namespace ProyectoPresupuestoEvento.View
{
    partial class FormUbications
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
            ListViewItem listViewItem1 = new ListViewItem("");
            ListViewItem listViewItem2 = new ListViewItem("");
            ListViewItem listViewItem3 = new ListViewItem("");
            ListViewItem listViewItem4 = new ListViewItem("");
            ListViewItem listViewItem5 = new ListViewItem("");
            ListViewItem listViewItem6 = new ListViewItem("");
            ListViewItem listViewItem7 = new ListViewItem("");
            ListViewItem listViewItem8 = new ListViewItem("");
            panel3 = new Panel();
            panelUpload = new Panel();
            label1 = new MaterialSkin.Controls.MaterialLabel();
            label3 = new MaterialSkin.Controls.MaterialLabel();
            nudUbicationPrice = new NumericUpDown();
            label2 = new MaterialSkin.Controls.MaterialLabel();
            mtbUbicationName = new MaterialSkin.Controls.MaterialTextBox();
            btnGuardarUbicacion = new MaterialSkin.Controls.MaterialButton();
            btnVolverAtras = new MaterialSkin.Controls.MaterialButton();
            panel2 = new Panel();
            mtLvUbications = new MaterialSkin.Controls.MaterialListView();
            NameColumn = new ColumnHeader();
            PriceColumn = new ColumnHeader();
            panelUbicationsTitle = new Panel();
            lblUbicationsTitle = new MaterialSkin.Controls.MaterialLabel();
            panelCrudCtrlUb = new Panel();
            btnUbicationRemove = new MaterialSkin.Controls.MaterialButton();
            btnUbicationEdit = new MaterialSkin.Controls.MaterialButton();
            btnUbicationCreate = new MaterialSkin.Controls.MaterialButton();
            panel3.SuspendLayout();
            panelUpload.SuspendLayout();
            panel2.SuspendLayout();
            panelUbicationsTitle.SuspendLayout();
            panelCrudCtrlUb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudUbicationPrice).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.Controls.Add(panelUpload);
            panel3.Location = new Point(803, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(668, 720);
            panel3.TabIndex = 4;
            // 
            // panelUpload
            // 
            panelUpload.Controls.Add(label1);
            panelUpload.Controls.Add(label3);
            panelUpload.Controls.Add(nudUbicationPrice);
            panelUpload.Controls.Add(label2);
            panelUpload.Controls.Add(mtbUbicationName);
            panelUpload.Controls.Add(btnGuardarUbicacion);
            panelUpload.Controls.Add(btnVolverAtras);
            panelUpload.Location = new Point(0, 0);
            panelUpload.Margin = new Padding(3, 2, 3, 2);
            panelUpload.Name = "panelUpload";
            panelUpload.Size = new Size(1471, 591);
            panelUpload.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Depth = 0;
            label1.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            label1.MouseState = MaterialSkin.MouseState.HOVER;
            label1.Location = new Point(40, 30);
            label1.Name = "label1";
            label1.Size = new Size(307, 30);
            label1.TabIndex = 7;
            label1.Text = "Carga de ubicacion";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Depth = 0;
            label3.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            label3.MouseState = MaterialSkin.MouseState.HOVER;
            label3.Location = new Point(40, 182);
            label3.Name = "label3";
            label3.Size = new Size(377, 21);
            label3.TabIndex = 9;
            label3.Text = "Precio por hora";
            // 
            // nudUbicationPrice
            // 
            nudUbicationPrice.DecimalPlaces = 2;
            nudUbicationPrice.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudUbicationPrice.Location = new Point(40, 204);
            nudUbicationPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudUbicationPrice.Name = "nudUbicationPrice";
            nudUbicationPrice.Size = new Size(250, 27);
            nudUbicationPrice.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Depth = 0;
            label2.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            label2.MouseState = MaterialSkin.MouseState.HOVER;
            label2.Location = new Point(40, 90);
            label2.Name = "label2";
            label2.Size = new Size(452, 21);
            label2.TabIndex = 8;
            label2.Text = "Nombre";
            // 
            // mtbUbicationName
            // 
            mtbUbicationName.AnimateReadOnly = false;
            mtbUbicationName.BorderStyle = BorderStyle.None;
            mtbUbicationName.Depth = 0;
            mtbUbicationName.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            mtbUbicationName.LeadingIcon = null;
            mtbUbicationName.Location = new Point(40, 112);
            mtbUbicationName.Margin = new Padding(3, 2, 3, 2);
            mtbUbicationName.MaxLength = 50;
            mtbUbicationName.MouseState = MaterialSkin.MouseState.OUT;
            mtbUbicationName.Multiline = false;
            mtbUbicationName.Name = "mtbUbicationName";
            mtbUbicationName.Size = new Size(250, 50);
            mtbUbicationName.TabIndex = 1;
            mtbUbicationName.Text = "";
            mtbUbicationName.TrailingIcon = null;
            // 
            // btnGuardarUbicacion
            // 
            btnGuardarUbicacion.AutoSize = false;
            btnGuardarUbicacion.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGuardarUbicacion.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnGuardarUbicacion.Depth = 0;
            btnGuardarUbicacion.FlatStyle = FlatStyle.Popup;
            btnGuardarUbicacion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardarUbicacion.HighEmphasis = true;
            btnGuardarUbicacion.Icon = null;
            btnGuardarUbicacion.Location = new Point(40, 270);
            btnGuardarUbicacion.Margin = new Padding(4);
            btnGuardarUbicacion.MouseState = MaterialSkin.MouseState.HOVER;
            btnGuardarUbicacion.Name = "btnGuardarUbicacion";
            btnGuardarUbicacion.NoAccentTextColor = Color.Empty;
            btnGuardarUbicacion.Size = new Size(90, 36);
            btnGuardarUbicacion.TabIndex = 5;
            btnGuardarUbicacion.Text = "Guardar";
            btnGuardarUbicacion.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnGuardarUbicacion.UseAccentColor = false;
            btnGuardarUbicacion.UseVisualStyleBackColor = true;
            btnGuardarUbicacion.Click += btnGuardarUbicacion_Click;
            // 
            // btnVolverAtras
            // 
            btnVolverAtras.AutoSize = false;
            btnVolverAtras.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnVolverAtras.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnVolverAtras.Depth = 0;
            btnVolverAtras.HighEmphasis = true;
            btnVolverAtras.Icon = null;
            btnVolverAtras.Location = new Point(200, 270);
            btnVolverAtras.Margin = new Padding(4);
            btnVolverAtras.MinimumSize = new Size(77, 0);
            btnVolverAtras.MouseState = MaterialSkin.MouseState.HOVER;
            btnVolverAtras.Name = "btnVolverAtras";
            btnVolverAtras.NoAccentTextColor = Color.Empty;
            btnVolverAtras.Size = new Size(90, 36);
            btnVolverAtras.TabIndex = 6;
            btnVolverAtras.Text = "Volver";
            btnVolverAtras.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnVolverAtras.UseAccentColor = false;
            btnVolverAtras.UseVisualStyleBackColor = true;
            btnVolverAtras.Click += btnVolverAtras_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(mtLvUbications);
            panel2.Controls.Add(panelUbicationsTitle);
            panel2.Controls.Add(panelCrudCtrlUb);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1471, 720);
            panel2.TabIndex = 3;
            // 
            // mtLvUbications
            // 
            mtLvUbications.AutoSizeTable = false;
            mtLvUbications.BackColor = Color.FromArgb(255, 255, 255);
            mtLvUbications.BorderStyle = BorderStyle.None;
            mtLvUbications.Columns.AddRange(new ColumnHeader[] { NameColumn, PriceColumn });
            mtLvUbications.Depth = 0;
            mtLvUbications.Dock = DockStyle.Fill;
            mtLvUbications.FullRowSelect = true;
            mtLvUbications.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3, listViewItem4, listViewItem5, listViewItem6, listViewItem7, listViewItem8 });
            mtLvUbications.Location = new Point(145, 60);
            mtLvUbications.MinimumSize = new Size(200, 100);
            mtLvUbications.MouseLocation = new Point(-1, -1);
            mtLvUbications.MouseState = MaterialSkin.MouseState.OUT;
            mtLvUbications.Name = "mtLvUbications";
            mtLvUbications.OwnerDraw = true;
            mtLvUbications.Size = new Size(1326, 660);
            mtLvUbications.TabIndex = 1;
            mtLvUbications.UseCompatibleStateImageBehavior = false;
            mtLvUbications.View = System.Windows.Forms.View.Details;
            mtLvUbications.DoubleClick += mtLvUbications_DoubleClick;
            // 
            // NameColumn
            // 
            NameColumn.Text = "Nombre";
            NameColumn.TextAlign = HorizontalAlignment.Center;
            NameColumn.Width = 300;
            // 
            // PriceColumn
            // 
            PriceColumn.Text = "Precio";
            PriceColumn.TextAlign = HorizontalAlignment.Center;
            PriceColumn.Width = 300;
            // 
            // panelUbicationsTitle
            // 
            panelUbicationsTitle.BackColor = Color.White;
            panelUbicationsTitle.Controls.Add(lblUbicationsTitle);
            panelUbicationsTitle.Dock = DockStyle.Top;
            panelUbicationsTitle.Location = new Point(145, 0);
            panelUbicationsTitle.Name = "panelUbicationsTitle";
            panelUbicationsTitle.Size = new Size(1326, 60);
            panelUbicationsTitle.TabIndex = 6;
            // 
            // lblUbicationsTitle
            // 
            lblUbicationsTitle.AutoSize = true;
            lblUbicationsTitle.Depth = 0;
            lblUbicationsTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblUbicationsTitle.MouseState = MaterialSkin.MouseState.HOVER;
            lblUbicationsTitle.Location = new Point(15, 10);
            lblUbicationsTitle.Name = "lblUbicationsTitle";
            lblUbicationsTitle.Size = new Size(118, 24);
            lblUbicationsTitle.TabIndex = 0;
            lblUbicationsTitle.Text = "Ubicaciones";
            // 
            // panelCrudCtrlUb
            // 
            panelCrudCtrlUb.BackColor = Color.White;
            panelCrudCtrlUb.Controls.Add(btnUbicationRemove);
            panelCrudCtrlUb.Controls.Add(btnUbicationEdit);
            panelCrudCtrlUb.Controls.Add(btnUbicationCreate);
            panelCrudCtrlUb.Dock = DockStyle.Left;
            panelCrudCtrlUb.Location = new Point(0, 0);
            panelCrudCtrlUb.Name = "panelCrudCtrlUb";
            panelCrudCtrlUb.Size = new Size(145, 720);
            panelCrudCtrlUb.TabIndex = 5;
            // 
            // btnUbicationRemove
            // 
            btnUbicationRemove.AutoSize = false;
            btnUbicationRemove.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnUbicationRemove.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnUbicationRemove.Depth = 0;
            btnUbicationRemove.HighEmphasis = true;
            btnUbicationRemove.Icon = null;
            btnUbicationRemove.Location = new Point(36, 346);
            btnUbicationRemove.Margin = new Padding(4, 6, 4, 6);
            btnUbicationRemove.MouseState = MaterialSkin.MouseState.HOVER;
            btnUbicationRemove.Name = "btnUbicationRemove";
            btnUbicationRemove.NoAccentTextColor = Color.Empty;
            btnUbicationRemove.Size = new Size(90, 36);
            btnUbicationRemove.TabIndex = 2;
            btnUbicationRemove.Text = "Eliminar";
            btnUbicationRemove.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnUbicationRemove.UseAccentColor = false;
            btnUbicationRemove.UseVisualStyleBackColor = true;
            btnUbicationRemove.Click += btnUbicationRemove_Click;
            // 
            // btnUbicationEdit
            // 
            btnUbicationEdit.AutoSize = false;
            btnUbicationEdit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnUbicationEdit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnUbicationEdit.Depth = 0;
            btnUbicationEdit.HighEmphasis = true;
            btnUbicationEdit.Icon = null;
            btnUbicationEdit.Location = new Point(36, 238);
            btnUbicationEdit.Margin = new Padding(4, 6, 4, 6);
            btnUbicationEdit.MouseState = MaterialSkin.MouseState.HOVER;
            btnUbicationEdit.Name = "btnUbicationEdit";
            btnUbicationEdit.NoAccentTextColor = Color.Empty;
            btnUbicationEdit.Size = new Size(90, 36);
            btnUbicationEdit.TabIndex = 1;
            btnUbicationEdit.Text = "Editar";
            btnUbicationEdit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnUbicationEdit.UseAccentColor = false;
            btnUbicationEdit.UseVisualStyleBackColor = true;
            btnUbicationEdit.Click += btnUbicationEdit_Click;
            // 
            // btnUbicationCreate
            // 
            btnUbicationCreate.AutoSize = false;
            btnUbicationCreate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnUbicationCreate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnUbicationCreate.Depth = 0;
            btnUbicationCreate.HighEmphasis = true;
            btnUbicationCreate.Icon = null;
            btnUbicationCreate.Location = new Point(36, 115);
            btnUbicationCreate.Margin = new Padding(4, 6, 4, 6);
            btnUbicationCreate.MouseState = MaterialSkin.MouseState.HOVER;
            btnUbicationCreate.Name = "btnUbicationCreate";
            btnUbicationCreate.NoAccentTextColor = Color.Empty;
            btnUbicationCreate.Size = new Size(90, 36);
            btnUbicationCreate.TabIndex = 0;
            btnUbicationCreate.Text = "Crear";
            btnUbicationCreate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnUbicationCreate.UseAccentColor = false;
            btnUbicationCreate.UseVisualStyleBackColor = true;
            btnUbicationCreate.Click += btnUbicationCreate_Click;
            // 
            // FormUbications
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1471, 720);
            Controls.Add(panel3);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormUbications";
            Text = "FormUbications";
            Load += FormUbications_Load;
            panel3.ResumeLayout(false);
            panelUpload.ResumeLayout(false);
            panelUpload.PerformLayout();
            panel2.ResumeLayout(false);
            panelUbicationsTitle.ResumeLayout(false);
            panelUbicationsTitle.PerformLayout();
            panelCrudCtrlUb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudUbicationPrice).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private Panel panel2;
        private Panel panelUbicationsTitle;
        private MaterialSkin.Controls.MaterialLabel lblUbicationsTitle;
        private MaterialSkin.Controls.MaterialListView mtLvUbications;
        private ColumnHeader NameColumn;
        private ColumnHeader PriceColumn;
        private Panel panelCrudCtrlUb;
        private MaterialSkin.Controls.MaterialButton btnUbicationRemove;
        private MaterialSkin.Controls.MaterialButton btnUbicationEdit;
        private MaterialSkin.Controls.MaterialButton btnUbicationCreate;
        private NumericUpDown nudUbicationPrice;
        private MaterialSkin.Controls.MaterialTextBox mtbUbicationName;
        private MaterialSkin.Controls.MaterialButton btnVolverAtras;
        private MaterialSkin.Controls.MaterialButton btnGuardarUbicacion;
        private MaterialSkin.Controls.MaterialLabel label3;
        private MaterialSkin.Controls.MaterialLabel label2;
        private MaterialSkin.Controls.MaterialLabel label1;
        private Panel panelUpload;
    }
}