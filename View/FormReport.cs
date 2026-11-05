using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoPresupuestoEvento.Dto;

namespace ProyectoPresupuestoEvento.View
{
    public partial class FormReport : Form
    {
        private FormIndex formIndex;

        private QuoteDto quote;
        private QuotePdf pdf;

        public FormReport(FormIndex formIndex)
        {
            this.formIndex = formIndex;
            InitializeComponent();
        }

        public void showQuote(QuoteDto quote)
        {
            this.quote = quote;
            pdf = new QuotePdf(quote);

            lblReportTitle.Text = "Detalle del presupuesto N° " + quote.Id;

            printPreview.Document = pdf.getDocument();
            ajustarZoom();
        }

        private void ajustarZoom()
        {
            int anchoDisponible = printPreview.Width - 40;
            if (printPreview.Document == null || anchoDisponible <= 0)
            {
                return;
            }

            int anchoHoja = printPreview.Document.DefaultPageSettings.PaperSize.Width;
            printPreview.Zoom = (double)anchoDisponible / anchoHoja;
        }

        private void printPreview_Resize(object sender, EventArgs e)
        {
            ajustarZoom();
        }

        private void btnVolverReport_Click(object sender, EventArgs e)
        {
            this.Hide();
            formIndex.Show();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string nombre = "Presupuesto_" + quote.Id + "_" + quote.EventItemName;
            foreach (char caracter in Path.GetInvalidFileNameChars())
            {
                nombre = nombre.Replace(caracter, '_');
            }
            nombre = nombre.Replace(' ', '_');

            SaveFileDialog dialogo = new SaveFileDialog();
            dialogo.Title = "Guardar presupuesto en PDF";
            dialogo.Filter = "Archivo PDF (*.pdf)|*.pdf";
            dialogo.FileName = nombre + ".pdf";

            if (dialogo.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                pdf.save(dialogo.FileName);
            }
            catch (Exception ex)
            {
                MessageHelper.showError("no se pudo guardar el PDF: " + ex.Message);
                return;
            }

            if (!File.Exists(dialogo.FileName))
            {
                MessageHelper.showError("no se pudo crear el PDF");
                return;
            }

            MessageHelper.showInfo("el PDF se guardo en " + dialogo.FileName);
        }
    }
}
