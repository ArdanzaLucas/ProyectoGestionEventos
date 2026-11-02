using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Model;
using ProyectoPresupuestoEvento.Interface;

namespace ProyectoPresupuestoEvento.Repository
{
    public class MenuRepository : Irepository<Menu>
    {

        private List<Menu> menus;
        private static MenuRepository instance;
        private int idCounter = 0;

        private MenuRepository()
        {
            menus = new List<Menu>();
        }


        public static MenuRepository getInstance()
        {
            if (instance == null)
            {
                instance = new MenuRepository();
            }
            return instance;
        }

        public void addToRepository(Menu menu)
        {
            idCounter++;
            menu.Id = idCounter;
            menus.Add(menu);
        }

        public List<Menu> getAll()
        {
            return menus;
        }

        public Menu getById(int id)
        {
            foreach (Menu menu in menus)
            {
                if (menu.Id == id)
                {
                    return menu;
                }
            }
            return null;
        }

        public void update(int id, Menu menu)
        {
            Menu existente = getById(id);
            if (existente == null)
            {
                return;
            }
            existente.Description = menu.Description;
            existente.PriceAdult = menu.PriceAdult;
            existente.PriceChild = menu.PriceChild;
            existente.TagList = menu.TagList;
        }

        public void removeById(int id)
        {
            Menu menuToRemove = getById(id);
            if (menuToRemove == null)
            {
                return;
            }
            menus.Remove(menuToRemove);

        }

    }
}
