using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Common;

namespace ProyectoPresupuestoEvento.Model
{
    public class Quote
    {
        private int _id;
        private int _eventItemId;
        private string _eventName;
        private string _eventClientName;
        private DateTime _eventDate;
        private int _eventGuestAdults;
        private int _eventGuestChilds;
        private int _eventDuration;
        private Ubication _ubication;
        private string _ubicationName;
        private decimal _ubicationPrice;
        private List<DetailMenu> _menusList;
        private List<DetailOptionItem> _optionItemList;
        private EstadoPresupuesto _state;
        private decimal _totalUbication;
        private decimal _totalMenus;
        private decimal _totalOptionItems;
        private decimal _total;


        //constructor

        public Quote(EventItem eventItem, Ubication ubication, List<DetailMenu> menusList, List<DetailOptionItem> optionItemList)
        {
            EventItemId = eventItem.Id;
            EventName = eventItem.Name;
            EventClientName = eventItem.ClientName;
            EventDate = eventItem.Date;
            EventGuestAdults = eventItem.GuestAdults;
            EventGuestChilds = eventItem.GuestChilds;
            EventDuration = eventItem.Duration;
            Ubication = ubication;
            UbicationName = ubication.Name;
            UbicationPrice = ubication.Price;
            MenusList = menusList;
            OptionItemList = optionItemList;
            State = EstadoPresupuesto.Pendiente;
        }

        public Quote(int id, EstadoPresupuesto state, int eventItemId, string eventName, string eventClientName,
            DateTime eventDate, int eventGuestAdults, int eventGuestChilds, int eventDuration,
            Ubication ubication, string ubicationName, decimal ubicationPrice,
            List<DetailMenu> menusList, List<DetailOptionItem> optionItemList,
            decimal totalUbication, decimal totalMenus, decimal totalOptionItems, decimal total)
        {
            Id = id;
            State = state;
            EventItemId = eventItemId;
            EventName = eventName;
            EventClientName = eventClientName;
            EventDate = eventDate;
            EventGuestAdults = eventGuestAdults;
            EventGuestChilds = eventGuestChilds;
            EventDuration = eventDuration;
            Ubication = ubication;
            UbicationName = ubicationName;
            UbicationPrice = ubicationPrice;
            MenusList = menusList;
            OptionItemList = optionItemList;
            TotalUbication = totalUbication;
            TotalMenus = totalMenus;
            TotalOptionItems = totalOptionItems;
            Total = total;
        }


        //propiedades

        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        public int EventItemId
        {
            get { return _eventItemId; }
            private set { _eventItemId = value; }
        }

        public string EventName
        {
            get { return _eventName; }
            private set { _eventName = value; }
        }

        public string EventClientName
        {
            get { return _eventClientName; }
            private set { _eventClientName = value; }
        }

        public DateTime EventDate
        {
            get { return _eventDate; }
            private set { _eventDate = value; }
        }

        public int EventGuestAdults
        {
            get { return _eventGuestAdults; }
            private set { _eventGuestAdults = value; }
        }

        public int EventGuestChilds
        {
            get { return _eventGuestChilds; }
            private set { _eventGuestChilds = value; }
        }

        public int EventDuration
        {
            get { return _eventDuration; }
            private set { _eventDuration = value; }
        }

        public int TotalGuests
        {
            get { return _eventGuestAdults + _eventGuestChilds; }
        }

        public Ubication Ubication
        {
            get { return _ubication; }
            private set
            {
                if (value == null)
                {
                    throw new BusinessRuleException("la ubicacion es obligatoria");
                }
                _ubication = value;
            }
        }

        public string UbicationName
        {
            get { return _ubicationName; }
            private set { _ubicationName = value; }
        }

        public decimal UbicationPrice
        {
            get { return _ubicationPrice; }
            private set { _ubicationPrice = value; }
        }

        public List<DetailMenu> MenusList
        {
            get { return _menusList; }
            private set
            {
                if (value == null)
                {
                    throw new BusinessRuleException("la lista de menus es obligatoria");
                }
                _menusList = value;
            }
        }

        public List<DetailOptionItem> OptionItemList
        {
            get { return _optionItemList; }
            private set
            {
                if (value == null)
                {
                    throw new BusinessRuleException("la lista de servicios es obligatoria");
                }
                _optionItemList = value;
            }
        }

        public EstadoPresupuesto State
        {
            get { return _state; }
            private set { _state = value; }
        }

        public decimal TotalUbication
        {
            get { return _totalUbication; }
            private set { _totalUbication = value; }
        }

        public decimal TotalMenus
        {
            get { return _totalMenus; }
            private set { _totalMenus = value; }
        }

        public decimal TotalOptionItems
        {
            get { return _totalOptionItems; }
            private set { _totalOptionItems = value; }
        }

        public decimal Total
        {
            get { return _total; }
            private set { _total = value; }
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

        public void calculateTotals()
        {
            if (_state != EstadoPresupuesto.Pendiente)
            {
                return;
            }

            TotalUbication = UbicationPrice * EventDuration;

            decimal totalMenus = 0;
            foreach (DetailMenu detailMenu in MenusList)
            {
                totalMenus = totalMenus + detailMenu.Subtotal;
            }
            TotalMenus = totalMenus;

            decimal totalOptionItems = 0;
            foreach (DetailOptionItem detailOptionItem in OptionItemList)
            {
                totalOptionItems = totalOptionItems + detailOptionItem.UnitPrice;
            }
            TotalOptionItems = totalOptionItems;

            Total = TotalUbication + TotalMenus + TotalOptionItems;
        }

        public void accept()
        {
            if (_state != EstadoPresupuesto.Pendiente)
            {
                throw new BusinessRuleException("solo se puede aceptar un presupuesto pendiente");
            }
            State = EstadoPresupuesto.Aceptado;
        }

        public void cancel()
        {
            if (_state != EstadoPresupuesto.Pendiente)
            {
                throw new BusinessRuleException("solo se puede cancelar un presupuesto pendiente");
            }
            State = EstadoPresupuesto.Cancelado;
        }

        public bool isEditable()
        {
            return _state == EstadoPresupuesto.Pendiente;
        }

        public bool overlapsWith(Quote otro)
        {
            DateTime inicio = _eventDate;
            DateTime fin = inicio.AddHours(_eventDuration);
            DateTime inicioOtro = otro.EventDate;
            DateTime finOtro = inicioOtro.AddHours(otro.EventDuration);

            return inicio < finOtro && inicioOtro < fin;
        }

        public Quote clone(EventItem eventItem)
        {
            List<DetailMenu> menus = new List<DetailMenu>();
            foreach (DetailMenu detailMenu in _menusList)
            {
                DetailMenu copia = new DetailMenu(detailMenu.Menu, detailMenu.TagDescription,
                    detailMenu.AdultQuantity, detailMenu.ChildQuantity);
                menus.Add(copia);
            }

            List<DetailOptionItem> optionItems = new List<DetailOptionItem>();
            foreach (DetailOptionItem detailOptionItem in _optionItemList)
            {
                DetailOptionItem copia = new DetailOptionItem(detailOptionItem.OptionItem);
                optionItems.Add(copia);
            }

            Quote nuevo = new Quote(eventItem, _ubication, menus, optionItems);
            return nuevo;
        }


    }
}
