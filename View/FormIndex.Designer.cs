namespace ProyectoPresupuestoEvento.View
{
    partial class FormIndex
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
            ListViewGroup listViewGroup1 = new ListViewGroup("ListViewGroup", HorizontalAlignment.Left);
            ListViewGroup listViewGroup2 = new ListViewGroup("ListViewGroup", HorizontalAlignment.Left);
            ListViewGroup listViewGroup3 = new ListViewGroup("ListViewGroup", HorizontalAlignment.Left);
            ListViewGroup listViewGroup4 = new ListViewGroup("ListViewGroup", HorizontalAlignment.Left);
            ListViewGroup listViewGroup5 = new ListViewGroup("ListViewGroup", HorizontalAlignment.Left);
            ListViewItem listViewItem1 = new ListViewItem(new string[] { "1", "Salon 2", "$20000", "100", "$50000", "$150000" }, -1);
            ListViewItem listViewItem2 = new ListViewItem("1");
            ListViewItem listViewItem3 = new ListViewItem("2");
            panelIndexCtrl = new Panel();
            btnIndexRemove = new MaterialSkin.Controls.MaterialButton();
            btnIndexReport = new MaterialSkin.Controls.MaterialButton();
            panel5 = new Panel();
            mtLvIndex = new MaterialSkin.Controls.MaterialListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            panelIndexCtrl.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panelIndexCtrl
            // 
            panelIndexCtrl.Controls.Add(btnIndexRemove);
            panelIndexCtrl.Controls.Add(btnIndexReport);
            panelIndexCtrl.Dock = DockStyle.Bottom;
            panelIndexCtrl.Location = new Point(0, 620);
            panelIndexCtrl.Name = "panelIndexCtrl";
            panelIndexCtrl.Size = new Size(1280, 100);
            panelIndexCtrl.TabIndex = 3;
            // 
            // btnIndexRemove
            // 
            btnIndexRemove.AutoSize = false;
            btnIndexRemove.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnIndexRemove.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnIndexRemove.Depth = 0;
            btnIndexRemove.HighEmphasis = true;
            btnIndexRemove.Icon = null;
            btnIndexRemove.Location = new Point(643, 30);
            btnIndexRemove.Margin = new Padding(4, 6, 4, 6);
            btnIndexRemove.MouseState = MaterialSkin.MouseState.HOVER;
            btnIndexRemove.Name = "btnIndexRemove";
            btnIndexRemove.NoAccentTextColor = Color.Empty;
            btnIndexRemove.Size = new Size(90, 36);
            btnIndexRemove.TabIndex = 1;
            btnIndexRemove.Text = "Eliminar";
            btnIndexRemove.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnIndexRemove.UseAccentColor = false;
            btnIndexRemove.UseVisualStyleBackColor = true;
            // 
            // btnIndexReport
            // 
            btnIndexReport.AutoSize = false;
            btnIndexReport.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnIndexReport.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnIndexReport.Depth = 0;
            btnIndexReport.HighEmphasis = true;
            btnIndexReport.Icon = null;
            btnIndexReport.Location = new Point(258, 30);
            btnIndexReport.Margin = new Padding(4, 6, 4, 6);
            btnIndexReport.MouseState = MaterialSkin.MouseState.HOVER;
            btnIndexReport.Name = "btnIndexReport";
            btnIndexReport.NoAccentTextColor = Color.Empty;
            btnIndexReport.Size = new Size(90, 36);
            btnIndexReport.TabIndex = 0;
            btnIndexReport.Text = "Detalle";
            btnIndexReport.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnIndexReport.UseAccentColor = false;
            btnIndexReport.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            panel5.Controls.Add(mtLvIndex);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(1280, 720);
            panel5.TabIndex = 2;
            // 
            // mtLvIndex
            // 
            mtLvIndex.AutoSizeTable = false;
            mtLvIndex.BackColor = Color.FromArgb(255, 255, 255);
            mtLvIndex.BorderStyle = BorderStyle.None;
            mtLvIndex.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
            mtLvIndex.Depth = 0;
            mtLvIndex.Dock = DockStyle.Fill;
            mtLvIndex.FullRowSelect = true;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "listViewGroup1";
            listViewGroup2.Header = "ListViewGroup";
            listViewGroup2.Name = "listViewGroup2";
            listViewGroup3.Header = "ListViewGroup";
            listViewGroup3.Name = "listViewGroup3";
            listViewGroup4.Header = "ListViewGroup";
            listViewGroup4.Name = "listViewGroup4";
            listViewGroup5.Header = "ListViewGroup";
            listViewGroup5.Name = "listViewGroup5";
            mtLvIndex.Groups.AddRange(new ListViewGroup[] { listViewGroup1, listViewGroup2, listViewGroup3, listViewGroup4, listViewGroup5 });
            mtLvIndex.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3 });
            mtLvIndex.Location = new Point(0, 0);
            mtLvIndex.MinimumSize = new Size(200, 100);
            mtLvIndex.MouseLocation = new Point(-1, -1);
            mtLvIndex.MouseState = MaterialSkin.MouseState.OUT;
            mtLvIndex.Name = "mtLvIndex";
            mtLvIndex.OwnerDraw = true;
            mtLvIndex.Size = new Size(1280, 720);
            mtLvIndex.TabIndex = 0;
            mtLvIndex.UseCompatibleStateImageBehavior = false;
            mtLvIndex.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Evento";
            columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Ubicacion";
            columnHeader2.Width = 110;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Servicios";
            columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Invitados";
            columnHeader4.Width = 90;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Catering";
            columnHeader5.Width = 90;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Total";
            columnHeader6.Width = 90;
            // 
            // FormIndex
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(panelIndexCtrl);
            Controls.Add(panel5);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormIndex";
            Text = "FormIndex";
            panelIndexCtrl.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelIndexCtrl;
        private MaterialSkin.Controls.MaterialButton btnIndexRemove;
        private MaterialSkin.Controls.MaterialButton btnIndexReport;
        private Panel panel5;
        private MaterialSkin.Controls.MaterialListView mtLvIndex;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
    }
}