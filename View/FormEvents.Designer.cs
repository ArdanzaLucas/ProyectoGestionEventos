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
            lblEventsTitle = new Label();
            mtLvEvents = new MaterialSkin.Controls.MaterialListView();
            NameColumn = new ColumnHeader();
            ClientColumn = new ColumnHeader();
            DateColumn = new ColumnHeader();
            AdultsColumn = new ColumnHeader();
            ChildsColumn = new ColumnHeader();
            DurationColumn = new ColumnHeader();
            panelEventsCU = new Panel();
            label1 = new Label();
            label2 = new Label();
            mtbEventName = new MaterialSkin.Controls.MaterialTextBox();
            label3 = new Label();
            mtbEventClient = new MaterialSkin.Controls.MaterialTextBox();
            label4 = new Label();
            dtpEventDate = new DateTimePicker();
            label5 = new Label();
            mtbEventAdults = new MaterialSkin.Controls.MaterialTextBox();
            label6 = new Label();
            mtbEventChilds = new MaterialSkin.Controls.MaterialTextBox();
            label7 = new Label();
            mtbEventDuration = new MaterialSkin.Controls.MaterialTextBox();
            btnGuardarEvento = new MaterialSkin.Controls.MaterialButton();
            btnVolverEvento = new MaterialSkin.Controls.MaterialButton();
            panelCrudCtrlEv.SuspendLayout();
            panelEventsList.SuspendLayout();
            panelEventsTitle.SuspendLayout();
            panelEventsCU.SuspendLayout();
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
            lblEventsTitle.Font = new Font("Georgia", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
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
            mtLvEvents.Columns.AddRange(new ColumnHeader[] { NameColumn, ClientColumn, DateColumn, AdultsColumn, ChildsColumn, DurationColumn });
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
            // ChildsColumn
            //
            ChildsColumn.Text = "Niños";
            ChildsColumn.Width = 70;
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
            panelEventsCU.Controls.Add(mtbEventAdults);
            panelEventsCU.Controls.Add(label6);
            panelEventsCU.Controls.Add(mtbEventChilds);
            panelEventsCU.Controls.Add(label7);
            panelEventsCU.Controls.Add(mtbEventDuration);
            panelEventsCU.Controls.Add(btnGuardarEvento);
            panelEventsCU.Controls.Add(btnVolverEvento);
            panelEventsCU.Location = new Point(640, 0);
            panelEventsCU.Name = "panelEventsCU";
            panelEventsCU.Size = new Size(640, 720);
            panelEventsCU.TabIndex = 2;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(78, 25);
            label1.Name = "label1";
            label1.Size = new Size(160, 24);
            label1.TabIndex = 0;
            label1.Text = "Carga de evento";
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Location = new Point(78, 80);
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
            mtbEventName.Location = new Point(78, 100);
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
            label3.Location = new Point(78, 170);
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
            mtbEventClient.Location = new Point(78, 190);
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
            label4.Location = new Point(78, 260);
            label4.Name = "label4";
            label4.Size = new Size(125, 15);
            label4.TabIndex = 5;
            label4.Text = "Fecha y hora de inicio";
            //
            // dtpEventDate
            //
            dtpEventDate.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpEventDate.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpEventDate.Format = DateTimePickerFormat.Custom;
            dtpEventDate.Location = new Point(78, 280);
            dtpEventDate.Name = "dtpEventDate";
            dtpEventDate.Size = new Size(250, 27);
            dtpEventDate.TabIndex = 6;
            //
            // label5
            //
            label5.AutoSize = true;
            label5.Location = new Point(400, 80);
            label5.Name = "label5";
            label5.Size = new Size(100, 15);
            label5.TabIndex = 7;
            label5.Text = "Invitados adultos";
            //
            // mtbEventAdults
            //
            mtbEventAdults.AnimateReadOnly = false;
            mtbEventAdults.BorderStyle = BorderStyle.None;
            mtbEventAdults.Depth = 0;
            mtbEventAdults.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            mtbEventAdults.LeadingIcon = null;
            mtbEventAdults.Location = new Point(400, 100);
            mtbEventAdults.MaxLength = 50;
            mtbEventAdults.MouseState = MaterialSkin.MouseState.OUT;
            mtbEventAdults.Multiline = false;
            mtbEventAdults.Name = "mtbEventAdults";
            mtbEventAdults.Size = new Size(150, 50);
            mtbEventAdults.TabIndex = 8;
            mtbEventAdults.Text = "";
            mtbEventAdults.TrailingIcon = null;
            //
            // label6
            //
            label6.AutoSize = true;
            label6.Location = new Point(400, 170);
            label6.Name = "label6";
            label6.Size = new Size(90, 15);
            label6.TabIndex = 9;
            label6.Text = "Invitados niños";
            //
            // mtbEventChilds
            //
            mtbEventChilds.AnimateReadOnly = false;
            mtbEventChilds.BorderStyle = BorderStyle.None;
            mtbEventChilds.Depth = 0;
            mtbEventChilds.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            mtbEventChilds.LeadingIcon = null;
            mtbEventChilds.Location = new Point(400, 190);
            mtbEventChilds.MaxLength = 50;
            mtbEventChilds.MouseState = MaterialSkin.MouseState.OUT;
            mtbEventChilds.Multiline = false;
            mtbEventChilds.Name = "mtbEventChilds";
            mtbEventChilds.Size = new Size(150, 50);
            mtbEventChilds.TabIndex = 10;
            mtbEventChilds.Text = "";
            mtbEventChilds.TrailingIcon = null;
            //
            // label7
            //
            label7.AutoSize = true;
            label7.Location = new Point(400, 260);
            label7.Name = "label7";
            label7.Size = new Size(100, 15);
            label7.TabIndex = 11;
            label7.Text = "Duracion (horas)";
            //
            // mtbEventDuration
            //
            mtbEventDuration.AnimateReadOnly = false;
            mtbEventDuration.BorderStyle = BorderStyle.None;
            mtbEventDuration.Depth = 0;
            mtbEventDuration.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            mtbEventDuration.LeadingIcon = null;
            mtbEventDuration.Location = new Point(400, 280);
            mtbEventDuration.MaxLength = 50;
            mtbEventDuration.MouseState = MaterialSkin.MouseState.OUT;
            mtbEventDuration.Multiline = false;
            mtbEventDuration.Name = "mtbEventDuration";
            mtbEventDuration.Size = new Size(150, 50);
            mtbEventDuration.TabIndex = 12;
            mtbEventDuration.Text = "";
            mtbEventDuration.TrailingIcon = null;
            //
            // btnGuardarEvento
            //
            btnGuardarEvento.AutoSize = false;
            btnGuardarEvento.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGuardarEvento.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnGuardarEvento.Depth = 0;
            btnGuardarEvento.HighEmphasis = true;
            btnGuardarEvento.Icon = null;
            btnGuardarEvento.Location = new Point(150, 400);
            btnGuardarEvento.Margin = new Padding(4, 6, 4, 6);
            btnGuardarEvento.MouseState = MaterialSkin.MouseState.HOVER;
            btnGuardarEvento.Name = "btnGuardarEvento";
            btnGuardarEvento.NoAccentTextColor = Color.Empty;
            btnGuardarEvento.Size = new Size(90, 36);
            btnGuardarEvento.TabIndex = 13;
            btnGuardarEvento.Text = "Guardar";
            btnGuardarEvento.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnGuardarEvento.UseAccentColor = false;
            btnGuardarEvento.UseVisualStyleBackColor = true;
            btnGuardarEvento.Click += btnGuardarEvento_Click;
            //
            // btnVolverEvento
            //
            btnVolverEvento.AutoSize = false;
            btnVolverEvento.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnVolverEvento.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnVolverEvento.Depth = 0;
            btnVolverEvento.HighEmphasis = true;
            btnVolverEvento.Icon = null;
            btnVolverEvento.Location = new Point(350, 400);
            btnVolverEvento.Margin = new Padding(4, 6, 4, 6);
            btnVolverEvento.MouseState = MaterialSkin.MouseState.HOVER;
            btnVolverEvento.Name = "btnVolverEvento";
            btnVolverEvento.NoAccentTextColor = Color.Empty;
            btnVolverEvento.Size = new Size(90, 36);
            btnVolverEvento.TabIndex = 14;
            btnVolverEvento.Text = "Volver";
            btnVolverEvento.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnVolverEvento.UseAccentColor = false;
            btnVolverEvento.UseVisualStyleBackColor = true;
            btnVolverEvento.Click += btnVolverEvento_Click;
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
            ResumeLayout(false);
        }

        #endregion

        private Panel panelEventsList;
        private Panel panelEventsTitle;
        private Label lblEventsTitle;
        private Panel panelEventsCU;
        private MaterialSkin.Controls.MaterialListView mtLvEvents;
        private ColumnHeader NameColumn;
        private ColumnHeader ClientColumn;
        private ColumnHeader DateColumn;
        private ColumnHeader AdultsColumn;
        private ColumnHeader ChildsColumn;
        private ColumnHeader DurationColumn;
        private Panel panelCrudCtrlEv;
        private MaterialSkin.Controls.MaterialButton btnEventRemove;
        private MaterialSkin.Controls.MaterialButton btnEventEdit;
        private MaterialSkin.Controls.MaterialButton btnEventCreate;
        private Label label1;
        private Label label2;
        private MaterialSkin.Controls.MaterialTextBox mtbEventName;
        private Label label3;
        private MaterialSkin.Controls.MaterialTextBox mtbEventClient;
        private Label label4;
        private DateTimePicker dtpEventDate;
        private Label label5;
        private MaterialSkin.Controls.MaterialTextBox mtbEventAdults;
        private Label label6;
        private MaterialSkin.Controls.MaterialTextBox mtbEventChilds;
        private Label label7;
        private MaterialSkin.Controls.MaterialTextBox mtbEventDuration;
        private MaterialSkin.Controls.MaterialButton btnGuardarEvento;
        private MaterialSkin.Controls.MaterialButton btnVolverEvento;
    }
}
