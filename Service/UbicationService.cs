using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Model;
using ProyectoPresupuestoEvento.Dto;
using ProyectoPresupuestoEvento.Repository;

namespace ProyectoPresupuestoEvento.Service
{
    internal class UbicationService
    {

        public UbicationService()
        {

        }

        public void addToRepository(UbicationDto dto)
        {
            UbicationRepository.getInstance().addToRepository(toModel(dto));
        }
        
        public List<UbicationDto> getUbications()
        {
            List<Ubication> ubications = UbicationRepository.getInstance().getAll();
            List<UbicationDto> dtos = new List<UbicationDto>();

            // solo se devuelven las ubicaciones activas
            foreach (Ubication ubication in ubications)
            {
                if (ubication.IsActive)
                {
                    UbicationDto dto = toDto(ubication);
                    dtos.Add(dto);
                }
            }

            return dtos;
        }

        public void updateUbication(int id, UbicationDto dto)
        {
            UbicationRepository.getInstance().update(id, toModel(dto));
        }

        // baja logica: no se borra del repositorio, se marca como inactiva
        public void removeUbication(int id)
        {
            Ubication ubication = UbicationRepository.getInstance().getById(id);
            if (ubication == null)
            {
                return;
            }

            ubication.deactivate();
            UbicationRepository.getInstance().update(id, ubication);
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
    }
}
