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

        public QuoteController()
        {

        }

        public void addQuote(QuoteDto dto)
        {
            QuoteService service = new QuoteService();
            service.addQuote(dto);
        }

        public List<QuoteDto> getQuotes()
        {
            QuoteService service = new QuoteService();
            return service.getQuotes();
        }

        public List<QuoteDto> getQuotesByEventItem(int eventItemId)
        {
            QuoteService service = new QuoteService();
            return service.getQuotesByEventItem(eventItemId);
        }

        public QuoteDto getQuoteById(int id)
        {
            QuoteService service = new QuoteService();
            return service.getQuoteById(id);
        }

        public void updateQuote(int id, QuoteDto dto)
        {
            QuoteService service = new QuoteService();
            service.updateQuote(id, dto);
        }

        public void removeQuote(int id)
        {
            QuoteService service = new QuoteService();
            service.removeQuote(id);
        }

        public void acceptQuote(int id)
        {
            QuoteService service = new QuoteService();
            service.acceptQuote(id);
        }

        public void cancelQuote(int id)
        {
            QuoteService service = new QuoteService();
            service.cancelQuote(id);
        }

        public void cloneQuote(int id)
        {
            QuoteService service = new QuoteService();
            service.cloneQuote(id);
        }

        public QuoteDto calculatePreview(QuoteDto dto)
        {
            QuoteService service = new QuoteService();
            return service.calculatePreview(dto);
        }


    }
}
