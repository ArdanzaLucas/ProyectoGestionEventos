using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPresupuestoEvento.Dto
{
    public class MenuDto
    {
        private int _id;
        private string _description;
        private decimal _priceAdult;
        private decimal _priceChild;
        private List<MenuTagDto> _tagList;


        //constructor

        public MenuDto(int id, string description, decimal priceAdult, decimal priceChild, List<MenuTagDto> tagList)
        {
            Id = id;
            Description = description;
            PriceAdult = priceAdult;
            PriceChild = priceChild;
            TagList = tagList;
        }

        public MenuDto(string description, decimal priceAdult, decimal priceChild, List<MenuTagDto> tagList)
        {
            Description = description;
            PriceAdult = priceAdult;
            PriceChild = priceChild;
            TagList = tagList;
        }


        //propiedades

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public decimal PriceAdult
        {
            get { return _priceAdult; }
            set { _priceAdult = value; }
        }

        public decimal PriceChild
        {
            get { return _priceChild; }
            set { _priceChild = value; }
        }

        public List<MenuTagDto> TagList
        {
            get { return _tagList; }
            set { _tagList = value; }
        }


    }
}
