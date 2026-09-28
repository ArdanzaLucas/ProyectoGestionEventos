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
            ListViewItem listViewItem9 = new ListViewItem("Ubicacion ");
            ListViewItem listViewItem10 = new ListViewItem("");
            ListViewItem listViewItem11 = new ListViewItem("");
            ListViewItem listViewItem12 = new ListViewItem("");
            ListViewItem listViewItem13 = new ListViewItem("");
            ListViewItem listViewItem14 = new ListViewItem("");
            ListViewItem listViewItem15 = new ListViewItem("");
            ListViewItem listViewItem16 = new ListViewItem("");
            panelMenuCU = new Panel();
            panelMenusList = new Panel();
            mtLvMenus = new MaterialSkin.Controls.MaterialListView();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            panelCrudCtrlMenus = new Panel();
            btnMenuRemove = new MaterialSkin.Controls.MaterialButton();
            btnMenuEdit = new MaterialSkin.Controls.MaterialButton();
            btnMenuCreate = new MaterialSkin.Controls.MaterialButton();
            panelMenusList.SuspendLayout();
            panelCrudCtrlMenus.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenuCU
            // 
            panelMenuCU.Dock = DockStyle.Right;
            panelMenuCU.Location = new Point(1080, 0);
            panelMenuCU.Name = "panelMenuCU";
            panelMenuCU.Size = new Size(200, 720);
            panelMenuCU.TabIndex = 4;
            // 
            // panelMenusList
            // 
            panelMenusList.Controls.Add(mtLvMenus);
            panelMenusList.Location = new Point(151, 0);
            panelMenusList.Name = "panelMenusList";
            panelMenusList.Size = new Size(340, 382);
            panelMenusList.TabIndex = 3;
            // 
            // mtLvMenus
            // 
            mtLvMenus.AutoSizeTable = false;
            mtLvMenus.BackColor = Color.FromArgb(255, 255, 255);
            mtLvMenus.BorderStyle = BorderStyle.None;
            mtLvMenus.Columns.AddRange(new ColumnHeader[] { columnHeader7, columnHeader8, columnHeader9, columnHeader10 });
            mtLvMenus.Depth = 0;
            mtLvMenus.FullRowSelect = true;
            mtLvMenus.Items.AddRange(new ListViewItem[] { listViewItem9, listViewItem10, listViewItem11, listViewItem12, listViewItem13, listViewItem14, listViewItem15, listViewItem16 });
            mtLvMenus.Location = new Point(30, 34);
            mtLvMenus.MinimumSize = new Size(200, 100);
            mtLvMenus.MouseLocation = new Point(-1, -1);
            mtLvMenus.MouseState = MaterialSkin.MouseState.OUT;
            mtLvMenus.Name = "mtLvMenus";
            mtLvMenus.OwnerDraw = true;
            mtLvMenus.Size = new Size(285, 324);
            mtLvMenus.TabIndex = 1;
            mtLvMenus.UseCompatibleStateImageBehavior = false;
            mtLvMenus.View = System.Windows.Forms.View.Details;
            // 
            // panelCrudCtrlMenus
            // 
            panelCrudCtrlMenus.BackColor = Color.White;
            panelCrudCtrlMenus.Controls.Add(btnMenuRemove);
            panelCrudCtrlMenus.Controls.Add(btnMenuEdit);
            panelCrudCtrlMenus.Controls.Add(btnMenuCreate);
            panelCrudCtrlMenus.Dock = DockStyle.Left;
            panelCrudCtrlMenus.Location = new Point(0, 0);
            panelCrudCtrlMenus.Name = "panelCrudCtrlMenus";
            panelCrudCtrlMenus.Size = new Size(151, 720);
            panelCrudCtrlMenus.TabIndex = 5;
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
            // 
            // FormMenus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(panelMenuCU);
            Controls.Add(panelMenusList);
            Controls.Add(panelCrudCtrlMenus);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormMenus";
            Text = "FormMenus";
            panelMenusList.ResumeLayout(false);
            panelCrudCtrlMenus.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenuCU;
        private Panel panelMenusList;
        private MaterialSkin.Controls.MaterialListView mtLvMenus;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private Panel panelCrudCtrlMenus;
        private MaterialSkin.Controls.MaterialButton btnMenuRemove;
        private MaterialSkin.Controls.MaterialButton btnMenuEdit;
        private MaterialSkin.Controls.MaterialButton btnMenuCreate;
    }
}