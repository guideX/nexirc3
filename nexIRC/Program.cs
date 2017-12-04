using System;
using System.Windows.Forms;
using nexIRC.Business.Controllers;
namespace nexIRC {
    /// <summary>
    /// Program
    /// </summary>
    static class Program {
        /// <summary>
        /// Main
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var programController = new ProgramBusiness();
            Application.Run(programController.MainWindow);
        }
    }
}