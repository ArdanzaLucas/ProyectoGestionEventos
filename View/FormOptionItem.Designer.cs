namespace ProyectoPresupuestoEvento.View
{
    partial class FormOptionItem
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
            panelOptionItemsCU = new Panel();
            panelOptionItemUpload = new Panel();
            lblOptionItemFormTitle = new MaterialSkin.Controls.MaterialLabel();
            lblOptionItemPrice = new MaterialSkin.Controls.MaterialLabel();
            nudOptionItemPrice = new NumericUpDown();
            lblOptionItemName = new MaterialSkin.Controls.MaterialLabel();
            mtbOptionItemName = new MaterialSkin.Controls.MaterialTextBox();
            btnSaveOptionItem = new MaterialSkin.Controls.MaterialButton();
            btnBack = new MaterialSkin.Controls.MaterialButton();
            panelOptionItemsList = new Panel();
            mtLvOptionItems = new MaterialSkin.Controls.MaterialListView();
            NameColumn = new ColumnHeader();
            PriceColumn = new ColumnHeader();
            panelOptionItemsTitle = new Panel();
            lblOptionItemsTitle = new MaterialSkin.Controls.MaterialLabel();
            panelCrudCtrlOptionItems = new Panel();
            btnOptionItemRemove = new MaterialSkin.Controls.MaterialButton();
            btnOptionItemEdit = new MaterialSkin.Controls.MaterialButton();
            btnOptionItemCreate = new MaterialSkin.Controls.MaterialButton();
            panelOptionItemsCU.SuspendLayout();
            panelOptionItemUpload.SuspendLayout();
            panelOptionItemsList.SuspendLayout();
            panelOptionItemsTitle.SuspendLayout();
            panelCrudCtrlOptionItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudOptionItemPrice).BeginInit();
            SuspendLayout();
            // 
            // panelOptionItemsCU
            // 
            panelOptionItemsCU.Controls.Add(panelOptionItemUpload);
            panelOptionItemsCU.Location = new Point(803, 0);
            panelOptionItemsCU.Name = "panelOptionItemsCU";
            panelOptionItemsCU.Size = new Size(668, 720);
            panelOptionItemsCU.TabIndex = 4;
            // 
            // panelOptionItemUpload
            // 
            panelOptionItemUpload.Controls.Add(lblOptionItemFormTitle);
            panelOptionItemUpload.Controls.Add(lblOptionItemPrice);
            panelOptionItemUpload.Controls.Add(nudOptionItemPrice);
            panelOptionItemUpload.Controls.Add(lblOptionItemName);
            panelOptionItemUpload.Controls.Add(mtbOptionItemName);
            panelOptionItemUpload.Controls.Add(btnSaveOptionItem);
            panelOptionItemUpload.Controls.Add(btnBack);
            panelOptionItemUpload.Location = new Point(0, 0);
            panelOptionItemUpload.Margin = new Padding(3, 2, 3, 2);
            panelOptionItemUpload.Name = "panelOptionItemUpload";
            panelOptionItemUpload.Size = new Size(1471, 591);
            panelOptionItemUpload.TabIndex = 10;
            // 
            // lblOptionItemFormTitle
            // 
            lblOptionItemFormTitle.AutoSize = true;
            lblOptionItemFormTitle.Depth = 0;
            lblOptionItemFormTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblOptionItemFormTitle.MouseState = MaterialSkin.MouseState.HOVER;
            lblOptionItemFormTitle.Location = new Point(40, 30);
            lblOptionItemFormTitle.Name = "lblOptionItemFormTitle";
            lblOptionItemFormTitle.Size = new Size(286, 30);
            lblOptionItemFormTitle.TabIndex = 7;
            lblOptionItemFormTitle.Text = "Carga de servicio";
            // 
            // lblOptionItemPrice
            // 
            lblOptionItemPrice.AutoSize = true;
            lblOptionItemPrice.Depth = 0;
            lblOptionItemPrice.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            lblOptionItemPrice.MouseState = MaterialSkin.MouseState.HOVER;
            lblOptionItemPrice.Location = new Point(40, 182);
            lblOptionItemPrice.Name = "lblOptionItemPrice";
            lblOptionItemPrice.Size = new Size(348, 21);
            lblOptionItemPrice.TabIndex = 9;
            lblOptionItemPrice.Text = "Precio";
            // 
            // nudOptionItemPrice
            // 
            nudOptionItemPrice.DecimalPlaces = 2;
            nudOptionItemPrice.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudOptionItemPrice.Location = new Point(40, 204);
            nudOptionItemPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudOptionItemPrice.Name = "nudOptionItemPrice";
            nudOptionItemPrice.Size = new Size(250, 27);
            nudOptionItemPrice.TabIndex = 0;
            // 
            // lblOptionItemName
            // 
            lblOptionItemName.AutoSize = true;
            lblOptionItemName.Depth = 0;
            lblOptionItemName.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            lblOptionItemName.MouseState = MaterialSkin.MouseState.HOVER;
            lblOptionItemName.Location = new Point(40, 90);
            lblOptionItemName.Name = "lblOptionItemName";
            lblOptionItemName.Size = new Size(424, 21);
            lblOptionItemName.TabIndex = 8;
            lblOptionItemName.Text = "Nombre";
            // 
            // mtbOptionItemName
            // 
            mtbOptionItemName.AnimateReadOnly = false;
            mtbOptionItemName.BorderStyle = BorderStyle.None;
            mtbOptionItemName.Depth = 0;
            mtbOptionItemName.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            mtbOptionItemName.LeadingIcon = null;
            mtbOptionItemName.Location = new Point(40, 112);
            mtbOptionItemName.Margin = new Padding(3, 2, 3, 2);
            mtbOptionItemName.MaxLength = 50;
            mtbOptionItemName.MouseState = MaterialSkin.MouseState.OUT;
            mtbOptionItemName.Multiline = false;
            mtbOptionItemName.Name = "mtbOptionItemName";
            mtbOptionItemName.Size = new Size(250, 50);
            mtbOptionItemName.TabIndex = 1;
            mtbOptionItemName.Text = "";
            mtbOptionItemName.TrailingIcon = null;
            // 
            // btnSaveOptionItem
            // 
            btnSaveOptionItem.AutoSize = false;
            btnSaveOptionItem.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSaveOptionItem.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSaveOptionItem.Depth = 0;
            btnSaveOptionItem.FlatStyle = FlatStyle.Popup;
            btnSaveOptionItem.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSaveOptionItem.HighEmphasis = true;
            btnSaveOptionItem.Icon = null;
            btnSaveOptionItem.Location = new Point(40, 270);
            btnSaveOptionItem.Margin = new Padding(4);
            btnSaveOptionItem.MouseState = MaterialSkin.MouseState.HOVER;
            btnSaveOptionItem.Name = "btnSaveOptionItem";
            btnSaveOptionItem.NoAccentTextColor = Color.Empty;
            btnSaveOptionItem.Size = new Size(90, 36);
            btnSaveOptionItem.TabIndex = 5;
            btnSaveOptionItem.Text = "Guardar";
            btnSaveOptionItem.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSaveOptionItem.UseAccentColor = false;
            btnSaveOptionItem.UseVisualStyleBackColor = true;
            btnSaveOptionItem.Click += btnSaveOptionItem_Click;
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
            // panelOptionItemsList
            // 
            panelOptionItemsList.Controls.Add(mtLvOptionItems);
            panelOptionItemsList.Controls.Add(panelOptionItemsTitle);
            panelOptionItemsList.Controls.Add(panelCrudCtrlOptionItems);
            panelOptionItemsList.Dock = DockStyle.Fill;
            panelOptionItemsList.Location = new Point(0, 0);
            panelOptionItemsList.Name = "panelOptionItemsList";
            panelOptionItemsList.Size = new Size(1471, 720);
            panelOptionItemsList.TabIndex = 3;
            // 
            // mtLvOptionItems
            // 
            mtLvOptionItems.AutoSizeTable = false;
            mtLvOptionItems.BackColor = Color.FromArgb(255, 255, 255);
            mtLvOptionItems.BorderStyle = BorderStyle.None;
            mtLvOptionItems.Columns.AddRange(new ColumnHeader[] { NameColumn, PriceColumn });
            mtLvOptionItems.Depth = 0;
            mtLvOptionItems.Dock = DockStyle.Fill;
            mtLvOptionItems.FullRowSelect = true;
            mtLvOptionItems.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3, listViewItem4, listViewItem5, listViewItem6, listViewItem7, listViewItem8 });
            mtLvOptionItems.Location = new Point(145, 60);
            mtLvOptionItems.MinimumSize = new Size(200, 100);
            mtLvOptionItems.MouseLocation = new Point(-1, -1);
            mtLvOptionItems.MouseState = MaterialSkin.MouseState.OUT;
            mtLvOptionItems.Name = "mtLvOptionItems";
            mtLvOptionItems.OwnerDraw = true;
            mtLvOptionItems.Size = new Size(1326, 660);
            mtLvOptionItems.TabIndex = 1;
            mtLvOptionItems.UseCompatibleStateImageBehavior = false;
            mtLvOptionItems.View = System.Windows.Forms.View.Details;
            mtLvOptionItems.DoubleClick += mtLvOptionItems_DoubleClick;
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
            // panelOptionItemsTitle
            // 
            panelOptionItemsTitle.BackColor = Color.White;
            panelOptionItemsTitle.Controls.Add(lblOptionItemsTitle);
            panelOptionItemsTitle.Dock = DockStyle.Top;
            panelOptionItemsTitle.Location = new Point(145, 0);
            panelOptionItemsTitle.Name = "panelOptionItemsTitle";
            panelOptionItemsTitle.Size = new Size(1326, 60);
            panelOptionItemsTitle.TabIndex = 6;
            // 
            // lblOptionItemsTitle
            // 
            lblOptionItemsTitle.AutoSize = true;
            lblOptionItemsTitle.Depth = 0;
            lblOptionItemsTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblOptionItemsTitle.MouseState = MaterialSkin.MouseState.HOVER;
            lblOptionItemsTitle.Location = new Point(15, 10);
            lblOptionItemsTitle.Name = "lblOptionItemsTitle";
            lblOptionItemsTitle.Size = new Size(195, 24);
            lblOptionItemsTitle.TabIndex = 0;
            lblOptionItemsTitle.Text = "Servicios adicionales";
            // 
            // panelCrudCtrlOptionItems
            // 
            panelCrudCtrlOptionItems.BackColor = Color.White;
            panelCrudCtrlOptionItems.Controls.Add(btnOptionItemRemove);
            panelCrudCtrlOptionItems.Controls.Add(btnOptionItemEdit);
            panelCrudCtrlOptionItems.Controls.Add(btnOptionItemCreate);
            panelCrudCtrlOptionItems.Dock = DockStyle.Left;
            panelCrudCtrlOptionItems.Location = new Point(0, 0);
            panelCrudCtrlOptionItems.Name = "panelCrudCtrlOptionItems";
            panelCrudCtrlOptionItems.Size = new Size(145, 720);
            panelCrudCtrlOptionItems.TabIndex = 5;
            // 
            // btnOptionItemRemove
            // 
            btnOptionItemRemove.AutoSize = false;
            btnOptionItemRemove.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnOptionItemRemove.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnOptionItemRemove.Depth = 0;
            btnOptionItemRemove.HighEmphasis = true;
            btnOptionItemRemove.Icon = null;
            btnOptionItemRemove.Location = new Point(36, 346);
            btnOptionItemRemove.Margin = new Padding(4, 6, 4, 6);
            btnOptionItemRemove.MouseState = MaterialSkin.MouseState.HOVER;
            btnOptionItemRemove.Name = "btnOptionItemRemove";
            btnOptionItemRemove.NoAccentTextColor = Color.Empty;
            btnOptionItemRemove.Size = new Size(90, 36);
            btnOptionItemRemove.TabIndex = 2;
            btnOptionItemRemove.Text = "Eliminar";
            btnOptionItemRemove.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnOptionItemRemove.UseAccentColor = false;
            btnOptionItemRemove.UseVisualStyleBackColor = true;
            btnOptionItemRemove.Click += btnOptionItemRemove_Click;
            // 
            // btnOptionItemEdit
            // 
            btnOptionItemEdit.AutoSize = false;
            btnOptionItemEdit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnOptionItemEdit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnOptionItemEdit.Depth = 0;
            btnOptionItemEdit.HighEmphasis = true;
            btnOptionItemEdit.Icon = null;
            btnOptionItemEdit.Location = new Point(36, 238);
            btnOptionItemEdit.Margin = new Padding(4, 6, 4, 6);
            btnOptionItemEdit.MouseState = MaterialSkin.MouseState.HOVER;
            btnOptionItemEdit.Name = "btnOptionItemEdit";
            btnOptionItemEdit.NoAccentTextColor = Color.Empty;
            btnOptionItemEdit.Size = new Size(90, 36);
            btnOptionItemEdit.TabIndex = 1;
            btnOptionItemEdit.Text = "Editar";
            btnOptionItemEdit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnOptionItemEdit.UseAccentColor = false;
            btnOptionItemEdit.UseVisualStyleBackColor = true;
            btnOptionItemEdit.Click += btnOptionItemEdit_Click;
            // 
            // btnOptionItemCreate
            // 
            btnOptionItemCreate.AutoSize = false;
            btnOptionItemCreate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnOptionItemCreate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnOptionItemCreate.Depth = 0;
            btnOptionItemCreate.HighEmphasis = true;
            btnOptionItemCreate.Icon = null;
            btnOptionItemCreate.Location = new Point(36, 115);
            btnOptionItemCreate.Margin = new Padding(4, 6, 4, 6);
            btnOptionItemCreate.MouseState = MaterialSkin.MouseState.HOVER;
            btnOptionItemCreate.Name = "btnOptionItemCreate";
            btnOptionItemCreate.NoAccentTextColor = Color.Empty;
            btnOptionItemCreate.Size = new Size(90, 36);
            btnOptionItemCreate.TabIndex = 0;
            btnOptionItemCreate.Text = "Crear";
            btnOptionItemCreate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnOptionItemCreate.UseAccentColor = false;
            btnOptionItemCreate.UseVisualStyleBackColor = true;
            btnOptionItemCreate.Click += btnOptionItemCreate_Click;
            // 
            // FormOptionItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1471, 720);
            Controls.Add(panelOptionItemsCU);
            Controls.Add(panelOptionItemsList);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormOptionItem";
            Text = "FormOptionItem";
            Load += FormOptionItem_Load;
            panelOptionItemsCU.ResumeLayout(false);
            panelOptionItemUpload.ResumeLayout(false);
            panelOptionItemUpload.PerformLayout();
            panelOptionItemsList.ResumeLayout(false);
            panelOptionItemsTitle.ResumeLayout(false);
            panelOptionItemsTitle.PerformLayout();
            panelCrudCtrlOptionItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudOptionItemPrice).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelOptionItemsCU;
        private Panel panelOptionItemsList;
        private Panel panelOptionItemsTitle;
        private MaterialSkin.Controls.MaterialLabel lblOptionItemsTitle;
        private MaterialSkin.Controls.MaterialListView mtLvOptionItems;
        private ColumnHeader NameColumn;
        private ColumnHeader PriceColumn;
        private Panel panelCrudCtrlOptionItems;
        private MaterialSkin.Controls.MaterialButton btnOptionItemRemove;
        private MaterialSkin.Controls.MaterialButton btnOptionItemEdit;
        private MaterialSkin.Controls.MaterialButton btnOptionItemCreate;
        private NumericUpDown nudOptionItemPrice;
        private MaterialSkin.Controls.MaterialTextBox mtbOptionItemName;
        private MaterialSkin.Controls.MaterialButton btnBack;
        private MaterialSkin.Controls.MaterialButton btnSaveOptionItem;
        private MaterialSkin.Controls.MaterialLabel lblOptionItemPrice;
        private MaterialSkin.Controls.MaterialLabel lblOptionItemName;
        private MaterialSkin.Controls.MaterialLabel lblOptionItemFormTitle;
        private Panel panelOptionItemUpload;
    }
}