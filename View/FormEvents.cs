using ProyectoPresupuestoEvento.Controller;
using ProyectoPresupuestoEvento.Dto;
using ProyectoPresupuestoEvento.Common;

namespace ProyectoPresupuestoEvento.View
{
    public partial class FormEvents : Form
    {

        private EventItemController eventController;

        private int editingId = 0;

        public FormEvents(EventItemController controller)
        {
            eventController = controller;
            InitializeComponent();
            VisualHelper.FitColumns(mtLvEvents);
            VisualHelper.CenterContent(panelEventsCU);
        }

        private void FormEvents_Load(object sender, EventArgs e)
        {
            panelEventsList.Visible = true;
            panelEventsList.Dock = DockStyle.Fill;
            panelEventsCU.Visible = false;

            ReloadList();
        }

        public void ResetView()
        {
            btnBackEvent_Click(null, EventArgs.Empty);
            ReloadList();
        }

        private void ReloadList()
        {
            List<EventItemDto> eventItems = eventController.GetEventItems();

            mtLvEvents.Items.Clear();

            foreach (EventItemDto eventItem in eventItems)
            {
                ListViewItem row = new ListViewItem();

                row.Text = eventItem.Name;
                row.SubItems.Add(eventItem.ClientName);
                row.SubItems.Add(eventItem.Date.ToString("dd/MM/yyyy HH:mm"));
                row.SubItems.Add(eventItem.GuestAdults.ToString());
                row.SubItems.Add(eventItem.GuestChildren.ToString());
                row.SubItems.Add(eventItem.Duration.ToString());

                row.Tag = eventItem;

                mtLvEvents.Items.Add(row);
            }

            VisualHelper.ShowEmptyMessage(mtLvEvents, "Todavia no hay eventos. Toque Crear para agregar uno.");
        }



        //seccion CRUD
        private void btnEventCreate_Click(object sender, EventArgs e)
        {
            editingId = 0;
            dtpEventDate.Value = DateTime.Now;

            panelEventsList.Visible = false;
            panelEventsList.Dock = DockStyle.None;
            panelEventsCU.Visible = true;
            panelEventsCU.Dock = DockStyle.Fill;
        }

        private void mtLvEvents_DoubleClick(object sender, EventArgs e)
        {
            btnEventEdit_Click(sender, e);
        }

        private void btnEventEdit_Click(object sender, EventArgs e)
        {
            if (mtLvEvents.SelectedItems.Count == 0)
            {
                MessageHelper.ShowWarning("seleccione un evento para editar");
                return;
            }

            ListViewItem selectedEvent = mtLvEvents.SelectedItems[0];
            EventItemDto selected = (EventItemDto)selectedEvent.Tag;

            editingId = selected.Id;

            mtbEventName.Text = selected.Name;
            mtbEventClient.Text = selected.ClientName;
            dtpEventDate.Value = selected.Date;
            nudEventAdults.Value = selected.GuestAdults;
            nudEventChildren.Value = selected.GuestChildren;
            nudEventDuration.Value = selected.Duration;

            panelEventsList.Visible = false;
            panelEventsList.Dock = DockStyle.None;
            panelEventsCU.Visible = true;
            panelEventsCU.Dock = DockStyle.Fill;
        }

        private void btnEventRemove_Click(object sender, EventArgs e)
        {
            if (mtLvEvents.SelectedItems.Count == 0)
            {
                MessageHelper.ShowWarning("seleccione un evento para eliminar");
                return;
            }

            ListViewItem selectedEvent = mtLvEvents.SelectedItems[0];
            EventItemDto selected = (EventItemDto)selectedEvent.Tag;

            string message = "¿Eliminar el evento " + selected.Name + "?";
            int quoteCount = eventController.CountQuotes(selected.Id);
            if (quoteCount > 0)
            {
                message = message + " tiene " + quoteCount + " presupuestos que tambien se borran";
            }

            if (!MessageHelper.Confirm(message))
            {
                return;
            }

            eventController.RemoveEventItem(selected.Id);
            ReloadList();
        }



        //seccion Carga
        private void btnBackEvent_Click(object sender, EventArgs e)
        {
            panelEventsList.Visible = true;
            panelEventsList.Dock = DockStyle.Fill;
            panelEventsCU.Visible = false;
            panelEventsCU.Dock = DockStyle.None;

            mtbEventName.Text = null;
            mtbEventClient.Text = null;
            nudEventAdults.Value = 0;
            nudEventChildren.Value = 0;
            nudEventDuration.Value = 1;

            editingId = 0;
        }

        private void btnSaveEvent_Click(object sender, EventArgs e)
        {
            int guestAdults = (int)nudEventAdults.Value;
            int guestChildren = (int)nudEventChildren.Value;
            int duration = (int)nudEventDuration.Value;

            EventItemDto eventItemDto = new EventItemDto(mtbEventName.Text, mtbEventClient.Text, dtpEventDate.Value, guestAdults, guestChildren, duration);

            try
            {
                if (editingId == 0)
                {
                    eventController.AddToRepository(eventItemDto);
                }
                else
                {
                    eventController.UpdateEventItem(editingId, eventItemDto);
                }
            }
            catch (BusinessRuleException ex)
            {
                MessageHelper.ShowWarning(ex.Message);
                return;
            }

            ReloadList();

            btnBackEvent_Click(sender, e);
        }
    }
}
