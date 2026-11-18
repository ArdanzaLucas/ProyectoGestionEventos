using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Dto;
using ProyectoPresupuestoEvento.Service;


namespace ProyectoPresupuestoEvento.Controller
{
    public class EventItemController
    {
        private EventItemService service;

        public EventItemController()
        {
            service = new EventItemService();
        }

        public void addToRepository(EventItemDto dto)
        {
            service.addToRepository(dto);
        }

        public List<EventItemDto> getEventItems()
        {
            return service.getEventItems();
        }

        public void updateEventItem(int id, EventItemDto dto)
        {
            service.updateEventItem(id, dto);
        }

        public void removeEventItem(int id)
        {
            service.removeEventItem(id);
        }

        public int countQuotes(int id)
        {
            return service.countQuotes(id);
        }
    }
}
