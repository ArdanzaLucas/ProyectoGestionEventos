using ProyectoPresupuestoEvento.Interface;

namespace ProyectoPresupuestoEvento.Common
{
    public class SystemClock : IClock
    {

        //propiedades

        public DateTime Today
        {
            get { return DateTime.Today; }
        }
    }
}
