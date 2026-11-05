using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Model;
using ProyectoPresupuestoEvento.Interface;

namespace ProyectoPresupuestoEvento.Repository
{
    public class QuoteRepository : Irepository<Quote>
    {

        private List<Quote> quotes;
        private static QuoteRepository instance;
        private int idCounter = 0;

        private QuoteRepository()
        {
            quotes = new List<Quote>();
        }


        public static QuoteRepository getInstance()
        {
            if (instance == null)
            {
                instance = new QuoteRepository();
            }
            return instance;
        }

        public void addToRepository(Quote quote)
        {
            idCounter++;
            quote.Id = idCounter;
            quotes.Add(quote);
        }

        public List<Quote> getAll()
        {
            return quotes;
        }

        public Quote getById(int id)
        {
            foreach (Quote quote in quotes)
            {
                if (quote.Id == id)
                {
                    return quote;
                }
            }
            return null;
        }

        public void update(int id, Quote quote)
        {
            Quote existente = getById(id);
            if (existente == null)
            {
                return;
            }
            existente.EventName = quote.EventName;
            existente.EventClientName = quote.EventClientName;
            existente.EventDate = quote.EventDate;
            existente.EventGuestAdults = quote.EventGuestAdults;
            existente.EventGuestChilds = quote.EventGuestChilds;
            existente.EventDuration = quote.EventDuration;
            existente.Ubication = quote.Ubication;
            existente.UbicationName = quote.UbicationName;
            existente.UbicationPrice = quote.UbicationPrice;
            existente.MenusList = quote.MenusList;
            existente.OptionItemList = quote.OptionItemList;
            existente.TotalUbication = quote.TotalUbication;
            existente.TotalMenus = quote.TotalMenus;
            existente.TotalOptionItems = quote.TotalOptionItems;
            existente.Total = quote.Total;
        }

        public void removeById(int id)
        {
            Quote quoteToRemove = getById(id);
            if (quoteToRemove == null)
            {
                return;
            }
            quotes.Remove(quoteToRemove);

        }

    }
}
