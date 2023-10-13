using SQLiteDatabaseApp.DataBase.Manager;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;


namespace SQLiteDatabaseApp.main
{
    internal static class MainStart
    {
        [STAThread]
        private static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DatabaseManager.GetInstance("ModesAndSteps.db");
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();

            Application.Run(authorizationWindow);
        }
    }
}
