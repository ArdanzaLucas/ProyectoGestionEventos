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
    public partial class FormEvents : Form
    {

        EventItemController eventController;

        private int idEditando = 0;

        public FormEvents(EventItemController controller)
        {
            eventController = controller;
            InitializeComponent();
        }

        private void FormEvents_Load(object sender, EventArgs e)
        {
            panelEventsList.Visible = true;
            panelEventsList.Dock = DockStyle.Fill;
            panelEventsCU.Visible = false;

            reloadMtlv();
        }

        public void resetView()
        {
            btnVolverEvento_Click(null, EventArgs.Empty);
            reloadMtlv();
        }

        private void reloadMtlv()
        {
            List<EventItemDto> eventos = eventController.getEventItems();

            mtLvEvents.Items.Clear();

            foreach (EventItemDto evento in eventos)
            {
                ListViewItem fila = new ListViewItem();

                fila.Text = evento.Name;
                fila.SubItems.Add(evento.ClientName);
                fila.SubItems.Add(evento.Date.ToString("dd/MM/yyyy HH:mm"));
                fila.SubItems.Add(evento.GuestAdults.ToString());
                fila.SubItems.Add(evento.GuestChilds.ToString());
                fila.SubItems.Add(evento.Duration.ToString());

                fila.Tag = evento;

                mtLvEvents.Items.Add(fila);
            }
        }



        //seccion CRUD
        private void btnEventCreate_Click(object sender, EventArgs e)
        {
            idEditando = 0;
            dtpEventDate.Value = DateTime.Now;

            panelEventsList.Visible = false;
            panelEventsList.Dock = DockStyle.None;
            panelEventsCU.Visible = true;
            panelEventsCU.Dock = DockStyle.Fill;
        }

        private void btnEventEdit_Click(object sender, EventArgs e)
        {
            if (mtLvEvents.SelectedItems.Count == 0)
            {
                MessageHelper.showWarning("seleccione un evento para editar");
                return;
            }

            ListViewItem selectedEvent = mtLvEvents.SelectedItems[0];
            EventItemDto selected = (EventItemDto)selectedEvent.Tag;

            idEditando = selected.Id;

            mtbEventName.Text = selected.Name;
            mtbEventClient.Text = selected.ClientName;
            dtpEventDate.Value = selected.Date;
            mtbEventAdults.Text = selected.GuestAdults.ToString();
            mtbEventChilds.Text = selected.GuestChilds.ToString();
            mtbEventDuration.Text = selected.Duration.ToString();

            panelEventsList.Visible = false;
            panelEventsList.Dock = DockStyle.None;
            panelEventsCU.Visible = true;
            panelEventsCU.Dock = DockStyle.Fill;
        }

        private void btnEventRemove_Click(object sender, EventArgs e)
        {
            if (mtLvEvents.SelectedItems.Count == 0)
            {
                MessageHelper.showWarning("seleccione un evento para eliminar");
                return;
            }

            ListViewItem selectedEvent = mtLvEvents.SelectedItems[0];
            EventItemDto selected = (EventItemDto)selectedEvent.Tag;

            string mensaje = "¿Eliminar el evento " + selected.Name + "?";
            int cantidadPresupuestos = eventController.countQuotes(selected.Id);
            if (cantidadPresupuestos > 0)
            {
                mensaje = mensaje + " tiene " + cantidadPresupuestos + " presupuestos que tambien se borran";
            }

            if (!MessageHelper.confirm(mensaje))
            {
                return;
            }

            eventController.removeEventItem(selected.Id);
            reloadMtlv();
        }



        //seccion Carga
        private void btnVolverEvento_Click(object sender, EventArgs e)
        {
            panelEventsList.Visible = true;
            panelEventsList.Dock = DockStyle.Fill;
            panelEventsCU.Visible = false;
            panelEventsCU.Dock = DockStyle.None;

            mtbEventName.Text = null;
            mtbEventClient.Text = null;
            mtbEventAdults.Text = null;
            mtbEventChilds.Text = null;
            mtbEventDuration.Text = null;

            idEditando = 0;
        }

        private void btnGuardarEvento_Click(object sender, EventArgs e)
        {
            int guestAdults;
            if (!int.TryParse(mtbEventAdults.Text, out guestAdults))
            {
                MessageHelper.showWarning("ingrese una cantidad de adultos valida");
                return;
            }

            int guestChilds;
            if (!int.TryParse(mtbEventChilds.Text, out guestChilds))
            {
                MessageHelper.showWarning("ingrese una cantidad de niños valida");
                return;
            }

            int duration;
            if (!int.TryParse(mtbEventDuration.Text, out duration))
            {
                MessageHelper.showWarning("ingrese una duracion valida (horas enteras)");
                return;
            }

            EventItemDto eventItemDto = new EventItemDto(mtbEventName.Text, mtbEventClient.Text, dtpEventDate.Value, guestAdults, guestChilds, duration);

            try
            {
                if (idEditando == 0)
                {
                    eventController.addToRepository(eventItemDto);
                }
                else
                {
                    eventController.updateEventItem(idEditando, eventItemDto);
                }
            }
            catch (BusinessRuleException ex)
            {
                MessageHelper.showWarning(ex.Message);
                return;
            }

            reloadMtlv();

            btnVolverEvento_Click(sender, e);
        }
    }
}
