using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Repository;

namespace ProyectoPresupuestoEvento.Interface
{
    internal interface IRepository<T> where T : class
    {
        public void AddToRepository(T obj);

        public List<T> GetAll();

        public T GetById(int id);

        public void Update(int id, T obj);
    }
}
