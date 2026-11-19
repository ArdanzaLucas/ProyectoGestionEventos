namespace ProyectoPresupuestoEvento
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += ShowUnexpectedError;

            Repository.SqliteDatabase.GetInstance();
#if DEBUG
            Mock.MockData.Load();
#endif

            Application.Run(new FormMain());
        }

        private static void ShowUnexpectedError(object sender, ThreadExceptionEventArgs e)
        {
            View.MessageHelper.ShowError("ocurrio un error inesperado: " + e.Exception.Message);
        }
    }
}