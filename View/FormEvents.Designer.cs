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
            panelCrudCtrlEv = new Panel();
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
            label1 = new MaterialSkin.Controls.MaterialLabel();
            label2 = new MaterialSkin.Controls.MaterialLabel();
            mtbEventName = new MaterialSkin.Controls.MaterialTextBox();
            label3 = new MaterialSkin.Controls.MaterialLabel();
            mtbEventClient = new MaterialSkin.Controls.MaterialTextBox();
            label4 = new MaterialSkin.Controls.MaterialLabel();
            dtpEventDate = new DateTimePicker();
            label5 = new MaterialSkin.Controls.MaterialLabel();
            nudEventAdults = new NumericUpDown();
            label6 = new MaterialSkin.Controls.MaterialLabel();
            nudEventChildren = new NumericUpDown();
            label7 = new MaterialSkin.Controls.MaterialLabel();
            nudEventDuration = new NumericUpDown();
            btnSaveEvent = new MaterialSkin.Controls.MaterialButton();
            btnBackEvent = new MaterialSkin.Controls.MaterialButton();
            panelCrudCtrlEv.SuspendLayout();
            panelEventsList.SuspendLayout();
            panelEventsTitle.SuspendLayout();
            panelEventsCU.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudEventAdults).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudEventChildren).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudEventDuration).BeginInit();
            SuspendLayout();
            //
            // panelCrudCtrlEv
            //
            panelCrudCtrlEv.BackColor = Color.White;
            panelCrudCtrlEv.Controls.Add(btnEventRemove);
            panelCrudCtrlEv.Controls.Add(btnEventEdit);
            panelCrudCtrlEv.Controls.Add(btnEventCreate);
            panelCrudCtrlEv.Dock = DockStyle.Left;
            panelCrudCtrlEv.Location = new Point(0, 0);
            panelCrudCtrlEv.Name = "panelCrudCtrlEv";
            panelCrudCtrlEv.Size = new Size(151, 720);
            panelCrudCtrlEv.TabIndex = 2;
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
            panelEventsList.Controls.Add(panelCrudCtrlEv);
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
            panelEventsCU.Controls.Add(label1);
            panelEventsCU.Controls.Add(label2);
            panelEventsCU.Controls.Add(mtbEventName);
            panelEventsCU.Controls.Add(label3);
            panelEventsCU.Controls.Add(mtbEventClient);
            panelEventsCU.Controls.Add(label4);
            panelEventsCU.Controls.Add(dtpEventDate);
            panelEventsCU.Controls.Add(label5);
            panelEventsCU.Controls.Add(nudEventAdults);
            panelEventsCU.Controls.Add(label6);
            panelEventsCU.Controls.Add(nudEventChildren);
            panelEventsCU.Controls.Add(label7);
            panelEventsCU.Controls.Add(nudEventDuration);
            panelEventsCU.Controls.Add(btnSaveEvent);
            panelEventsCU.Controls.Add(btnBackEvent);
            panelEventsCU.Location = new Point(640, 0);
            panelEventsCU.Name = "panelEventsCU";
            panelEventsCU.Size = new Size(640, 720);
            panelEventsCU.TabIndex = 2;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Depth = 0;
            label1.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            label1.MouseState = MaterialSkin.MouseState.HOVER;
            label1.Location = new Point(40, 30);
            label1.Name = "label1";
            label1.Size = new Size(160, 24);
            label1.TabIndex = 0;
            label1.Text = "Carga de evento";
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Depth = 0;
            label2.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            label2.MouseState = MaterialSkin.MouseState.HOVER;
            label2.Location = new Point(40, 90);
            label2.Name = "label2";
            label2.Size = new Size(110, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre del evento";
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
            // label3
            //
            label3.AutoSize = true;
            label3.Depth = 0;
            label3.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            label3.MouseState = MaterialSkin.MouseState.HOVER;
            label3.Location = new Point(40, 182);
            label3.Name = "label3";
            label3.Size = new Size(110, 15);
            label3.TabIndex = 3;
            label3.Text = "Nombre del cliente";
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
            // label4
            //
            label4.AutoSize = true;
            label4.Depth = 0;
            label4.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            label4.MouseState = MaterialSkin.MouseState.HOVER;
            label4.Location = new Point(40, 274);
            label4.Name = "label4";
            label4.Size = new Size(125, 15);
            label4.TabIndex = 5;
            label4.Text = "Fecha y hora de inicio";
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
            // label5
            //
            label5.AutoSize = true;
            label5.Depth = 0;
            label5.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            label5.MouseState = MaterialSkin.MouseState.HOVER;
            label5.Location = new Point(340, 90);
            label5.Name = "label5";
            label5.Size = new Size(100, 15);
            label5.TabIndex = 7;
            label5.Text = "Invitados adultos";
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
            // label6
            //
            label6.AutoSize = true;
            label6.Depth = 0;
            label6.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            label6.MouseState = MaterialSkin.MouseState.HOVER;
            label6.Location = new Point(340, 182);
            label6.Name = "label6";
            label6.Size = new Size(90, 15);
            label6.TabIndex = 9;
            label6.Text = "Invitados niños";
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
            // label7
            //
            label7.AutoSize = true;
            label7.Depth = 0;
            label7.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            label7.MouseState = MaterialSkin.MouseState.HOVER;
            label7.Location = new Point(340, 274);
            label7.Name = "label7";
            label7.Size = new Size(100, 15);
            label7.TabIndex = 11;
            label7.Text = "Duracion (horas)";
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
            // btnGuardarEvento
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
            // btnVolverEvento
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
            panelCrudCtrlEv.ResumeLayout(false);
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
        private Panel panelCrudCtrlEv;
        private MaterialSkin.Controls.MaterialButton btnEventRemove;
        private MaterialSkin.Controls.MaterialButton btnEventEdit;
        private MaterialSkin.Controls.MaterialButton btnEventCreate;
        private MaterialSkin.Controls.MaterialLabel label1;
        private MaterialSkin.Controls.MaterialLabel label2;
        private MaterialSkin.Controls.MaterialTextBox mtbEventName;
        private MaterialSkin.Controls.MaterialLabel label3;
        private MaterialSkin.Controls.MaterialTextBox mtbEventClient;
        private MaterialSkin.Controls.MaterialLabel label4;
        private DateTimePicker dtpEventDate;
        private MaterialSkin.Controls.MaterialLabel label5;
        private NumericUpDown nudEventAdults;
        private MaterialSkin.Controls.MaterialLabel label6;
        private NumericUpDown nudEventChildren;
        private MaterialSkin.Controls.MaterialLabel label7;
        private NumericUpDown nudEventDuration;
        private MaterialSkin.Controls.MaterialButton btnSaveEvent;
        private MaterialSkin.Controls.MaterialButton btnBackEvent;
    }
}
