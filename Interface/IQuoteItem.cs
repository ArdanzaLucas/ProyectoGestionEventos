using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPresupuestoEvento.Interface
{
    public interface IQuoteItem
    {
        public string Description { get; }

        public decimal Subtotal { get; }
    }
}
