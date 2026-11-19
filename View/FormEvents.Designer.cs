namespace ProyectoPresupuestoEvento.View
{
    partial class FormEvents
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
            panelCrudCtrlEvents = new Panel();
            btnEventRemove = new MaterialSkin.Controls.MaterialButton();
            btnEventEdit = new MaterialSkin.Controls.MaterialButton();
            btnEventCreate = new MaterialSkin.Controls.MaterialButton();
            panelEventsList = new Panel();
            panelEventsTitle = new Panel();
            lblEventsTitle = new MaterialSkin.Controls.MaterialLabel();
            mtLvEvents = new MaterialSkin.Controls.MaterialListView();
            NameColumn = new ColumnHeader();
            ClientColumn = new ColumnHeader();
            DateColumn = new ColumnHeader();
            AdultsColumn = new ColumnHeader();
            ChildrenColumn = new ColumnHeader();
            DurationColumn = new ColumnHeader();
            panelEventsCU = new Panel();
            lblEventFormTitle = new MaterialSkin.Controls.MaterialLabel();
            lblEventName = new MaterialSkin.Controls.MaterialLabel();
            mtbEventName = new MaterialSkin.Controls.MaterialTextBox();
            lblEventClient = new MaterialSkin.Controls.MaterialLabel();
            mtbEventClient = new MaterialSkin.Controls.MaterialTextBox();
            lblEventDate = new MaterialSkin.Controls.MaterialLabel();
            dtpEventDate = new DateTimePicker();
            lblEventAdults = new MaterialSkin.Controls.MaterialLabel();
            nudEventAdults = new NumericUpDown();
            lblEventChildren = new MaterialSkin.Controls.MaterialLabel();
            nudEventChildren = new NumericUpDown();
            lblEventDuration = new MaterialSkin.Controls.MaterialLabel();
            nudEventDuration = new NumericUpDown();
            btnSaveEvent = new MaterialSkin.Controls.MaterialButton();
            btnBackEvent = new MaterialSkin.Controls.MaterialButton();
            panelCrudCtrlEvents.SuspendLayout();
            panelEventsList.SuspendLayout();
            panelEventsTitle.SuspendLayout();
            panelEventsCU.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudEventAdults).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudEventChildren).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudEventDuration).BeginInit();
            SuspendLayout();
            //
            // panelCrudCtrlEvents
            //
            panelCrudCtrlEvents.BackColor = Color.White;
            panelCrudCtrlEvents.Controls.Add(btnEventRemove);
            panelCrudCtrlEvents.Controls.Add(btnEventEdit);
            panelCrudCtrlEvents.Controls.Add(btnEventCreate);
            panelCrudCtrlEvents.Dock = DockStyle.Left;
            panelCrudCtrlEvents.Location = new Point(0, 0);
            panelCrudCtrlEvents.Name = "panelCrudCtrlEvents";
            panelCrudCtrlEvents.Size = new Size(151, 720);
            panelCrudCtrlEvents.TabIndex = 2;
            //
            // btnEventRemove
            //
            btnEventRemove.AutoSize = false;
            btnEventRemove.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEventRemove.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnEventRemove.Depth = 0;
            btnEventRemove.HighEmphasis = true;
            btnEventRemove.Icon = null;
            btnEventRemove.Location = new Point(36, 346);
            btnEventRemove.Margin = new Padding(4, 6, 4, 6);
            btnEventRemove.MouseState = MaterialSkin.MouseState.HOVER;
            btnEventRemove.Name = "btnEventRemove";
            btnEventRemove.NoAccentTextColor = Color.Empty;
            btnEventRemove.Size = new Size(90, 36);
            btnEventRemove.TabIndex = 2;
            btnEventRemove.Text = "Eliminar";
            btnEventRemove.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnEventRemove.UseAccentColor = false;
            btnEventRemove.UseVisualStyleBackColor = true;
            btnEventRemove.Click += btnEventRemove_Click;
            //
            // btnEventEdit
            //
            btnEventEdit.AutoSize = false;
            btnEventEdit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEventEdit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnEventEdit.Depth = 0;
            btnEventEdit.HighEmphasis = true;
            btnEventEdit.Icon = null;
            btnEventEdit.Location = new Point(36, 238);
            btnEventEdit.Margin = new Padding(4, 6, 4, 6);
            btnEventEdit.MouseState = MaterialSkin.MouseState.HOVER;
            btnEventEdit.Name = "btnEventEdit";
            btnEventEdit.NoAccentTextColor = Color.Empty;
            btnEventEdit.Size = new Size(90, 36);
            btnEventEdit.TabIndex = 1;
            btnEventEdit.Text = "Editar";
            btnEventEdit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnEventEdit.UseAccentColor = false;
            btnEventEdit.UseVisualStyleBackColor = true;
            btnEventEdit.Click += btnEventEdit_Click;
            //
            // btnEventCreate
            //
            btnEventCreate.AutoSize = false;
            btnEventCreate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEventCreate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnEventCreate.Depth = 0;
            btnEventCreate.HighEmphasis = true;
            btnEventCreate.Icon = null;
            btnEventCreate.Location = new Point(36, 115);
            btnEventCreate.Margin = new Padding(4, 6, 4, 6);
            btnEventCreate.MouseState = MaterialSkin.MouseState.HOVER;
            btnEventCreate.Name = "btnEventCreate";
            btnEventCreate.NoAccentTextColor = Color.Empty;
            btnEventCreate.Size = new Size(90, 36);
            btnEventCreate.TabIndex = 0;
            btnEventCreate.Text = "Crear";
            btnEventCreate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnEventCreate.UseAccentColor = false;
            btnEventCreate.UseVisualStyleBackColor = true;
            btnEventCreate.Click += btnEventCreate_Click;
            //
            // panelEventsList
            //
            panelEventsList.Controls.Add(mtLvEvents);
            panelEventsList.Controls.Add(panelEventsTitle);
            panelEventsList.Controls.Add(panelCrudCtrlEvents);
            panelEventsList.Dock = DockStyle.Fill;
            panelEventsList.Location = new Point(0, 0);
            panelEventsList.Name = "panelEventsList";
            panelEventsList.Size = new Size(1280, 720);
            panelEventsList.TabIndex = 1;
            // 
            // panelEventsTitle
            // 
            panelEventsTitle.BackColor = Color.White;
            panelEventsTitle.Controls.Add(lblEventsTitle);
            panelEventsTitle.Dock = DockStyle.Top;
            panelEventsTitle.Name = "panelEventsTitle";
            panelEventsTitle.Size = new Size(500, 45);
            panelEventsTitle.TabIndex = 6;
            // 
            // lblEventsTitle
            // 
            lblEventsTitle.AutoSize = true;
            lblEventsTitle.Depth = 0;
            lblEventsTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblEventsTitle.MouseState = MaterialSkin.MouseState.HOVER;
            lblEventsTitle.Location = new Point(15, 10);
            lblEventsTitle.Name = "lblEventsTitle";
            lblEventsTitle.Size = new Size(100, 24);
            lblEventsTitle.TabIndex = 0;
            lblEventsTitle.Text = "Eventos";
            //
            // mtLvEvents
            //
            mtLvEvents.AutoSizeTable = false;
            mtLvEvents.BackColor = Color.FromArgb(255, 255, 255);
            mtLvEvents.BorderStyle = BorderStyle.None;
            mtLvEvents.Columns.AddRange(new ColumnHeader[] { NameColumn, ClientColumn, DateColumn, AdultsColumn, ChildrenColumn, DurationColumn });
            mtLvEvents.Depth = 0;
            mtLvEvents.Dock = DockStyle.Fill;
            mtLvEvents.FullRowSelect = true;
            mtLvEvents.Location = new Point(151, 0);
            mtLvEvents.MinimumSize = new Size(200, 100);
            mtLvEvents.MouseLocation = new Point(-1, -1);
            mtLvEvents.MouseState = MaterialSkin.MouseState.OUT;
            mtLvEvents.Name = "mtLvEvents";
            mtLvEvents.OwnerDraw = true;
            mtLvEvents.Size = new Size(1129, 720);
            mtLvEvents.TabIndex = 1;
            mtLvEvents.UseCompatibleStateImageBehavior = false;
            mtLvEvents.View = System.Windows.Forms.View.Details;
            mtLvEvents.DoubleClick += mtLvEvents_DoubleClick;
            //
            // NameColumn
            //
            NameColumn.Text = "Nombre";
            NameColumn.Width = 150;
            //
            // ClientColumn
            //
            ClientColumn.Text = "Cliente";
            ClientColumn.Width = 130;
            //
            // DateColumn
            //
            DateColumn.Text = "Fecha";
            DateColumn.Width = 150;
            //
            // AdultsColumn
            //
            AdultsColumn.Text = "Adultos";
            AdultsColumn.Width = 80;
            //
            // ChildrenColumn
            //
            ChildrenColumn.Text = "Niños";
            ChildrenColumn.Width = 70;
            //
            // DurationColumn
            //
            DurationColumn.Text = "Horas";
            DurationColumn.Width = 70;
            //
            // panelEventsCU
            //
            panelEventsCU.Controls.Add(lblEventFormTitle);
            panelEventsCU.Controls.Add(lblEventName);
            panelEventsCU.Controls.Add(mtbEventName);
            panelEventsCU.Controls.Add(lblEventClient);
            panelEventsCU.Controls.Add(mtbEventClient);
            panelEventsCU.Controls.Add(lblEventDate);
            panelEventsCU.Controls.Add(dtpEventDate);
            panelEventsCU.Controls.Add(lblEventAdults);
            panelEventsCU.Controls.Add(nudEventAdults);
            panelEventsCU.Controls.Add(lblEventChildren);
            panelEventsCU.Controls.Add(nudEventChildren);
            panelEventsCU.Controls.Add(lblEventDuration);
            panelEventsCU.Controls.Add(nudEventDuration);
            panelEventsCU.Controls.Add(btnSaveEvent);
            panelEventsCU.Controls.Add(btnBackEvent);
            panelEventsCU.Location = new Point(640, 0);
            panelEventsCU.Name = "panelEventsCU";
            panelEventsCU.Size = new Size(640, 720);
            panelEventsCU.TabIndex = 2;
            //
            // lblEventFormTitle
            //
            lblEventFormTitle.AutoSize = true;
            lblEventFormTitle.Depth = 0;
            lblEventFormTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblEventFormTitle.MouseState = MaterialSkin.MouseState.HOVER;
            lblEventFormTitle.Location = new Point(40, 30);
            lblEventFormTitle.Name = "lblEventFormTitle";
            lblEventFormTitle.Size = new Size(160, 24);
            lblEventFormTitle.TabIndex = 0;
            lblEventFormTitle.Text = "Carga de evento";
            //
            // lblEventName
            //
            lblEventName.AutoSize = true;
            lblEventName.Depth = 0;
            lblEventName.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            lblEventName.MouseState = MaterialSkin.MouseState.HOVER;
            lblEventName.Location = new Point(40, 90);
            lblEventName.Name = "lblEventName";
            lblEventName.Size = new Size(110, 15);
            lblEventName.TabIndex = 1;
            lblEventName.Text = "Nombre del evento";
            //
            // mtbEventName
            //
            mtbEventName.AnimateReadOnly = false;
            mtbEventName.BorderStyle = BorderStyle.None;
            mtbEventName.Depth = 0;
            mtbEventName.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            mtbEventName.LeadingIcon = null;
            mtbEventName.Location = new Point(40, 112);
            mtbEventName.MaxLength = 50;
            mtbEventName.MouseState = MaterialSkin.MouseState.OUT;
            mtbEventName.Multiline = false;
            mtbEventName.Name = "mtbEventName";
            mtbEventName.Size = new Size(250, 50);
            mtbEventName.TabIndex = 2;
            mtbEventName.Text = "";
            mtbEventName.TrailingIcon = null;
            //
            // lblEventClient
            //
            lblEventClient.AutoSize = true;
            lblEventClient.Depth = 0;
            lblEventClient.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            lblEventClient.MouseState = MaterialSkin.MouseState.HOVER;
            lblEventClient.Location = new Point(40, 182);
            lblEventClient.Name = "lblEventClient";
            lblEventClient.Size = new Size(110, 15);
            lblEventClient.TabIndex = 3;
            lblEventClient.Text = "Nombre del cliente";
            //
            // mtbEventClient
            //
            mtbEventClient.AnimateReadOnly = false;
            mtbEventClient.BorderStyle = BorderStyle.None;
            mtbEventClient.Depth = 0;
            mtbEventClient.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            mtbEventClient.LeadingIcon = null;
            mtbEventClient.Location = new Point(40, 204);
            mtbEventClient.MaxLength = 50;
            mtbEventClient.MouseState = MaterialSkin.MouseState.OUT;
            mtbEventClient.Multiline = false;
            mtbEventClient.Name = "mtbEventClient";
            mtbEventClient.Size = new Size(250, 50);
            mtbEventClient.TabIndex = 4;
            mtbEventClient.Text = "";
            mtbEventClient.TrailingIcon = null;
            //
            // lblEventDate
            //
            lblEventDate.AutoSize = true;
            lblEventDate.Depth = 0;
            lblEventDate.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            lblEventDate.MouseState = MaterialSkin.MouseState.HOVER;
            lblEventDate.Location = new Point(40, 274);
            lblEventDate.Name = "lblEventDate";
            lblEventDate.Size = new Size(125, 15);
            lblEventDate.TabIndex = 5;
            lblEventDate.Text = "Fecha y hora de inicio";
            //
            // dtpEventDate
            //
            dtpEventDate.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpEventDate.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpEventDate.Format = DateTimePickerFormat.Custom;
            dtpEventDate.Location = new Point(40, 296);
            dtpEventDate.Name = "dtpEventDate";
            dtpEventDate.Size = new Size(250, 27);
            dtpEventDate.TabIndex = 6;
            //
            // lblEventAdults
            //
            lblEventAdults.AutoSize = true;
            lblEventAdults.Depth = 0;
            lblEventAdults.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            lblEventAdults.MouseState = MaterialSkin.MouseState.HOVER;
            lblEventAdults.Location = new Point(340, 90);
            lblEventAdults.Name = "lblEventAdults";
            lblEventAdults.Size = new Size(100, 15);
            lblEventAdults.TabIndex = 7;
            lblEventAdults.Text = "Invitados adultos";
            //
            // nudEventAdults
            //
            nudEventAdults.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudEventAdults.Location = new Point(340, 112);
            nudEventAdults.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudEventAdults.Name = "nudEventAdults";
            nudEventAdults.Size = new Size(250, 27);
            nudEventAdults.TabIndex = 8;
            //
            // lblEventChildren
            //
            lblEventChildren.AutoSize = true;
            lblEventChildren.Depth = 0;
            lblEventChildren.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            lblEventChildren.MouseState = MaterialSkin.MouseState.HOVER;
            lblEventChildren.Location = new Point(340, 182);
            lblEventChildren.Name = "lblEventChildren";
            lblEventChildren.Size = new Size(90, 15);
            lblEventChildren.TabIndex = 9;
            lblEventChildren.Text = "Invitados niños";
            //
            // nudEventChildren
            //
            nudEventChildren.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudEventChildren.Location = new Point(340, 204);
            nudEventChildren.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudEventChildren.Name = "nudEventChildren";
            nudEventChildren.Size = new Size(250, 27);
            nudEventChildren.TabIndex = 10;
            //
            // lblEventDuration
            //
            lblEventDuration.AutoSize = true;
            lblEventDuration.Depth = 0;
            lblEventDuration.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            lblEventDuration.MouseState = MaterialSkin.MouseState.HOVER;
            lblEventDuration.Location = new Point(340, 274);
            lblEventDuration.Name = "lblEventDuration";
            lblEventDuration.Size = new Size(100, 15);
            lblEventDuration.TabIndex = 11;
            lblEventDuration.Text = "Duracion (horas)";
            //
            // nudEventDuration
            //
            nudEventDuration.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudEventDuration.Location = new Point(340, 296);
            nudEventDuration.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            nudEventDuration.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudEventDuration.Name = "nudEventDuration";
            nudEventDuration.Size = new Size(250, 27);
            nudEventDuration.TabIndex = 12;
            nudEventDuration.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // btnSaveEvent
            //
            btnSaveEvent.AutoSize = false;
            btnSaveEvent.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSaveEvent.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSaveEvent.Depth = 0;
            btnSaveEvent.HighEmphasis = true;
            btnSaveEvent.Icon = null;
            btnSaveEvent.Location = new Point(40, 362);
            btnSaveEvent.Margin = new Padding(4, 6, 4, 6);
            btnSaveEvent.MouseState = MaterialSkin.MouseState.HOVER;
            btnSaveEvent.Name = "btnSaveEvent";
            btnSaveEvent.NoAccentTextColor = Color.Empty;
            btnSaveEvent.Size = new Size(90, 36);
            btnSaveEvent.TabIndex = 13;
            btnSaveEvent.Text = "Guardar";
            btnSaveEvent.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSaveEvent.UseAccentColor = false;
            btnSaveEvent.UseVisualStyleBackColor = true;
            btnSaveEvent.Click += btnSaveEvent_Click;
            //
            // btnBackEvent
            //
            btnBackEvent.AutoSize = false;
            btnBackEvent.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBackEvent.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBackEvent.Depth = 0;
            btnBackEvent.HighEmphasis = true;
            btnBackEvent.Icon = null;
            btnBackEvent.Location = new Point(500, 362);
            btnBackEvent.Margin = new Padding(4, 6, 4, 6);
            btnBackEvent.MouseState = MaterialSkin.MouseState.HOVER;
            btnBackEvent.Name = "btnBackEvent";
            btnBackEvent.NoAccentTextColor = Color.Empty;
            btnBackEvent.Size = new Size(90, 36);
            btnBackEvent.TabIndex = 14;
            btnBackEvent.Text = "Volver";
            btnBackEvent.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnBackEvent.UseAccentColor = false;
            btnBackEvent.UseVisualStyleBackColor = true;
            btnBackEvent.Click += btnBackEvent_Click;
            //
            // FormEvents
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(panelEventsCU);
            Controls.Add(panelEventsList);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormEvents";
            Text = "FormEvents";
            Load += FormEvents_Load;
            panelCrudCtrlEvents.ResumeLayout(false);
            panelEventsList.ResumeLayout(false);
            panelEventsTitle.ResumeLayout(false);
            panelEventsTitle.PerformLayout();
            panelEventsCU.ResumeLayout(false);
            panelEventsCU.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudEventAdults).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudEventChildren).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudEventDuration).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelEventsList;
        private Panel panelEventsTitle;
        private MaterialSkin.Controls.MaterialLabel lblEventsTitle;
        private Panel panelEventsCU;
        private MaterialSkin.Controls.MaterialListView mtLvEvents;
        private ColumnHeader NameColumn;
        private ColumnHeader ClientColumn;
        private ColumnHeader DateColumn;
        private ColumnHeader AdultsColumn;
        private ColumnHeader ChildrenColumn;
        private ColumnHeader DurationColumn;
        private Panel panelCrudCtrlEvents;
        private MaterialSkin.Controls.MaterialButton btnEventRemove;
        private MaterialSkin.Controls.MaterialButton btnEventEdit;
        private MaterialSkin.Controls.MaterialButton btnEventCreate;
        private MaterialSkin.Controls.MaterialLabel lblEventFormTitle;
        private MaterialSkin.Controls.MaterialLabel lblEventName;
        private MaterialSkin.Controls.MaterialTextBox mtbEventName;
        private MaterialSkin.Controls.MaterialLabel lblEventClient;
        private MaterialSkin.Controls.MaterialTextBox mtbEventClient;
        private MaterialSkin.Controls.MaterialLabel lblEventDate;
        private DateTimePicker dtpEventDate;
        private MaterialSkin.Controls.MaterialLabel lblEventAdults;
        private NumericUpDown nudEventAdults;
        private MaterialSkin.Controls.MaterialLabel lblEventChildren;
        private NumericUpDown nudEventChildren;
        private MaterialSkin.Controls.MaterialLabel lblEventDuration;
        private NumericUpDown nudEventDuration;
        private MaterialSkin.Controls.MaterialButton btnSaveEvent;
        private MaterialSkin.Controls.MaterialButton btnBackEvent;
    }
}
