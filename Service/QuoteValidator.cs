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
        public void ValidateQuote(Quote quote, Quote original)
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
                bool hasTheTag = false;
                foreach (MenuTag tag in detailMenu.Menu.TagList)
                {
                    if (tag.Description == detailMenu.TagDescription)
                    {
                        hasTheTag = true;
                    }
                }
                if (!hasTheTag)
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
            List<string> inactiveNames = GetInactiveItems(quote);
            foreach (string name in inactiveNames)
            {
                if (original == null || !GetInactiveItems(original).Contains(name))
                {
                    throw new BusinessRuleException("no se puede usar " + name + " porque esta dado de baja");
                }
            }
        }

        public void ValidateEventNotPast(DateTime eventDate, string action)
        {
            if (eventDate.Date < DateTime.Today)
            {
                throw new BusinessRuleException("no se puede " + action + " un presupuesto de un evento que ya paso");
            }
        }

        // compara las copias del presupuesto con el evento actual
        public void ValidateEventNotChanged(Quote quote)
        {
            EventItem eventItem = eventItemRepository.GetById(quote.EventItemId);

            bool unchanged = quote.EventName == eventItem.Name
                && quote.EventClientName == eventItem.ClientName
                && quote.EventDate.ToString("yyyy-MM-dd HH:mm") == eventItem.Date.ToString("yyyy-MM-dd HH:mm")
                && quote.EventGuestAdults == eventItem.GuestAdults
                && quote.EventGuestChildren == eventItem.GuestChildren
                && quote.EventDuration == eventItem.Duration;

            if (!unchanged)
            {
                throw new BusinessRuleException("los datos del evento cambiaron: edite y guarde el presupuesto antes de aceptarlo");
            }
        }

        // un evento puede tener un solo presupuesto aceptado
        public void ValidateNoOtherAccepted(Quote quote)
        {
            foreach (Quote other in quoteRepository.GetAll())
            {
                if (other.Id != quote.Id && other.EventItemId == quote.EventItemId && other.State == QuoteState.Accepted)
                {
                    throw new BusinessRuleException("el evento ya tiene un presupuesto aceptado");
                }
            }
        }

        // busca otro aceptado en el mismo salon con un horario que se pise
        public void ValidateLocationFree(Quote quote)
        {
            foreach (Quote other in quoteRepository.GetAll())
            {
                if (other.Id != quote.Id && other.State == QuoteState.Accepted && other.Location.Id == quote.Location.Id && quote.OverlapsWith(other))
                {
                    throw new BusinessRuleException("la ubicacion ya esta ocupada en ese horario por el evento " + other.EventName);
                }
            }
        }

        // no se puede clonar si usa algo dado de baja
        public void ValidateCanClone(Quote original)
        {
            List<string> inactiveNames = GetInactiveItems(original);
            if (inactiveNames.Count > 0)
            {
                throw new BusinessRuleException("no se puede clonar: usa elementos dados de baja ("
                    + string.Join(", ", inactiveNames) + ")");
            }
        }

        // nombres de la ubicacion, los menus y los servicios dados de baja que usa el presupuesto
        private List<string> GetInactiveItems(Quote quote)
        {
            List<string> names = new List<string>();

            if (!quote.Location.IsActive)
            {
                names.Add(quote.Location.Name);
            }

            foreach (DetailMenu detailMenu in quote.MenusList)
            {
                if (!detailMenu.Menu.IsActive && !names.Contains(detailMenu.Menu.Description))
                {
                    names.Add(detailMenu.Menu.Description);
                }
            }

            foreach (DetailOptionItem detailOptionItem in quote.OptionItemList)
            {
                if (!detailOptionItem.OptionItem.IsActive)
                {
                    names.Add(detailOptionItem.OptionItem.Name);
                }
            }

            return names;
        }
    }
}
