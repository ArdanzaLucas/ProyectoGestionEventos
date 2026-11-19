using ProyectoPresupuestoEvento.Controller;
using ProyectoPresupuestoEvento.Dto;
using ProyectoPresupuestoEvento.Repository;

namespace ProyectoPresupuestoEvento.Mock
{
    public class MockData
    {
        public static void Load()
        {
            if (!IsDatabaseEmpty())
            {
                return;
            }

            LoadLocations();
            LoadOptionItems();
            LoadMenuTags();
            LoadMenus();
            LoadEventItems();
        }

        private static bool IsDatabaseEmpty()
        {
            return LocationRepository.GetInstance().GetAll().Count == 0
                && OptionItemRepository.GetInstance().GetAll().Count == 0
                && MenuTagRepository.GetInstance().GetAll().Count == 0
                && MenuRepository.GetInstance().GetAll().Count == 0
                && EventItemRepository.GetInstance().GetAll().Count == 0;
        }

        private static void LoadLocations()
        {
            LocationController controller = new LocationController();
            controller.AddToRepository(new LocationDto("Salon Los Robles", 50000));
            controller.AddToRepository(new LocationDto("Quinta Las Acacias", 80000));
            controller.AddToRepository(new LocationDto("Terraza Centro", 35000));
        }

        private static void LoadOptionItems()
        {
            OptionItemController controller = new OptionItemController();
            controller.AddToRepository(new OptionItemDto("DJ", 200000));
            controller.AddToRepository(new OptionItemDto("Fotografo", 150000));
            controller.AddToRepository(new OptionItemDto("Decoracion", 120000));
            controller.AddToRepository(new OptionItemDto("Animacion infantil", 90000));
        }

        private static void LoadMenuTags()
        {
            MenuTagController controller = new MenuTagController();
            controller.AddToRepository(new MenuTagDto("Estandar"));
            controller.AddToRepository(new MenuTagDto("Vegana"));
            controller.AddToRepository(new MenuTagDto("Sin TACC"));
            controller.AddToRepository(new MenuTagDto("Vegetariana"));
        }

        private static void LoadMenus()
        {
            MenuController controller = new MenuController();
            controller.AddToRepository(new MenuDto("Milanesa con papas", 15000, 8000, GetTags("Estandar", "Vegana", "Sin TACC")));
            controller.AddToRepository(new MenuDto("Pollo al horno", 14000, 7500, GetTags("Estandar", "Sin TACC")));
            controller.AddToRepository(new MenuDto("Pastas caseras", 12000, 6000, GetTags("Estandar", "Vegetariana", "Vegana")));
            controller.AddToRepository(new MenuDto("Asado completo", 22000, 11000, GetTags("Estandar")));
            controller.AddToRepository(new MenuDto("Mesa dulce", 6000, 4000, GetTags("Estandar", "Sin TACC")));
        }

        private static void LoadEventItems()
        {
            EventItemController controller = new EventItemController();
            controller.AddToRepository(new EventItemDto("Cumpleaños de Ana", "Ana Gomez", DateTime.Today.AddDays(30).AddHours(21), 40, 15, 5));
            controller.AddToRepository(new EventItemDto("Casamiento Perez", "Juan Perez", DateTime.Today.AddDays(90).AddHours(20), 120, 20, 6));
            controller.AddToRepository(new EventItemDto("Aniversario empresa", "Tecno SA", DateTime.Today.AddDays(45).AddHours(19), 60, 0, 4));
        }

        private static List<MenuTagDto> GetTags(params string[] names)
        {
            List<MenuTagDto> selectedTags = new List<MenuTagDto>();

            foreach (MenuTagDto tag in new MenuTagController().GetMenuTags())
            {
                if (names.Contains(tag.Description))
                {
                    selectedTags.Add(tag);
                }
            }

            return selectedTags;
        }
    }
}
