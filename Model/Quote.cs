using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Common;
using ProyectoPresupuestoEvento.Interface;

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
        private int _eventGuestChildren;
        private int _eventDuration;
        private Location _location;
        private string _locationName;
        private decimal _locationPrice;
        private List<DetailMenu> _menusList;
        private List<DetailOptionItem> _optionItemList;
        private QuoteState _state;
        private decimal _totalLocation;
        private decimal _totalMenus;
        private decimal _totalOptionItems;
        private decimal _total;


        //constructor

        public Quote(EventItem eventItem, Location location, List<DetailMenu> menusList, List<DetailOptionItem> optionItemList)
        {
            EventItemId = eventItem.Id;
            EventName = eventItem.Name;
            EventClientName = eventItem.ClientName;
            EventDate = eventItem.Date;
            EventGuestAdults = eventItem.GuestAdults;
            EventGuestChildren = eventItem.GuestChildren;
            EventDuration = eventItem.Duration;
            Location = location;
            LocationName = location.Name;
            LocationPrice = location.Price;
            MenusList = menusList;
            OptionItemList = optionItemList;
            State = QuoteState.Pending;
        }

        public Quote(int id, QuoteState state, int eventItemId, string eventName, string eventClientName,
            DateTime eventDate, int eventGuestAdults, int eventGuestChildren, int eventDuration,
            Location location, string locationName, decimal locationPrice,
            List<DetailMenu> menusList, List<DetailOptionItem> optionItemList,
            decimal totalLocation, decimal totalMenus, decimal totalOptionItems, decimal total)
        {
            Id = id;
            State = state;
            EventItemId = eventItemId;
            EventName = eventName;
            EventClientName = eventClientName;
            EventDate = eventDate;
            EventGuestAdults = eventGuestAdults;
            EventGuestChildren = eventGuestChildren;
            EventDuration = eventDuration;
            Location = location;
            LocationName = locationName;
            LocationPrice = locationPrice;
            MenusList = menusList;
            OptionItemList = optionItemList;
            TotalLocation = totalLocation;
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

        public int EventGuestChildren
        {
            get { return _eventGuestChildren; }
            private set { _eventGuestChildren = value; }
        }

        public int EventDuration
        {
            get { return _eventDuration; }
            private set { _eventDuration = value; }
        }

        public int TotalGuests
        {
            get { return _eventGuestAdults + _eventGuestChildren; }
        }

        public Location Location
        {
            get { return _location; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "la ubicacion es obligatoria");
                }
                _location = value;
            }
        }

        public string LocationName
        {
            get { return _locationName; }
            private set { _locationName = value; }
        }

        public decimal LocationPrice
        {
            get { return _locationPrice; }
            private set { _locationPrice = value; }
        }

        public List<DetailMenu> MenusList
        {
            get { return _menusList; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "la lista de menus es obligatoria");
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
                    throw new ArgumentNullException(nameof(value), "la lista de servicios es obligatoria");
                }
                _optionItemList = value;
            }
        }

        public QuoteState State
        {
            get { return _state; }
            private set { _state = value; }
        }

        public decimal TotalLocation
        {
            get { return _totalLocation; }
            private set { _totalLocation = value; }
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

        public void AssignId(int id)
        {
            if (Id != 0)
            {
                throw new BusinessRuleException("el id ya fue asignado");
            }
            Id = id;
        }

        public void CalculateTotals()
        {
            if (_state != QuoteState.Pending)
            {
                return;
            }

            TotalLocation = LocationPrice * EventDuration;
            TotalMenus = SumSubtotals(MenusList);
            TotalOptionItems = SumSubtotals(OptionItemList);
            Total = TotalLocation + TotalMenus + TotalOptionItems;
        }

        private decimal SumSubtotals(IEnumerable<IQuoteItem> items)
        {
            decimal total = 0;
            foreach (IQuoteItem item in items)
            {
                total = total + item.Subtotal;
            }
            return total;
        }

        public void Accept()
        {
            if (_state != QuoteState.Pending)
            {
                throw new BusinessRuleException("solo se puede aceptar un presupuesto pendiente");
            }
            State = QuoteState.Accepted;
        }

        public void Cancel()
        {
            if (_state != QuoteState.Pending)
            {
                throw new BusinessRuleException("solo se puede cancelar un presupuesto pendiente");
            }
            State = QuoteState.Cancelled;
        }

        public bool IsEditable()
        {
            return _state == QuoteState.Pending;
        }

        public bool OverlapsWith(Quote other)
        {
            DateTime start = _eventDate;
            DateTime end = start.AddHours(_eventDuration);
            DateTime otherStart = other.EventDate;
            DateTime otherEnd = otherStart.AddHours(other.EventDuration);

            return start < otherEnd && otherStart < end;
        }

        public Quote Clone(EventItem eventItem)
        {
            List<DetailMenu> menus = new List<DetailMenu>();
            foreach (DetailMenu detailMenu in _menusList)
            {
                DetailMenu copy = new DetailMenu(detailMenu.Menu, detailMenu.TagDescription,
                    detailMenu.AdultQuantity, detailMenu.ChildQuantity);
                menus.Add(copy);
            }

            List<DetailOptionItem> optionItems = new List<DetailOptionItem>();
            foreach (DetailOptionItem detailOptionItem in _optionItemList)
            {
                DetailOptionItem copy = new DetailOptionItem(detailOptionItem.OptionItem);
                optionItems.Add(copy);
            }

            Quote newQuote = new Quote(eventItem, _location, menus, optionItems);
            return newQuote;
        }


    }
}
