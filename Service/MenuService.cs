using ProyectoPresupuestoEvento.Model;
using ProyectoPresupuestoEvento.Dto;
using ProyectoPresupuestoEvento.Repository;
using ProyectoPresupuestoEvento.Interface;
using ProyectoPresupuestoEvento.Common;

namespace ProyectoPresupuestoEvento.Service
{
    // logica de los menus y sus etiquetas
    public class MenuService
    {
        // se guardan como la interfaz: el service no sabe que los datos estan en SQLite
        private IRepository<Menu> repository;
        private IRepository<MenuTag> menuTagRepository;

        // el controller usa este: le pasa los repositorios reales al otro constructor
        public MenuService()
            : this(MenuRepository.GetInstance(), MenuTagRepository.GetInstance())
        {
        }

        // recibe los repositorios desde afuera (inyeccion de dependencias)
        public MenuService(IRepository<Menu> repository, IRepository<MenuTag> menuTagRepository)
        {
            this.repository = repository;
            this.menuTagRepository = menuTagRepository;
        }

        public void AddToRepository(MenuDto dto)
        {
            Menu menu = ToModel(dto);
            ValidateHasTags(menu);
            ValidateUniqueDescription(menu.Description, 0);
            repository.AddToRepository(menu);
        }

        // devuelve solo los menus activos
        public List<MenuDto> GetMenus()
        {
            List<Menu> menus = repository.GetAll();
            List<MenuDto> dtos = new List<MenuDto>();

            foreach (Menu menu in menus)
            {
                MenuDto dto = ToDto(menu);
                dtos.Add(dto);
            }

            return dtos;
        }

        public void UpdateMenu(int id, MenuDto dto)
        {
            Menu menu = ToModel(dto);
            ValidateHasTags(menu);
            ValidateUniqueDescription(menu.Description, id);
            repository.Update(id, menu);
        }

        private void ValidateHasTags(Menu menu)
        {
            if (menu.TagList.Count == 0)
            {
                throw new BusinessRuleException("seleccione al menos una etiqueta");
            }
        }

        // compara solo con los menus activos y sin distinguir mayusculas
        private void ValidateUniqueDescription(string description, int editingId)
        {
            foreach (Menu menu in repository.GetAll())
            {
                if (menu.Id != editingId && menu.Description.ToLower() == description.ToLower())
                {
                    throw new BusinessRuleException("ya existe un menu con ese nombre");
                }
            }
        }

        // baja logica: el menu queda guardado pero inactivo
        public void RemoveMenu(int id)
        {
            Menu menu = repository.GetById(id);
            menu.Deactivate();
            repository.Update(id, menu);
        }

        // busca cada etiqueta real por su id
        private Menu ToModel(MenuDto dto)
        {
            List<MenuTag> tags = new List<MenuTag>();
            foreach (MenuTagDto tagDto in dto.TagList)
            {
                MenuTag tag = menuTagRepository.GetById(tagDto.Id);
                tags.Add(tag);
            }

            Menu model = new Menu(dto.Description, dto.PriceAdult, dto.PriceChild, tags);
            return model;
        }

        private MenuDto ToDto(Menu menu)
        {
            List<MenuTagDto> tagDtos = new List<MenuTagDto>();
            foreach (MenuTag tag in menu.TagList)
            {
                MenuTagDto tagDto = new MenuTagDto(tag.Id, tag.Description);
                tagDtos.Add(tagDto);
            }

            MenuDto dto = new MenuDto(menu.Id, menu.Description, menu.PriceAdult, menu.PriceChild, tagDtos);
            return dto;
        }
    }
}
