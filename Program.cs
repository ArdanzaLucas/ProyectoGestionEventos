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
            Common.ErrorLog.Write(e.Exception);
            View.MessageHelper.ShowError("ocurrio un error inesperado. El detalle se guardo en " + Common.ErrorLog.FilePath);
        }
    }
}