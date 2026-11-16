using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Model;
using ProyectoPresupuestoEvento.Dto;
using ProyectoPresupuestoEvento.Repository;
using ProyectoPresupuestoEvento.Interface;
using ProyectoPresupuestoEvento.Common;

namespace ProyectoPresupuestoEvento.Service
{
    // logica de las ubicaciones
    internal class UbicationService
    {
        // se guarda como la interfaz: el service no sabe que los datos estan en SQLite
        private IRepository<Ubication> repository;

        public UbicationService()
        {
            repository = UbicationRepository.getInstance();
        }

        public void addToRepository(UbicationDto dto)
        {
            Ubication ubication = toModel(dto);
            validateUniqueName(ubication.Name, 0);
            repository.addToRepository(ubication);
        }
        
        // devuelve solo los activos
        public List<UbicationDto> getUbications()
        {
            List<Ubication> ubications = repository.getAll();
            List<UbicationDto> dtos = new List<UbicationDto>();

            foreach (Ubication ubication in ubications)
            {
                UbicationDto dto = toDto(ubication);
                dtos.Add(dto);
            }

            return dtos;
        }

        public void updateUbication(int id, UbicationDto dto)
        {
            Ubication ubication = toModel(dto);
            validateUniqueName(ubication.Name, id);
            repository.update(id, ubication);
        }

        // compara solo con los activos y sin distinguir mayusculas
        private void validateUniqueName(string name, int idEditando)
        {
            foreach (Ubication ubication in repository.getAll())
            {
                if (ubication.Id != idEditando && ubication.Name.ToLower() == name.ToLower())
                {
                    throw new BusinessRuleException("ya existe una ubicacion con ese nombre");
                }
            }
        }

        public Ubication getModelById(int id)
        {
            return repository.getById(id);
        }

        public Ubication toModel(UbicationDto dto)
        {
            Ubication model = new Ubication(dto.Name, dto.Price);
            return model;
        }

        public UbicationDto toDto(Ubication ubication)
        {
            UbicationDto dto = new UbicationDto(ubication.Id, ubication.Name, ubication.Price);
            return dto;
        }


        // baja logica: queda guardado pero inactivo
        public void removeUbication(int id)
        {
            Ubication ubication = repository.getById(id);
            ubication.deactivate();
            repository.update(id, ubication);
        }
    }
}
