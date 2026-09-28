using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoPresupuestoEvento.View
{
    public static class VisualHelper
    {



        public static void setMaterialTheme(MaterialForm form)
        {
            // 2. Inicializas el gestor de temas de MaterialSkin
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;


            // 3. Configuras el esquema de colores (puedes cambiarlos a tu gusto)
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT; // O THEMES.DARK
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800,
                Primary.BlueGrey900,
                Primary.BlueGrey500,
                Accent.LightBlue200,
                TextShade.WHITE
             );
        }

        public static void EnlazarIconosSidebar(MaterialTabControl tabControl, ImageList listaImagenes, string[] nombresIconos)
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
    }
}