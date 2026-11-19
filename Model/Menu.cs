using ProyectoPresupuestoEvento.Common;

namespace ProyectoPresupuestoEvento.Model
{
    public class Menu
    {
        private int _id;
        private string _description;
        private decimal _priceAdult;
        private decimal _priceChild;
        private List<MenuTag> _tagList;
        private bool _isActive = true;


        //constructor

        public Menu(string description, decimal priceAdult, decimal priceChild, List<MenuTag> tagList)
        {
            Description = description;
            PriceAdult = priceAdult;
            PriceChild = priceChild;
            TagList = tagList;
        }

        public Menu(int id, string description, decimal priceAdult, decimal priceChild, List<MenuTag> tagList, bool isActive)
        {
            Id = id;
            Description = description;
            PriceAdult = priceAdult;
            PriceChild = priceChild;
            TagList = tagList;
            IsActive = isActive;
        }


        //propiedades

        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        public string Description
        {
            get { return _description; }
            private set { _description = Validator.RequireText(value, "ingrese una descripcion para el menu"); }
        }

        public decimal PriceAdult
        {
            get { return _priceAdult; }
            private set { _priceAdult = Validator.RequirePrice(value, "el precio por adulto"); }
        }

        public decimal PriceChild
        {
            get { return _priceChild; }
            private set { _priceChild = Validator.RequirePrice(value, "el precio por niño"); }
        }

        public IReadOnlyList<MenuTag> TagList
        {
            get { return _tagList.AsReadOnly(); }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "la lista de etiquetas es obligatoria");
                }
                _tagList = new List<MenuTag>(value);
            }
        }

        public bool IsActive
        {
            get { return _isActive; }
            private set { _isActive = value; }
        }


        //metodos

        public void AssignId(int id)
        {
            if (Id != 0)
            {
                throw new BusinessRuleException("el id ya fue asignado");
            }
            Id = id;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public bool HasTag(int tagId)
        {
            foreach (MenuTag tag in _tagList)
            {
                if (tag.Id == tagId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
