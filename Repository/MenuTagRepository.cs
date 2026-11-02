using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Model;
using ProyectoPresupuestoEvento.Interface;

namespace ProyectoPresupuestoEvento.Repository
{
    public class MenuTagRepository : Irepository<MenuTag>
    {

        private List<MenuTag> menuTags;
        private static MenuTagRepository instance;
        private int idCounter = 0;

        private MenuTagRepository()
        {
            menuTags = new List<MenuTag>();
        }


        public static MenuTagRepository getInstance()
        {
            if (instance == null)
            {
                instance = new MenuTagRepository();
            }
            return instance;
        }

        public void addToRepository(MenuTag menuTag)
        {
            idCounter++;
            menuTag.Id = idCounter;
            menuTags.Add(menuTag);
        }

        public List<MenuTag> getAll()
        {
            return menuTags;
        }

        public MenuTag getById(int id)
        {
            foreach (MenuTag menuTag in menuTags)
            {
                if (menuTag.Id == id)
                {
                    return menuTag;
                }
            }
            return null;
        }

        public void update(int id, MenuTag menuTag)
        {
            MenuTag existente = getById(id);
            if (existente == null)
            {
                return;
            }
            existente.Description = menuTag.Description;
        }

        public void removeById(int id)
        {
            MenuTag menuTagToRemove = getById(id);
            if (menuTagToRemove == null)
            {
                return;
            }
            menuTags.Remove(menuTagToRemove);

        }

    }
}
