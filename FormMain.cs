using MaterialSkin;
using MaterialSkin.Controls;
using ProyectoPresupuestoEvento.View;
using ProyectoPresupuestoEvento.Controller;

namespace ProyectoPresupuestoEvento

{
    public partial class FormMain : MaterialForm
    {
        private EventItemController eventsController;
        private MenuController menuController;
        private MenuTagController menuTagController;
        private OptionItemController optionItemsController;
        private QuoteController quoteController;
        private UbicationController ubicationController;

        private FormIndex frmIndex;
        private FormReport frmReport;
        private FormQuoteEdit frmQuoteEdit;
        private FormEvents frmEvents;
        private FormUbications frmUbications;
        private FormOptionItem frmOI;
        private FormMenus frmMenus;
        private FormMenuTags frmMenuTags;

        public FormMain()
        {
            InitializeComponent();

            VisualHelper.setMaterialTheme();

            this.DrawerIsOpen = false;


            string[] iconos = { "IconQuote.png", "iconEvent.png", "IconPin.png", "IconRegistry.png", "IconMenus.png" };
            VisualHelper.linkSidebarIcons(TabCtrl, imageList1, iconos);

            eventsController = new EventItemController();
            menuController= new MenuController();
            menuTagController = new MenuTagController();
            optionItemsController= new OptionItemController();
            quoteController = new QuoteController();
            ubicationController = new UbicationController();
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            frmIndex = new FormIndex(quoteController, eventsController);
            frmIndex.TopLevel = false;
            frmIndex.Dock = DockStyle.Fill;
            this.pnlIndex.Controls.Add(frmIndex);
            frmIndex.Show();
            frmReport = new FormReport(frmIndex);
            frmReport.TopLevel = false;
            frmReport.Dock = DockStyle.Fill;
            this.pnlIndex.Controls.Add(frmReport);
            frmIndex.setFormReport(frmReport);
            frmQuoteEdit = new FormQuoteEdit(quoteController, eventsController, ubicationController, menuController, optionItemsController);
            frmQuoteEdit.TopLevel = false;
            frmQuoteEdit.Dock = DockStyle.Fill;
            this.pnlIndex.Controls.Add(frmQuoteEdit);
            frmQuoteEdit.setFormIndex(frmIndex);
            frmIndex.setFormQuoteEdit(frmQuoteEdit);
            frmEvents = new FormEvents(eventsController);
            frmEvents.TopLevel = false;
            frmEvents.Dock = DockStyle.Fill;
            this.pnlCntEvents.Controls.Add(frmEvents);
            frmEvents.Show();
            frmUbications = new FormUbications(ubicationController);
            frmUbications.TopLevel = false;
            frmUbications.Dock = DockStyle.Fill;
            this.pnlCntUbications.Controls.Add(frmUbications);
            frmUbications.Show();
            frmOI = new FormOptionItem(optionItemsController);
            frmOI.TopLevel = false;
            frmOI.Dock = DockStyle.Fill;
            this.pnlCntOpIts.Controls.Add(frmOI);
            frmOI.Show();
            frmMenus = new FormMenus(menuController, menuTagController);
            frmMenus.TopLevel = false;
            frmMenus.Dock = DockStyle.Fill;
            this.pnlCntCatering.Controls.Add(frmMenus);
            frmMenus.Show();
            frmMenuTags = new FormMenuTags(menuTagController, frmMenus);
            frmMenuTags.TopLevel = false;
            frmMenuTags.Dock = DockStyle.Fill;
            this.pnlCntCatering.Controls.Add(frmMenuTags);
            frmMenus.setFormMenuTags(frmMenuTags);


        }

        private void TabCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabCtrl.SelectedTab == tabIndex)
            {
                frmReport.Hide();
                frmQuoteEdit.Hide();
                frmQuoteEdit.resetView();
                frmIndex.Show();
                frmIndex.resetView();
            }
            else if (TabCtrl.SelectedTab == tabEvents)
            {
                frmEvents.resetView();
            }
            else if (TabCtrl.SelectedTab == tabUbications)
            {
                frmUbications.resetView();
            }
            else if (TabCtrl.SelectedTab == tabOptionItem)
            {
                frmOI.resetView();
            }
            else if (TabCtrl.SelectedTab == tabCatering)
            {
                frmMenuTags.Hide();
                frmMenuTags.resetView();
                frmMenus.Show();
                frmMenus.resetView();
            }
        }
    }
}
