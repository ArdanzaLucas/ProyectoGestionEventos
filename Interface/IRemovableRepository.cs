using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPresupuestoEvento.Interface
{
    internal interface IRemovableRepository<T> : IRepository<T> where T : class
    {
        public void RemoveById(int id);
    }
}
