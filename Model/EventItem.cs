using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Common;

namespace ProyectoPresupuestoEvento.Model
{
    public class EventItem
    {
        private int _id;
        private string _name;
        private string _clientName;
        private DateTime _date;
        private int _guestAdults;
        private int _guestChilds;
        private int _duration;


        //constructor

        public EventItem(int id, string name, string clientName, DateTime date, int guestAdults, int guestChilds, int duration)
        {
            Id = id;
            Name = name;
            ClientName = clientName;
            Date = date;
            GuestAdults = guestAdults;
            GuestChilds = guestChilds;
            Duration = duration;
            validateGuests();
        }

        public EventItem(string name, string clientName, DateTime date, int guestAdults, int guestChilds, int duration)
        {
            Name = name;
            ClientName = clientName;
            Date = date;
            GuestAdults = guestAdults;
            GuestChilds = guestChilds;
            Duration = duration;
            validateGuests();
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
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new BusinessRuleException("ingrese un nombre para el evento");
                }
                _name = value.Trim();
            }
        }

        public string ClientName
        {
            get { return _clientName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new BusinessRuleException("ingrese el nombre del cliente");
                }
                _clientName = value.Trim();
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public int GuestAdults
        {
            get { return _guestAdults; }
            set
            {
                if (value < 0)
                {
                    throw new BusinessRuleException("la cantidad de adultos no puede ser negativa");
                }
                _guestAdults = value;
            }
        }

        public int GuestChilds
        {
            get { return _guestChilds; }
            set
            {
                if (value < 0)
                {
                    throw new BusinessRuleException("la cantidad de niños no puede ser negativa");
                }
                _guestChilds = value;
            }
        }

        public int Duration
        {
            get { return _duration; }
            set
            {
                if (value <= 0)
                {
                    throw new BusinessRuleException("la duracion tiene que ser mayor a 0 horas");
                }
                _duration = value;
            }
        }


        public int TotalGuests
        {
            get { return _guestAdults + _guestChilds; }
        }


        //metodos

        private void validateGuests()
        {
            if (TotalGuests == 0)
            {
                throw new BusinessRuleException("el evento tiene que tener al menos un invitado");
            }
        }


    }
}
