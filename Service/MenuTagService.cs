using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Model;
using ProyectoPresupuestoEvento.Dto;
using ProyectoPresupuestoEvento.Repository;
using ProyectoPresupuestoEvento.Common;

namespace ProyectoPresupuestoEvento.Service
{
    internal class MenuTagService
    {

        public MenuTagService()
        {

        }

        public void addToRepository(MenuTagDto dto)
        {
            MenuTag model = toModel(dto);
            validateUniqueDescription(model.Description, 0);
            MenuTagRepository.getInstance().addToRepository(model);
        }

        public List<MenuTagDto> getMenuTags()
        {
            List<MenuTag> menuTags = MenuTagRepository.getInstance().getAll();
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
            MenuTagRepository.getInstance().update(id, model);
        }

        public void removeMenuTag(int id)
        {
            MenuService menuService = new MenuService();
            menuService.removeTagFromMenus(id);

            MenuTagRepository.getInstance().removeById(id);
        }

        public List<string> getMenusWithOnlyThisTag(int id)
        {
            MenuService menuService = new MenuService();
            List<Menu> menus = menuService.getAllModels();
            List<string> nombres = new List<string>();

            foreach (Menu menu in menus)
            {
                if (menu.IsActive && menu.TagList.Count == 1 && menu.hasTag(id))
                {
                    nombres.Add(menu.Description);
                }
            }

            return nombres;
        }

        public int countMenusUsing(int id)
        {
            MenuService menuService = new MenuService();
            List<Menu> menus = menuService.getAllModels();
            int cantidad = 0;

            foreach (Menu menu in menus)
            {
                if (menu.IsActive && menu.hasTag(id))
                {
                    cantidad++;
                }
            }

            return cantidad;
        }

        private void validateUniqueDescription(string description, int idEditando)
        {
            List<MenuTag> menuTags = MenuTagRepository.getInstance().getAll();

            foreach (MenuTag menuTag in menuTags)
            {
                if (menuTag.Id != idEditando && menuTag.Description.ToLower() == description.ToLower())
                {
                    throw new BusinessRuleException("ya existe una etiqueta con ese nombre");
                }
            }
        }

        public MenuTag getModelById(int id)
        {
            return MenuTagRepository.getInstance().getById(id);
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
