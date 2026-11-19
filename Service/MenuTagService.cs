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
            : this(MenuTagRepository.GetInstance(), MenuRepository.GetInstance())
        {
        }

        // recibe los repositorios desde afuera (inyeccion de dependencias)
        public MenuTagService(IRepository<MenuTag> repository, IRepository<Menu> menuRepository)
        {
            this.repository = repository;
            this.menuRepository = menuRepository;
        }

        public void AddToRepository(MenuTagDto dto)
        {
            MenuTag model = ToModel(dto);
            ValidateUniqueDescription(model.Description, 0);
            repository.AddToRepository(model);
        }

        public List<MenuTagDto> GetMenuTags()
        {
            List<MenuTag> menuTags = repository.GetAll();
            List<MenuTagDto> dtos = new List<MenuTagDto>();

            foreach (MenuTag menuTag in menuTags)
            {
                MenuTagDto dto = ToDto(menuTag);
                dtos.Add(dto);
            }

            return dtos;
        }

        public void UpdateMenuTag(int id, MenuTagDto dto)
        {
            MenuTag model = ToModel(dto);
            ValidateUniqueDescription(model.Description, id);
            repository.Update(id, model);
        }

        // borrado fisico: no se puede si es la unica etiqueta de algun menu activo
        public void RemoveMenuTag(int id)
        {
            List<string> menusWithOnlyThisTag = GetMenusWithOnlyThisTag(id);
            if (menusWithOnlyThisTag.Count > 0)
            {
                throw new BusinessRuleException("no se puede eliminar: es la unica etiqueta de estos menus: "
                    + string.Join(", ", menusWithOnlyThisTag) + ". primero asigneles otra etiqueta");
            }

            repository.RemoveById(id);
        }

        // menus activos que se quedarian sin etiquetas si se borra esta
        public List<string> GetMenusWithOnlyThisTag(int id)
        {
            List<Menu> menus = menuRepository.GetAll();
            List<string> names = new List<string>();

            foreach (Menu menu in menus)
            {
                if (menu.TagList.Count == 1 && menu.HasTag(id))
                {
                    names.Add(menu.Description);
                }
            }

            return names;
        }

        // cuantos menus activos la usan, para el mensaje de confirmacion
        public int CountMenusUsing(int id)
        {
            List<Menu> menus = menuRepository.GetAll();
            int count = 0;

            foreach (Menu menu in menus)
            {
                if (menu.HasTag(id))
                {
                    count++;
                }
            }

            return count;
        }

        private void ValidateUniqueDescription(string description, int editingId)
        {
            List<MenuTag> menuTags = repository.GetAll();

            foreach (MenuTag menuTag in menuTags)
            {
                if (menuTag.Id != editingId && menuTag.Description.ToLower() == description.ToLower())
                {
                    throw new BusinessRuleException("ya existe una etiqueta con ese nombre");
                }
            }
        }

        public MenuTag ToModel(MenuTagDto dto)
        {
            MenuTag model = new MenuTag(dto.Description);
            return model;
        }

        public MenuTagDto ToDto(MenuTag menuTag)
        {
            MenuTagDto dto = new MenuTagDto(menuTag.Id, menuTag.Description);
            return dto;
        }
    }
}
