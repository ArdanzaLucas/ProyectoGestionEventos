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

        public MenuController()
        {

        }

        public void addToRepository(MenuDto dto)
        {
            MenuService service = new MenuService();
            service.addToRepository(dto);
        }

        public List<MenuDto> getMenus()
        {
            MenuService service = new MenuService();
            return service.getMenus();
        }

        public void updateMenu(int id, MenuDto dto)
        {
            MenuService service = new MenuService();
            service.updateMenu(id, dto);
        }

        public void removeMenu(int id)
        {
            MenuService service = new MenuService();
            service.removeMenu(id);
        }


    }
}
