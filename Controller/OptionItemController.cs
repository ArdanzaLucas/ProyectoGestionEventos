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
        private OptionItemService service;

        public OptionItemController()
        {
            service = new OptionItemService();
        }

        public void addToRepository(OptionItemDto dto)
        {
            service.addToRepository(dto);
        }
        
        public List<OptionItemDto> getOptionItems()
        {
           return service.getOptionItems();
        }

        public void updateOptionItem(int id, OptionItemDto dto)
        {
            service.updateOptionItem(id, dto);
        }

        public void removeOptionItem(int id)
        {
            service.removeOptionItem(id);

        }

        
    }
}
