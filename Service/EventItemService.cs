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
    // logica de los eventos y sus reglas
    internal class EventItemService
    {
        // se guardan como la interfaz: el service no sabe que los datos estan en SQLite
        private IRemovableRepository<EventItem> repository;
        private IRemovableRepository<Quote> quoteRepository;
        private IClock clock;

        // el controller usa este: le pasa los repositorios y el reloj reales al otro constructor
        public EventItemService()
            : this(EventItemRepository.GetInstance(), QuoteRepository.GetInstance(), new SystemClock())
        {
        }

        // recibe sus dependencias desde afuera (inyeccion de dependencias)
        public EventItemService(IRemovableRepository<EventItem> repository, IRemovableRepository<Quote> quoteRepository, IClock clock)
        {
            this.repository = repository;
            this.quoteRepository = quoteRepository;
            this.clock = clock;
        }

        // crea un evento: la fecha no puede ser anterior a hoy
        public void AddToRepository(EventItemDto dto)
        {
            if (dto.Date.Date < clock.Today)
            {
                throw new BusinessRuleException("la fecha del evento no puede ser anterior a hoy");
            }

            EventItem eventItem = ToModel(dto);
            ValidateHasGuests(eventItem);
            ValidateNotRepeated(eventItem, 0);
            repository.AddToRepository(eventItem);
        }

        public List<EventItemDto> GetEventItems()
        {
            List<EventItem> eventItems = repository.GetAll();
            List<EventItemDto> dtos = new List<EventItemDto>();

            foreach (EventItem eventItem in eventItems)
            {
                EventItemDto dto = ToDto(eventItem);
                dtos.Add(dto);
            }

            return dtos;
        }

        public void UpdateEventItem(int id, EventItemDto dto)
        {
            EventItem eventItem = ToModel(dto);
            ValidateHasGuests(eventItem);
            ValidateNotRepeated(eventItem, id);
            ValidateScheduleChange(id, eventItem);
            repository.Update(id, eventItem);
        }

        // no deja cambiar fecha, hora ni duracion si el evento tiene un presupuesto aceptado
        private void ValidateScheduleChange(int id, EventItem eventItem)
        {
            EventItem original = repository.GetById(id);
            // compara hasta el minuto, porque el formulario no muestra los segundos
            bool dateChanged = original.Date.ToString("yyyy-MM-dd HH:mm") != eventItem.Date.ToString("yyyy-MM-dd HH:mm");
            bool durationChanged = original.Duration != eventItem.Duration;

            if (dateChanged || durationChanged)
            {
                foreach (Quote quote in GetQuotes(id))
                {
                    if (quote.State == QuoteState.Accepted)
                    {
                        throw new BusinessRuleException("no se puede cambiar la fecha, la hora ni la duracion de un evento con un presupuesto aceptado");
                    }
                }
            }
        }

        // va aca y no en un set, porque al cargar los adultos los niños todavia valen 0
        private void ValidateHasGuests(EventItem eventItem)
        {
            if (eventItem.TotalGuests == 0)
            {
                throw new BusinessRuleException("el evento tiene que tener al menos un invitado");
            }
        }

        // no puede haber dos eventos con el mismo nombre, cliente y dia
        private void ValidateNotRepeated(EventItem eventItem, int editingId)
        {
            foreach (EventItem other in repository.GetAll())
            {
                if (other.Id != editingId
                    && other.Name.ToLower() == eventItem.Name.ToLower()
                    && other.ClientName.ToLower() == eventItem.ClientName.ToLower()
                    && other.Date.Date == eventItem.Date.Date)
                {
                    throw new BusinessRuleException("ya existe un evento con ese nombre, cliente y fecha");
                }
            }
        }

        // borra primero los presupuestos del evento y despues el evento
        public void RemoveEventItem(int id)
        {
            foreach (Quote quote in GetQuotes(id))
            {
                quoteRepository.RemoveById(quote.Id);
            }

            repository.RemoveById(id);
        }

        public int CountQuotes(int id)
        {
            return GetQuotes(id).Count;
        }

        // presupuestos de un evento
        private List<Quote> GetQuotes(int eventItemId)
        {
            List<Quote> quotes = new List<Quote>();
            foreach (Quote quote in quoteRepository.GetAll())
            {
                if (quote.EventItemId == eventItemId)
                {
                    quotes.Add(quote);
                }
            }
            return quotes;
        }

        public EventItem ToModel(EventItemDto dto)
        {
            EventItem model = new EventItem(dto.Name, dto.ClientName, dto.Date, dto.GuestAdults, dto.GuestChildren, dto.Duration);
            return model;
        }

        public EventItemDto ToDto(EventItem eventItem)
        {
            EventItemDto dto = new EventItemDto(eventItem.Id, eventItem.Name, eventItem.ClientName, eventItem.Date,
                eventItem.GuestAdults, eventItem.GuestChildren, eventItem.Duration);
            return dto;
        }
    }
}
