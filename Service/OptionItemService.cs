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
    internal class OptionItemService
    {

        public OptionItemService()
        {

        }

        public void addToRepository(OptionItemDto dto)
        {
            OptionItemRepository.getInstance().addToRepository(toModel(dto));
        }
        
        public List<OptionItemDto> getOptionItems()
        {
            List<OptionItem> optionItems = OptionItemRepository.getInstance().getAll();
            List<OptionItemDto> dtos = new List<OptionItemDto>();

            // solo se devuelven los servicios activos
            foreach (OptionItem optionItem in optionItems)
            {
                if (optionItem.IsActive)
                {
                    OptionItemDto dto = toDto(optionItem);
                    dtos.Add(dto);
                }
            }

            return dtos;
        }

        public void updateOptionItem(int id, OptionItemDto dto)
        {
            OptionItemRepository.getInstance().update(id, toModel(dto));
        }

        // baja logica: no se borra del repositorio, se marca como inactivo
        public void removeOptionItem(int id)
        {
            OptionItem optionItem = OptionItemRepository.getInstance().getById(id);
            if (optionItem == null)
            {
                return;
            }

            optionItem.deactivate();
            OptionItemRepository.getInstance().update(id, optionItem);
        }
        
        public OptionItem toModel(OptionItemDto dto)
        {
            OptionItem model = new OptionItem(dto.Name, dto.Price);
            return model;
        }

        public OptionItemDto toDto(OptionItem optionItem)
        {
            OptionItemDto dto = new OptionItemDto(optionItem.Id, optionItem.Name, optionItem.Price);
            return dto;
        }
    }
}
