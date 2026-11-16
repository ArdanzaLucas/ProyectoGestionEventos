﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPresupuestoEvento.Common
{
    public static class Validator
    {

        //metodos

        public static string requireText(string value, string mensaje)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new BusinessRuleException(mensaje);
            }

            string texto = value.Trim();
            if (texto.Length > 50)
            {
                throw new BusinessRuleException("el texto no puede tener mas de 50 caracteres");
            }
            return texto;
        }

        public static decimal requirePrice(decimal value, string nombre)
        {
            if (value < 0)
            {
                throw new BusinessRuleException(nombre + " no puede ser negativo");
            }
            if (value > 1000000000)
            {
                throw new BusinessRuleException(nombre + " no puede ser mayor a 1000000000");
            }
            if (decimal.Round(value, 2) != value)
            {
                throw new BusinessRuleException(nombre + " no puede tener mas de 2 decimales");
            }
            return value;
        }

        public static int requireQuantity(int value, string nombre)
        {
            if (value < 0)
            {
                throw new BusinessRuleException(nombre + " no puede ser negativa");
            }
            if (value > 10000)
            {
                throw new BusinessRuleException(nombre + " no puede ser mayor a 10000");
            }
            return value;
        }

    }
}
