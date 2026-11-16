namespace ProyectoPresupuestoEvento.View
{
    partial class FormIndex
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
            panelIndexList = new Panel();
            panelIndexTitle = new Panel();
            lblIndexTitle = new MaterialSkin.Controls.MaterialLabel();
            mtLvIndex = new MaterialSkin.Controls.MaterialListView();
            NumberColumn = new ColumnHeader();
            EventColumn = new ColumnHeader();
            DateColumn = new ColumnHeader();
            UbicationColumn = new ColumnHeader();
            GuestsColumn = new ColumnHeader();
            StateColumn = new ColumnHeader();
            TotalColumn = new ColumnHeader();
            panelIndexFilter = new Panel();
            lblFilterEvent = new MaterialSkin.Controls.MaterialLabel();
            cmbFilterEvent = new ComboBox();
            panelCrudCtrlIndex = new Panel();
            btnQuoteCreate = new MaterialSkin.Controls.MaterialButton();
            btnQuoteEdit = new MaterialSkin.Controls.MaterialButton();
            btnQuoteAccept = new MaterialSkin.Controls.MaterialButton();
            btnQuoteCancel = new MaterialSkin.Controls.MaterialButton();
            btnQuoteClone = new MaterialSkin.Controls.MaterialButton();
            btnQuoteRemove = new MaterialSkin.Controls.MaterialButton();
            btnIndexReport = new MaterialSkin.Controls.MaterialButton();
            panelQuoteCU = new Panel();
            label1 = new MaterialSkin.Controls.MaterialLabel();
            label2 = new MaterialSkin.Controls.MaterialLabel();
            cmbQuoteEvent = new ComboBox();
            label3 = new MaterialSkin.Controls.MaterialLabel();
            cmbQuoteUbication = new ComboBox();
            label4 = new MaterialSkin.Controls.MaterialLabel();
            lblQuoteGuests = new MaterialSkin.Controls.MaterialLabel();
            label5 = new MaterialSkin.Controls.MaterialLabel();
            cmbQuoteMenu = new ComboBox();
            label6 = new MaterialSkin.Controls.MaterialLabel();
            cmbQuoteTag = new ComboBox();
            label7 = new MaterialSkin.Controls.MaterialLabel();
            nudQuoteAdults = new NumericUpDown();
            label8 = new MaterialSkin.Controls.MaterialLabel();
            nudQuoteChilds = new NumericUpDown();
            btnAddLine = new MaterialSkin.Controls.MaterialButton();
            lvQuoteLines = new ListView();
            LineMenuColumn = new ColumnHeader();
            LineTagColumn = new ColumnHeader();
            LineAdultsColumn = new ColumnHeader();
            LineChildsColumn = new ColumnHeader();
            LineSubtotalColumn = new ColumnHeader();
            btnRemoveLine = new MaterialSkin.Controls.MaterialButton();
            label9 = new MaterialSkin.Controls.MaterialLabel();
            clbQuoteOptionItems = new CheckedListBox();
            label10 = new MaterialSkin.Controls.MaterialLabel();
            lblTotalUbication = new MaterialSkin.Controls.MaterialLabel();
            lblTotalMenus = new MaterialSkin.Controls.MaterialLabel();
            lblTotalOptionItems = new MaterialSkin.Controls.MaterialLabel();
            lblTotal = new MaterialSkin.Controls.MaterialLabel();
            btnGuardarQuote = new MaterialSkin.Controls.MaterialButton();
            btnVolverQuote = new MaterialSkin.Controls.MaterialButton();
            panelIndexList.SuspendLayout();
            panelIndexTitle.SuspendLayout();
            panelIndexFilter.SuspendLayout();
            panelCrudCtrlIndex.SuspendLayout();
            panelQuoteCU.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuoteAdults).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudQuoteChilds).BeginInit();
            SuspendLayout();
            //
            // panelIndexList
            //
            panelIndexList.Controls.Add(mtLvIndex);
            panelIndexList.Controls.Add(panelIndexFilter);
            panelIndexList.Controls.Add(panelIndexTitle);
            panelIndexList.Controls.Add(panelCrudCtrlIndex);
            panelIndexList.Dock = DockStyle.Fill;
            panelIndexList.Location = new Point(0, 0);
            panelIndexList.Name = "panelIndexList";
            panelIndexList.Size = new Size(1280, 720);
            panelIndexList.TabIndex = 0;
            // 
            // panelIndexTitle
            // 
            panelIndexTitle.BackColor = Color.White;
            panelIndexTitle.Controls.Add(lblIndexTitle);
            panelIndexTitle.Dock = DockStyle.Top;
            panelIndexTitle.Name = "panelIndexTitle";
            panelIndexTitle.Size = new Size(500, 45);
            panelIndexTitle.TabIndex = 6;
            // 
            // lblIndexTitle
            // 
            lblIndexTitle.AutoSize = true;
            lblIndexTitle.Depth = 0;
            lblIndexTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblIndexTitle.MouseState = MaterialSkin.MouseState.HOVER;
            lblIndexTitle.Location = new Point(15, 10);
            lblIndexTitle.Name = "lblIndexTitle";
            lblIndexTitle.Size = new Size(100, 24);
            lblIndexTitle.TabIndex = 0;
            lblIndexTitle.Text = "Presupuestos";
            //
            // mtLvIndex
            //
            mtLvIndex.AutoSizeTable = false;
            mtLvIndex.BackColor = Color.FromArgb(255, 255, 255);
            mtLvIndex.BorderStyle = BorderStyle.None;
            mtLvIndex.Columns.AddRange(new ColumnHeader[] { NumberColumn, EventColumn, DateColumn, UbicationColumn, GuestsColumn, StateColumn, TotalColumn });
            mtLvIndex.Depth = 0;
            mtLvIndex.Dock = DockStyle.Fill;
            mtLvIndex.FullRowSelect = true;
            mtLvIndex.Location = new Point(151, 45);
            mtLvIndex.MinimumSize = new Size(200, 100);
            mtLvIndex.MouseLocation = new Point(-1, -1);
            mtLvIndex.MouseState = MaterialSkin.MouseState.OUT;
            mtLvIndex.Name = "mtLvIndex";
            mtLvIndex.OwnerDraw = true;
            mtLvIndex.Size = new Size(1129, 675);
            mtLvIndex.TabIndex = 0;
            mtLvIndex.UseCompatibleStateImageBehavior = false;
            mtLvIndex.View = System.Windows.Forms.View.Details;
            mtLvIndex.DoubleClick += mtLvIndex_DoubleClick;
            //
            // NumberColumn
            //
            NumberColumn.Text = "N°";
            NumberColumn.Width = 55;
            //
            // EventColumn
            //
            EventColumn.Text = "Evento";
            EventColumn.Width = 100;
            //
            // DateColumn
            //
            DateColumn.Text = "Fecha";
            DateColumn.Width = 105;
            //
            // UbicationColumn
            //
            UbicationColumn.Text = "Ubicacion";
            UbicationColumn.Width = 95;
            //
            // GuestsColumn
            //
            GuestsColumn.Text = "Invitados";
            GuestsColumn.Width = 85;
            //
            // StateColumn
            //
            StateColumn.Text = "Estado";
            StateColumn.Width = 90;
            //
            // TotalColumn
            //
            TotalColumn.Text = "Total";
            TotalColumn.Width = 110;
            //
            // panelIndexFilter
            //
            panelIndexFilter.BackColor = Color.White;
            panelIndexFilter.Controls.Add(lblFilterEvent);
            panelIndexFilter.Controls.Add(cmbFilterEvent);
            panelIndexFilter.Dock = DockStyle.Top;
            panelIndexFilter.Location = new Point(151, 0);
            panelIndexFilter.Name = "panelIndexFilter";
            panelIndexFilter.Size = new Size(1129, 45);
            panelIndexFilter.TabIndex = 1;
            //
            // lblFilterEvent
            //
            lblFilterEvent.AutoSize = true;
            lblFilterEvent.Depth = 0;
            lblFilterEvent.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            lblFilterEvent.MouseState = MaterialSkin.MouseState.HOVER;
            lblFilterEvent.Location = new Point(15, 15);
            lblFilterEvent.Name = "lblFilterEvent";
            lblFilterEvent.Size = new Size(45, 15);
            lblFilterEvent.TabIndex = 0;
            lblFilterEvent.Text = "Evento:";
            //
            // cmbFilterEvent
            //
            cmbFilterEvent.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterEvent.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbFilterEvent.Location = new Point(70, 11);
            cmbFilterEvent.Name = "cmbFilterEvent";
            cmbFilterEvent.Size = new Size(250, 23);
            cmbFilterEvent.TabIndex = 1;
            cmbFilterEvent.SelectedIndexChanged += cmbFilterEvent_SelectedIndexChanged;
            //
            // panelCrudCtrlIndex
            //
            panelCrudCtrlIndex.BackColor = Color.White;
            panelCrudCtrlIndex.Controls.Add(btnQuoteCreate);
            panelCrudCtrlIndex.Controls.Add(btnQuoteEdit);
            panelCrudCtrlIndex.Controls.Add(btnQuoteAccept);
            panelCrudCtrlIndex.Controls.Add(btnQuoteCancel);
            panelCrudCtrlIndex.Controls.Add(btnQuoteClone);
            panelCrudCtrlIndex.Controls.Add(btnQuoteRemove);
            panelCrudCtrlIndex.Controls.Add(btnIndexReport);
            panelCrudCtrlIndex.Dock = DockStyle.Left;
            panelCrudCtrlIndex.Location = new Point(0, 0);
            panelCrudCtrlIndex.Name = "panelCrudCtrlIndex";
            panelCrudCtrlIndex.Size = new Size(151, 720);
            panelCrudCtrlIndex.TabIndex = 2;
            //
            // btnQuoteCreate
            //
            btnQuoteCreate.AutoSize = false;
            btnQuoteCreate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnQuoteCreate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnQuoteCreate.Depth = 0;
            btnQuoteCreate.HighEmphasis = true;
            btnQuoteCreate.Icon = null;
            btnQuoteCreate.Location = new Point(25, 40);
            btnQuoteCreate.Margin = new Padding(4, 6, 4, 6);
            btnQuoteCreate.MouseState = MaterialSkin.MouseState.HOVER;
            btnQuoteCreate.Name = "btnQuoteCreate";
            btnQuoteCreate.NoAccentTextColor = Color.Empty;
            btnQuoteCreate.Size = new Size(100, 36);
            btnQuoteCreate.TabIndex = 0;
            btnQuoteCreate.Text = "Nuevo";
            btnQuoteCreate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnQuoteCreate.UseAccentColor = false;
            btnQuoteCreate.UseVisualStyleBackColor = true;
            btnQuoteCreate.Click += btnQuoteCreate_Click;
            //
            // btnQuoteEdit
            //
            btnQuoteEdit.AutoSize = false;
            btnQuoteEdit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnQuoteEdit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnQuoteEdit.Depth = 0;
            btnQuoteEdit.HighEmphasis = true;
            btnQuoteEdit.Icon = null;
            btnQuoteEdit.Location = new Point(25, 100);
            btnQuoteEdit.Margin = new Padding(4, 6, 4, 6);
            btnQuoteEdit.MouseState = MaterialSkin.MouseState.HOVER;
            btnQuoteEdit.Name = "btnQuoteEdit";
            btnQuoteEdit.NoAccentTextColor = Color.Empty;
            btnQuoteEdit.Size = new Size(100, 36);
            btnQuoteEdit.TabIndex = 1;
            btnQuoteEdit.Text = "Editar";
            btnQuoteEdit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnQuoteEdit.UseAccentColor = false;
            btnQuoteEdit.UseVisualStyleBackColor = true;
            btnQuoteEdit.Click += btnQuoteEdit_Click;
            //
            // btnQuoteAccept
            //
            btnQuoteAccept.AutoSize = false;
            btnQuoteAccept.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnQuoteAccept.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnQuoteAccept.Depth = 0;
            btnQuoteAccept.HighEmphasis = true;
            btnQuoteAccept.Icon = null;
            btnQuoteAccept.Location = new Point(25, 160);
            btnQuoteAccept.Margin = new Padding(4, 6, 4, 6);
            btnQuoteAccept.MouseState = MaterialSkin.MouseState.HOVER;
            btnQuoteAccept.Name = "btnQuoteAccept";
            btnQuoteAccept.NoAccentTextColor = Color.Empty;
            btnQuoteAccept.Size = new Size(100, 36);
            btnQuoteAccept.TabIndex = 2;
            btnQuoteAccept.Text = "Aceptar";
            btnQuoteAccept.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnQuoteAccept.UseAccentColor = false;
            btnQuoteAccept.UseVisualStyleBackColor = true;
            btnQuoteAccept.Click += btnQuoteAccept_Click;
            //
            // btnQuoteCancel
            //
            btnQuoteCancel.AutoSize = false;
            btnQuoteCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnQuoteCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnQuoteCancel.Depth = 0;
            btnQuoteCancel.HighEmphasis = true;
            btnQuoteCancel.Icon = null;
            btnQuoteCancel.Location = new Point(25, 220);
            btnQuoteCancel.Margin = new Padding(4, 6, 4, 6);
            btnQuoteCancel.MouseState = MaterialSkin.MouseState.HOVER;
            btnQuoteCancel.Name = "btnQuoteCancel";
            btnQuoteCancel.NoAccentTextColor = Color.Empty;
            btnQuoteCancel.Size = new Size(100, 36);
            btnQuoteCancel.TabIndex = 3;
            btnQuoteCancel.Text = "Cancelar";
            btnQuoteCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnQuoteCancel.UseAccentColor = false;
            btnQuoteCancel.UseVisualStyleBackColor = true;
            btnQuoteCancel.Click += btnQuoteCancel_Click;
            //
            // btnQuoteClone
            //
            btnQuoteClone.AutoSize = false;
            btnQuoteClone.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnQuoteClone.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnQuoteClone.Depth = 0;
            btnQuoteClone.HighEmphasis = true;
            btnQuoteClone.Icon = null;
            btnQuoteClone.Location = new Point(25, 280);
            btnQuoteClone.Margin = new Padding(4, 6, 4, 6);
            btnQuoteClone.MouseState = MaterialSkin.MouseState.HOVER;
            btnQuoteClone.Name = "btnQuoteClone";
            btnQuoteClone.NoAccentTextColor = Color.Empty;
            btnQuoteClone.Size = new Size(100, 36);
            btnQuoteClone.TabIndex = 4;
            btnQuoteClone.Text = "Clonar";
            btnQuoteClone.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnQuoteClone.UseAccentColor = false;
            btnQuoteClone.UseVisualStyleBackColor = true;
            btnQuoteClone.Click += btnQuoteClone_Click;
            //
            // btnQuoteRemove
            //
            btnQuoteRemove.AutoSize = false;
            btnQuoteRemove.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnQuoteRemove.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnQuoteRemove.Depth = 0;
            btnQuoteRemove.HighEmphasis = true;
            btnQuoteRemove.Icon = null;
            btnQuoteRemove.Location = new Point(25, 340);
            btnQuoteRemove.Margin = new Padding(4, 6, 4, 6);
            btnQuoteRemove.MouseState = MaterialSkin.MouseState.HOVER;
            btnQuoteRemove.Name = "btnQuoteRemove";
            btnQuoteRemove.NoAccentTextColor = Color.Empty;
            btnQuoteRemove.Size = new Size(100, 36);
            btnQuoteRemove.TabIndex = 5;
            btnQuoteRemove.Text = "Eliminar";
            btnQuoteRemove.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnQuoteRemove.UseAccentColor = false;
            btnQuoteRemove.UseVisualStyleBackColor = true;
            btnQuoteRemove.Click += btnQuoteRemove_Click;
            //
            // btnIndexReport
            //
            btnIndexReport.AutoSize = false;
            btnIndexReport.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnIndexReport.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnIndexReport.Depth = 0;
            btnIndexReport.HighEmphasis = true;
            btnIndexReport.Icon = null;
            btnIndexReport.Location = new Point(25, 420);
            btnIndexReport.Margin = new Padding(4, 6, 4, 6);
            btnIndexReport.MouseState = MaterialSkin.MouseState.HOVER;
            btnIndexReport.Name = "btnIndexReport";
            btnIndexReport.NoAccentTextColor = Color.Empty;
            btnIndexReport.Size = new Size(100, 36);
            btnIndexReport.TabIndex = 6;
            btnIndexReport.Text = "Detalle";
            btnIndexReport.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnIndexReport.UseAccentColor = false;
            btnIndexReport.UseVisualStyleBackColor = true;
            btnIndexReport.Click += btnIndexReport_Click;
            //
            // panelQuoteCU
            //
            panelQuoteCU.Controls.Add(label1);
            panelQuoteCU.Controls.Add(label2);
            panelQuoteCU.Controls.Add(cmbQuoteEvent);
            panelQuoteCU.Controls.Add(label3);
            panelQuoteCU.Controls.Add(cmbQuoteUbication);
            panelQuoteCU.Controls.Add(label4);
            panelQuoteCU.Controls.Add(lblQuoteGuests);
            panelQuoteCU.Controls.Add(label5);
            panelQuoteCU.Controls.Add(cmbQuoteMenu);
            panelQuoteCU.Controls.Add(label6);
            panelQuoteCU.Controls.Add(cmbQuoteTag);
            panelQuoteCU.Controls.Add(label7);
            panelQuoteCU.Controls.Add(nudQuoteAdults);
            panelQuoteCU.Controls.Add(label8);
            panelQuoteCU.Controls.Add(nudQuoteChilds);
            panelQuoteCU.Controls.Add(btnAddLine);
            panelQuoteCU.Controls.Add(lvQuoteLines);
            panelQuoteCU.Controls.Add(btnRemoveLine);
            panelQuoteCU.Controls.Add(label9);
            panelQuoteCU.Controls.Add(clbQuoteOptionItems);
            panelQuoteCU.Controls.Add(label10);
            panelQuoteCU.Controls.Add(lblTotalUbication);
            panelQuoteCU.Controls.Add(lblTotalMenus);
            panelQuoteCU.Controls.Add(lblTotalOptionItems);
            panelQuoteCU.Controls.Add(lblTotal);
            panelQuoteCU.Controls.Add(btnGuardarQuote);
            panelQuoteCU.Controls.Add(btnVolverQuote);
            panelQuoteCU.Location = new Point(640, 0);
            panelQuoteCU.Name = "panelQuoteCU";
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
            // cmbQuoteUbication
            //
            cmbQuoteUbication.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbQuoteUbication.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbQuoteUbication.Location = new Point(290, 68);
            cmbQuoteUbication.Name = "cmbQuoteUbication";
            cmbQuoteUbication.Size = new Size(220, 23);
            cmbQuoteUbication.TabIndex = 4;
            cmbQuoteUbication.SelectedIndexChanged += cmbQuoteUbication_SelectedIndexChanged;
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
            // nudQuoteChilds
            //
            nudQuoteChilds.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudQuoteChilds.Location = new Point(390, 146);
            nudQuoteChilds.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudQuoteChilds.Name = "nudQuoteChilds";
            nudQuoteChilds.Size = new Size(60, 23);
            nudQuoteChilds.TabIndex = 13;
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
            lvQuoteLines.Columns.AddRange(new ColumnHeader[] { LineMenuColumn, LineTagColumn, LineAdultsColumn, LineChildsColumn, LineSubtotalColumn });
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
            // LineChildsColumn
            //
            LineChildsColumn.Text = "Niños";
            LineChildsColumn.Width = 70;
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
            // lblTotalUbication
            //
            lblTotalUbication.AutoSize = true;
            lblTotalUbication.Depth = 0;
            lblTotalUbication.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            lblTotalUbication.MouseState = MaterialSkin.MouseState.HOVER;
            lblTotalUbication.Location = new Point(300, 348);
            lblTotalUbication.Name = "lblTotalUbication";
            lblTotalUbication.Size = new Size(70, 15);
            lblTotalUbication.TabIndex = 20;
            lblTotalUbication.Text = "Ubicacion: -";
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
            btnGuardarQuote.AutoSize = false;
            btnGuardarQuote.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGuardarQuote.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnGuardarQuote.Depth = 0;
            btnGuardarQuote.HighEmphasis = true;
            btnGuardarQuote.Icon = null;
            btnGuardarQuote.Location = new Point(150, 480);
            btnGuardarQuote.Margin = new Padding(4, 6, 4, 6);
            btnGuardarQuote.MouseState = MaterialSkin.MouseState.HOVER;
            btnGuardarQuote.Name = "btnGuardarQuote";
            btnGuardarQuote.NoAccentTextColor = Color.Empty;
            btnGuardarQuote.Size = new Size(90, 36);
            btnGuardarQuote.TabIndex = 24;
            btnGuardarQuote.Text = "Guardar";
            btnGuardarQuote.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnGuardarQuote.UseAccentColor = false;
            btnGuardarQuote.UseVisualStyleBackColor = true;
            btnGuardarQuote.Click += btnGuardarQuote_Click;
            //
            // btnVolverQuote
            //
            btnVolverQuote.AutoSize = false;
            btnVolverQuote.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnVolverQuote.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnVolverQuote.Depth = 0;
            btnVolverQuote.HighEmphasis = true;
            btnVolverQuote.Icon = null;
            btnVolverQuote.Location = new Point(350, 480);
            btnVolverQuote.Margin = new Padding(4, 6, 4, 6);
            btnVolverQuote.MouseState = MaterialSkin.MouseState.HOVER;
            btnVolverQuote.Name = "btnVolverQuote";
            btnVolverQuote.NoAccentTextColor = Color.Empty;
            btnVolverQuote.Size = new Size(90, 36);
            btnVolverQuote.TabIndex = 25;
            btnVolverQuote.Text = "Volver";
            btnVolverQuote.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnVolverQuote.UseAccentColor = false;
            btnVolverQuote.UseVisualStyleBackColor = true;
            btnVolverQuote.Click += btnVolverQuote_Click;
            //
            // FormIndex
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(panelQuoteCU);
            Controls.Add(panelIndexList);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormIndex";
            Text = "FormIndex";
            Load += FormIndex_Load;
            panelIndexList.ResumeLayout(false);
            panelIndexTitle.ResumeLayout(false);
            panelIndexTitle.PerformLayout();
            panelIndexFilter.ResumeLayout(false);
            panelIndexFilter.PerformLayout();
            panelCrudCtrlIndex.ResumeLayout(false);
            panelQuoteCU.ResumeLayout(false);
            panelQuoteCU.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuoteAdults).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudQuoteChilds).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelIndexList;
        private Panel panelIndexTitle;
        private MaterialSkin.Controls.MaterialLabel lblIndexTitle;
        private MaterialSkin.Controls.MaterialListView mtLvIndex;
        private ColumnHeader NumberColumn;
        private ColumnHeader EventColumn;
        private ColumnHeader DateColumn;
        private ColumnHeader UbicationColumn;
        private ColumnHeader GuestsColumn;
        private ColumnHeader StateColumn;
        private ColumnHeader TotalColumn;
        private Panel panelIndexFilter;
        private MaterialSkin.Controls.MaterialLabel lblFilterEvent;
        private ComboBox cmbFilterEvent;
        private Panel panelCrudCtrlIndex;
        private MaterialSkin.Controls.MaterialButton btnQuoteCreate;
        private MaterialSkin.Controls.MaterialButton btnQuoteEdit;
        private MaterialSkin.Controls.MaterialButton btnQuoteAccept;
        private MaterialSkin.Controls.MaterialButton btnQuoteCancel;
        private MaterialSkin.Controls.MaterialButton btnQuoteClone;
        private MaterialSkin.Controls.MaterialButton btnQuoteRemove;
        private MaterialSkin.Controls.MaterialButton btnIndexReport;
        private Panel panelQuoteCU;
        private MaterialSkin.Controls.MaterialLabel label1;
        private MaterialSkin.Controls.MaterialLabel label2;
        private ComboBox cmbQuoteEvent;
        private MaterialSkin.Controls.MaterialLabel label3;
        private ComboBox cmbQuoteUbication;
        private MaterialSkin.Controls.MaterialLabel label4;
        private MaterialSkin.Controls.MaterialLabel lblQuoteGuests;
        private MaterialSkin.Controls.MaterialLabel label5;
        private ComboBox cmbQuoteMenu;
        private MaterialSkin.Controls.MaterialLabel label6;
        private ComboBox cmbQuoteTag;
        private MaterialSkin.Controls.MaterialLabel label7;
        private NumericUpDown nudQuoteAdults;
        private MaterialSkin.Controls.MaterialLabel label8;
        private NumericUpDown nudQuoteChilds;
        private MaterialSkin.Controls.MaterialButton btnAddLine;
        private ListView lvQuoteLines;
        private ColumnHeader LineMenuColumn;
        private ColumnHeader LineTagColumn;
        private ColumnHeader LineAdultsColumn;
        private ColumnHeader LineChildsColumn;
        private ColumnHeader LineSubtotalColumn;
        private MaterialSkin.Controls.MaterialButton btnRemoveLine;
        private MaterialSkin.Controls.MaterialLabel label9;
        private CheckedListBox clbQuoteOptionItems;
        private MaterialSkin.Controls.MaterialLabel label10;
        private MaterialSkin.Controls.MaterialLabel lblTotalUbication;
        private MaterialSkin.Controls.MaterialLabel lblTotalMenus;
        private MaterialSkin.Controls.MaterialLabel lblTotalOptionItems;
        private MaterialSkin.Controls.MaterialLabel lblTotal;
        private MaterialSkin.Controls.MaterialButton btnGuardarQuote;
        private MaterialSkin.Controls.MaterialButton btnVolverQuote;
    }
}
