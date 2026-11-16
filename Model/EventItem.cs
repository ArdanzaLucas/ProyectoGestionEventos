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
        }

        public EventItem(string name, string clientName, DateTime date, int guestAdults, int guestChilds, int duration)
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
            private set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            private set { _name = Validator.requireText(value, "ingrese un nombre para el evento"); }
        }

        public string ClientName
        {
            get { return _clientName; }
            private set { _clientName = Validator.requireText(value, "ingrese el nombre del cliente"); }
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
                int cantidad = Validator.requireQuantity(value, "la cantidad de adultos");
                if (cantidad + _guestChilds > 10000)
                {
                    throw new BusinessRuleException("el evento no puede tener mas de 10000 invitados");
                }
                _guestAdults = cantidad;
            }
        }

        public int GuestChilds
        {
            get { return _guestChilds; }
            private set
            {
                int cantidad = Validator.requireQuantity(value, "la cantidad de niños");
                if (_guestAdults + cantidad > 10000)
                {
                    throw new BusinessRuleException("el evento no puede tener mas de 10000 invitados");
                }
                _guestChilds = cantidad;
            }
        }

        public int Duration
        {
            get { return _duration; }
            private set
            {
                if (value <= 0)
                {
                    throw new BusinessRuleException("la duracion tiene que ser mayor a 0 horas");
                }
                if (value > 24)
                {
                    throw new BusinessRuleException("la duracion no puede ser mayor a 24 horas");
                }
                _duration = value;
            }
        }


        public int TotalGuests
        {
            get { return _guestAdults + _guestChilds; }
        }


        //metodos

        public void assignId(int id)
        {
            if (Id != 0)
            {
                throw new BusinessRuleException("el id ya fue asignado");
            }
            Id = id;
        }


    }
}
