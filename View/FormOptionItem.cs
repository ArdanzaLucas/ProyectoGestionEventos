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
            VisualHelper.CenterContent(panelOptionItemUpload);
        }


        private void FormOptionItem_Load(object sender, EventArgs e)
        {
            panelOptionItemsList.Visible = true;
            panelOptionItemsCU.Visible = false;

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
        private void btnOptionItemCreate_Click(object sender, EventArgs e)
        {
            editingId = 0;

            panelOptionItemsList.Visible = false;
            panelOptionItemsCU.Visible = true;
            panelOptionItemsCU.Dock = DockStyle.Fill;
            panelOptionItemUpload.Dock = DockStyle.Fill;

        }


        private void mtLvOptionItems_DoubleClick(object sender, EventArgs e)
        {
            btnOptionItemEdit_Click(sender, e);
        }

        private void btnOptionItemEdit_Click(object sender, EventArgs e)
        {
            if (mtLvOptionItems.SelectedItems.Count == 0)
            {
                MessageHelper.ShowWarning("seleccione un servicio para editar");
                return;
            }

            ListViewItem selectedOptionItem = mtLvOptionItems.SelectedItems[0];
            OptionItemDto selected = (OptionItemDto)selectedOptionItem.Tag;


            editingId = selected.Id;

            mtbOptionItemName.Text = selected.Name;
            nudOptionItemPrice.Value = selected.Price;



            panelOptionItemsList.Visible = false;
            panelOptionItemsCU.Visible = true;
            panelOptionItemsCU.Dock = DockStyle.Fill;
            panelOptionItemUpload.Dock = DockStyle.Fill;

        }

        private void btnOptionItemRemove_Click(object sender, EventArgs e)
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
            panelOptionItemsList.Visible = true;
            panelOptionItemsCU.Visible = false;
            panelOptionItemsCU.Dock = DockStyle.None;
            panelOptionItemUpload.Dock = DockStyle.None;

            mtbOptionItemName.Text = null;
            nudOptionItemPrice.Value = 0;

            editingId = 0;
        }

        private void btnSaveOptionItem_Click(object sender, EventArgs e)
        {
            decimal price = decimal.Round(nudOptionItemPrice.Value, 2);

            OptionItemDto optionItemDto = new OptionItemDto(mtbOptionItemName.Text, price);

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
