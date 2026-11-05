using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Controller;
using ProyectoPresupuestoEvento.Dto;

namespace ProyectoPresupuestoEvento.Mock
{
    public class MockData
    {
        public static void load()
        {
            loadUbications();
            loadOptionItems();
            loadMenuTags();
            loadMenus();
            loadEventItems();
        }

        private static void loadUbications()
        {
            UbicationController controller = new UbicationController();
            controller.addToRepository(new UbicationDto("Salon Los Robles", 50000));
            controller.addToRepository(new UbicationDto("Quinta Las Acacias", 80000));
            controller.addToRepository(new UbicationDto("Terraza Centro", 35000));
        }

        private static void loadOptionItems()
        {
            OptionItemController controller = new OptionItemController();
            controller.addToRepository(new OptionItemDto("DJ", 200000));
            controller.addToRepository(new OptionItemDto("Fotografo", 150000));
            controller.addToRepository(new OptionItemDto("Decoracion", 120000));
            controller.addToRepository(new OptionItemDto("Animacion infantil", 90000));
        }

        private static void loadMenuTags()
        {
            MenuTagController controller = new MenuTagController();
            controller.addToRepository(new MenuTagDto("Estandar"));
            controller.addToRepository(new MenuTagDto("Vegana"));
            controller.addToRepository(new MenuTagDto("Sin TACC"));
            controller.addToRepository(new MenuTagDto("Vegetariana"));
        }

        private static void loadMenus()
        {
            MenuController controller = new MenuController();
            controller.addToRepository(new MenuDto("Milanesa con papas", 15000, 8000, getTags("Estandar", "Vegana", "Sin TACC")));
            controller.addToRepository(new MenuDto("Pollo al horno", 14000, 7500, getTags("Estandar", "Sin TACC")));
            controller.addToRepository(new MenuDto("Pastas caseras", 12000, 6000, getTags("Estandar", "Vegetariana", "Vegana")));
            controller.addToRepository(new MenuDto("Asado completo", 22000, 11000, getTags("Estandar")));
            controller.addToRepository(new MenuDto("Mesa dulce", 6000, 4000, getTags("Estandar", "Sin TACC")));
        }

        private static void loadEventItems()
        {
            EventItemController controller = new EventItemController();
            controller.addToRepository(new EventItemDto("Cumpleaños de Ana", "Ana Gomez", DateTime.Today.AddDays(30).AddHours(21), 40, 15, 5));
            controller.addToRepository(new EventItemDto("Casamiento Perez", "Juan Perez", DateTime.Today.AddDays(90).AddHours(20), 120, 20, 6));
            controller.addToRepository(new EventItemDto("Aniversario empresa", "Tecno SA", DateTime.Today.AddDays(45).AddHours(19), 60, 0, 4));
        }

        private static List<MenuTagDto> getTags(params string[] nombres)
        {
            List<MenuTagDto> elegidas = new List<MenuTagDto>();

            foreach (MenuTagDto etiqueta in new MenuTagController().getMenuTags())
            {
                if (nombres.Contains(etiqueta.Description))
                {
                    elegidas.Add(etiqueta);
                }
            }

            return elegidas;
        }
    }
}
