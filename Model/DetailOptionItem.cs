using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPresupuestoEvento.Model
{
    public class DetailOptionItem
    {
        private OptionItem _optionItem;
        private string _optionItemName;
        private decimal _unitPrice;


        //constructor

        public DetailOptionItem(OptionItem optionItem)
        {
            OptionItem = optionItem;
            OptionItemName = optionItem.Name;
            UnitPrice = optionItem.Price;
        }


        //propiedades

        public OptionItem OptionItem
        {
            get { return _optionItem; }
            set { _optionItem = value; }
        }

        public string OptionItemName
        {
            get { return _optionItemName; }
            set { _optionItemName = value; }
        }

        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }


    }
}
