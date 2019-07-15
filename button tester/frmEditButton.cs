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
    public partial class frmEditButton : Form
    {
        public class ButtonTypeContainerClass
        {
            public Settings.PayloadClass.ButtonType buttontype;
        }

        public ButtonTypeContainerClass ButtonInfoContainer = new ButtonTypeContainerClass();

        public frmEditButton()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void frmEditButton_Load(object sender, EventArgs e)
        {
            if (ButtonInfoContainer.buttontype != null)
            {
                // edit
                txtButtonName.Text = ButtonInfoContainer.buttontype.Name;
                txtPinID.Text = ButtonInfoContainer.buttontype.PinID.ToString();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (int.TryParse(txtPinID.Text, out var pid) && pid > 0)
            {
                if (txtButtonName.Text.Length > 0)
                {
                    ButtonInfoContainer.buttontype = new Settings.PayloadClass.ButtonType();
                    ButtonInfoContainer.buttontype.Name = txtButtonName.Text;
                    ButtonInfoContainer.buttontype.PinID = pid;

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                    MessageBox.Show("Give the button a name", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
            }
            else
                MessageBox.Show("Wrong pin ID, expecting an integer greater than 0", "Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
