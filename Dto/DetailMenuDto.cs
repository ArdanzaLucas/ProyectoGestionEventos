using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPresupuestoEvento.Dto
{
    public class DetailMenuDto
    {
        private int _menuId;
        private string _menuDescription;
        private string _tagDescription;
        private int _adultQuantity;
        private int _childQuantity;
        private decimal _unitPriceAdult;
        private decimal _unitPriceChild;
        private decimal _subtotal;


        //constructor

        public DetailMenuDto(int menuId, string tagDescription, int adultQuantity, int childQuantity)
        {
            MenuId = menuId;
            TagDescription = tagDescription;
            AdultQuantity = adultQuantity;
            ChildQuantity = childQuantity;
        }


        //propiedades

        public int MenuId
        {
            get { return _menuId; }
            set { _menuId = value; }
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

        public decimal Subtotal
        {
            get { return _subtotal; }
            set { _subtotal = value; }
        }


    }
}
