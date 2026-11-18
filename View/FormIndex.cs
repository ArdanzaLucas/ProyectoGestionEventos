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
    public partial class FormIndex : Form
    {
        private QuoteController quoteController;
        private EventItemController eventController;

        private FormReport formReport;
        private FormQuoteEdit formQuoteEdit;

        public FormIndex(QuoteController quoteController, EventItemController eventController)
        {
            this.quoteController = quoteController;
            this.eventController = eventController;
            InitializeComponent();
            VisualHelper.fitColumns(mtLvIndex);
        }

        public void setFormReport(FormReport formReport)
        {
            this.formReport = formReport;
        }

        public void setFormQuoteEdit(FormQuoteEdit formQuoteEdit)
        {
            this.formQuoteEdit = formQuoteEdit;
        }

        private void FormIndex_Load(object sender, EventArgs e)
        {
            panelIndexList.Visible = true;
            panelIndexList.Dock = DockStyle.Fill;

            reloadFilter();
            reloadMtlv();
        }

        public void resetView()
        {
            reloadFilter();
            cmbFilterEvent.SelectedIndex = 0;
            reloadMtlv();
        }



        //seccion Lista

        private void reloadFilter()
        {
            int idElegido = 0;
            if (cmbFilterEvent.SelectedItem != null)
            {
                idElegido = ((EventItemDto)cmbFilterEvent.SelectedItem).Id;
            }

            cmbFilterEvent.Items.Clear();
            cmbFilterEvent.DisplayMember = "DisplayName";

            cmbFilterEvent.Items.Add(new EventItemDto(0, "Todos", "", DateTime.Now, 0, 0, 0));

            List<EventItemDto> eventos = eventController.getEventItems();
            foreach (EventItemDto evento in eventos)
            {
                cmbFilterEvent.Items.Add(evento);
            }

            cmbFilterEvent.SelectedIndex = 0;
            for (int i = 0; i < cmbFilterEvent.Items.Count; i++)
            {
                if (((EventItemDto)cmbFilterEvent.Items[i]).Id == idElegido)
                {
                    cmbFilterEvent.SelectedIndex = i;
                }
            }
        }

        public void reloadMtlv()
        {
            int idEvento = 0;
            if (cmbFilterEvent.SelectedItem != null)
            {
                idEvento = ((EventItemDto)cmbFilterEvent.SelectedItem).Id;
            }

            List<QuoteDto> presupuestos;
            if (idEvento == 0)
            {
                presupuestos = quoteController.getQuotes();
            }
            else
            {
                presupuestos = quoteController.getQuotesByEventItem(idEvento);
            }

            mtLvIndex.Items.Clear();

            foreach (QuoteDto presupuesto in presupuestos)
            {
                ListViewItem fila = new ListViewItem();

                fila.Text = presupuesto.Id.ToString();
                fila.SubItems.Add(presupuesto.EventItemName);
                fila.SubItems.Add(presupuesto.EventDate.ToString("dd/MM/yyyy"));
                fila.SubItems.Add(presupuesto.UbicationName);
                fila.SubItems.Add(presupuesto.TotalGuests.ToString());
                fila.SubItems.Add(presupuesto.State.ToString());
                fila.SubItems.Add(presupuesto.Total.ToString("C"));

                fila.Tag = presupuesto;

                mtLvIndex.Items.Add(fila);
            }

            if (idEvento == 0)
            {
                VisualHelper.showEmptyMessage(mtLvIndex, "Todavia no hay presupuestos. Toque Nuevo para armar uno.");
            }
            else
            {
                VisualHelper.showEmptyMessage(mtLvIndex, "Este evento todavia no tiene presupuestos.");
            }
        }

        private void cmbFilterEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadMtlv();
        }

        private QuoteDto getSelectedQuote(string accion)
        {
            if (mtLvIndex.SelectedItems.Count == 0)
            {
                MessageHelper.showWarning("seleccione un presupuesto para " + accion);
                return null;
            }

            return (QuoteDto)mtLvIndex.SelectedItems[0].Tag;
        }



        //seccion CRUD
        private void btnQuoteCreate_Click(object sender, EventArgs e)
        {
            int idFiltro = ((EventItemDto)cmbFilterEvent.SelectedItem).Id;
            formQuoteEdit.showNew(idFiltro);
            this.Hide();
            formQuoteEdit.Show();
        }

        private void mtLvIndex_DoubleClick(object sender, EventArgs e)
        {
            btnQuoteEdit_Click(sender, e);
        }

        private void btnQuoteEdit_Click(object sender, EventArgs e)
        {
            QuoteDto selected = getSelectedQuote("editar");
            if (selected == null)
            {
                return;
            }

            if (selected.State != EstadoPresupuesto.Pendiente)
            {
                MessageHelper.showWarning("solo se puede editar un presupuesto pendiente");
                return;
            }

            formQuoteEdit.showEdit(selected);
            this.Hide();
            formQuoteEdit.Show();
        }

        private void btnQuoteAccept_Click(object sender, EventArgs e)
        {
            QuoteDto selected = getSelectedQuote("aceptar");
            if (selected == null)
            {
                return;
            }

            if (!MessageHelper.confirm(
                "¿Aceptar el presupuesto N° " + selected.Id + " de " + selected.EventItemName + "? ya no se va a poder editar"))
            {
                return;
            }

            try
            {
                quoteController.acceptQuote(selected.Id);
            }
            catch (BusinessRuleException ex)
            {
                MessageHelper.showWarning(ex.Message);
            }

            reloadMtlv();
        }

        private void btnQuoteCancel_Click(object sender, EventArgs e)
        {
            QuoteDto selected = getSelectedQuote("cancelar");
            if (selected == null)
            {
                return;
            }

            if (!MessageHelper.confirm(
                "¿Cancelar el presupuesto N° " + selected.Id + " de " + selected.EventItemName + "? ya no se va a poder editar"))
            {
                return;
            }

            try
            {
                quoteController.cancelQuote(selected.Id);
            }
            catch (BusinessRuleException ex)
            {
                MessageHelper.showWarning(ex.Message);
            }

            reloadMtlv();
        }

        private void btnQuoteClone_Click(object sender, EventArgs e)
        {
            QuoteDto selected = getSelectedQuote("clonar");
            if (selected == null)
            {
                return;
            }

            try
            {
                quoteController.cloneQuote(selected.Id);
            }
            catch (BusinessRuleException ex)
            {
                MessageHelper.showWarning(ex.Message);
            }

            reloadMtlv();
        }

        private void btnQuoteRemove_Click(object sender, EventArgs e)
        {
            QuoteDto selected = getSelectedQuote("eliminar");
            if (selected == null)
            {
                return;
            }

            string mensaje = "¿Eliminar el presupuesto N° " + selected.Id + " de " + selected.EventItemName + "?";
            if (selected.State == EstadoPresupuesto.Aceptado)
            {
                mensaje = mensaje + " es el presupuesto ACEPTADO del evento";
            }

            if (!MessageHelper.confirm(mensaje))
            {
                return;
            }

            quoteController.removeQuote(selected.Id);
            reloadMtlv();
        }

        private void btnIndexReport_Click(object sender, EventArgs e)
        {
            QuoteDto selected = getSelectedQuote("ver el detalle");
            if (selected == null)
            {
                return;
            }

            formReport.showQuote(selected);
            this.Hide();
            formReport.Show();
        }
    }
}
