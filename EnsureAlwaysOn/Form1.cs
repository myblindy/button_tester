using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnsureAlwaysOn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tmrChecker_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!Process.GetProcessesByName("button tester").Any())
                {
                    var key = Registry.CurrentUser.CreateSubKey(@"Software\SS\Button Tester");
                    var lastopen = key.GetValue("Last Open") as string;

                    if (!string.IsNullOrWhiteSpace(lastopen))
                    {
                        var lastlog = key.GetValue("Last Log") as string;
                        if (!string.IsNullOrWhiteSpace(lastlog))
                            File.AppendAllText(lastlog, "RESTART,Restarted at " + DateTime.Now);

                        Process.Start("button tester.exe", "\"" + lastopen + "\"");
                    }
                }
            }
            catch
            {
            }

        }
    }
}
