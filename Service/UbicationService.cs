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
            List<Ubication> ubications = UbicationRepository.getInstance().getUbications();
            List<UbicationDto> dtos = new List<UbicationDto>();

            foreach (Ubication ubication in ubications)
            {
                UbicationDto dto = toDto(ubication);
                dtos.Add(dto);
            }

            return dtos;
        }

        public void updateUbication()
        {

        }

        public void removeUbication()
        {

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
