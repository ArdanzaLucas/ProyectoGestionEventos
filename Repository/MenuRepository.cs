using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Model;

namespace ProyectoPresupuestoEvento.Repository
{
    internal class MenuRepository
    {
        //atributos

        private List<Menu> menus;
        private MenuRepository instance;
        private int idCounter;

        //constructor

        private MenuRepository()
        {
            menus = new List<Menu>();
        }

        //singleton

        public MenuRepository getInstance()
        {
            if(instance == null)
            {
                instance = new MenuRepository();
            }
            return instance;
        }


        //metodos

        public void addToRepository(Menu menuModel)
        {
            idCounter++;
            menuModel.Id = idCounter;
            menus.Add(menuModel);
        }

        public List<Menu> getMenus()
        {
            foreach(Menu menu in menus)
            {
                return null;
            }
            return null;

        }
        
        public Menu getMenuById(int id)
        {
            return null;
        }

        public void updateMenu(int id, Menu menuModel)
        {

        }

    }
}
