using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Dto;
using ProyectoPresupuestoEvento.Service;


namespace ProyectoPresupuestoEvento.Controller
{
    public class OptionItemController
    {

        public OptionItemController()
        {

        }

        public void addToRepository(OptionItemDto dto)
        {
            OptionItemService service = new OptionItemService();
            service.addToRepository(dto);
        }
        
        public List<OptionItemDto> getOptionItems()
        {
            OptionItemService service = new OptionItemService();
           return service.getOptionItems();
        }

        public void updateOptionItem(int id, OptionItemDto dto)
        {
            OptionItemService service = new OptionItemService();
            service.updateOptionItem(id, dto);
        }

        public void removeOptionItem(int id)
        {
            OptionItemService service = new OptionItemService();
            service.removeOptionItem(id);

        }

        
    }
}
