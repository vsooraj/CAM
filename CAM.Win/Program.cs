using CAM.Data.Repository;
using System;
using System.Windows.Forms;

namespace CAM.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var dBLogRepository = new DBLogRepository();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmSoftwares(dBLogRepository));
        }
    }
}
