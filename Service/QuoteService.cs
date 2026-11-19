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
        private IRepository<Location> locationRepository;
        private IRepository<Menu> menuRepository;
        private IRepository<OptionItem> optionItemRepository;
        private QuoteValidator validator;
        private QuotePdfGenerator pdfGenerator;

        // el controller usa este: le pasa los repositorios reales al otro constructor
        public QuoteService()
            : this(QuoteRepository.GetInstance(), EventItemRepository.GetInstance(), LocationRepository.GetInstance(),
                  MenuRepository.GetInstance(), OptionItemRepository.GetInstance())
        {
        }

        // recibe los repositorios desde afuera (inyeccion de dependencias)
        public QuoteService(IRepository<Quote> repository, IRepository<EventItem> eventItemRepository,
            IRepository<Location> locationRepository, IRepository<Menu> menuRepository, IRepository<OptionItem> optionItemRepository)
        {
            this.repository = repository;
            this.eventItemRepository = eventItemRepository;
            this.locationRepository = locationRepository;
            this.menuRepository = menuRepository;
            this.optionItemRepository = optionItemRepository;
            validator = new QuoteValidator(repository, eventItemRepository);
            pdfGenerator = new QuotePdfGenerator();
        }

        // crea un presupuesto nuevo con los datos actuales del evento, la ubicacion, los menus y los servicios
        public void AddQuote(QuoteDto dto)
        {
            Quote quote = ToModel(dto);

            validator.ValidateEventNotPast(quote.EventDate, "crear");
            validator.ValidateQuote(quote, null);

            quote.CalculateTotals();
            repository.AddToRepository(quote);
        }

        // devuelve todos los presupuestos como dto, usando solo sus datos congelados
        public List<QuoteDto> GetQuotes()
        {
            List<Quote> quotes = repository.GetAll();
            List<QuoteDto> dtos = new List<QuoteDto>();

            foreach (Quote quote in quotes)
            {
                dtos.Add(ToDto(quote));
            }

            return dtos;
        }

        public List<QuoteDto> GetQuotesByEventItem(int eventItemId)
        {
            List<Quote> quotes = repository.GetAll();
            List<QuoteDto> dtos = new List<QuoteDto>();

            foreach (Quote quote in quotes)
            {
                if (quote.EventItemId == eventItemId)
                {
                    dtos.Add(ToDto(quote));
                }
            }

            return dtos;
        }

        public QuoteDto GetQuoteById(int id)
        {
            Quote quote = repository.GetById(id);
            return ToDto(quote);
        }

        // solo edita un pendiente: arma todo de nuevo con toModel, asi toma los datos y precios actuales
        public void UpdateQuote(int id, QuoteDto dto)
        {
            Quote original = repository.GetById(id);
            if (!original.IsEditable())
            {
                throw new BusinessRuleException("solo se puede editar un presupuesto pendiente");
            }

            // el evento de un presupuesto no se puede cambiar
            dto.EventItemId = original.EventItemId;
            Quote quote = ToModel(dto);

            validator.ValidateQuote(quote, original);

            quote.CalculateTotals();
            repository.Update(id, quote);
        }

        public void RemoveQuote(int id)
        {
            repository.RemoveById(id);
        }

        // acepta un presupuesto: desde ahi queda congelado
        public void AcceptQuote(int id)
        {
            Quote quote = repository.GetById(id);
            // cambia el estado solo en memoria: si alguna validacion falla, no se guarda nada
            quote.Accept();

            validator.ValidateEventNotPast(quote.EventDate, "aceptar");
            validator.ValidateEventNotChanged(quote);
            validator.ValidateNoOtherAccepted(quote);
            validator.ValidateLocationFree(quote);

            // recien aca se guarda el nuevo estado
            repository.Update(id, quote);
        }

        public void CancelQuote(int id)
        {
            Quote quote = repository.GetById(id);
            quote.Cancel();
            repository.Update(id, quote);
        }

        // crea un pendiente nuevo con la misma ubicacion, menus y servicios que el original
        public void CloneQuote(int id)
        {
            Quote original = repository.GetById(id);
            validator.ValidateCanClone(original);

            EventItem eventItem = GetEventItem(original.EventItemId);
            validator.ValidateEventNotPast(eventItem.Date, "clonar");

            // el clon toma los datos y precios actuales, no las copias del original
            Quote newQuote = original.Clone(eventItem);
            // las lineas se revisan como si se armara a mano: por ejemplo, el menu puede haber perdido la etiqueta
            validator.ValidateQuote(newQuote, null);

            newQuote.CalculateTotals();
            repository.AddToRepository(newQuote);
        }

        // calcula los totales mientras se carga el presupuesto, sin guardarlo
        // genera el pdf del presupuesto en la ruta indicada, con sus datos congelados
        public void ExportPdf(int id, string path)
        {
            Quote quote = repository.GetById(id);
            pdfGenerator.Generate(quote, path);
        }

        public QuoteDto CalculatePreview(QuoteDto dto)
        {
            Quote quote = ToModel(dto);
            quote.CalculateTotals();
            return ToDto(quote);
        }



        //auxiliares

        private EventItem GetEventItem(int eventItemId)
        {
            return eventItemRepository.GetById(eventItemId);
        }



        //conversiones

        // busca los objetos reales por id en sus repositorios, y el presupuesto y sus lineas copian sus datos
        public Quote ToModel(QuoteDto dto)
        {
            EventItem eventItem = GetEventItem(dto.EventItemId);
            Location location = locationRepository.GetById(dto.LocationId);

            List<DetailMenu> menus = new List<DetailMenu>();
            foreach (DetailMenuDto lineDto in dto.MenusList)
            {
                Menu menu = menuRepository.GetById(lineDto.MenuId);
                menus.Add(new DetailMenu(menu, lineDto.TagDescription, lineDto.AdultQuantity, lineDto.ChildQuantity));
            }

            List<DetailOptionItem> optionItems = new List<DetailOptionItem>();
            foreach (DetailOptionItemDto lineDto in dto.OptionItemsList)
            {
                OptionItem optionItem = optionItemRepository.GetById(lineDto.OptionItemId);
                optionItems.Add(new DetailOptionItem(optionItem));
            }

            Quote quote = new Quote(eventItem, location, menus, optionItems);
            return quote;
        }

        // pasa al dto solo las copias congeladas, sin consultar otras entidades
        public QuoteDto ToDto(Quote quote)
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

            QuoteDto dto = new QuoteDto(quote.EventItemId, quote.Location.Id, menusDto, optionItemsDto);
            dto.Id = quote.Id;
            dto.LocationName = quote.LocationName;
            dto.LocationPrice = quote.LocationPrice;
            dto.State = quote.State;
            dto.TotalLocation = quote.TotalLocation;
            dto.TotalMenus = quote.TotalMenus;
            dto.TotalOptionItems = quote.TotalOptionItems;
            dto.Total = quote.Total;

            dto.EventItemName = quote.EventName;
            dto.EventClientName = quote.EventClientName;
            dto.EventDate = quote.EventDate;
            dto.EventGuestAdults = quote.EventGuestAdults;
            dto.EventGuestChildren = quote.EventGuestChildren;
            dto.EventDuration = quote.EventDuration;
            dto.TotalGuests = quote.TotalGuests;

            return dto;
        }
    }
}
