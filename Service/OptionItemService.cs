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
            : this(OptionItemRepository.GetInstance())
        {
        }

        // recibe el repositorio desde afuera (inyeccion de dependencias)
        public OptionItemService(IRepository<OptionItem> repository)
        {
            this.repository = repository;
        }

        public void AddToRepository(OptionItemDto dto)
        {
            OptionItem optionItem = ToModel(dto);
            ValidateUniqueName(optionItem.Name, 0);
            repository.AddToRepository(optionItem);
        }
        
        // devuelve solo los activos
        public List<OptionItemDto> GetOptionItems()
        {
            List<OptionItem> optionItems = repository.GetAll();
            List<OptionItemDto> dtos = new List<OptionItemDto>();

            foreach (OptionItem optionItem in optionItems)
            {
                OptionItemDto dto = ToDto(optionItem);
                dtos.Add(dto);
            }

            return dtos;
        }

        public void UpdateOptionItem(int id, OptionItemDto dto)
        {
            OptionItem optionItem = ToModel(dto);
            ValidateUniqueName(optionItem.Name, id);
            repository.Update(id, optionItem);
        }

        // compara solo con los activos y sin distinguir mayusculas
        private void ValidateUniqueName(string name, int editingId)
        {
            foreach (OptionItem optionItem in repository.GetAll())
            {
                if (optionItem.Id != editingId && optionItem.Name.ToLower() == name.ToLower())
                {
                    throw new BusinessRuleException("ya existe un servicio con ese nombre");
                }
            }
        }

        // baja logica: queda guardado pero inactivo
        public void RemoveOptionItem(int id)
        {
            OptionItem optionItem = repository.GetById(id);
            optionItem.Deactivate();
            repository.Update(id, optionItem);
        }

        public OptionItem ToModel(OptionItemDto dto)
        {
            OptionItem model = new OptionItem(dto.Name, dto.Price);
            return model;
        }

        public OptionItemDto ToDto(OptionItem optionItem)
        {
            OptionItemDto dto = new OptionItemDto(optionItem.Id, optionItem.Name, optionItem.Price);
            return dto;
        }
    }
}
