using System.Diagnostics;
using ProyectoPresupuestoEvento.Controller;
using ProyectoPresupuestoEvento.Dto;
using ProyectoPresupuestoEvento.Common;

namespace ProyectoPresupuestoEvento.View
{
    public partial class FormIndex : Form
    {
        private QuoteController quoteController;
        private EventItemController eventController;

        private FormQuoteEdit formQuoteEdit;

        public FormIndex(QuoteController quoteController, EventItemController eventController)
        {
            this.quoteController = quoteController;
            this.eventController = eventController;
            InitializeComponent();
            VisualHelper.FitColumns(mtLvIndex);
            ClearTempPdfFolder();
        }

        public void SetFormQuoteEdit(FormQuoteEdit formQuoteEdit)
        {
            this.formQuoteEdit = formQuoteEdit;
        }

        private void FormIndex_Load(object sender, EventArgs e)
        {
            panelIndexList.Visible = true;
            panelIndexList.Dock = DockStyle.Fill;

            ReloadFilter();
            ReloadList();
        }

        public void ResetView()
        {
            ReloadFilter();
            cmbFilterEvent.SelectedIndex = 0;
            ReloadList();
        }



        //seccion Lista

        private void ReloadFilter()
        {
            int selectedId = 0;
            if (cmbFilterEvent.SelectedItem != null)
            {
                selectedId = ((EventItemDto)cmbFilterEvent.SelectedItem).Id;
            }

            cmbFilterEvent.Items.Clear();
            cmbFilterEvent.DisplayMember = "DisplayName";

            cmbFilterEvent.Items.Add(new EventItemDto(0, "Todos", "", DateTime.Now, 0, 0, 0));

            List<EventItemDto> eventItems = eventController.GetEventItems();
            foreach (EventItemDto eventItem in eventItems)
            {
                cmbFilterEvent.Items.Add(eventItem);
            }

            cmbFilterEvent.SelectedIndex = 0;
            for (int i = 0; i < cmbFilterEvent.Items.Count; i++)
            {
                if (((EventItemDto)cmbFilterEvent.Items[i]).Id == selectedId)
                {
                    cmbFilterEvent.SelectedIndex = i;
                }
            }
        }

        public void ReloadList()
        {
            int selectedEventId = 0;
            if (cmbFilterEvent.SelectedItem != null)
            {
                selectedEventId = ((EventItemDto)cmbFilterEvent.SelectedItem).Id;
            }

            List<QuoteDto> quotes;
            if (selectedEventId == 0)
            {
                quotes = quoteController.GetQuotes();
            }
            else
            {
                quotes = quoteController.GetQuotesByEventItem(selectedEventId);
            }

            mtLvIndex.Items.Clear();

            foreach (QuoteDto quote in quotes)
            {
                ListViewItem row = new ListViewItem();

                row.Text = quote.Id.ToString();
                row.SubItems.Add(quote.EventItemName);
                row.SubItems.Add(quote.EventDate.ToString("dd/MM/yyyy"));
                row.SubItems.Add(quote.LocationName);
                row.SubItems.Add(quote.TotalGuests.ToString());
                row.SubItems.Add(QuoteStateText.GetDisplayName(quote.State));
                row.SubItems.Add(quote.Total.ToString("C"));

                row.Tag = quote;

                mtLvIndex.Items.Add(row);
            }

            if (selectedEventId == 0)
            {
                VisualHelper.ShowEmptyMessage(mtLvIndex, "Todavia no hay presupuestos. Toque Nuevo para armar uno.");
            }
            else
            {
                VisualHelper.ShowEmptyMessage(mtLvIndex, "Este evento todavia no tiene presupuestos.");
            }
        }

        private void cmbFilterEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadList();
        }

        private QuoteDto GetSelectedQuote(string action)
        {
            if (mtLvIndex.SelectedItems.Count == 0)
            {
                MessageHelper.ShowWarning("seleccione un presupuesto para " + action);
                return null;
            }

            return (QuoteDto)mtLvIndex.SelectedItems[0].Tag;
        }



        //seccion CRUD
        private void btnQuoteCreate_Click(object sender, EventArgs e)
        {
            int filterId = ((EventItemDto)cmbFilterEvent.SelectedItem).Id;
            formQuoteEdit.ShowNew(filterId);
            this.Hide();
            formQuoteEdit.Show();
        }

        private void mtLvIndex_DoubleClick(object sender, EventArgs e)
        {
            btnQuoteEdit_Click(sender, e);
        }

        private void btnQuoteEdit_Click(object sender, EventArgs e)
        {
            QuoteDto selected = GetSelectedQuote("editar");
            if (selected == null)
            {
                return;
            }

            if (!selected.IsEditable)
            {
                MessageHelper.ShowWarning("solo se puede editar un presupuesto pendiente");
                return;
            }

            formQuoteEdit.ShowEdit(selected);
            this.Hide();
            formQuoteEdit.Show();
        }

        private void btnQuoteAccept_Click(object sender, EventArgs e)
        {
            QuoteDto selected = GetSelectedQuote("aceptar");
            if (selected == null)
            {
                return;
            }

            if (!MessageHelper.Confirm(
                "¿Aceptar el presupuesto N° " + selected.Id + " de " + selected.EventItemName + "? ya no se va a poder editar"))
            {
                return;
            }

            RunQuoteAction(() => quoteController.AcceptQuote(selected.Id));
        }

        private void btnQuoteCancel_Click(object sender, EventArgs e)
        {
            QuoteDto selected = GetSelectedQuote("cancelar");
            if (selected == null)
            {
                return;
            }

            if (!MessageHelper.Confirm(
                "¿Cancelar el presupuesto N° " + selected.Id + " de " + selected.EventItemName + "? ya no se va a poder editar"))
            {
                return;
            }

            RunQuoteAction(() => quoteController.CancelQuote(selected.Id));
        }

        private void btnQuoteClone_Click(object sender, EventArgs e)
        {
            QuoteDto selected = GetSelectedQuote("clonar");
            if (selected == null)
            {
                return;
            }

            RunQuoteAction(() => quoteController.CloneQuote(selected.Id));
        }

        private void btnQuoteRemove_Click(object sender, EventArgs e)
        {
            QuoteDto selected = GetSelectedQuote("eliminar");
            if (selected == null)
            {
                return;
            }

            string message = "¿Eliminar el presupuesto N° " + selected.Id + " de " + selected.EventItemName + "?";
            if (selected.State == QuoteState.Accepted)
            {
                message = message + " es el presupuesto ACEPTADO del evento";
            }

            if (!MessageHelper.Confirm(message))
            {
                return;
            }

            quoteController.RemoveQuote(selected.Id);
            ReloadList();
        }

        // genera el pdf en una carpeta temporal y lo abre con el visor de pdf de Windows
        private void btnIndexReport_Click(object sender, EventArgs e)
        {
            QuoteDto selected = GetSelectedQuote("ver el detalle");
            if (selected == null)
            {
                return;
            }

            Directory.CreateDirectory(AppFolders.TempPdf);
            string path = Path.Combine(AppFolders.TempPdf, BuildPdfName(selected) + "_" + DateTime.Now.ToString("HHmmss") + ".pdf");
            if (!ExportPdf(selected, path))
            {
                return;
            }

            ProcessStartInfo viewer = new ProcessStartInfo(path);
            viewer.UseShellExecute = true;
            Process.Start(viewer);
        }

        private void btnQuoteSavePdf_Click(object sender, EventArgs e)
        {
            QuoteDto selected = GetSelectedQuote("guardar el PDF");
            if (selected == null)
            {
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Guardar presupuesto en PDF";
            dialog.Filter = "Archivo PDF (*.pdf)|*.pdf";
            dialog.FileName = BuildPdfName(selected) + ".pdf";

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (ExportPdf(selected, dialog.FileName))
            {
                MessageHelper.ShowInfo("el PDF se guardo en " + dialog.FileName);
            }
        }

        private void RunQuoteAction(Action action)
        {
            try
            {
                action();
            }
            catch (BusinessRuleException ex)
            {
                MessageHelper.ShowWarning(ex.Message);
            }

            ReloadList();
        }

        private void ClearTempPdfFolder()
        {
            if (!Directory.Exists(AppFolders.TempPdf))
            {
                return;
            }

            foreach (string file in Directory.GetFiles(AppFolders.TempPdf))
            {
                try
                {
                    File.Delete(file);
                }
                catch (IOException)
                {
                }
                catch (UnauthorizedAccessException)
                {
                }
            }
        }

        private bool ExportPdf(QuoteDto quote, string path)
        {
            try
            {
                quoteController.ExportPdf(quote.Id, path);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("no se pudo generar el PDF: " + ex.Message);
                return false;
            }
            return true;
        }

        private string BuildPdfName(QuoteDto quote)
        {
            string name = "Presupuesto_" + quote.Id + "_" + quote.EventItemName;
            foreach (char character in Path.GetInvalidFileNameChars())
            {
                name = name.Replace(character, '_');
            }
            return name.Replace(' ', '_');
        }
    }
}
