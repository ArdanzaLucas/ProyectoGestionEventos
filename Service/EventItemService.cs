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
    internal class EventItemService
    {

        public EventItemService()
        {

        }

        public void addToRepository(EventItemDto dto)
        {
            if (dto.Date.Date < DateTime.Today)
            {
                throw new BusinessRuleException("la fecha del evento no puede ser anterior a hoy");
            }

            EventItemRepository.getInstance().addToRepository(toModel(dto));
        }

        public List<EventItemDto> getEventItems()
        {
            List<EventItem> eventItems = EventItemRepository.getInstance().getAll();
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
            EventItemRepository.getInstance().update(id, toModel(dto));
        }

        public void removeEventItem(int id)
        {
            QuoteService quoteService = new QuoteService();
            quoteService.removeQuotesByEventItem(id);

            EventItemRepository.getInstance().removeById(id);
        }

        public int countQuotes(int id)
        {
            QuoteService quoteService = new QuoteService();
            return quoteService.getQuotesByEventItem(id).Count;
        }

        public EventItem getModelById(int id)
        {
            return EventItemRepository.getInstance().getById(id);
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
