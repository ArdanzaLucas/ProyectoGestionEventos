using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Dto;
using ProyectoPresupuestoEvento.Service;


namespace ProyectoPresupuestoEvento.Controller
{
    public class MenuTagController
    {
        private MenuTagService service;

        public MenuTagController()
        {
            service = new MenuTagService();
        }

        public void addToRepository(MenuTagDto dto)
        {
            service.addToRepository(dto);
        }

        public List<MenuTagDto> getMenuTags()
        {
            return service.getMenuTags();
        }

        public void updateMenuTag(int id, MenuTagDto dto)
        {
            service.updateMenuTag(id, dto);
        }

        public void removeMenuTag(int id)
        {
            service.removeMenuTag(id);
        }

        public List<string> getMenusWithOnlyThisTag(int id)
        {
            return service.getMenusWithOnlyThisTag(id);
        }

        public int countMenusUsing(int id)
        {
            return service.countMenusUsing(id);
        }
    }
}
