namespace ProyectoPresupuestoEvento.Dto
{
    public class EventItemDto
    {
        private int _id;
        private string _name;
        private string _clientName;
        private DateTime _date;
        private int _guestAdults;
        private int _guestChildren;
        private int _duration;


        //constructor

        public EventItemDto(int id, string name, string clientName, DateTime date, int guestAdults, int guestChildren, int duration)
        {
            Id = id;
            Name = name;
            ClientName = clientName;
            Date = date;
            GuestAdults = guestAdults;
            GuestChildren = guestChildren;
            Duration = duration;
        }

        public EventItemDto(string name, string clientName, DateTime date, int guestAdults, int guestChildren, int duration)
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

        public int GuestChildren
        {
            get { return _guestChildren; }
            set { _guestChildren = value; }
        }

        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        public string DisplayName
        {
            get
            {
                if (_clientName == null || _clientName == "")
                {
                    return _name;
                }
                return _name + " - " + _clientName;
            }
        }


    }
}
