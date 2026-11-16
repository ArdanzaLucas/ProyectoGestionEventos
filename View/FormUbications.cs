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
    public partial class FormUbications : Form
    {
        private UbicationController ubicationController;

        private int idEditando = 0;


        public FormUbications(UbicationController controller)
        {
            this.ubicationController = controller;
            InitializeComponent();
            VisualHelper.fitColumns(mtLvUbications);
            VisualHelper.centerContent(panelUpload);
        }

        private void FormUbications_Load(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel3.Visible = false;

            reloadMtlv();
        }

        public void resetView()
        {
            btnVolverAtras_Click(null, EventArgs.Empty);
            reloadMtlv();
        }

        private void reloadMtlv()
        {
            List<UbicationDto> ubicaciones = ubicationController.getUbications();

            mtLvUbications.Items.Clear();

            foreach (UbicationDto ubicacion in ubicaciones)
            {
                ListViewItem fila = new ListViewItem();

                fila.Text = ubicacion.Name;
                fila.SubItems.Add(ubicacion.Price.ToString("C"));

                fila.Tag = ubicacion;

                mtLvUbications.Items.Add(fila);
            }

            VisualHelper.showEmptyMessage(mtLvUbications, "Todavia no hay ubicaciones. Toque Crear para agregar una.");
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


        private void mtLvUbications_DoubleClick(object sender, EventArgs e)
        {
            btnUbicationEdit_Click(sender, e);
        }

        private void btnUbicationEdit_Click(object sender, EventArgs e)
        {
            if
                (
                    mtLvUbications.SelectedItems.Count == 0
                )
            {
                MessageHelper.showWarning("seleccione una ubicacion para editar");
                return;
            }

            ListViewItem selectedUbication = mtLvUbications.SelectedItems[0];
            UbicationDto selected = (UbicationDto)selectedUbication.Tag;


            idEditando = selected.Id;

            mtbUbicationName.Text = selected.Name;
            nudUbicationPrice.Value = selected.Price;



            panel2.Visible = false;
            panel3.Visible = true;
            panel3.Dock = DockStyle.Fill;
            panelUpload.Dock = DockStyle.Fill;

        }

        private void btnUbicationRemove_Click(object sender, EventArgs e)
        {
            if (mtLvUbications.SelectedItems.Count == 0)
            {
                MessageHelper.showWarning("seleccione una ubicacion para eliminar");
                return;
            }

            ListViewItem selectedUbication = mtLvUbications.SelectedItems[0];
            UbicationDto selected = (UbicationDto)selectedUbication.Tag;

            if (!MessageHelper.confirm(
                "¿Eliminar la ubicacion " + selected.Name + "?"))
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
            nudUbicationPrice.Value = 0;

            idEditando = 0;
        }

        private void btnGuardarUbicacion_Click(object sender, EventArgs e)
        {
            decimal price = decimal.Round(nudUbicationPrice.Value, 2);

            UbicationDto ubicationDto = new UbicationDto(mtbUbicationName.Text, price);

            try
            {
                if (idEditando == 0)
                {
                    ubicationController.addToRepository(ubicationDto);
                }
                else
                {
                    ubicationController.updateUbication(idEditando, ubicationDto);
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
