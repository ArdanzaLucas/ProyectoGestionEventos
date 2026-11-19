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

            try
            {
                Repository.SqliteDatabase.GetInstance();
#if DEBUG
                Mock.MockData.Load();
#endif
            }
            catch (Exception ex)
            {
                Common.ErrorLog.Write(ex);
                View.MessageHelper.ShowError("no se pudo abrir la base de datos en " + Common.AppFolders.Data
                    + ". Revise que la carpeta tenga permiso de escritura.");
                return;
            }

            Application.Run(new FormMain());
        }

        private static void ShowUnexpectedError(object sender, ThreadExceptionEventArgs e)
        {
            Common.ErrorLog.Write(e.Exception);
            View.MessageHelper.ShowError("ocurrio un error inesperado. El detalle se guardo en " + Common.ErrorLog.FilePath);
        }
    }
}