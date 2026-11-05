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
    public partial class FormMenus : Form
    {

        MenuController menuController;

        MenuTagController menuTagController;

        FormMenuTags formMenuTags;

        private int idEditando = 0;

        public FormMenus(MenuController controller, MenuTagController menuTagController)
        {
            menuController = controller;
            this.menuTagController = menuTagController;
            InitializeComponent();
        }

        public void setFormMenuTags(FormMenuTags formMenuTags)
        {
            this.formMenuTags = formMenuTags;
        }

        private void FormMenus_Load(object sender, EventArgs e)
        {
            panelMenusList.Visible = true;
            panelMenusList.Dock = DockStyle.Fill;
            panelMenuUpload.Visible = false;

            reloadMtlv();
        }

        public void resetView()
        {
            btnVolverMenu_Click(null, EventArgs.Empty);
            reloadMtlv();
        }

        public void reloadMtlv()
        {
            List<MenuDto> menus = menuController.getMenus();

            mtLvMenus.Items.Clear();

            foreach (MenuDto menu in menus)
            {
                ListViewItem fila = new ListViewItem();

                fila.Text = menu.Description;
                fila.SubItems.Add(menu.PriceAdult.ToString("C"));
                fila.SubItems.Add(menu.PriceChild.ToString("C"));

                string etiquetas = "";
                foreach (MenuTagDto tag in menu.TagList)
                {
                    if (etiquetas != "")
                    {
                        etiquetas = etiquetas + ", ";
                    }
                    etiquetas = etiquetas + tag.Description;
                }
                fila.SubItems.Add(etiquetas);
                fila.Tag = menu;

                mtLvMenus.Items.Add(fila);
            }
        }

        private void loadTags()
        {
            clbMenuTags.Items.Clear();

            clbMenuTags.DisplayMember = "Description";

            List<MenuTagDto> etiquetas = menuTagController.getMenuTags();
            foreach (MenuTagDto etiqueta in etiquetas)
            {
                clbMenuTags.Items.Add(etiqueta);
            }
        }



        //seccion CRUD
        private void btnMenuCreate_Click(object sender, EventArgs e)
        {
            idEditando = 0;
            loadTags();

            panelMenusList.Visible = false;
            panelMenusList.Dock = DockStyle.None;
            panelMenuUpload.Visible = true;
            panelMenuUpload.Dock = DockStyle.Fill;
        }

        private void btnMenuEdit_Click(object sender, EventArgs e)
        {
            if (mtLvMenus.SelectedItems.Count == 0)
            {
                MessageHelper.showWarning("seleccione un menu para editar");
                return;
            }

            ListViewItem selectedMenu = mtLvMenus.SelectedItems[0];
            MenuDto selected = (MenuDto)selectedMenu.Tag;

            idEditando = selected.Id;

            mtbMenuDescription.Text = selected.Description;
            mtbMenuPriceAdult.Text = selected.PriceAdult.ToString();
            mtbMenuPriceChild.Text = selected.PriceChild.ToString();

            loadTags();
            for (int i = 0; i < clbMenuTags.Items.Count; i++)
            {
                MenuTagDto etiqueta = (MenuTagDto)clbMenuTags.Items[i];
                foreach (MenuTagDto tagDelMenu in selected.TagList)
                {
                    if (tagDelMenu.Id == etiqueta.Id)
                    {
                        clbMenuTags.SetItemChecked(i, true);
                    }
                }
            }

            panelMenusList.Visible = false;
            panelMenusList.Dock = DockStyle.None;
            panelMenuUpload.Visible = true;
            panelMenuUpload.Dock = DockStyle.Fill;
        }

        private void btnMenuRemove_Click(object sender, EventArgs e)
        {
            if (mtLvMenus.SelectedItems.Count == 0)
            {
                MessageHelper.showWarning("seleccione un menu para eliminar");
                return;
            }

            ListViewItem selectedMenu = mtLvMenus.SelectedItems[0];
            MenuDto selected = (MenuDto)selectedMenu.Tag;

            if (!MessageHelper.confirm(
                "¿Eliminar el menu " + selected.Description + "?"))
            {
                return;
            }

            menuController.removeMenu(selected.Id);
            reloadMtlv();
        }

        private void btnMenuTags_Click(object sender, EventArgs e)
        {
            this.Hide();
            formMenuTags.Show();
        }



        //seccion Carga
        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            panelMenusList.Visible = true;
            panelMenusList.Dock = DockStyle.Fill;
            panelMenuUpload.Visible = false;
            panelMenuUpload.Dock = DockStyle.None;

            mtbMenuDescription.Text = null;
            mtbMenuPriceAdult.Text = null;
            mtbMenuPriceChild.Text = null;
            clbMenuTags.Items.Clear();

            idEditando = 0;
        }

        private void btnGuardarMenu_Click(object sender, EventArgs e)
        {
            decimal priceAdult;
            if (!decimal.TryParse(mtbMenuPriceAdult.Text, out priceAdult))
            {
                MessageHelper.showWarning("ingrese un precio por adulto valido");
                return;
            }

            decimal priceChild;
            if (!decimal.TryParse(mtbMenuPriceChild.Text, out priceChild))
            {
                MessageHelper.showWarning("ingrese un precio por niño valido");
                return;
            }

            List<MenuTagDto> etiquetas = new List<MenuTagDto>();
            foreach (MenuTagDto etiqueta in clbMenuTags.CheckedItems)
            {
                etiquetas.Add(etiqueta);
            }

            MenuDto menuDto = new MenuDto(mtbMenuDescription.Text, priceAdult, priceChild, etiquetas);

            try
            {
                if (idEditando == 0)
                {
                    menuController.addToRepository(menuDto);
                }
                else
                {
                    menuController.updateMenu(idEditando, menuDto);
                }
            }
            catch (BusinessRuleException ex)
            {
                MessageHelper.showWarning(ex.Message);
                return;
            }

            reloadMtlv();

            btnVolverMenu_Click(sender, e);
        }
    }
}
