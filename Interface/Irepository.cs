using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Repository;

namespace ProyectoPresupuestoEvento.Interface
{
    internal interface Irepository<T> where T : class
    {
        public void addToRepository(T obj);

        public List<T> getAll();

        public T getById(int id);

        public void removeById(int id);

        public void update( int id, T obj);



    }
}
