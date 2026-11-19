namespace ProyectoPresupuestoEvento.View
{
    partial class FormMenus
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
            panelMenusList = new Panel();
            panelMenusTitle = new Panel();
            lblMenusTitle = new MaterialSkin.Controls.MaterialLabel();
            mtLvMenus = new MaterialSkin.Controls.MaterialListView();
            Description = new ColumnHeader();
            AdultPrice = new ColumnHeader();
            ChildPrice = new ColumnHeader();
            TagList = new ColumnHeader();
            panelCrudCtrlMenus = new Panel();
            btnMenuTags = new MaterialSkin.Controls.MaterialButton();
            btnMenuRemove = new MaterialSkin.Controls.MaterialButton();
            btnMenuEdit = new MaterialSkin.Controls.MaterialButton();
            btnMenuCreate = new MaterialSkin.Controls.MaterialButton();
            panelMenuUpload = new Panel();
            btnBackMenu = new MaterialSkin.Controls.MaterialButton();
            btnSaveMenu = new MaterialSkin.Controls.MaterialButton();
            lblMenuTags = new MaterialSkin.Controls.MaterialLabel();
            clbMenuTags = new CheckedListBox();
            nudMenuPriceChild = new NumericUpDown();
            nudMenuPriceAdult = new NumericUpDown();
            lblMenuPriceChild = new MaterialSkin.Controls.MaterialLabel();
            lblMenuPriceAdult = new MaterialSkin.Controls.MaterialLabel();
            mtbMenuDescription = new MaterialSkin.Controls.MaterialTextBox();
            lblMenuDescription = new MaterialSkin.Controls.MaterialLabel();
            lblMenuFormTitle = new MaterialSkin.Controls.MaterialLabel();
            panelMenusList.SuspendLayout();
            panelMenusTitle.SuspendLayout();
            panelCrudCtrlMenus.SuspendLayout();
            panelMenuUpload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudMenuPriceAdult).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMenuPriceChild).BeginInit();
            SuspendLayout();
            // 
            // panelMenusList
            // 
            panelMenusList.Controls.Add(mtLvMenus);
            panelMenusList.Controls.Add(panelMenusTitle);
            panelMenusList.Controls.Add(panelCrudCtrlMenus);
            panelMenusList.Location = new Point(0, 0);
            panelMenusList.Name = "panelMenusList";
            panelMenusList.Size = new Size(607, 720);
            panelMenusList.TabIndex = 3;
            // 
            // panelMenusTitle
            // 
            panelMenusTitle.BackColor = Color.White;
            panelMenusTitle.Controls.Add(lblMenusTitle);
            panelMenusTitle.Dock = DockStyle.Top;
            panelMenusTitle.Name = "panelMenusTitle";
            panelMenusTitle.Size = new Size(500, 45);
            panelMenusTitle.TabIndex = 6;
            // 
            // lblMenusTitle
            // 
            lblMenusTitle.AutoSize = true;
            lblMenusTitle.Depth = 0;
            lblMenusTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblMenusTitle.MouseState = MaterialSkin.MouseState.HOVER;
            lblMenusTitle.Location = new Point(15, 10);
            lblMenusTitle.Name = "lblMenusTitle";
            lblMenusTitle.Size = new Size(100, 24);
            lblMenusTitle.TabIndex = 0;
            lblMenusTitle.Text = "Menús";
            // 
            // mtLvMenus
            // 
            mtLvMenus.AutoSizeTable = false;
            mtLvMenus.BackColor = Color.FromArgb(255, 255, 255);
            mtLvMenus.BorderStyle = BorderStyle.None;
            mtLvMenus.Columns.AddRange(new ColumnHeader[] { Description, AdultPrice, ChildPrice, TagList });
            mtLvMenus.Depth = 0;
            mtLvMenus.Dock = DockStyle.Fill;
            mtLvMenus.FullRowSelect = true;
            mtLvMenus.Location = new Point(151, 0);
            mtLvMenus.MinimumSize = new Size(200, 100);
            mtLvMenus.MouseLocation = new Point(-1, -1);
            mtLvMenus.MouseState = MaterialSkin.MouseState.OUT;
            mtLvMenus.Name = "mtLvMenus";
            mtLvMenus.OwnerDraw = true;
            mtLvMenus.Size = new Size(456, 720);
            mtLvMenus.TabIndex = 1;
            mtLvMenus.UseCompatibleStateImageBehavior = false;
            mtLvMenus.View = System.Windows.Forms.View.Details;
            mtLvMenus.DoubleClick += mtLvMenus_DoubleClick;
            // 
            // Description
            // 
            Description.Text = "Descripcion";
            Description.Width = 150;
            // 
            // AdultPrice
            // 
            AdultPrice.Text = "Precio Adulto";
            AdultPrice.Width = 120;
            // 
            // ChildPrice
            // 
            ChildPrice.Text = "Precio niño";
            ChildPrice.Width = 120;
            // 
            // TagList
            // 
            TagList.Text = "Etiquetas";
            TagList.Width = 150;
            // 
            // panelCrudCtrlMenus
            // 
            panelCrudCtrlMenus.BackColor = Color.White;
            panelCrudCtrlMenus.Controls.Add(btnMenuTags);
            panelCrudCtrlMenus.Controls.Add(btnMenuRemove);
            panelCrudCtrlMenus.Controls.Add(btnMenuEdit);
            panelCrudCtrlMenus.Controls.Add(btnMenuCreate);
            panelCrudCtrlMenus.Dock = DockStyle.Left;
            panelCrudCtrlMenus.Location = new Point(0, 0);
            panelCrudCtrlMenus.Name = "panelCrudCtrlMenus";
            panelCrudCtrlMenus.Size = new Size(151, 720);
            panelCrudCtrlMenus.TabIndex = 5;
            // 
            // btnMenuTags
            // 
            btnMenuTags.AutoSize = false;
            btnMenuTags.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMenuTags.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnMenuTags.Depth = 0;
            btnMenuTags.HighEmphasis = true;
            btnMenuTags.Icon = null;
            btnMenuTags.Location = new Point(36, 461);
            btnMenuTags.Margin = new Padding(4, 6, 4, 6);
            btnMenuTags.MouseState = MaterialSkin.MouseState.HOVER;
            btnMenuTags.Name = "btnMenuTags";
            btnMenuTags.NoAccentTextColor = Color.Empty;
            btnMenuTags.Size = new Size(90, 36);
            btnMenuTags.TabIndex = 3;
            btnMenuTags.Text = "Etiquetas";
            btnMenuTags.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnMenuTags.UseAccentColor = false;
            btnMenuTags.UseVisualStyleBackColor = true;
            btnMenuTags.Click += btnMenuTags_Click;
            // 
            // btnMenuRemove
            // 
            btnMenuRemove.AutoSize = false;
            btnMenuRemove.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMenuRemove.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnMenuRemove.Depth = 0;
            btnMenuRemove.HighEmphasis = true;
            btnMenuRemove.Icon = null;
            btnMenuRemove.Location = new Point(36, 346);
            btnMenuRemove.Margin = new Padding(4, 6, 4, 6);
            btnMenuRemove.MouseState = MaterialSkin.MouseState.HOVER;
            btnMenuRemove.Name = "btnMenuRemove";
            btnMenuRemove.NoAccentTextColor = Color.Empty;
            btnMenuRemove.Size = new Size(90, 36);
            btnMenuRemove.TabIndex = 2;
            btnMenuRemove.Text = "Eliminar";
            btnMenuRemove.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnMenuRemove.UseAccentColor = false;
            btnMenuRemove.UseVisualStyleBackColor = true;
            btnMenuRemove.Click += btnMenuRemove_Click;
            // 
            // btnMenuEdit
            // 
            btnMenuEdit.AutoSize = false;
            btnMenuEdit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMenuEdit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnMenuEdit.Depth = 0;
            btnMenuEdit.HighEmphasis = true;
            btnMenuEdit.Icon = null;
            btnMenuEdit.Location = new Point(36, 238);
            btnMenuEdit.Margin = new Padding(4, 6, 4, 6);
            btnMenuEdit.MouseState = MaterialSkin.MouseState.HOVER;
            btnMenuEdit.Name = "btnMenuEdit";
            btnMenuEdit.NoAccentTextColor = Color.Empty;
            btnMenuEdit.Size = new Size(90, 36);
            btnMenuEdit.TabIndex = 1;
            btnMenuEdit.Text = "Editar";
            btnMenuEdit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnMenuEdit.UseAccentColor = false;
            btnMenuEdit.UseVisualStyleBackColor = true;
            btnMenuEdit.Click += btnMenuEdit_Click;
            // 
            // btnMenuCreate
            // 
            btnMenuCreate.AutoSize = false;
            btnMenuCreate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMenuCreate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnMenuCreate.Depth = 0;
            btnMenuCreate.HighEmphasis = true;
            btnMenuCreate.Icon = null;
            btnMenuCreate.Location = new Point(36, 115);
            btnMenuCreate.Margin = new Padding(4, 6, 4, 6);
            btnMenuCreate.MouseState = MaterialSkin.MouseState.HOVER;
            btnMenuCreate.Name = "btnMenuCreate";
            btnMenuCreate.NoAccentTextColor = Color.Empty;
            btnMenuCreate.Size = new Size(90, 36);
            btnMenuCreate.TabIndex = 0;
            btnMenuCreate.Text = "Crear";
            btnMenuCreate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnMenuCreate.UseAccentColor = false;
            btnMenuCreate.UseVisualStyleBackColor = true;
            btnMenuCreate.Click += btnMenuCreate_Click;
            // 
            // panelMenuUpload
            // 
            panelMenuUpload.Controls.Add(btnBackMenu);
            panelMenuUpload.Controls.Add(btnSaveMenu);
            panelMenuUpload.Controls.Add(lblMenuTags);
            panelMenuUpload.Controls.Add(clbMenuTags);
            panelMenuUpload.Controls.Add(nudMenuPriceChild);
            panelMenuUpload.Controls.Add(nudMenuPriceAdult);
            panelMenuUpload.Controls.Add(lblMenuPriceChild);
            panelMenuUpload.Controls.Add(lblMenuPriceAdult);
            panelMenuUpload.Controls.Add(mtbMenuDescription);
            panelMenuUpload.Controls.Add(lblMenuDescription);
            panelMenuUpload.Controls.Add(lblMenuFormTitle);
            panelMenuUpload.Location = new Point(640, 0);
            panelMenuUpload.Name = "panelMenuUpload";
            panelMenuUpload.Size = new Size(641, 677);
            panelMenuUpload.TabIndex = 6;
            // 
            // btnBackMenu
            // 
            btnBackMenu.AutoSize = false;
            btnBackMenu.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBackMenu.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBackMenu.Depth = 0;
            btnBackMenu.HighEmphasis = true;
            btnBackMenu.Icon = null;
            btnBackMenu.Location = new Point(500, 338);
            btnBackMenu.Margin = new Padding(4, 6, 4, 6);
            btnBackMenu.MouseState = MaterialSkin.MouseState.HOVER;
            btnBackMenu.Name = "btnBackMenu";
            btnBackMenu.NoAccentTextColor = Color.Empty;
            btnBackMenu.Size = new Size(90, 36);
            btnBackMenu.TabIndex = 10;
            btnBackMenu.Text = "Volver";
            btnBackMenu.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnBackMenu.UseAccentColor = false;
            btnBackMenu.UseVisualStyleBackColor = true;
            btnBackMenu.Click += btnBackMenu_Click;
            // 
            // btnSaveMenu
            // 
            btnSaveMenu.AutoSize = false;
            btnSaveMenu.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSaveMenu.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSaveMenu.Depth = 0;
            btnSaveMenu.HighEmphasis = true;
            btnSaveMenu.Icon = null;
            btnSaveMenu.Location = new Point(40, 338);
            btnSaveMenu.Margin = new Padding(4, 6, 4, 6);
            btnSaveMenu.MouseState = MaterialSkin.MouseState.HOVER;
            btnSaveMenu.Name = "btnSaveMenu";
            btnSaveMenu.NoAccentTextColor = Color.Empty;
            btnSaveMenu.Size = new Size(90, 36);
            btnSaveMenu.TabIndex = 9;
            btnSaveMenu.Text = "Guardar";
            btnSaveMenu.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSaveMenu.UseAccentColor = false;
            btnSaveMenu.UseVisualStyleBackColor = true;
            btnSaveMenu.Click += btnSaveMenu_Click;
            // 
            // lblMenuTags
            // 
            lblMenuTags.AutoSize = true;
            lblMenuTags.Depth = 0;
            lblMenuTags.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            lblMenuTags.MouseState = MaterialSkin.MouseState.HOVER;
            lblMenuTags.Location = new Point(340, 90);
            lblMenuTags.Name = "lblMenuTags";
            lblMenuTags.Size = new Size(55, 15);
            lblMenuTags.TabIndex = 8;
            lblMenuTags.Text = "Etiquetas";
            // 
            // clbMenuTags
            // 
            clbMenuTags.FormattingEnabled = true;
            clbMenuTags.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clbMenuTags.Location = new Point(340, 112);
            clbMenuTags.CheckOnClick = true;
            clbMenuTags.Name = "clbMenuTags";
            clbMenuTags.Size = new Size(250, 186);
            clbMenuTags.TabIndex = 7;
            // 
            // nudMenuPriceChild
            // 
            nudMenuPriceChild.DecimalPlaces = 2;
            nudMenuPriceChild.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudMenuPriceChild.Location = new Point(40, 272);
            nudMenuPriceChild.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudMenuPriceChild.Name = "nudMenuPriceChild";
            nudMenuPriceChild.Size = new Size(250, 27);
            nudMenuPriceChild.TabIndex = 6;
            // 
            // nudMenuPriceAdult
            // 
            nudMenuPriceAdult.DecimalPlaces = 2;
            nudMenuPriceAdult.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudMenuPriceAdult.Location = new Point(40, 204);
            nudMenuPriceAdult.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudMenuPriceAdult.Name = "nudMenuPriceAdult";
            nudMenuPriceAdult.Size = new Size(250, 27);
            nudMenuPriceAdult.TabIndex = 5;
            // 
            // lblMenuPriceChild
            // 
            lblMenuPriceChild.AutoSize = true;
            lblMenuPriceChild.Depth = 0;
            lblMenuPriceChild.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            lblMenuPriceChild.MouseState = MaterialSkin.MouseState.HOVER;
            lblMenuPriceChild.Location = new Point(40, 250);
            lblMenuPriceChild.Name = "lblMenuPriceChild";
            lblMenuPriceChild.Size = new Size(146, 15);
            lblMenuPriceChild.TabIndex = 4;
            lblMenuPriceChild.Text = "Precio por niño";
            // 
            // lblMenuPriceAdult
            // 
            lblMenuPriceAdult.AutoSize = true;
            lblMenuPriceAdult.Depth = 0;
            lblMenuPriceAdult.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            lblMenuPriceAdult.MouseState = MaterialSkin.MouseState.HOVER;
            lblMenuPriceAdult.Location = new Point(40, 182);
            lblMenuPriceAdult.Name = "lblMenuPriceAdult";
            lblMenuPriceAdult.Size = new Size(156, 15);
            lblMenuPriceAdult.TabIndex = 3;
            lblMenuPriceAdult.Text = "Precio por adulto";
            // 
            // mtbMenuDescription
            // 
            mtbMenuDescription.AnimateReadOnly = false;
            mtbMenuDescription.BorderStyle = BorderStyle.None;
            mtbMenuDescription.Depth = 0;
            mtbMenuDescription.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            mtbMenuDescription.LeadingIcon = null;
            mtbMenuDescription.Location = new Point(40, 112);
            mtbMenuDescription.MaxLength = 50;
            mtbMenuDescription.MouseState = MaterialSkin.MouseState.OUT;
            mtbMenuDescription.Multiline = false;
            mtbMenuDescription.Name = "mtbMenuDescription";
            mtbMenuDescription.Size = new Size(250, 50);
            mtbMenuDescription.TabIndex = 2;
            mtbMenuDescription.Text = "";
            mtbMenuDescription.TrailingIcon = null;
            // 
            // lblMenuDescription
            // 
            lblMenuDescription.AutoSize = true;
            lblMenuDescription.Depth = 0;
            lblMenuDescription.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            lblMenuDescription.MouseState = MaterialSkin.MouseState.HOVER;
            lblMenuDescription.Location = new Point(40, 90);
            lblMenuDescription.Name = "lblMenuDescription";
            lblMenuDescription.Size = new Size(185, 15);
            lblMenuDescription.TabIndex = 1;
            lblMenuDescription.Text = "Descripcion";
            // 
            // lblMenuFormTitle
            // 
            lblMenuFormTitle.AutoSize = true;
            lblMenuFormTitle.Depth = 0;
            lblMenuFormTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblMenuFormTitle.MouseState = MaterialSkin.MouseState.HOVER;
            lblMenuFormTitle.Location = new Point(40, 30);
            lblMenuFormTitle.Name = "lblMenuFormTitle";
            lblMenuFormTitle.Size = new Size(88, 15);
            lblMenuFormTitle.TabIndex = 0;
            lblMenuFormTitle.Text = "Carga de menu";
            // 
            // FormMenus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(panelMenuUpload);
            Controls.Add(panelMenusList);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormMenus";
            Text = "FormMenus";
            Load += FormMenus_Load;
            panelMenusList.ResumeLayout(false);
            panelMenusTitle.ResumeLayout(false);
            panelMenusTitle.PerformLayout();
            panelCrudCtrlMenus.ResumeLayout(false);
            panelMenuUpload.ResumeLayout(false);
            panelMenuUpload.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudMenuPriceAdult).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMenuPriceChild).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelMenusList;
        private Panel panelMenusTitle;
        private MaterialSkin.Controls.MaterialLabel lblMenusTitle;
        private MaterialSkin.Controls.MaterialListView mtLvMenus;
        private ColumnHeader Description;
        private ColumnHeader AdultPrice;
        private ColumnHeader ChildPrice;
        private ColumnHeader TagList;
        private Panel panelCrudCtrlMenus;
        private MaterialSkin.Controls.MaterialButton btnMenuRemove;
        private MaterialSkin.Controls.MaterialButton btnMenuEdit;
        private MaterialSkin.Controls.MaterialButton btnMenuCreate;
        private Panel panelMenuUpload;
        private MaterialSkin.Controls.MaterialButton btnMenuTags;
        private MaterialSkin.Controls.MaterialLabel lblMenuDescription;
        private MaterialSkin.Controls.MaterialLabel lblMenuFormTitle;
        private NumericUpDown nudMenuPriceChild;
        private NumericUpDown nudMenuPriceAdult;
        private MaterialSkin.Controls.MaterialLabel lblMenuPriceChild;
        private MaterialSkin.Controls.MaterialLabel lblMenuPriceAdult;
        private MaterialSkin.Controls.MaterialTextBox mtbMenuDescription;
        private CheckedListBox clbMenuTags;
        private MaterialSkin.Controls.MaterialButton btnBackMenu;
        private MaterialSkin.Controls.MaterialButton btnSaveMenu;
        private MaterialSkin.Controls.MaterialLabel lblMenuTags;
    }
}