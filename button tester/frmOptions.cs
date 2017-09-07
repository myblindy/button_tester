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

            chkReverseDirection.Checked = settings.Payload.ReverseDirection;

            txtCounterChangeCap.Text = (settings.Payload.LastCounterChangeMovementCap / 1000.0).ToString();

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
            cmbOutputTickChannel.SelectedIndex = settings.Payload.ClockOutputChannel ?? 0;

            chkTestPilotPin.Checked = settings.Payload.TestPilotLightPin.HasValue;
            cmbTestPilotPin.SelectedIndex = settings.Payload.TestPilotLightPin??0;

            chkWaitBetweenAnalogChanges.Checked = settings.Payload.WaitBeforeAnalogChanges.HasValue;
            txtWaitBetweenAnalogChanges.Text = ((settings.Payload.WaitBeforeAnalogChanges ?? 0) / 1000.0f).ToString();

            foreach (var kvp in settings.Payload.Links)
                lstLinks.Items.Add("D" + (kvp.Key + 1) + " -> " + "D" + (kvp.Value + 1));

            if (settings.Payload.Hysteresis.ContainsKey(Settings.PayloadClass.HysteresisKind.Humidity))
            {
                chkHumidity.Checked = true;
                txtHumidityFrom.Text = settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Humidity].From.ToString();
                txtHumidityTo.Text = settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Humidity].To.ToString();
                txtHumidityPin.Text = (settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Humidity].PinID).ToString();
            }

            if (settings.Payload.Hysteresis.ContainsKey(Settings.PayloadClass.HysteresisKind.Temperature))
            {
                chkTemp.Checked = true;
                txtTempFrom.Text = settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Temperature].From.ToString();
                txtTempTo.Text = settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Temperature].To.ToString();
                txtTempPin.Text = (settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Temperature].PinID).ToString();
            }

            if (settings.Payload.HysteresisAI.ContainsKey(1))
            {
                chkAI1.Checked = true;
                txtAI1From.Text = settings.Payload.HysteresisAI[1].From.ToString();
                txtAI1To.Text = settings.Payload.HysteresisAI[1].To.ToString();
                txtAI1Pin.Text = (settings.Payload.HysteresisAI[1].PinID).ToString();
            }
            if (settings.Payload.HysteresisAI.ContainsKey(2))
            {
                chkAI2.Checked = true;
                txtAI2From.Text = settings.Payload.HysteresisAI[2].From.ToString();
                txtAI2To.Text = settings.Payload.HysteresisAI[2].To.ToString();
                txtAI2Pin.Text = (settings.Payload.HysteresisAI[2].PinID).ToString();
            }
            if (settings.Payload.HysteresisAI.ContainsKey(3))
            {
                chkAI3.Checked = true;
                txtAI3From.Text = settings.Payload.HysteresisAI[3].From.ToString();
                txtAI3To.Text = settings.Payload.HysteresisAI[3].To.ToString();
                txtAI3Pin.Text = (settings.Payload.HysteresisAI[3].PinID).ToString();
            }
            if (settings.Payload.HysteresisAI.ContainsKey(4))
            {
                chkAI4.Checked = true;
                txtAI4From.Text = settings.Payload.HysteresisAI[4].From.ToString();
                txtAI4To.Text = settings.Payload.HysteresisAI[4].To.ToString();
                txtAI4Pin.Text = (settings.Payload.HysteresisAI[4].PinID).ToString();
            }

            chkDriveMotor.Checked = settings.Payload.DriveMotor;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                int linesStart = int.Parse(txtLinesStart.Text), linesEnd = int.Parse(txtLinesEnd.Text);
                double offlineStart = double.Parse(txtOfflineStart.Text), offlineEnd = double.Parse(txtOfflineEnd.Text);
                double offlineStart2 = double.Parse(txtOfflineStart2.Text), offlineEnd2 = double.Parse(txtOfflineEnd2.Text);
                int poff = int.Parse(txtPowerOffPin.Text);
                double
                    zerol = double.Parse(txtZeroToleranceLow.Text),
                    zeroh = double.Parse(txtZeroToleranceHigh.Text);
                double
                    h_from = chkHumidity.Checked ? double.Parse(txtHumidityFrom.Text) : 0,
                    h_to = chkHumidity.Checked ? double.Parse(txtHumidityTo.Text) : 0,
                    t_from = chkTemp.Checked ? double.Parse(txtTempFrom.Text) : 0,
                    t_to = chkTemp.Checked ? double.Parse(txtTempTo.Text) : 0;
                int h_pin = chkHumidity.Checked ? int.Parse(txtHumidityPin.Text) : 0,
                    t_pin = chkTemp.Checked ? int.Parse(txtTempPin.Text) : 0;
                double
                    ai1_from = chkAI1.Checked ? double.Parse(txtAI1From.Text) : 0,
                    ai2_from = chkAI2.Checked ? double.Parse(txtAI2From.Text) : 0,
                    ai3_from = chkAI3.Checked ? double.Parse(txtAI3From.Text) : 0,
                    ai4_from = chkAI4.Checked ? double.Parse(txtAI4From.Text) : 0,
                    ai1_to = chkAI1.Checked ? double.Parse(txtAI1To.Text) : 0,
                    ai2_to = chkAI2.Checked ? double.Parse(txtAI2To.Text) : 0,
                    ai3_to = chkAI3.Checked ? double.Parse(txtAI3To.Text) : 0,
                    ai4_to = chkAI4.Checked ? double.Parse(txtAI4To.Text) : 0;
                int ai1_pin = chkAI1.Checked ? int.Parse(txtAI1Pin.Text) : 0,
                    ai2_pin = chkAI2.Checked ? int.Parse(txtAI2Pin.Text) : 0,
                    ai3_pin = chkAI3.Checked ? int.Parse(txtAI3Pin.Text) : 0,
                    ai4_pin = chkAI4.Checked ? int.Parse(txtAI4Pin.Text) : 0;
                double countercap = double.Parse(txtCounterChangeCap.Text);

                if (linesEnd < linesStart || offlineEnd < offlineStart || offlineEnd2 < offlineStart2
                    || !LJ.ValidPin(poff) || (chkHumidity.Checked && !LJ.ValidPinAny(h_pin))
                    || (chkTemp.Checked && !LJ.ValidPinAny(t_pin)))
                    throw new Exception();

                settings.Payload.OfflineRange = new Pair<int, int>((int)(offlineStart * 1000.0), (int)(offlineEnd * 1000.0));
                settings.Payload.OfflineLineProcRange = new Pair<int, int>(linesStart, linesEnd);
                settings.Payload.OfflineRange2 = new Pair<int, int>((int)(offlineStart2 * 1000.0), (int)(offlineEnd2 * 1000.0));
                settings.Payload.PowerOffPin = poff;
                settings.Payload.ZeroToleranceLow = zerol;
                settings.Payload.ZeroToleranceHigh = zeroh;
                settings.Payload.ReverseDirection = chkReverseDirection.Checked;

                settings.Payload.LastCounterChangeMovementCap = countercap * 1000.0;

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
                settings.Payload.TestPilotLightPin = chkTestPilotPin.Checked ?
                    (int?)int.Parse((cmbTestPilotPin.SelectedItem as string).Substring(1)) - 1 : null;
                settings.Payload.WaitBeforeAnalogChanges = chkWaitBetweenAnalogChanges.Checked ?
                    (int?)((int)(double.Parse(txtWaitBetweenAnalogChanges.Text) * 1000.0f)) : null;

                settings.Payload.Links = new SerializableDictionary<int, int>();
                foreach (string s in lstLinks.Items)
                {
                    var vals = s.Split(new string[] { " -> " }, StringSplitOptions.None);
                    settings.Payload.Links.Add(int.Parse(vals[0].Substring(1)) - 1,
                        int.Parse(vals[1].Substring(1)) - 1);
                }

                settings.Payload.Hysteresis = new SerializableDictionary<Settings.PayloadClass.HysteresisKind, Settings.PayloadClass.HysteresisPayload>();
                if (chkTemp.Checked)
                    settings.Payload.Hysteresis.Add(Settings.PayloadClass.HysteresisKind.Temperature,
                        new Settings.PayloadClass.HysteresisPayload()
                        {
                            From = t_from,
                            To = t_to,
                            PinID = t_pin
                        });
                if (chkHumidity.Checked)
                    settings.Payload.Hysteresis.Add(Settings.PayloadClass.HysteresisKind.Humidity,
                        new Settings.PayloadClass.HysteresisPayload()
                        {
                            From = h_from,
                            To = h_to,
                            PinID = h_pin
                        });
                settings.Payload.HysteresisAI = new SerializableDictionary<int, Settings.PayloadClass.HysteresisPayload>();
                if (chkAI1.Checked)
                    settings.Payload.HysteresisAI.Add(1, new Settings.PayloadClass.HysteresisPayload()
                    {
                        From = ai1_from,
                        To = ai1_to,
                        PinID = ai1_pin
                    });
                if (chkAI2.Checked)
                    settings.Payload.HysteresisAI.Add(2, new Settings.PayloadClass.HysteresisPayload()
                    {
                        From = ai2_from,
                        To = ai2_to,
                        PinID = ai2_pin
                    });
                if (chkAI3.Checked)
                    settings.Payload.HysteresisAI.Add(3, new Settings.PayloadClass.HysteresisPayload()
                    {
                        From = ai3_from,
                        To = ai3_to,
                        PinID = ai3_pin
                    });
                if (chkAI4.Checked)
                    settings.Payload.HysteresisAI.Add(4, new Settings.PayloadClass.HysteresisPayload()
                    {
                        From = ai4_from,
                        To = ai4_to,
                        PinID = ai4_pin
                    });

                settings.Payload.DriveMotor = chkDriveMotor.Checked;

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
            if (priority != null && new frmEditPriority(settings, priority).ShowDialog() == DialogResult.OK)
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

        private void btnMoveUpTestSet_Click(object sender, EventArgs e)
        {

        }

        private void btnMoveDownTestSet_Click(object sender, EventArgs e)
        {

        }

        private void btnMoveUpPriority_Click(object sender, EventArgs e)
        {

        }

        private void btnMoveDownPriority_Click(object sender, EventArgs e)
        {

        }

        private void btnAddLink_Click(object sender, EventArgs e)
        {
            var edit = new frmEditLink(settings);
            if (edit.ShowDialog() == DialogResult.OK)
            {
                int? From = edit.From, To = edit.To;
                lstLinks.Items.Add("D" + (From.Value + 1) + " -> D" + (To.Value + 1));
            }
        }

        private void btnEditLink_Click(object sender, EventArgs e)
        {
            try
            {
                var edit = new frmEditLink(settings);
                var vals = (lstLinks.SelectedItem as string).Split(new string[] { " -> " }, StringSplitOptions.None);
                edit.From = int.Parse(vals[0].Substring(1)) - 1;
                edit.To = int.Parse(vals[1].Substring(1)) - 1;
                if (edit.ShowDialog() == DialogResult.OK)
                {
                    int? From = edit.From, To = edit.To;
                    lstLinks.Items[lstLinks.SelectedIndex] = "D" + (From.Value + 1) + " -> D" + (To.Value + 1);
                }
            }
            catch
            {
            }
        }

        private void btnRemoveLink_Click(object sender, EventArgs e)
        {
            try
            {
                lstLinks.Items.RemoveAt(lstLinks.SelectedIndex);
            }
            catch
            {
            }
        }

        private void chkHumidity_CheckedChanged(object sender, EventArgs e)
        {
            txtHumidityFrom.Enabled = txtHumidityPin.Enabled = txtHumidityTo.Enabled = chkHumidity.Checked;
        }

        private void chkTemp_CheckedChanged(object sender, EventArgs e)
        {
            txtTempFrom.Enabled = txtTempTo.Enabled = txtTempPin.Enabled = chkTemp.Checked;
        }

        private void chkAI1_CheckedChanged(object sender, EventArgs e)
        {
            txtAI1From.Enabled = txtAI1Pin.Enabled = txtAI1To.Enabled = chkAI1.Checked;
        }

        private void chkAI2_CheckedChanged(object sender, EventArgs e)
        {
            txtAI2From.Enabled = txtAI2Pin.Enabled = txtAI2To.Enabled = chkAI2.Checked;
        }

        private void chkAI3_CheckedChanged(object sender, EventArgs e)
        {
            txtAI3From.Enabled = txtAI3Pin.Enabled = txtAI3To.Enabled = chkAI3.Checked;
        }

        private void chkAI4_CheckedChanged(object sender, EventArgs e)
        {
            txtAI4From.Enabled = txtAI4Pin.Enabled = txtAI4To.Enabled = chkAI4.Checked;
        }

        private void chkTestPilotPin_CheckedChanged(object sender, EventArgs e)
        {
            cmbTestPilotPin.Enabled = chkTestPilotPin.Checked;
        }
    }
}
