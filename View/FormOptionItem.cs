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
    public partial class FormOptionItem : Form
    {
        private OptionItemController optionItemController;

        private int idEditando = 0;


        public FormOptionItem(OptionItemController controller)
        {
            this.optionItemController = controller;
            InitializeComponent();
            VisualHelper.fitColumns(mtLvOptionItems);
            VisualHelper.centerContent(panelOIUpload);
        }


        private void FormOptionItem_Load(object sender, EventArgs e)
        {
            panelOIList.Visible = true;
            panelOICU.Visible = false;

            reloadMtlv();
        }

        public void resetView()
        {
            btnVolverAtras_Click(null, EventArgs.Empty);
            reloadMtlv();
        }

        private void reloadMtlv()
        {
            List<OptionItemDto> servicios = optionItemController.getOptionItems();

            mtLvOptionItems.Items.Clear();

            foreach (OptionItemDto servicio in servicios)
            {
                ListViewItem fila = new ListViewItem();

                fila.Text = servicio.Name;
                fila.SubItems.Add(servicio.Price.ToString("C"));

                fila.Tag = servicio;

                mtLvOptionItems.Items.Add(fila);
            }

            VisualHelper.showEmptyMessage(mtLvOptionItems, "Todavia no hay servicios. Toque Crear para agregar uno.");
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


        private void mtLvOptionItems_DoubleClick(object sender, EventArgs e)
        {
            btnOIEdit_Click(sender, e);
        }

        private void btnOIEdit_Click(object sender, EventArgs e)
        {
            if
                (
                    mtLvOptionItems.SelectedItems.Count == 0
                )
            {
                MessageHelper.showWarning("seleccione un servicio para editar");
                return;
            }

            ListViewItem selectedOptionItem = mtLvOptionItems.SelectedItems[0];
            OptionItemDto selected = (OptionItemDto)selectedOptionItem.Tag;


            idEditando = selected.Id;

            mtbOIName.Text = selected.Name;
            nudOIPrice.Value = selected.Price;



            panelOIList.Visible = false;
            panelOICU.Visible = true;
            panelOICU.Dock = DockStyle.Fill;
            panelOIUpload.Dock = DockStyle.Fill;

        }

        private void btnOIRemove_Click(object sender, EventArgs e)
        {
            if (mtLvOptionItems.SelectedItems.Count == 0)
            {
                MessageHelper.showWarning("seleccione un servicio para eliminar");
                return;
            }

            ListViewItem selectedOptionItem = mtLvOptionItems.SelectedItems[0];
            OptionItemDto selected = (OptionItemDto)selectedOptionItem.Tag;

            if (!MessageHelper.confirm(
                "¿Eliminar el servicio " + selected.Name + "?"))
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
            nudOIPrice.Value = 0;

            idEditando = 0;
        }

        private void btnGuardarOI_Click(object sender, EventArgs e)
        {
            decimal price = decimal.Round(nudOIPrice.Value, 2);

            OptionItemDto optionItemDto = new OptionItemDto(mtbOIName.Text, price);

            try
            {
                if (idEditando == 0)
                {
                    optionItemController.addToRepository(optionItemDto);
                }
                else
                {
                    optionItemController.updateOptionItem(idEditando, optionItemDto);
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
