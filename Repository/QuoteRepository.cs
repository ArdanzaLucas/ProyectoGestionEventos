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

        // copia todo menos el id y el evento, que no cambian
        public void update(int id, Quote quote)
        {
            Quote existente = getById(id);
            if (existente == null)
            {
                return;
            }
            existente.Ubication = quote.Ubication;
            existente.UbicationPrice = quote.UbicationPrice;
            existente.MenusList = quote.MenusList;
            existente.OptionItemList = quote.OptionItemList;
            existente.State = quote.State;
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
