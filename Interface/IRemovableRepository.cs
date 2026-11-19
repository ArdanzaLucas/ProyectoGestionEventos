namespace ProyectoPresupuestoEvento.Interface
{
    public interface IRemovableRepository<T> : IRepository<T> where T : class
    {
        void RemoveById(int id);
    }
}
