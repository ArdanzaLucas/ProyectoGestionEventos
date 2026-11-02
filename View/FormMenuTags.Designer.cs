namespace ProyectoPresupuestoEvento.View
{
    partial class FormMenuTags
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
            panelMenuTagCU = new Panel();
            panelMenuTagUpload = new Panel();
            label1 = new Label();
            label2 = new Label();
            mtbMenuTagDescription = new MaterialSkin.Controls.MaterialTextBox();
            btnGuardarMenuTag = new MaterialSkin.Controls.MaterialButton();
            btnVolverAtras = new MaterialSkin.Controls.MaterialButton();
            panelMenuTagList = new Panel();
            mtLvMenuTags = new MaterialSkin.Controls.MaterialListView();
            IdColumn = new ColumnHeader();
            DescriptionColumn = new ColumnHeader();
            panelCrudCtrlMenuTag = new Panel();
            btnVolverMenus = new MaterialSkin.Controls.MaterialButton();
            btnMenuTagRemove = new MaterialSkin.Controls.MaterialButton();
            btnMenuTagEdit = new MaterialSkin.Controls.MaterialButton();
            btnMenuTagCreate = new MaterialSkin.Controls.MaterialButton();
            panelMenuTagCU.SuspendLayout();
            panelMenuTagUpload.SuspendLayout();
            panelMenuTagList.SuspendLayout();
            panelCrudCtrlMenuTag.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenuTagCU
            // 
            panelMenuTagCU.Controls.Add(panelMenuTagUpload);
            panelMenuTagCU.Location = new Point(803, 0);
            panelMenuTagCU.Name = "panelMenuTagCU";
            panelMenuTagCU.Size = new Size(668, 720);
            panelMenuTagCU.TabIndex = 4;
            // 
            // panelMenuTagUpload
            // 
            panelMenuTagUpload.Controls.Add(label1);
            panelMenuTagUpload.Controls.Add(label2);
            panelMenuTagUpload.Controls.Add(mtbMenuTagDescription);
            panelMenuTagUpload.Controls.Add(btnGuardarMenuTag);
            panelMenuTagUpload.Controls.Add(btnVolverAtras);
            panelMenuTagUpload.Location = new Point(0, 0);
            panelMenuTagUpload.Margin = new Padding(3, 2, 3, 2);
            panelMenuTagUpload.Name = "panelMenuTagUpload";
            panelMenuTagUpload.Size = new Size(1471, 591);
            panelMenuTagUpload.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 19.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(247, 56);
            label1.Name = "label1";
            label1.Size = new Size(215, 30);
            label1.TabIndex = 7;
            label1.Text = "Carga de etiqueta";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(72, 128);
            label2.Name = "label2";
            label2.Size = new Size(432, 21);
            label2.TabIndex = 8;
            label2.Text = "Ingrese una descripcion para la etiqueta (ej: Vegana).";
            // 
            // mtbMenuTagDescription
            // 
            mtbMenuTagDescription.AnimateReadOnly = false;
            mtbMenuTagDescription.BorderStyle = BorderStyle.None;
            mtbMenuTagDescription.Depth = 0;
            mtbMenuTagDescription.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            mtbMenuTagDescription.LeadingIcon = null;
            mtbMenuTagDescription.Location = new Point(78, 178);
            mtbMenuTagDescription.Margin = new Padding(3, 2, 3, 2);
            mtbMenuTagDescription.MaxLength = 50;
            mtbMenuTagDescription.MouseState = MaterialSkin.MouseState.OUT;
            mtbMenuTagDescription.Multiline = false;
            mtbMenuTagDescription.Name = "mtbMenuTagDescription";
            mtbMenuTagDescription.Size = new Size(237, 50);
            mtbMenuTagDescription.TabIndex = 0;
            mtbMenuTagDescription.Text = "";
            mtbMenuTagDescription.TrailingIcon = null;
            // 
            // btnGuardarMenuTag
            // 
            btnGuardarMenuTag.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGuardarMenuTag.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnGuardarMenuTag.Depth = 0;
            btnGuardarMenuTag.FlatStyle = FlatStyle.Popup;
            btnGuardarMenuTag.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardarMenuTag.HighEmphasis = true;
            btnGuardarMenuTag.Icon = null;
            btnGuardarMenuTag.Location = new Point(378, 300);
            btnGuardarMenuTag.Margin = new Padding(4);
            btnGuardarMenuTag.MouseState = MaterialSkin.MouseState.HOVER;
            btnGuardarMenuTag.Name = "btnGuardarMenuTag";
            btnGuardarMenuTag.NoAccentTextColor = Color.Empty;
            btnGuardarMenuTag.Size = new Size(88, 36);
            btnGuardarMenuTag.TabIndex = 5;
            btnGuardarMenuTag.Text = "Guardar";
            btnGuardarMenuTag.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnGuardarMenuTag.UseAccentColor = false;
            btnGuardarMenuTag.UseVisualStyleBackColor = true;
            btnGuardarMenuTag.Click += btnGuardarMenuTag_Click;
            // 
            // btnVolverAtras
            // 
            btnVolverAtras.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnVolverAtras.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnVolverAtras.Depth = 0;
            btnVolverAtras.HighEmphasis = true;
            btnVolverAtras.Icon = null;
            btnVolverAtras.Location = new Point(378, 398);
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
            // panelMenuTagList
            // 
            panelMenuTagList.Controls.Add(mtLvMenuTags);
            panelMenuTagList.Controls.Add(panelCrudCtrlMenuTag);
            panelMenuTagList.Dock = DockStyle.Fill;
            panelMenuTagList.Location = new Point(0, 0);
            panelMenuTagList.Name = "panelMenuTagList";
            panelMenuTagList.Size = new Size(1471, 720);
            panelMenuTagList.TabIndex = 3;
            // 
            // mtLvMenuTags
            // 
            mtLvMenuTags.AutoSizeTable = false;
            mtLvMenuTags.BackColor = Color.FromArgb(255, 255, 255);
            mtLvMenuTags.BorderStyle = BorderStyle.None;
            mtLvMenuTags.Columns.AddRange(new ColumnHeader[] { IdColumn, DescriptionColumn });
            mtLvMenuTags.Depth = 0;
            mtLvMenuTags.Dock = DockStyle.Fill;
            mtLvMenuTags.FullRowSelect = true;
            mtLvMenuTags.Location = new Point(145, 0);
            mtLvMenuTags.MinimumSize = new Size(200, 100);
            mtLvMenuTags.MouseLocation = new Point(-1, -1);
            mtLvMenuTags.MouseState = MaterialSkin.MouseState.OUT;
            mtLvMenuTags.Name = "mtLvMenuTags";
            mtLvMenuTags.OwnerDraw = true;
            mtLvMenuTags.Size = new Size(1326, 720);
            mtLvMenuTags.TabIndex = 1;
            mtLvMenuTags.UseCompatibleStateImageBehavior = false;
            mtLvMenuTags.View = System.Windows.Forms.View.Details;
            // 
            // IdColumn
            // 
            IdColumn.Text = "Id";
            IdColumn.Width = 150;
            // 
            // DescriptionColumn
            // 
            DescriptionColumn.Text = "Descripcion";
            DescriptionColumn.TextAlign = HorizontalAlignment.Center;
            DescriptionColumn.Width = 300;
            // 
            // panelCrudCtrlMenuTag
            // 
            panelCrudCtrlMenuTag.BackColor = Color.White;
            panelCrudCtrlMenuTag.Controls.Add(btnVolverMenus);
            panelCrudCtrlMenuTag.Controls.Add(btnMenuTagRemove);
            panelCrudCtrlMenuTag.Controls.Add(btnMenuTagEdit);
            panelCrudCtrlMenuTag.Controls.Add(btnMenuTagCreate);
            panelCrudCtrlMenuTag.Dock = DockStyle.Left;
            panelCrudCtrlMenuTag.Location = new Point(0, 0);
            panelCrudCtrlMenuTag.Name = "panelCrudCtrlMenuTag";
            panelCrudCtrlMenuTag.Size = new Size(145, 720);
            panelCrudCtrlMenuTag.TabIndex = 5;
            // 
            // btnVolverMenus
            // 
            btnVolverMenus.AutoSize = false;
            btnVolverMenus.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnVolverMenus.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnVolverMenus.Depth = 0;
            btnVolverMenus.HighEmphasis = true;
            btnVolverMenus.Icon = null;
            btnVolverMenus.Location = new Point(36, 461);
            btnVolverMenus.Margin = new Padding(4, 6, 4, 6);
            btnVolverMenus.MouseState = MaterialSkin.MouseState.HOVER;
            btnVolverMenus.Name = "btnVolverMenus";
            btnVolverMenus.NoAccentTextColor = Color.Empty;
            btnVolverMenus.Size = new Size(90, 36);
            btnVolverMenus.TabIndex = 3;
            btnVolverMenus.Text = "Volver";
            btnVolverMenus.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnVolverMenus.UseAccentColor = false;
            btnVolverMenus.UseVisualStyleBackColor = true;
            btnVolverMenus.Click += btnVolverMenus_Click;
            // 
            // btnMenuTagRemove
            // 
            btnMenuTagRemove.AutoSize = false;
            btnMenuTagRemove.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMenuTagRemove.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnMenuTagRemove.Depth = 0;
            btnMenuTagRemove.HighEmphasis = true;
            btnMenuTagRemove.Icon = null;
            btnMenuTagRemove.Location = new Point(36, 346);
            btnMenuTagRemove.Margin = new Padding(4, 6, 4, 6);
            btnMenuTagRemove.MouseState = MaterialSkin.MouseState.HOVER;
            btnMenuTagRemove.Name = "btnMenuTagRemove";
            btnMenuTagRemove.NoAccentTextColor = Color.Empty;
            btnMenuTagRemove.Size = new Size(90, 36);
            btnMenuTagRemove.TabIndex = 2;
            btnMenuTagRemove.Text = "Eliminar";
            btnMenuTagRemove.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnMenuTagRemove.UseAccentColor = false;
            btnMenuTagRemove.UseVisualStyleBackColor = true;
            btnMenuTagRemove.Click += btnMenuTagRemove_Click;
            // 
            // btnMenuTagEdit
            // 
            btnMenuTagEdit.AutoSize = false;
            btnMenuTagEdit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMenuTagEdit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnMenuTagEdit.Depth = 0;
            btnMenuTagEdit.HighEmphasis = true;
            btnMenuTagEdit.Icon = null;
            btnMenuTagEdit.Location = new Point(36, 238);
            btnMenuTagEdit.Margin = new Padding(4, 6, 4, 6);
            btnMenuTagEdit.MouseState = MaterialSkin.MouseState.HOVER;
            btnMenuTagEdit.Name = "btnMenuTagEdit";
            btnMenuTagEdit.NoAccentTextColor = Color.Empty;
            btnMenuTagEdit.Size = new Size(90, 36);
            btnMenuTagEdit.TabIndex = 1;
            btnMenuTagEdit.Text = "Editar";
            btnMenuTagEdit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnMenuTagEdit.UseAccentColor = false;
            btnMenuTagEdit.UseVisualStyleBackColor = true;
            btnMenuTagEdit.Click += btnMenuTagEdit_Click;
            // 
            // btnMenuTagCreate
            // 
            btnMenuTagCreate.AutoSize = false;
            btnMenuTagCreate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMenuTagCreate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnMenuTagCreate.Depth = 0;
            btnMenuTagCreate.HighEmphasis = true;
            btnMenuTagCreate.Icon = null;
            btnMenuTagCreate.Location = new Point(36, 115);
            btnMenuTagCreate.Margin = new Padding(4, 6, 4, 6);
            btnMenuTagCreate.MouseState = MaterialSkin.MouseState.HOVER;
            btnMenuTagCreate.Name = "btnMenuTagCreate";
            btnMenuTagCreate.NoAccentTextColor = Color.Empty;
            btnMenuTagCreate.Size = new Size(90, 36);
            btnMenuTagCreate.TabIndex = 0;
            btnMenuTagCreate.Text = "Crear";
            btnMenuTagCreate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnMenuTagCreate.UseAccentColor = false;
            btnMenuTagCreate.UseVisualStyleBackColor = true;
            btnMenuTagCreate.Click += btnMenuTagCreate_Click;
            // 
            // FormMenuTags
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1471, 720);
            Controls.Add(panelMenuTagCU);
            Controls.Add(panelMenuTagList);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormMenuTags";
            Text = "FormMenuTags";
            Load += FormMenuTags_Load;
            panelMenuTagCU.ResumeLayout(false);
            panelMenuTagUpload.ResumeLayout(false);
            panelMenuTagUpload.PerformLayout();
            panelMenuTagList.ResumeLayout(false);
            panelCrudCtrlMenuTag.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenuTagCU;
        private Panel panelMenuTagList;
        private MaterialSkin.Controls.MaterialListView mtLvMenuTags;
        private ColumnHeader IdColumn;
        private ColumnHeader DescriptionColumn;
        private Panel panelCrudCtrlMenuTag;
        private MaterialSkin.Controls.MaterialButton btnVolverMenus;
        private MaterialSkin.Controls.MaterialButton btnMenuTagRemove;
        private MaterialSkin.Controls.MaterialButton btnMenuTagEdit;
        private MaterialSkin.Controls.MaterialButton btnMenuTagCreate;
        private MaterialSkin.Controls.MaterialTextBox mtbMenuTagDescription;
        private MaterialSkin.Controls.MaterialButton btnVolverAtras;
        private MaterialSkin.Controls.MaterialButton btnGuardarMenuTag;
        private Label label2;
        private Label label1;
        private Panel panelMenuTagUpload;
    }
}
