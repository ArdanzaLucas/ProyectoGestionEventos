namespace ProyectoPresupuestoEvento.Interface
{
    public interface IRepository<T> where T : class
    {
        void AddToRepository(T obj);

        List<T> GetAll();

        T GetById(int id);

        void Update(int id, T obj);
    }
}
