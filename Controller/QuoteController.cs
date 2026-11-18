using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void addQuote(QuoteDto dto)
        {
            service.addQuote(dto);
        }

        public List<QuoteDto> getQuotes()
        {
            return service.getQuotes();
        }

        public List<QuoteDto> getQuotesByEventItem(int eventItemId)
        {
            return service.getQuotesByEventItem(eventItemId);
        }

        public QuoteDto getQuoteById(int id)
        {
            return service.getQuoteById(id);
        }

        public void updateQuote(int id, QuoteDto dto)
        {
            service.updateQuote(id, dto);
        }

        public void removeQuote(int id)
        {
            service.removeQuote(id);
        }

        public void acceptQuote(int id)
        {
            service.acceptQuote(id);
        }

        public void cancelQuote(int id)
        {
            service.cancelQuote(id);
        }

        public void cloneQuote(int id)
        {
            service.cloneQuote(id);
        }

        public QuoteDto calculatePreview(QuoteDto dto)
        {
            return service.calculatePreview(dto);
        }
    }
}
