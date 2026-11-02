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
    internal class EventItemService
    {

        public EventItemService()
        {

        }

        public void addToRepository(EventItemDto dto)
        {
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

        // el evento se borra de verdad, junto con sus presupuestos
        public void removeEventItem(int id)
        {
            EventItemRepository.getInstance().removeById(id);
        }

        // cuantos presupuestos tiene el evento (se usa para avisar antes de borrar)
        public int countQuotes(int id)
        {
            EventItem eventItem = EventItemRepository.getInstance().getById(id);
            if (eventItem == null)
            {
                return 0;
            }
            return eventItem.getQuotes().Count;
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
