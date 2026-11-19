using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Common;

namespace ProyectoPresupuestoEvento.Dto
{
    public class QuoteDto
    {
        private int _id;
        private int _eventItemId;
        private string _eventItemName;
        private string _eventClientName;
        private DateTime _eventDate;
        private int _eventGuestAdults;
        private int _eventGuestChildren;
        private int _eventDuration;
        private int _totalGuests;
        private int _locationId;
        private string _locationName;
        private decimal _locationPrice;
        private List<DetailMenuDto> _menusList;
        private List<DetailOptionItemDto> _optionItemsList;
        private QuoteState _state;
        private decimal _totalLocation;
        private decimal _totalMenus;
        private decimal _totalOptionItems;
        private decimal _total;


        //constructor

        public QuoteDto(int eventItemId, int locationId, List<DetailMenuDto> menusList, List<DetailOptionItemDto> optionItemsList)
        {
            EventItemId = eventItemId;
            LocationId = locationId;
            MenusList = menusList;
            OptionItemsList = optionItemsList;
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

        public string EventItemName
        {
            get { return _eventItemName; }
            set { _eventItemName = value; }
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

        public int EventGuestChildren
        {
            get { return _eventGuestChildren; }
            set { _eventGuestChildren = value; }
        }

        public int EventDuration
        {
            get { return _eventDuration; }
            set { _eventDuration = value; }
        }

        public int TotalGuests
        {
            get { return _totalGuests; }
            set { _totalGuests = value; }
        }

        public int LocationId
        {
            get { return _locationId; }
            set { _locationId = value; }
        }

        public string LocationName
        {
            get { return _locationName; }
            set { _locationName = value; }
        }

        public decimal LocationPrice
        {
            get { return _locationPrice; }
            set { _locationPrice = value; }
        }

        public List<DetailMenuDto> MenusList
        {
            get { return _menusList; }
            set { _menusList = value; }
        }

        public List<DetailOptionItemDto> OptionItemsList
        {
            get { return _optionItemsList; }
            set { _optionItemsList = value; }
        }

        public QuoteState State
        {
            get { return _state; }
            set { _state = value; }
        }

        public decimal TotalLocation
        {
            get { return _totalLocation; }
            set { _totalLocation = value; }
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


    }
}
