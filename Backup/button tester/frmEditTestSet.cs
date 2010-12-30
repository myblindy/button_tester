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
    public partial class frmEditTestSet : Form
    {
        private Settings settings;
        private Settings.PayloadClass.TestSet testset;

        public frmEditTestSet(Settings settings, Settings.PayloadClass.TestSet testset)
        {
            this.settings = settings;
            this.testset = testset;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!txtCondition.ValidateExpression())
            {
                MessageBox.Show("Invalid condition", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                testset.Condition = new TestExpression(txtCondition.Text);
                testset.Delay = (int)(double.Parse(txtDelay.Text) * 1000.0f);
                testset.Result = (Settings.PayloadClass.TestSet.ResultType)Enum.Parse(
                    typeof(Settings.PayloadClass.TestSet.ResultType),
                    (string)cmbResult.SelectedItem);
            }
            catch
            {
                MessageBox.Show("Invalid data entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void frmEditTestSet_Load(object sender, EventArgs e)
        {
            txtCondition.Settings = settings;
            txtCondition.Text = testset.Condition.Expression;

            foreach (var s in Enum.GetNames(typeof(Settings.PayloadClass.TestSet.ResultType)))
                cmbResult.Items.Add(s);
            cmbResult.SelectedItem = testset.Result.ToString();

            txtDelay.Text = (testset.Delay / 1000.0f).ToString();
        }
    }
}
