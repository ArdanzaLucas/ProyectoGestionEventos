using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPresupuestoEvento.Common
{
    public static class Validator
    {

        //metodos

        public static string RequireText(string value, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new BusinessRuleException(message);
            }

            string text = value.Trim();
            if (text.Length > Limits.MaxTextLength)
            {
                throw new BusinessRuleException("el texto no puede tener mas de " + Limits.MaxTextLength + " caracteres");
            }
            return text;
        }

        public static decimal RequirePrice(decimal value, string name)
        {
            if (value < 0)
            {
                throw new BusinessRuleException(name + " no puede ser negativo");
            }
            if (value > Limits.MaxPrice)
            {
                throw new BusinessRuleException(name + " no puede ser mayor a " + Limits.MaxPrice);
            }
            if (decimal.Round(value, 2) != value)
            {
                throw new BusinessRuleException(name + " no puede tener mas de 2 decimales");
            }
            return value;
        }

        public static int RequireQuantity(int value, string name)
        {
            if (value < 0)
            {
                throw new BusinessRuleException(name + " no puede ser negativa");
            }
            if (value > Limits.MaxQuantity)
            {
                throw new BusinessRuleException(name + " no puede ser mayor a " + Limits.MaxQuantity);
            }
            return value;
        }

    }
}
