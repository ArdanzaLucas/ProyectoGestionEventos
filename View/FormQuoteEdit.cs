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
    public partial class FormQuoteEdit : Form
    {
        private QuoteController quoteController;
        private EventItemController eventController;
        private UbicationController ubicationController;
        private MenuController menuController;
        private OptionItemController optionItemController;

        private FormIndex formIndex;

        private int idEditando = 0;

        private List<DetailMenuDto> lineas = new List<DetailMenuDto>();

        public FormQuoteEdit(QuoteController quoteController, EventItemController eventController,
            UbicationController ubicationController, MenuController menuController, OptionItemController optionItemController)
        {
            this.quoteController = quoteController;
            this.eventController = eventController;
            this.ubicationController = ubicationController;
            this.menuController = menuController;
            this.optionItemController = optionItemController;
            InitializeComponent();
            VisualHelper.centerContent(panelQuoteCU);
        }

        public void setFormIndex(FormIndex formIndex)
        {
            this.formIndex = formIndex;
        }

        public void resetView()
        {
            lineas = new List<DetailMenuDto>();
            lvQuoteLines.Items.Clear();
            idEditando = 0;
        }



        //seccion Abrir

        public void showNew(int idEventoFiltro)
        {
            idEditando = 0;
            loadCombos();

            cmbQuoteEvent.Enabled = true;
            for (int i = 0; i < cmbQuoteEvent.Items.Count; i++)
            {
                if (((EventItemDto)cmbQuoteEvent.Items[i]).Id == idEventoFiltro)
                {
                    cmbQuoteEvent.SelectedIndex = i;
                }
            }

            lineas = new List<DetailMenuDto>();

            refreshTotals();
        }

        public void showEdit(QuoteDto selected)
        {
            idEditando = selected.Id;
            loadCombos();

            for (int i = 0; i < cmbQuoteEvent.Items.Count; i++)
            {
                if (((EventItemDto)cmbQuoteEvent.Items[i]).Id == selected.EventItemId)
                {
                    cmbQuoteEvent.SelectedIndex = i;
                }
            }
            cmbQuoteEvent.Enabled = false;

            bool ubicacionEncontrada = false;
            for (int i = 0; i < cmbQuoteUbication.Items.Count; i++)
            {
                if (((UbicationDto)cmbQuoteUbication.Items[i]).Id == selected.UbicationId)
                {
                    cmbQuoteUbication.SelectedIndex = i;
                    ubicacionEncontrada = true;
                }
            }
            if (!ubicacionEncontrada)
            {
                UbicationDto deBaja = new UbicationDto(selected.UbicationId, selected.UbicationName + " (dada de baja)", selected.UbicationPrice);
                cmbQuoteUbication.Items.Add(deBaja);
                cmbQuoteUbication.SelectedItem = deBaja;
            }

            lineas = new List<DetailMenuDto>();
            foreach (DetailMenuDto linea in selected.MenusList)
            {
                DetailMenuDto copia = new DetailMenuDto(linea.MenuId, linea.TagDescription, linea.AdultQuantity, linea.ChildQuantity);
                copia.MenuDescription = linea.MenuDescription;
                lineas.Add(copia);
            }

            foreach (DetailOptionItemDto servicio in selected.OptionItemsList)
            {
                bool servicioEncontrado = false;
                for (int i = 0; i < clbQuoteOptionItems.Items.Count; i++)
                {
                    if (((OptionItemDto)clbQuoteOptionItems.Items[i]).Id == servicio.OptionItemId)
                    {
                        clbQuoteOptionItems.SetItemChecked(i, true);
                        servicioEncontrado = true;
                    }
                }
                if (!servicioEncontrado)
                {
                    OptionItemDto deBaja = new OptionItemDto(servicio.OptionItemId, servicio.OptionItemName + " (dado de baja)", servicio.UnitPrice);
                    int indice = clbQuoteOptionItems.Items.Add(deBaja);
                    clbQuoteOptionItems.SetItemChecked(indice, true);
                }
            }

            refreshTotals();
        }

        private void loadCombos()
        {
            cmbQuoteEvent.Items.Clear();
            cmbQuoteEvent.DisplayMember = "DisplayName";
            foreach (EventItemDto evento in eventController.getEventItems())
            {
                cmbQuoteEvent.Items.Add(evento);
            }

            cmbQuoteUbication.Items.Clear();
            cmbQuoteUbication.DisplayMember = "Name";
            foreach (UbicationDto ubicacion in ubicationController.getUbications())
            {
                cmbQuoteUbication.Items.Add(ubicacion);
            }

            cmbQuoteMenu.Items.Clear();
            cmbQuoteMenu.DisplayMember = "Description";
            foreach (MenuDto menu in menuController.getMenus())
            {
                cmbQuoteMenu.Items.Add(menu);
            }
            cmbQuoteTag.Items.Clear();

            clbQuoteOptionItems.Items.Clear();
            clbQuoteOptionItems.DisplayMember = "Name";
            foreach (OptionItemDto servicio in optionItemController.getOptionItems())
            {
                clbQuoteOptionItems.Items.Add(servicio);
            }

            nudQuoteAdults.Value = 0;
            nudQuoteChilds.Value = 0;
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
            foreach (MenuTagDto etiqueta in menu.TagList)
            {
                cmbQuoteTag.Items.Add(etiqueta);
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
                EventItemDto evento = (EventItemDto)cmbQuoteEvent.SelectedItem;
                lblQuoteGuests.Text = "Invitados del evento: " + evento.GuestAdults + " adultos / " + evento.GuestChilds + " niños";
            }

            refreshTotals();
        }

        private void cmbQuoteUbication_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshTotals();
        }

        private void clbQuoteOptionItems_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(refreshTotals));
        }

        private void btnAddLine_Click(object sender, EventArgs e)
        {
            if (cmbQuoteMenu.SelectedItem == null)
            {
                MessageHelper.showWarning("seleccione un menu");
                return;
            }

            if (cmbQuoteTag.SelectedItem == null)
            {
                MessageHelper.showWarning("seleccione una etiqueta");
                return;
            }

            int adultos = (int)nudQuoteAdults.Value;
            int ninos = (int)nudQuoteChilds.Value;
            if (adultos + ninos == 0)
            {
                MessageHelper.showWarning("ingrese al menos un plato (adultos o niños)");
                return;
            }

            MenuDto menu = (MenuDto)cmbQuoteMenu.SelectedItem;
            MenuTagDto etiqueta = (MenuTagDto)cmbQuoteTag.SelectedItem;

            bool yaEstaba = false;
            foreach (DetailMenuDto linea in lineas)
            {
                if (linea.MenuId == menu.Id && linea.TagDescription == etiqueta.Description)
                {
                    linea.AdultQuantity = linea.AdultQuantity + adultos;
                    linea.ChildQuantity = linea.ChildQuantity + ninos;
                    yaEstaba = true;
                }
            }

            if (!yaEstaba)
            {
                DetailMenuDto nueva = new DetailMenuDto(menu.Id, etiqueta.Description, adultos, ninos);
                nueva.MenuDescription = menu.Description;
                lineas.Add(nueva);
            }

            nudQuoteAdults.Value = 0;
            nudQuoteChilds.Value = 0;

            refreshTotals();
        }

        private void btnRemoveLine_Click(object sender, EventArgs e)
        {
            if (lvQuoteLines.SelectedItems.Count == 0)
            {
                MessageHelper.showWarning("seleccione una linea para quitar");
                return;
            }

            int indice = lvQuoteLines.SelectedItems[0].Index;
            lineas.RemoveAt(indice);

            refreshTotals();
        }

        private QuoteDto buildQuoteDto()
        {
            EventItemDto evento = (EventItemDto)cmbQuoteEvent.SelectedItem;
            UbicationDto ubicacion = (UbicationDto)cmbQuoteUbication.SelectedItem;

            List<DetailOptionItemDto> servicios = new List<DetailOptionItemDto>();
            foreach (OptionItemDto servicio in clbQuoteOptionItems.CheckedItems)
            {
                servicios.Add(new DetailOptionItemDto(servicio.Id));
            }

            QuoteDto dto = new QuoteDto(evento.Id, ubicacion.Id, lineas, servicios);
            return dto;
        }

        private void refreshTotals()
        {
            if (cmbQuoteEvent.SelectedItem == null || cmbQuoteUbication.SelectedItem == null)
            {
                showLines(lineas, false);
                lblTotalUbication.Text = "Ubicacion: -";
                lblTotalMenus.Text = "Catering: -";
                lblTotalOptionItems.Text = "Servicios: -";
                lblTotal.Text = "Total: -";
                return;
            }

            QuoteDto preview = quoteController.calculatePreview(buildQuoteDto());

            showLines(preview.MenusList, true);
            lblTotalUbication.Text = "Ubicacion: " + preview.TotalUbication.ToString("C");
            lblTotalMenus.Text = "Catering: " + preview.TotalMenus.ToString("C");
            lblTotalOptionItems.Text = "Servicios: " + preview.TotalOptionItems.ToString("C");
            lblTotal.Text = "Total: " + preview.Total.ToString("C");
        }

        private void showLines(List<DetailMenuDto> lista, bool conSubtotal)
        {
            lvQuoteLines.Items.Clear();

            foreach (DetailMenuDto linea in lista)
            {
                ListViewItem fila = new ListViewItem();
                fila.Text = linea.MenuDescription;
                fila.SubItems.Add(linea.TagDescription);
                fila.SubItems.Add(linea.AdultQuantity.ToString());
                fila.SubItems.Add(linea.ChildQuantity.ToString());

                if (conSubtotal)
                {
                    fila.SubItems.Add(linea.Subtotal.ToString("C"));
                }
                else
                {
                    fila.SubItems.Add("-");
                }

                lvQuoteLines.Items.Add(fila);
            }
        }



        //seccion Guardar y volver

        private void btnVolverQuote_Click(object sender, EventArgs e)
        {
            resetView();
            this.Hide();
            formIndex.Show();
        }

        private void btnGuardarQuote_Click(object sender, EventArgs e)
        {
            if (cmbQuoteEvent.SelectedItem == null)
            {
                MessageHelper.showWarning("seleccione un evento");
                return;
            }

            if (cmbQuoteUbication.SelectedItem == null)
            {
                MessageHelper.showWarning("seleccione una ubicacion");
                return;
            }

            QuoteDto quoteDto = buildQuoteDto();

            try
            {
                if (idEditando == 0)
                {
                    quoteController.addQuote(quoteDto);
                }
                else
                {
                    quoteController.updateQuote(idEditando, quoteDto);
                }
            }
            catch (BusinessRuleException ex)
            {
                MessageHelper.showWarning(ex.Message);
                return;
            }

            formIndex.reloadMtlv();

            btnVolverQuote_Click(sender, e);
        }
    }
}
