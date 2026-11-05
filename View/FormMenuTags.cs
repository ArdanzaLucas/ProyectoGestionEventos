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

        private int idEditando = 0;


        public FormMenuTags(MenuTagController controller, FormMenus formMenus)
        {
            this.menuTagController = controller;
            this.formMenus = formMenus;
            InitializeComponent();
        }


        private void FormMenuTags_Load(object sender, EventArgs e)
        {
            panelMenuTagList.Visible = true;
            panelMenuTagCU.Visible = false;

            reloadMtlv();
        }

        public void resetView()
        {
            btnVolverAtras_Click(null, EventArgs.Empty);
            reloadMtlv();
        }

        private void reloadMtlv()
        {
            List<MenuTagDto> etiquetas = menuTagController.getMenuTags();

            mtLvMenuTags.Items.Clear();

            foreach (MenuTagDto etiqueta in etiquetas)
            {
                ListViewItem fila = new ListViewItem();

                fila.Text = etiqueta.Id.ToString();
                fila.SubItems.Add(etiqueta.Description);

                fila.Tag = etiqueta;

                mtLvMenuTags.Items.Add(fila);
            }
        }



        //seccion CRUD
        private void btnMenuTagCreate_Click(object sender, EventArgs e)
        {
            idEditando = 0;

            panelMenuTagList.Visible = false;
            panelMenuTagCU.Visible = true;
            panelMenuTagCU.Dock = DockStyle.Fill;
            panelMenuTagUpload.Dock = DockStyle.Fill;
        }

        private void btnMenuTagEdit_Click(object sender, EventArgs e)
        {
            if (mtLvMenuTags.SelectedItems.Count == 0)
            {
                MessageHelper.showWarning("seleccione una etiqueta para editar");
                return;
            }

            ListViewItem selectedMenuTag = mtLvMenuTags.SelectedItems[0];
            MenuTagDto selected = (MenuTagDto)selectedMenuTag.Tag;

            idEditando = selected.Id;

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
                MessageHelper.showWarning("seleccione una etiqueta para eliminar");
                return;
            }

            ListViewItem selectedMenuTag = mtLvMenuTags.SelectedItems[0];
            MenuTagDto selected = (MenuTagDto)selectedMenuTag.Tag;

            List<string> menusConSoloEsta = menuTagController.getMenusWithOnlyThisTag(selected.Id);
            if (menusConSoloEsta.Count > 0)
            {
                MessageHelper.showWarning("no se puede eliminar: es la unica etiqueta de estos menus: "
                    + string.Join(", ", menusConSoloEsta)
                    + ". primero asigneles otra etiqueta");
                return;
            }

            int cantidadMenus = menuTagController.countMenusUsing(selected.Id);

            if (!MessageHelper.confirm(
                "¿Eliminar la etiqueta " + selected.Description + "? la usan " + cantidadMenus + " menus"))
            {
                return;
            }

            menuTagController.removeMenuTag(selected.Id);
            reloadMtlv();
        }

        private void btnVolverMenus_Click(object sender, EventArgs e)
        {
            this.Hide();
            formMenus.reloadMtlv();
            formMenus.Show();
        }



        //seccion Carga
        private void btnVolverAtras_Click(object sender, EventArgs e)
        {
            panelMenuTagList.Visible = true;
            panelMenuTagCU.Visible = false;
            panelMenuTagCU.Dock = DockStyle.None;
            panelMenuTagUpload.Dock = DockStyle.None;

            mtbMenuTagDescription.Text = null;

            idEditando = 0;
        }

        private void btnGuardarMenuTag_Click(object sender, EventArgs e)
        {
            MenuTagDto menuTagDto = new MenuTagDto(mtbMenuTagDescription.Text);

            try
            {
                if (idEditando == 0)
                {
                    menuTagController.addToRepository(menuTagDto);
                }
                else
                {
                    menuTagController.updateMenuTag(idEditando, menuTagDto);
                }
            }
            catch (BusinessRuleException ex)
            {
                MessageHelper.showWarning(ex.Message);
                return;
            }

            reloadMtlv();

            btnVolverAtras_Click(sender, e);
        }


    }
}
