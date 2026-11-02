using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Model;
using ProyectoPresupuestoEvento.Dto;
using ProyectoPresupuestoEvento.Interface;

namespace ProyectoPresupuestoEvento.Repository
{
    public class OptionItemRepository : Irepository<OptionItem>
    {

        private List<OptionItem> optionItems;
        private static OptionItemRepository instance;
        private int idCounter = 0;

        private OptionItemRepository()
        {
            optionItems = new List<OptionItem>();
        }


        public static OptionItemRepository getInstance()
        {
            if (instance == null)
            {
                instance = new OptionItemRepository();
            }
            return instance;
        }

        public void addToRepository(OptionItem optionItem)
        {
            idCounter++;
            optionItem.Id = idCounter;
            optionItems.Add(optionItem);
        }

        public List<OptionItem> getAll()
        {
            return optionItems;
        }

        public OptionItem getById(int id)
        {
            foreach (OptionItem optionItem in optionItems)
            {
                if (optionItem.Id == id)
                {
                    return optionItem;
                }
            }
            return null;
        }

        public void update(int id, OptionItem optionItem)
        {
            OptionItem existente = getById(id);
            if (existente == null)
            {
                return;
            }
            existente.Name = optionItem.Name;
            existente.Price = optionItem.Price;
        }

        public void removeById(int id)
        {
            OptionItem optionItemToRemove = getById(id);
            if (optionItemToRemove == null)
            {
                return;
            }
            optionItems.Remove(optionItemToRemove);
            
        }

    }
}
