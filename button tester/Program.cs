using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace button_tester
{
    static class Program
    {
        [DllImport("winmm.dll", EntryPoint = "timeBeginPeriod")]
        static extern uint MM_BeginPeriod(uint uMilliseconds);

        [DllImport("winmm.dll", EntryPoint = "timeEndPeriod")]
        static extern uint MM_EndPeriod(uint uMilliseconds);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] parameters)
        {
            try
            {
                MM_BeginPeriod(1);

                Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture =
                    CultureInfo.DefaultThreadCurrentCulture = CultureInfo.DefaultThreadCurrentUICulture =
                    CultureInfo.InvariantCulture;


                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain(parameters.Any() ? parameters[0] : null));
            }
            finally
            {
                MM_EndPeriod(1);
            }
        }
    }
}
