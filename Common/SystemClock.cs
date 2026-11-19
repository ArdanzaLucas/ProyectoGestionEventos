using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Interface;

namespace ProyectoPresupuestoEvento.Common
{
    internal class SystemClock : IClock
    {

        //propiedades

        public DateTime Today
        {
            get { return DateTime.Today; }
        }
    }
}
