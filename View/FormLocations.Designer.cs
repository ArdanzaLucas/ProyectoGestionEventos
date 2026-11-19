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
            lblLocationFormTitle = new MaterialSkin.Controls.MaterialLabel();
            lblLocationPrice = new MaterialSkin.Controls.MaterialLabel();
            nudLocationPrice = new NumericUpDown();
            lblLocationName = new MaterialSkin.Controls.MaterialLabel();
            mtbLocationName = new MaterialSkin.Controls.MaterialTextBox();
            btnSaveLocation = new MaterialSkin.Controls.MaterialButton();
            btnBack = new MaterialSkin.Controls.MaterialButton();
            panelLocationsList = new Panel();
            mtLvLocations = new MaterialSkin.Controls.MaterialListView();
            NameColumn = new ColumnHeader();
            PriceColumn = new ColumnHeader();
            panelLocationsTitle = new Panel();
            lblLocationsTitle = new MaterialSkin.Controls.MaterialLabel();
            panelCrudCtrlLocations = new Panel();
            btnLocationRemove = new MaterialSkin.Controls.MaterialButton();
            btnLocationEdit = new MaterialSkin.Controls.MaterialButton();
            btnLocationCreate = new MaterialSkin.Controls.MaterialButton();
            panelLocationsCU.SuspendLayout();
            panelUpload.SuspendLayout();
            panelLocationsList.SuspendLayout();
            panelLocationsTitle.SuspendLayout();
            panelCrudCtrlLocations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudLocationPrice).BeginInit();
            SuspendLayout();
            // 
            // panelLocationsCU
            // 
            panelLocationsCU.Controls.Add(panelUpload);
            panelLocationsCU.Location = new Point(803, 0);
            panelLocationsCU.Name = "panelLocationsCU";
            panelLocationsCU.Size = new Size(668, 720);
            panelLocationsCU.TabIndex = 4;
            // 
            // panelUpload
            // 
            panelUpload.Controls.Add(lblLocationFormTitle);
            panelUpload.Controls.Add(lblLocationPrice);
            panelUpload.Controls.Add(nudLocationPrice);
            panelUpload.Controls.Add(lblLocationName);
            panelUpload.Controls.Add(mtbLocationName);
            panelUpload.Controls.Add(btnSaveLocation);
            panelUpload.Controls.Add(btnBack);
            panelUpload.Location = new Point(0, 0);
            panelUpload.Margin = new Padding(3, 2, 3, 2);
            panelUpload.Name = "panelUpload";
            panelUpload.Size = new Size(1471, 591);
            panelUpload.TabIndex = 10;
            // 
            // lblLocationFormTitle
            // 
            lblLocationFormTitle.AutoSize = true;
            lblLocationFormTitle.Depth = 0;
            lblLocationFormTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblLocationFormTitle.MouseState = MaterialSkin.MouseState.HOVER;
            lblLocationFormTitle.Location = new Point(40, 30);
            lblLocationFormTitle.Name = "lblLocationFormTitle";
            lblLocationFormTitle.Size = new Size(307, 30);
            lblLocationFormTitle.TabIndex = 7;
            lblLocationFormTitle.Text = "Carga de ubicacion";
            // 
            // lblLocationPrice
            // 
            lblLocationPrice.AutoSize = true;
            lblLocationPrice.Depth = 0;
            lblLocationPrice.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            lblLocationPrice.MouseState = MaterialSkin.MouseState.HOVER;
            lblLocationPrice.Location = new Point(40, 182);
            lblLocationPrice.Name = "lblLocationPrice";
            lblLocationPrice.Size = new Size(377, 21);
            lblLocationPrice.TabIndex = 9;
            lblLocationPrice.Text = "Precio por hora";
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
            // lblLocationName
            // 
            lblLocationName.AutoSize = true;
            lblLocationName.Depth = 0;
            lblLocationName.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            lblLocationName.MouseState = MaterialSkin.MouseState.HOVER;
            lblLocationName.Location = new Point(40, 90);
            lblLocationName.Name = "lblLocationName";
            lblLocationName.Size = new Size(452, 21);
            lblLocationName.TabIndex = 8;
            lblLocationName.Text = "Nombre";
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
            // btnSaveLocation
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
            // btnBack
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
            // panelLocationsList
            // 
            panelLocationsList.Controls.Add(mtLvLocations);
            panelLocationsList.Controls.Add(panelLocationsTitle);
            panelLocationsList.Controls.Add(panelCrudCtrlLocations);
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
            // panelCrudCtrlLocations
            // 
            panelCrudCtrlLocations.BackColor = Color.White;
            panelCrudCtrlLocations.Controls.Add(btnLocationRemove);
            panelCrudCtrlLocations.Controls.Add(btnLocationEdit);
            panelCrudCtrlLocations.Controls.Add(btnLocationCreate);
            panelCrudCtrlLocations.Dock = DockStyle.Left;
            panelCrudCtrlLocations.Location = new Point(0, 0);
            panelCrudCtrlLocations.Name = "panelCrudCtrlLocations";
            panelCrudCtrlLocations.Size = new Size(145, 720);
            panelCrudCtrlLocations.TabIndex = 5;
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
            panelCrudCtrlLocations.ResumeLayout(false);
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
        private Panel panelCrudCtrlLocations;
        private MaterialSkin.Controls.MaterialButton btnLocationRemove;
        private MaterialSkin.Controls.MaterialButton btnLocationEdit;
        private MaterialSkin.Controls.MaterialButton btnLocationCreate;
        private NumericUpDown nudLocationPrice;
        private MaterialSkin.Controls.MaterialTextBox mtbLocationName;
        private MaterialSkin.Controls.MaterialButton btnBack;
        private MaterialSkin.Controls.MaterialButton btnSaveLocation;
        private MaterialSkin.Controls.MaterialLabel lblLocationPrice;
        private MaterialSkin.Controls.MaterialLabel lblLocationName;
        private MaterialSkin.Controls.MaterialLabel lblLocationFormTitle;
        private Panel panelUpload;
    }
}