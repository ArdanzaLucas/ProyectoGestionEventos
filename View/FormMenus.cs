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

namespace ProyectoPresupuestoEvento.View
{
    public partial class FormMenus : Form
    {

        MenuController menuController;

        // se usa para cargar las etiquetas en la lista con casillas
        MenuTagController menuTagController;

        // formulario de etiquetas: esta en el mismo lugar que este, pero oculto
        FormMenuTags formMenuTags;

        // id del menu que se esta editando. Vale 0 cuando se crea uno nuevo.
        private int idEditando = 0;

        public FormMenus(MenuController controller, MenuTagController menuTagController)
        {
            menuController = controller;
            this.menuTagController = menuTagController;
            InitializeComponent();
        }

        // lo llama FormMain despues de crear los dos formularios
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

        // es publico porque tambien lo llama FormMenuTags al volver
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

                // junta las etiquetas en un solo texto: "Estandar, Vegana"
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

                // guarda el DTO completo en la fila
                fila.Tag = menu;

                mtLvMenus.Items.Add(fila);
            }
        }

        // carga todas las etiquetas en la lista con casillas, sin marcar
        private void loadTags()
        {
            clbMenuTags.Items.Clear();

            // muestra la descripcion de cada etiqueta en vez del nombre de la clase
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
                MessageBox.Show("seleccione un menu para editar");
                return;
            }

            ListViewItem selectedMenu = mtLvMenus.SelectedItems[0];
            MenuDto selected = (MenuDto)selectedMenu.Tag;

            idEditando = selected.Id;

            mtbMenuDescription.Text = selected.Description;
            mtbMenuPriceAdult.Text = selected.PriceAdult.ToString();
            mtbMenuPriceChild.Text = selected.PriceChild.ToString();

            // carga todas las etiquetas y marca las que ya tiene el menu
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
                MessageBox.Show("seleccione un menu para eliminar");
                return;
            }

            ListViewItem selectedMenu = mtLvMenus.SelectedItems[0];
            MenuDto selected = (MenuDto)selectedMenu.Tag;

            DialogResult respuesta = MessageBox.Show(
                "¿Eliminar el menu " + selected.Description + "?",
                "Confirmar", MessageBoxButtons.YesNo);

            if (respuesta == DialogResult.No)
            {
                return;
            }

            menuController.removeMenu(selected.Id);
            reloadMtlv();
        }

        // oculta los menus y muestra las etiquetas
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
            // Trim saca los espacios del principio y del final
            string description = mtbMenuDescription.Text.Trim();
            if (description == "")
            {
                MessageBox.Show("ingrese una descripcion");
                return;
            }

            decimal priceAdult;
            if (!decimal.TryParse(mtbMenuPriceAdult.Text, out priceAdult) || priceAdult < 0)
            {
                MessageBox.Show("ingrese un precio por adulto valido");
                return;
            }

            decimal priceChild;
            if (!decimal.TryParse(mtbMenuPriceChild.Text, out priceChild) || priceChild < 0)
            {
                MessageBox.Show("ingrese un precio por niño valido");
                return;
            }

            // arma la lista con las etiquetas marcadas
            List<MenuTagDto> etiquetas = new List<MenuTagDto>();
            foreach (MenuTagDto etiqueta in clbMenuTags.CheckedItems)
            {
                etiquetas.Add(etiqueta);
            }

            if (etiquetas.Count == 0)
            {
                MessageBox.Show("seleccione al menos una etiqueta");
                return;
            }

            MenuDto menuDto = new MenuDto(description, priceAdult, priceChild, etiquetas);

            if (idEditando == 0)
            {
                menuController.addToRepository(menuDto);
            }
            else
            {
                menuController.updateMenu(idEditando, menuDto);
            }

            reloadMtlv();

            // vuelve a la lista y limpia los campos, igual que el boton Volver
            btnVolverMenu_Click(sender, e);
        }
    }
}
