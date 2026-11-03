using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Model;
using ProyectoPresupuestoEvento.Dto;
using ProyectoPresupuestoEvento.Repository;

namespace ProyectoPresupuestoEvento.Service
{
    // cuando una regla no se cumple, lanza InvalidOperationException con el mensaje
    // y el formulario lo muestra
    internal class QuoteService
    {

        public QuoteService()
        {

        }

        public void addQuote(QuoteDto dto)
        {
            Quote quote = toModel(dto);
            EventItem eventItem = getEventItem(quote.EventItemId);

            validateQuote(quote, null);

            quote.calculateTotals(eventItem.Duration);
            QuoteRepository.getInstance().addToRepository(quote);
        }

        public List<QuoteDto> getQuotes()
        {
            List<Quote> quotes = QuoteRepository.getInstance().getAll();
            List<QuoteDto> dtos = new List<QuoteDto>();

            foreach (Quote quote in quotes)
            {
                dtos.Add(toDto(quote));
            }

            return dtos;
        }

        public List<QuoteDto> getQuotesByEventItem(int eventItemId)
        {
            List<Quote> quotes = QuoteRepository.getInstance().getAll();
            List<QuoteDto> dtos = new List<QuoteDto>();

            foreach (Quote quote in quotes)
            {
                if (quote.EventItemId == eventItemId)
                {
                    dtos.Add(toDto(quote));
                }
            }

            return dtos;
        }

        public QuoteDto getQuoteById(int id)
        {
            Quote quote = QuoteRepository.getInstance().getById(id);
            if (quote == null)
            {
                return null;
            }
            return toDto(quote);
        }

        // al guardar, el presupuesto toma los precios actuales (toModel arma lineas nuevas)
        public void updateQuote(int id, QuoteDto dto)
        {
            Quote original = QuoteRepository.getInstance().getById(id);
            if (original == null)
            {
                return;
            }

            if (!original.isEditable())
            {
                throw new InvalidOperationException("solo se puede editar un presupuesto pendiente");
            }

            Quote quote = toModel(dto);
            // el evento de un presupuesto no se cambia
            quote.EventItemId = original.EventItemId;
            EventItem eventItem = getEventItem(quote.EventItemId);

            validateQuote(quote, original);

            quote.calculateTotals(eventItem.Duration);
            QuoteRepository.getInstance().update(id, quote);
        }

        public void removeQuote(int id)
        {
            QuoteRepository.getInstance().removeById(id);
        }

        // borra todos los presupuestos de un evento (se usa al eliminar el evento)
        public void removeQuotesByEventItem(int eventItemId)
        {
            // primero se juntan los ids, porque no se puede borrar de una lista mientras se recorre
            List<int> ids = new List<int>();
            foreach (Quote quote in QuoteRepository.getInstance().getAll())
            {
                if (quote.EventItemId == eventItemId)
                {
                    ids.Add(quote.Id);
                }
            }

            foreach (int id in ids)
            {
                QuoteRepository.getInstance().removeById(id);
            }
        }

        // se congela con los precios que tiene (no los actualiza)
        public void acceptQuote(int id)
        {
            Quote quote = QuoteRepository.getInstance().getById(id);
            if (quote == null)
            {
                return;
            }

            EventItem eventItem = getEventItem(quote.EventItemId);

            // un evento puede tener un solo presupuesto aceptado
            foreach (Quote otro in QuoteRepository.getInstance().getAll())
            {
                if (otro.Id != quote.Id && otro.EventItemId == quote.EventItemId && otro.State == EstadoPresupuesto.Aceptado)
                {
                    throw new InvalidOperationException("el evento ya tiene un presupuesto aceptado");
                }
            }

            // recalcula con la duracion actual antes de congelar
            quote.calculateTotals(eventItem.Duration);
            quote.accept();
            QuoteRepository.getInstance().update(id, quote);
        }

        public void cancelQuote(int id)
        {
            Quote quote = QuoteRepository.getInstance().getById(id);
            if (quote == null)
            {
                return;
            }

            quote.cancel();
            QuoteRepository.getInstance().update(id, quote);
        }

        public void cloneQuote(int id)
        {
            Quote original = QuoteRepository.getInstance().getById(id);
            if (original == null)
            {
                return;
            }

            // un presupuesto clonado solo puede usar elementos activos
            List<string> inactivos = getInactiveItems(original);
            if (inactivos.Count > 0)
            {
                throw new InvalidOperationException("no se puede clonar: usa elementos dados de baja ("
                    + string.Join(", ", inactivos) + ")");
            }

            Quote nuevo = original.clone();
            EventItem eventItem = getEventItem(nuevo.EventItemId);
            nuevo.calculateTotals(eventItem.Duration);
            QuoteRepository.getInstance().addToRepository(nuevo);
        }

        // arma el presupuesto y calcula sus totales SIN guardarlo.
        // lo usa el formulario para mostrar los totales mientras se carga.
        public QuoteDto calculatePreview(QuoteDto dto)
        {
            Quote quote = toModel(dto);
            EventItem eventItem = getEventItem(quote.EventItemId);
            quote.calculateTotals(eventItem.Duration);
            return toDto(quote);
        }



        //validaciones

        // original es el presupuesto antes de editarlo (null si es nuevo)
        private void validateQuote(Quote quote, Quote original)
        {
            // V5: cada linea tiene al menos un plato
            foreach (DetailMenu detailMenu in quote.MenusList)
            {
                if (detailMenu.AdultQuantity < 0 || detailMenu.ChildQuantity < 0
                    || detailMenu.AdultQuantity + detailMenu.ChildQuantity == 0)
                {
                    throw new InvalidOperationException("cada linea de catering tiene que tener al menos un plato");
                }
            }

            // V7: el mismo menu con la misma etiqueta no puede estar dos veces
            for (int i = 0; i < quote.MenusList.Count; i++)
            {
                for (int j = i + 1; j < quote.MenusList.Count; j++)
                {
                    DetailMenu a = quote.MenusList[i];
                    DetailMenu b = quote.MenusList[j];
                    if (a.Menu.Id == b.Menu.Id && a.TagDescription == b.TagDescription)
                    {
                        throw new InvalidOperationException("la variante " + a.Menu.Description + " " + a.TagDescription + " esta repetida");
                    }
                }
            }

            // V15: la etiqueta tiene que ser una de las que tiene el menu
            foreach (DetailMenu detailMenu in quote.MenusList)
            {
                bool tieneLaEtiqueta = false;
                foreach (MenuTag tag in detailMenu.Menu.TagList)
                {
                    if (tag.Description == detailMenu.TagDescription)
                    {
                        tieneLaEtiqueta = true;
                    }
                }
                if (!tieneLaEtiqueta)
                {
                    throw new InvalidOperationException("el menu " + detailMenu.Menu.Description + " no tiene la etiqueta " + detailMenu.TagDescription);
                }
            }

            // V8: el mismo servicio no puede estar dos veces
            for (int i = 0; i < quote.OptionItemList.Count; i++)
            {
                for (int j = i + 1; j < quote.OptionItemList.Count; j++)
                {
                    if (quote.OptionItemList[i].OptionItem.Id == quote.OptionItemList[j].OptionItem.Id)
                    {
                        throw new InvalidOperationException("el servicio " + quote.OptionItemList[i].OptionItem.Name + " esta repetido");
                    }
                }
            }

            // V9: no hay limite de platos (puede haber varios bloques de menu o platos de mas)

            // V12: solo elementos activos. Al editar, se pueden conservar los que ya tenia.
            List<string> inactivos = getInactiveItems(quote);
            foreach (string nombre in inactivos)
            {
                if (original == null || !getInactiveItems(original).Contains(nombre))
                {
                    throw new InvalidOperationException("no se puede usar " + nombre + " porque esta dado de baja");
                }
            }
        }

        // devuelve los nombres de la ubicacion, menus y servicios dados de baja que usa el presupuesto
        private List<string> getInactiveItems(Quote quote)
        {
            List<string> nombres = new List<string>();

            if (!quote.Ubication.IsActive)
            {
                nombres.Add(quote.Ubication.Name);
            }

            foreach (DetailMenu detailMenu in quote.MenusList)
            {
                if (!detailMenu.Menu.IsActive && !nombres.Contains(detailMenu.Menu.Description))
                {
                    nombres.Add(detailMenu.Menu.Description);
                }
            }

            foreach (DetailOptionItem detailOptionItem in quote.OptionItemList)
            {
                if (!detailOptionItem.OptionItem.IsActive)
                {
                    nombres.Add(detailOptionItem.OptionItem.Name);
                }
            }

            return nombres;
        }

        private EventItem getEventItem(int eventItemId)
        {
            EventItem eventItem = EventItemRepository.getInstance().getById(eventItemId);
            if (eventItem == null)
            {
                throw new InvalidOperationException("seleccione un evento");
            }
            return eventItem;
        }



        //conversiones

        // busca la ubicacion, los menus y los servicios por id.
        // las lineas nuevas copian los precios actuales.
        public Quote toModel(QuoteDto dto)
        {
            // V6: el presupuesto tiene que tener ubicacion
            Ubication ubication = UbicationRepository.getInstance().getById(dto.UbicationId);
            if (ubication == null)
            {
                throw new InvalidOperationException("seleccione una ubicacion");
            }

            List<DetailMenu> menus = new List<DetailMenu>();
            foreach (DetailMenuDto lineDto in dto.MenusList)
            {
                Menu menu = MenuRepository.getInstance().getById(lineDto.MenuId);
                if (menu == null)
                {
                    throw new InvalidOperationException("no se encontro el menu elegido");
                }
                menus.Add(new DetailMenu(menu, lineDto.TagDescription, lineDto.AdultQuantity, lineDto.ChildQuantity));
            }

            List<DetailOptionItem> optionItems = new List<DetailOptionItem>();
            foreach (DetailOptionItemDto lineDto in dto.OptionItemsList)
            {
                OptionItem optionItem = OptionItemRepository.getInstance().getById(lineDto.OptionItemId);
                if (optionItem == null)
                {
                    throw new InvalidOperationException("no se encontro el servicio elegido");
                }
                optionItems.Add(new DetailOptionItem(optionItem));
            }

            Quote quote = new Quote(dto.EventItemId, ubication, menus, optionItems);
            return quote;
        }

        // si el presupuesto esta Pendiente, antes recalcula los totales con la duracion actual del evento
        public QuoteDto toDto(Quote quote)
        {
            EventItem eventItem = EventItemRepository.getInstance().getById(quote.EventItemId);
            if (eventItem != null)
            {
                quote.calculateTotals(eventItem.Duration);
            }

            List<DetailMenuDto> menusDto = new List<DetailMenuDto>();
            foreach (DetailMenu detailMenu in quote.MenusList)
            {
                DetailMenuDto lineDto = new DetailMenuDto(detailMenu.Menu.Id, detailMenu.TagDescription,
                    detailMenu.AdultQuantity, detailMenu.ChildQuantity);
                lineDto.MenuDescription = detailMenu.Menu.Description;
                lineDto.UnitPriceAdult = detailMenu.UnitPriceAdult;
                lineDto.UnitPriceChild = detailMenu.UnitPriceChild;
                lineDto.Subtotal = detailMenu.calculateSubtotal();
                menusDto.Add(lineDto);
            }

            List<DetailOptionItemDto> optionItemsDto = new List<DetailOptionItemDto>();
            foreach (DetailOptionItem detailOptionItem in quote.OptionItemList)
            {
                DetailOptionItemDto lineDto = new DetailOptionItemDto(detailOptionItem.OptionItem.Id);
                lineDto.OptionItemName = detailOptionItem.OptionItem.Name;
                lineDto.UnitPrice = detailOptionItem.UnitPrice;
                optionItemsDto.Add(lineDto);
            }

            QuoteDto dto = new QuoteDto(quote.EventItemId, quote.Ubication.Id, menusDto, optionItemsDto);
            dto.Id = quote.Id;
            dto.UbicationName = quote.Ubication.Name;
            dto.UbicationPrice = quote.UbicationPrice;
            dto.State = quote.State;
            dto.TotalUbication = quote.TotalUbication;
            dto.TotalMenus = quote.TotalMenus;
            dto.TotalOptionItems = quote.TotalOptionItems;
            dto.Total = quote.Total;

            if (eventItem != null)
            {
                dto.EventItemName = eventItem.Name;
                dto.EventDate = eventItem.Date;
                dto.TotalGuests = eventItem.getTotalGuests();
            }

            return dto;
        }
    }
}
