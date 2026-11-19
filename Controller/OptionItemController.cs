using ProyectoPresupuestoEvento.Dto;
using ProyectoPresupuestoEvento.Service;


namespace ProyectoPresupuestoEvento.Controller
{
    public class OptionItemController
    {
        private OptionItemService service;

        public OptionItemController()
        {
            service = new OptionItemService();
        }

        public void AddToRepository(OptionItemDto dto)
        {
            service.AddToRepository(dto);
        }

        public List<OptionItemDto> GetOptionItems()
        {
           return service.GetOptionItems();
        }

        public void UpdateOptionItem(int id, OptionItemDto dto)
        {
            service.UpdateOptionItem(id, dto);
        }

        public void RemoveOptionItem(int id)
        {
            service.RemoveOptionItem(id);

        }


    }
}
