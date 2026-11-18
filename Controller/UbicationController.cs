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
        private UbicationService service;

        public UbicationController()
        {
            service = new UbicationService();
        }

        public void addToRepository(UbicationDto dto)
        {
            service.addToRepository(dto);
        }
        
        public List<UbicationDto> getUbications()
        {
           return service.getUbications();
        }

        public void updateUbication(int id, UbicationDto dto)
        {
            service.updateUbication(id, dto);
        }

        public void removeUbication(int id)
        {
            service.removeUbication(id);

        }

        
    }
}
