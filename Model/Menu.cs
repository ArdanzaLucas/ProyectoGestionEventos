using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            set { _description = value; }
        }

        public decimal PriceAdult
        {
            get { return _priceAdult; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("no puede ser menor a 0 el valor");
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
                    throw new ArgumentException("no puede ser menor a 0 el valor");
                }
                _priceChild = value;
            }
        }

        public List<MenuTag> TagList
        {
            get { return _tagList; }
            set { _tagList = value; }
        }

        // solo lectura: para desactivarlo se usa deactivate()
        public bool IsActive
        {
            get { return _isActive; }
        }


        //metodos

        // baja logica: el menu no se borra, queda inactivo
        public void deactivate()
        {
            _isActive = false;
        }

        // devuelve true si el menu tiene la etiqueta con ese id
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

        // saca la etiqueta con ese id de la lista del menu
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
