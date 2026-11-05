using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Common;

namespace ProyectoPresupuestoEvento.Model
{
    public class Ubication
    {
        private int _id;
        private string _name;
        private decimal _price;
        private bool _isActive = true;


        //constructor
        
        public Ubication(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public Ubication(string name, decimal price)
        {
            Name = name;
            Price = price;
        }


        //propiedades

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new BusinessRuleException("ingrese un nombre para la ubicacion");
                }
                _name = value.Trim();
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value < 0)
                {
                    throw new BusinessRuleException("el precio de la ubicacion no puede ser negativo");
                }
                _price = value;
            }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        
        public bool IsActive
        {
            get { return _isActive; }
        }


        

        public void deactivate()
        {
            _isActive = false;
        }


    }
}
