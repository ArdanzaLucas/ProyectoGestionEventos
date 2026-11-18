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
        private IRepository<EventItem> repository;
        private IRepository<Quote> quoteRepository;

        // el controller usa este: le pasa los repositorios reales al otro constructor
        public EventItemService()
            : this(EventItemRepository.getInstance(), QuoteRepository.getInstance())
        {
        }

        // recibe los repositorios desde afuera (inyeccion de dependencias)
        public EventItemService(IRepository<EventItem> repository, IRepository<Quote> quoteRepository)
        {
            this.repository = repository;
            this.quoteRepository = quoteRepository;
        }

        // crea un evento: la fecha no puede ser anterior a hoy
        public void addToRepository(EventItemDto dto)
        {
            if (dto.Date.Date < DateTime.Today)
            {
                throw new BusinessRuleException("la fecha del evento no puede ser anterior a hoy");
            }

            EventItem eventItem = toModel(dto);
            validateHasGuests(eventItem);
            validateNotRepeated(eventItem, 0);
            repository.addToRepository(eventItem);
        }

        public List<EventItemDto> getEventItems()
        {
            List<EventItem> eventItems = repository.getAll();
            List<EventItemDto> dtos = new List<EventItemDto>();

            foreach (EventItem eventItem in eventItems)
            {
                EventItemDto dto = toDto(eventItem);
                dtos.Add(dto);
            }

            return dtos;
        }

        public void updateEventItem(int id, EventItemDto dto)
        {
            EventItem eventItem = toModel(dto);
            validateHasGuests(eventItem);
            validateNotRepeated(eventItem, id);
            validateScheduleChange(id, eventItem);
            repository.update(id, eventItem);
        }

        // no deja cambiar fecha, hora ni duracion si el evento tiene un presupuesto aceptado
        private void validateScheduleChange(int id, EventItem eventItem)
        {
            EventItem original = repository.getById(id);
            // compara hasta el minuto, porque el formulario no muestra los segundos
            bool cambioFecha = original.Date.ToString("yyyy-MM-dd HH:mm") != eventItem.Date.ToString("yyyy-MM-dd HH:mm");
            bool cambioDuracion = original.Duration != eventItem.Duration;

            if (cambioFecha || cambioDuracion)
            {
                foreach (Quote quote in getQuotes(id))
                {
                    if (quote.State == EstadoPresupuesto.Aceptado)
                    {
                        throw new BusinessRuleException("no se puede cambiar la fecha, la hora ni la duracion de un evento con un presupuesto aceptado");
                    }
                }
            }
        }

        // va aca y no en un set, porque al cargar los adultos los niños todavia valen 0
        private void validateHasGuests(EventItem eventItem)
        {
            if (eventItem.TotalGuests == 0)
            {
                throw new BusinessRuleException("el evento tiene que tener al menos un invitado");
            }
        }

        // no puede haber dos eventos con el mismo nombre, cliente y dia
        private void validateNotRepeated(EventItem eventItem, int idEditando)
        {
            foreach (EventItem otro in repository.getAll())
            {
                if (otro.Id != idEditando
                    && otro.Name.ToLower() == eventItem.Name.ToLower()
                    && otro.ClientName.ToLower() == eventItem.ClientName.ToLower()
                    && otro.Date.Date == eventItem.Date.Date)
                {
                    throw new BusinessRuleException("ya existe un evento con ese nombre, cliente y fecha");
                }
            }
        }

        // borra primero los presupuestos del evento y despues el evento
        public void removeEventItem(int id)
        {
            foreach (Quote quote in getQuotes(id))
            {
                quoteRepository.removeById(quote.Id);
            }

            repository.removeById(id);
        }

        public int countQuotes(int id)
        {
            return getQuotes(id).Count;
        }

        // presupuestos de un evento
        private List<Quote> getQuotes(int eventItemId)
        {
            List<Quote> quotes = new List<Quote>();
            foreach (Quote quote in quoteRepository.getAll())
            {
                if (quote.EventItemId == eventItemId)
                {
                    quotes.Add(quote);
                }
            }
            return quotes;
        }

        public EventItem toModel(EventItemDto dto)
        {
            EventItem model = new EventItem(dto.Name, dto.ClientName, dto.Date, dto.GuestAdults, dto.GuestChilds, dto.Duration);
            return model;
        }

        public EventItemDto toDto(EventItem eventItem)
        {
            EventItemDto dto = new EventItemDto(eventItem.Id, eventItem.Name, eventItem.ClientName, eventItem.Date,
                eventItem.GuestAdults, eventItem.GuestChilds, eventItem.Duration);
            return dto;
        }
    }
}
