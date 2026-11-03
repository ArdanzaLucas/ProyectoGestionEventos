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

namespace ProyectoPresupuestoEvento.View
{
    public partial class FormEvents : Form
    {

        EventItemController eventController;

        // id del evento que se esta editando. Vale 0 cuando se crea uno nuevo.
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

        // la llama FormMain cada vez que se entra a la pestaña:
        // vuelve a la lista (descarta lo que se estaba cargando) y recarga los datos
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

                // guarda el DTO completo en la fila
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
                MessageBox.Show("seleccione un evento para editar");
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
                MessageBox.Show("seleccione un evento para eliminar");
                return;
            }

            ListViewItem selectedEvent = mtLvEvents.SelectedItems[0];
            EventItemDto selected = (EventItemDto)selectedEvent.Tag;

            // si tiene presupuestos, se avisa que tambien se borran
            string mensaje = "¿Eliminar el evento " + selected.Name + "?";
            int cantidadPresupuestos = eventController.countQuotes(selected.Id);
            if (cantidadPresupuestos > 0)
            {
                mensaje = mensaje + " tiene " + cantidadPresupuestos + " presupuestos que tambien se borran";
            }

            DialogResult respuesta = MessageBox.Show(mensaje, "Confirmar", MessageBoxButtons.YesNo);

            if (respuesta == DialogResult.No)
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
            // Trim saca los espacios del principio y del final
            string name = mtbEventName.Text.Trim();
            if (name == "")
            {
                MessageBox.Show("ingrese un nombre para el evento");
                return;
            }

            string clientName = mtbEventClient.Text.Trim();
            if (clientName == "")
            {
                MessageBox.Show("ingrese el nombre del cliente");
                return;
            }

            DateTime fecha = dtpEventDate.Value;

            // al crear no se aceptan dias pasados; al editar si.
            // .Date se queda solo con el dia (sin la hora), asi hoy a cualquier hora vale.
            if (idEditando == 0 && fecha.Date < DateTime.Today)
            {
                MessageBox.Show("la fecha del evento no puede ser anterior a hoy");
                return;
            }

            int guestAdults;
            if (!int.TryParse(mtbEventAdults.Text, out guestAdults) || guestAdults < 0)
            {
                MessageBox.Show("ingrese una cantidad de adultos valida");
                return;
            }

            int guestChilds;
            if (!int.TryParse(mtbEventChilds.Text, out guestChilds) || guestChilds < 0)
            {
                MessageBox.Show("ingrese una cantidad de niños valida");
                return;
            }

            if (guestAdults + guestChilds == 0)
            {
                MessageBox.Show("el evento tiene que tener al menos un invitado");
                return;
            }

            int duration;
            if (!int.TryParse(mtbEventDuration.Text, out duration) || duration <= 0)
            {
                MessageBox.Show("ingrese una duracion valida (horas enteras, mayor a 0)");
                return;
            }

            EventItemDto eventItemDto = new EventItemDto(name, clientName, fecha, guestAdults, guestChilds, duration);

            if (idEditando == 0)
            {
                eventController.addToRepository(eventItemDto);
            }
            else
            {
                eventController.updateEventItem(idEditando, eventItemDto);
            }

            reloadMtlv();

            // vuelve a la lista y limpia los campos, igual que el boton Volver
            btnVolverEvento_Click(sender, e);
        }
    }
}
