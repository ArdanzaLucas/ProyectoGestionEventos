using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPresupuestoEvento.Dto
{
    public class OptionItemDto
    {
        private int _id;
        private string _name;
        private decimal _price;


        //constructor

        public OptionItemDto(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public OptionItemDto(string name, decimal price)
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


    }
}

