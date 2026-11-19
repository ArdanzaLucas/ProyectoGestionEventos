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

        private int editingId = 0;

        public FormMenus(MenuController controller, MenuTagController menuTagController)
        {
            menuController = controller;
            this.menuTagController = menuTagController;
            InitializeComponent();
            VisualHelper.FitColumns(mtLvMenus);
            VisualHelper.CenterContent(panelMenuUpload);
        }

        public void SetFormMenuTags(FormMenuTags formMenuTags)
        {
            this.formMenuTags = formMenuTags;
        }

        private void FormMenus_Load(object sender, EventArgs e)
        {
            panelMenusList.Visible = true;
            panelMenusList.Dock = DockStyle.Fill;
            panelMenuUpload.Visible = false;

            ReloadList();
        }

        public void ResetView()
        {
            btnBackMenu_Click(null, EventArgs.Empty);
            ReloadList();
        }

        public void ReloadList()
        {
            List<MenuDto> menus = menuController.GetMenus();

            mtLvMenus.Items.Clear();

            foreach (MenuDto menu in menus)
            {
                ListViewItem row = new ListViewItem();

                row.Text = menu.Description;
                row.SubItems.Add(menu.PriceAdult.ToString("C"));
                row.SubItems.Add(menu.PriceChild.ToString("C"));

                string tags = "";
                foreach (MenuTagDto tag in menu.TagList)
                {
                    if (tags != "")
                    {
                        tags = tags + ", ";
                    }
                    tags = tags + tag.Description;
                }
                row.SubItems.Add(tags);
                row.Tag = menu;

                mtLvMenus.Items.Add(row);
            }

            VisualHelper.ShowEmptyMessage(mtLvMenus, "Todavia no hay menus. Toque Crear para agregar uno.");
        }

        private void LoadTags()
        {
            clbMenuTags.Items.Clear();

            clbMenuTags.DisplayMember = "Description";

            List<MenuTagDto> tags = menuTagController.GetMenuTags();
            foreach (MenuTagDto tag in tags)
            {
                clbMenuTags.Items.Add(tag);
            }
        }



        //seccion CRUD
        private void btnMenuCreate_Click(object sender, EventArgs e)
        {
            editingId = 0;
            LoadTags();

            panelMenusList.Visible = false;
            panelMenusList.Dock = DockStyle.None;
            panelMenuUpload.Visible = true;
            panelMenuUpload.Dock = DockStyle.Fill;
        }

        private void mtLvMenus_DoubleClick(object sender, EventArgs e)
        {
            btnMenuEdit_Click(sender, e);
        }

        private void btnMenuEdit_Click(object sender, EventArgs e)
        {
            if (mtLvMenus.SelectedItems.Count == 0)
            {
                MessageHelper.ShowWarning("seleccione un menu para editar");
                return;
            }

            ListViewItem selectedMenu = mtLvMenus.SelectedItems[0];
            MenuDto selected = (MenuDto)selectedMenu.Tag;

            editingId = selected.Id;

            mtbMenuDescription.Text = selected.Description;
            nudMenuPriceAdult.Value = selected.PriceAdult;
            nudMenuPriceChild.Value = selected.PriceChild;

            LoadTags();
            for (int i = 0; i < clbMenuTags.Items.Count; i++)
            {
                MenuTagDto tag = (MenuTagDto)clbMenuTags.Items[i];
                foreach (MenuTagDto menuTag in selected.TagList)
                {
                    if (menuTag.Id == tag.Id)
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
                MessageHelper.ShowWarning("seleccione un menu para eliminar");
                return;
            }

            ListViewItem selectedMenu = mtLvMenus.SelectedItems[0];
            MenuDto selected = (MenuDto)selectedMenu.Tag;

            if (!MessageHelper.Confirm(
                "¿Eliminar el menu " + selected.Description + "?"))
            {
                return;
            }

            menuController.RemoveMenu(selected.Id);
            ReloadList();
        }

        private void btnMenuTags_Click(object sender, EventArgs e)
        {
            this.Hide();
            formMenuTags.Show();
        }



        //seccion Carga
        private void btnBackMenu_Click(object sender, EventArgs e)
        {
            panelMenusList.Visible = true;
            panelMenusList.Dock = DockStyle.Fill;
            panelMenuUpload.Visible = false;
            panelMenuUpload.Dock = DockStyle.None;

            mtbMenuDescription.Text = null;
            nudMenuPriceAdult.Value = 0;
            nudMenuPriceChild.Value = 0;
            clbMenuTags.Items.Clear();

            editingId = 0;
        }

        private void btnSaveMenu_Click(object sender, EventArgs e)
        {
            decimal priceAdult = decimal.Round(nudMenuPriceAdult.Value, 2);
            decimal priceChild = decimal.Round(nudMenuPriceChild.Value, 2);

            List<MenuTagDto> tags = new List<MenuTagDto>();
            foreach (MenuTagDto tag in clbMenuTags.CheckedItems)
            {
                tags.Add(tag);
            }

            MenuDto menuDto = new MenuDto(mtbMenuDescription.Text, priceAdult, priceChild, tags);

            try
            {
                if (editingId == 0)
                {
                    menuController.AddToRepository(menuDto);
                }
                else
                {
                    menuController.UpdateMenu(editingId, menuDto);
                }
            }
            catch (BusinessRuleException ex)
            {
                MessageHelper.ShowWarning(ex.Message);
                return;
            }

            ReloadList();

            btnBackMenu_Click(sender, e);
        }
    }
}
