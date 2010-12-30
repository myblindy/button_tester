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
    public partial class frmOptions : Form
    {
        private Settings settings;

        public frmOptions(Settings settings)
        {
            this.settings = settings;
            InitializeComponent();
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            txtCycleCondition.Settings = settings;

            txtLinesEnd.Text = settings.Payload.OfflineLineProcRange.Second.ToString();
            txtLinesStart.Text = settings.Payload.OfflineLineProcRange.First.ToString();
            txtOfflineEnd.Text = (settings.Payload.OfflineRange.Second / 1000.0).ToString();
            txtOfflineStart.Text = (settings.Payload.OfflineRange.First / 1000.0).ToString();
            txtOfflineEnd2.Text = (settings.Payload.OfflineRange2.Second / 1000.0).ToString();
            txtOfflineStart2.Text = (settings.Payload.OfflineRange2.First / 1000.0).ToString();
            txtZeroToleranceLow.Text = settings.Payload.ZeroToleranceLow.ToString();
            txtZeroToleranceHigh.Text = settings.Payload.ZeroToleranceHigh.ToString();

            txtPowerOffPin.Text = settings.Payload.PowerOffPin.ToString();

            foreach (var pr in settings.Payload.Priorities)
                lstPriorities.Items.Add(pr);

            foreach (var ts in settings.Payload.TestSets)
                lstTestSets.Items.Add(ts);

            chkStopOnErrors.Checked = settings.Payload.StopOnErrors;

            chkUseCycles.Checked = settings.Payload.UseCycles;
            txtCycleCondition.Text = settings.Payload.CycleCondition.Expression;
            chkStopAtCycles.Checked = settings.Payload.StopAtCycles.HasValue;
            txtStopAtCycles.Text = (settings.Payload.StopAtCycles ?? 100).ToString();
            chkOutputTick.Checked = settings.Payload.ClockOutputChannel.HasValue;
            //cmbOutputTickChannel.SelectedIndex = 0;
            cmbOutputTickChannel.SelectedIndex = settings.Payload.ClockOutputChannel ?? 0;

            chkWaitBetweenAnalogChanges.Checked = settings.Payload.WaitBeforeAnalogChanges.HasValue;
            txtWaitBetweenAnalogChanges.Text = ((settings.Payload.WaitBeforeAnalogChanges ?? 0)/1000.0f).ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                int linesStart = int.Parse(txtLinesStart.Text), linesEnd = int.Parse(txtLinesEnd.Text);
                double offlineStart = double.Parse(txtOfflineStart.Text), offlineEnd = double.Parse(txtOfflineEnd.Text);
                double offlineStart2 = double.Parse(txtOfflineStart2.Text), offlineEnd2 = double.Parse(txtOfflineEnd2.Text);
                int poff = int.Parse(txtPowerOffPin.Text);
                double zerol = double.Parse(txtZeroToleranceLow.Text),
                    zeroh=double.Parse(txtZeroToleranceHigh.Text);

                if (linesEnd < linesStart || offlineEnd < offlineStart || offlineEnd2 < offlineStart2
                    || !Util.ValidPin(poff))
                    throw new Exception();

                settings.Payload.OfflineRange = new Pair<int, int>((int)(offlineStart * 1000.0), (int)(offlineEnd * 1000.0));
                settings.Payload.OfflineLineProcRange = new Pair<int, int>(linesStart, linesEnd);
                settings.Payload.OfflineRange2 = new Pair<int, int>((int)(offlineStart2 * 1000.0), (int)(offlineEnd2 * 1000.0));
                settings.Payload.PowerOffPin = poff;
                settings.Payload.ZeroToleranceLow = zerol;
                settings.Payload.ZeroToleranceHigh = zeroh;

                settings.Payload.Priorities = new List<Settings.PayloadClass.Priority>(
                    lstPriorities.Items.Cast<Settings.PayloadClass.Priority>());
                settings.Payload.TestSets = new List<Settings.PayloadClass.TestSet>(
                    lstTestSets.Items.Cast<Settings.PayloadClass.TestSet>());

                settings.Payload.StopOnErrors = chkStopOnErrors.Checked;

                if (chkUseCycles.Checked && !TestExpression.Validate(txtCycleCondition.Text, settings))
                    throw new Exception();

                settings.Payload.UseCycles = chkUseCycles.Checked;
                settings.Payload.CycleCondition = new TestExpression(txtCycleCondition.Text);
                settings.Payload.StopAtCycles = chkStopAtCycles.Checked ?
                    (int?)int.Parse(txtStopAtCycles.Text) : null;
                settings.Payload.ClockOutputChannel = chkOutputTick.Checked ?
                    (int?)int.Parse((cmbOutputTickChannel.SelectedItem as string).Substring(1)) - 1 : null;
                settings.Payload.WaitBeforeAnalogChanges = chkWaitBetweenAnalogChanges.Checked ?
                    (int?)((int)(double.Parse(txtWaitBetweenAnalogChanges.Text)*1000.0f)) : null;

                DialogResult = DialogResult.OK;
                Close();
            }
            catch
            {
                MessageBox.Show("Invalid input. Please check that the ranges are actual numbers " +
                    "and that the starts are happening before the ends.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAddNewCondition_Click(object sender, EventArgs e)
        {
            Settings.PayloadClass.Priority priority = new Settings.PayloadClass.Priority();
            if (new frmEditPriority(settings, priority).ShowDialog() == DialogResult.OK)
            {
                lstPriorities.Items.Add(priority);
            }
        }

        private void btnEditCondition_Click(object sender, EventArgs e)
        {
            Settings.PayloadClass.Priority priority = (Settings.PayloadClass.Priority)lstPriorities.SelectedItem;
            if (priority!=null && new frmEditPriority(settings, priority).ShowDialog() == DialogResult.OK)
            {
                lstPriorities.Items[lstPriorities.SelectedIndex] = priority;
            }
        }

        private void btnRemoveCondition_Click(object sender, EventArgs e)
        {
            if (lstPriorities.SelectedIndex >= 0 &&
                MessageBox.Show("Are you sure you want to remove the selected priority?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                lstPriorities.Items.RemoveAt(lstPriorities.SelectedIndex);
        }

        private void btnAddNewTestSet_Click(object sender, EventArgs e)
        {
            Settings.PayloadClass.TestSet ts = new Settings.PayloadClass.TestSet();
            if (new frmEditTestSet(settings, ts).ShowDialog() == DialogResult.OK)
            {
                lstTestSets.Items.Add(ts);
            }
        }

        private void btnEditTestSet_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.PayloadClass.TestSet ts = (Settings.PayloadClass.TestSet)lstTestSets.SelectedItem;
                if (new frmEditTestSet(settings, ts).ShowDialog() == DialogResult.OK)
                    lstTestSets.Items[lstTestSets.SelectedIndex] = ts;
            }
            catch { }
        }

        private void btnRemoveTestSet_Click(object sender, EventArgs e)
        {
            if (lstTestSets.SelectedIndex >= 0 &&
                MessageBox.Show("Are you sure you want to remove the selected test set?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                lstTestSets.Items.RemoveAt(lstTestSets.SelectedIndex);
        }

        private void chkUseCycles_CheckedChanged(object sender, EventArgs e)
        {
            lblCondition.Enabled = txtCycleCondition.Enabled =
                chkStopAtCycles.Enabled = chkOutputTick.Enabled = chkUseCycles.Checked;
            txtStopAtCycles.Enabled = chkUseCycles.Checked ? chkStopAtCycles.Checked : false;
            cmbOutputTickChannel.Enabled = chkUseCycles.Checked ? chkOutputTick.Checked : false;
        }

        private void chkStopAtCycles_CheckedChanged(object sender, EventArgs e)
        {
            txtStopAtCycles.Enabled = chkStopAtCycles.Checked;
        }

        private void chkOutputTick_CheckedChanged(object sender, EventArgs e)
        {
            cmbOutputTickChannel.Enabled = chkOutputTick.Checked;
        }

        private void chkWaitBetweenAnalogChanges_CheckedChanged(object sender, EventArgs e)
        {
            txtWaitBetweenAnalogChanges.Enabled = chkWaitBetweenAnalogChanges.Checked;
        }
    }
}
