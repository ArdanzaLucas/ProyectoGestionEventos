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

        private int editingId = 0;


        public FormOptionItem(OptionItemController controller)
        {
            this.optionItemController = controller;
            InitializeComponent();
            VisualHelper.FitColumns(mtLvOptionItems);
            VisualHelper.CenterContent(panelOIUpload);
        }


        private void FormOptionItem_Load(object sender, EventArgs e)
        {
            panelOIList.Visible = true;
            panelOICU.Visible = false;

            ReloadList();
        }

        public void ResetView()
        {
            btnBack_Click(null, EventArgs.Empty);
            ReloadList();
        }

        private void ReloadList()
        {
            List<OptionItemDto> optionItems = optionItemController.GetOptionItems();

            mtLvOptionItems.Items.Clear();

            foreach (OptionItemDto optionItem in optionItems)
            {
                ListViewItem row = new ListViewItem();

                row.Text = optionItem.Name;
                row.SubItems.Add(optionItem.Price.ToString("C"));

                row.Tag = optionItem;

                mtLvOptionItems.Items.Add(row);
            }

            VisualHelper.ShowEmptyMessage(mtLvOptionItems, "Todavia no hay servicios. Toque Crear para agregar uno.");
        }



        //seccion CRUD
        private void btnOICreate_Click(object sender, EventArgs e)
        {
            editingId = 0;

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
                MessageHelper.ShowWarning("seleccione un servicio para editar");
                return;
            }

            ListViewItem selectedOptionItem = mtLvOptionItems.SelectedItems[0];
            OptionItemDto selected = (OptionItemDto)selectedOptionItem.Tag;


            editingId = selected.Id;

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
                MessageHelper.ShowWarning("seleccione un servicio para eliminar");
                return;
            }

            ListViewItem selectedOptionItem = mtLvOptionItems.SelectedItems[0];
            OptionItemDto selected = (OptionItemDto)selectedOptionItem.Tag;

            if (!MessageHelper.Confirm(
                "¿Eliminar el servicio " + selected.Name + "?"))
            {
                return;
            }

            optionItemController.RemoveOptionItem(selected.Id);
            ReloadList();

        }





        //seccion Carga
        private void btnBack_Click(object sender, EventArgs e)
        {
            panelOIList.Visible = true;
            panelOICU.Visible = false;
            panelOICU.Dock = DockStyle.None;
            panelOIUpload.Dock = DockStyle.None;

            mtbOIName.Text = null;
            nudOIPrice.Value = 0;

            editingId = 0;
        }

        private void btnSaveOI_Click(object sender, EventArgs e)
        {
            decimal price = decimal.Round(nudOIPrice.Value, 2);

            OptionItemDto optionItemDto = new OptionItemDto(mtbOIName.Text, price);

            try
            {
                if (editingId == 0)
                {
                    optionItemController.AddToRepository(optionItemDto);
                }
                else
                {
                    optionItemController.UpdateOptionItem(editingId, optionItemDto);
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
