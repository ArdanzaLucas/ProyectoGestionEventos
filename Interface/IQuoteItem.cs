namespace ProyectoPresupuestoEvento.Interface
{
    public interface IQuoteItem
    {
        string Description { get; }

        decimal Subtotal { get; }
    }
}
