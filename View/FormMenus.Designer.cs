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
            lblMenusTitle = new Label();
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
            btnVolverMenu = new MaterialSkin.Controls.MaterialButton();
            btnGuardarMenu = new MaterialSkin.Controls.MaterialButton();
            label5 = new Label();
            clbMenuTags = new CheckedListBox();
            mtbMenuPriceChild = new MaterialSkin.Controls.MaterialTextBox();
            mtbMenuPriceAdult = new MaterialSkin.Controls.MaterialTextBox();
            label4 = new Label();
            label3 = new Label();
            mtbMenuDescription = new MaterialSkin.Controls.MaterialTextBox();
            label2 = new Label();
            label1 = new Label();
            panelMenusList.SuspendLayout();
            panelMenusTitle.SuspendLayout();
            panelCrudCtrlMenus.SuspendLayout();
            panelMenuUpload.SuspendLayout();
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
            lblMenusTitle.Font = new Font("Georgia", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
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
            panelMenuUpload.Controls.Add(btnVolverMenu);
            panelMenuUpload.Controls.Add(btnGuardarMenu);
            panelMenuUpload.Controls.Add(label5);
            panelMenuUpload.Controls.Add(clbMenuTags);
            panelMenuUpload.Controls.Add(mtbMenuPriceChild);
            panelMenuUpload.Controls.Add(mtbMenuPriceAdult);
            panelMenuUpload.Controls.Add(label4);
            panelMenuUpload.Controls.Add(label3);
            panelMenuUpload.Controls.Add(mtbMenuDescription);
            panelMenuUpload.Controls.Add(label2);
            panelMenuUpload.Controls.Add(label1);
            panelMenuUpload.Location = new Point(640, 0);
            panelMenuUpload.Name = "panelMenuUpload";
            panelMenuUpload.Size = new Size(641, 677);
            panelMenuUpload.TabIndex = 6;
            // 
            // btnVolverMenu
            // 
            btnVolverMenu.AutoSize = false;
            btnVolverMenu.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnVolverMenu.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnVolverMenu.Depth = 0;
            btnVolverMenu.HighEmphasis = true;
            btnVolverMenu.Icon = null;
            btnVolverMenu.Location = new Point(335, 476);
            btnVolverMenu.Margin = new Padding(4, 6, 4, 6);
            btnVolverMenu.MouseState = MaterialSkin.MouseState.HOVER;
            btnVolverMenu.Name = "btnVolverMenu";
            btnVolverMenu.NoAccentTextColor = Color.Empty;
            btnVolverMenu.Size = new Size(90, 36);
            btnVolverMenu.TabIndex = 10;
            btnVolverMenu.Text = "Volver";
            btnVolverMenu.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnVolverMenu.UseAccentColor = false;
            btnVolverMenu.UseVisualStyleBackColor = true;
            btnVolverMenu.Click += btnVolverMenu_Click;
            // 
            // btnGuardarMenu
            // 
            btnGuardarMenu.AutoSize = false;
            btnGuardarMenu.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGuardarMenu.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnGuardarMenu.Depth = 0;
            btnGuardarMenu.HighEmphasis = true;
            btnGuardarMenu.Icon = null;
            btnGuardarMenu.Location = new Point(144, 476);
            btnGuardarMenu.Margin = new Padding(4, 6, 4, 6);
            btnGuardarMenu.MouseState = MaterialSkin.MouseState.HOVER;
            btnGuardarMenu.Name = "btnGuardarMenu";
            btnGuardarMenu.NoAccentTextColor = Color.Empty;
            btnGuardarMenu.Size = new Size(90, 36);
            btnGuardarMenu.TabIndex = 9;
            btnGuardarMenu.Text = "Guardar";
            btnGuardarMenu.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnGuardarMenu.UseAccentColor = false;
            btnGuardarMenu.UseVisualStyleBackColor = true;
            btnGuardarMenu.Click += btnGuardarMenu_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(370, 78);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 8;
            label5.Text = "Etiquetas";
            // 
            // clbMenuTags
            // 
            clbMenuTags.FormattingEnabled = true;
            clbMenuTags.Location = new Point(351, 115);
            clbMenuTags.CheckOnClick = true;
            clbMenuTags.Name = "clbMenuTags";
            clbMenuTags.Size = new Size(120, 94);
            clbMenuTags.TabIndex = 7;
            // 
            // mtbMenuPriceChild
            // 
            mtbMenuPriceChild.AnimateReadOnly = false;
            mtbMenuPriceChild.BorderStyle = BorderStyle.None;
            mtbMenuPriceChild.Depth = 0;
            mtbMenuPriceChild.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            mtbMenuPriceChild.LeadingIcon = null;
            mtbMenuPriceChild.Location = new Point(73, 324);
            mtbMenuPriceChild.MaxLength = 50;
            mtbMenuPriceChild.MouseState = MaterialSkin.MouseState.OUT;
            mtbMenuPriceChild.Multiline = false;
            mtbMenuPriceChild.Name = "mtbMenuPriceChild";
            mtbMenuPriceChild.Size = new Size(100, 50);
            mtbMenuPriceChild.TabIndex = 6;
            mtbMenuPriceChild.Text = "";
            mtbMenuPriceChild.TrailingIcon = null;
            // 
            // mtbMenuPriceAdult
            // 
            mtbMenuPriceAdult.AnimateReadOnly = false;
            mtbMenuPriceAdult.BorderStyle = BorderStyle.None;
            mtbMenuPriceAdult.Depth = 0;
            mtbMenuPriceAdult.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            mtbMenuPriceAdult.LeadingIcon = null;
            mtbMenuPriceAdult.Location = new Point(78, 204);
            mtbMenuPriceAdult.MaxLength = 50;
            mtbMenuPriceAdult.MouseState = MaterialSkin.MouseState.OUT;
            mtbMenuPriceAdult.Multiline = false;
            mtbMenuPriceAdult.Name = "mtbMenuPriceAdult";
            mtbMenuPriceAdult.Size = new Size(100, 50);
            mtbMenuPriceAdult.TabIndex = 5;
            mtbMenuPriceAdult.Text = "";
            mtbMenuPriceAdult.TrailingIcon = null;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(73, 294);
            label4.Name = "label4";
            label4.Size = new Size(146, 15);
            label4.TabIndex = 4;
            label4.Text = "ingresa un precio por niño";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(78, 176);
            label3.Name = "label3";
            label3.Size = new Size(156, 15);
            label3.TabIndex = 3;
            label3.Text = "ingresa un precio por adulto";
            // 
            // mtbMenuDescription
            // 
            mtbMenuDescription.AnimateReadOnly = false;
            mtbMenuDescription.BorderStyle = BorderStyle.None;
            mtbMenuDescription.Depth = 0;
            mtbMenuDescription.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            mtbMenuDescription.LeadingIcon = null;
            mtbMenuDescription.Location = new Point(78, 115);
            mtbMenuDescription.MaxLength = 50;
            mtbMenuDescription.MouseState = MaterialSkin.MouseState.OUT;
            mtbMenuDescription.Multiline = false;
            mtbMenuDescription.Name = "mtbMenuDescription";
            mtbMenuDescription.Size = new Size(100, 50);
            mtbMenuDescription.TabIndex = 2;
            mtbMenuDescription.Text = "";
            mtbMenuDescription.TrailingIcon = null;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(78, 78);
            label2.Name = "label2";
            label2.Size = new Size(185, 15);
            label2.TabIndex = 1;
            label2.Text = "Ingresa una descripcion del menu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(221, 34);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 0;
            label1.Text = "Carga de menu";
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
            ResumeLayout(false);
        }

        #endregion
        private Panel panelMenusList;
        private Panel panelMenusTitle;
        private Label lblMenusTitle;
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
        private Label label2;
        private Label label1;
        private MaterialSkin.Controls.MaterialTextBox mtbMenuPriceChild;
        private MaterialSkin.Controls.MaterialTextBox mtbMenuPriceAdult;
        private Label label4;
        private Label label3;
        private MaterialSkin.Controls.MaterialTextBox mtbMenuDescription;
        private CheckedListBox clbMenuTags;
        private MaterialSkin.Controls.MaterialButton btnVolverMenu;
        private MaterialSkin.Controls.MaterialButton btnGuardarMenu;
        private Label label5;
    }
}