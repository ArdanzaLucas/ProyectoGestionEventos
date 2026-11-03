using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPresupuestoEvento.Dto
{
    public class DetailOptionItemDto
    {
        private int _optionItemId;
        private string _optionItemName;
        private decimal _unitPrice;


        //constructor

        // lo que carga la View; el resto lo completa el Service
        public DetailOptionItemDto(int optionItemId)
        {
            OptionItemId = optionItemId;
        }


        //propiedades

        public int OptionItemId
        {
            get { return _optionItemId; }
            set { _optionItemId = value; }
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
