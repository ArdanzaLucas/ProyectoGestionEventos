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

        public void AddToRepository(MenuTagDto dto)
        {
            service.AddToRepository(dto);
        }

        public List<MenuTagDto> GetMenuTags()
        {
            return service.GetMenuTags();
        }

        public void UpdateMenuTag(int id, MenuTagDto dto)
        {
            service.UpdateMenuTag(id, dto);
        }

        public void RemoveMenuTag(int id)
        {
            service.RemoveMenuTag(id);
        }

        public List<string> GetMenusWithOnlyThisTag(int id)
        {
            return service.GetMenusWithOnlyThisTag(id);
        }

        public int CountMenusUsing(int id)
        {
            return service.CountMenusUsing(id);
        }
    }
}
