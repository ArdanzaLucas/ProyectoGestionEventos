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

        public EventItemController()
        {

        }

        public void addToRepository(EventItemDto dto)
        {
            EventItemService service = new EventItemService();
            service.addToRepository(dto);
        }

        public List<EventItemDto> getEventItems()
        {
            EventItemService service = new EventItemService();
            return service.getEventItems();
        }

        public void updateEventItem(int id, EventItemDto dto)
        {
            EventItemService service = new EventItemService();
            service.updateEventItem(id, dto);
        }

        public void removeEventItem(int id)
        {
            EventItemService service = new EventItemService();
            service.removeEventItem(id);
        }

        public int countQuotes(int id)
        {
            EventItemService service = new EventItemService();
            return service.countQuotes(id);
        }


    }
}
