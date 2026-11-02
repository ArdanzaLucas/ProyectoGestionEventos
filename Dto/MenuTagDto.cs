using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPresupuestoEvento.Dto
{
    public class MenuTagDto
    {
        private int _id;
        private string _description;


        //constructor

        public MenuTagDto(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public MenuTagDto(string description)
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
            set { _description = value; }
        }


    }
}
