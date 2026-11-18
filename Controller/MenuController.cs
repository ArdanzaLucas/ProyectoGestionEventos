using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Dto;
using ProyectoPresupuestoEvento.Service;


namespace ProyectoPresupuestoEvento.Controller
{
    public class MenuController
    {
        private MenuService service;

        public MenuController()
        {
            service = new MenuService();
        }

        public void addToRepository(MenuDto dto)
        {
            service.addToRepository(dto);
        }

        public List<MenuDto> getMenus()
        {
            return service.getMenus();
        }

        public void updateMenu(int id, MenuDto dto)
        {
            service.updateMenu(id, dto);
        }

        public void removeMenu(int id)
        {
            service.removeMenu(id);
        }
    }
}
