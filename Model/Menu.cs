using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPresupuestoEvento.Model
{
    internal class Menu
    {

        //Atributos
        private int? _id;
        private string _description;
        private decimal _priceAdult;
        private decimal _priceChild;
        private List <MenuTag> _tagList;

        //constructor
        public Menu(int id, string description, decimal priceAdult, decimal priceChild,List<MenuTag> tagList)
        {
            Id = id;
            Description = description;
            PriceAdult = priceAdult;
            PriceChild = priceChild;
            TagList = tagList;

        }
        public Menu(int id, string description,decimal price)
        {
            Id = id;
            Description = description;
           // Price = price;
        }

        public Menu(string description, decimal price)
        {
            Description = description;
            //Price = price;
        }


        //propiedades

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                ArgumentNullException.ThrowIfNull(value);
                _description = value;
            }
        }

        public decimal PriceAdult
        {
            get
            {
                return _priceAdult;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("no puede ser menor a 0 el valor");
                }
                else
                {
                    _priceAdult = value;
                }
            }
        }

        public decimal PriceChild
        {
            get
            {
                return _priceChild;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("no puede ser menor a 0 el valor");
                }
                else
                {
                    _priceChild = value;
                }
            }
        }

        public int? Id
        {
            get
            {
                return _id;
            }
            set
            {
                if(_id is not null)
                {
                    throw new ArgumentException("ya existe un menu con este id");
                }
                else
                {
                    _id = value;
                }
            }
        }

        public List<MenuTag> TagList
        {
            get {return _tagList; }
            set { value= _tagList; }
        } 
                

    }
}
