namespace ProyectoPresupuestoEvento.View
{
    partial class FormReport
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
            printPreview = new PrintPreviewControl();
            panelReportTitle = new Panel();
            lblReportTitle = new Label();
            panelCrudCtrlReport = new Panel();
            btnImprimir = new MaterialSkin.Controls.MaterialButton();
            btnVolverReport = new MaterialSkin.Controls.MaterialButton();
            panelReportTitle.SuspendLayout();
            panelCrudCtrlReport.SuspendLayout();
            SuspendLayout();
            //
            // printPreview
            //
            printPreview.AutoZoom = false;
            printPreview.Dock = DockStyle.Fill;
            printPreview.Name = "printPreview";
            printPreview.TabIndex = 0;
            printPreview.UseAntiAlias = true;
            printPreview.Zoom = 1D;
            printPreview.Resize += printPreview_Resize;
            //
            // panelReportTitle
            //
            panelReportTitle.BackColor = Color.White;
            panelReportTitle.Controls.Add(lblReportTitle);
            panelReportTitle.Dock = DockStyle.Top;
            panelReportTitle.Name = "panelReportTitle";
            panelReportTitle.Size = new Size(500, 45);
            panelReportTitle.TabIndex = 1;
            //
            // lblReportTitle
            //
            lblReportTitle.AutoSize = true;
            lblReportTitle.Font = new Font("Georgia", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReportTitle.Location = new Point(15, 10);
            lblReportTitle.Name = "lblReportTitle";
            lblReportTitle.Size = new Size(100, 24);
            lblReportTitle.TabIndex = 0;
            lblReportTitle.Text = "Detalle del presupuesto";
            //
            // panelCrudCtrlReport
            //
            panelCrudCtrlReport.BackColor = Color.White;
            panelCrudCtrlReport.Controls.Add(btnImprimir);
            panelCrudCtrlReport.Controls.Add(btnVolverReport);
            panelCrudCtrlReport.Dock = DockStyle.Left;
            panelCrudCtrlReport.Location = new Point(0, 0);
            panelCrudCtrlReport.Name = "panelCrudCtrlReport";
            panelCrudCtrlReport.Size = new Size(151, 720);
            panelCrudCtrlReport.TabIndex = 2;
            //
            // btnImprimir
            //
            btnImprimir.AutoSize = false;
            btnImprimir.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnImprimir.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnImprimir.Depth = 0;
            btnImprimir.HighEmphasis = true;
            btnImprimir.Icon = null;
            btnImprimir.Location = new Point(25, 40);
            btnImprimir.Margin = new Padding(4, 6, 4, 6);
            btnImprimir.MouseState = MaterialSkin.MouseState.HOVER;
            btnImprimir.Name = "btnImprimir";
            btnImprimir.NoAccentTextColor = Color.Empty;
            btnImprimir.Size = new Size(100, 36);
            btnImprimir.TabIndex = 0;
            btnImprimir.Text = "Imprimir";
            btnImprimir.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnImprimir.UseAccentColor = false;
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            //
            // btnVolverReport
            //
            btnVolverReport.AutoSize = false;
            btnVolverReport.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnVolverReport.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnVolverReport.Depth = 0;
            btnVolverReport.HighEmphasis = true;
            btnVolverReport.Icon = null;
            btnVolverReport.Location = new Point(25, 100);
            btnVolverReport.Margin = new Padding(4, 6, 4, 6);
            btnVolverReport.MouseState = MaterialSkin.MouseState.HOVER;
            btnVolverReport.Name = "btnVolverReport";
            btnVolverReport.NoAccentTextColor = Color.Empty;
            btnVolverReport.Size = new Size(100, 36);
            btnVolverReport.TabIndex = 1;
            btnVolverReport.Text = "Volver";
            btnVolverReport.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnVolverReport.UseAccentColor = false;
            btnVolverReport.UseVisualStyleBackColor = true;
            btnVolverReport.Click += btnVolverReport_Click;
            //
            // FormReport
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(printPreview);
            Controls.Add(panelReportTitle);
            Controls.Add(panelCrudCtrlReport);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormReport";
            Text = "FormReport";
            panelReportTitle.ResumeLayout(false);
            panelReportTitle.PerformLayout();
            panelCrudCtrlReport.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PrintPreviewControl printPreview;
        private Panel panelReportTitle;
        private Label lblReportTitle;
        private Panel panelCrudCtrlReport;
        private MaterialSkin.Controls.MaterialButton btnImprimir;
        private MaterialSkin.Controls.MaterialButton btnVolverReport;
    }
}
