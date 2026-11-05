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
    internal class MenuService
    {

        public MenuService()
        {

        }

        public void addToRepository(MenuDto dto)
        {
            MenuRepository.getInstance().addToRepository(toModel(dto));
        }

        public List<MenuDto> getMenus()
        {
            List<Menu> menus = MenuRepository.getInstance().getAll();
            List<MenuDto> dtos = new List<MenuDto>();

            foreach (Menu menu in menus)
            {
                if (menu.IsActive)
                {
                    MenuDto dto = toDto(menu);
                    dtos.Add(dto);
                }
            }

            return dtos;
        }

        public void updateMenu(int id, MenuDto dto)
        {
            MenuRepository.getInstance().update(id, toModel(dto));
        }

        public void removeMenu(int id)
        {
            Menu menu = MenuRepository.getInstance().getById(id);
            if (menu == null)
            {
                return;
            }

            menu.deactivate();
            MenuRepository.getInstance().update(id, menu);
        }

        public Menu getModelById(int id)
        {
            return MenuRepository.getInstance().getById(id);
        }

        public List<Menu> getAllModels()
        {
            return MenuRepository.getInstance().getAll();
        }

        public void removeTagFromMenus(int tagId)
        {
            foreach (Menu menu in getAllModels())
            {
                menu.removeTag(tagId);
            }
        }

        public Menu toModel(MenuDto dto)
        {
            MenuTagService menuTagService = new MenuTagService();
            List<MenuTag> tags = new List<MenuTag>();
            foreach (MenuTagDto tagDto in dto.TagList)
            {
                MenuTag tag = menuTagService.getModelById(tagDto.Id);
                if (tag != null)
                {
                    tags.Add(tag);
                }
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
