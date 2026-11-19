using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoPresupuestoEvento.Controller;
using ProyectoPresupuestoEvento.Dto;
using ProyectoPresupuestoEvento.Common;

namespace ProyectoPresupuestoEvento.View
{
    public partial class FormMenuTags : Form
    {
        private MenuTagController menuTagController;

        private FormMenus formMenus;

        private int editingId = 0;


        public FormMenuTags(MenuTagController controller, FormMenus formMenus)
        {
            this.menuTagController = controller;
            this.formMenus = formMenus;
            InitializeComponent();
            VisualHelper.FitColumns(mtLvMenuTags);
            VisualHelper.CenterContent(panelMenuTagUpload);
        }


        private void FormMenuTags_Load(object sender, EventArgs e)
        {
            panelMenuTagList.Visible = true;
            panelMenuTagCU.Visible = false;

            ReloadList();
        }

        public void ResetView()
        {
            btnBack_Click(null, EventArgs.Empty);
            ReloadList();
        }

        private void ReloadList()
        {
            List<MenuTagDto> tags = menuTagController.GetMenuTags();

            mtLvMenuTags.Items.Clear();

            foreach (MenuTagDto tag in tags)
            {
                ListViewItem row = new ListViewItem();

                row.Text = tag.Description;

                row.Tag = tag;

                mtLvMenuTags.Items.Add(row);
            }

            VisualHelper.ShowEmptyMessage(mtLvMenuTags, "Todavia no hay etiquetas. Toque Crear para agregar una.");
        }



        //seccion CRUD
        private void btnMenuTagCreate_Click(object sender, EventArgs e)
        {
            editingId = 0;

            panelMenuTagList.Visible = false;
            panelMenuTagCU.Visible = true;
            panelMenuTagCU.Dock = DockStyle.Fill;
            panelMenuTagUpload.Dock = DockStyle.Fill;
        }

        private void mtLvMenuTags_DoubleClick(object sender, EventArgs e)
        {
            btnMenuTagEdit_Click(sender, e);
        }

        private void btnMenuTagEdit_Click(object sender, EventArgs e)
        {
            if (mtLvMenuTags.SelectedItems.Count == 0)
            {
                MessageHelper.ShowWarning("seleccione una etiqueta para editar");
                return;
            }

            ListViewItem selectedMenuTag = mtLvMenuTags.SelectedItems[0];
            MenuTagDto selected = (MenuTagDto)selectedMenuTag.Tag;

            editingId = selected.Id;

            mtbMenuTagDescription.Text = selected.Description;

            panelMenuTagList.Visible = false;
            panelMenuTagCU.Visible = true;
            panelMenuTagCU.Dock = DockStyle.Fill;
            panelMenuTagUpload.Dock = DockStyle.Fill;
        }

        private void btnMenuTagRemove_Click(object sender, EventArgs e)
        {
            if (mtLvMenuTags.SelectedItems.Count == 0)
            {
                MessageHelper.ShowWarning("seleccione una etiqueta para eliminar");
                return;
            }

            ListViewItem selectedMenuTag = mtLvMenuTags.SelectedItems[0];
            MenuTagDto selected = (MenuTagDto)selectedMenuTag.Tag;

            List<string> menusWithOnlyThisTag = menuTagController.GetMenusWithOnlyThisTag(selected.Id);
            if (menusWithOnlyThisTag.Count > 0)
            {
                MessageHelper.ShowWarning("no se puede eliminar: es la unica etiqueta de estos menus: "
                    + string.Join(", ", menusWithOnlyThisTag)
                    + ". primero asigneles otra etiqueta");
                return;
            }

            int menuCount = menuTagController.CountMenusUsing(selected.Id);

            if (!MessageHelper.Confirm(
                "¿Eliminar la etiqueta " + selected.Description + "? la usan " + menuCount + " menus"))
            {
                return;
            }

            try
            {
                menuTagController.RemoveMenuTag(selected.Id);
            }
            catch (BusinessRuleException ex)
            {
                MessageHelper.ShowWarning(ex.Message);
                return;
            }

            ReloadList();
        }

        private void btnBackToMenus_Click(object sender, EventArgs e)
        {
            this.Hide();
            formMenus.ReloadList();
            formMenus.Show();
        }



        //seccion Carga
        private void btnBack_Click(object sender, EventArgs e)
        {
            panelMenuTagList.Visible = true;
            panelMenuTagCU.Visible = false;
            panelMenuTagCU.Dock = DockStyle.None;
            panelMenuTagUpload.Dock = DockStyle.None;

            mtbMenuTagDescription.Text = null;

            editingId = 0;
        }

        private void btnSaveMenuTag_Click(object sender, EventArgs e)
        {
            MenuTagDto menuTagDto = new MenuTagDto(mtbMenuTagDescription.Text);

            try
            {
                if (editingId == 0)
                {
                    menuTagController.AddToRepository(menuTagDto);
                }
                else
                {
                    menuTagController.UpdateMenuTag(editingId, menuTagDto);
                }
            }
            catch (BusinessRuleException ex)
            {
                MessageHelper.ShowWarning(ex.Message);
                return;
            }

            ReloadList();

            btnBack_Click(sender, e);
        }


    }
}
