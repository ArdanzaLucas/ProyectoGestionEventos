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

        public void AddToRepository(MenuDto dto)
        {
            service.AddToRepository(dto);
        }

        public List<MenuDto> GetMenus()
        {
            return service.GetMenus();
        }

        public void UpdateMenu(int id, MenuDto dto)
        {
            service.UpdateMenu(id, dto);
        }

        public void RemoveMenu(int id)
        {
            service.RemoveMenu(id);
        }
    }
}
