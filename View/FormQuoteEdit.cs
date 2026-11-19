using ProyectoPresupuestoEvento.Controller;
using ProyectoPresupuestoEvento.Dto;
using ProyectoPresupuestoEvento.Common;

namespace ProyectoPresupuestoEvento.View
{
    public partial class FormQuoteEdit : Form
    {
        private QuoteController quoteController;
        private EventItemController eventController;
        private LocationController locationController;
        private MenuController menuController;
        private OptionItemController optionItemController;

        private FormIndex formIndex;

        private int editingId = 0;

        private List<DetailMenuDto> lines = new List<DetailMenuDto>();

        public FormQuoteEdit(QuoteController quoteController, EventItemController eventController,
            LocationController locationController, MenuController menuController, OptionItemController optionItemController)
        {
            this.quoteController = quoteController;
            this.eventController = eventController;
            this.locationController = locationController;
            this.menuController = menuController;
            this.optionItemController = optionItemController;
            InitializeComponent();
            VisualHelper.CenterContent(panelQuoteCU);
        }

        public void SetFormIndex(FormIndex formIndex)
        {
            this.formIndex = formIndex;
        }

        public void ResetView()
        {
            lines = new List<DetailMenuDto>();
            lvQuoteLines.Items.Clear();
            editingId = 0;
        }



        //seccion Abrir

        public void ShowNew(int filterEventId)
        {
            editingId = 0;
            LoadCombos();

            cmbQuoteEvent.Enabled = true;
            for (int i = 0; i < cmbQuoteEvent.Items.Count; i++)
            {
                if (((EventItemDto)cmbQuoteEvent.Items[i]).Id == filterEventId)
                {
                    cmbQuoteEvent.SelectedIndex = i;
                }
            }

            lines = new List<DetailMenuDto>();

            RefreshTotals();
        }

        public void ShowEdit(QuoteDto selected)
        {
            editingId = selected.Id;
            LoadCombos();

            for (int i = 0; i < cmbQuoteEvent.Items.Count; i++)
            {
                if (((EventItemDto)cmbQuoteEvent.Items[i]).Id == selected.EventItemId)
                {
                    cmbQuoteEvent.SelectedIndex = i;
                }
            }
            cmbQuoteEvent.Enabled = false;

            bool locationFound = false;
            for (int i = 0; i < cmbQuoteLocation.Items.Count; i++)
            {
                if (((LocationDto)cmbQuoteLocation.Items[i]).Id == selected.LocationId)
                {
                    cmbQuoteLocation.SelectedIndex = i;
                    locationFound = true;
                }
            }
            if (!locationFound)
            {
                LocationDto inactiveItem = new LocationDto(selected.LocationId, selected.LocationName + " (dada de baja)", selected.LocationPrice);
                cmbQuoteLocation.Items.Add(inactiveItem);
                cmbQuoteLocation.SelectedItem = inactiveItem;
            }

            lines = new List<DetailMenuDto>();
            foreach (DetailMenuDto line in selected.MenuList)
            {
                DetailMenuDto copy = new DetailMenuDto(line.MenuId, line.TagDescription, line.AdultQuantity, line.ChildQuantity);
                copy.MenuDescription = line.MenuDescription;
                lines.Add(copy);
            }

            foreach (DetailOptionItemDto optionItem in selected.OptionItemList)
            {
                bool optionItemFound = false;
                for (int i = 0; i < clbQuoteOptionItems.Items.Count; i++)
                {
                    if (((OptionItemDto)clbQuoteOptionItems.Items[i]).Id == optionItem.OptionItemId)
                    {
                        clbQuoteOptionItems.SetItemChecked(i, true);
                        optionItemFound = true;
                    }
                }
                if (!optionItemFound)
                {
                    OptionItemDto inactiveItem = new OptionItemDto(optionItem.OptionItemId, optionItem.OptionItemName + " (dado de baja)", optionItem.UnitPrice);
                    int index = clbQuoteOptionItems.Items.Add(inactiveItem);
                    clbQuoteOptionItems.SetItemChecked(index, true);
                }
            }

            RefreshTotals();
        }

        private void LoadCombos()
        {
            cmbQuoteEvent.Items.Clear();
            cmbQuoteEvent.DisplayMember = "DisplayName";
            foreach (EventItemDto eventItem in eventController.GetEventItems())
            {
                cmbQuoteEvent.Items.Add(eventItem);
            }

            cmbQuoteLocation.Items.Clear();
            cmbQuoteLocation.DisplayMember = "Name";
            foreach (LocationDto location in locationController.GetLocations())
            {
                cmbQuoteLocation.Items.Add(location);
            }

            cmbQuoteMenu.Items.Clear();
            cmbQuoteMenu.DisplayMember = "Description";
            foreach (MenuDto menu in menuController.GetMenus())
            {
                cmbQuoteMenu.Items.Add(menu);
            }
            cmbQuoteTag.Items.Clear();

            clbQuoteOptionItems.Items.Clear();
            clbQuoteOptionItems.DisplayMember = "Name";
            foreach (OptionItemDto optionItem in optionItemController.GetOptionItems())
            {
                clbQuoteOptionItems.Items.Add(optionItem);
            }

            nudQuoteAdults.Value = 0;
            nudQuoteChildren.Value = 0;
            lblQuoteGuests.Text = "Invitados del evento: -";
        }



        //seccion Carga

        private void cmbQuoteMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbQuoteTag.Items.Clear();
            cmbQuoteTag.DisplayMember = "Description";

            if (cmbQuoteMenu.SelectedItem == null)
            {
                return;
            }

            MenuDto menu = (MenuDto)cmbQuoteMenu.SelectedItem;
            foreach (MenuTagDto tag in menu.TagList)
            {
                cmbQuoteTag.Items.Add(tag);
            }

            if (cmbQuoteTag.Items.Count > 0)
            {
                cmbQuoteTag.SelectedIndex = 0;
            }
        }

        private void cmbQuoteEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbQuoteEvent.SelectedItem == null)
            {
                lblQuoteGuests.Text = "Invitados del evento: -";
            }
            else
            {
                EventItemDto eventItem = (EventItemDto)cmbQuoteEvent.SelectedItem;
                lblQuoteGuests.Text = "Invitados del evento: " + eventItem.GuestAdults + " adultos / " + eventItem.GuestChildren + " niños";
            }

            RefreshTotals();
        }

        private void cmbQuoteLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTotals();
        }

        private void clbQuoteOptionItems_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(() => RefreshTotals()));
        }

        private void btnAddLine_Click(object sender, EventArgs e)
        {
            if (cmbQuoteMenu.SelectedItem == null)
            {
                MessageHelper.ShowWarning("seleccione un menu");
                return;
            }

            if (cmbQuoteTag.SelectedItem == null)
            {
                MessageHelper.ShowWarning("seleccione una etiqueta");
                return;
            }

            int adults = (int)nudQuoteAdults.Value;
            int children = (int)nudQuoteChildren.Value;
            if (adults + children == 0)
            {
                MessageHelper.ShowWarning("ingrese al menos un plato (adultos o niños)");
                return;
            }

            MenuDto menu = (MenuDto)cmbQuoteMenu.SelectedItem;
            MenuTagDto tag = (MenuTagDto)cmbQuoteTag.SelectedItem;

            DetailMenuDto existingLine = null;
            foreach (DetailMenuDto line in lines)
            {
                if (line.MenuId == menu.Id && line.TagDescription == tag.Description)
                {
                    existingLine = line;
                }
            }

            DetailMenuDto newLine = null;
            if (existingLine != null)
            {
                existingLine.AdultQuantity = existingLine.AdultQuantity + adults;
                existingLine.ChildQuantity = existingLine.ChildQuantity + children;
            }
            else
            {
                newLine = new DetailMenuDto(menu.Id, tag.Description, adults, children);
                newLine.MenuDescription = menu.Description;
                lines.Add(newLine);
            }

            if (!RefreshTotals())
            {
                if (existingLine != null)
                {
                    existingLine.AdultQuantity = existingLine.AdultQuantity - adults;
                    existingLine.ChildQuantity = existingLine.ChildQuantity - children;
                }
                else
                {
                    lines.Remove(newLine);
                }
                RefreshTotals();
                return;
            }

            nudQuoteAdults.Value = 0;
            nudQuoteChildren.Value = 0;
        }

        private void btnRemoveLine_Click(object sender, EventArgs e)
        {
            if (lvQuoteLines.SelectedItems.Count == 0)
            {
                MessageHelper.ShowWarning("seleccione una linea para quitar");
                return;
            }

            int index = lvQuoteLines.SelectedItems[0].Index;
            lines.RemoveAt(index);

            RefreshTotals();
        }

        private QuoteDto BuildQuoteDto()
        {
            EventItemDto eventItem = (EventItemDto)cmbQuoteEvent.SelectedItem;
            LocationDto location = (LocationDto)cmbQuoteLocation.SelectedItem;

            List<DetailOptionItemDto> optionItems = new List<DetailOptionItemDto>();
            foreach (OptionItemDto optionItem in clbQuoteOptionItems.CheckedItems)
            {
                optionItems.Add(new DetailOptionItemDto(optionItem.Id));
            }

            QuoteDto dto = new QuoteDto(eventItem.Id, location.Id, lines, optionItems);
            return dto;
        }

        private bool RefreshTotals()
        {
            if (cmbQuoteEvent.SelectedItem == null || cmbQuoteLocation.SelectedItem == null)
            {
                ShowEmptyTotals();
                return true;
            }

            QuoteDto preview;
            try
            {
                preview = quoteController.CalculatePreview(BuildQuoteDto());
            }
            catch (BusinessRuleException ex)
            {
                MessageHelper.ShowWarning(ex.Message);
                ShowEmptyTotals();
                return false;
            }

            ShowLines(preview.MenuList, true);
            lblTotalLocation.Text = "Ubicacion: " + preview.TotalLocation.ToString("C");
            lblTotalMenus.Text = "Catering: " + preview.TotalMenus.ToString("C");
            lblTotalOptionItems.Text = "Servicios: " + preview.TotalOptionItems.ToString("C");
            lblTotal.Text = "Total: " + preview.Total.ToString("C");
            return true;
        }

        private void ShowEmptyTotals()
        {
            ShowLines(lines, false);
            lblTotalLocation.Text = "Ubicacion: -";
            lblTotalMenus.Text = "Catering: -";
            lblTotalOptionItems.Text = "Servicios: -";
            lblTotal.Text = "Total: -";
        }

        private void ShowLines(List<DetailMenuDto> list, bool withSubtotal)
        {
            lvQuoteLines.Items.Clear();

            foreach (DetailMenuDto line in list)
            {
                ListViewItem row = new ListViewItem();
                row.Text = line.MenuDescription;
                row.SubItems.Add(line.TagDescription);
                row.SubItems.Add(line.AdultQuantity.ToString());
                row.SubItems.Add(line.ChildQuantity.ToString());

                if (withSubtotal)
                {
                    row.SubItems.Add(line.Subtotal.ToString("C"));
                }
                else
                {
                    row.SubItems.Add("-");
                }

                lvQuoteLines.Items.Add(row);
            }
        }



        //seccion Guardar y volver

        private void btnBackQuote_Click(object sender, EventArgs e)
        {
            ResetView();
            this.Hide();
            formIndex.Show();
        }

        private void btnSaveQuote_Click(object sender, EventArgs e)
        {
            if (cmbQuoteEvent.SelectedItem == null)
            {
                MessageHelper.ShowWarning("seleccione un evento");
                return;
            }

            if (cmbQuoteLocation.SelectedItem == null)
            {
                MessageHelper.ShowWarning("seleccione una ubicacion");
                return;
            }

            QuoteDto quoteDto = BuildQuoteDto();

            try
            {
                if (editingId == 0)
                {
                    quoteController.AddQuote(quoteDto);
                }
                else
                {
                    quoteController.UpdateQuote(editingId, quoteDto);
                }
            }
            catch (BusinessRuleException ex)
            {
                MessageHelper.ShowWarning(ex.Message);
                return;
            }

            formIndex.ReloadList();

            btnBackQuote_Click(sender, e);
        }
    }
}
