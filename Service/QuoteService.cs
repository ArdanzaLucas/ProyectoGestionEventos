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
        // se guardan como la interfaz: el service no sabe que los datos estan en SQLite
        private IRepository<Quote> repository;
        private IRepository<EventItem> eventItemRepository;
        private IRepository<Ubication> ubicationRepository;
        private IRepository<Menu> menuRepository;
        private IRepository<OptionItem> optionItemRepository;
        private QuoteValidator validator;

        // el controller usa este: le pasa los repositorios reales al otro constructor
        public QuoteService()
            : this(QuoteRepository.getInstance(), EventItemRepository.getInstance(), UbicationRepository.getInstance(),
                  MenuRepository.getInstance(), OptionItemRepository.getInstance())
        {
        }

        // recibe los repositorios desde afuera (inyeccion de dependencias)
        public QuoteService(IRepository<Quote> repository, IRepository<EventItem> eventItemRepository,
            IRepository<Ubication> ubicationRepository, IRepository<Menu> menuRepository, IRepository<OptionItem> optionItemRepository)
        {
            this.repository = repository;
            this.eventItemRepository = eventItemRepository;
            this.ubicationRepository = ubicationRepository;
            this.menuRepository = menuRepository;
            this.optionItemRepository = optionItemRepository;
            validator = new QuoteValidator(repository, eventItemRepository);
        }

        // crea un presupuesto nuevo con los datos actuales del evento, la ubicacion, los menus y los servicios
        public void addQuote(QuoteDto dto)
        {
            Quote quote = toModel(dto);

            validator.validateEventNotPast(quote.EventDate, "crear");
            validator.validateQuote(quote, null);

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

            validator.validateQuote(quote, original);

            quote.calculateTotals();
            repository.update(id, quote);
        }

        public void removeQuote(int id)
        {
            repository.removeById(id);
        }

        // acepta un presupuesto: desde ahi queda congelado
        public void acceptQuote(int id)
        {
            Quote quote = repository.getById(id);
            // cambia el estado solo en memoria: si alguna validacion falla, no se guarda nada
            quote.accept();

            validator.validateEventNotPast(quote.EventDate, "aceptar");
            validator.validateEventNotChanged(quote);
            validator.validateNoOtherAccepted(quote);
            validator.validateUbicationFree(quote);

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
            validator.validateCanClone(original);

            EventItem eventItem = getEventItem(original.EventItemId);
            validator.validateEventNotPast(eventItem.Date, "clonar");

            // el clon toma los datos y precios actuales, no las copias del original
            Quote nuevo = original.clone(eventItem);
            // las lineas se revisan como si se armara a mano: por ejemplo, el menu puede haber perdido la etiqueta
            validator.validateQuote(nuevo, null);

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



        //auxiliares

        private EventItem getEventItem(int eventItemId)
        {
            return eventItemRepository.getById(eventItemId);
        }



        //conversiones

        // busca los objetos reales por id en sus repositorios, y el presupuesto y sus lineas copian sus datos
        public Quote toModel(QuoteDto dto)
        {
            EventItem eventItem = getEventItem(dto.EventItemId);
            Ubication ubication = ubicationRepository.getById(dto.UbicationId);

            List<DetailMenu> menus = new List<DetailMenu>();
            foreach (DetailMenuDto lineDto in dto.MenusList)
            {
                Menu menu = menuRepository.getById(lineDto.MenuId);
                menus.Add(new DetailMenu(menu, lineDto.TagDescription, lineDto.AdultQuantity, lineDto.ChildQuantity));
            }

            List<DetailOptionItem> optionItems = new List<DetailOptionItem>();
            foreach (DetailOptionItemDto lineDto in dto.OptionItemsList)
            {
                OptionItem optionItem = optionItemRepository.getById(lineDto.OptionItemId);
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
