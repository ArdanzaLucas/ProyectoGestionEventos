using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPresupuestoEvento.Dto
{
    public class MenuDto
    {
        //Atributos
        private int? id;
        private string description;
        private decimal price;

        //constructor
        public MenuDto(int id, string description, decimal price)
        {
           this.id = id;
           this.description = description;
           this.price = price;
        }

        public MenuDto(string description, decimal price)
        {
            this.description = description;
            this.price = price;
        }

    }
}
