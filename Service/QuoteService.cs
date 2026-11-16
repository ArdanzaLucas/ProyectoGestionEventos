using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Model;
using ProyectoPresupuestoEvento.Dto;
using ProyectoPresupuestoEvento.Repository;
using ProyectoPresupuestoEvento.Interface;
using ProyectoPresupuestoEvento.Common;

namespace ProyectoPresupuestoEvento.Service
{
    // logica de los presupuestos: armarlos, validarlos, calcularlos y cambiar su estado
    internal class QuoteService
    {
        // se guarda como la interfaz: el service no sabe que los datos estan en SQLite
        private IRepository<Quote> repository;

        public QuoteService()
        {
            repository = QuoteRepository.getInstance();
        }

        // crea un presupuesto nuevo con los datos actuales del evento, la ubicacion, los menus y los servicios
        public void addQuote(QuoteDto dto)
        {
            Quote quote = toModel(dto);

            validateEventNotPast(quote.EventDate, "crear");
            validateQuote(quote, null);

            quote.calculateTotals();
            repository.addToRepository(quote);
        }

        // devuelve todos los presupuestos como dto, usando solo sus datos congelados
        public List<QuoteDto> getQuotes()
        {
            List<Quote> quotes = repository.getAll();
            List<QuoteDto> dtos = new List<QuoteDto>();

            foreach (Quote quote in quotes)
            {
                dtos.Add(toDto(quote));
            }

            return dtos;
        }

        public List<QuoteDto> getQuotesByEventItem(int eventItemId)
        {
            List<Quote> quotes = repository.getAll();
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
            Quote quote = repository.getById(id);
            return toDto(quote);
        }

        // lo usa EventItemService para saber si puede cambiar la fecha del evento
        public bool hasAcceptedQuote(int eventItemId)
        {
            foreach (Quote quote in repository.getAll())
            {
                if (quote.EventItemId == eventItemId && quote.State == EstadoPresupuesto.Aceptado)
                {
                    return true;
                }
            }
            return false;
        }

        // solo edita un pendiente: arma todo de nuevo con toModel, asi toma los datos y precios actuales
        public void updateQuote(int id, QuoteDto dto)
        {
            Quote original = repository.getById(id);
            if (!original.isEditable())
            {
                throw new BusinessRuleException("solo se puede editar un presupuesto pendiente");
            }

            // el evento de un presupuesto no se puede cambiar
            dto.EventItemId = original.EventItemId;
            Quote quote = toModel(dto);

            validateQuote(quote, original);

            quote.calculateTotals();
            repository.update(id, quote);
        }

        public void removeQuote(int id)
        {
            repository.removeById(id);
        }

        // borra los presupuestos de un evento, lo llama EventItemService al borrar el evento
        public void removeQuotesByEventItem(int eventItemId)
        {
            // primero junta los ids y despues borra, para no borrar mientras recorre la lista
            List<int> ids = new List<int>();
            foreach (Quote quote in repository.getAll())
            {
                if (quote.EventItemId == eventItemId)
                {
                    ids.Add(quote.Id);
                }
            }

            foreach (int id in ids)
            {
                repository.removeById(id);
            }
        }

        // acepta un presupuesto: desde ahi queda congelado
        public void acceptQuote(int id)
        {
            Quote quote = repository.getById(id);
            // cambia el estado solo en memoria: si alguna validacion falla, no se guarda nada
            quote.accept();

            validateEventNotPast(quote.EventDate, "aceptar");
            validateEventNotChanged(quote);

            foreach (Quote otro in repository.getAll())
            {
                if (otro.Id != quote.Id && otro.EventItemId == quote.EventItemId && otro.State == EstadoPresupuesto.Aceptado)
                {
                    throw new BusinessRuleException("el evento ya tiene un presupuesto aceptado");
                }
            }

            validateUbicationFree(quote);

            // recien aca se guarda el nuevo estado
            repository.update(id, quote);
        }

        public void cancelQuote(int id)
        {
            Quote quote = repository.getById(id);
            quote.cancel();
            repository.update(id, quote);
        }

        // crea un pendiente nuevo con la misma ubicacion, menus y servicios que el original
        public void cloneQuote(int id)
        {
            Quote original = repository.getById(id);
            // no se puede clonar si usa algo dado de baja
            List<string> inactivos = getInactiveItems(original);
            if (inactivos.Count > 0)
            {
                throw new BusinessRuleException("no se puede clonar: usa elementos dados de baja ("
                    + string.Join(", ", inactivos) + ")");
            }

            EventItem eventItem = getEventItem(original.EventItemId);
            validateEventNotPast(eventItem.Date, "clonar");

            // el clon toma los datos y precios actuales, no las copias del original
            Quote nuevo = original.clone(eventItem);
            // las lineas se revisan como si se armara a mano: por ejemplo, el menu puede haber perdido la etiqueta
            validateQuote(nuevo, null);

            nuevo.calculateTotals();
            repository.addToRepository(nuevo);
        }

        // calcula los totales mientras se carga el presupuesto, sin guardarlo
        public QuoteDto calculatePreview(QuoteDto dto)
        {
            Quote quote = toModel(dto);
            quote.calculateTotals();
            return toDto(quote);
        }



        //validaciones

        // reglas de las lineas: platos, variantes repetidas, etiquetas del menu, servicios repetidos y elementos de baja
        private void validateQuote(Quote quote, Quote original)
        {
            foreach (DetailMenu detailMenu in quote.MenusList)
            {
                if (detailMenu.AdultQuantity + detailMenu.ChildQuantity == 0)
                {
                    throw new BusinessRuleException("cada linea de catering tiene que tener al menos un plato");
                }
            }

            for (int i = 0; i < quote.MenusList.Count; i++)
            {
                for (int j = i + 1; j < quote.MenusList.Count; j++)
                {
                    DetailMenu a = quote.MenusList[i];
                    DetailMenu b = quote.MenusList[j];
                    if (a.Menu.Id == b.Menu.Id && a.TagDescription == b.TagDescription)
                    {
                        throw new BusinessRuleException("la variante " + a.Menu.Description + " " + a.TagDescription + " esta repetida");
                    }
                }
            }

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
                    throw new BusinessRuleException("el menu " + detailMenu.Menu.Description + " no tiene la etiqueta " + detailMenu.TagDescription);
                }
            }

            for (int i = 0; i < quote.OptionItemList.Count; i++)
            {
                for (int j = i + 1; j < quote.OptionItemList.Count; j++)
                {
                    if (quote.OptionItemList[i].OptionItem.Id == quote.OptionItemList[j].OptionItem.Id)
                    {
                        throw new BusinessRuleException("el servicio " + quote.OptionItemList[i].OptionItem.Name + " esta repetido");
                    }
                }
            }

            // al editar se pueden conservar los elementos de baja que ya tenia el original
            List<string> inactivos = getInactiveItems(quote);
            foreach (string nombre in inactivos)
            {
                if (original == null || !getInactiveItems(original).Contains(nombre))
                {
                    throw new BusinessRuleException("no se puede usar " + nombre + " porque esta dado de baja");
                }
            }
        }

        private void validateEventNotPast(DateTime eventDate, string accion)
        {
            if (eventDate.Date < DateTime.Today)
            {
                throw new BusinessRuleException("no se puede " + accion + " un presupuesto de un evento que ya paso");
            }
        }

        // compara las copias del presupuesto con el evento actual
        private void validateEventNotChanged(Quote quote)
        {
            EventItem eventItem = getEventItem(quote.EventItemId);

            bool igual = quote.EventName == eventItem.Name
                && quote.EventClientName == eventItem.ClientName
                && quote.EventDate.ToString("yyyy-MM-dd HH:mm") == eventItem.Date.ToString("yyyy-MM-dd HH:mm")
                && quote.EventGuestAdults == eventItem.GuestAdults
                && quote.EventGuestChilds == eventItem.GuestChilds
                && quote.EventDuration == eventItem.Duration;

            if (!igual)
            {
                throw new BusinessRuleException("los datos del evento cambiaron: edite y guarde el presupuesto antes de aceptarlo");
            }
        }

        // busca otro aceptado en el mismo salon con un horario que se pise
        private void validateUbicationFree(Quote quote)
        {
            foreach (Quote otro in repository.getAll())
            {
                if (otro.Id != quote.Id && otro.State == EstadoPresupuesto.Aceptado && otro.Ubication.Id == quote.Ubication.Id && quote.overlapsWith(otro))
                {
                    throw new BusinessRuleException("la ubicacion ya esta ocupada en ese horario por el evento " + otro.EventName);
                }
            }
        }

        // nombres de la ubicacion, los menus y los servicios dados de baja que usa el presupuesto
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
            EventItemService eventItemService = new EventItemService();
            EventItem eventItem = eventItemService.getModelById(eventItemId);
            return eventItem;
        }



        //conversiones

        // pide los objetos reales por id a cada service, y el presupuesto y sus lineas copian sus datos
        public Quote toModel(QuoteDto dto)
        {
            EventItem eventItem = getEventItem(dto.EventItemId);

            UbicationService ubicationService = new UbicationService();
            Ubication ubication = ubicationService.getModelById(dto.UbicationId);
            MenuService menuService = new MenuService();
            List<DetailMenu> menus = new List<DetailMenu>();
            foreach (DetailMenuDto lineDto in dto.MenusList)
            {
                Menu menu = menuService.getModelById(lineDto.MenuId);
                menus.Add(new DetailMenu(menu, lineDto.TagDescription, lineDto.AdultQuantity, lineDto.ChildQuantity));
            }

            OptionItemService optionItemService = new OptionItemService();
            List<DetailOptionItem> optionItems = new List<DetailOptionItem>();
            foreach (DetailOptionItemDto lineDto in dto.OptionItemsList)
            {
                OptionItem optionItem = optionItemService.getModelById(lineDto.OptionItemId);
                optionItems.Add(new DetailOptionItem(optionItem));
            }

            Quote quote = new Quote(eventItem, ubication, menus, optionItems);
            return quote;
        }

        // pasa al dto solo las copias congeladas, sin consultar otras entidades
        public QuoteDto toDto(Quote quote)
        {
            List<DetailMenuDto> menusDto = new List<DetailMenuDto>();
            foreach (DetailMenu detailMenu in quote.MenusList)
            {
                DetailMenuDto lineDto = new DetailMenuDto(detailMenu.Menu.Id, detailMenu.TagDescription,
                    detailMenu.AdultQuantity, detailMenu.ChildQuantity);
                lineDto.MenuDescription = detailMenu.MenuDescription;
                lineDto.UnitPriceAdult = detailMenu.UnitPriceAdult;
                lineDto.UnitPriceChild = detailMenu.UnitPriceChild;
                lineDto.Subtotal = detailMenu.Subtotal;
                menusDto.Add(lineDto);
            }

            List<DetailOptionItemDto> optionItemsDto = new List<DetailOptionItemDto>();
            foreach (DetailOptionItem detailOptionItem in quote.OptionItemList)
            {
                DetailOptionItemDto lineDto = new DetailOptionItemDto(detailOptionItem.OptionItem.Id);
                lineDto.OptionItemName = detailOptionItem.OptionItemName;
                lineDto.UnitPrice = detailOptionItem.UnitPrice;
                optionItemsDto.Add(lineDto);
            }

            QuoteDto dto = new QuoteDto(quote.EventItemId, quote.Ubication.Id, menusDto, optionItemsDto);
            dto.Id = quote.Id;
            dto.UbicationName = quote.UbicationName;
            dto.UbicationPrice = quote.UbicationPrice;
            dto.State = quote.State;
            dto.TotalUbication = quote.TotalUbication;
            dto.TotalMenus = quote.TotalMenus;
            dto.TotalOptionItems = quote.TotalOptionItems;
            dto.Total = quote.Total;

            dto.EventItemName = quote.EventName;
            dto.EventClientName = quote.EventClientName;
            dto.EventDate = quote.EventDate;
            dto.EventGuestAdults = quote.EventGuestAdults;
            dto.EventGuestChilds = quote.EventGuestChilds;
            dto.EventDuration = quote.EventDuration;
            dto.TotalGuests = quote.TotalGuests;

            return dto;
        }
    }
}
