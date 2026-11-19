namespace ProyectoPresupuestoEvento.View
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
            pnlIndexContainer = new Panel();
            pnlIndex = new Panel();
            tabEvents = new TabPage();
            pnlCntEvents = new Panel();
            tabLocations = new TabPage();
            pnlCntLocations = new Panel();
            tabOptionItem = new TabPage();
            pnlCntOptionItems = new Panel();
            tabCatering = new TabPage();
            pnlCntCatering = new Panel();
            imageListIcons = new ImageList(components);
            TabCtrl.SuspendLayout();
            tabIndex.SuspendLayout();
            pnlIndexContainer.SuspendLayout();
            tabEvents.SuspendLayout();
            tabLocations.SuspendLayout();
            tabOptionItem.SuspendLayout();
            tabCatering.SuspendLayout();
            SuspendLayout();
            // 
            // TabCtrl
            // 
            TabCtrl.Alignment = TabAlignment.Left;
            TabCtrl.Controls.Add(tabIndex);
            TabCtrl.Controls.Add(tabEvents);
            TabCtrl.Controls.Add(tabLocations);
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
            TabCtrl.SelectedIndexChanged += TabCtrl_SelectedIndexChanged;
            // 
            // tabIndex
            // 
            tabIndex.Controls.Add(pnlIndexContainer);
            tabIndex.Location = new Point(27, 4);
            tabIndex.Name = "tabIndex";
            tabIndex.Padding = new Padding(3);
            tabIndex.RightToLeft = RightToLeft.No;
            tabIndex.Size = new Size(803, 600);
            tabIndex.TabIndex = 0;
            tabIndex.Text = "Inicio";
            tabIndex.UseVisualStyleBackColor = true;
            // 
            // pnlIndexContainer
            // 
            pnlIndexContainer.Controls.Add(pnlIndex);
            pnlIndexContainer.Dock = DockStyle.Fill;
            pnlIndexContainer.Location = new Point(3, 3);
            pnlIndexContainer.Name = "pnlIndexContainer";
            pnlIndexContainer.Size = new Size(797, 594);
            pnlIndexContainer.TabIndex = 0;
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
            tabEvents.Padding = new Padding(3);
            tabEvents.Size = new Size(803, 600);
            tabEvents.TabIndex = 1;
            tabEvents.Text = "Eventos";
            tabEvents.UseVisualStyleBackColor = true;
            // 
            // pnlCntEvents
            // 
            pnlCntEvents.Dock = DockStyle.Fill;
            pnlCntEvents.Location = new Point(3, 3);
            pnlCntEvents.Name = "pnlCntEvents";
            pnlCntEvents.Size = new Size(797, 594);
            pnlCntEvents.TabIndex = 1;
            // 
            // tabLocations
            // 
            tabLocations.Controls.Add(pnlCntLocations);
            tabLocations.Location = new Point(27, 4);
            tabLocations.Name = "tabLocations";
            tabLocations.Padding = new Padding(3);
            tabLocations.Size = new Size(803, 600);
            tabLocations.TabIndex = 2;
            tabLocations.Text = "Ubicaciones";
            tabLocations.UseVisualStyleBackColor = true;
            // 
            // pnlCntLocations
            // 
            pnlCntLocations.Dock = DockStyle.Fill;
            pnlCntLocations.Location = new Point(3, 3);
            pnlCntLocations.Name = "pnlCntLocations";
            pnlCntLocations.Size = new Size(797, 594);
            pnlCntLocations.TabIndex = 2;
            // 
            // tabOptionItem
            // 
            tabOptionItem.Controls.Add(pnlCntOptionItems);
            tabOptionItem.Location = new Point(27, 4);
            tabOptionItem.Name = "tabOptionItem";
            tabOptionItem.Padding = new Padding(3);
            tabOptionItem.Size = new Size(803, 600);
            tabOptionItem.TabIndex = 3;
            tabOptionItem.Text = "Servicios";
            tabOptionItem.UseVisualStyleBackColor = true;
            // 
            // pnlCntOptionItems
            // 
            pnlCntOptionItems.Dock = DockStyle.Fill;
            pnlCntOptionItems.Location = new Point(3, 3);
            pnlCntOptionItems.Name = "pnlCntOptionItems";
            pnlCntOptionItems.Size = new Size(797, 594);
            pnlCntOptionItems.TabIndex = 2;
            // 
            // tabCatering
            // 
            tabCatering.Controls.Add(pnlCntCatering);
            tabCatering.Location = new Point(27, 4);
            tabCatering.Name = "tabCatering";
            tabCatering.Padding = new Padding(3);
            tabCatering.Size = new Size(803, 600);
            tabCatering.TabIndex = 4;
            tabCatering.Text = "Catering";
            tabCatering.UseVisualStyleBackColor = true;
            // 
            // pnlCntCatering
            // 
            pnlCntCatering.Dock = DockStyle.Fill;
            pnlCntCatering.Location = new Point(3, 3);
            pnlCntCatering.Name = "pnlCntCatering";
            pnlCntCatering.Size = new Size(797, 594);
            pnlCntCatering.TabIndex = 2;
            // 
            // imageListIcons
            // 
            imageListIcons.ColorDepth = ColorDepth.Depth32Bit;
            imageListIcons.ImageStream = (ImageListStreamer)resources.GetObject("imageListIcons.ImageStream");
            imageListIcons.Tag = "icons";
            imageListIcons.TransparentColor = Color.Transparent;
            imageListIcons.Images.SetKeyName(0, "IconRegistry.png");
            imageListIcons.Images.SetKeyName(1, "IconPin.png");
            imageListIcons.Images.SetKeyName(2, "IconMenus.png");
            imageListIcons.Images.SetKeyName(3, "IconQuote.png");
            imageListIcons.Images.SetKeyName(4, "IconEvent.png");
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
            MinimumSize = new Size(840, 675);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestion de Eventos";
            Load += FormMain_Load;
            TabCtrl.ResumeLayout(false);
            tabIndex.ResumeLayout(false);
            pnlIndexContainer.ResumeLayout(false);
            tabEvents.ResumeLayout(false);
            tabLocations.ResumeLayout(false);
            tabOptionItem.ResumeLayout(false);
            tabCatering.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl TabCtrl;
        private TabPage tabIndex;
        private TabPage tabEvents;
        private TabPage tabLocations;
        private TabPage tabOptionItem;
        private TabPage tabCatering;
        private Panel pnlCntEvents;
        private Panel pnlIndexContainer;
        private Panel pnlIndex;
        private ImageList imageListIcons;
        private Panel pnlCntLocations;
        private Panel pnlCntOptionItems;
        private Panel pnlCntCatering;
    }
}
