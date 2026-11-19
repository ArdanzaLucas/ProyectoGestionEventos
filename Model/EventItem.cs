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
        private int _guestChildren;
        private int _duration;


        //constructor

        public EventItem(int id, string name, string clientName, DateTime date, int guestAdults, int guestChildren, int duration)
        {
            Id = id;
            Name = name;
            ClientName = clientName;
            Date = date;
            GuestAdults = guestAdults;
            GuestChildren = guestChildren;
            Duration = duration;
        }

        public EventItem(string name, string clientName, DateTime date, int guestAdults, int guestChildren, int duration)
        {
            Name = name;
            ClientName = clientName;
            Date = date;
            GuestAdults = guestAdults;
            GuestChildren = guestChildren;
            Duration = duration;
        }


        //propiedades

        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            private set { _name = Validator.RequireText(value, "ingrese un nombre para el evento"); }
        }

        public string ClientName
        {
            get { return _clientName; }
            private set { _clientName = Validator.RequireText(value, "ingrese el nombre del cliente"); }
        }

        public DateTime Date
        {
            get { return _date; }
            private set { _date = value; }
        }

        public int GuestAdults
        {
            get { return _guestAdults; }
            private set
            {
                int count = Validator.RequireQuantity(value, "la cantidad de adultos");
                if (count + _guestChildren > Limits.MaxGuests)
                {
                    throw new BusinessRuleException("el evento no puede tener mas de " + Limits.MaxGuests + " invitados");
                }
                _guestAdults = count;
            }
        }

        public int GuestChildren
        {
            get { return _guestChildren; }
            private set
            {
                int count = Validator.RequireQuantity(value, "la cantidad de niños");
                if (_guestAdults + count > Limits.MaxGuests)
                {
                    throw new BusinessRuleException("el evento no puede tener mas de " + Limits.MaxGuests + " invitados");
                }
                _guestChildren = count;
            }
        }

        public int Duration
        {
            get { return _duration; }
            private set
            {
                if (value < Limits.MinDuration)
                {
                    throw new BusinessRuleException("la duracion tiene que ser de al menos " + Limits.MinDuration + " hora");
                }
                if (value > Limits.MaxDuration)
                {
                    throw new BusinessRuleException("la duracion no puede ser mayor a " + Limits.MaxDuration + " horas");
                }
                _duration = value;
            }
        }


        public int TotalGuests
        {
            get { return _guestAdults + _guestChildren; }
        }


        //metodos

        public void AssignId(int id)
        {
            if (Id != 0)
            {
                throw new BusinessRuleException("el id ya fue asignado");
            }
            Id = id;
        }


    }
}
