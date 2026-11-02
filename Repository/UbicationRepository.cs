using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Model;
using ProyectoPresupuestoEvento.Dto;
using ProyectoPresupuestoEvento.Interface;

namespace ProyectoPresupuestoEvento.Repository
{
    public class UbicationRepository : Irepository<Ubication>
    {

        private List<Ubication> ubications;
        private static UbicationRepository instance;
        private int idCounter = 0;

        private UbicationRepository()
        {
            ubications = new List<Ubication>();
        }


        public static UbicationRepository getInstance()
        {
            if (instance == null)
            {
                instance = new UbicationRepository();
            }
            return instance;
        }

        public void addToRepository(Ubication ubication)
        {
            idCounter++;
            ubication.Id = idCounter;
            ubications.Add(ubication);
        }

        public List<Ubication> getAll()
        {
            return ubications;
        }

        public Ubication getById(int id)
        {
            foreach (Ubication ubication in ubications)
            {
                if (ubication.Id == id)
                {
                    return ubication;
                }
            }
            return null;
        }

        public void update(int id, Ubication ubication)
        {
            Ubication existente = getById(id);
            if (existente == null)
            {
                return;
            }
            existente.Name = ubication.Name;
            existente.Price = ubication.Price;
        }

        public void removeById(int id)
        {
            Ubication ubicationToRemove = getById(id);
            if (ubicationToRemove == null)
            {
                return;
            }
            ubications.Remove(ubicationToRemove);
            
        }

    }
}
