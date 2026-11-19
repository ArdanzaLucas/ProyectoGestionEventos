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

        public void AddToRepository(EventItemDto dto)
        {
            service.AddToRepository(dto);
        }

        public List<EventItemDto> GetEventItems()
        {
            return service.GetEventItems();
        }

        public void UpdateEventItem(int id, EventItemDto dto)
        {
            service.UpdateEventItem(id, dto);
        }

        public void RemoveEventItem(int id)
        {
            service.RemoveEventItem(id);
        }

        public int CountQuotes(int id)
        {
            return service.CountQuotes(id);
        }
    }
}
