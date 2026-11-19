using ProyectoPresupuestoEvento.Common;

namespace ProyectoPresupuestoEvento.Model
{
    public class Location
    {
        private int _id;
        private string _name;
        private decimal _price;
        private bool _isActive = true;


        //constructor

        public Location(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public Location(int id, string name, decimal price, bool isActive)
        {
            Id = id;
            Name = name;
            Price = price;
            IsActive = isActive;
        }


        //propiedades

        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            private set { _name = Validator.RequireText(value, "ingrese un nombre para la ubicacion"); }
        }

        public decimal Price
        {
            get { return _price; }
            private set { _price = Validator.RequirePrice(value, "el precio de la ubicacion"); }
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
    }
}
