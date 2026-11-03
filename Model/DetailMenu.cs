using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPresupuestoEvento.Model
{
    // una linea de catering del presupuesto: un menu en una de sus variantes (etiqueta)
    public class DetailMenu
    {
        private Menu _menu;
        private string _tagDescription;
        private int _adultQuantity;
        private int _childQuantity;
        private decimal _unitPriceAdult;
        private decimal _unitPriceChild;


        //constructor

        // copia los precios actuales del menu
        public DetailMenu(Menu menu, string tagDescription, int adultQuantity, int childQuantity)
        {
            Menu = menu;
            TagDescription = tagDescription;
            AdultQuantity = adultQuantity;
            ChildQuantity = childQuantity;
            UnitPriceAdult = menu.PriceAdult;
            UnitPriceChild = menu.PriceChild;
        }


        //propiedades

        public Menu Menu
        {
            get { return _menu; }
            set { _menu = value; }
        }

        // copia del texto de la etiqueta (no depende de que la etiqueta siga existiendo)
        public string TagDescription
        {
            get { return _tagDescription; }
            set { _tagDescription = value; }
        }

        public int AdultQuantity
        {
            get { return _adultQuantity; }
            set { _adultQuantity = value; }
        }

        public int ChildQuantity
        {
            get { return _childQuantity; }
            set { _childQuantity = value; }
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


        //metodos

        // vuelve a copiar los precios actuales del menu
        public void refreshPrices()
        {
            _unitPriceAdult = _menu.PriceAdult;
            _unitPriceChild = _menu.PriceChild;
        }

        public decimal calculateSubtotal()
        {
            return _unitPriceAdult * _adultQuantity + _unitPriceChild * _childQuantity;
        }


    }
}
