using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Dto;
using ProyectoPresupuestoEvento.Service;


namespace ProyectoPresupuestoEvento.Controller
{
    public class UbicationController
    {

        public UbicationController()
        {

        }

        public void addToRepository(UbicationDto dto)
        {
            UbicationService service = new UbicationService();
            service.addToRepository(dto);
        }
        
        public List<UbicationDto> getUbications()
        {
            UbicationService service = new UbicationService();
           return service.getUbications();
        }

        public void updateUbication()
        {

        }

        public void removeUbication(int id)
        {
            UbicationService service = new UbicationService();
            service.removeUbication(id);

        }

        
    }
}
