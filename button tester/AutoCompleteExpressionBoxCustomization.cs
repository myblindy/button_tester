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
    public partial class AutoCompleteExpressionBoxCustomization : Form
    {
        private Settings settings;

        public AutoCompleteExpressionBoxCustomization(Settings settings)
        {
            this.settings = settings;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private KeyValuePair<int, string> GetKVP(string s)
        {
            int middle = s.IndexOf(" = ");
            string key = s.Substring(0, middle), val = s.Substring(middle + 3);

            return new KeyValuePair<int, string>(
                int.Parse(key.Substring(1)),
                val);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            settings.Payload.DigitalNameOverrides = new SerializableDictionary<int,string>();

            foreach (string s in lstButtons.Items)
            {
                var kvp = GetKVP(s);
                settings.Payload.DigitalNameOverrides.Add(kvp.Key, kvp.Value);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void AutoCompleteExpressionBoxCustomization_Load(object sender, EventArgs e)
        {
            foreach (var redefined in settings.Payload.DigitalNameOverrides)
                lstButtons.Items.Add("D" + redefined.Key + " = " + redefined.Value);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            var frm = new AutoCompleteExpressionBoxCustomizationEdit();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string key = "D" + frm.Payload.KVP.Value.Key;

                if (lstButtons.Items.Cast<string>().Any(
                    w => string.Compare(w, 0, key + " ", 0, key.Length + 1) == 0))
                {
                    MessageBox.Show("Duplicate entry detected, dropping the new one.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    lstButtons.Items.Add(key + " = " +
                        frm.Payload.KVP.Value.Value);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstButtons.SelectedIndex < 0)
                return;

            var frm = new AutoCompleteExpressionBoxCustomizationEdit();
            frm.Payload.KVP = GetKVP(lstButtons.SelectedItem as string);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string key = "D" + frm.Payload.KVP.Value.Key;

                if (lstButtons.Items.Cast<string>().Any(
                    w => string.Compare(w, 0, key + " ", 0, key.Length + 1) == 0))
                {
                    MessageBox.Show("Duplicate entry detected, dropping the new one.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    lstButtons.Items[lstButtons.SelectedIndex] =
                        key + " = " + frm.Payload.KVP.Value.Value;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstButtons.SelectedIndex >= 0 &&
                MessageBox.Show("Are you sure you want to delete the selected line?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lstButtons.Items.RemoveAt(lstButtons.SelectedIndex);
            }
        }
    }
}
