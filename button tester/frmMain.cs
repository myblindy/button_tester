using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using Microsoft.Win32;

namespace button_tester
{
    public partial class frmMain : Form
    {
        Settings settings = new Settings();

        public frmMain(string file)
        {
            InitializeComponent();

            LJ.Init();
            LJ.ResetOutputs();
            tmrUIUpdate_Tick(null, null);

            lblCnt.Text = "Cnt:" + Environment.NewLine + "--";
            lblErr.Text = "Err:" + Environment.NewLine + "0";

            if (!string.IsNullOrWhiteSpace(file))
            {
                OpenFile(file);

                var key = Registry.CurrentUser.CreateSubKey(@"Software\SS\Button Tester");
                var lastlog = key.GetValue("Last Log") as string;

                if (!string.IsNullOrWhiteSpace(lastlog))
                    Run(Convert.ToBoolean(key.GetValue("Random Run") as string), lastlog);
            }
            else
                mnuNewProject.PerformClick();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNewProject_Click(object sender, EventArgs e)
        {
            mnuNewProject.PerformClick();
        }

        private void mnuNewProject_Click(object sender, EventArgs e)
        {
            if (settings.Dirty)
                switch (MessageBox.Show("You have changed your project since the last save. " +
                    "Do you want to save your project first?", "Button Tester", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question))
                {
                    case DialogResult.Cancel:
                        return;
                    case DialogResult.Yes:
                        mnuSaveProject.PerformClick();
                        break;
                }

            settings.New();
            WriteLastOpenFile(null);

            lvMain.Items.Clear();

            UpdateTitle();
        }

        private void tlbSave_Click(object sender, EventArgs e)
        {
            mnuSaveProject.PerformClick();
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            if (settings.FileName == null)
                if (fdSave.ShowDialog() == DialogResult.OK)
                {
                    settings.FileName = fdSave.FileName;
                    WriteLastOpenFile(fdSave.FileName);
                }
                else
                    return;

            settings.Save();

            UpdateTitle();
        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            mnuOpenProject.PerformClick();
        }

        void OpenFile(string filename)
        {
            if (!settings.Load(filename))
                return;

            WriteLastOpenFile(filename);

            // update the list view
            lvMain.Items.Clear();
            int i = 0;

            foreach (var act in settings.Payload.Actions)
                lvMain.Items.Add(new ListViewItem(new string[]{
                        (++i).ToString(),
                        act.GetTypeName(),
                        act.GetDetails(),
                        ""
                    }));

            UpdateTitle();
        }

        private void mnuOpenProject_Click(object sender, EventArgs e)
        {
            if (settings.Dirty)
                switch (MessageBox.Show("You have changed your project since the last save. " +
                    "Do you want to save your project first?", "Button Tester", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question))
                {
                    case DialogResult.Cancel:
                        return;
                    case DialogResult.Yes:
                        mnuSaveProject.PerformClick();
                        break;
                }

            if (fdOpen.ShowDialog() == DialogResult.OK)
            {
                OpenFile(fdOpen.FileName);
            }
        }

        private void WriteLastOpenFile(string path)
        {
            var key = Registry.CurrentUser.CreateSubKey(@"Software\SS\Button Tester");
            key.SetValue("Last Open", path ?? "");
        }

        private void mnuSaveProjectAs_Click(object sender, EventArgs e)
        {
            if (fdSave.ShowDialog() == DialogResult.OK)
            {
                settings.FileName = fdSave.FileName;
                WriteLastOpenFile(fdSave.FileName);
                settings.Save();

                UpdateTitle();
            }
        }

        void SetDirty()
        {
            settings.Dirty = true;
            UpdateTitle();
        }

        void UpdateTitle()
        {
            string appname = Process.GetCurrentProcess().ProcessName;

            if (settings.FileName != null)
                Text = appname + " - " + Path.GetFileNameWithoutExtension(settings.FileName) + (settings.Dirty ? " *" : "");
            else
                Text = appname + " - Untitled" + (settings.Dirty ? " *" : "");
        }

        private void mnuAddNew_Click(object sender, EventArgs e)
        {
            var addnew = new frmEdit(settings);
            addnew.ActionContainer.action = null;

            if (addnew.ShowDialog() == DialogResult.OK)
            {
                // update the database
                settings.Payload.Actions.Add(addnew.ActionContainer.action);

                // update the listview
                lvMain.Items.Add(new ListViewItem(new string[]{
                    settings.Payload.Actions.Count.ToString(),
                    addnew.ActionContainer.action.GetTypeName(),
                    addnew.ActionContainer.action.GetDetails(),
                    ""
                }));

                lvMain.FocusedItem = lvMain.Items[lvMain.Items.Count - 1];

                // set the dirty flag
                SetDirty();
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Button Tester", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            if (mnuStop.Enabled)
            {
                mnuStop_Click(null, null);
                Thread.Sleep(500);
            }

            if (settings.Dirty)
            {
                switch (MessageBox.Show("You have changed your project since the last save. " +
                    "Do you want to save your project first?", "Button Tester", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        mnuSave_Click(null, null);
                        break;

                    case DialogResult.Cancel:
                        e.Cancel = true;
                        return;
                }
            }

            WriteLastOpenFile(null);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
        }

        private void mnuEditItem_Click(object sender, EventArgs e)
        {
            if (lvMain.SelectedItems.Count <= 0)
                return;

            var editform = new frmEdit(settings);
            editform.ActionContainer.action = settings.Payload.Actions[
                lvMain.SelectedIndices[0]];

            if (editform.ShowDialog() == DialogResult.OK)
            {
                settings.Payload.Actions[int.Parse(lvMain.SelectedItems[0].Text) - 1] =
                    editform.ActionContainer.action;

                SetDirty();
                lvMain.SelectedItems[0].SubItems[1].Text = editform.ActionContainer.action.GetTypeName();
                lvMain.SelectedItems[0].SubItems[2].Text = editform.ActionContainer.action.GetDetails();
            }
        }

        private void tsbAddNewItem_Click(object sender, EventArgs e)
        {
            mnuAddNewItem.PerformClick();
        }

        private void tsbEditItem_Click(object sender, EventArgs e)
        {
            mnuEditItem.PerformClick();
        }

        private void tmrUIUpdate_Tick(object sender, EventArgs e)
        {
            // can copy/cut/delete?
            bool enabled = lvMain.SelectedIndices.Count > 0;

            mnuCopy.Enabled = mnuCut.Enabled = mnuDelete.Enabled = tsbCopy.Enabled =
                tsbCut.Enabled = enabled;

            // can paste?
            enabled = Clipboard.ContainsData("btprj clipboard");

            mnuPaste.Enabled = tsbPaste.Enabled = enabled;
        }

        private void tsbCut_Click(object sender, EventArgs e)
        {
            mnuCut.PerformClick();
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            mnuCopy.PerformClick();
        }

        private void tsbPaste_Click(object sender, EventArgs e)
        {
            mnuPaste.PerformClick();
        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            mnuCopy.PerformClick();
            mnuDelete.PerformClick();
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            if (lvMain.SelectedIndices.Count <= 0)
                return;

            Settings.PayloadClass.Action action = settings.Payload.Actions[lvMain.SelectedIndices[0]];

            Clipboard.Clear();
            Clipboard.SetData("btprj clipboard", action);
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            if (lvMain.SelectedIndices.Count <= 0)
                return;

            SetDirty();

            settings.Payload.Actions.RemoveAt(lvMain.SelectedIndices[0]);
            lvMain.Items.RemoveAt(lvMain.SelectedIndices[0]);
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            if (!Clipboard.ContainsData("btprj clipboard"))
                return;

            Settings.PayloadClass.Action action = Clipboard.GetData("btprj clipboard")
                as Settings.PayloadClass.Action;

            if (action == null)
                return;

            SetDirty();

            settings.Payload.Actions.Add(action);
            lvMain.Items.Add(new ListViewItem(new string[]{
                settings.Payload.Actions.Count.ToString(),
                action.GetTypeName(),
                action.GetDetails(),
                ""
            }));
        }

        private void mnuMoveUp_Click(object sender, EventArgs e)
        {
            if (lvMain.SelectedIndices.Count <= 0 || lvMain.SelectedIndices[0] <= 0)
                return;

            SetDirty();

            int i = lvMain.SelectedIndices[0];

            Settings.PayloadClass.Action temp = settings.Payload.Actions[i - 1];
            settings.Payload.Actions[i - 1] = settings.Payload.Actions[i];
            settings.Payload.Actions[i] = temp;

            ListViewItem temp2 = lvMain.Items[i - 1];
            lvMain.Items[i - 1] = lvMain.Items[i].Clone() as ListViewItem;
            lvMain.Items[i] = temp2;

            // change the numbers
            lvMain.Items[i - 1].SubItems[0].Text = i.ToString();
            lvMain.Items[i].SubItems[0].Text = (i + 1).ToString();

            // select the new row
            lvMain.Items[i - 1].Selected = true;
        }

        private void mnuMoveDown_Click(object sender, EventArgs e)
        {
            if (lvMain.SelectedIndices.Count <= 0 ||
                lvMain.SelectedIndices[0] >= lvMain.Items.Count - 1)
                return;

            SetDirty();

            int i = lvMain.SelectedIndices[0];

            Settings.PayloadClass.Action temp = settings.Payload.Actions[i + 1];
            settings.Payload.Actions[i + 1] = settings.Payload.Actions[i];
            settings.Payload.Actions[i] = temp;

            ListViewItem temp2 = lvMain.Items[i + 1];
            lvMain.Items[i + 1] = lvMain.Items[i].Clone() as ListViewItem;
            lvMain.Items[i] = temp2;

            // change the numbers
            lvMain.Items[i + 1].SubItems[0].Text = (i + 2).ToString();
            lvMain.Items[i].SubItems[0].Text = (i + 1).ToString();

            // select the new row
            lvMain.Items[i + 1].Selected = true;
        }

        private void tsbMoveUp_Click(object sender, EventArgs e)
        {
            mnuMoveUp.PerformClick();
        }

        private void tsbMoveDown_Click(object sender, EventArgs e)
        {
            mnuMoveDown.PerformClick();
        }

        private void lvMain_DoubleClick(object sender, EventArgs e)
        {
            mnuEditItem.PerformClick();
        }

        private void tsbRun_Click(object sender, EventArgs e)
        {
            mnuRun.PerformClick();
        }

        private void tsbStop_Click(object sender, EventArgs e)
        {
            mnuStop.PerformClick();
        }

        private DateTime NextEvent;
        private bool RunRandom;
        private int LinesToBreak, PreBreakInterval;
        private bool BreakEnabled, InBreak;
        private Settings.PayloadClass.ButtonType[] CurrBTs = null;

        private bool StopLoggingThread;

        private void DisplayPriority(Settings.PayloadClass.Priority priority)
        {
            if (priority != null)
            {
                var ps = priority.PriorityOrder
                    .Where(w => w.Second == Settings.PayloadClass.Priority.PriorityState.Used)
                    .Select(w => settings.Payload.Buttons[w.First].Name + " (" + settings.Payload.Buttons[w.First].PinID + ")");
                Invoke((MethodInvoker)delegate
                {
                    lstPriorities.Items.Clear();
                    foreach (var s in ps)
                        lstPriorities.Items.Add(s);
                });
            }
            else
                Invoke((MethodInvoker)delegate
                {
                    lstPriorities.Items.Clear();
                    lstPriorities.Items.Add("(no priorities)");
                });
        }

        private string PrettyNumber(int n)
        {
            string o = "";

            while (n > 0)
            {
                if (n >= 1000)
                    o = " " + string.Format("{0:000}", n % 1000) + o;
                else
                    o = (n % 1000) + o;
                n /= 1000;
            }

            return o;
        }

        int[] StateSnapshot = null;
        double[] AStateSnapshot = null;

        private void Run(bool random, string logfilename)
        {
            if (lvMain.Items.Count <= 0)
                return;

            var key = Registry.CurrentUser.CreateSubKey(@"Software\SS\Button Tester");
            key.SetValue("Last Log", logfilename);
            key.SetValue("Random Run", random.ToString());

            RunRandom = random;

            // stop the ui updating
            tmrUIUpdate.Enabled = false;

            // disable everything
            foreach (var item in menustripMain.Items)
                ((ToolStripItem)item).Enabled = false;

            foreach (var item in toolstripMain.Items)
                ((ToolStripItem)item).Enabled = false;

            mnuRun.Enabled = mnuRunRandom.Enabled = false;

            // initial break stuff
            BreakEnabled =
                settings.Payload.OfflineLineProcRange.First != settings.Payload.OfflineLineProcRange.Second ||
                settings.Payload.OfflineLineProcRange.Second != 0;
            LinesToBreak = settings.Random.Next(settings.Payload.OfflineLineProcRange.First,
                settings.Payload.OfflineLineProcRange.Second) + 1;
            InBreak = false;

            InWaitForCondition = false;

            CurrBTs = null;

            // enable only the required stuff
            mnuSimulation.Enabled = mnuStop.Enabled = tsbStop.Enabled = true;

            // enable the loop timer
            settings.IP = 0;
            tmrLoop.Interval = 1;
            tmrLoop.Enabled = true;

            // enable the countdown timer
            NextEvent = DateTime.Now.AddSeconds(10);
            tmrCountdown.Enabled = true;

            // enable the logging timer
            lblDirection.Text = "0";
            StopLoggingThread = false;
            lblCnt.Text = "Cnt:" + Environment.NewLine + (settings.Payload.UseCycles ? "0" : "--");
            lblErr.Text = "Err:" + Environment.NewLine + "0";
            Thread thread = new Thread(() =>
                {
                    Thread.Sleep(500);

                    Settings.PayloadClass.Priority priority =
                        settings.Payload.Priorities.Count > 0 ? settings.Payload.Priorities[0] : null;
                    Settings.PayloadClass.TestSet expectedts = null;
                    DateTime expecteddate = DateTime.Now;
                    int cyclecounter = 0, errorcounter = 0;
                    bool lastcycletest = false;
                    DateTime lastcycletime = DateTime.Now;
                    int OldSign = 0;
                    DateTime lastsignchange = DateTime.Now.Subtract(TimeSpan.FromMilliseconds(
                        settings.Payload.WaitBeforeAnalogChanges ?? 0));
                    int[] InputState = null;
                    DateTime? shutdowncounterpintime = null;
                    int[] ResetPinPhases = new int[16];
                    int[] OldRealState = new int[16]; OldRealState[0] = -1;
                    int[] linkedpins = new int[16];  // linkedpin[i]=j means pin i is on because of j
                    for (int i = 0; i < 16; ++i) linkedpins[i] = -1;

                    // drive motor (di14 and di15 alternate (overlapping) -> drives either di6 or di7)
                    bool? LastD14 = null;
                    DateTime LastDriveMotorTick = DateTime.Now;

                    DateTime? firstloglinetime = null;

                    string OldCurrVal = null;

                    // last counter change
                    long lastcounter = -1;
                    DateTime lastcounterupdate = DateTime.Now;

                    float oldTemp = 0.0f, oldRH = 0.0f;
                    float[] oldAI = new float[8];
                    SetupInitialHysteresis(oldAI, ref oldTemp, ref oldRH, settings);

                    StringBuilder currvalsb = new StringBuilder();

                    // fill in the priority list box
                    DisplayPriority(priority);

                    // test pilot light on
                    if (settings.Payload.TestPilotLightPin.HasValue)
                        LJ.SetDigitalOutput(
                            settings.Payload.TestPilotLightPin.Value + 1,
                            true,
                            1);

                    while (!StopLoggingThread)
                    {
                        // TODO: AI0
                        float ai0 = LJ.ReadAnalogInput(0);
                        int sign = (ai0 < settings.Payload.ZeroToleranceLow) ? -1 :
                            ((ai0 > settings.Payload.ZeroToleranceHigh) ? 1 : 0);
                        sign *= settings.Payload.ReverseDirection ? -1 : 1;

                        // adjust the sign if we put a cap on movement
                        if (settings.Payload.LastCounterChangeMovementCap > 0)
                        {
                            long counter = LJ.ReadCounter(false);
                            if (counter != lastcounter || lastcounter == -1)
                            {
                                lastcounter = counter; lastcounterupdate = DateTime.Now;
                            }
                            else if ((DateTime.Now - lastcounterupdate).TotalMilliseconds > settings.Payload.LastCounterChangeMovementCap)
                                sign = 0;
                        }

                        string result;
                        bool pass = InputState == null;

                        // counter pin
                        if (shutdowncounterpintime.HasValue &&
                            DateTime.Now.CompareTo(shutdowncounterpintime.Value) > 0)
                        {
                            // set the output
                            LJ.SetDigitalOutput(
                                settings.Payload.ClockOutputChannel.Value + 1, true, 0);

                            shutdowncounterpintime = null;
                        }

                        // build the state table
                        if (sign != OldSign && (DateTime.Now - lastsignchange).TotalMilliseconds <
                            settings.Payload.WaitBeforeAnalogChanges)
                        {
                            sign = OldSign;
                            // TODO: AI0
                            ai0 = oldAI[0];
                        }
                        else
                        {
                            // TODO: AI0
                            oldAI[0] = ai0;
                            if (sign != OldSign)
                                lastsignchange = DateTime.Now;
                        }

                        if (sign == -1)
                            result = "v";
                        else if (sign == 1)
                            result = "^";
                        else
                            result = "0";

                        if (sign != OldSign)
                        {
                            lblDirection.BeginInvoke(new MethodInvoker(delegate
                            {
                                lblDirection.Text = result;
                            }));

                            pass = true;

                            OldSign = sign;
                        }

                        int[] State = new int[16];
                        int states = LJ.ReadDigital();
                        for (int i = 1; i <= 16; ++i)
                            State[i - 1] = (states & (1 << (i - 1))) > 0 ? 1 : 0;

                        if (InputState != null)
                            for (int i = 0; i < 16; ++i)
                                if (State[i] != InputState[i])
                                {
                                    pass = true;
                                    break;
                                }

                        // drive motor
                        if (settings.Payload.DriveMotor)
                        {
                            if (!LastD14.HasValue)
                            {
                                // init
                                LastD14 = State[14] != 0;
                                LastDriveMotorTick = DateTime.Now;
                            }
                            else if (LastD14 != (State[14] != 0))
                            {
                                // change
                                LastD14 = State[14] != 0;
                                LastDriveMotorTick = DateTime.Now;

                                // if on
                                if (State[14] != 0)
                                {
                                    // set the motors depending on direction (if the overlapping wave is on)
                                    LJ.SetDigitalOutput(7, true, State[15]);
                                    LJ.SetDigitalOutput(8, true, 1 - State[15]);
                                }
                            }
                            else if (LastDriveMotorTick != null && (DateTime.Now - LastDriveMotorTick).TotalSeconds > 1.5)
                            {
                                // no tick, stop the motors
                                LJ.SetDigitalOutput(7, true, 0);
                                LJ.SetDigitalOutput(8, true, 0);
                            }
                        }

                        // hysteresis logic (ignore ai0)
                        // also contains code to show the current values
                        currvalsb.Length = 0;
                        for (int i = 1; i < 8; ++i)
                        {
                            // TODO: AI0
                            if (settings.Payload.HysteresisAI.ContainsKey(i))
                            {
                                float ai = LJ.ReadAnalogInput(i);
                                currvalsb.AppendLine(string.Format("AI{0}: {1:0.00}v", i, ai));

                                if (settings.Payload.HysteresisAI[i].PinID > 0)
                                {
                                    if (oldAI[i] >= settings.Payload.HysteresisAI[i].From
                                        && ai <= settings.Payload.HysteresisAI[i].From)
                                    {
                                        if (State[settings.Payload.HysteresisAI[i].PinID - 1] == 0)
                                            LJ.SetDigitalOutput(settings.Payload.HysteresisAI[i].PinID, true, 1);
                                    }
                                    else if (oldAI[i] <= settings.Payload.HysteresisAI[i].To
                                        && ai >= settings.Payload.HysteresisAI[i].To)
                                    {
                                        if (State[settings.Payload.HysteresisAI[i].PinID - 1] != 0)
                                            LJ.SetDigitalOutput(settings.Payload.HysteresisAI[i].PinID, true, 0);
                                    }
                                }
                                oldAI[i] = ai;
                            }
                        }

                        if (settings.Payload.Hysteresis.ContainsKey(Settings.PayloadClass.HysteresisKind.Humidity) ||
                            settings.Payload.Hysteresis.ContainsKey(Settings.PayloadClass.HysteresisKind.Temperature))
                        {
                            float temp, rh;
                            LJ.ReadTemperatureHumidity(out temp, out rh);
                            currvalsb.AppendLine(string.Format("Temp: {0:0.0}C", temp));
                            currvalsb.AppendLine(string.Format("Humidity: {0:0.0}", rh));

                            if (settings.Payload.Hysteresis.ContainsKey(Settings.PayloadClass.HysteresisKind.Humidity) &&
                                settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Humidity].PinID > 0)
                            {
                                if (oldRH >= settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Humidity].From
                                    && rh <= settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Humidity].From)
                                {
                                    if (State[settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Humidity].PinID - 1] == 0)
                                    {
                                        LJ.SetDigitalOutput(settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Humidity].PinID,
                                            true, 1);
                                    }
                                }
                                else if (oldRH <= settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Humidity].To
                                    && rh >= settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Humidity].To)
                                {
                                    if (State[settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Humidity].PinID - 1] != 0)
                                    {
                                        LJ.SetDigitalOutput(settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Humidity].PinID, true, 0);
                                    }
                                }
                            }
                            if (settings.Payload.Hysteresis.ContainsKey(Settings.PayloadClass.HysteresisKind.Temperature) &&
                                settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Temperature].PinID > 0)
                            {
                                if (oldTemp >= settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Temperature].From
                                    && temp <= settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Temperature].From)
                                {
                                    if (State[settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Temperature].PinID - 1] == 0)
                                        LJ.SetDigitalOutput(settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Temperature].PinID,
                                            true, 1);
                                }
                                else if (oldTemp <= settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Temperature].To
                                    && temp >= settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Temperature].To)
                                {
                                    if (State[settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Temperature].PinID - 1] != 0)
                                        LJ.SetDigitalOutput(settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Temperature].PinID, true, 0);
                                }
                            }
                            oldRH = rh;
                            oldTemp = temp;
                        }

                        // flush the current display string
                        string cv = currvalsb.ToString();
                        if (cv != OldCurrVal)
                        {
                            OldCurrVal = cv;
                            Invoke(new MethodInvoker(delegate
                                {
                                    if (lblCurrentValues.Text != cv)
                                        lblCurrentValues.Text = cv;
                                }));
                        }

                        // linked pins
                        foreach (var lkvp in settings.Payload.Links)
                        {
                            if (State[lkvp.Key] != 0 && State[lkvp.Value] == 0)
                            {
                                State[lkvp.Value] = 1;
                                LJ.SetDigitalOutput(lkvp.Value + 1, true, 1);
                                linkedpins[lkvp.Value] = lkvp.Key;
                            }
                        }
                        // clearing linked pins
                        for (int i = 0; i < 16; ++i)
                            if (linkedpins[i] >= 0)
                            {
                                if (State[linkedpins[i]] == 0)
                                {
                                    // clearing it
                                    LJ.SetDigitalOutput(i + 1, true, 0);
                                    linkedpins[i] = -1;
                                }
                            }

                        // pins waiting for a reset
                        for (int i = 0; i < ResetPinPhases.Length; ++i)
                            if (State[i] == 0 && ResetPinPhases[i] == 1)
                                ResetPinPhases[i] = 0;

                        double[] astate = new double[] { ai0 };

                        // calculate any priority changes
                        if (priority != null && priority.ExitCondition.Evaluate(State, astate, settings))
                        {
                            IEnumerable<Settings.PayloadClass.Priority> ps;
                            if (priority.Condition.Evaluate(State, astate, settings))
                            {
                                int currentindex = -1;
                                for (int i = 0; i < settings.Payload.Priorities.Count; ++i)
                                    if (settings.Payload.Priorities[i] == priority)
                                        currentindex = i;

                                ps = settings.Payload.Priorities.Where(
                                    (w, i) => i < currentindex);
                            }
                            else
                                ps = settings.Payload.Priorities.Select(w => w);

                            foreach (var p in ps) //settings.Payload.Priorities)
                                if (priority != p && p.Condition.Evaluate(State, astate, settings))
                                {
                                    // first see what buttons have to be reset
                                    foreach (var po in priority.PriorityOrder)
                                        if (po.Second == Settings.PayloadClass.Priority.PriorityState.NotUsedAndReset &&
                                            State[po.First] == 1)
                                        {
                                            ResetPinPhases[po.First] = 1;
                                        }

                                    // now just change the priority set
                                    DisplayPriority(priority = p);
                                    break;
                                }
                        }

                        // now the real (priority-transformed) state
                        int[] RealState;
                        if (priority == null)
                            RealState = State;
                        else
                        {
                            RealState = new int[16];

                            foreach (var p in priority.PriorityOrder)
                                if (p.Second == Settings.PayloadClass.Priority.PriorityState.Used &&
                                    State[p.First] == 1 && ResetPinPhases[p.First] == 0)
                                {
                                    RealState[p.First] = 1;
                                    break;
                                }

                            Array.Copy(State, 8, RealState, 8, 8);

                            bool invoke = false;
                            for (int i = 0; i < 16; ++i)
                                if (RealState[i] != OldRealState[i])
                                {
                                    invoke = true;
                                    break;
                                }

                            // and display it!
                            if (invoke)
                            {
                                int[] tmprealstate = new int[16];
                                Array.Copy(RealState, tmprealstate, 16);
                                Invoke((MethodInvoker)delegate
                                {
                                    Debug.Print("inside the updater");

                                    foreach (ListViewItem item in lstPriorities.Items)
                                        if (item.BackColor == Color.Green)
                                        {
                                            item.BackColor = SystemColors.Window;
                                            item.ForeColor = SystemColors.ControlText;
                                        }

                                    for (int i = 0; i < 8; ++i)
                                    {
                                        string partial = null;
                                        foreach (var b in settings.Payload.Buttons)
                                            if (b.PinID == i + 1 && tmprealstate[i] == 1)
                                            {
                                                partial = b.Name + " ";
                                                break;
                                            }

                                        if (partial != null)
                                        {
                                            foreach (ListViewItem item in lstPriorities.Items)
                                                if (item.Text.StartsWith(partial))
                                                {
                                                    item.ForeColor = Color.White;
                                                    item.BackColor = Color.Green;
                                                }
                                        }
                                    }
                                });
                                Array.Copy(RealState, OldRealState, 16);
                            }

                        }

                        lock (ThreadSync)
                        {
                            StateSnapshot = RealState;
                            AStateSnapshot = astate;

                        }

                        // are we waiting on any test?
                        if (expectedts != null)
                        {
                            // are we too late?
                            if (DateTime.Now.CompareTo(expecteddate) == 1)
                            {
                                using (var s1 = File.Open(fdSaveLog.FileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                                using (var stream = new StreamWriter(s1))
                                    stream.WriteLine("ERROR,Condition failed,\"" +
                                        expectedts.Condition.Expression + ", took too long\"");

                                ++errorcounter;
                                Invoke((MethodInvoker)delegate
                                {
                                    lblErr.Text = "Err:" + Environment.NewLine + PrettyNumber(errorcounter);
                                });

                                if (settings.Payload.StopOnErrors)
                                {
                                    Invoke((MethodInvoker)delegate
                                    {
                                        mnuStop_Click(null, null);
                                        MessageBox.Show("Condition failed:\n" +
                                            expectedts.Condition.Expression + "\n\nTook too long.");
                                    });
                                    break;
                                }

                                // next cycle of errors.
                                expectedts = null;
                            }
                            else
                            {
                                // if not, is the result really happening?
                                //bool ok = false;
                                //switch (expectedts.Result)
                                //{
                                //    case Settings.PayloadClass.TestSet.ResultType.Down:
                                //        ok = sign == -1;
                                //        break;
                                //    case Settings.PayloadClass.TestSet.ResultType.StayStill:
                                //        ok = sign == 0;
                                //        break;
                                //    case Settings.PayloadClass.TestSet.ResultType.Up:
                                //        ok = sign == 1;
                                //        break;
                                //}

                                if (expectedts.Result.Evaluate(RealState, astate, settings))
                                {
                                    // all's fine!
                                    expectedts = null;
                                }
                            }
                        }
                        else
                        {
                            // if not, run all tests and see if we should wait on any
                            foreach (var ts in settings.Payload.TestSets)
                                if (ts.Condition.Evaluate(RealState, astate, settings))
                                {
                                    // found one!
                                    expectedts = ts;
                                    expecteddate = DateTime.Now.AddMilliseconds(ts.Delay);
                                    break;
                                }
                        }

                        // now calculate the cycles
                        if (settings.Payload.UseCycles)
                        {
                            if (settings.Payload.CycleCondition.Evaluate(State, astate, settings))
                            {
                                if (lastcycletest == false && (DateTime.Now - lastcycletime).TotalMilliseconds > 20)
                                {
                                    ++cyclecounter;
                                    if (settings.Payload.StopAtCycles.HasValue &&
                                        cyclecounter >= settings.Payload.StopAtCycles.Value)
                                    {

                                        Invoke((MethodInvoker)delegate
                                        {
                                            mnuStop_Click(null, null);
                                            MessageBox.Show(cyclecounter + " cycles reached.");
                                        });
                                        break;
                                    }
                                    Invoke((MethodInvoker)delegate
                                    {
                                        lblCnt.Text = "Cnt:" + Environment.NewLine + PrettyNumber(cyclecounter);
                                    });

                                    // output a pin
                                    if (settings.Payload.ClockOutputChannel.HasValue)
                                    {
                                        // set the output
                                        LJ.SetDigitalOutput(
                                            settings.Payload.ClockOutputChannel.Value + 1, true, 1);

                                        shutdowncounterpintime =
                                            DateTime.Now.AddMilliseconds(500);
                                    }

                                    lastcycletest = true;
                                    lastcycletime = DateTime.Now;
                                }
                            }
                            else
                                lastcycletest = false;
                        }

                        if (!pass)
                            continue;

                        InputState = State;

                        StringBuilder sb = new StringBuilder();

                        for (int i = 1; i <= 16; ++i)
                        {
                            sb.Append(InputState[i - 1] == 0 ? "" : "On");
                            sb.Append(",");
                        }

                        sb.Append(result);
                        sb.Append(",");
                        sb.Append(LJ.ReadCounter(true));
                        sb.Append(",");

                        sb.Append("\"");
                        sb.Append(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff"));
                        sb.Append("\"");
                        sb.Append(",");
                        var now = DateTime.Now;
                        if (!firstloglinetime.HasValue) firstloglinetime = now;
                        sb.Append((now - firstloglinetime.Value).TotalSeconds.ToString("R"));
                        sb.Append(",");
                        sb.Append(
                            settings.Payload.Hysteresis.ContainsKey(Settings.PayloadClass.HysteresisKind.Temperature)
                            ? oldTemp.ToString() : "0.0");
                        sb.Append(",");
                        sb.Append(
                            settings.Payload.Hysteresis.ContainsKey(Settings.PayloadClass.HysteresisKind.Humidity)
                            ? oldRH.ToString() : "0.0");
                        sb.Append(",");
                        sb.Append(
                            settings.Payload.HysteresisAI.ContainsKey(1)
                            ? oldAI[1].ToString() : "0.0");
                        sb.Append(",");
                        sb.Append(
                            settings.Payload.HysteresisAI.ContainsKey(2)
                            ? oldAI[2].ToString() : "0.0");
                        sb.Append(",");
                        sb.Append(
                            settings.Payload.HysteresisAI.ContainsKey(3)
                            ? oldAI[3].ToString() : "0.0");
                        sb.Append(",");
                        sb.Append(
                            settings.Payload.HysteresisAI.ContainsKey(4)
                            ? oldAI[4].ToString() : "0.0");

                        using (var s1 = File.Open(logfilename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                        using (var stream = new StreamWriter(s1))
                            stream.WriteLine(sb.ToString());
                    }

                    using (var s1 = File.Open(logfilename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                    using (var stream = new StreamWriter(s1))
                        stream.WriteLine("END,Thread terminated," +
                            DateTime.Now.ToString() + "," + cyclecounter + " cycles," +
                            errorcounter + " errors");

                    // test pilot light off
                    if (settings.Payload.TestPilotLightPin.HasValue)
                        LJ.SetDigitalOutput(
                            settings.Payload.TestPilotLightPin.Value + 1,
                            true,
                            0);
                });

            thread.Name = "Background worker thread";
            try
            {
                thread.Start();
            }
            catch
            {
            }
        }

        private void SetupInitialHysteresis(float[] oldAI, ref float oldTemp, ref float oldRH, Settings settings)
        {
            for (int i = 0; i < 8; ++i)
            {
                oldAI[i] = LJ.ReadAnalogInput(i);
                if (settings.Payload.HysteresisAI.ContainsKey(i))
                {
                    if (oldAI[i] < settings.Payload.HysteresisAI[i].From)
                        LJ.SetDigitalOutput(settings.Payload.HysteresisAI[i].PinID, true, 1);
                }
            }

            LJ.ReadTemperatureHumidity(out oldTemp, out oldRH);
            if (settings.Payload.Hysteresis.ContainsKey(Settings.PayloadClass.HysteresisKind.Humidity))
            {
                if (oldRH < settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Humidity].From)
                    LJ.SetDigitalOutput(settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Humidity].PinID,
                        true, 1);
            }
            if (settings.Payload.Hysteresis.ContainsKey(Settings.PayloadClass.HysteresisKind.Temperature))
            {
                if (oldTemp < settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Temperature].From)
                    LJ.SetDigitalOutput(settings.Payload.Hysteresis[Settings.PayloadClass.HysteresisKind.Temperature].PinID,
                        true, 1);
            }
        }

        private void mnuRun_Click(object sender, EventArgs e)
        {
            // get the log file name
            if (fdSaveLog.ShowDialog() != DialogResult.OK)
                return;

            Run(false, fdSaveLog.FileName);
        }

        private void mnuStop_Click(object sender, EventArgs e)
        {
            var key = Registry.CurrentUser.CreateSubKey(@"Software\SS\Button Tester");
            key.SetValue("Last Log", "");

            // stop the timers
            lblCountdown.Text = "";
            lblBreak.Text = "";
            lblCurrentValues.Text = "";
            lblBreak.ForeColor = Color.Green;
            lblCountdown.ForeColor = SystemColors.ControlText;
            StopLoggingThread = true;
            tmrCountdown.Enabled = false;
            tmrLoop.Enabled = false;
            ClearMarks();

            lstPriorities.Items.Clear();

            // enable everything
            foreach (var item in menustripMain.Items)
                ((ToolStripItem)item).Enabled = true;

            foreach (var item in toolstripMain.Items)
                ((ToolStripItem)item).Enabled = true;

            mnuRunRandom.Enabled = mnuRun.Enabled = true;

            // disable this button
            mnuStop.Enabled = tsbStop.Enabled = false;

            // enable the ui timer
            tmrUIUpdate_Tick(null, null);
            tmrUIUpdate.Enabled = true;

            // Thread.Sleep(1000);

            LJ.ResetOutputs();

            lblDirection.Text = "";
        }

        void ClearMarks(int except = -1)
        {
            var idx = 0;
            foreach (ListViewItem line in lvMain.Items)
                if (idx++ != except)
                {
                    if (line.SubItems[3].Text != "")
                        line.SubItems[3].Text = "";

                    if (line.BackColor != SystemColors.Window)
                        line.BackColor = SystemColors.Window;

                    if (line.ForeColor != SystemColors.ControlText)
                        line.ForeColor = SystemColors.ControlText;
                }
        }

        object ThreadSync = new object();
        bool InWaitForCondition = false;

        private void tmrLoop_Tick(object sender, EventArgs e)
        {
            // do the break logic
            if (InBreak)
            {
                // restore the stuff
                tmrLoop.Interval = PreBreakInterval;
                NextEvent = DateTime.Now.AddMilliseconds(PreBreakInterval);
                lblBreak.ForeColor = Color.Green;
                lblCountdown.ForeColor = SystemColors.ControlText;
                LinesToBreak = settings.Random.Next(settings.Payload.OfflineLineProcRange.First,
                    settings.Payload.OfflineLineProcRange.Second);
                InBreak = false;

                LJ.SetDigitalOutput(settings.Payload.PowerOffPin, true, 0);
                if (CurrBTs != null)
                    foreach (var bt in CurrBTs)
                    {
                        LJ.SetDigitalOutput(bt.PinID, true, 1);
                    }

                //if (--settings.IP < 0)
                //    settings.IP += settings.Payload.Actions.Count;

                return;
            }

            // reset the previous button
            if (CurrBTs != null)
            {
                foreach (var bt in CurrBTs)
                {
                    LJ.SetDigitalOutput(bt.PinID, true, 0);
                }
                CurrBTs = null;
            }

            // mark our current step
            ClearMarks(settings.IP);
            if (lvMain.Items[settings.IP].BackColor != Color.Green)
                lvMain.Items[settings.IP].BackColor = Color.Green;
            if (lvMain.Items[settings.IP].ForeColor != Color.White)
                lvMain.Items[settings.IP].ForeColor = Color.White;
            lvMain.EnsureVisible(settings.IP);

            // interpret our current step
            if (settings.Payload.Actions[settings.IP] is Settings.PayloadClass.ActionButtonPress)
            {
                var abp = (Settings.PayloadClass.ActionButtonPress)settings.Payload.Actions[settings.IP];

                // press the buttons
                if (abp.UseAll)
                    CurrBTs = abp.Buttons.ToArray();
                else
                    CurrBTs = new Settings.PayloadClass.ButtonType[] { abp.Buttons[settings.Random.Next(abp.Buttons.Count)] };

                foreach (var bt in CurrBTs)
                {
                    LJ.SetDigitalOutput(bt.PinID, true, 1);
                }

                // delay is in the interval
                tmrLoop.Interval = Math.Max(1, settings.Random.Next(
                    (int)(abp.PressedTime.First * 1000), (int)(abp.PressedTime.Second * 1000)));
                NextEvent = DateTime.Now.AddMilliseconds(tmrLoop.Interval);

                lvMain.Items[settings.IP].SubItems[3].Text = tmrLoop.Interval / 1000.0f + "s, " +
                    (abp.UseAll ? "All buttons" : CurrBTs[0].Name);
            }
            else if (settings.Payload.Actions[settings.IP] is Settings.PayloadClass.ActionDelay)
            {
                Settings.PayloadClass.ActionDelay delay = settings.Payload.Actions[settings.IP]
                    as Settings.PayloadClass.ActionDelay;

                // delay is in the interval
                tmrLoop.Interval = Math.Max(1, settings.Random.Next(
                    (int)(delay.Range.First * 1000), (int)(delay.Range.Second * 1000)));
                NextEvent = DateTime.Now.AddMilliseconds(tmrLoop.Interval);

                lvMain.Items[settings.IP].SubItems[3].Text = (tmrLoop.Interval / 1000.0f).ToString();
            }
            else if (settings.Payload.Actions[settings.IP] is Settings.PayloadClass.ActionEnd)
                mnuStop.PerformClick();
            else if (settings.Payload.Actions[settings.IP] is Settings.PayloadClass.ActionWaitForCondition)
            {
                tmrLoop.Interval = 15;
                NextEvent = DateTime.Now.AddMilliseconds(tmrLoop.Interval);

                int[] state = null;
                double[] astate = null;

                lock (ThreadSync)
                {
                    state = StateSnapshot;
                    astate = AStateSnapshot;
                }

                InWaitForCondition = state != null && astate != null
                    ? !((Settings.PayloadClass.ActionWaitForCondition)settings.Payload.Actions[settings.IP])
                        .Condition.Evaluate(state, astate, settings)
                    : true;
            }

            if (BreakEnabled && --LinesToBreak == 0)
            {
                PreBreakInterval = tmrLoop.Interval;
                tmrLoop.Interval = settings.Random.Next(0, 2) == 0 ?
                    settings.Random.Next(settings.Payload.OfflineRange.First,
                    settings.Payload.OfflineRange.Second) :
                    settings.Random.Next(settings.Payload.OfflineRange2.First,
                    settings.Payload.OfflineRange2.Second);
                NextEvent = DateTime.Now.AddMilliseconds(tmrLoop.Interval);
                lblBreak.ForeColor = lblCountdown.ForeColor = Color.Red;
                InBreak = true;

                if (CurrBTs != null)
                    foreach (var bt in CurrBTs)
                    {
                        LJ.SetDigitalOutput(bt.PinID, true, 0);
                    }

                LJ.SetDigitalOutput(settings.Payload.PowerOffPin, true, 1);
            }

            if (!InWaitForCondition)
                if (RunRandom)
                    settings.IP = settings.Random.Next(settings.Payload.Actions.Count);
                else
                {
                    ++settings.IP;
                    if (settings.IP >= settings.Payload.Actions.Count)
                        settings.IP = 0;
                }
        }

        private void tmrCountdown_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            if (InWaitForCondition)
                lblCountdown.Text = "Waiting";
            else if (now.CompareTo(NextEvent) >= 0)
                lblCountdown.Text = "00:00:00";
            else
            {
                double tms = (NextEvent - DateTime.Now).TotalMilliseconds;
                tms /= 1000;
                int s = (int)tms % 60;
                tms /= 60;
                int m = (int)tms % 60;
                tms /= 60;
                int h = (int)tms;

                lblCountdown.Text = //new DateTime((NextEvent - DateTime.Now).Ticks)
                                    //.ToString("mm:ss.fff");
                    string.Format("{0:00}:{1:00}:{2:00}", h, m, s);
            }

            if (LinesToBreak > 0)
                lblBreak.Text = "Break in " + LinesToBreak + " lines.";
            else
                lblBreak.Text = "Breaking.";
        }

        private void tsbRunRandom_Click(object sender, EventArgs e)
        {
            mnuRunRandom.PerformClick();
        }

        private void mnuRunRandom_Click(object sender, EventArgs e)
        {
            // get the log file name
            if (fdSaveLog.ShowDialog() != DialogResult.OK)
                return;

            Run(true, fdSaveLog.FileName);
        }

        private void mnuOptions_Click(object sender, EventArgs e)
        {
            new frmOptions(settings).ShowDialog();
        }

        private void tsbOptions_Click(object sender, EventArgs e)
        {
            mnuOptions.PerformClick();
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            mnuAbout.PerformClick();
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }
    }
}
