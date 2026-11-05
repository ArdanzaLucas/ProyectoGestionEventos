using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Dto;

namespace ProyectoPresupuestoEvento.View
{
    public class QuotePdf
    {
        private QuoteDto quote;
        private PrintDocument printDocument;

        private Font fontTitulo = new Font("Georgia", 18, FontStyle.Bold);
        private Font fontSeccion = new Font("Georgia", 12, FontStyle.Bold);
        private Font fontTexto = new Font("Segoe UI", 10);
        private Font fontNegrita = new Font("Segoe UI", 10, FontStyle.Bold);
        private Font fontTotal = new Font("Segoe UI", 13, FontStyle.Bold);

        private StringFormat alDerecha = new StringFormat();

        private StringFormat cortar = new StringFormat();

        public QuotePdf(QuoteDto quote)
        {
            this.quote = quote;

            alDerecha.Alignment = StringAlignment.Far;
            cortar.Trimming = StringTrimming.EllipsisCharacter;
            cortar.FormatFlags = StringFormatFlags.NoWrap;

            printDocument = new PrintDocument();
            printDocument.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            printDocument.PrintPage += printDocument_PrintPage;
        }

        public PrintDocument getDocument()
        {
            return printDocument;
        }

        public void save(string ruta)
        {
            if (File.Exists(ruta))
            {
                File.Delete(ruta);
            }

            printDocument.DocumentName = "Presupuesto " + quote.Id;
            printDocument.PrinterSettings.PrintToFile = true;
            printDocument.PrinterSettings.PrintFileName = ruta;

            printDocument.PrintController = new StandardPrintController();

            printDocument.Print();

            int intentos = 0;
            while (!archivoListo(ruta) && intentos < 20)
            {
                Thread.Sleep(250);
                intentos++;
            }
        }

        private bool archivoListo(string ruta)
        {
            return File.Exists(ruta) && new FileInfo(ruta).Length > 0;
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush negro = Brushes.Black;
            Pen linea = Pens.Gray;

            float izquierda = e.MarginBounds.Left;
            float derecha = e.MarginBounds.Right;
            float y = e.MarginBounds.Top;

            g.DrawString("Presupuesto N° " + quote.Id, fontTitulo, negro, izquierda, y);
            g.DrawString("Estado: " + quote.State, fontNegrita, negro, derecha, y + 8, alDerecha);
            y = y + 40;
            g.DrawString("Emitido el " + DateTime.Now.ToString("dd/MM/yyyy"), fontTexto, negro, izquierda, y);
            y = y + 28;
            g.DrawLine(linea, izquierda, y, derecha, y);
            y = y + 15;

            g.DrawString("Evento", fontSeccion, negro, izquierda, y);
            y = y + 25;
            g.DrawString("Nombre: " + quote.EventItemName, fontTexto, negro, izquierda, y);
            y = y + 20;
            g.DrawString("Cliente: " + quote.EventClientName, fontTexto, negro, izquierda, y);
            y = y + 20;
            g.DrawString("Fecha y hora: " + quote.EventDate.ToString("dd/MM/yyyy HH:mm"), fontTexto, negro, izquierda, y);
            y = y + 20;
            g.DrawString("Invitados: " + quote.EventGuestAdults + " adultos / " + quote.EventGuestChilds + " niños", fontTexto, negro, izquierda, y);
            y = y + 20;
            g.DrawString("Duracion: " + quote.EventDuration + " horas", fontTexto, negro, izquierda, y);
            y = y + 35;

            g.DrawString("Ubicacion", fontSeccion, negro, izquierda, y);
            y = y + 25;
            g.DrawString(quote.UbicationName + ": " + quote.UbicationPrice.ToString("C") + " por hora x " + quote.EventDuration + " horas",
                fontTexto, negro, izquierda, y);
            g.DrawString(quote.TotalUbication.ToString("C"), fontTexto, negro, derecha, y, alDerecha);
            y = y + 35;

            g.DrawString("Catering", fontSeccion, negro, izquierda, y);
            y = y + 25;

            if (quote.MenusList.Count == 0)
            {
                g.DrawString("Sin catering", fontTexto, negro, izquierda, y);
                y = y + 20;
            }
            else
            {
                g.DrawString("Menu", fontNegrita, negro, izquierda, y);
                g.DrawString("Etiqueta", fontNegrita, negro, izquierda + 140, y);
                g.DrawString("Adultos", fontNegrita, negro, izquierda + 290, y, alDerecha);
                g.DrawString("Niños", fontNegrita, negro, izquierda + 340, y, alDerecha);
                g.DrawString("P. adulto", fontNegrita, negro, izquierda + 430, y, alDerecha);
                g.DrawString("P. niño", fontNegrita, negro, izquierda + 515, y, alDerecha);
                g.DrawString("Subtotal", fontNegrita, negro, derecha, y, alDerecha);
                y = y + 20;
                g.DrawLine(linea, izquierda, y, derecha, y);
                y = y + 5;

                foreach (DetailMenuDto lineaMenu in quote.MenusList)
                {
                    g.DrawString(lineaMenu.MenuDescription, fontTexto, negro, new RectangleF(izquierda, y, 135, 20), cortar);
                    g.DrawString(lineaMenu.TagDescription, fontTexto, negro, new RectangleF(izquierda + 140, y, 100, 20), cortar);
                    g.DrawString(lineaMenu.AdultQuantity.ToString(), fontTexto, negro, izquierda + 290, y, alDerecha);
                    g.DrawString(lineaMenu.ChildQuantity.ToString(), fontTexto, negro, izquierda + 340, y, alDerecha);
                    g.DrawString(lineaMenu.UnitPriceAdult.ToString("C"), fontTexto, negro, izquierda + 430, y, alDerecha);
                    g.DrawString(lineaMenu.UnitPriceChild.ToString("C"), fontTexto, negro, izquierda + 515, y, alDerecha);
                    g.DrawString(lineaMenu.Subtotal.ToString("C"), fontTexto, negro, derecha, y, alDerecha);
                    y = y + 20;
                }
            }
            y = y + 15;

            g.DrawString("Servicios", fontSeccion, negro, izquierda, y);
            y = y + 25;

            if (quote.OptionItemsList.Count == 0)
            {
                g.DrawString("Sin servicios", fontTexto, negro, izquierda, y);
                y = y + 20;
            }
            else
            {
                foreach (DetailOptionItemDto servicio in quote.OptionItemsList)
                {
                    g.DrawString(servicio.OptionItemName, fontTexto, negro, izquierda, y);
                    g.DrawString(servicio.UnitPrice.ToString("C"), fontTexto, negro, derecha, y, alDerecha);
                    y = y + 20;
                }
            }
            y = y + 20;

            g.DrawLine(linea, izquierda, y, derecha, y);
            y = y + 10;
            g.DrawString("Ubicacion: " + quote.TotalUbication.ToString("C"), fontTexto, negro, derecha, y, alDerecha);
            y = y + 20;
            g.DrawString("Catering: " + quote.TotalMenus.ToString("C"), fontTexto, negro, derecha, y, alDerecha);
            y = y + 20;
            g.DrawString("Servicios: " + quote.TotalOptionItems.ToString("C"), fontTexto, negro, derecha, y, alDerecha);
            y = y + 28;
            g.DrawString("TOTAL: " + quote.Total.ToString("C"), fontTotal, negro, derecha, y, alDerecha);

            e.HasMorePages = false;
        }
    }
}
