using System;
using System.Collections.Generic;
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

        public MenuTag(string description)
        {
            Description = description;
        }

        public MenuTag(int id, string description)
        {
            Id = id;
            Description = description;
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
            private set { _description = Validator.RequireText(value, "ingrese una descripcion para la etiqueta"); }
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
    }
}
