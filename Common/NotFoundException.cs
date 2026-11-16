using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPresupuestoEvento.Common
{
    public class NotFoundException : BusinessRuleException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
