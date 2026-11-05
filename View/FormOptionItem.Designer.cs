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
            panelOICU = new Panel();
            panelOIUpload = new Panel();
            label1 = new Label();
            label3 = new Label();
            mtbOIPrice = new MaterialSkin.Controls.MaterialTextBox();
            label2 = new Label();
            mtbOIName = new MaterialSkin.Controls.MaterialTextBox();
            btnGuardarOI = new MaterialSkin.Controls.MaterialButton();
            btnVolverAtras = new MaterialSkin.Controls.MaterialButton();
            panelOIList = new Panel();
            mtLvOptionItems = new MaterialSkin.Controls.MaterialListView();
            IdColumn = new ColumnHeader();
            NameColumn = new ColumnHeader();
            PriceColumn = new ColumnHeader();
            panelOITitle = new Panel();
            lblOITitle = new Label();
            panelCrudCtrlOI = new Panel();
            btnOIRemove = new MaterialSkin.Controls.MaterialButton();
            btnOIEdit = new MaterialSkin.Controls.MaterialButton();
            btnOICreate = new MaterialSkin.Controls.MaterialButton();
            panelOICU.SuspendLayout();
            panelOIUpload.SuspendLayout();
            panelOIList.SuspendLayout();
            panelOITitle.SuspendLayout();
            panelCrudCtrlOI.SuspendLayout();
            SuspendLayout();
            // 
            // panelOICU
            // 
            panelOICU.Controls.Add(panelOIUpload);
            panelOICU.Location = new Point(803, 0);
            panelOICU.Name = "panelOICU";
            panelOICU.Size = new Size(668, 720);
            panelOICU.TabIndex = 4;
            // 
            // panelOIUpload
            // 
            panelOIUpload.Controls.Add(label1);
            panelOIUpload.Controls.Add(label3);
            panelOIUpload.Controls.Add(mtbOIPrice);
            panelOIUpload.Controls.Add(label2);
            panelOIUpload.Controls.Add(mtbOIName);
            panelOIUpload.Controls.Add(btnGuardarOI);
            panelOIUpload.Controls.Add(btnVolverAtras);
            panelOIUpload.Location = new Point(0, 0);
            panelOIUpload.Margin = new Padding(3, 2, 3, 2);
            panelOIUpload.Name = "panelOIUpload";
            panelOIUpload.Size = new Size(1471, 591);
            panelOIUpload.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 19.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(247, 56);
            label1.Name = "label1";
            label1.Size = new Size(286, 30);
            label1.TabIndex = 7;
            label1.Text = "Carga de nuevo servicio";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(72, 275);
            label3.Name = "label3";
            label3.Size = new Size(348, 21);
            label3.TabIndex = 9;
            label3.Text = "Ingrese un valor para el precio del servicio.";
            // 
            // mtbOIPrice
            // 
            mtbOIPrice.AnimateReadOnly = false;
            mtbOIPrice.BorderStyle = BorderStyle.None;
            mtbOIPrice.Depth = 0;
            mtbOIPrice.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            mtbOIPrice.LeadingIcon = null;
            mtbOIPrice.Location = new Point(77, 326);
            mtbOIPrice.Margin = new Padding(3, 2, 3, 2);
            mtbOIPrice.MaxLength = 50;
            mtbOIPrice.MouseState = MaterialSkin.MouseState.OUT;
            mtbOIPrice.Multiline = false;
            mtbOIPrice.Name = "mtbOIPrice";
            mtbOIPrice.Size = new Size(175, 50);
            mtbOIPrice.TabIndex = 0;
            mtbOIPrice.Text = "";
            mtbOIPrice.TrailingIcon = null;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(72, 128);
            label2.Name = "label2";
            label2.Size = new Size(424, 21);
            label2.TabIndex = 8;
            label2.Text = "Ingrese un nombre o descripcion del nuevo servicio.";
            // 
            // mtbOIName
            // 
            mtbOIName.AnimateReadOnly = false;
            mtbOIName.BorderStyle = BorderStyle.None;
            mtbOIName.Depth = 0;
            mtbOIName.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            mtbOIName.LeadingIcon = null;
            mtbOIName.Location = new Point(78, 178);
            mtbOIName.Margin = new Padding(3, 2, 3, 2);
            mtbOIName.MaxLength = 50;
            mtbOIName.MouseState = MaterialSkin.MouseState.OUT;
            mtbOIName.Multiline = false;
            mtbOIName.Name = "mtbOIName";
            mtbOIName.Size = new Size(237, 50);
            mtbOIName.TabIndex = 1;
            mtbOIName.Text = "";
            mtbOIName.TrailingIcon = null;
            // 
            // btnGuardarOI
            // 
            btnGuardarOI.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGuardarOI.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnGuardarOI.Depth = 0;
            btnGuardarOI.FlatStyle = FlatStyle.Popup;
            btnGuardarOI.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardarOI.HighEmphasis = true;
            btnGuardarOI.Icon = null;
            btnGuardarOI.Location = new Point(378, 442);
            btnGuardarOI.Margin = new Padding(4);
            btnGuardarOI.MouseState = MaterialSkin.MouseState.HOVER;
            btnGuardarOI.Name = "btnGuardarOI";
            btnGuardarOI.NoAccentTextColor = Color.Empty;
            btnGuardarOI.Size = new Size(88, 36);
            btnGuardarOI.TabIndex = 5;
            btnGuardarOI.Text = "Guardar";
            btnGuardarOI.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnGuardarOI.UseAccentColor = false;
            btnGuardarOI.UseVisualStyleBackColor = true;
            btnGuardarOI.Click += btnGuardarOI_Click;
            // 
            // btnVolverAtras
            // 
            btnVolverAtras.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnVolverAtras.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnVolverAtras.Depth = 0;
            btnVolverAtras.HighEmphasis = true;
            btnVolverAtras.Icon = null;
            btnVolverAtras.Location = new Point(378, 539);
            btnVolverAtras.Margin = new Padding(4);
            btnVolverAtras.MinimumSize = new Size(77, 0);
            btnVolverAtras.MouseState = MaterialSkin.MouseState.HOVER;
            btnVolverAtras.Name = "btnVolverAtras";
            btnVolverAtras.NoAccentTextColor = Color.Empty;
            btnVolverAtras.Size = new Size(77, 36);
            btnVolverAtras.TabIndex = 6;
            btnVolverAtras.Text = "Volver";
            btnVolverAtras.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnVolverAtras.UseAccentColor = false;
            btnVolverAtras.UseVisualStyleBackColor = true;
            btnVolverAtras.Click += btnVolverAtras_Click;
            // 
            // panelOIList
            // 
            panelOIList.Controls.Add(mtLvOptionItems);
            panelOIList.Controls.Add(panelOITitle);
            panelOIList.Controls.Add(panelCrudCtrlOI);
            panelOIList.Dock = DockStyle.Fill;
            panelOIList.Location = new Point(0, 0);
            panelOIList.Name = "panelOIList";
            panelOIList.Size = new Size(1471, 720);
            panelOIList.TabIndex = 3;
            // 
            // mtLvOptionItems
            // 
            mtLvOptionItems.AutoSizeTable = false;
            mtLvOptionItems.BackColor = Color.FromArgb(255, 255, 255);
            mtLvOptionItems.BorderStyle = BorderStyle.None;
            mtLvOptionItems.Columns.AddRange(new ColumnHeader[] { IdColumn, NameColumn, PriceColumn });
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
            // 
            // IdColumn
            // 
            IdColumn.Text = "Id";
            IdColumn.Width = 150;
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
            // panelOITitle
            // 
            panelOITitle.BackColor = Color.White;
            panelOITitle.Controls.Add(lblOITitle);
            panelOITitle.Dock = DockStyle.Top;
            panelOITitle.Location = new Point(145, 0);
            panelOITitle.Name = "panelOITitle";
            panelOITitle.Size = new Size(1326, 60);
            panelOITitle.TabIndex = 6;
            // 
            // lblOITitle
            // 
            lblOITitle.AutoSize = true;
            lblOITitle.Font = new Font("Georgia", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOITitle.Location = new Point(15, 10);
            lblOITitle.Name = "lblOITitle";
            lblOITitle.Size = new Size(195, 24);
            lblOITitle.TabIndex = 0;
            lblOITitle.Text = "Servicios adicionales";
            // 
            // panelCrudCtrlOI
            // 
            panelCrudCtrlOI.BackColor = Color.White;
            panelCrudCtrlOI.Controls.Add(btnOIRemove);
            panelCrudCtrlOI.Controls.Add(btnOIEdit);
            panelCrudCtrlOI.Controls.Add(btnOICreate);
            panelCrudCtrlOI.Dock = DockStyle.Left;
            panelCrudCtrlOI.Location = new Point(0, 0);
            panelCrudCtrlOI.Name = "panelCrudCtrlOI";
            panelCrudCtrlOI.Size = new Size(145, 720);
            panelCrudCtrlOI.TabIndex = 5;
            // 
            // btnOIRemove
            // 
            btnOIRemove.AutoSize = false;
            btnOIRemove.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnOIRemove.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnOIRemove.Depth = 0;
            btnOIRemove.HighEmphasis = true;
            btnOIRemove.Icon = null;
            btnOIRemove.Location = new Point(36, 346);
            btnOIRemove.Margin = new Padding(4, 6, 4, 6);
            btnOIRemove.MouseState = MaterialSkin.MouseState.HOVER;
            btnOIRemove.Name = "btnOIRemove";
            btnOIRemove.NoAccentTextColor = Color.Empty;
            btnOIRemove.Size = new Size(90, 36);
            btnOIRemove.TabIndex = 2;
            btnOIRemove.Text = "Eliminar";
            btnOIRemove.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnOIRemove.UseAccentColor = false;
            btnOIRemove.UseVisualStyleBackColor = true;
            btnOIRemove.Click += btnOIRemove_Click;
            // 
            // btnOIEdit
            // 
            btnOIEdit.AutoSize = false;
            btnOIEdit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnOIEdit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnOIEdit.Depth = 0;
            btnOIEdit.HighEmphasis = true;
            btnOIEdit.Icon = null;
            btnOIEdit.Location = new Point(36, 238);
            btnOIEdit.Margin = new Padding(4, 6, 4, 6);
            btnOIEdit.MouseState = MaterialSkin.MouseState.HOVER;
            btnOIEdit.Name = "btnOIEdit";
            btnOIEdit.NoAccentTextColor = Color.Empty;
            btnOIEdit.Size = new Size(90, 36);
            btnOIEdit.TabIndex = 1;
            btnOIEdit.Text = "Editar";
            btnOIEdit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnOIEdit.UseAccentColor = false;
            btnOIEdit.UseVisualStyleBackColor = true;
            btnOIEdit.Click += btnOIEdit_Click;
            // 
            // btnOICreate
            // 
            btnOICreate.AutoSize = false;
            btnOICreate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnOICreate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnOICreate.Depth = 0;
            btnOICreate.HighEmphasis = true;
            btnOICreate.Icon = null;
            btnOICreate.Location = new Point(36, 115);
            btnOICreate.Margin = new Padding(4, 6, 4, 6);
            btnOICreate.MouseState = MaterialSkin.MouseState.HOVER;
            btnOICreate.Name = "btnOICreate";
            btnOICreate.NoAccentTextColor = Color.Empty;
            btnOICreate.Size = new Size(90, 36);
            btnOICreate.TabIndex = 0;
            btnOICreate.Text = "Crear";
            btnOICreate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnOICreate.UseAccentColor = false;
            btnOICreate.UseVisualStyleBackColor = true;
            btnOICreate.Click += btnOICreate_Click;
            // 
            // FormOptionItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1471, 720);
            Controls.Add(panelOICU);
            Controls.Add(panelOIList);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormOptionItem";
            Text = "FormOptionItem";
            Load += FormOptionItem_Load;
            panelOICU.ResumeLayout(false);
            panelOIUpload.ResumeLayout(false);
            panelOIUpload.PerformLayout();
            panelOIList.ResumeLayout(false);
            panelOITitle.ResumeLayout(false);
            panelOITitle.PerformLayout();
            panelCrudCtrlOI.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelOICU;
        private Panel panelOIList;
        private Panel panelOITitle;
        private Label lblOITitle;
        private MaterialSkin.Controls.MaterialListView mtLvOptionItems;
        private ColumnHeader IdColumn;
        private ColumnHeader NameColumn;
        private ColumnHeader PriceColumn;
        private Panel panelCrudCtrlOI;
        private MaterialSkin.Controls.MaterialButton btnOIRemove;
        private MaterialSkin.Controls.MaterialButton btnOIEdit;
        private MaterialSkin.Controls.MaterialButton btnOICreate;
        private MaterialSkin.Controls.MaterialTextBox mtbOIPrice;
        private MaterialSkin.Controls.MaterialTextBox mtbOIName;
        private MaterialSkin.Controls.MaterialButton btnVolverAtras;
        private MaterialSkin.Controls.MaterialButton btnGuardarOI;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panelOIUpload;
    }
}