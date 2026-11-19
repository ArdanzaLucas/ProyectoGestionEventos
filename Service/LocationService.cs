using ProyectoPresupuestoEvento.Model;
using ProyectoPresupuestoEvento.Dto;
using ProyectoPresupuestoEvento.Repository;
using ProyectoPresupuestoEvento.Interface;
using ProyectoPresupuestoEvento.Common;

namespace ProyectoPresupuestoEvento.Service
{
    // logica de las ubicaciones
    public class LocationService
    {
        // se guarda como la interfaz: el service no sabe que los datos estan en SQLite
        private IRepository<Location> repository;

        // el controller usa este: le pasa el repositorio real al otro constructor
        public LocationService()
            : this(LocationRepository.GetInstance())
        {
        }

        // recibe el repositorio desde afuera (inyeccion de dependencias)
        public LocationService(IRepository<Location> repository)
        {
            this.repository = repository;
        }

        public void AddToRepository(LocationDto dto)
        {
            Location location = ToModel(dto);
            ValidateUniqueName(location.Name, 0);
            repository.AddToRepository(location);
        }

        // devuelve solo los activos
        public List<LocationDto> GetLocations()
        {
            List<Location> locations = repository.GetAll();
            List<LocationDto> dtos = new List<LocationDto>();

            foreach (Location location in locations)
            {
                LocationDto dto = ToDto(location);
                dtos.Add(dto);
            }

            return dtos;
        }

        public void UpdateLocation(int id, LocationDto dto)
        {
            Location location = ToModel(dto);
            ValidateUniqueName(location.Name, id);
            repository.Update(id, location);
        }

        // compara solo con los activos y sin distinguir mayusculas
        private void ValidateUniqueName(string name, int editingId)
        {
            foreach (Location location in repository.GetAll())
            {
                if (location.Id != editingId && location.Name.ToLower() == name.ToLower())
                {
                    throw new BusinessRuleException("ya existe una ubicacion con ese nombre");
                }
            }
        }

        // baja logica: queda guardado pero inactivo
        public void RemoveLocation(int id)
        {
            Location location = repository.GetById(id);
            location.Deactivate();
            repository.Update(id, location);
        }

        private Location ToModel(LocationDto dto)
        {
            Location model = new Location(dto.Name, dto.Price);
            return model;
        }

        private LocationDto ToDto(Location location)
        {
            LocationDto dto = new LocationDto(location.Id, location.Name, location.Price);
            return dto;
        }
    }
}
