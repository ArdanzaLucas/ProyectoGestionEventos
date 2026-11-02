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

        public MenuTagController()
        {

        }

        public void addToRepository(MenuTagDto dto)
        {
            MenuTagService service = new MenuTagService();
            service.addToRepository(dto);
        }

        public List<MenuTagDto> getMenuTags()
        {
            MenuTagService service = new MenuTagService();
            return service.getMenuTags();
        }

        public void updateMenuTag(int id, MenuTagDto dto)
        {
            MenuTagService service = new MenuTagService();
            service.updateMenuTag(id, dto);
        }

        public void removeMenuTag(int id)
        {
            MenuTagService service = new MenuTagService();
            service.removeMenuTag(id);
        }

        public List<string> getMenusWithOnlyThisTag(int id)
        {
            MenuTagService service = new MenuTagService();
            return service.getMenusWithOnlyThisTag(id);
        }

        public int countMenusUsing(int id)
        {
            MenuTagService service = new MenuTagService();
            return service.countMenusUsing(id);
        }

        public bool existsDescription(string description, int idEditando)
        {
            MenuTagService service = new MenuTagService();
            return service.existsDescription(description, idEditando);
        }


    }
}
