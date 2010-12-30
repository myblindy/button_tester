using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace button_tester
{
    public partial class frmEditLink : Form
    {
        public int? From=null, To=null;
        private int? OrigFrom;
        private Settings settings;

        public frmEditLink(Settings settings)
        {
            InitializeComponent();
            this.settings = settings;
            OrigFrom = From;
        }

        private void frmEditLink_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 16; ++i)
            {
                cmbFrom.Items.Add("D" + i);
                cmbTo.Items.Add("D" + i);
            }

            cmbFrom.SelectedIndex = From ?? 0;
            cmbTo.SelectedIndex = To ?? 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cmbFrom.SelectedIndex == cmbTo.SelectedIndex)
            {
                MessageBox.Show("You cannot link a button to itself.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            From = cmbFrom.SelectedIndex;
            To = cmbTo.SelectedIndex;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
