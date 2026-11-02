using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPresupuestoEvento.Model
{
    public class OptionItem
    {
        private int _id;
        private string _name;
        private decimal _price;
        private bool _isActive = true;


        //constructor
        
        public OptionItem(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public OptionItem(string name, decimal price)
        {
            Name = name;
            Price = price;
        }


        //propiedades

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        // solo lectura: para desactivarla se usa deactivate()
        public bool IsActive
        {
            get { return _isActive; }
        }


        //metodos

        // baja logica: el servicio no se borra, queda inactivo
        public void deactivate()
        {
            _isActive = false;
        }


    }
}
