using System.Windows.Forms;

namespace ProyectoPresupuestoEvento.View
{
    public static class MessageHelper
    {
        private const string TITULO = "Gestion de Eventos";

        public static void showWarning(string mensaje)
        {
            MessageBox.Show(mensaje, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void showError(string mensaje)
        {
            MessageBox.Show(mensaje, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void showInfo(string mensaje)
        {
            MessageBox.Show(mensaje, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool confirm(string mensaje)
        {
            DialogResult respuesta = MessageBox.Show(mensaje, TITULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return respuesta == DialogResult.Yes;
        }
    }
}
