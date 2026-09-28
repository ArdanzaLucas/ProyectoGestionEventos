namespace ProyectoPresupuestoEvento
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            TabCtrl = new MaterialSkin.Controls.MaterialTabControl();
            tabIndex = new TabPage();
            panel4 = new Panel();
            pnlIndex = new Panel();
            tabEvents = new TabPage();
            pnlCntEvents = new Panel();
            tabUbications = new TabPage();
            pnlCntUbications = new Panel();
            tabOptionItem = new TabPage();
            pnlCntOpIts = new Panel();
            tabCatering = new TabPage();
            pnlCntCatering = new Panel();
            imageList1 = new ImageList(components);
            TabCtrl.SuspendLayout();
            tabIndex.SuspendLayout();
            panel4.SuspendLayout();
            tabEvents.SuspendLayout();
            tabUbications.SuspendLayout();
            tabOptionItem.SuspendLayout();
            tabCatering.SuspendLayout();
            SuspendLayout();
            // 
            // TabCtrl
            // 
            TabCtrl.Alignment = TabAlignment.Left;
            TabCtrl.Controls.Add(tabIndex);
            TabCtrl.Controls.Add(tabEvents);
            TabCtrl.Controls.Add(tabUbications);
            TabCtrl.Controls.Add(tabOptionItem);
            TabCtrl.Controls.Add(tabCatering);
            TabCtrl.Depth = 0;
            TabCtrl.Dock = DockStyle.Fill;
            TabCtrl.Location = new Point(3, 64);
            TabCtrl.MouseState = MaterialSkin.MouseState.HOVER;
            TabCtrl.Multiline = true;
            TabCtrl.Name = "TabCtrl";
            TabCtrl.SelectedIndex = 0;
            TabCtrl.Size = new Size(834, 608);
            TabCtrl.TabIndex = 0;
            // 
            // tabIndex
            // 
            tabIndex.Controls.Add(panel4);
            tabIndex.Location = new Point(27, 4);
            tabIndex.Name = "tabIndex";
            tabIndex.Padding = new Padding(3, 3, 3, 3);
            tabIndex.RightToLeft = RightToLeft.No;
            tabIndex.Size = new Size(803, 600);
            tabIndex.TabIndex = 0;
            tabIndex.Text = "Inicio";
            tabIndex.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(pnlIndex);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(797, 594);
            panel4.TabIndex = 0;
            // 
            // pnlIndex
            // 
            pnlIndex.Dock = DockStyle.Fill;
            pnlIndex.Location = new Point(0, 0);
            pnlIndex.Name = "pnlIndex";
            pnlIndex.Size = new Size(797, 594);
            pnlIndex.TabIndex = 0;
            // 
            // tabEvents
            // 
            tabEvents.Controls.Add(pnlCntEvents);
            tabEvents.Location = new Point(27, 4);
            tabEvents.Name = "tabEvents";
            tabEvents.Padding = new Padding(3, 3, 3, 3);
            tabEvents.Size = new Size(804, 600);
            tabEvents.TabIndex = 1;
            tabEvents.Text = "Eventos";
            tabEvents.UseVisualStyleBackColor = true;
            // 
            // pnlCntEvents
            // 
            pnlCntEvents.Dock = DockStyle.Fill;
            pnlCntEvents.Location = new Point(3, 3);
            pnlCntEvents.Name = "pnlCntEvents";
            pnlCntEvents.Size = new Size(798, 594);
            pnlCntEvents.TabIndex = 1;
            // 
            // tabUbications
            // 
            tabUbications.Controls.Add(pnlCntUbications);
            tabUbications.Location = new Point(27, 4);
            tabUbications.Name = "tabUbications";
            tabUbications.Padding = new Padding(3, 3, 3, 3);
            tabUbications.Size = new Size(804, 600);
            tabUbications.TabIndex = 2;
            tabUbications.Text = "Ubicaciones";
            tabUbications.UseVisualStyleBackColor = true;
            // 
            // pnlCntUbications
            // 
            pnlCntUbications.Dock = DockStyle.Fill;
            pnlCntUbications.Location = new Point(3, 3);
            pnlCntUbications.Name = "pnlCntUbications";
            pnlCntUbications.Size = new Size(798, 594);
            pnlCntUbications.TabIndex = 2;
            // 
            // tabOptionItem
            // 
            tabOptionItem.Controls.Add(pnlCntOpIts);
            tabOptionItem.Location = new Point(27, 4);
            tabOptionItem.Name = "tabOptionItem";
            tabOptionItem.Padding = new Padding(3, 3, 3, 3);
            tabOptionItem.Size = new Size(804, 600);
            tabOptionItem.TabIndex = 3;
            tabOptionItem.Text = "Servicios";
            tabOptionItem.UseVisualStyleBackColor = true;
            // 
            // pnlCntOpIts
            // 
            pnlCntOpIts.Dock = DockStyle.Fill;
            pnlCntOpIts.Location = new Point(3, 3);
            pnlCntOpIts.Name = "pnlCntOpIts";
            pnlCntOpIts.Size = new Size(798, 594);
            pnlCntOpIts.TabIndex = 2;
            // 
            // tabCatering
            // 
            tabCatering.Controls.Add(pnlCntCatering);
            tabCatering.Location = new Point(27, 4);
            tabCatering.Name = "tabCatering";
            tabCatering.Padding = new Padding(3, 3, 3, 3);
            tabCatering.Size = new Size(804, 600);
            tabCatering.TabIndex = 4;
            tabCatering.Text = "Catering";
            tabCatering.UseVisualStyleBackColor = true;
            // 
            // pnlCntCatering
            // 
            pnlCntCatering.Dock = DockStyle.Fill;
            pnlCntCatering.Location = new Point(3, 3);
            pnlCntCatering.Name = "pnlCntCatering";
            pnlCntCatering.Size = new Size(798, 594);
            pnlCntCatering.TabIndex = 2;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.Tag = "icons";
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "IconSave.png");
            imageList1.Images.SetKeyName(1, "IconRegistry.png");
            imageList1.Images.SetKeyName(2, "IconPin.png");
            imageList1.Images.SetKeyName(3, "IconHome.png");
            imageList1.Images.SetKeyName(4, "008-compartimiento.png");
            imageList1.Images.SetKeyName(5, "009-signo-de-mas.png");
            imageList1.Images.SetKeyName(6, "IconEdition.png");
            imageList1.Images.SetKeyName(7, "IconPrint.png");
            imageList1.Images.SetKeyName(8, "IconMenus.png");
            imageList1.Images.SetKeyName(9, "IconQuote.png");
            imageList1.Images.SetKeyName(10, "iconEvent.png");
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 675);
            Controls.Add(TabCtrl);
            DrawerIsOpen = true;
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = TabCtrl;
            MaximumSize = new Size(840, 675);
            MinimumSize = new Size(840, 675);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestion de Eventos";
            Load += FormMain_Load;
            TabCtrl.ResumeLayout(false);
            tabIndex.ResumeLayout(false);
            panel4.ResumeLayout(false);
            tabEvents.ResumeLayout(false);
            tabUbications.ResumeLayout(false);
            tabOptionItem.ResumeLayout(false);
            tabCatering.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl TabCtrl;
        private TabPage tabIndex;
        private TabPage tabEvents;
        private TabPage tabUbications;
        private TabPage tabOptionItem;
        private TabPage tabCatering;
        private Panel pnlCntEvents;
        private Panel panel4;
        private Panel pnlIndex;
        private ImageList imageList1;
        private Panel pnlCntUbications;
        private Panel pnlCntOpIts;
        private Panel pnlCntCatering;
    }
}
