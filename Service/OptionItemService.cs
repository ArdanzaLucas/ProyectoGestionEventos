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
    // logica de los servicios adicionales
    internal class OptionItemService
    {
        // se guarda como la interfaz: el service no sabe que los datos estan en SQLite
        private IRepository<OptionItem> repository;

        // el controller usa este: le pasa el repositorio real al otro constructor
        public OptionItemService()
            : this(OptionItemRepository.getInstance())
        {
        }

        // recibe el repositorio desde afuera (inyeccion de dependencias)
        public OptionItemService(IRepository<OptionItem> repository)
        {
            this.repository = repository;
        }

        public void addToRepository(OptionItemDto dto)
        {
            OptionItem optionItem = toModel(dto);
            validateUniqueName(optionItem.Name, 0);
            repository.addToRepository(optionItem);
        }
        
        // devuelve solo los activos
        public List<OptionItemDto> getOptionItems()
        {
            List<OptionItem> optionItems = repository.getAll();
            List<OptionItemDto> dtos = new List<OptionItemDto>();

            foreach (OptionItem optionItem in optionItems)
            {
                OptionItemDto dto = toDto(optionItem);
                dtos.Add(dto);
            }

            return dtos;
        }

        public void updateOptionItem(int id, OptionItemDto dto)
        {
            OptionItem optionItem = toModel(dto);
            validateUniqueName(optionItem.Name, id);
            repository.update(id, optionItem);
        }

        // compara solo con los activos y sin distinguir mayusculas
        private void validateUniqueName(string name, int idEditando)
        {
            foreach (OptionItem optionItem in repository.getAll())
            {
                if (optionItem.Id != idEditando && optionItem.Name.ToLower() == name.ToLower())
                {
                    throw new BusinessRuleException("ya existe un servicio con ese nombre");
                }
            }
        }

        // baja logica: queda guardado pero inactivo
        public void removeOptionItem(int id)
        {
            OptionItem optionItem = repository.getById(id);
            optionItem.deactivate();
            repository.update(id, optionItem);
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
