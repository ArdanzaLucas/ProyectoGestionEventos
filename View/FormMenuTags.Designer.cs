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
            label1 = new MaterialSkin.Controls.MaterialLabel();
            label2 = new MaterialSkin.Controls.MaterialLabel();
            mtbMenuTagDescription = new MaterialSkin.Controls.MaterialTextBox();
            btnSaveMenuTag = new MaterialSkin.Controls.MaterialButton();
            btnBack = new MaterialSkin.Controls.MaterialButton();
            panelMenuTagList = new Panel();
            mtLvMenuTags = new MaterialSkin.Controls.MaterialListView();
            DescriptionColumn = new ColumnHeader();
            panelMenuTagTitle = new Panel();
            lblMenuTagTitle = new MaterialSkin.Controls.MaterialLabel();
            panelCrudCtrlMenuTag = new Panel();
            btnBackToMenus = new MaterialSkin.Controls.MaterialButton();
            btnMenuTagRemove = new MaterialSkin.Controls.MaterialButton();
            btnMenuTagEdit = new MaterialSkin.Controls.MaterialButton();
            btnMenuTagCreate = new MaterialSkin.Controls.MaterialButton();
            panelMenuTagCU.SuspendLayout();
            panelMenuTagUpload.SuspendLayout();
            panelMenuTagList.SuspendLayout();
            panelMenuTagTitle.SuspendLayout();
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
            panelMenuTagUpload.Controls.Add(btnSaveMenuTag);
            panelMenuTagUpload.Controls.Add(btnBack);
            panelMenuTagUpload.Location = new Point(0, 0);
            panelMenuTagUpload.Margin = new Padding(3, 2, 3, 2);
            panelMenuTagUpload.Name = "panelMenuTagUpload";
            panelMenuTagUpload.Size = new Size(1471, 591);
            panelMenuTagUpload.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Depth = 0;
            label1.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            label1.MouseState = MaterialSkin.MouseState.HOVER;
            label1.Location = new Point(40, 30);
            label1.Name = "label1";
            label1.Size = new Size(215, 30);
            label1.TabIndex = 7;
            label1.Text = "Carga de etiqueta";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Depth = 0;
            label2.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            label2.MouseState = MaterialSkin.MouseState.HOVER;
            label2.Location = new Point(40, 90);
            label2.Name = "label2";
            label2.Size = new Size(432, 21);
            label2.TabIndex = 8;
            label2.Text = "Descripcion";
            // 
            // mtbMenuTagDescription
            // 
            mtbMenuTagDescription.AnimateReadOnly = false;
            mtbMenuTagDescription.BorderStyle = BorderStyle.None;
            mtbMenuTagDescription.Depth = 0;
            mtbMenuTagDescription.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            mtbMenuTagDescription.LeadingIcon = null;
            mtbMenuTagDescription.Location = new Point(40, 112);
            mtbMenuTagDescription.Margin = new Padding(3, 2, 3, 2);
            mtbMenuTagDescription.MaxLength = 50;
            mtbMenuTagDescription.MouseState = MaterialSkin.MouseState.OUT;
            mtbMenuTagDescription.Multiline = false;
            mtbMenuTagDescription.Name = "mtbMenuTagDescription";
            mtbMenuTagDescription.Size = new Size(250, 50);
            mtbMenuTagDescription.TabIndex = 0;
            mtbMenuTagDescription.Text = "";
            mtbMenuTagDescription.TrailingIcon = null;
            // 
            // btnGuardarMenuTag
            // 
            btnSaveMenuTag.AutoSize = false;
            btnSaveMenuTag.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSaveMenuTag.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSaveMenuTag.Depth = 0;
            btnSaveMenuTag.FlatStyle = FlatStyle.Popup;
            btnSaveMenuTag.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSaveMenuTag.HighEmphasis = true;
            btnSaveMenuTag.Icon = null;
            btnSaveMenuTag.Location = new Point(40, 202);
            btnSaveMenuTag.Margin = new Padding(4);
            btnSaveMenuTag.MouseState = MaterialSkin.MouseState.HOVER;
            btnSaveMenuTag.Name = "btnSaveMenuTag";
            btnSaveMenuTag.NoAccentTextColor = Color.Empty;
            btnSaveMenuTag.Size = new Size(90, 36);
            btnSaveMenuTag.TabIndex = 5;
            btnSaveMenuTag.Text = "Guardar";
            btnSaveMenuTag.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSaveMenuTag.UseAccentColor = false;
            btnSaveMenuTag.UseVisualStyleBackColor = true;
            btnSaveMenuTag.Click += btnSaveMenuTag_Click;
            // 
            // btnVolverAtras
            // 
            btnBack.AutoSize = false;
            btnBack.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBack.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBack.Depth = 0;
            btnBack.HighEmphasis = true;
            btnBack.Icon = null;
            btnBack.Location = new Point(200, 202);
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
            // panelMenuTagList
            // 
            panelMenuTagList.Controls.Add(mtLvMenuTags);
            panelMenuTagList.Controls.Add(panelMenuTagTitle);
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
            mtLvMenuTags.Columns.AddRange(new ColumnHeader[] { DescriptionColumn });
            mtLvMenuTags.Depth = 0;
            mtLvMenuTags.Dock = DockStyle.Fill;
            mtLvMenuTags.FullRowSelect = true;
            mtLvMenuTags.Location = new Point(145, 60);
            mtLvMenuTags.MinimumSize = new Size(200, 100);
            mtLvMenuTags.MouseLocation = new Point(-1, -1);
            mtLvMenuTags.MouseState = MaterialSkin.MouseState.OUT;
            mtLvMenuTags.Name = "mtLvMenuTags";
            mtLvMenuTags.OwnerDraw = true;
            mtLvMenuTags.Size = new Size(1326, 660);
            mtLvMenuTags.TabIndex = 1;
            mtLvMenuTags.UseCompatibleStateImageBehavior = false;
            mtLvMenuTags.View = System.Windows.Forms.View.Details;
            mtLvMenuTags.DoubleClick += mtLvMenuTags_DoubleClick;
            // 
            // DescriptionColumn
            // 
            DescriptionColumn.Text = "Descripcion";
            DescriptionColumn.TextAlign = HorizontalAlignment.Center;
            DescriptionColumn.Width = 300;
            // 
            // panelMenuTagTitle
            // 
            panelMenuTagTitle.BackColor = Color.White;
            panelMenuTagTitle.Controls.Add(lblMenuTagTitle);
            panelMenuTagTitle.Dock = DockStyle.Top;
            panelMenuTagTitle.Location = new Point(145, 0);
            panelMenuTagTitle.Name = "panelMenuTagTitle";
            panelMenuTagTitle.Size = new Size(1326, 60);
            panelMenuTagTitle.TabIndex = 6;
            // 
            // lblMenuTagTitle
            // 
            lblMenuTagTitle.AutoSize = true;
            lblMenuTagTitle.Depth = 0;
            lblMenuTagTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblMenuTagTitle.MouseState = MaterialSkin.MouseState.HOVER;
            lblMenuTagTitle.Location = new Point(15, 10);
            lblMenuTagTitle.Name = "lblMenuTagTitle";
            lblMenuTagTitle.Size = new Size(95, 24);
            lblMenuTagTitle.TabIndex = 0;
            lblMenuTagTitle.Text = "Etiquetas";
            // 
            // panelCrudCtrlMenuTag
            // 
            panelCrudCtrlMenuTag.BackColor = Color.White;
            panelCrudCtrlMenuTag.Controls.Add(btnBackToMenus);
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
            btnBackToMenus.AutoSize = false;
            btnBackToMenus.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBackToMenus.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBackToMenus.Depth = 0;
            btnBackToMenus.HighEmphasis = true;
            btnBackToMenus.Icon = null;
            btnBackToMenus.Location = new Point(36, 461);
            btnBackToMenus.Margin = new Padding(4, 6, 4, 6);
            btnBackToMenus.MouseState = MaterialSkin.MouseState.HOVER;
            btnBackToMenus.Name = "btnBackToMenus";
            btnBackToMenus.NoAccentTextColor = Color.Empty;
            btnBackToMenus.Size = new Size(90, 36);
            btnBackToMenus.TabIndex = 3;
            btnBackToMenus.Text = "Volver";
            btnBackToMenus.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnBackToMenus.UseAccentColor = false;
            btnBackToMenus.UseVisualStyleBackColor = true;
            btnBackToMenus.Click += btnBackToMenus_Click;
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
            panelMenuTagTitle.ResumeLayout(false);
            panelMenuTagTitle.PerformLayout();
            panelCrudCtrlMenuTag.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenuTagCU;
        private Panel panelMenuTagList;
        private Panel panelMenuTagTitle;
        private MaterialSkin.Controls.MaterialLabel lblMenuTagTitle;
        private MaterialSkin.Controls.MaterialListView mtLvMenuTags;
        private ColumnHeader DescriptionColumn;
        private Panel panelCrudCtrlMenuTag;
        private MaterialSkin.Controls.MaterialButton btnBackToMenus;
        private MaterialSkin.Controls.MaterialButton btnMenuTagRemove;
        private MaterialSkin.Controls.MaterialButton btnMenuTagEdit;
        private MaterialSkin.Controls.MaterialButton btnMenuTagCreate;
        private MaterialSkin.Controls.MaterialTextBox mtbMenuTagDescription;
        private MaterialSkin.Controls.MaterialButton btnBack;
        private MaterialSkin.Controls.MaterialButton btnSaveMenuTag;
        private MaterialSkin.Controls.MaterialLabel label2;
        private MaterialSkin.Controls.MaterialLabel label1;
        private Panel panelMenuTagUpload;
    }
}
