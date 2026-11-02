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
    public partial class FormMenuTags : Form
    {
        private MenuTagController menuTagController;

        // formulario de menus: se vuelve a mostrar con el boton "Volver a menus"
        private FormMenus formMenus;

        // id de la etiqueta que se esta editando. Vale 0 cuando se crea una nueva.
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

        private void reloadMtlv()
        {
            List<MenuTagDto> etiquetas = menuTagController.getMenuTags();

            mtLvMenuTags.Items.Clear();

            foreach (MenuTagDto etiqueta in etiquetas)
            {
                ListViewItem fila = new ListViewItem();

                fila.Text = etiqueta.Id.ToString();
                fila.SubItems.Add(etiqueta.Description);

                // guarda el DTO completo en la fila
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
                MessageBox.Show("seleccione una etiqueta para editar");
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
                MessageBox.Show("seleccione una etiqueta para eliminar");
                return;
            }

            ListViewItem selectedMenuTag = mtLvMenuTags.SelectedItems[0];
            MenuTagDto selected = (MenuTagDto)selectedMenuTag.Tag;

            // no se puede borrar si algun menu se quedaria sin etiquetas
            List<string> menusConSoloEsta = menuTagController.getMenusWithOnlyThisTag(selected.Id);
            if (menusConSoloEsta.Count > 0)
            {
                MessageBox.Show("no se puede eliminar: es la unica etiqueta de estos menus: "
                    + string.Join(", ", menusConSoloEsta)
                    + ". primero asigneles otra etiqueta");
                return;
            }

            int cantidadMenus = menuTagController.countMenusUsing(selected.Id);

            DialogResult respuesta = MessageBox.Show(
                "¿Eliminar la etiqueta " + selected.Description + "? la usan " + cantidadMenus + " menus",
                "Confirmar", MessageBoxButtons.YesNo);

            if (respuesta == DialogResult.No)
            {
                return;
            }

            menuTagController.removeMenuTag(selected.Id);
            reloadMtlv();
        }

        // oculta las etiquetas y vuelve a mostrar los menus
        private void btnVolverMenus_Click(object sender, EventArgs e)
        {
            this.Hide();
            // recarga la lista de menus por si se renombro o borro alguna etiqueta
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
            // Trim saca los espacios del principio y del final
            string description = mtbMenuTagDescription.Text.Trim();
            if (description == "")
            {
                MessageBox.Show("ingrese una descripcion");
                return;
            }

            // no puede haber dos etiquetas con el mismo nombre
            if (menuTagController.existsDescription(description, idEditando))
            {
                MessageBox.Show("ya existe una etiqueta con ese nombre");
                return;
            }

            MenuTagDto menuTagDto = new MenuTagDto(description);

            if (idEditando == 0)
            {
                menuTagController.addToRepository(menuTagDto);
            }
            else
            {
                menuTagController.updateMenuTag(idEditando, menuTagDto);
            }

            reloadMtlv();

            // vuelve a la lista y limpia los campos, igual que el boton Volver
            btnVolverAtras_Click(sender, e);
        }


    }
}
