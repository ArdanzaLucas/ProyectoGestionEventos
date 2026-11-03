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
    public partial class FormOptionItem : Form
    {
        private OptionItemController optionItemController;

        // id del servicio que se esta editando. Vale 0 cuando se crea uno nuevo.
        private int idEditando = 0;


        public FormOptionItem(OptionItemController controller)
        {
            this.optionItemController = controller;
            InitializeComponent();
        }


        private void FormOptionItem_Load(object sender, EventArgs e)
        {
            panelOIList.Visible = true;
            panelOICU.Visible = false;

            reloadMtlv();
        }

        // la llama FormMain cada vez que se entra a la pestaña:
        // vuelve a la lista (descarta lo que se estaba cargando) y recarga los datos
        public void resetView()
        {
            btnVolverAtras_Click(null, EventArgs.Empty);
            reloadMtlv();
        }

        private void reloadMtlv()
        {
            // 1. Pedís los DTOs al controller.
            List<OptionItemDto> servicios = optionItemController.getOptionItems();

            // 2. Quitás las filas anteriores para no duplicar datos.
            mtLvOptionItems.Items.Clear();

            // 3. Convertís cada DTO en una fila del MaterialListView.
            foreach (OptionItemDto servicio in servicios)
            {
                ListViewItem fila = new ListViewItem();

                // Primera columna.
                fila.Text = servicio.Id.ToString();

                // Segunda y tercera columna.
                fila.SubItems.Add(servicio.Name);
                fila.SubItems.Add(servicio.Price.ToString("C"));

                // Conserva el DTO completo asociado a la fila.
                fila.Tag = servicio;

                // 4. Agregás la fila visual a la lista.
                mtLvOptionItems.Items.Add(fila);
            }
        }



        //seccion CRUD
        private void btnOICreate_Click(object sender, EventArgs e)
        {
            idEditando = 0;

            panelOIList.Visible = false;
            panelOICU.Visible = true;
            panelOICU.Dock = DockStyle.Fill;
            panelOIUpload.Dock = DockStyle.Fill;

        }


        private void btnOIEdit_Click(object sender, EventArgs e)
        {
            if
                (
                    mtLvOptionItems.SelectedItems.Count == 0
                )
            {
                MessageBox.Show("seleccione un servicio para editar");
                return;
            }

            ListViewItem selectedOptionItem = mtLvOptionItems.SelectedItems[0];
            OptionItemDto selected = (OptionItemDto)selectedOptionItem.Tag;


            idEditando = selected.Id;

            mtbOIName.Text = selected.Name;
            mtbOIPrice.Text = selected.Price.ToString();



            panelOIList.Visible = false;
            panelOICU.Visible = true;
            panelOICU.Dock = DockStyle.Fill;
            panelOIUpload.Dock = DockStyle.Fill;

        }

        private void btnOIRemove_Click(object sender, EventArgs e)
        {
            if (mtLvOptionItems.SelectedItems.Count == 0)
            {
                MessageBox.Show("seleccione un servicio para eliminar");
                return;
            }

            ListViewItem selectedOptionItem = mtLvOptionItems.SelectedItems[0];
            OptionItemDto selected = (OptionItemDto)selectedOptionItem.Tag;

            DialogResult respuesta = MessageBox.Show(
                "¿Eliminar el servicio " + selected.Name + "?",
                "Confirmar", MessageBoxButtons.YesNo);

            if (respuesta == DialogResult.No)
            {
                return;
            }

            optionItemController.removeOptionItem(selected.Id);
            reloadMtlv();

        }





        //seccion Carga
        private void btnVolverAtras_Click(object sender, EventArgs e)
        {
            panelOIList.Visible = true;
            panelOICU.Visible = false;
            panelOICU.Dock = DockStyle.None;
            panelOIUpload.Dock = DockStyle.None;

            mtbOIName.Text = null;
            mtbOIPrice.Text = null;

            idEditando = 0;
        }

        private void btnGuardarOI_Click(object sender, EventArgs e)
        {
            // Trim saca los espacios del principio y del final
            string name = mtbOIName.Text.Trim();
            if (name == "")
            {
                MessageBox.Show("ingrese un nombre");
                return;
            }

            decimal price;
            if (!decimal.TryParse(mtbOIPrice.Text, out price) || price < 0)
            {
                MessageBox.Show("ingrese un precio valido");
                return;
            }

            OptionItemDto optionItemDto = new OptionItemDto(name, price);


            if (idEditando == 0)
            {
                optionItemController.addToRepository(optionItemDto);
            }
            else
            {
                optionItemController.updateOptionItem(idEditando, optionItemDto);
            }

            reloadMtlv();

            // vuelve a la lista y limpia los campos, igual que el boton Volver
            btnVolverAtras_Click(sender, e);
        }

        
    }
}
