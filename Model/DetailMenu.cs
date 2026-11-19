using ProyectoPresupuestoEvento.Common;
using ProyectoPresupuestoEvento.Interface;

namespace ProyectoPresupuestoEvento.Model
{
    public class DetailMenu : IQuoteItem
    {
        private Menu _menu;
        private string _menuDescription;
        private string _tagDescription;
        private int _adultQuantity;
        private int _childQuantity;
        private decimal _unitPriceAdult;
        private decimal _unitPriceChild;


        //constructor

        public DetailMenu(Menu menu, string tagDescription, int adultQuantity, int childQuantity)
        {
            Menu = menu;
            MenuDescription = menu.Description;
            TagDescription = tagDescription;
            AdultQuantity = adultQuantity;
            ChildQuantity = childQuantity;
            UnitPriceAdult = menu.PriceAdult;
            UnitPriceChild = menu.PriceChild;
        }

        public DetailMenu(Menu menu, string menuDescription, string tagDescription, int adultQuantity, int childQuantity,
            decimal unitPriceAdult, decimal unitPriceChild)
        {
            Menu = menu;
            MenuDescription = menuDescription;
            TagDescription = tagDescription;
            AdultQuantity = adultQuantity;
            ChildQuantity = childQuantity;
            UnitPriceAdult = unitPriceAdult;
            UnitPriceChild = unitPriceChild;
        }


        //propiedades

        public Menu Menu
        {
            get { return _menu; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "el menu es obligatorio");
                }
                _menu = value;
            }
        }

        public string MenuDescription
        {
            get { return _menuDescription; }
            private set { _menuDescription = value; }
        }

        public string TagDescription
        {
            get { return _tagDescription; }
            private set { _tagDescription = value; }
        }

        public int AdultQuantity
        {
            get { return _adultQuantity; }
            private set { _adultQuantity = Validator.RequireQuantity(value, "la cantidad de adultos"); }
        }

        public int ChildQuantity
        {
            get { return _childQuantity; }
            private set { _childQuantity = Validator.RequireQuantity(value, "la cantidad de niños"); }
        }

        public decimal UnitPriceAdult
        {
            get { return _unitPriceAdult; }
            private set { _unitPriceAdult = value; }
        }

        public decimal UnitPriceChild
        {
            get { return _unitPriceChild; }
            private set { _unitPriceChild = value; }
        }

        public string Description
        {
            get { return _menuDescription + " (" + _tagDescription + ")"; }
        }

        public decimal Subtotal
        {
            get { return _unitPriceAdult * _adultQuantity + _unitPriceChild * _childQuantity; }
        }
    }
}
