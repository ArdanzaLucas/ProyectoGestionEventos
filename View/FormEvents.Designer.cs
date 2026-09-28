namespace ProyectoPresupuestoEvento.View
{
    partial class FormEvents
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
            ListViewItem listViewItem1 = new ListViewItem("Ubicacion ");
            ListViewItem listViewItem2 = new ListViewItem("");
            ListViewItem listViewItem3 = new ListViewItem("");
            ListViewItem listViewItem4 = new ListViewItem("");
            ListViewItem listViewItem5 = new ListViewItem("");
            ListViewItem listViewItem6 = new ListViewItem("");
            ListViewItem listViewItem7 = new ListViewItem("");
            ListViewItem listViewItem8 = new ListViewItem("");
            panel1 = new Panel();
            panelCrudCtrlEv = new Panel();
            btnEventRemove = new MaterialSkin.Controls.MaterialButton();
            btnEventEdit = new MaterialSkin.Controls.MaterialButton();
            btnEventCreate = new MaterialSkin.Controls.MaterialButton();
            panelEventsList = new Panel();
            mtLvEvents = new MaterialSkin.Controls.MaterialListView();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            panelEventsCU = new Panel();
            panel1.SuspendLayout();
            panelCrudCtrlEv.SuspendLayout();
            panelEventsList.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panelCrudCtrlEv);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(151, 720);
            panel1.TabIndex = 0;
            // 
            // panelCrudCtrlEv
            // 
            panelCrudCtrlEv.BackColor = Color.White;
            panelCrudCtrlEv.Controls.Add(btnEventRemove);
            panelCrudCtrlEv.Controls.Add(btnEventEdit);
            panelCrudCtrlEv.Controls.Add(btnEventCreate);
            panelCrudCtrlEv.Dock = DockStyle.Left;
            panelCrudCtrlEv.Location = new Point(0, 0);
            panelCrudCtrlEv.Name = "panelCrudCtrlEv";
            panelCrudCtrlEv.Size = new Size(151, 720);
            panelCrudCtrlEv.TabIndex = 2;
            // 
            // btnEventRemove
            // 
            btnEventRemove.AutoSize = false;
            btnEventRemove.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEventRemove.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnEventRemove.Depth = 0;
            btnEventRemove.HighEmphasis = true;
            btnEventRemove.Icon = null;
            btnEventRemove.Location = new Point(36, 346);
            btnEventRemove.Margin = new Padding(4, 6, 4, 6);
            btnEventRemove.MouseState = MaterialSkin.MouseState.HOVER;
            btnEventRemove.Name = "btnEventRemove";
            btnEventRemove.NoAccentTextColor = Color.Empty;
            btnEventRemove.Size = new Size(90, 36);
            btnEventRemove.TabIndex = 2;
            btnEventRemove.Text = "Eliminar";
            btnEventRemove.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnEventRemove.UseAccentColor = false;
            btnEventRemove.UseVisualStyleBackColor = true;
            // 
            // btnEventEdit
            // 
            btnEventEdit.AutoSize = false;
            btnEventEdit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEventEdit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnEventEdit.Depth = 0;
            btnEventEdit.HighEmphasis = true;
            btnEventEdit.Icon = null;
            btnEventEdit.Location = new Point(36, 238);
            btnEventEdit.Margin = new Padding(4, 6, 4, 6);
            btnEventEdit.MouseState = MaterialSkin.MouseState.HOVER;
            btnEventEdit.Name = "btnEventEdit";
            btnEventEdit.NoAccentTextColor = Color.Empty;
            btnEventEdit.Size = new Size(90, 36);
            btnEventEdit.TabIndex = 1;
            btnEventEdit.Text = "Editar";
            btnEventEdit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnEventEdit.UseAccentColor = false;
            btnEventEdit.UseVisualStyleBackColor = true;
            // 
            // btnEventCreate
            // 
            btnEventCreate.AutoSize = false;
            btnEventCreate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEventCreate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnEventCreate.Depth = 0;
            btnEventCreate.HighEmphasis = true;
            btnEventCreate.Icon = null;
            btnEventCreate.Location = new Point(36, 115);
            btnEventCreate.Margin = new Padding(4, 6, 4, 6);
            btnEventCreate.MouseState = MaterialSkin.MouseState.HOVER;
            btnEventCreate.Name = "btnEventCreate";
            btnEventCreate.NoAccentTextColor = Color.Empty;
            btnEventCreate.Size = new Size(90, 36);
            btnEventCreate.TabIndex = 0;
            btnEventCreate.Text = "Crear";
            btnEventCreate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnEventCreate.UseAccentColor = false;
            btnEventCreate.UseVisualStyleBackColor = true;
            // 
            // panelEventsList
            // 
            panelEventsList.Controls.Add(mtLvEvents);
            panelEventsList.Dock = DockStyle.Fill;
            panelEventsList.Location = new Point(151, 0);
            panelEventsList.Name = "panelEventsList";
            panelEventsList.Size = new Size(1129, 720);
            panelEventsList.TabIndex = 1;
            // 
            // mtLvEvents
            // 
            mtLvEvents.AutoSizeTable = false;
            mtLvEvents.BackColor = Color.FromArgb(255, 255, 255);
            mtLvEvents.BorderStyle = BorderStyle.None;
            mtLvEvents.Columns.AddRange(new ColumnHeader[] { columnHeader7, columnHeader8, columnHeader9, columnHeader10 });
            mtLvEvents.Depth = 0;
            mtLvEvents.Dock = DockStyle.Fill;
            mtLvEvents.FullRowSelect = true;
            mtLvEvents.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3, listViewItem4, listViewItem5, listViewItem6, listViewItem7, listViewItem8 });
            mtLvEvents.Location = new Point(0, 0);
            mtLvEvents.MinimumSize = new Size(200, 100);
            mtLvEvents.MouseLocation = new Point(-1, -1);
            mtLvEvents.MouseState = MaterialSkin.MouseState.OUT;
            mtLvEvents.Name = "mtLvEvents";
            mtLvEvents.OwnerDraw = true;
            mtLvEvents.Size = new Size(1129, 720);
            mtLvEvents.TabIndex = 1;
            mtLvEvents.UseCompatibleStateImageBehavior = false;
            mtLvEvents.View = System.Windows.Forms.View.Details;
            // 
            // panelEventsCU
            // 
            panelEventsCU.Dock = DockStyle.Right;
            panelEventsCU.Location = new Point(1080, 0);
            panelEventsCU.Name = "panelEventsCU";
            panelEventsCU.Size = new Size(200, 720);
            panelEventsCU.TabIndex = 2;
            panelEventsCU.Paint += panel3_Paint;
            // 
            // FormEvents
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(panelEventsCU);
            Controls.Add(panelEventsList);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormEvents";
            Text = "FormEvents";
            panel1.ResumeLayout(false);
            panelCrudCtrlEv.ResumeLayout(false);
            panelEventsList.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panelEventsList;
        private Panel panelEventsCU;
        private MaterialSkin.Controls.MaterialListView mtLvEvents;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private Panel panelCrudCtrlEv;
        private MaterialSkin.Controls.MaterialButton btnEventRemove;
        private MaterialSkin.Controls.MaterialButton btnEventEdit;
        private MaterialSkin.Controls.MaterialButton btnEventCreate;
    }
}