using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPresupuestoEvento.Model
{
    internal class MenuTag
    {

        private int _tagId;
        private string _description;


        //constructor
        public MenuTag()
        {


        }



        //propiedades

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

    }
}
