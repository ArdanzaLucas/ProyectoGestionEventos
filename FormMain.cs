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
        private LocationController locationController;

        private FormIndex frmIndex;
        private FormQuoteEdit frmQuoteEdit;
        private FormEvents frmEvents;
        private FormLocations frmLocations;
        private FormOptionItem frmOI;
        private FormMenus frmMenus;
        private FormMenuTags frmMenuTags;

        public FormMain()
        {
            InitializeComponent();

            VisualHelper.SetMaterialTheme();

            this.DrawerIsOpen = false;


            string[] icons = { "IconQuote.png", "iconEvent.png", "IconPin.png", "IconRegistry.png", "IconMenus.png" };
            VisualHelper.LinkSidebarIcons(TabCtrl, imageList1, icons);

            eventsController = new EventItemController();
            menuController= new MenuController();
            menuTagController = new MenuTagController();
            optionItemsController= new OptionItemController();
            quoteController = new QuoteController();
            locationController = new LocationController();
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            frmIndex = new FormIndex(quoteController, eventsController);
            frmIndex.TopLevel = false;
            frmIndex.Dock = DockStyle.Fill;
            this.pnlIndex.Controls.Add(frmIndex);
            frmIndex.Show();
            frmQuoteEdit = new FormQuoteEdit(quoteController, eventsController, locationController, menuController, optionItemsController);
            frmQuoteEdit.TopLevel = false;
            frmQuoteEdit.Dock = DockStyle.Fill;
            this.pnlIndex.Controls.Add(frmQuoteEdit);
            frmQuoteEdit.SetFormIndex(frmIndex);
            frmIndex.SetFormQuoteEdit(frmQuoteEdit);
            frmEvents = new FormEvents(eventsController);
            frmEvents.TopLevel = false;
            frmEvents.Dock = DockStyle.Fill;
            this.pnlCntEvents.Controls.Add(frmEvents);
            frmEvents.Show();
            frmLocations = new FormLocations(locationController);
            frmLocations.TopLevel = false;
            frmLocations.Dock = DockStyle.Fill;
            this.pnlCntLocations.Controls.Add(frmLocations);
            frmLocations.Show();
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
            frmMenus.SetFormMenuTags(frmMenuTags);


        }

        private void TabCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabCtrl.SelectedTab == tabIndex)
            {
                frmQuoteEdit.Hide();
                frmQuoteEdit.ResetView();
                frmIndex.Show();
                frmIndex.ResetView();
            }
            else if (TabCtrl.SelectedTab == tabEvents)
            {
                frmEvents.ResetView();
            }
            else if (TabCtrl.SelectedTab == tabLocations)
            {
                frmLocations.ResetView();
            }
            else if (TabCtrl.SelectedTab == tabOptionItem)
            {
                frmOI.ResetView();
            }
            else if (TabCtrl.SelectedTab == tabCatering)
            {
                frmMenuTags.Hide();
                frmMenuTags.ResetView();
                frmMenus.Show();
                frmMenus.ResetView();
            }
        }
    }
}
