using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Common;

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

        public DetailOptionItem(OptionItem optionItem, string optionItemName, decimal unitPrice)
        {
            OptionItem = optionItem;
            OptionItemName = optionItemName;
            UnitPrice = unitPrice;
        }


        //propiedades

        public OptionItem OptionItem
        {
            get { return _optionItem; }
            private set
            {
                if (value == null)
                {
                    throw new BusinessRuleException("el servicio es obligatorio");
                }
                _optionItem = value;
            }
        }

        public string OptionItemName
        {
            get { return _optionItemName; }
            private set { _optionItemName = value; }
        }

        public decimal UnitPrice
        {
            get { return _unitPrice; }
            private set { _unitPrice = value; }
        }
    }
}
