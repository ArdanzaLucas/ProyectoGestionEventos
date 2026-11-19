using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPresupuestoEvento.Common
{
    public static class AppFolders
    {

        //propiedades

        public static string Data
        {
            get { return Path.Combine(AppContext.BaseDirectory, "Data"); }
        }

        public static string TempPdf
        {
            get { return Path.Combine(Path.GetTempPath(), "PresupuestoEvento"); }
        }
    }
}
