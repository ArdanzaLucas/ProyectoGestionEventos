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
    public partial class FormLocations : Form
    {
        private LocationController locationController;

        private int editingId = 0;


        public FormLocations(LocationController controller)
        {
            this.locationController = controller;
            InitializeComponent();
            VisualHelper.FitColumns(mtLvLocations);
            VisualHelper.CenterContent(panelUpload);
        }

        private void FormLocations_Load(object sender, EventArgs e)
        {
            panelLocationsList.Visible = true;
            panelLocationsCU.Visible = false;

            ReloadList();
        }

        public void ResetView()
        {
            btnBack_Click(null, EventArgs.Empty);
            ReloadList();
        }

        private void ReloadList()
        {
            List<LocationDto> locations = locationController.GetLocations();

            mtLvLocations.Items.Clear();

            foreach (LocationDto location in locations)
            {
                ListViewItem row = new ListViewItem();

                row.Text = location.Name;
                row.SubItems.Add(location.Price.ToString("C"));

                row.Tag = location;

                mtLvLocations.Items.Add(row);
            }

            VisualHelper.ShowEmptyMessage(mtLvLocations, "Todavia no hay ubicaciones. Toque Crear para agregar una.");
        }



        //seccion CRUD
        private void btnLocationCreate_Click(object sender, EventArgs e)
        {
            editingId = 0;

            panelLocationsList.Visible = false;
            panelLocationsCU.Visible = true;
            panelLocationsCU.Dock = DockStyle.Fill;
            panelUpload.Dock = DockStyle.Fill;

        }


        private void mtLvLocations_DoubleClick(object sender, EventArgs e)
        {
            btnLocationEdit_Click(sender, e);
        }

        private void btnLocationEdit_Click(object sender, EventArgs e)
        {
            if
                (
                    mtLvLocations.SelectedItems.Count == 0
                )
            {
                MessageHelper.ShowWarning("seleccione una ubicacion para editar");
                return;
            }

            ListViewItem selectedLocation = mtLvLocations.SelectedItems[0];
            LocationDto selected = (LocationDto)selectedLocation.Tag;


            editingId = selected.Id;

            mtbLocationName.Text = selected.Name;
            nudLocationPrice.Value = selected.Price;



            panelLocationsList.Visible = false;
            panelLocationsCU.Visible = true;
            panelLocationsCU.Dock = DockStyle.Fill;
            panelUpload.Dock = DockStyle.Fill;

        }

        private void btnLocationRemove_Click(object sender, EventArgs e)
        {
            if (mtLvLocations.SelectedItems.Count == 0)
            {
                MessageHelper.ShowWarning("seleccione una ubicacion para eliminar");
                return;
            }

            ListViewItem selectedLocation = mtLvLocations.SelectedItems[0];
            LocationDto selected = (LocationDto)selectedLocation.Tag;

            if (!MessageHelper.Confirm(
                "¿Eliminar la ubicacion " + selected.Name + "?"))
            {
                return;
            }

            locationController.RemoveLocation(selected.Id);
            ReloadList();

        }





        //seccion Carga
        private void btnBack_Click(object sender, EventArgs e)
        {
            panelLocationsList.Visible = true;
            panelLocationsCU.Visible = false;
            panelLocationsCU.Dock = DockStyle.None;
            panelUpload.Dock = DockStyle.None;

            mtbLocationName.Text = null;
            nudLocationPrice.Value = 0;

            editingId = 0;
        }

        private void btnSaveLocation_Click(object sender, EventArgs e)
        {
            decimal price = decimal.Round(nudLocationPrice.Value, 2);

            LocationDto locationDto = new LocationDto(mtbLocationName.Text, price);

            try
            {
                if (editingId == 0)
                {
                    locationController.AddToRepository(locationDto);
                }
                else
                {
                    locationController.UpdateLocation(editingId, locationDto);
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
