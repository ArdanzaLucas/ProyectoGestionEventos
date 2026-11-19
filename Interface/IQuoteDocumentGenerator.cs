using ProyectoPresupuestoEvento.Model;

namespace ProyectoPresupuestoEvento.Interface
{
    public interface IQuoteDocumentGenerator
    {
        void Generate(Quote quote, string path);
    }
}
