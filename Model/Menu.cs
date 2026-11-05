using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Menu(int id, string description, decimal priceAdult, decimal priceChild, List<MenuTag> tagList)
        {
            Id = id;
            Description = description;
            PriceAdult = priceAdult;
            PriceChild = priceChild;
            TagList = tagList;
        }

        public Menu(string description, decimal priceAdult, decimal priceChild, List<MenuTag> tagList)
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
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new BusinessRuleException("ingrese una descripcion para el menu");
                }
                _description = value.Trim();
            }
        }

        public decimal PriceAdult
        {
            get { return _priceAdult; }
            set
            {
                if (value < 0)
                {
                    throw new BusinessRuleException("el precio por adulto no puede ser negativo");
                }
                _priceAdult = value;
            }
        }

        public decimal PriceChild
        {
            get { return _priceChild; }
            set
            {
                if (value < 0)
                {
                    throw new BusinessRuleException("el precio por niño no puede ser negativo");
                }
                _priceChild = value;
            }
        }

        public List<MenuTag> TagList
        {
            get { return _tagList; }
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new BusinessRuleException("seleccione al menos una etiqueta");
                }
                _tagList = value;
            }
        }

        public bool IsActive
        {
            get { return _isActive; }
        }


        //metodos

        public void deactivate()
        {
            _isActive = false;
        }

        public bool hasTag(int tagId)
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

        public void removeTag(int tagId)
        {
            MenuTag tagToRemove = null;
            foreach (MenuTag tag in _tagList)
            {
                if (tag.Id == tagId)
                {
                    tagToRemove = tag;
                }
            }

            if (tagToRemove != null)
            {
                _tagList.Remove(tagToRemove);
            }
        }


    }
}
