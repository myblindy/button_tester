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
    public partial class frmEditPriority : Form
    {
        Settings settings;
        Settings.PayloadClass.Priority priority;

        bool ready = false;

        public frmEditPriority(Settings settings, Settings.PayloadClass.Priority priority)
        {
            this.settings = settings;
            this.priority = priority;
            InitializeComponent();
        }

        private void frmEditPriority_Load(object sender, EventArgs e)
        {
            txtTestExpression.Settings = settings;
            txtTestExpression.Text = priority.Condition.Expression;

            txtExitCondition.Settings = settings;
            txtExitCondition.Text = priority.ExitCondition.Expression;

            var list = settings.Payload.Buttons;

            foreach (var po in priority.PriorityOrder)
                lstButtonOrder.Items.Add(list[po.First].Name, 
                    po.Second== Settings.PayloadClass.Priority.PriorityState.Used?CheckState.Checked:
                    po.Second==Settings.PayloadClass.Priority.PriorityState.NotUsed?CheckState.Unchecked:
                    CheckState.Indeterminate);

            for (int i = 0; i < list.Count; ++i)
                if (!priority.PriorityOrder.Any(w => w.First == i))
                    lstButtonOrder.Items.Add(list[i].Name, true);

            ready = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!txtTestExpression.ValidateExpression() || !txtExitCondition.ValidateExpression())
            {
                MessageBox.Show("Invalid test expressions");
                return;
            }

            priority.Condition = new TestExpression(txtTestExpression.Text);
            priority.ExitCondition = new TestExpression(txtExitCondition.Text);
            priority.PriorityOrder = new List<Pair<int, Settings.PayloadClass.Priority.PriorityState>>();
            for (int k = 0; k < lstButtonOrder.Items.Count; ++k)
                for (int i = 0; i < settings.Payload.Buttons.Count; ++i)
                    if (settings.Payload.Buttons[i].Name == (string)lstButtonOrder.Items[k])
                    {
                        var cs=lstButtonOrder.GetItemCheckState(k);
                        priority.PriorityOrder.Add(
                            new Pair<int, Settings.PayloadClass.Priority.PriorityState>(i,
                                cs == CheckState.Checked ? Settings.PayloadClass.Priority.PriorityState.Used :
                                cs == CheckState.Unchecked ? Settings.PayloadClass.Priority.PriorityState.NotUsed :
                                Settings.PayloadClass.Priority.PriorityState.NotUsedAndReset));
                        break;
                    }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (lstButtonOrder.SelectedIndex < 1)
                return;

            string tmp = lstButtonOrder.Items[lstButtonOrder.SelectedIndex - 1] as string;
            lstButtonOrder.Items[lstButtonOrder.SelectedIndex - 1] = lstButtonOrder.Items[lstButtonOrder.SelectedIndex];
            lstButtonOrder.Items[lstButtonOrder.SelectedIndex] = tmp;

            ready = false;
            var chk = lstButtonOrder.GetItemCheckState(lstButtonOrder.SelectedIndex - 1);
            lstButtonOrder.SetItemCheckState(lstButtonOrder.SelectedIndex - 1, lstButtonOrder.GetItemCheckState(lstButtonOrder.SelectedIndex));
            lstButtonOrder.SetItemCheckState(lstButtonOrder.SelectedIndex, chk);
            ready = true;

            --lstButtonOrder.SelectedIndex;
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (lstButtonOrder.SelectedIndex < 0 || lstButtonOrder.SelectedIndex >= lstButtonOrder.Items.Count - 1)
                return;

            string tmp = lstButtonOrder.Items[lstButtonOrder.SelectedIndex] as string;
            lstButtonOrder.Items[lstButtonOrder.SelectedIndex] = lstButtonOrder.Items[lstButtonOrder.SelectedIndex + 1];
            lstButtonOrder.Items[lstButtonOrder.SelectedIndex + 1] = tmp;

            ready = false;
            var chk = lstButtonOrder.GetItemCheckState(lstButtonOrder.SelectedIndex);
            lstButtonOrder.SetItemCheckState(lstButtonOrder.SelectedIndex, lstButtonOrder.GetItemCheckState(lstButtonOrder.SelectedIndex + 1));
            lstButtonOrder.SetItemCheckState(lstButtonOrder.SelectedIndex + 1, chk);
            ready = true;

            ++lstButtonOrder.SelectedIndex;
        }

        private void lstButtonOrder_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!ready)
                return; 

            if (e.CurrentValue == CheckState.Unchecked)
                e.NewValue = CheckState.Indeterminate;
            else if (e.CurrentValue == CheckState.Indeterminate)
                e.NewValue = CheckState.Checked;
        }
    }
}
