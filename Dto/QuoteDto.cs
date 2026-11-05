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
        private int _eventGuestChilds;
        private int _eventDuration;
        private int _totalGuests;
        private int _ubicationId;
        private string _ubicationName;
        private decimal _ubicationPrice;
        private List<DetailMenuDto> _menusList;
        private List<DetailOptionItemDto> _optionItemsList;
        private EstadoPresupuesto _state;
        private decimal _totalUbication;
        private decimal _totalMenus;
        private decimal _totalOptionItems;
        private decimal _total;


        //constructor

        public QuoteDto(int eventItemId, int ubicationId, List<DetailMenuDto> menusList, List<DetailOptionItemDto> optionItemsList)
        {
            EventItemId = eventItemId;
            UbicationId = ubicationId;
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
            get { return _totalGuests; }
            set { _totalGuests = value; }
        }

        public int UbicationId
        {
            get { return _ubicationId; }
            set { _ubicationId = value; }
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

        public EstadoPresupuesto State
        {
            get { return _state; }
            set { _state = value; }
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


    }
}
