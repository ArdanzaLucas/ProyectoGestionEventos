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
            LocationColumn = new ColumnHeader();
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
            btnQuoteSavePdf = new MaterialSkin.Controls.MaterialButton();
            panelIndexList.SuspendLayout();
            panelIndexTitle.SuspendLayout();
            panelIndexFilter.SuspendLayout();
            panelCrudCtrlIndex.SuspendLayout();
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
            mtLvIndex.Columns.AddRange(new ColumnHeader[] { NumberColumn, EventColumn, DateColumn, LocationColumn, GuestsColumn, StateColumn, TotalColumn });
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
            // LocationColumn
            //
            LocationColumn.Text = "Ubicacion";
            LocationColumn.Width = 95;
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
            panelCrudCtrlIndex.Controls.Add(btnQuoteSavePdf);
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
            // btnQuoteSavePdf
            //
            btnQuoteSavePdf.AutoSize = false;
            btnQuoteSavePdf.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnQuoteSavePdf.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnQuoteSavePdf.Depth = 0;
            btnQuoteSavePdf.HighEmphasis = true;
            btnQuoteSavePdf.Icon = null;
            btnQuoteSavePdf.Location = new Point(20, 480);
            btnQuoteSavePdf.Margin = new Padding(4, 6, 4, 6);
            btnQuoteSavePdf.MouseState = MaterialSkin.MouseState.HOVER;
            btnQuoteSavePdf.Name = "btnQuoteSavePdf";
            btnQuoteSavePdf.NoAccentTextColor = Color.Empty;
            btnQuoteSavePdf.Size = new Size(110, 36);
            btnQuoteSavePdf.TabIndex = 7;
            btnQuoteSavePdf.Text = "Guardar PDF";
            btnQuoteSavePdf.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnQuoteSavePdf.UseAccentColor = false;
            btnQuoteSavePdf.UseVisualStyleBackColor = true;
            btnQuoteSavePdf.Click += btnQuoteSavePdf_Click;
            //
            // FormIndex
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
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
        private ColumnHeader LocationColumn;
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
        private MaterialSkin.Controls.MaterialButton btnQuoteSavePdf;
    }
}
