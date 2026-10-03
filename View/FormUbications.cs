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


            mtbUbicationName.Text = selected.Name;
            mtbUbicationPrice.Text = selected.Price.ToString();



            panel2.Visible = false;
            panel3.Visible = true;

        }

        private void btnUbicationRemove_Click(object sender, EventArgs e)
        {
            ListViewItem selectedUbication = mtLvUbications.SelectedItems[0];
            UbicationDto selected = (UbicationDto)selectedUbication.Tag;

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
        }

        private void btnGuardarUbicacion_Click(object sender, EventArgs e)
        {
            string name = mtbUbicationName.Text;
            decimal price = Convert.ToDecimal(mtbUbicationPrice.Text);

            UbicationDto ubicationDto = new UbicationDto(name, price);


            ubicationController.addToRepository(ubicationDto);
            reloadMtlv();
        }

        
    }
}
