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
            label1 = new Label();
            label3 = new Label();
            mtbUbicationPrice = new MaterialSkin.Controls.MaterialTextBox();
            label2 = new Label();
            mtbUbicationName = new MaterialSkin.Controls.MaterialTextBox();
            btnGuardarUbicacion = new MaterialSkin.Controls.MaterialButton();
            btnVolverAtras = new MaterialSkin.Controls.MaterialButton();
            panel2 = new Panel();
            mtLvUbications = new MaterialSkin.Controls.MaterialListView();
            IdColumn = new ColumnHeader();
            NameColumn = new ColumnHeader();
            PriceColumn = new ColumnHeader();
            panelCrudCtrlUb = new Panel();
            btnUbicationRemove = new MaterialSkin.Controls.MaterialButton();
            btnUbicationEdit = new MaterialSkin.Controls.MaterialButton();
            btnUbicationCreate = new MaterialSkin.Controls.MaterialButton();
            panel3.SuspendLayout();
            panelUpload.SuspendLayout();
            panel2.SuspendLayout();
            panelCrudCtrlUb.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.Controls.Add(panelUpload);
            panel3.Location = new Point(918, 0);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(763, 960);
            panel3.TabIndex = 4;
            // 
            // panelUpload
            // 
            panelUpload.Controls.Add(label1);
            panelUpload.Controls.Add(label3);
            panelUpload.Controls.Add(mtbUbicationPrice);
            panelUpload.Controls.Add(label2);
            panelUpload.Controls.Add(mtbUbicationName);
            panelUpload.Controls.Add(btnGuardarUbicacion);
            panelUpload.Controls.Add(btnVolverAtras);
            panelUpload.Location = new Point(0, 0);
            panelUpload.Name = "panelUpload";
            panelUpload.Size = new Size(1681, 788);
            panelUpload.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 19.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(282, 75);
            label1.Name = "label1";
            label1.Size = new Size(378, 38);
            label1.TabIndex = 7;
            label1.Text = "Carga de nueva ubicacion";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(82, 367);
            label3.Name = "label3";
            label3.Size = new Size(487, 27);
            label3.TabIndex = 9;
            label3.Text = "Ingrese un valor para el precio de la ubicacion.";
            // 
            // mtbUbicationPrice
            // 
            mtbUbicationPrice.AnimateReadOnly = false;
            mtbUbicationPrice.BorderStyle = BorderStyle.None;
            mtbUbicationPrice.Depth = 0;
            mtbUbicationPrice.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            mtbUbicationPrice.LeadingIcon = null;
            mtbUbicationPrice.Location = new Point(88, 435);
            mtbUbicationPrice.MaxLength = 50;
            mtbUbicationPrice.MouseState = MaterialSkin.MouseState.OUT;
            mtbUbicationPrice.Multiline = false;
            mtbUbicationPrice.Name = "mtbUbicationPrice";
            mtbUbicationPrice.Size = new Size(200, 50);
            mtbUbicationPrice.TabIndex = 0;
            mtbUbicationPrice.Text = "";
            mtbUbicationPrice.TrailingIcon = null;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(82, 171);
            label2.Name = "label2";
            label2.Size = new Size(578, 27);
            label2.TabIndex = 8;
            label2.Text = "Ingrese un nombre o descripcion de la nueva ubicacion.";
            // 
            // mtbUbicationName
            // 
            mtbUbicationName.AnimateReadOnly = false;
            mtbUbicationName.BorderStyle = BorderStyle.None;
            mtbUbicationName.Depth = 0;
            mtbUbicationName.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            mtbUbicationName.LeadingIcon = null;
            mtbUbicationName.Location = new Point(89, 237);
            mtbUbicationName.MaxLength = 50;
            mtbUbicationName.MouseState = MaterialSkin.MouseState.OUT;
            mtbUbicationName.Multiline = false;
            mtbUbicationName.Name = "mtbUbicationName";
            mtbUbicationName.Size = new Size(271, 50);
            mtbUbicationName.TabIndex = 1;
            mtbUbicationName.Text = "";
            mtbUbicationName.TrailingIcon = null;
            // 
            // btnGuardarUbicacion
            // 
            btnGuardarUbicacion.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGuardarUbicacion.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnGuardarUbicacion.Depth = 0;
            btnGuardarUbicacion.FlatStyle = FlatStyle.Popup;
            btnGuardarUbicacion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardarUbicacion.HighEmphasis = true;
            btnGuardarUbicacion.Icon = null;
            btnGuardarUbicacion.Location = new Point(432, 589);
            btnGuardarUbicacion.Margin = new Padding(5);
            btnGuardarUbicacion.MouseState = MaterialSkin.MouseState.HOVER;
            btnGuardarUbicacion.Name = "btnGuardarUbicacion";
            btnGuardarUbicacion.NoAccentTextColor = Color.Empty;
            btnGuardarUbicacion.Size = new Size(88, 36);
            btnGuardarUbicacion.TabIndex = 5;
            btnGuardarUbicacion.Text = "Guardar";
            btnGuardarUbicacion.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnGuardarUbicacion.UseAccentColor = false;
            btnGuardarUbicacion.UseVisualStyleBackColor = true;
            btnGuardarUbicacion.Click += btnGuardarUbicacion_Click;
            // 
            // btnVolverAtras
            // 
            btnVolverAtras.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnVolverAtras.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnVolverAtras.Depth = 0;
            btnVolverAtras.HighEmphasis = true;
            btnVolverAtras.Icon = null;
            btnVolverAtras.Location = new Point(432, 719);
            btnVolverAtras.Margin = new Padding(5);
            btnVolverAtras.MinimumSize = new Size(88, 0);
            btnVolverAtras.MouseState = MaterialSkin.MouseState.HOVER;
            btnVolverAtras.Name = "btnVolverAtras";
            btnVolverAtras.NoAccentTextColor = Color.Empty;
            btnVolverAtras.Size = new Size(88, 36);
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
            panel2.Controls.Add(panelCrudCtrlUb);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1681, 960);
            panel2.TabIndex = 3;
            // 
            // mtLvUbications
            // 
            mtLvUbications.AutoSizeTable = false;
            mtLvUbications.BackColor = Color.FromArgb(255, 255, 255);
            mtLvUbications.BorderStyle = BorderStyle.None;
            mtLvUbications.Columns.AddRange(new ColumnHeader[] { IdColumn, NameColumn, PriceColumn });
            mtLvUbications.Depth = 0;
            mtLvUbications.Dock = DockStyle.Fill;
            mtLvUbications.FullRowSelect = true;
            mtLvUbications.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3, listViewItem4, listViewItem5, listViewItem6, listViewItem7, listViewItem8 });
            mtLvUbications.Location = new Point(166, 0);
            mtLvUbications.Margin = new Padding(3, 4, 3, 4);
            mtLvUbications.MinimumSize = new Size(229, 133);
            mtLvUbications.MouseLocation = new Point(-1, -1);
            mtLvUbications.MouseState = MaterialSkin.MouseState.OUT;
            mtLvUbications.Name = "mtLvUbications";
            mtLvUbications.OwnerDraw = true;
            mtLvUbications.Size = new Size(1515, 960);
            mtLvUbications.TabIndex = 1;
            mtLvUbications.UseCompatibleStateImageBehavior = false;
            mtLvUbications.View = System.Windows.Forms.View.Details;
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
            // panelCrudCtrlUb
            // 
            panelCrudCtrlUb.BackColor = Color.White;
            panelCrudCtrlUb.Controls.Add(btnUbicationRemove);
            panelCrudCtrlUb.Controls.Add(btnUbicationEdit);
            panelCrudCtrlUb.Controls.Add(btnUbicationCreate);
            panelCrudCtrlUb.Dock = DockStyle.Left;
            panelCrudCtrlUb.Location = new Point(0, 0);
            panelCrudCtrlUb.Margin = new Padding(3, 4, 3, 4);
            panelCrudCtrlUb.Name = "panelCrudCtrlUb";
            panelCrudCtrlUb.Size = new Size(166, 960);
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
            btnUbicationRemove.Location = new Point(41, 461);
            btnUbicationRemove.Margin = new Padding(5, 8, 5, 8);
            btnUbicationRemove.MouseState = MaterialSkin.MouseState.HOVER;
            btnUbicationRemove.Name = "btnUbicationRemove";
            btnUbicationRemove.NoAccentTextColor = Color.Empty;
            btnUbicationRemove.Size = new Size(103, 48);
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
            btnUbicationEdit.Location = new Point(41, 317);
            btnUbicationEdit.Margin = new Padding(5, 8, 5, 8);
            btnUbicationEdit.MouseState = MaterialSkin.MouseState.HOVER;
            btnUbicationEdit.Name = "btnUbicationEdit";
            btnUbicationEdit.NoAccentTextColor = Color.Empty;
            btnUbicationEdit.Size = new Size(103, 48);
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
            btnUbicationCreate.Location = new Point(41, 153);
            btnUbicationCreate.Margin = new Padding(5, 8, 5, 8);
            btnUbicationCreate.MouseState = MaterialSkin.MouseState.HOVER;
            btnUbicationCreate.Name = "btnUbicationCreate";
            btnUbicationCreate.NoAccentTextColor = Color.Empty;
            btnUbicationCreate.Size = new Size(103, 48);
            btnUbicationCreate.TabIndex = 0;
            btnUbicationCreate.Text = "Crear";
            btnUbicationCreate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnUbicationCreate.UseAccentColor = false;
            btnUbicationCreate.UseVisualStyleBackColor = true;
            btnUbicationCreate.Click += btnUbicationCreate_Click;
            // 
            // FormUbications
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1681, 960);
            Controls.Add(panel3);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormUbications";
            Text = "FormUbications";
            Load += FormUbications_Load;
            panel3.ResumeLayout(false);
            panelUpload.ResumeLayout(false);
            panelUpload.PerformLayout();
            panel2.ResumeLayout(false);
            panelCrudCtrlUb.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private Panel panel2;
        private MaterialSkin.Controls.MaterialListView mtLvUbications;
        private ColumnHeader IdColumn;
        private ColumnHeader NameColumn;
        private ColumnHeader PriceColumn;
        private Panel panelCrudCtrlUb;
        private MaterialSkin.Controls.MaterialButton btnUbicationRemove;
        private MaterialSkin.Controls.MaterialButton btnUbicationEdit;
        private MaterialSkin.Controls.MaterialButton btnUbicationCreate;
        private MaterialSkin.Controls.MaterialTextBox mtbUbicationPrice;
        private MaterialSkin.Controls.MaterialTextBox mtbUbicationName;
        private MaterialSkin.Controls.MaterialButton btnVolverAtras;
        private MaterialSkin.Controls.MaterialButton btnGuardarUbicacion;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panelUpload;
    }
}