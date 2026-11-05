using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Common;

namespace ProyectoPresupuestoEvento.Model
{
    public class MenuTag
    {

        private int _id;
        private string _description;


        //constructor

        public MenuTag(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public MenuTag(string description)
        {
            Description = description;
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
                    throw new BusinessRuleException("ingrese una descripcion para la etiqueta");
                }
                _description = value.Trim();
            }
        }

    }
}
