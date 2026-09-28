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
        private OptionItemController optionItemsController;
        private QuoteController quoteController;
        private UbicationController ubicationController;

        public FormMain()
        {
            InitializeComponent();

            VisualHelper.setMaterialTheme(this);

            this.DrawerIsOpen = false;


            string[] iconos = { "IconQuote.png", "iconEvent.png", "IconPin.png", "IconRegistry.png", "IconMenus.png" };
            VisualHelper.EnlazarIconosSidebar(TabCtrl, imageList1, iconos);

            //controllers
            eventsController = new EventItemController();
            menuController= new MenuController();
            optionItemsController= new OptionItemController();
            quoteController = new QuoteController();
            ubicationController = new UbicationController();
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            //formularios
            //index
            FormIndex frmIndex = new FormIndex(eventsController);
            frmIndex.TopLevel = false;
            frmIndex.Dock = DockStyle.Fill;
            this.pnlIndex.Controls.Add(frmIndex);
            frmIndex.Show();
            //Eventos
            FormEvents frmEvents = new FormEvents(eventsController);
            frmEvents.TopLevel = false;
            frmEvents.Dock = DockStyle.Fill;
            this.pnlCntEvents.Controls.Add(frmEvents);
            frmEvents.Show();
            //Ubicaciones
            FormUbications frmUbications = new FormUbications(ubicationController);
            frmUbications.TopLevel = false;
            frmUbications.Dock = DockStyle.Fill;
            this.pnlCntUbications.Controls.Add(frmUbications);
            frmUbications.Show();
            //Servicios adicionales
            FormOptionItem frmOI = new FormOptionItem(optionItemsController);
            frmOI.TopLevel = false;
            frmOI.Dock = DockStyle.Fill;
            this.pnlCntOpIts.Controls.Add(frmOI);
            frmOI.Show();
            //menus de comida
            FormMenus frmMenus = new FormMenus(menuController);
            frmMenus.TopLevel = false;
            frmMenus.Dock = DockStyle.Fill;
            this.pnlCntCatering.Controls.Add(frmMenus);
            frmMenus.Show();


        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
