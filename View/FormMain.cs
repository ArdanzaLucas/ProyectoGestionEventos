using MaterialSkin.Controls;
using ProyectoPresupuestoEvento.Controller;

namespace ProyectoPresupuestoEvento.View
{
    public partial class FormMain : MaterialForm
    {
        private EventItemController eventController;
        private MenuController menuController;
        private MenuTagController menuTagController;
        private OptionItemController optionItemController;
        private QuoteController quoteController;
        private LocationController locationController;

        private FormIndex frmIndex;
        private FormQuoteEdit frmQuoteEdit;
        private FormEvents frmEvents;
        private FormLocations frmLocations;
        private FormOptionItem frmOptionItems;
        private FormMenus frmMenus;
        private FormMenuTags frmMenuTags;

        public FormMain()
        {
            InitializeComponent();

            VisualHelper.SetMaterialTheme();

            this.DrawerIsOpen = false;


            string[] icons = { "IconQuote.png", "IconEvent.png", "IconPin.png", "IconRegistry.png", "IconMenus.png" };
            VisualHelper.LinkSidebarIcons(TabCtrl, imageListIcons, icons);

            eventController = new EventItemController();
            menuController = new MenuController();
            menuTagController = new MenuTagController();
            optionItemController = new OptionItemController();
            quoteController = new QuoteController();
            locationController = new LocationController();
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            frmIndex = new FormIndex(quoteController, eventController);
            EmbedForm(frmIndex, pnlIndex);
            frmIndex.Show();

            frmQuoteEdit = new FormQuoteEdit(quoteController, eventController, locationController, menuController, optionItemController);
            EmbedForm(frmQuoteEdit, pnlIndex);
            frmQuoteEdit.SetFormIndex(frmIndex);
            frmIndex.SetFormQuoteEdit(frmQuoteEdit);

            frmEvents = new FormEvents(eventController);
            EmbedForm(frmEvents, pnlCntEvents);
            frmEvents.Show();

            frmLocations = new FormLocations(locationController);
            EmbedForm(frmLocations, pnlCntLocations);
            frmLocations.Show();

            frmOptionItems = new FormOptionItem(optionItemController);
            EmbedForm(frmOptionItems, pnlCntOptionItems);
            frmOptionItems.Show();

            frmMenus = new FormMenus(menuController, menuTagController);
            EmbedForm(frmMenus, pnlCntCatering);
            frmMenus.Show();

            frmMenuTags = new FormMenuTags(menuTagController, frmMenus);
            EmbedForm(frmMenuTags, pnlCntCatering);
            frmMenus.SetFormMenuTags(frmMenuTags);
        }

        private void EmbedForm(Form form, Control container)
        {
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            container.Controls.Add(form);
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
                frmOptionItems.ResetView();
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
