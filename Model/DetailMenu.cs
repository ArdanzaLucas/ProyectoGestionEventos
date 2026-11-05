using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Common;

namespace ProyectoPresupuestoEvento.Model
{
    public class DetailMenu
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

            if (AdultQuantity + ChildQuantity == 0)
            {
                throw new BusinessRuleException("cada linea de catering tiene que tener al menos un plato");
            }
        }


        //propiedades

        public Menu Menu
        {
            get { return _menu; }
            set { _menu = value; }
        }

        public string MenuDescription
        {
            get { return _menuDescription; }
            set { _menuDescription = value; }
        }

        public string TagDescription
        {
            get { return _tagDescription; }
            set { _tagDescription = value; }
        }

        public int AdultQuantity
        {
            get { return _adultQuantity; }
            set
            {
                if (value < 0)
                {
                    throw new BusinessRuleException("la cantidad de adultos no puede ser negativa");
                }
                _adultQuantity = value;
            }
        }

        public int ChildQuantity
        {
            get { return _childQuantity; }
            set
            {
                if (value < 0)
                {
                    throw new BusinessRuleException("la cantidad de niños no puede ser negativa");
                }
                _childQuantity = value;
            }
        }

        public decimal UnitPriceAdult
        {
            get { return _unitPriceAdult; }
            set { _unitPriceAdult = value; }
        }

        public decimal UnitPriceChild
        {
            get { return _unitPriceChild; }
            set { _unitPriceChild = value; }
        }


        public decimal Subtotal
        {
            get { return _unitPriceAdult * _adultQuantity + _unitPriceChild * _childQuantity; }
        }


    }
}
