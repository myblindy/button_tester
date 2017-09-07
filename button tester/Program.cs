using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace button_tester
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] parameters)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain(parameters.Any() ? parameters[0] : null));
        }
    }
}
