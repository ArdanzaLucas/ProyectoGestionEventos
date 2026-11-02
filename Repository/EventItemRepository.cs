using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Model;
using ProyectoPresupuestoEvento.Interface;

namespace ProyectoPresupuestoEvento.Repository
{
    public class EventItemRepository : Irepository<EventItem>
    {

        private List<EventItem> eventItems;
        private static EventItemRepository instance;
        private int idCounter = 0;

        private EventItemRepository()
        {
            eventItems = new List<EventItem>();
        }


        public static EventItemRepository getInstance()
        {
            if (instance == null)
            {
                instance = new EventItemRepository();
            }
            return instance;
        }

        public void addToRepository(EventItem eventItem)
        {
            idCounter++;
            eventItem.Id = idCounter;
            eventItems.Add(eventItem);
        }

        public List<EventItem> getAll()
        {
            return eventItems;
        }

        public EventItem getById(int id)
        {
            foreach (EventItem eventItem in eventItems)
            {
                if (eventItem.Id == id)
                {
                    return eventItem;
                }
            }
            return null;
        }

        // copia los datos del evento; sus presupuestos no se tocan
        public void update(int id, EventItem eventItem)
        {
            EventItem existente = getById(id);
            if (existente == null)
            {
                return;
            }
            existente.Name = eventItem.Name;
            existente.ClientName = eventItem.ClientName;
            existente.Date = eventItem.Date;
            existente.GuestAdults = eventItem.GuestAdults;
            existente.GuestChilds = eventItem.GuestChilds;
            existente.Duration = eventItem.Duration;
        }

        // borra el evento, y con el sus presupuestos
        public void removeById(int id)
        {
            EventItem eventItemToRemove = getById(id);
            if (eventItemToRemove == null)
            {
                return;
            }
            eventItems.Remove(eventItemToRemove);

        }

    }
}
