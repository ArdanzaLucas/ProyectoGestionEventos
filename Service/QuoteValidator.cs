using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPresupuestoEvento.Model;
using ProyectoPresupuestoEvento.Interface;
using ProyectoPresupuestoEvento.Common;

namespace ProyectoPresupuestoEvento.Service
{
    // reglas de los presupuestos que necesitan mirar varios objetos o la base; las usa QuoteService
    internal class QuoteValidator
    {
        private IRepository<Quote> quoteRepository;
        private IRepository<EventItem> eventItemRepository;

        public QuoteValidator(IRepository<Quote> quoteRepository, IRepository<EventItem> eventItemRepository)
        {
            this.quoteRepository = quoteRepository;
            this.eventItemRepository = eventItemRepository;
        }

        // reglas de las lineas: platos, variantes repetidas, etiquetas del menu, servicios repetidos y elementos de baja
        public void validateQuote(Quote quote, Quote original)
        {
            foreach (DetailMenu detailMenu in quote.MenusList)
            {
                if (detailMenu.AdultQuantity + detailMenu.ChildQuantity == 0)
                {
                    throw new BusinessRuleException("cada linea de catering tiene que tener al menos un plato");
                }
            }

            for (int i = 0; i < quote.MenusList.Count; i++)
            {
                for (int j = i + 1; j < quote.MenusList.Count; j++)
                {
                    DetailMenu a = quote.MenusList[i];
                    DetailMenu b = quote.MenusList[j];
                    if (a.Menu.Id == b.Menu.Id && a.TagDescription == b.TagDescription)
                    {
                        throw new BusinessRuleException("la variante " + a.Menu.Description + " " + a.TagDescription + " esta repetida");
                    }
                }
            }

            foreach (DetailMenu detailMenu in quote.MenusList)
            {
                bool tieneLaEtiqueta = false;
                foreach (MenuTag tag in detailMenu.Menu.TagList)
                {
                    if (tag.Description == detailMenu.TagDescription)
                    {
                        tieneLaEtiqueta = true;
                    }
                }
                if (!tieneLaEtiqueta)
                {
                    throw new BusinessRuleException("el menu " + detailMenu.Menu.Description + " no tiene la etiqueta " + detailMenu.TagDescription);
                }
            }

            for (int i = 0; i < quote.OptionItemList.Count; i++)
            {
                for (int j = i + 1; j < quote.OptionItemList.Count; j++)
                {
                    if (quote.OptionItemList[i].OptionItem.Id == quote.OptionItemList[j].OptionItem.Id)
                    {
                        throw new BusinessRuleException("el servicio " + quote.OptionItemList[i].OptionItem.Name + " esta repetido");
                    }
                }
            }

            // al editar se pueden conservar los elementos de baja que ya tenia el original
            List<string> inactivos = getInactiveItems(quote);
            foreach (string nombre in inactivos)
            {
                if (original == null || !getInactiveItems(original).Contains(nombre))
                {
                    throw new BusinessRuleException("no se puede usar " + nombre + " porque esta dado de baja");
                }
            }
        }

        public void validateEventNotPast(DateTime eventDate, string accion)
        {
            if (eventDate.Date < DateTime.Today)
            {
                throw new BusinessRuleException("no se puede " + accion + " un presupuesto de un evento que ya paso");
            }
        }

        // compara las copias del presupuesto con el evento actual
        public void validateEventNotChanged(Quote quote)
        {
            EventItem eventItem = eventItemRepository.getById(quote.EventItemId);

            bool igual = quote.EventName == eventItem.Name
                && quote.EventClientName == eventItem.ClientName
                && quote.EventDate.ToString("yyyy-MM-dd HH:mm") == eventItem.Date.ToString("yyyy-MM-dd HH:mm")
                && quote.EventGuestAdults == eventItem.GuestAdults
                && quote.EventGuestChilds == eventItem.GuestChilds
                && quote.EventDuration == eventItem.Duration;

            if (!igual)
            {
                throw new BusinessRuleException("los datos del evento cambiaron: edite y guarde el presupuesto antes de aceptarlo");
            }
        }

        // un evento puede tener un solo presupuesto aceptado
        public void validateNoOtherAccepted(Quote quote)
        {
            foreach (Quote otro in quoteRepository.getAll())
            {
                if (otro.Id != quote.Id && otro.EventItemId == quote.EventItemId && otro.State == EstadoPresupuesto.Aceptado)
                {
                    throw new BusinessRuleException("el evento ya tiene un presupuesto aceptado");
                }
            }
        }

        // busca otro aceptado en el mismo salon con un horario que se pise
        public void validateUbicationFree(Quote quote)
        {
            foreach (Quote otro in quoteRepository.getAll())
            {
                if (otro.Id != quote.Id && otro.State == EstadoPresupuesto.Aceptado && otro.Ubication.Id == quote.Ubication.Id && quote.overlapsWith(otro))
                {
                    throw new BusinessRuleException("la ubicacion ya esta ocupada en ese horario por el evento " + otro.EventName);
                }
            }
        }

        // no se puede clonar si usa algo dado de baja
        public void validateCanClone(Quote original)
        {
            List<string> inactivos = getInactiveItems(original);
            if (inactivos.Count > 0)
            {
                throw new BusinessRuleException("no se puede clonar: usa elementos dados de baja ("
                    + string.Join(", ", inactivos) + ")");
            }
        }

        // nombres de la ubicacion, los menus y los servicios dados de baja que usa el presupuesto
        private List<string> getInactiveItems(Quote quote)
        {
            List<string> nombres = new List<string>();

            if (!quote.Ubication.IsActive)
            {
                nombres.Add(quote.Ubication.Name);
            }

            foreach (DetailMenu detailMenu in quote.MenusList)
            {
                if (!detailMenu.Menu.IsActive && !nombres.Contains(detailMenu.Menu.Description))
                {
                    nombres.Add(detailMenu.Menu.Description);
                }
            }

            foreach (DetailOptionItem detailOptionItem in quote.OptionItemList)
            {
                if (!detailOptionItem.OptionItem.IsActive)
                {
                    nombres.Add(detailOptionItem.OptionItem.Name);
                }
            }

            return nombres;
        }
    }
}
