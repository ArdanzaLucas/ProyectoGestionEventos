using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Model;
using ProyectoPresupuestoEvento.Dto;


namespace ProyectoPresupuestoEvento.Repository
{
    public class UbicationRepository
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

        public List<Ubication> getUbications()
        {
            return ubications;
        }

        public Ubication getUbicationById(int id)
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

        public void updateUbication()
        {

        }

        public void removeUbication(int id)
        {
            Ubication ubicationToRemove = getUbicationById(id);
            if (ubicationToRemove == null)
            {
                return;
            }
            ubications.Remove(ubicationToRemove);
            
        }

    }
}
