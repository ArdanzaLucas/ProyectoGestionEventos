using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPresupuestoEvento.Model
{
    // una linea de servicio del presupuesto
    public class DetailOptionItem
    {
        private OptionItem _optionItem;
        private decimal _unitPrice;


        //constructor

        // copia el precio actual del servicio
        public DetailOptionItem(OptionItem optionItem)
        {
            OptionItem = optionItem;
            UnitPrice = optionItem.Price;
        }


        //propiedades

        public OptionItem OptionItem
        {
            get { return _optionItem; }
            set { _optionItem = value; }
        }

        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }


        //metodos

        // vuelve a copiar el precio actual del servicio
        public void refreshPrice()
        {
            _unitPrice = _optionItem.Price;
        }


    }
}
