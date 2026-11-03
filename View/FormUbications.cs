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
    public partial class FormUbications : Form
    {
        private UbicationController ubicationController;

        // id de la ubicacion que se esta editando. Vale 0 cuando se crea una nueva.
        private int idEditando = 0;


        public FormUbications(UbicationController controller)
        {
            this.ubicationController = controller;
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormUbications_Load(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel3.Visible = false;

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
            List<UbicationDto> ubicaciones = ubicationController.getUbications();

            // 2. Quitás las filas anteriores para no duplicar datos.
            mtLvUbications.Items.Clear();

            // 3. Convertís cada DTO en una fila del MaterialListView.
            foreach (UbicationDto ubicacion in ubicaciones)
            {
                ListViewItem fila = new ListViewItem();

                // Primera columna.
                fila.Text = ubicacion.Id.ToString();

                // Segunda y tercera columna.
                fila.SubItems.Add(ubicacion.Name);
                fila.SubItems.Add(ubicacion.Price.ToString("C"));

                // Conserva el DTO completo asociado a la fila.
                fila.Tag = ubicacion;

                // 4. Agregás la fila visual a la lista.
                mtLvUbications.Items.Add(fila);
            }
        }



        //seccion CRUD
        private void btnUbicationCreate_Click(object sender, EventArgs e)
        {
            idEditando = 0;

            panel2.Visible = false;
            panel3.Visible = true;
            panel3.Dock = DockStyle.Fill;
            panelUpload.Dock = DockStyle.Fill;

        }


        private void btnUbicationEdit_Click(object sender, EventArgs e)
        {
            if
                (
                    mtLvUbications.SelectedItems.Count == 0
                )
            {
                MessageBox.Show("seleccione una ubicacion para editar");
                return;
            }

            ListViewItem selectedUbication = mtLvUbications.SelectedItems[0];
            UbicationDto selected = (UbicationDto)selectedUbication.Tag;


            idEditando = selected.Id;

            mtbUbicationName.Text = selected.Name;
            mtbUbicationPrice.Text = selected.Price.ToString();



            panel2.Visible = false;
            panel3.Visible = true;
            panel3.Dock = DockStyle.Fill;
            panelUpload.Dock = DockStyle.Fill;

        }

        private void btnUbicationRemove_Click(object sender, EventArgs e)
        {
            if (mtLvUbications.SelectedItems.Count == 0)
            {
                MessageBox.Show("seleccione una ubicacion para eliminar");
                return;
            }

            ListViewItem selectedUbication = mtLvUbications.SelectedItems[0];
            UbicationDto selected = (UbicationDto)selectedUbication.Tag;

            DialogResult respuesta = MessageBox.Show(
                "¿Eliminar la ubicacion " + selected.Name + "?",
                "Confirmar", MessageBoxButtons.YesNo);

            if (respuesta == DialogResult.No)
            {
                return;
            }

            ubicationController.removeUbication(selected.Id);
            reloadMtlv();

        }





        //seccion Carga
        private void btnVolverAtras_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel3.Visible = false;
            panel3.Dock = DockStyle.None;
            panelUpload.Dock = DockStyle.None;

            mtbUbicationName.Text = null;
            mtbUbicationPrice.Text = null;

            idEditando = 0;
        }

        private void btnGuardarUbicacion_Click(object sender, EventArgs e)
        {
            // Trim saca los espacios del principio y del final
            string name = mtbUbicationName.Text.Trim();
            if (name == "")
            {
                MessageBox.Show("ingrese un nombre");
                return;
            }

            decimal price;
            if (!decimal.TryParse(mtbUbicationPrice.Text, out price) || price < 0)
            {
                MessageBox.Show("ingrese un precio valido");
                return;
            }

            UbicationDto ubicationDto = new UbicationDto(name, price);


            if (idEditando == 0)
            {
                ubicationController.addToRepository(ubicationDto);
            }
            else
            {
                ubicationController.updateUbication(idEditando, ubicationDto);
            }

            reloadMtlv();

            // vuelve a la lista y limpia los campos, igual que el boton Volver
            btnVolverAtras_Click(sender, e);
        }

        
    }
}
