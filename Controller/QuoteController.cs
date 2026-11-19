using ProyectoPresupuestoEvento.Dto;
using ProyectoPresupuestoEvento.Service;


namespace ProyectoPresupuestoEvento.Controller
{
    public class QuoteController
    {
        private QuoteService service;

        public QuoteController()
        {
            service = new QuoteService();
        }

        public void AddQuote(QuoteDto dto)
        {
            service.AddQuote(dto);
        }

        public List<QuoteDto> GetQuotes()
        {
            return service.GetQuotes();
        }

        public List<QuoteDto> GetQuotesByEventItem(int eventItemId)
        {
            return service.GetQuotesByEventItem(eventItemId);
        }

        public QuoteDto GetQuoteById(int id)
        {
            return service.GetQuoteById(id);
        }

        public void UpdateQuote(int id, QuoteDto dto)
        {
            service.UpdateQuote(id, dto);
        }

        public void RemoveQuote(int id)
        {
            service.RemoveQuote(id);
        }

        public void AcceptQuote(int id)
        {
            service.AcceptQuote(id);
        }

        public void CancelQuote(int id)
        {
            service.CancelQuote(id);
        }

        public void CloneQuote(int id)
        {
            service.CloneQuote(id);
        }

        public QuoteDto CalculatePreview(QuoteDto dto)
        {
            return service.CalculatePreview(dto);
        }

        public void ExportPdf(int id, string path)
        {
            service.ExportPdf(id, path);
        }
    }
}
