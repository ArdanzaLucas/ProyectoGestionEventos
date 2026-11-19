using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using ProyectoPresupuestoEvento.Model;
using ProyectoPresupuestoEvento.Common;
using ProyectoPresupuestoEvento.Interface;

namespace ProyectoPresupuestoEvento.Service
{
    // arma el pdf del presupuesto con la libreria PDFsharp; lo usa QuoteService
    internal class QuotePdfGenerator : IQuoteDocumentGenerator
    {
        private XFont fontTitle = new XFont("Georgia", 18, XFontStyleEx.Bold);
        private XFont fontSection = new XFont("Georgia", 12, XFontStyleEx.Bold);
        private XFont fontText = new XFont("Segoe UI", 9.5, XFontStyleEx.Regular);
        private XFont fontBold = new XFont("Segoe UI", 9.5, XFontStyleEx.Bold);
        private XFont fontTotal = new XFont("Segoe UI", 13, XFontStyleEx.Bold);

        private IClock clock;
        private PdfDocument document;
        private XGraphics g;
        private double left;
        private double right;
        private double bottom;
        private double y;

        public QuotePdfGenerator(IClock clock)
        {
            this.clock = clock;
        }

        // genera el archivo con los datos congelados del presupuesto
        public void Generate(Quote quote, string path)
        {
            document = new PdfDocument();
            document.Info.Title = "Presupuesto " + quote.Id;
            NewPage();

            DrawHeader(quote);
            DrawEvent(quote);
            DrawLocation(quote);
            DrawMenus(quote);
            DrawOptionItems(quote);
            DrawTotals(quote);

            g.Dispose();
            g = null;
            document.Save(path);
        }

        private void DrawHeader(Quote quote)
        {
            Write("Presupuesto N° " + quote.Id, fontTitle, left);
            WriteRight("Estado: " + QuoteStateText.GetDisplayName(quote.State), fontBold, right, y + 6);
            y = y + 30;
            Write("Emitido el " + clock.Today.ToString("dd/MM/yyyy"), fontText, left);
            y = y + 20;
            g.DrawLine(XPens.Gray, left, y, right, y);
            y = y + 12;
        }

        private void DrawEvent(Quote quote)
        {
            Write("Evento", fontSection, left);
            y = y + 18;
            Write("Nombre: " + quote.EventName, fontText, left);
            y = y + 15;
            Write("Cliente: " + quote.EventClientName, fontText, left);
            y = y + 15;
            Write("Fecha y hora: " + quote.EventDate.ToString("dd/MM/yyyy HH:mm"), fontText, left);
            y = y + 15;
            Write("Invitados: " + quote.EventGuestAdults + " adultos / " + quote.EventGuestChildren + " niños", fontText, left);
            y = y + 15;
            Write("Duracion: " + quote.EventDuration + " horas", fontText, left);
            y = y + 25;
        }

        private void DrawLocation(Quote quote)
        {
            Write("Ubicacion", fontSection, left);
            y = y + 18;
            Write(quote.LocationName + ": " + quote.LocationPrice.ToString("C") + " por hora x " + quote.EventDuration + " horas",
                fontText, left);
            WriteRight(quote.TotalLocation.ToString("C"), fontText, right, y);
            y = y + 25;
        }

        private void DrawMenus(Quote quote)
        {
            EnsureSpace(60);
            Write("Catering", fontSection, left);
            y = y + 18;

            if (quote.MenusList.Count == 0)
            {
                Write("Sin catering", fontText, left);
                y = y + 15;
            }
            else
            {
                DrawMenuTableHeader();

                foreach (DetailMenu detailMenu in quote.MenusList)
                {
                    // si la linea no entra, sigue en una pagina nueva con el encabezado de la tabla
                    if (EnsureSpace(15))
                    {
                        DrawMenuTableHeader();
                    }
                    Write(Cut(detailMenu.MenuDescription, fontText, 95), fontText, left);
                    Write(Cut(detailMenu.TagDescription, fontText, 75), fontText, left + 100);
                    WriteRight(detailMenu.AdultQuantity.ToString(), fontText, left + 215, y);
                    WriteRight(detailMenu.ChildQuantity.ToString(), fontText, left + 255, y);
                    WriteRight(detailMenu.UnitPriceAdult.ToString("C"), fontText, left + 325, y);
                    WriteRight(detailMenu.UnitPriceChild.ToString("C"), fontText, left + 390, y);
                    WriteRight(detailMenu.Subtotal.ToString("C"), fontText, right, y);
                    y = y + 15;
                }
            }
            y = y + 12;
        }

        private void DrawMenuTableHeader()
        {
            Write("Menu", fontBold, left);
            Write("Etiqueta", fontBold, left + 100);
            WriteRight("Adultos", fontBold, left + 215, y);
            WriteRight("Niños", fontBold, left + 255, y);
            WriteRight("P. adulto", fontBold, left + 325, y);
            WriteRight("P. niño", fontBold, left + 390, y);
            WriteRight("Subtotal", fontBold, right, y);
            y = y + 15;
            g.DrawLine(XPens.Gray, left, y, right, y);
            y = y + 4;
        }

        private void DrawOptionItems(Quote quote)
        {
            EnsureSpace(40);
            Write("Servicios", fontSection, left);
            y = y + 18;

            if (quote.OptionItemList.Count == 0)
            {
                Write("Sin servicios", fontText, left);
                y = y + 15;
            }
            else
            {
                foreach (DetailOptionItem detailOptionItem in quote.OptionItemList)
                {
                    EnsureSpace(15);
                    Write(detailOptionItem.OptionItemName, fontText, left);
                    WriteRight(detailOptionItem.UnitPrice.ToString("C"), fontText, right, y);
                    y = y + 15;
                }
            }
            y = y + 15;
        }

        // el bloque de totales no se parte entre dos paginas
        private void DrawTotals(Quote quote)
        {
            EnsureSpace(80);
            g.DrawLine(XPens.Gray, left, y, right, y);
            y = y + 8;
            WriteRight("Ubicacion: " + quote.TotalLocation.ToString("C"), fontText, right, y);
            y = y + 15;
            WriteRight("Catering: " + quote.TotalMenus.ToString("C"), fontText, right, y);
            y = y + 15;
            WriteRight("Servicios: " + quote.TotalOptionItems.ToString("C"), fontText, right, y);
            y = y + 22;
            WriteRight("TOTAL: " + quote.Total.ToString("C"), fontTotal, right, y);
        }

        // agrega una hoja A4 y vuelve a escribir desde arriba
        private void NewPage()
        {
            if (g != null)
            {
                g.Dispose();
            }

            PdfPage page = document.AddPage();
            page.Size = PageSize.A4;
            g = XGraphics.FromPdfPage(page);
            left = 56;
            right = page.Width.Point - 56;
            bottom = page.Height.Point - 56;
            y = 56;
        }

        // si lo que sigue no entra en la hoja, pasa a una nueva; devuelve true si cambio de pagina
        private bool EnsureSpace(double height)
        {
            if (y + height <= bottom)
            {
                return false;
            }
            NewPage();
            return true;
        }

        // escribe un texto desde x, en la altura actual
        private void Write(string text, XFont font, double x)
        {
            g.DrawString(text, font, XBrushes.Black, new XRect(x, y, right - x, 20), XStringFormats.TopLeft);
        }

        // escribe un texto alineado a la derecha, terminando en x
        private void WriteRight(string text, XFont font, double x, double top)
        {
            g.DrawString(text, font, XBrushes.Black, new XRect(left, top, x - left, 20), XStringFormats.TopRight);
        }

        // acorta el texto con "..." si no entra en el ancho
        private string Cut(string text, XFont font, double width)
        {
            if (g.MeasureString(text, font).Width <= width)
            {
                return text;
            }
            while (text.Length > 1 && g.MeasureString(text + "...", font).Width > width)
            {
                text = text.Substring(0, text.Length - 1);
            }
            return text + "...";
        }
    }
}
