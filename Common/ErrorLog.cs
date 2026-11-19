using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPresupuestoEvento.Common
{
    public static class ErrorLog
    {

        //propiedades

        public static string FilePath
        {
            get { return Path.Combine(AppFolders.Data, "errores.log"); }
        }


        //metodos

        public static void Write(Exception exception)
        {
            try
            {
                Directory.CreateDirectory(AppFolders.Data);
                string text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine
                    + exception + Environment.NewLine + Environment.NewLine;
                File.AppendAllText(FilePath, text);
            }
            catch (IOException)
            {
            }
            catch (UnauthorizedAccessException)
            {
            }
        }
    }
}
