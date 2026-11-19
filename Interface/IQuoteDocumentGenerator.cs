using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Model;

namespace ProyectoPresupuestoEvento.Interface
{
    internal interface IQuoteDocumentGenerator
    {
        public void Generate(Quote quote, string path);
    }
}
