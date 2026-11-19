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



        public static void SetMaterialTheme()
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

        public static void LinkSidebarIcons(MaterialTabControl tabControl, ImageList imageList, string[] iconNames)
        {
            tabControl.ImageList = imageList;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (i < iconNames.Length)
                {
                    tabControl.TabPages[i].ImageKey = iconNames[i];
                }
            }
        }

        public static void ShowEmptyMessage(ListView list, string message)
        {
            MaterialLabel tag = null;
            foreach (Control control in list.Controls)
            {
                if (control.Name == "lblEmptyList")
                {
                    tag = (MaterialLabel)control;
                }
            }

            if (tag == null)
            {
                tag = new MaterialLabel();
                tag.Name = "lblEmptyList";
                tag.AutoSize = false;
                tag.TextAlign = ContentAlignment.MiddleCenter;
                tag.FontType = MaterialSkinManager.fontType.Subtitle1;
                tag.HighEmphasis = false;
                tag.Location = new Point(0, 60);
                tag.Size = new Size(list.Width, 60);
                tag.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                list.Controls.Add(tag);
            }

            tag.Text = message;
            tag.Visible = list.Items.Count == 0;
        }

        public static void CenterContent(Panel panel)
        {
            panel.Resize += centeredPanel_Resize;
        }

        private static void centeredPanel_Resize(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            if (panel.Controls.Count == 0)
            {
                return;
            }

            int left = int.MaxValue;
            int right = 0;
            foreach (Control control in panel.Controls)
            {
                if (control.Left < left)
                {
                    left = control.Left;
                }
                if (control.Right > right)
                {
                    right = control.Right;
                }
            }

            int contentWidth = right - left;
            int newLeft = (panel.ClientSize.Width - contentWidth) / 2;
            if (newLeft < 10)
            {
                newLeft = 10;
            }

            int offset = newLeft - left;
            foreach (Control control in panel.Controls)
            {
                control.Left = control.Left + offset;
            }
        }

        public static void FitColumns(ListView list)
        {
            foreach (ColumnHeader column in list.Columns)
            {
                column.Tag = column.Width;
            }
            list.Resize += fittedList_Resize;
        }

        private static void fittedList_Resize(object sender, EventArgs e)
        {
            ListView list = (ListView)sender;
            int availableWidth = list.ClientSize.Width;
            if (availableWidth < 100 || list.Columns.Count == 0)
            {
                return;
            }

            int originalWidth = 0;
            foreach (ColumnHeader column in list.Columns)
            {
                originalWidth = originalWidth + (int)column.Tag;
            }
            if (availableWidth < originalWidth)
            {
                availableWidth = originalWidth;
            }

            int usedWidth = 0;
            for (int i = 0; i < list.Columns.Count - 1; i++)
            {
                ColumnHeader column = list.Columns[i];
                column.Width = (int)column.Tag * availableWidth / originalWidth;
                usedWidth = usedWidth + column.Width;
            }
            list.Columns[list.Columns.Count - 1].Width = availableWidth - usedWidth;
        }
    }
}
