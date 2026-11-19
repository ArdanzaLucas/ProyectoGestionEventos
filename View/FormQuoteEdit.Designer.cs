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
            label1 = new MaterialSkin.Controls.MaterialLabel();
            label2 = new MaterialSkin.Controls.MaterialLabel();
            cmbQuoteEvent = new ComboBox();
            label3 = new MaterialSkin.Controls.MaterialLabel();
            cmbQuoteLocation = new ComboBox();
            label4 = new MaterialSkin.Controls.MaterialLabel();
            lblQuoteGuests = new MaterialSkin.Controls.MaterialLabel();
            label5 = new MaterialSkin.Controls.MaterialLabel();
            cmbQuoteMenu = new ComboBox();
            label6 = new MaterialSkin.Controls.MaterialLabel();
            cmbQuoteTag = new ComboBox();
            label7 = new MaterialSkin.Controls.MaterialLabel();
            nudQuoteAdults = new NumericUpDown();
            label8 = new MaterialSkin.Controls.MaterialLabel();
            nudQuoteChildren = new NumericUpDown();
            btnAddLine = new MaterialSkin.Controls.MaterialButton();
            lvQuoteLines = new ListView();
            LineMenuColumn = new ColumnHeader();
            LineTagColumn = new ColumnHeader();
            LineAdultsColumn = new ColumnHeader();
            LineChildrenColumn = new ColumnHeader();
            LineSubtotalColumn = new ColumnHeader();
            btnRemoveLine = new MaterialSkin.Controls.MaterialButton();
            label9 = new MaterialSkin.Controls.MaterialLabel();
            clbQuoteOptionItems = new CheckedListBox();
            label10 = new MaterialSkin.Controls.MaterialLabel();
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
            panelQuoteCU.Controls.Add(label1);
            panelQuoteCU.Controls.Add(label2);
            panelQuoteCU.Controls.Add(cmbQuoteEvent);
            panelQuoteCU.Controls.Add(label3);
            panelQuoteCU.Controls.Add(cmbQuoteLocation);
            panelQuoteCU.Controls.Add(label4);
            panelQuoteCU.Controls.Add(lblQuoteGuests);
            panelQuoteCU.Controls.Add(label5);
            panelQuoteCU.Controls.Add(cmbQuoteMenu);
            panelQuoteCU.Controls.Add(label6);
            panelQuoteCU.Controls.Add(cmbQuoteTag);
            panelQuoteCU.Controls.Add(label7);
            panelQuoteCU.Controls.Add(nudQuoteAdults);
            panelQuoteCU.Controls.Add(label8);
            panelQuoteCU.Controls.Add(nudQuoteChildren);
            panelQuoteCU.Controls.Add(btnAddLine);
            panelQuoteCU.Controls.Add(lvQuoteLines);
            panelQuoteCU.Controls.Add(btnRemoveLine);
            panelQuoteCU.Controls.Add(label9);
            panelQuoteCU.Controls.Add(clbQuoteOptionItems);
            panelQuoteCU.Controls.Add(label10);
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
            // label1
            //
            label1.AutoSize = true;
            label1.Depth = 0;
            label1.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            label1.MouseState = MaterialSkin.MouseState.HOVER;
            label1.Location = new Point(20, 12);
            label1.Name = "label1";
            label1.Size = new Size(210, 24);
            label1.TabIndex = 0;
            label1.Text = "Carga de presupuesto";
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Depth = 0;
            label2.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            label2.MouseState = MaterialSkin.MouseState.HOVER;
            label2.Location = new Point(20, 46);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 1;
            label2.Text = "Evento";
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
            // label3
            //
            label3.AutoSize = true;
            label3.Depth = 0;
            label3.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            label3.MouseState = MaterialSkin.MouseState.HOVER;
            label3.Location = new Point(290, 46);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 3;
            label3.Text = "Ubicacion";
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
            // label4
            //
            label4.AutoSize = true;
            label4.Depth = 0;
            label4.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            label4.MouseState = MaterialSkin.MouseState.HOVER;
            label4.Location = new Point(20, 105);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 5;
            label4.Text = "Catering";
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
            // label5
            //
            label5.AutoSize = true;
            label5.Depth = 0;
            label5.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            label5.MouseState = MaterialSkin.MouseState.HOVER;
            label5.Location = new Point(20, 124);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 6;
            label5.Text = "Menu";
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
            // label6
            //
            label6.AutoSize = true;
            label6.Depth = 0;
            label6.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            label6.MouseState = MaterialSkin.MouseState.HOVER;
            label6.Location = new Point(190, 124);
            label6.Name = "label6";
            label6.Size = new Size(50, 15);
            label6.TabIndex = 8;
            label6.Text = "Etiqueta";
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
            // label7
            //
            label7.AutoSize = true;
            label7.Depth = 0;
            label7.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            label7.MouseState = MaterialSkin.MouseState.HOVER;
            label7.Location = new Point(320, 124);
            label7.Name = "label7";
            label7.Size = new Size(48, 15);
            label7.TabIndex = 10;
            label7.Text = "Adultos";
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
            // label8
            //
            label8.AutoSize = true;
            label8.Depth = 0;
            label8.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            label8.MouseState = MaterialSkin.MouseState.HOVER;
            label8.Location = new Point(390, 124);
            label8.Name = "label8";
            label8.Size = new Size(37, 15);
            label8.TabIndex = 12;
            label8.Text = "Niños";
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
            // label9
            //
            label9.AutoSize = true;
            label9.Depth = 0;
            label9.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            label9.MouseState = MaterialSkin.MouseState.HOVER;
            label9.Location = new Point(20, 325);
            label9.Name = "label9";
            label9.Size = new Size(57, 15);
            label9.TabIndex = 17;
            label9.Text = "Servicios";
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
            // label10
            //
            label10.AutoSize = true;
            label10.Depth = 0;
            label10.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            label10.MouseState = MaterialSkin.MouseState.HOVER;
            label10.Location = new Point(300, 325);
            label10.Name = "label10";
            label10.Size = new Size(48, 15);
            label10.TabIndex = 19;
            label10.Text = "Totales";
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
            // btnGuardarQuote
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
            // btnVolverQuote
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
        private MaterialSkin.Controls.MaterialLabel label1;
        private MaterialSkin.Controls.MaterialLabel label2;
        private ComboBox cmbQuoteEvent;
        private MaterialSkin.Controls.MaterialLabel label3;
        private ComboBox cmbQuoteLocation;
        private MaterialSkin.Controls.MaterialLabel label4;
        private MaterialSkin.Controls.MaterialLabel lblQuoteGuests;
        private MaterialSkin.Controls.MaterialLabel label5;
        private ComboBox cmbQuoteMenu;
        private MaterialSkin.Controls.MaterialLabel label6;
        private ComboBox cmbQuoteTag;
        private MaterialSkin.Controls.MaterialLabel label7;
        private NumericUpDown nudQuoteAdults;
        private MaterialSkin.Controls.MaterialLabel label8;
        private NumericUpDown nudQuoteChildren;
        private MaterialSkin.Controls.MaterialButton btnAddLine;
        private ListView lvQuoteLines;
        private ColumnHeader LineMenuColumn;
        private ColumnHeader LineTagColumn;
        private ColumnHeader LineAdultsColumn;
        private ColumnHeader LineChildrenColumn;
        private ColumnHeader LineSubtotalColumn;
        private MaterialSkin.Controls.MaterialButton btnRemoveLine;
        private MaterialSkin.Controls.MaterialLabel label9;
        private CheckedListBox clbQuoteOptionItems;
        private MaterialSkin.Controls.MaterialLabel label10;
        private MaterialSkin.Controls.MaterialLabel lblTotalLocation;
        private MaterialSkin.Controls.MaterialLabel lblTotalMenus;
        private MaterialSkin.Controls.MaterialLabel lblTotalOptionItems;
        private MaterialSkin.Controls.MaterialLabel lblTotal;
        private MaterialSkin.Controls.MaterialButton btnSaveQuote;
        private MaterialSkin.Controls.MaterialButton btnBackQuote;
    }
}
