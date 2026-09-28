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
            ListViewItem listViewItem9 = new ListViewItem("Ubicacion ");
            ListViewItem listViewItem10 = new ListViewItem("");
            ListViewItem listViewItem11 = new ListViewItem("");
            ListViewItem listViewItem12 = new ListViewItem("");
            ListViewItem listViewItem13 = new ListViewItem("");
            ListViewItem listViewItem14 = new ListViewItem("");
            ListViewItem listViewItem15 = new ListViewItem("");
            ListViewItem listViewItem16 = new ListViewItem("");
            panelOICU = new Panel();
            panelOIList = new Panel();
            mtLvOptionItems = new MaterialSkin.Controls.MaterialListView();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            panelCrudCtrlOI = new Panel();
            btnOIRemove = new MaterialSkin.Controls.MaterialButton();
            btnOIEdit = new MaterialSkin.Controls.MaterialButton();
            btnOICreate = new MaterialSkin.Controls.MaterialButton();
            panelOIList.SuspendLayout();
            panelCrudCtrlOI.SuspendLayout();
            SuspendLayout();
            // 
            // panelOICU
            // 
            panelOICU.Dock = DockStyle.Right;
            panelOICU.Location = new Point(1080, 0);
            panelOICU.Name = "panelOICU";
            panelOICU.Size = new Size(200, 720);
            panelOICU.TabIndex = 4;
            // 
            // panelOIList
            // 
            panelOIList.Controls.Add(mtLvOptionItems);
            panelOIList.Location = new Point(151, 0);
            panelOIList.Name = "panelOIList";
            panelOIList.Size = new Size(323, 326);
            panelOIList.TabIndex = 3;
            // 
            // mtLvOptionItems
            // 
            mtLvOptionItems.AutoSizeTable = false;
            mtLvOptionItems.BackColor = Color.FromArgb(255, 255, 255);
            mtLvOptionItems.BorderStyle = BorderStyle.None;
            mtLvOptionItems.Columns.AddRange(new ColumnHeader[] { columnHeader7, columnHeader8, columnHeader9, columnHeader10 });
            mtLvOptionItems.Depth = 0;
            mtLvOptionItems.FullRowSelect = true;
            mtLvOptionItems.Items.AddRange(new ListViewItem[] { listViewItem9, listViewItem10, listViewItem11, listViewItem12, listViewItem13, listViewItem14, listViewItem15, listViewItem16 });
            mtLvOptionItems.Location = new Point(30, 34);
            mtLvOptionItems.MinimumSize = new Size(200, 100);
            mtLvOptionItems.MouseLocation = new Point(-1, -1);
            mtLvOptionItems.MouseState = MaterialSkin.MouseState.OUT;
            mtLvOptionItems.Name = "mtLvOptionItems";
            mtLvOptionItems.OwnerDraw = true;
            mtLvOptionItems.Size = new Size(285, 324);
            mtLvOptionItems.TabIndex = 1;
            mtLvOptionItems.UseCompatibleStateImageBehavior = false;
            mtLvOptionItems.View = System.Windows.Forms.View.Details;
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
            panelCrudCtrlOI.Size = new Size(151, 720);
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
            // 
            // FormOptionItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(panelOICU);
            Controls.Add(panelOIList);
            Controls.Add(panelCrudCtrlOI);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormOptionItem";
            Text = "FormOptionItem";
            panelOIList.ResumeLayout(false);
            panelCrudCtrlOI.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelOICU;
        private Panel panelOIList;
        private MaterialSkin.Controls.MaterialListView mtLvOptionItems;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private Panel panelCrudCtrlOI;
        private MaterialSkin.Controls.MaterialButton btnOIRemove;
        private MaterialSkin.Controls.MaterialButton btnOIEdit;
        private MaterialSkin.Controls.MaterialButton btnOICreate;
    }
}