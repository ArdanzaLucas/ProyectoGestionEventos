using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPresupuestoEvento.Model
{
    public class Quote
    {
        private int _id;
        private int _eventItemId;
        private Ubication _ubication;
        private decimal _ubicationPrice;
        private List<DetailMenu> _menusList;
        private List<DetailOptionItem> _optionItemList;
        private EstadoPresupuesto _state;
        private decimal _totalUbication;
        private decimal _totalMenus;
        private decimal _totalOptionItems;
        private decimal _total;


        //constructor

        // todo presupuesto nuevo nace Pendiente y copia el precio actual de la ubicacion
        public Quote(int eventItemId, Ubication ubication, List<DetailMenu> menusList, List<DetailOptionItem> optionItemList)
        {
            EventItemId = eventItemId;
            Ubication = ubication;
            UbicationPrice = ubication.Price;
            MenusList = menusList;
            OptionItemList = optionItemList;
            State = EstadoPresupuesto.Pendiente;
        }


        //propiedades

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        // id del evento al que pertenece el presupuesto
        public int EventItemId
        {
            get { return _eventItemId; }
            set { _eventItemId = value; }
        }

        public Ubication Ubication
        {
            get { return _ubication; }
            set { _ubication = value; }
        }

        // precio por hora copiado de la ubicacion
        public decimal UbicationPrice
        {
            get { return _ubicationPrice; }
            set { _ubicationPrice = value; }
        }

        public List<DetailMenu> MenusList
        {
            get { return _menusList; }
            set { _menusList = value; }
        }

        public List<DetailOptionItem> OptionItemList
        {
            get { return _optionItemList; }
            set { _optionItemList = value; }
        }

        public EstadoPresupuesto State
        {
            get { return _state; }
            set { _state = value; }
        }

        public decimal TotalUbication
        {
            get { return _totalUbication; }
            set { _totalUbication = value; }
        }

        public decimal TotalMenus
        {
            get { return _totalMenus; }
            set { _totalMenus = value; }
        }

        public decimal TotalOptionItems
        {
            get { return _totalOptionItems; }
            set { _totalOptionItems = value; }
        }

        public decimal Total
        {
            get { return _total; }
            set { _total = value; }
        }


        //metodos

        // calcula los totales con los precios copiados y la duracion del evento.
        // si el presupuesto ya esta Aceptado o Cancelado, no cambia nada (queda congelado).
        public void calculateTotals(int duration)
        {
            if (_state != EstadoPresupuesto.Pendiente)
            {
                return;
            }

            _totalUbication = _ubicationPrice * duration;

            _totalMenus = 0;
            foreach (DetailMenu detailMenu in _menusList)
            {
                _totalMenus = _totalMenus + detailMenu.calculateSubtotal();
            }

            _totalOptionItems = 0;
            foreach (DetailOptionItem detailOptionItem in _optionItemList)
            {
                _totalOptionItems = _totalOptionItems + detailOptionItem.UnitPrice;
            }

            _total = _totalUbication + _totalMenus + _totalOptionItems;
        }

        // vuelve a copiar los precios actuales de la ubicacion, los menus y los servicios
        public void refreshPrices()
        {
            _ubicationPrice = _ubication.Price;

            foreach (DetailMenu detailMenu in _menusList)
            {
                detailMenu.refreshPrices();
            }

            foreach (DetailOptionItem detailOptionItem in _optionItemList)
            {
                detailOptionItem.refreshPrice();
            }
        }


        public void accept()
        {
            if (_state != EstadoPresupuesto.Pendiente)
            {
                throw new InvalidOperationException("solo se puede aceptar un presupuesto pendiente");
            }
            _state = EstadoPresupuesto.Aceptado;
        }

        public void cancel()
        {
            if (_state != EstadoPresupuesto.Pendiente)
            {
                throw new InvalidOperationException("solo se puede cancelar un presupuesto pendiente");
            }
            _state = EstadoPresupuesto.Cancelado;
        }

        // solo un presupuesto Pendiente se puede editar
        public bool isEditable()
        {
            return _state == EstadoPresupuesto.Pendiente;
        }

        // crea un presupuesto nuevo, Pendiente, con lo mismo pero con los precios actuales
        public Quote clone()
        {
            List<DetailMenu> menus = new List<DetailMenu>();
            foreach (DetailMenu detailMenu in _menusList)
            {
                DetailMenu copia = new DetailMenu(detailMenu.Menu, detailMenu.TagDescription,
                    detailMenu.AdultQuantity, detailMenu.ChildQuantity);
                menus.Add(copia);
            }

            List<DetailOptionItem> optionItems = new List<DetailOptionItem>();
            foreach (DetailOptionItem detailOptionItem in _optionItemList)
            {
                DetailOptionItem copia = new DetailOptionItem(detailOptionItem.OptionItem);
                optionItems.Add(copia);
            }

            Quote nuevo = new Quote(_eventItemId, _ubication, menus, optionItems);
            return nuevo;
        }


    }
}
