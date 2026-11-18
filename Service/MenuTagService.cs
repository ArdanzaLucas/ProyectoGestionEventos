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
    // logica de las etiquetas que se asignan a los menus
    internal class MenuTagService
    {
        // se guardan como la interfaz: el service no sabe que los datos estan en SQLite
        private IRepository<MenuTag> repository;
        private IRepository<Menu> menuRepository;

        // el controller usa este: le pasa los repositorios reales al otro constructor
        public MenuTagService()
            : this(MenuTagRepository.getInstance(), MenuRepository.getInstance())
        {
        }

        // recibe los repositorios desde afuera (inyeccion de dependencias)
        public MenuTagService(IRepository<MenuTag> repository, IRepository<Menu> menuRepository)
        {
            this.repository = repository;
            this.menuRepository = menuRepository;
        }

        public void addToRepository(MenuTagDto dto)
        {
            MenuTag model = toModel(dto);
            validateUniqueDescription(model.Description, 0);
            repository.addToRepository(model);
        }

        public List<MenuTagDto> getMenuTags()
        {
            List<MenuTag> menuTags = repository.getAll();
            List<MenuTagDto> dtos = new List<MenuTagDto>();

            foreach (MenuTag menuTag in menuTags)
            {
                MenuTagDto dto = toDto(menuTag);
                dtos.Add(dto);
            }

            return dtos;
        }

        public void updateMenuTag(int id, MenuTagDto dto)
        {
            MenuTag model = toModel(dto);
            validateUniqueDescription(model.Description, id);
            repository.update(id, model);
        }

        // borrado fisico: no se puede si es la unica etiqueta de algun menu activo
        public void removeMenuTag(int id)
        {
            List<string> menusConSoloEsta = getMenusWithOnlyThisTag(id);
            if (menusConSoloEsta.Count > 0)
            {
                throw new BusinessRuleException("no se puede eliminar: es la unica etiqueta de estos menus: "
                    + string.Join(", ", menusConSoloEsta) + ". primero asigneles otra etiqueta");
            }

            repository.removeById(id);
        }

        // menus activos que se quedarian sin etiquetas si se borra esta
        public List<string> getMenusWithOnlyThisTag(int id)
        {
            List<Menu> menus = menuRepository.getAll();
            List<string> nombres = new List<string>();

            foreach (Menu menu in menus)
            {
                if (menu.TagList.Count == 1 && menu.hasTag(id))
                {
                    nombres.Add(menu.Description);
                }
            }

            return nombres;
        }

        // cuantos menus activos la usan, para el mensaje de confirmacion
        public int countMenusUsing(int id)
        {
            List<Menu> menus = menuRepository.getAll();
            int cantidad = 0;

            foreach (Menu menu in menus)
            {
                if (menu.hasTag(id))
                {
                    cantidad++;
                }
            }

            return cantidad;
        }

        private void validateUniqueDescription(string description, int idEditando)
        {
            List<MenuTag> menuTags = repository.getAll();

            foreach (MenuTag menuTag in menuTags)
            {
                if (menuTag.Id != idEditando && menuTag.Description.ToLower() == description.ToLower())
                {
                    throw new BusinessRuleException("ya existe una etiqueta con ese nombre");
                }
            }
        }

        public MenuTag toModel(MenuTagDto dto)
        {
            MenuTag model = new MenuTag(dto.Description);
            return model;
        }

        public MenuTagDto toDto(MenuTag menuTag)
        {
            MenuTagDto dto = new MenuTagDto(menuTag.Id, menuTag.Description);
            return dto;
        }
    }
}
