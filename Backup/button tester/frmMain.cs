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

namespace button_tester
{
    public partial class frmMain : Form
    {
        Settings settings = new Settings();

        delegate void InvokeDelegate();

        public frmMain()
        {
            InitializeComponent();
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
                    settings.FileName = fdSave.FileName;
                else
                    return;

            settings.Save();

            UpdateTitle();
        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            mnuOpenProject.PerformClick();
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
                if (!settings.Load(fdOpen.FileName))
                    return;

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
            }

            UpdateTitle();
        }

        private void mnuSaveProjectAs_Click(object sender, EventArgs e)
        {
            if (fdSave.ShowDialog() == DialogResult.OK)
            {
                settings.FileName = fdSave.FileName;
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

            //settings.SaveGlobals();
            if (mnuStop.Enabled)
                mnuStop_Click(null, null);

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Util.Init();
            Util.ResetOutputs();
            tmrUIUpdate_Tick(null, null);
            mnuNewProject.PerformClick();

            lblCnt.Text = "Cnt:" + Environment.NewLine + "--";
            lblErr.Text = "Err:" + Environment.NewLine + "0";
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

        private int[] OutputState;

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

        private void Run(bool random)
        {
            if (lvMain.Items.Count <= 0)
                return;

            // get the log file name
            if (fdSaveLog.ShowDialog() != DialogResult.OK)
                return;

            RunRandom = random;

            // stop the ui updating
            tmrUIUpdate.Enabled = false;

            // disable everything
            foreach (var item in menustripMain.Items)
                ((ToolStripItem)item).Enabled = false;

            foreach (var item in toolstripMain.Items)
                ((ToolStripItem)item).Enabled = false;

            mnuRun.Enabled= mnuRunRandom.Enabled = false;

            // initial break stuff
            BreakEnabled =
                settings.Payload.OfflineLineProcRange.First != settings.Payload.OfflineLineProcRange.Second ||
                settings.Payload.OfflineLineProcRange.Second != 0;
            LinesToBreak = settings.Random.Next(settings.Payload.OfflineLineProcRange.First,
                settings.Payload.OfflineLineProcRange.Second) + 1;
            InBreak = false;

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
            OutputState = new int[8];
            lblDirection.Text = "0";
            StopLoggingThread = false;
            lblCnt.Text = "Cnt:" + Environment.NewLine + (settings.Payload.UseCycles ? "0" : "--");
            lblErr.Text = "Err:" + Environment.NewLine + "0";
            Thread thread = new Thread(() =>
                {
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
                    float oldai0 = 0;
                    int[] InputState = null;
                    DateTime? shutdowncounterpintime = null;
                    int[] ResetPinPhases = new int[16];
                    int[] OldRealState = new int[16]; OldRealState[0] = -1;

                    // fill in the priority list box
                    DisplayPriority(priority);

                    while (!StopLoggingThread)
                    {
                        float ai0 = Util.ReadAnalogInput(0);
                        int sign = (ai0 < settings.Payload.ZeroToleranceLow) ? -1 :
                            ((ai0 > settings.Payload.ZeroToleranceHigh) ? 1 : 0);
                        string result;
                        bool pass = InputState == null;

                        // counter pin
                        if (shutdowncounterpintime.HasValue &&
                            DateTime.Now.CompareTo(shutdowncounterpintime.Value) > 0)
                        {
                            // set the output
                            Util.SetDigitalOutput(
                                settings.Payload.ClockOutputChannel.Value + 1, true, 0);

                            shutdowncounterpintime = null;
                        }

                        // build the state table
                        if (sign != OldSign && (DateTime.Now - lastsignchange).TotalMilliseconds <
                            settings.Payload.WaitBeforeAnalogChanges)
                        {
                            sign = OldSign;
                            ai0 = oldai0;
                        }
                        else
                        {
                            oldai0 = ai0;
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
                            lblDirection.BeginInvoke(new InvokeDelegate(delegate
                            {
                                lblDirection.Text = result;
                            }));

                            pass = true;

                            OldSign = sign;
                        }

                        int[] State = new int[16];
                        Array.Copy(OutputState, State, OutputState.Length);
                        int states = Util.ReadDigital();
                        for (int i = 9; i <= 16; ++i)
                            State[i - 1] = (states & (1 << (i - 1))) > 0 ? 1 : 0;

                        if (InputState != null)
                            for (int i = 0; i < 16; ++i)
                                if (State[i] != InputState[i])
                                {
                                    pass = true;
                                    break;
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
                            for(int i=0;i<16;++i)
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
                                            if (b.PinID == i+1 && tmprealstate[i] == 1)
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
                                bool ok = false;
                                switch (expectedts.Result)
                                {
                                    case Settings.PayloadClass.TestSet.ResultType.Down:
                                        ok = sign == -1;
                                        break;
                                    case Settings.PayloadClass.TestSet.ResultType.StayStill:
                                        ok = sign == 0;
                                        break;
                                    case Settings.PayloadClass.TestSet.ResultType.Up:
                                        ok = sign == 1;
                                        break;
                                }

                                if (ok)
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
                                        Util.SetDigitalOutput(
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
                        sb.Append(Util.Counter(true));
                        sb.Append(",");

                        sb.Append("\"");
                        sb.Append(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff"));
                        sb.Append("\"");

                        using (var s1 = File.Open(fdSaveLog.FileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                        using (var stream = new StreamWriter(s1))
                            stream.WriteLine(sb.ToString());
                    }

                    using (var s1 = File.Open(fdSaveLog.FileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                    using (var stream = new StreamWriter(s1))
                        stream.WriteLine("END,Thread terminated," +
                            DateTime.Now.ToString() + "," + cyclecounter + " cycles," +
                            errorcounter + " errors");
                });

            try
            {
                thread.Start();
            }
            catch
            {
            }
        }

        private void mnuRun_Click(object sender, EventArgs e)
        {
            Run(false);
        }

        private void mnuStop_Click(object sender, EventArgs e)
        {
            // stop the timers
            lblCountdown.Text = "";
            lblBreak.Text = "";
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

            Util.ResetOutputs();

            lblDirection.Text = "";
        }

        void ClearMarks()
        {
            foreach (ListViewItem line in lvMain.Items)
            {
                if (line.SubItems[3].Text != "")
                    line.SubItems[3].Text = "";

                if (line.BackColor != SystemColors.Window)
                    line.BackColor = SystemColors.Window;

                if (line.ForeColor != SystemColors.ControlText)
                    line.ForeColor = SystemColors.ControlText;
            }
        }

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

                Util.SetDigitalOutput(settings.Payload.PowerOffPin, true, 0);
                OutputState[settings.Payload.PowerOffPin - 1] = 0;
                if (CurrBTs != null)
                    foreach (var bt in CurrBTs)
                    {
                        Util.SetDigitalOutput(bt.PinID, true, 1);
                        OutputState[bt.PinID - 1] = 1;
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
                    Util.SetDigitalOutput(bt.PinID, true, 0);
                    OutputState[bt.PinID - 1] = 0;
                }
                CurrBTs = null;
            }

            // mark our current step
            ClearMarks();
            lvMain.Items[settings.IP].BackColor = Color.Green;
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
                    Util.SetDigitalOutput(bt.PinID, true, 1);
                    OutputState[bt.PinID - 1] = 1;
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
                        Util.SetDigitalOutput(bt.PinID, true, 0);
                        OutputState[bt.PinID - 1] = 0;
                    }

                Util.SetDigitalOutput(settings.Payload.PowerOffPin, true, 1);
                OutputState[settings.Payload.PowerOffPin - 1] = 1;
            }

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
            if (now.CompareTo(NextEvent) >= 0)
                lblCountdown.Text = "00:00.00";
            else
                lblCountdown.Text = new DateTime((NextEvent - DateTime.Now).Ticks)
                    .ToString("mm:ss.fff");

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
            Run(true);
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
