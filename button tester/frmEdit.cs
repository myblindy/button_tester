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
    public partial class frmEdit : Form
    {
        public class ActionContainerClass
        {
            public Settings.PayloadClass.Action action;
        }

        public ActionContainerClass ActionContainer = new ActionContainerClass();

        Settings settings;

        public frmEdit(Settings settings)
        {
            InitializeComponent();
            this.settings = settings;

            txtButtonPressTest.Settings = txtDelayPressTest.Settings = txtWaitForConditionCondition.Settings = settings;
        }

        private void frmEdit_Load(object sender, EventArgs e)
        {
            // fill in the button press list box
            foreach (var b in settings.Payload.Buttons)
                lstButtons.Items.Add(b.Name);

            if (ActionContainer.action != null)
            {
                // we're in edit mode
                if (ActionContainer.action is Settings.PayloadClass.ActionButtonPress)
                {
                    var abp =
                        (Settings.PayloadClass.ActionButtonPress)ActionContainer.action;

                    // we're editing a button press action
                    foreach (var btn in abp.Buttons)
                        lstButtons.SetSelected(lstButtons.FindString(btn.Name.ToString()), true);

                    txtPressedRangeStart.Text = abp.PressedTime.First.ToString();
                    txtPressedRangeEnd.Text = abp.PressedTime.Second.ToString();

                    chkUseAll.Checked = abp.UseAll;

                    if (chkRequiresTestForButtonPress.Checked = abp.TestToPass != null)
                        txtButtonPressTest.Text = abp.TestToPass.Expression;

                    tabMain.SelectedIndex = 0;
                }
                else if (ActionContainer.action is Settings.PayloadClass.ActionDelay)
                {
                    // we're editing a delay action
                    var delay = (Settings.PayloadClass.ActionDelay)ActionContainer.action;
                    txtRangeStart.Text = delay.Range.First.ToString();
                    txtRangeEnd.Text = delay.Range.Second.ToString();

                    if (chkRequiresTestForDelay.Checked = delay.TestToPass != null)
                        txtDelayPressTest.Text = delay.TestToPass.Expression;

                    tabMain.SelectedIndex = 1;
                }
                else if (ActionContainer.action is Settings.PayloadClass.ActionEnd)
                {
                    tabMain.SelectedIndex = 3;
                }
                else if (ActionContainer.action is Settings.PayloadClass.ActionWaitForCondition)
                {
                    txtWaitForConditionCondition.Text =
                        ((Settings.PayloadClass.ActionWaitForCondition)ActionContainer.action)
                        .Condition.Expression;
                    tabMain.SelectedIndex = 2;
                }
                else
                    throw new IndexOutOfRangeException("Trying to edit an invalid type of action");
            }
            else
            {
                // we're in add mode
                // in this mode we aren't really doing anything to set up
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            double start, end;

            switch (tabMain.SelectedIndex)
            {
                case 0:
                    if (lstButtons.SelectedItems.Count <= 0)
                    {
                        MessageBox.Show("You have to select at least one button to press.", null,
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }


                    if (double.TryParse(txtPressedRangeStart.Text, out start) &&
                        double.TryParse(txtPressedRangeEnd.Text, out end) &&
                        start <= end && start >= 0)
                    {
                        ActionContainer.action = new Settings.PayloadClass.ActionButtonPress();
                        var abp =
                            (Settings.PayloadClass.ActionButtonPress)ActionContainer.action;

                        foreach (var btn in lstButtons.SelectedItems)
                            abp.Buttons.Add(settings.Payload.Buttons.First(w => w.Name == (string)btn));

                        abp.PressedTime.First = start;
                        abp.PressedTime.Second = end;

                        abp.TestToPass = chkRequiresTestForButtonPress.Checked
                            ? new TestExpression(txtButtonPressTest.Text)
                            : null;

                        abp.UseAll = chkUseAll.Checked;
                    }
                    else
                    {
                        MessageBox.Show("The range you entered isn't a valid range.", null,
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }

                    break;

                case 1:
                    if (double.TryParse(txtRangeStart.Text, out start) &&
                        double.TryParse(txtRangeEnd.Text, out end) &&
                        start <= end)
                    {
                        ActionContainer.action = new Settings.PayloadClass.ActionDelay();
                        var delay = (Settings.PayloadClass.ActionDelay)ActionContainer.action;

                        delay.Range.First = start;
                        delay.Range.Second = end;

                        delay.TestToPass = chkRequiresTestForDelay.Checked
                            ? new TestExpression(txtDelayPressTest.Text)
                            : null;
                    }
                    else
                    {
                        MessageBox.Show("The range you entered isn't a valid range.", null,
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }

                    break;

                case 2:
                    ActionContainer.action = new Settings.PayloadClass.ActionWaitForCondition
                    {
                        Condition = new TestExpression(txtWaitForConditionCondition.Text)
                    };
                    break;

                case 3:
                    ActionContainer.action = new Settings.PayloadClass.ActionEnd();

                    break;
            }

            // return success
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAddButton_Click(object sender, EventArgs e)
        {
            var eb = new frmEditButton();
            eb.ButtonInfoContainer.buttontype = null;
            if (eb.ShowDialog() != DialogResult.OK)
                return;

            settings.Payload.Buttons.Add(eb.ButtonInfoContainer.buttontype);
            lstButtons.Items.Add(eb.ButtonInfoContainer.buttontype.Name);

            //settings.SaveGlobals();
        }

        private void btnDeleteButton_Click(object sender, EventArgs e)
        {
            if (lstButtons.SelectedIndex >= 0 &&
                MessageBox.Show("Are you sure you want to delete the selected item?", "Deletion Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                settings.Payload.Buttons.RemoveAt(lstButtons.SelectedIndex);
                lstButtons.Items.RemoveAt(lstButtons.SelectedIndex);

                //settings.SaveGlobals();
            }
        }

        private void btnEditButton_Click(object sender, EventArgs e)
        {
            if (lstButtons.SelectedIndex < 0)
                return;

            var eb = new frmEditButton();
            eb.ButtonInfoContainer.buttontype = settings.Payload.Buttons[lstButtons.SelectedIndex];
            if (eb.ShowDialog() != DialogResult.OK)
                return;

            settings.Payload.Buttons[lstButtons.SelectedIndex] = eb.ButtonInfoContainer.buttontype;
            lstButtons.Items[lstButtons.SelectedIndex] = "";
            lstButtons.Items[lstButtons.SelectedIndex] = eb.ButtonInfoContainer.buttontype.Name;

            //settings.SaveGlobals();
        }

        private void chkRequiresTestForButtonPress_CheckedChanged(object sender, EventArgs e)
        {
            txtButtonPressTest.Enabled = chkRequiresTestForButtonPress.Checked;
        }

        private void chkRequiresTestForDelay_CheckedChanged(object sender, EventArgs e)
        {
            txtDelayPressTest.Enabled = chkRequiresTestForDelay.Checked;
        }
    }
}
