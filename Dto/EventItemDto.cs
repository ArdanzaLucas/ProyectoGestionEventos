using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPresupuestoEvento.Dto
{
    public class EventItemDto
    {
        private int _id;
        private string _name;
        private string _clientName;
        private DateTime _date;
        private int _guestAdults;
        private int _guestChilds;
        private int _duration;


        //constructor

        public EventItemDto(int id, string name, string clientName, DateTime date, int guestAdults, int guestChilds, int duration)
        {
            Id = id;
            Name = name;
            ClientName = clientName;
            Date = date;
            GuestAdults = guestAdults;
            GuestChilds = guestChilds;
            Duration = duration;
        }

        public EventItemDto(string name, string clientName, DateTime date, int guestAdults, int guestChilds, int duration)
        {
            Name = name;
            ClientName = clientName;
            Date = date;
            GuestAdults = guestAdults;
            GuestChilds = guestChilds;
            Duration = duration;
        }


        //propiedades

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string ClientName
        {
            get { return _clientName; }
            set { _clientName = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public int GuestAdults
        {
            get { return _guestAdults; }
            set { _guestAdults = value; }
        }

        public int GuestChilds
        {
            get { return _guestChilds; }
            set { _guestChilds = value; }
        }

        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        // solo lectura: el texto que se muestra en los combos, ej. "Cumpleaños - Juan Perez"
        public string DisplayName
        {
            get
            {
                // "Todos" (el primer item del filtro) no tiene cliente
                if (_clientName == null || _clientName == "")
                {
                    return _name;
                }
                return _name + " - " + _clientName;
            }
        }


    }
}
