using System.Windows.Forms;

namespace ProyectoPresupuestoEvento.View
{
    public static class MessageHelper
    {
        private const string TITLE = "Gestion de Eventos";

        public static void ShowWarning(string message)
        {
            MessageBox.Show(message, TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowError(string message)
        {
            MessageBox.Show(message, TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowInfo(string message)
        {
            MessageBox.Show(message, TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool Confirm(string message)
        {
            DialogResult answer = MessageBox.Show(message, TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return answer == DialogResult.Yes;
        }
    }
}
