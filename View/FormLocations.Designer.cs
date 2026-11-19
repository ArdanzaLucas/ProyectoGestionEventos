namespace ProyectoPresupuestoEvento.View
{
    partial class FormLocations
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
            panelLocationsCU = new Panel();
            panelUpload = new Panel();
            label1 = new MaterialSkin.Controls.MaterialLabel();
            label3 = new MaterialSkin.Controls.MaterialLabel();
            nudLocationPrice = new NumericUpDown();
            label2 = new MaterialSkin.Controls.MaterialLabel();
            mtbLocationName = new MaterialSkin.Controls.MaterialTextBox();
            btnSaveLocation = new MaterialSkin.Controls.MaterialButton();
            btnBack = new MaterialSkin.Controls.MaterialButton();
            panelLocationsList = new Panel();
            mtLvLocations = new MaterialSkin.Controls.MaterialListView();
            NameColumn = new ColumnHeader();
            PriceColumn = new ColumnHeader();
            panelLocationsTitle = new Panel();
            lblLocationsTitle = new MaterialSkin.Controls.MaterialLabel();
            panelCrudCtrlUb = new Panel();
            btnLocationRemove = new MaterialSkin.Controls.MaterialButton();
            btnLocationEdit = new MaterialSkin.Controls.MaterialButton();
            btnLocationCreate = new MaterialSkin.Controls.MaterialButton();
            panelLocationsCU.SuspendLayout();
            panelUpload.SuspendLayout();
            panelLocationsList.SuspendLayout();
            panelLocationsTitle.SuspendLayout();
            panelCrudCtrlUb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudLocationPrice).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panelLocationsCU.Controls.Add(panelUpload);
            panelLocationsCU.Location = new Point(803, 0);
            panelLocationsCU.Name = "panelLocationsCU";
            panelLocationsCU.Size = new Size(668, 720);
            panelLocationsCU.TabIndex = 4;
            // 
            // panelUpload
            // 
            panelUpload.Controls.Add(label1);
            panelUpload.Controls.Add(label3);
            panelUpload.Controls.Add(nudLocationPrice);
            panelUpload.Controls.Add(label2);
            panelUpload.Controls.Add(mtbLocationName);
            panelUpload.Controls.Add(btnSaveLocation);
            panelUpload.Controls.Add(btnBack);
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
            // nudLocationPrice
            // 
            nudLocationPrice.DecimalPlaces = 2;
            nudLocationPrice.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudLocationPrice.Location = new Point(40, 204);
            nudLocationPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudLocationPrice.Name = "nudLocationPrice";
            nudLocationPrice.Size = new Size(250, 27);
            nudLocationPrice.TabIndex = 0;
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
            // mtbLocationName
            // 
            mtbLocationName.AnimateReadOnly = false;
            mtbLocationName.BorderStyle = BorderStyle.None;
            mtbLocationName.Depth = 0;
            mtbLocationName.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            mtbLocationName.LeadingIcon = null;
            mtbLocationName.Location = new Point(40, 112);
            mtbLocationName.Margin = new Padding(3, 2, 3, 2);
            mtbLocationName.MaxLength = 50;
            mtbLocationName.MouseState = MaterialSkin.MouseState.OUT;
            mtbLocationName.Multiline = false;
            mtbLocationName.Name = "mtbLocationName";
            mtbLocationName.Size = new Size(250, 50);
            mtbLocationName.TabIndex = 1;
            mtbLocationName.Text = "";
            mtbLocationName.TrailingIcon = null;
            // 
            // btnGuardarUbicacion
            // 
            btnSaveLocation.AutoSize = false;
            btnSaveLocation.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSaveLocation.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSaveLocation.Depth = 0;
            btnSaveLocation.FlatStyle = FlatStyle.Popup;
            btnSaveLocation.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSaveLocation.HighEmphasis = true;
            btnSaveLocation.Icon = null;
            btnSaveLocation.Location = new Point(40, 270);
            btnSaveLocation.Margin = new Padding(4);
            btnSaveLocation.MouseState = MaterialSkin.MouseState.HOVER;
            btnSaveLocation.Name = "btnSaveLocation";
            btnSaveLocation.NoAccentTextColor = Color.Empty;
            btnSaveLocation.Size = new Size(90, 36);
            btnSaveLocation.TabIndex = 5;
            btnSaveLocation.Text = "Guardar";
            btnSaveLocation.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSaveLocation.UseAccentColor = false;
            btnSaveLocation.UseVisualStyleBackColor = true;
            btnSaveLocation.Click += btnSaveLocation_Click;
            // 
            // btnVolverAtras
            // 
            btnBack.AutoSize = false;
            btnBack.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBack.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBack.Depth = 0;
            btnBack.HighEmphasis = true;
            btnBack.Icon = null;
            btnBack.Location = new Point(200, 270);
            btnBack.Margin = new Padding(4);
            btnBack.MinimumSize = new Size(77, 0);
            btnBack.MouseState = MaterialSkin.MouseState.HOVER;
            btnBack.Name = "btnBack";
            btnBack.NoAccentTextColor = Color.Empty;
            btnBack.Size = new Size(90, 36);
            btnBack.TabIndex = 6;
            btnBack.Text = "Volver";
            btnBack.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnBack.UseAccentColor = false;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // panel2
            // 
            panelLocationsList.Controls.Add(mtLvLocations);
            panelLocationsList.Controls.Add(panelLocationsTitle);
            panelLocationsList.Controls.Add(panelCrudCtrlUb);
            panelLocationsList.Dock = DockStyle.Fill;
            panelLocationsList.Location = new Point(0, 0);
            panelLocationsList.Name = "panelLocationsList";
            panelLocationsList.Size = new Size(1471, 720);
            panelLocationsList.TabIndex = 3;
            // 
            // mtLvLocations
            // 
            mtLvLocations.AutoSizeTable = false;
            mtLvLocations.BackColor = Color.FromArgb(255, 255, 255);
            mtLvLocations.BorderStyle = BorderStyle.None;
            mtLvLocations.Columns.AddRange(new ColumnHeader[] { NameColumn, PriceColumn });
            mtLvLocations.Depth = 0;
            mtLvLocations.Dock = DockStyle.Fill;
            mtLvLocations.FullRowSelect = true;
            mtLvLocations.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3, listViewItem4, listViewItem5, listViewItem6, listViewItem7, listViewItem8 });
            mtLvLocations.Location = new Point(145, 60);
            mtLvLocations.MinimumSize = new Size(200, 100);
            mtLvLocations.MouseLocation = new Point(-1, -1);
            mtLvLocations.MouseState = MaterialSkin.MouseState.OUT;
            mtLvLocations.Name = "mtLvLocations";
            mtLvLocations.OwnerDraw = true;
            mtLvLocations.Size = new Size(1326, 660);
            mtLvLocations.TabIndex = 1;
            mtLvLocations.UseCompatibleStateImageBehavior = false;
            mtLvLocations.View = System.Windows.Forms.View.Details;
            mtLvLocations.DoubleClick += mtLvLocations_DoubleClick;
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
            // panelLocationsTitle
            // 
            panelLocationsTitle.BackColor = Color.White;
            panelLocationsTitle.Controls.Add(lblLocationsTitle);
            panelLocationsTitle.Dock = DockStyle.Top;
            panelLocationsTitle.Location = new Point(145, 0);
            panelLocationsTitle.Name = "panelLocationsTitle";
            panelLocationsTitle.Size = new Size(1326, 60);
            panelLocationsTitle.TabIndex = 6;
            // 
            // lblLocationsTitle
            // 
            lblLocationsTitle.AutoSize = true;
            lblLocationsTitle.Depth = 0;
            lblLocationsTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblLocationsTitle.MouseState = MaterialSkin.MouseState.HOVER;
            lblLocationsTitle.Location = new Point(15, 10);
            lblLocationsTitle.Name = "lblLocationsTitle";
            lblLocationsTitle.Size = new Size(118, 24);
            lblLocationsTitle.TabIndex = 0;
            lblLocationsTitle.Text = "Ubicaciones";
            // 
            // panelCrudCtrlUb
            // 
            panelCrudCtrlUb.BackColor = Color.White;
            panelCrudCtrlUb.Controls.Add(btnLocationRemove);
            panelCrudCtrlUb.Controls.Add(btnLocationEdit);
            panelCrudCtrlUb.Controls.Add(btnLocationCreate);
            panelCrudCtrlUb.Dock = DockStyle.Left;
            panelCrudCtrlUb.Location = new Point(0, 0);
            panelCrudCtrlUb.Name = "panelCrudCtrlUb";
            panelCrudCtrlUb.Size = new Size(145, 720);
            panelCrudCtrlUb.TabIndex = 5;
            // 
            // btnLocationRemove
            // 
            btnLocationRemove.AutoSize = false;
            btnLocationRemove.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLocationRemove.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnLocationRemove.Depth = 0;
            btnLocationRemove.HighEmphasis = true;
            btnLocationRemove.Icon = null;
            btnLocationRemove.Location = new Point(36, 346);
            btnLocationRemove.Margin = new Padding(4, 6, 4, 6);
            btnLocationRemove.MouseState = MaterialSkin.MouseState.HOVER;
            btnLocationRemove.Name = "btnLocationRemove";
            btnLocationRemove.NoAccentTextColor = Color.Empty;
            btnLocationRemove.Size = new Size(90, 36);
            btnLocationRemove.TabIndex = 2;
            btnLocationRemove.Text = "Eliminar";
            btnLocationRemove.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnLocationRemove.UseAccentColor = false;
            btnLocationRemove.UseVisualStyleBackColor = true;
            btnLocationRemove.Click += btnLocationRemove_Click;
            // 
            // btnLocationEdit
            // 
            btnLocationEdit.AutoSize = false;
            btnLocationEdit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLocationEdit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnLocationEdit.Depth = 0;
            btnLocationEdit.HighEmphasis = true;
            btnLocationEdit.Icon = null;
            btnLocationEdit.Location = new Point(36, 238);
            btnLocationEdit.Margin = new Padding(4, 6, 4, 6);
            btnLocationEdit.MouseState = MaterialSkin.MouseState.HOVER;
            btnLocationEdit.Name = "btnLocationEdit";
            btnLocationEdit.NoAccentTextColor = Color.Empty;
            btnLocationEdit.Size = new Size(90, 36);
            btnLocationEdit.TabIndex = 1;
            btnLocationEdit.Text = "Editar";
            btnLocationEdit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnLocationEdit.UseAccentColor = false;
            btnLocationEdit.UseVisualStyleBackColor = true;
            btnLocationEdit.Click += btnLocationEdit_Click;
            // 
            // btnLocationCreate
            // 
            btnLocationCreate.AutoSize = false;
            btnLocationCreate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLocationCreate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnLocationCreate.Depth = 0;
            btnLocationCreate.HighEmphasis = true;
            btnLocationCreate.Icon = null;
            btnLocationCreate.Location = new Point(36, 115);
            btnLocationCreate.Margin = new Padding(4, 6, 4, 6);
            btnLocationCreate.MouseState = MaterialSkin.MouseState.HOVER;
            btnLocationCreate.Name = "btnLocationCreate";
            btnLocationCreate.NoAccentTextColor = Color.Empty;
            btnLocationCreate.Size = new Size(90, 36);
            btnLocationCreate.TabIndex = 0;
            btnLocationCreate.Text = "Crear";
            btnLocationCreate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnLocationCreate.UseAccentColor = false;
            btnLocationCreate.UseVisualStyleBackColor = true;
            btnLocationCreate.Click += btnLocationCreate_Click;
            // 
            // FormLocations
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1471, 720);
            Controls.Add(panelLocationsCU);
            Controls.Add(panelLocationsList);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormLocations";
            Text = "FormLocations";
            Load += FormLocations_Load;
            panelLocationsCU.ResumeLayout(false);
            panelUpload.ResumeLayout(false);
            panelUpload.PerformLayout();
            panelLocationsList.ResumeLayout(false);
            panelLocationsTitle.ResumeLayout(false);
            panelLocationsTitle.PerformLayout();
            panelCrudCtrlUb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudLocationPrice).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelLocationsCU;
        private Panel panelLocationsList;
        private Panel panelLocationsTitle;
        private MaterialSkin.Controls.MaterialLabel lblLocationsTitle;
        private MaterialSkin.Controls.MaterialListView mtLvLocations;
        private ColumnHeader NameColumn;
        private ColumnHeader PriceColumn;
        private Panel panelCrudCtrlUb;
        private MaterialSkin.Controls.MaterialButton btnLocationRemove;
        private MaterialSkin.Controls.MaterialButton btnLocationEdit;
        private MaterialSkin.Controls.MaterialButton btnLocationCreate;
        private NumericUpDown nudLocationPrice;
        private MaterialSkin.Controls.MaterialTextBox mtbLocationName;
        private MaterialSkin.Controls.MaterialButton btnBack;
        private MaterialSkin.Controls.MaterialButton btnSaveLocation;
        private MaterialSkin.Controls.MaterialLabel label3;
        private MaterialSkin.Controls.MaterialLabel label2;
        private MaterialSkin.Controls.MaterialLabel label1;
        private Panel panelUpload;
    }
}