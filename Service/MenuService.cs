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
    // logica de los menus y sus etiquetas
    internal class MenuService
    {
        // se guardan como la interfaz: el service no sabe que los datos estan en SQLite
        private IRepository<Menu> repository;
        private IRepository<MenuTag> menuTagRepository;

        // el controller usa este: le pasa los repositorios reales al otro constructor
        public MenuService()
            : this(MenuRepository.getInstance(), MenuTagRepository.getInstance())
        {
        }

        // recibe los repositorios desde afuera (inyeccion de dependencias)
        public MenuService(IRepository<Menu> repository, IRepository<MenuTag> menuTagRepository)
        {
            this.repository = repository;
            this.menuTagRepository = menuTagRepository;
        }

        public void addToRepository(MenuDto dto)
        {
            Menu menu = toModel(dto);
            validateHasTags(menu);
            validateUniqueDescription(menu.Description, 0);
            repository.addToRepository(menu);
        }

        // devuelve solo los menus activos
        public List<MenuDto> getMenus()
        {
            List<Menu> menus = repository.getAll();
            List<MenuDto> dtos = new List<MenuDto>();

            foreach (Menu menu in menus)
            {
                MenuDto dto = toDto(menu);
                dtos.Add(dto);
            }

            return dtos;
        }

        public void updateMenu(int id, MenuDto dto)
        {
            Menu menu = toModel(dto);
            validateHasTags(menu);
            validateUniqueDescription(menu.Description, id);
            repository.update(id, menu);
        }

        private void validateHasTags(Menu menu)
        {
            if (menu.TagList.Count == 0)
            {
                throw new BusinessRuleException("seleccione al menos una etiqueta");
            }
        }

        // compara solo con los menus activos y sin distinguir mayusculas
        private void validateUniqueDescription(string description, int idEditando)
        {
            foreach (Menu menu in repository.getAll())
            {
                if (menu.Id != idEditando && menu.Description.ToLower() == description.ToLower())
                {
                    throw new BusinessRuleException("ya existe un menu con ese nombre");
                }
            }
        }

        // baja logica: el menu queda guardado pero inactivo
        public void removeMenu(int id)
        {
            Menu menu = repository.getById(id);
            menu.deactivate();
            repository.update(id, menu);
        }

        // busca cada etiqueta real por su id
        public Menu toModel(MenuDto dto)
        {
            List<MenuTag> tags = new List<MenuTag>();
            foreach (MenuTagDto tagDto in dto.TagList)
            {
                MenuTag tag = menuTagRepository.getById(tagDto.Id);
                tags.Add(tag);
            }

            Menu model = new Menu(dto.Description, dto.PriceAdult, dto.PriceChild, tags);
            return model;
        }

        public MenuDto toDto(Menu menu)
        {
            List<MenuTagDto> tagDtos = new List<MenuTagDto>();
            foreach (MenuTag tag in menu.TagList)
            {
                MenuTagDto tagDto = new MenuTagDto(tag.Id, tag.Description);
                tagDtos.Add(tagDto);
            }

            MenuDto dto = new MenuDto(menu.Id, menu.Description, menu.PriceAdult, menu.PriceChild, tagDtos);
            return dto;
        }
    }
}
