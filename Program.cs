namespace ProyectoPresupuestoEvento
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Mock.MockData.load();

            Application.Run(new FormMain());
        }
    }
}