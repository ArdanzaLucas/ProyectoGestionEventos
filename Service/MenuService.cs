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

            // solo se devuelven los menus activos
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

        // baja logica: no se borra del repositorio, se marca como inactivo
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

        public Menu toModel(MenuDto dto)
        {
            // las etiquetas se buscan en su repositorio por id,
            // asi el menu usa las mismas etiquetas que se ven en la lista de etiquetas
            List<MenuTag> tags = new List<MenuTag>();
            foreach (MenuTagDto tagDto in dto.TagList)
            {
                MenuTag tag = MenuTagRepository.getInstance().getById(tagDto.Id);
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
