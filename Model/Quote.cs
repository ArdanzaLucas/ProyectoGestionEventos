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
            _state = EstadoPresupuesto.Pendiente;
        }


        //propiedades

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int EventItemId
        {
            get { return _eventItemId; }
            set { _eventItemId = value; }
        }

        public string EventName
        {
            get { return _eventName; }
            set { _eventName = value; }
        }

        public string EventClientName
        {
            get { return _eventClientName; }
            set { _eventClientName = value; }
        }

        public DateTime EventDate
        {
            get { return _eventDate; }
            set { _eventDate = value; }
        }

        public int EventGuestAdults
        {
            get { return _eventGuestAdults; }
            set { _eventGuestAdults = value; }
        }

        public int EventGuestChilds
        {
            get { return _eventGuestChilds; }
            set { _eventGuestChilds = value; }
        }

        public int EventDuration
        {
            get { return _eventDuration; }
            set { _eventDuration = value; }
        }

        public int TotalGuests
        {
            get { return _eventGuestAdults + _eventGuestChilds; }
        }

        public Ubication Ubication
        {
            get { return _ubication; }
            set { _ubication = value; }
        }

        public string UbicationName
        {
            get { return _ubicationName; }
            set { _ubicationName = value; }
        }

        public decimal UbicationPrice
        {
            get { return _ubicationPrice; }
            set { _ubicationPrice = value; }
        }

        public List<DetailMenu> MenusList
        {
            get { return _menusList; }
            set { _menusList = value; }
        }

        public List<DetailOptionItem> OptionItemList
        {
            get { return _optionItemList; }
            set { _optionItemList = value; }
        }

        public EstadoPresupuesto State
        {
            get { return _state; }
        }

        public decimal TotalUbication
        {
            get { return _totalUbication; }
            set { _totalUbication = value; }
        }

        public decimal TotalMenus
        {
            get { return _totalMenus; }
            set { _totalMenus = value; }
        }

        public decimal TotalOptionItems
        {
            get { return _totalOptionItems; }
            set { _totalOptionItems = value; }
        }

        public decimal Total
        {
            get { return _total; }
            set { _total = value; }
        }


        //metodos

        public void calculateTotals()
        {
            if (_state != EstadoPresupuesto.Pendiente)
            {
                return;
            }

            _totalUbication = _ubicationPrice * _eventDuration;

            _totalMenus = 0;
            foreach (DetailMenu detailMenu in _menusList)
            {
                _totalMenus = _totalMenus + detailMenu.Subtotal;
            }

            _totalOptionItems = 0;
            foreach (DetailOptionItem detailOptionItem in _optionItemList)
            {
                _totalOptionItems = _totalOptionItems + detailOptionItem.UnitPrice;
            }

            _total = _totalUbication + _totalMenus + _totalOptionItems;
        }

        public void accept()
        {
            if (_state != EstadoPresupuesto.Pendiente)
            {
                throw new BusinessRuleException("solo se puede aceptar un presupuesto pendiente");
            }
            _state = EstadoPresupuesto.Aceptado;
        }

        public void cancel()
        {
            if (_state != EstadoPresupuesto.Pendiente)
            {
                throw new BusinessRuleException("solo se puede cancelar un presupuesto pendiente");
            }
            _state = EstadoPresupuesto.Cancelado;
        }

        public bool isEditable()
        {
            return _state == EstadoPresupuesto.Pendiente;
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
