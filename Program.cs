namespace ProyectoPresupuestoEvento
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += mostrarErrorInesperado;

            Repository.SqliteDatabase.getInstance();
#if DEBUG
            Mock.MockData.load();
#endif

            Application.Run(new FormMain());
        }

        private static void mostrarErrorInesperado(object sender, ThreadExceptionEventArgs e)
        {
            View.MessageHelper.showError("ocurrio un error inesperado: " + e.Exception.Message);
        }
    }
}