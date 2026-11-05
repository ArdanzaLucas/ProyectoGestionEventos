using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Model;
using ProyectoPresupuestoEvento.Dto;
using ProyectoPresupuestoEvento.Repository;
using ProyectoPresupuestoEvento.Common;

namespace ProyectoPresupuestoEvento.Service
{
    internal class QuoteService
    {

        public QuoteService()
        {

        }

        public void addQuote(QuoteDto dto)
        {
            Quote quote = toModel(dto);

            validateQuote(quote, null);

            quote.calculateTotals();
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

        public void updateQuote(int id, QuoteDto dto)
        {
            Quote original = QuoteRepository.getInstance().getById(id);
            if (original == null)
            {
                return;
            }

            if (!original.isEditable())
            {
                throw new BusinessRuleException("solo se puede editar un presupuesto pendiente");
            }

            dto.EventItemId = original.EventItemId;
            Quote quote = toModel(dto);

            validateQuote(quote, original);

            quote.calculateTotals();
            QuoteRepository.getInstance().update(id, quote);
        }

        public void removeQuote(int id)
        {
            QuoteRepository.getInstance().removeById(id);
        }

        public void removeQuotesByEventItem(int eventItemId)
        {
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

        public void acceptQuote(int id)
        {
            Quote quote = QuoteRepository.getInstance().getById(id);
            if (quote == null)
            {
                return;
            }

            foreach (Quote otro in QuoteRepository.getInstance().getAll())
            {
                if (otro.Id != quote.Id && otro.EventItemId == quote.EventItemId && otro.State == EstadoPresupuesto.Aceptado)
                {
                    throw new BusinessRuleException("el evento ya tiene un presupuesto aceptado");
                }
            }

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

            List<string> inactivos = getInactiveItems(original);
            if (inactivos.Count > 0)
            {
                throw new BusinessRuleException("no se puede clonar: usa elementos dados de baja ("
                    + string.Join(", ", inactivos) + ")");
            }

            EventItem eventItem = getEventItem(original.EventItemId);
            Quote nuevo = original.clone(eventItem);
            nuevo.calculateTotals();
            QuoteRepository.getInstance().addToRepository(nuevo);
        }

        public QuoteDto calculatePreview(QuoteDto dto)
        {
            Quote quote = toModel(dto);
            quote.calculateTotals();
            return toDto(quote);
        }



        //validaciones

        private void validateQuote(Quote quote, Quote original)
        {
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

            List<string> inactivos = getInactiveItems(quote);
            foreach (string nombre in inactivos)
            {
                if (original == null || !getInactiveItems(original).Contains(nombre))
                {
                    throw new BusinessRuleException("no se puede usar " + nombre + " porque esta dado de baja");
                }
            }
        }

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
            if (eventItem == null)
            {
                throw new BusinessRuleException("seleccione un evento");
            }
            return eventItem;
        }



        //conversiones

        public Quote toModel(QuoteDto dto)
        {
            EventItem eventItem = getEventItem(dto.EventItemId);

            UbicationService ubicationService = new UbicationService();
            Ubication ubication = ubicationService.getModelById(dto.UbicationId);
            if (ubication == null)
            {
                throw new BusinessRuleException("seleccione una ubicacion");
            }

            MenuService menuService = new MenuService();
            List<DetailMenu> menus = new List<DetailMenu>();
            foreach (DetailMenuDto lineDto in dto.MenusList)
            {
                Menu menu = menuService.getModelById(lineDto.MenuId);
                if (menu == null)
                {
                    throw new BusinessRuleException("no se encontro el menu elegido");
                }
                menus.Add(new DetailMenu(menu, lineDto.TagDescription, lineDto.AdultQuantity, lineDto.ChildQuantity));
            }

            OptionItemService optionItemService = new OptionItemService();
            List<DetailOptionItem> optionItems = new List<DetailOptionItem>();
            foreach (DetailOptionItemDto lineDto in dto.OptionItemsList)
            {
                OptionItem optionItem = optionItemService.getModelById(lineDto.OptionItemId);
                if (optionItem == null)
                {
                    throw new BusinessRuleException("no se encontro el servicio elegido");
                }
                optionItems.Add(new DetailOptionItem(optionItem));
            }

            Quote quote = new Quote(eventItem, ubication, menus, optionItems);
            return quote;
        }

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
