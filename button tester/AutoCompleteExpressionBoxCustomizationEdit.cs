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
    public partial class AutoCompleteExpressionBoxCustomizationEdit : Form
    {
        public class PayloadType
        {
            public KeyValuePair<int, string>? KVP { get; set; }
        }

        public PayloadType Payload = new PayloadType();

        public AutoCompleteExpressionBoxCustomizationEdit()
        {
            InitializeComponent();
        }

        private void AutoCompleteExpressionBoxCustomizationEdit_Load(object sender, EventArgs e)
        {
            if (Payload.KVP != null)
            {
                cmbID.SelectedItem = "D" + Payload.KVP.Value.Key;
                txtName.Text = Payload.KVP.Value.Value;
            }
            else
            {
                cmbID.SelectedIndex = 0;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                Payload.KVP = new KeyValuePair<int, string>(
                    int.Parse(cmbID.Text.Substring(1)),
                    txtName.Text);

                DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("Cannot enter an empty name.", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
