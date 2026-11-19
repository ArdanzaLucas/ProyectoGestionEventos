using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Dto;
using ProyectoPresupuestoEvento.Service;


namespace ProyectoPresupuestoEvento.Controller
{
    public class LocationController
    {
        private LocationService service;

        public LocationController()
        {
            service = new LocationService();
        }

        public void AddToRepository(LocationDto dto)
        {
            service.AddToRepository(dto);
        }
        
        public List<LocationDto> GetLocations()
        {
           return service.GetLocations();
        }

        public void UpdateLocation(int id, LocationDto dto)
        {
            service.UpdateLocation(id, dto);
        }

        public void RemoveLocation(int id)
        {
            service.RemoveLocation(id);

        }

        
    }
}
