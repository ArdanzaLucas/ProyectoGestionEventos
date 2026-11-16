using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoPresupuestoEvento.View
{
    public static class VisualHelper
    {



        public static void setMaterialTheme()
        {
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;


            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800,
                Primary.BlueGrey900,
                Primary.BlueGrey500,
                Accent.LightBlue200,
                TextShade.WHITE
             );
        }

        public static void linkSidebarIcons(MaterialTabControl tabControl, ImageList listaImagenes, string[] nombresIconos)
        {
            tabControl.ImageList = listaImagenes;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (i < nombresIconos.Length)
                {
                    tabControl.TabPages[i].ImageKey = nombresIconos[i];
                }
            }
        }

        public static void showEmptyMessage(ListView lista, string mensaje)
        {
            MaterialLabel etiqueta = null;
            foreach (Control control in lista.Controls)
            {
                if (control.Name == "lblListaVacia")
                {
                    etiqueta = (MaterialLabel)control;
                }
            }

            if (etiqueta == null)
            {
                etiqueta = new MaterialLabel();
                etiqueta.Name = "lblListaVacia";
                etiqueta.AutoSize = false;
                etiqueta.TextAlign = ContentAlignment.MiddleCenter;
                etiqueta.FontType = MaterialSkinManager.fontType.Subtitle1;
                etiqueta.HighEmphasis = false;
                etiqueta.Location = new Point(0, 60);
                etiqueta.Size = new Size(lista.Width, 60);
                etiqueta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                lista.Controls.Add(etiqueta);
            }

            etiqueta.Text = mensaje;
            etiqueta.Visible = lista.Items.Count == 0;
        }

        public static void centerContent(Panel panel)
        {
            panel.Resize += panelCentrado_Resize;
        }

        private static void panelCentrado_Resize(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            if (panel.Controls.Count == 0)
            {
                return;
            }

            int izquierda = int.MaxValue;
            int derecha = 0;
            foreach (Control control in panel.Controls)
            {
                if (control.Left < izquierda)
                {
                    izquierda = control.Left;
                }
                if (control.Right > derecha)
                {
                    derecha = control.Right;
                }
            }

            int anchoContenido = derecha - izquierda;
            int nuevaIzquierda = (panel.ClientSize.Width - anchoContenido) / 2;
            if (nuevaIzquierda < 10)
            {
                nuevaIzquierda = 10;
            }

            int desplazamiento = nuevaIzquierda - izquierda;
            foreach (Control control in panel.Controls)
            {
                control.Left = control.Left + desplazamiento;
            }
        }

        public static void fitColumns(ListView lista)
        {
            foreach (ColumnHeader columna in lista.Columns)
            {
                columna.Tag = columna.Width;
            }
            lista.Resize += listaAjustada_Resize;
        }

        private static void listaAjustada_Resize(object sender, EventArgs e)
        {
            ListView lista = (ListView)sender;
            int anchoDisponible = lista.ClientSize.Width;
            if (anchoDisponible < 100 || lista.Columns.Count == 0)
            {
                return;
            }

            int anchoOriginal = 0;
            foreach (ColumnHeader columna in lista.Columns)
            {
                anchoOriginal = anchoOriginal + (int)columna.Tag;
            }
            if (anchoDisponible < anchoOriginal)
            {
                anchoDisponible = anchoOriginal;
            }

            int anchoUsado = 0;
            for (int i = 0; i < lista.Columns.Count - 1; i++)
            {
                ColumnHeader columna = lista.Columns[i];
                columna.Width = (int)columna.Tag * anchoDisponible / anchoOriginal;
                anchoUsado = anchoUsado + columna.Width;
            }
            lista.Columns[lista.Columns.Count - 1].Width = anchoDisponible - anchoUsado;
        }
    }
}
