namespace ProyectoPresupuestoEvento.View
{
    partial class FormQuoteEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelQuoteCU = new Panel();
            lblQuoteFormTitle = new MaterialSkin.Controls.MaterialLabel();
            lblQuoteEvent = new MaterialSkin.Controls.MaterialLabel();
            cmbQuoteEvent = new ComboBox();
            lblQuoteLocation = new MaterialSkin.Controls.MaterialLabel();
            cmbQuoteLocation = new ComboBox();
            lblQuoteCatering = new MaterialSkin.Controls.MaterialLabel();
            lblQuoteGuests = new MaterialSkin.Controls.MaterialLabel();
            lblQuoteMenu = new MaterialSkin.Controls.MaterialLabel();
            cmbQuoteMenu = new ComboBox();
            lblQuoteTag = new MaterialSkin.Controls.MaterialLabel();
            cmbQuoteTag = new ComboBox();
            lblQuoteAdults = new MaterialSkin.Controls.MaterialLabel();
            nudQuoteAdults = new NumericUpDown();
            lblQuoteChildren = new MaterialSkin.Controls.MaterialLabel();
            nudQuoteChildren = new NumericUpDown();
            btnAddLine = new MaterialSkin.Controls.MaterialButton();
            lvQuoteLines = new ListView();
            LineMenuColumn = new ColumnHeader();
            LineTagColumn = new ColumnHeader();
            LineAdultsColumn = new ColumnHeader();
            LineChildrenColumn = new ColumnHeader();
            LineSubtotalColumn = new ColumnHeader();
            btnRemoveLine = new MaterialSkin.Controls.MaterialButton();
            lblQuoteOptionItems = new MaterialSkin.Controls.MaterialLabel();
            clbQuoteOptionItems = new CheckedListBox();
            lblQuoteTotals = new MaterialSkin.Controls.MaterialLabel();
            lblTotalLocation = new MaterialSkin.Controls.MaterialLabel();
            lblTotalMenus = new MaterialSkin.Controls.MaterialLabel();
            lblTotalOptionItems = new MaterialSkin.Controls.MaterialLabel();
            lblTotal = new MaterialSkin.Controls.MaterialLabel();
            btnSaveQuote = new MaterialSkin.Controls.MaterialButton();
            btnBackQuote = new MaterialSkin.Controls.MaterialButton();
            panelQuoteCU.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuoteAdults).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudQuoteChildren).BeginInit();
            SuspendLayout();
            //
            // panelQuoteCU
            //
            panelQuoteCU.Controls.Add(lblQuoteFormTitle);
            panelQuoteCU.Controls.Add(lblQuoteEvent);
            panelQuoteCU.Controls.Add(cmbQuoteEvent);
            panelQuoteCU.Controls.Add(lblQuoteLocation);
            panelQuoteCU.Controls.Add(cmbQuoteLocation);
            panelQuoteCU.Controls.Add(lblQuoteCatering);
            panelQuoteCU.Controls.Add(lblQuoteGuests);
            panelQuoteCU.Controls.Add(lblQuoteMenu);
            panelQuoteCU.Controls.Add(cmbQuoteMenu);
            panelQuoteCU.Controls.Add(lblQuoteTag);
            panelQuoteCU.Controls.Add(cmbQuoteTag);
            panelQuoteCU.Controls.Add(lblQuoteAdults);
            panelQuoteCU.Controls.Add(nudQuoteAdults);
            panelQuoteCU.Controls.Add(lblQuoteChildren);
            panelQuoteCU.Controls.Add(nudQuoteChildren);
            panelQuoteCU.Controls.Add(btnAddLine);
            panelQuoteCU.Controls.Add(lvQuoteLines);
            panelQuoteCU.Controls.Add(btnRemoveLine);
            panelQuoteCU.Controls.Add(lblQuoteOptionItems);
            panelQuoteCU.Controls.Add(clbQuoteOptionItems);
            panelQuoteCU.Controls.Add(lblQuoteTotals);
            panelQuoteCU.Controls.Add(lblTotalLocation);
            panelQuoteCU.Controls.Add(lblTotalMenus);
            panelQuoteCU.Controls.Add(lblTotalOptionItems);
            panelQuoteCU.Controls.Add(lblTotal);
            panelQuoteCU.Controls.Add(btnSaveQuote);
            panelQuoteCU.Controls.Add(btnBackQuote);
            panelQuoteCU.Name = "panelQuoteCU";
            panelQuoteCU.Dock = DockStyle.Fill;
            panelQuoteCU.Location = new Point(0, 0);
            panelQuoteCU.Size = new Size(640, 720);
            panelQuoteCU.TabIndex = 1;
            //
            // lblQuoteFormTitle
            //
            lblQuoteFormTitle.AutoSize = true;
            lblQuoteFormTitle.Depth = 0;
            lblQuoteFormTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblQuoteFormTitle.MouseState = MaterialSkin.MouseState.HOVER;
            lblQuoteFormTitle.Location = new Point(20, 12);
            lblQuoteFormTitle.Name = "lblQuoteFormTitle";
            lblQuoteFormTitle.Size = new Size(210, 24);
            lblQuoteFormTitle.TabIndex = 0;
            lblQuoteFormTitle.Text = "Carga de presupuesto";
            //
            // lblQuoteEvent
            //
            lblQuoteEvent.AutoSize = true;
            lblQuoteEvent.Depth = 0;
            lblQuoteEvent.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            lblQuoteEvent.MouseState = MaterialSkin.MouseState.HOVER;
            lblQuoteEvent.Location = new Point(20, 46);
            lblQuoteEvent.Name = "lblQuoteEvent";
            lblQuoteEvent.Size = new Size(43, 15);
            lblQuoteEvent.TabIndex = 1;
            lblQuoteEvent.Text = "Evento";
            //
            // cmbQuoteEvent
            //
            cmbQuoteEvent.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbQuoteEvent.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbQuoteEvent.Location = new Point(20, 68);
            cmbQuoteEvent.Name = "cmbQuoteEvent";
            cmbQuoteEvent.Size = new Size(250, 23);
            cmbQuoteEvent.TabIndex = 2;
            cmbQuoteEvent.SelectedIndexChanged += cmbQuoteEvent_SelectedIndexChanged;
            //
            // lblQuoteLocation
            //
            lblQuoteLocation.AutoSize = true;
            lblQuoteLocation.Depth = 0;
            lblQuoteLocation.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            lblQuoteLocation.MouseState = MaterialSkin.MouseState.HOVER;
            lblQuoteLocation.Location = new Point(290, 46);
            lblQuoteLocation.Name = "lblQuoteLocation";
            lblQuoteLocation.Size = new Size(59, 15);
            lblQuoteLocation.TabIndex = 3;
            lblQuoteLocation.Text = "Ubicacion";
            //
            // cmbQuoteLocation
            //
            cmbQuoteLocation.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbQuoteLocation.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbQuoteLocation.Location = new Point(290, 68);
            cmbQuoteLocation.Name = "cmbQuoteLocation";
            cmbQuoteLocation.Size = new Size(220, 23);
            cmbQuoteLocation.TabIndex = 4;
            cmbQuoteLocation.SelectedIndexChanged += cmbQuoteLocation_SelectedIndexChanged;
            //
            // lblQuoteCatering
            //
            lblQuoteCatering.AutoSize = true;
            lblQuoteCatering.Depth = 0;
            lblQuoteCatering.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            lblQuoteCatering.MouseState = MaterialSkin.MouseState.HOVER;
            lblQuoteCatering.Location = new Point(20, 105);
            lblQuoteCatering.Name = "lblQuoteCatering";
            lblQuoteCatering.Size = new Size(53, 15);
            lblQuoteCatering.TabIndex = 5;
            lblQuoteCatering.Text = "Catering";
            // 
            // lblQuoteGuests
            // 
            lblQuoteGuests.AutoSize = true;
            lblQuoteGuests.Depth = 0;
            lblQuoteGuests.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            lblQuoteGuests.HighEmphasis = false;
            lblQuoteGuests.MouseState = MaterialSkin.MouseState.HOVER;
            lblQuoteGuests.Location = new Point(100, 105);
            lblQuoteGuests.Name = "lblQuoteGuests";
            lblQuoteGuests.Size = new Size(150, 15);
            lblQuoteGuests.TabIndex = 26;
            lblQuoteGuests.Text = "Invitados del evento: -";
            //
            // lblQuoteMenu
            //
            lblQuoteMenu.AutoSize = true;
            lblQuoteMenu.Depth = 0;
            lblQuoteMenu.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            lblQuoteMenu.MouseState = MaterialSkin.MouseState.HOVER;
            lblQuoteMenu.Location = new Point(20, 124);
            lblQuoteMenu.Name = "lblQuoteMenu";
            lblQuoteMenu.Size = new Size(38, 15);
            lblQuoteMenu.TabIndex = 6;
            lblQuoteMenu.Text = "Menu";
            //
            // cmbQuoteMenu
            //
            cmbQuoteMenu.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbQuoteMenu.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbQuoteMenu.Location = new Point(20, 146);
            cmbQuoteMenu.Name = "cmbQuoteMenu";
            cmbQuoteMenu.Size = new Size(160, 23);
            cmbQuoteMenu.TabIndex = 7;
            cmbQuoteMenu.SelectedIndexChanged += cmbQuoteMenu_SelectedIndexChanged;
            //
            // lblQuoteTag
            //
            lblQuoteTag.AutoSize = true;
            lblQuoteTag.Depth = 0;
            lblQuoteTag.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            lblQuoteTag.MouseState = MaterialSkin.MouseState.HOVER;
            lblQuoteTag.Location = new Point(190, 124);
            lblQuoteTag.Name = "lblQuoteTag";
            lblQuoteTag.Size = new Size(50, 15);
            lblQuoteTag.TabIndex = 8;
            lblQuoteTag.Text = "Etiqueta";
            //
            // cmbQuoteTag
            //
            cmbQuoteTag.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbQuoteTag.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbQuoteTag.Location = new Point(190, 146);
            cmbQuoteTag.Name = "cmbQuoteTag";
            cmbQuoteTag.Size = new Size(120, 23);
            cmbQuoteTag.TabIndex = 9;
            //
            // lblQuoteAdults
            //
            lblQuoteAdults.AutoSize = true;
            lblQuoteAdults.Depth = 0;
            lblQuoteAdults.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            lblQuoteAdults.MouseState = MaterialSkin.MouseState.HOVER;
            lblQuoteAdults.Location = new Point(320, 124);
            lblQuoteAdults.Name = "lblQuoteAdults";
            lblQuoteAdults.Size = new Size(48, 15);
            lblQuoteAdults.TabIndex = 10;
            lblQuoteAdults.Text = "Adultos";
            //
            // nudQuoteAdults
            //
            nudQuoteAdults.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudQuoteAdults.Location = new Point(320, 146);
            nudQuoteAdults.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudQuoteAdults.Name = "nudQuoteAdults";
            nudQuoteAdults.Size = new Size(60, 23);
            nudQuoteAdults.TabIndex = 11;
            //
            // lblQuoteChildren
            //
            lblQuoteChildren.AutoSize = true;
            lblQuoteChildren.Depth = 0;
            lblQuoteChildren.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            lblQuoteChildren.MouseState = MaterialSkin.MouseState.HOVER;
            lblQuoteChildren.Location = new Point(390, 124);
            lblQuoteChildren.Name = "lblQuoteChildren";
            lblQuoteChildren.Size = new Size(37, 15);
            lblQuoteChildren.TabIndex = 12;
            lblQuoteChildren.Text = "Niños";
            //
            // nudQuoteChildren
            //
            nudQuoteChildren.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudQuoteChildren.Location = new Point(390, 146);
            nudQuoteChildren.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudQuoteChildren.Name = "nudQuoteChildren";
            nudQuoteChildren.Size = new Size(60, 23);
            nudQuoteChildren.TabIndex = 13;
            //
            // btnAddLine
            //
            btnAddLine.AutoSize = false;
            btnAddLine.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddLine.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            btnAddLine.Depth = 0;
            btnAddLine.HighEmphasis = true;
            btnAddLine.Icon = null;
            btnAddLine.Location = new Point(465, 140);
            btnAddLine.Margin = new Padding(4, 6, 4, 6);
            btnAddLine.MouseState = MaterialSkin.MouseState.HOVER;
            btnAddLine.Name = "btnAddLine";
            btnAddLine.NoAccentTextColor = Color.Empty;
            btnAddLine.Size = new Size(90, 32);
            btnAddLine.TabIndex = 14;
            btnAddLine.Text = "Agregar";
            btnAddLine.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAddLine.UseAccentColor = false;
            btnAddLine.UseVisualStyleBackColor = true;
            btnAddLine.Click += btnAddLine_Click;
            //
            // lvQuoteLines
            //
            lvQuoteLines.Columns.AddRange(new ColumnHeader[] { LineMenuColumn, LineTagColumn, LineAdultsColumn, LineChildrenColumn, LineSubtotalColumn });
            lvQuoteLines.FullRowSelect = true;
            lvQuoteLines.GridLines = true;
            lvQuoteLines.Location = new Point(20, 185);
            lvQuoteLines.MultiSelect = false;
            lvQuoteLines.Name = "lvQuoteLines";
            lvQuoteLines.Size = new Size(535, 125);
            lvQuoteLines.TabIndex = 15;
            lvQuoteLines.UseCompatibleStateImageBehavior = false;
            lvQuoteLines.View = System.Windows.Forms.View.Details;
            //
            // LineMenuColumn
            //
            LineMenuColumn.Text = "Menu";
            LineMenuColumn.Width = 150;
            //
            // LineTagColumn
            //
            LineTagColumn.Text = "Etiqueta";
            LineTagColumn.Width = 110;
            //
            // LineAdultsColumn
            //
            LineAdultsColumn.Text = "Adultos";
            LineAdultsColumn.Width = 70;
            //
            // LineChildrenColumn
            //
            LineChildrenColumn.Text = "Niños";
            LineChildrenColumn.Width = 70;
            //
            // LineSubtotalColumn
            //
            LineSubtotalColumn.Text = "Subtotal";
            LineSubtotalColumn.Width = 110;
            //
            // btnRemoveLine
            //
            btnRemoveLine.AutoSize = false;
            btnRemoveLine.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRemoveLine.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            btnRemoveLine.Depth = 0;
            btnRemoveLine.HighEmphasis = true;
            btnRemoveLine.Icon = null;
            btnRemoveLine.Location = new Point(565, 185);
            btnRemoveLine.Margin = new Padding(4, 6, 4, 6);
            btnRemoveLine.MouseState = MaterialSkin.MouseState.HOVER;
            btnRemoveLine.Name = "btnRemoveLine";
            btnRemoveLine.NoAccentTextColor = Color.Empty;
            btnRemoveLine.Size = new Size(110, 32);
            btnRemoveLine.TabIndex = 16;
            btnRemoveLine.Text = "Quitar linea";
            btnRemoveLine.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnRemoveLine.UseAccentColor = false;
            btnRemoveLine.UseVisualStyleBackColor = true;
            btnRemoveLine.Click += btnRemoveLine_Click;
            //
            // lblQuoteOptionItems
            //
            lblQuoteOptionItems.AutoSize = true;
            lblQuoteOptionItems.Depth = 0;
            lblQuoteOptionItems.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            lblQuoteOptionItems.MouseState = MaterialSkin.MouseState.HOVER;
            lblQuoteOptionItems.Location = new Point(20, 325);
            lblQuoteOptionItems.Name = "lblQuoteOptionItems";
            lblQuoteOptionItems.Size = new Size(57, 15);
            lblQuoteOptionItems.TabIndex = 17;
            lblQuoteOptionItems.Text = "Servicios";
            //
            // clbQuoteOptionItems
            //
            clbQuoteOptionItems.CheckOnClick = true;
            clbQuoteOptionItems.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clbQuoteOptionItems.Location = new Point(20, 345);
            clbQuoteOptionItems.Name = "clbQuoteOptionItems";
            clbQuoteOptionItems.Size = new Size(250, 112);
            clbQuoteOptionItems.TabIndex = 18;
            clbQuoteOptionItems.ItemCheck += clbQuoteOptionItems_ItemCheck;
            //
            // lblQuoteTotals
            //
            lblQuoteTotals.AutoSize = true;
            lblQuoteTotals.Depth = 0;
            lblQuoteTotals.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            lblQuoteTotals.MouseState = MaterialSkin.MouseState.HOVER;
            lblQuoteTotals.Location = new Point(300, 325);
            lblQuoteTotals.Name = "lblQuoteTotals";
            lblQuoteTotals.Size = new Size(48, 15);
            lblQuoteTotals.TabIndex = 19;
            lblQuoteTotals.Text = "Totales";
            //
            // lblTotalLocation
            //
            lblTotalLocation.AutoSize = true;
            lblTotalLocation.Depth = 0;
            lblTotalLocation.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            lblTotalLocation.MouseState = MaterialSkin.MouseState.HOVER;
            lblTotalLocation.Location = new Point(300, 348);
            lblTotalLocation.Name = "lblTotalLocation";
            lblTotalLocation.Size = new Size(70, 15);
            lblTotalLocation.TabIndex = 20;
            lblTotalLocation.Text = "Ubicacion: -";
            //
            // lblTotalMenus
            //
            lblTotalMenus.AutoSize = true;
            lblTotalMenus.Depth = 0;
            lblTotalMenus.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            lblTotalMenus.MouseState = MaterialSkin.MouseState.HOVER;
            lblTotalMenus.Location = new Point(300, 372);
            lblTotalMenus.Name = "lblTotalMenus";
            lblTotalMenus.Size = new Size(65, 15);
            lblTotalMenus.TabIndex = 21;
            lblTotalMenus.Text = "Catering: -";
            //
            // lblTotalOptionItems
            //
            lblTotalOptionItems.AutoSize = true;
            lblTotalOptionItems.Depth = 0;
            lblTotalOptionItems.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            lblTotalOptionItems.MouseState = MaterialSkin.MouseState.HOVER;
            lblTotalOptionItems.Location = new Point(300, 396);
            lblTotalOptionItems.Name = "lblTotalOptionItems";
            lblTotalOptionItems.Size = new Size(65, 15);
            lblTotalOptionItems.TabIndex = 22;
            lblTotalOptionItems.Text = "Servicios: -";
            //
            // lblTotal
            //
            lblTotal.AutoSize = true;
            lblTotal.Depth = 0;
            lblTotal.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblTotal.MouseState = MaterialSkin.MouseState.HOVER;
            lblTotal.Location = new Point(300, 425);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(70, 21);
            lblTotal.TabIndex = 23;
            lblTotal.Text = "Total: -";
            //
            // btnSaveQuote
            //
            btnSaveQuote.AutoSize = false;
            btnSaveQuote.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSaveQuote.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSaveQuote.Depth = 0;
            btnSaveQuote.HighEmphasis = true;
            btnSaveQuote.Icon = null;
            btnSaveQuote.Location = new Point(150, 480);
            btnSaveQuote.Margin = new Padding(4, 6, 4, 6);
            btnSaveQuote.MouseState = MaterialSkin.MouseState.HOVER;
            btnSaveQuote.Name = "btnSaveQuote";
            btnSaveQuote.NoAccentTextColor = Color.Empty;
            btnSaveQuote.Size = new Size(90, 36);
            btnSaveQuote.TabIndex = 24;
            btnSaveQuote.Text = "Guardar";
            btnSaveQuote.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSaveQuote.UseAccentColor = false;
            btnSaveQuote.UseVisualStyleBackColor = true;
            btnSaveQuote.Click += btnSaveQuote_Click;
            //
            // btnBackQuote
            //
            btnBackQuote.AutoSize = false;
            btnBackQuote.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBackQuote.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBackQuote.Depth = 0;
            btnBackQuote.HighEmphasis = true;
            btnBackQuote.Icon = null;
            btnBackQuote.Location = new Point(350, 480);
            btnBackQuote.Margin = new Padding(4, 6, 4, 6);
            btnBackQuote.MouseState = MaterialSkin.MouseState.HOVER;
            btnBackQuote.Name = "btnBackQuote";
            btnBackQuote.NoAccentTextColor = Color.Empty;
            btnBackQuote.Size = new Size(90, 36);
            btnBackQuote.TabIndex = 25;
            btnBackQuote.Text = "Volver";
            btnBackQuote.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnBackQuote.UseAccentColor = false;
            btnBackQuote.UseVisualStyleBackColor = true;
            btnBackQuote.Click += btnBackQuote_Click;
            //
            // FormQuoteEdit
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 720);
            Controls.Add(panelQuoteCU);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormQuoteEdit";
            Text = "FormQuoteEdit";
            panelQuoteCU.ResumeLayout(false);
            panelQuoteCU.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuoteAdults).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudQuoteChildren).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelQuoteCU;
        private MaterialSkin.Controls.MaterialLabel lblQuoteFormTitle;
        private MaterialSkin.Controls.MaterialLabel lblQuoteEvent;
        private ComboBox cmbQuoteEvent;
        private MaterialSkin.Controls.MaterialLabel lblQuoteLocation;
        private ComboBox cmbQuoteLocation;
        private MaterialSkin.Controls.MaterialLabel lblQuoteCatering;
        private MaterialSkin.Controls.MaterialLabel lblQuoteGuests;
        private MaterialSkin.Controls.MaterialLabel lblQuoteMenu;
        private ComboBox cmbQuoteMenu;
        private MaterialSkin.Controls.MaterialLabel lblQuoteTag;
        private ComboBox cmbQuoteTag;
        private MaterialSkin.Controls.MaterialLabel lblQuoteAdults;
        private NumericUpDown nudQuoteAdults;
        private MaterialSkin.Controls.MaterialLabel lblQuoteChildren;
        private NumericUpDown nudQuoteChildren;
        private MaterialSkin.Controls.MaterialButton btnAddLine;
        private ListView lvQuoteLines;
        private ColumnHeader LineMenuColumn;
        private ColumnHeader LineTagColumn;
        private ColumnHeader LineAdultsColumn;
        private ColumnHeader LineChildrenColumn;
        private ColumnHeader LineSubtotalColumn;
        private MaterialSkin.Controls.MaterialButton btnRemoveLine;
        private MaterialSkin.Controls.MaterialLabel lblQuoteOptionItems;
        private CheckedListBox clbQuoteOptionItems;
        private MaterialSkin.Controls.MaterialLabel lblQuoteTotals;
        private MaterialSkin.Controls.MaterialLabel lblTotalLocation;
        private MaterialSkin.Controls.MaterialLabel lblTotalMenus;
        private MaterialSkin.Controls.MaterialLabel lblTotalOptionItems;
        private MaterialSkin.Controls.MaterialLabel lblTotal;
        private MaterialSkin.Controls.MaterialButton btnSaveQuote;
        private MaterialSkin.Controls.MaterialButton btnBackQuote;
    }
}
