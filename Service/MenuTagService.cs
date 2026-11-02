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
    internal class MenuTagService
    {

        public MenuTagService()
        {

        }

        public void addToRepository(MenuTagDto dto)
        {
            MenuTagRepository.getInstance().addToRepository(toModel(dto));
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
            MenuTagRepository.getInstance().update(id, toModel(dto));
        }

        // las etiquetas se borran de verdad (no hay baja logica).
        // antes se sacan de todos los menus que la tienen.
        // la View tiene que revisar antes getMenusWithOnlyThisTag.
        public void removeMenuTag(int id)
        {
            List<Menu> menus = MenuRepository.getInstance().getAll();
            foreach (Menu menu in menus)
            {
                menu.removeTag(id);
            }

            MenuTagRepository.getInstance().removeById(id);
        }

        // devuelve los nombres de los menus activos que tienen solo esta etiqueta.
        // si la lista no esta vacia, no se puede borrar la etiqueta.
        public List<string> getMenusWithOnlyThisTag(int id)
        {
            List<Menu> menus = MenuRepository.getInstance().getAll();
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

        // cuenta cuantos menus activos tienen esta etiqueta
        public int countMenusUsing(int id)
        {
            List<Menu> menus = MenuRepository.getInstance().getAll();
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

        // devuelve true si ya hay otra etiqueta con esa descripcion.
        // ToLower hace que "Vegana" y "vegana" cuenten como iguales.
        // idEditando es la etiqueta que se esta editando, para no compararla consigo misma.
        public bool existsDescription(string description, int idEditando)
        {
            List<MenuTag> menuTags = MenuTagRepository.getInstance().getAll();

            foreach (MenuTag menuTag in menuTags)
            {
                if (menuTag.Id != idEditando && menuTag.Description.ToLower() == description.ToLower())
                {
                    return true;
                }
            }

            return false;
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
