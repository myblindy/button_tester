using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace button_tester
{
    public partial class AutoCompleteExpressionBox : UserControl
    {
        private Settings settings;

        public AutoCompleteExpressionBox()
        {
            InitializeComponent();
        }

        public override string Text
        {
            get
            {
                return txtExpression.Text;
            }
            set
            {
                txtExpression.Text = value;
            }
        }

        public bool ValidateExpression() { return TestExpression.Validate(txtExpression.Text, settings); }

        public static Dictionary<string, string> GetRedefitionions(Settings settings)
        {
            Dictionary<string, string> suggestions = new Dictionary<string, string>();

            // first read the settings for the default buttons
            foreach (var button in settings.Payload.Buttons)
            {
                string key = "D" + button.PinID;
                if (!suggestions.Keys.Contains(key))
                    suggestions.Add(key, button.Name);
            }

            // let the user redefine as he sees fit
            foreach (var redefinition in settings.Payload.DigitalNameOverrides)
            {
                string key = "D" + redefinition.Key;
                if (suggestions.Keys.Contains(key))
                    suggestions[key] = redefinition.Value;
                else
                    suggestions.Add(key, redefinition.Value);
            }

            return suggestions;
        }

        public Settings Settings
        {
            set
            {
                settings = value;

                Dictionary<string, string> suggestions = GetRedefitionions(settings);

                // clear the menu
                mnuSuggestions.Items.Clear();

                // fill in the suggestions
                foreach (var suggestion in
                    from ss in suggestions
                    orderby ss.Value
                    select ss)
                {
                    ToolStripMenuItem mnui = new ToolStripMenuItem(suggestion.Value + " (" + suggestion.Key + ")");
                    mnui.Tag = "[" + suggestion.Value + "]";
                    mnui.Click += new EventHandler(mnuSuggestionsItem_Click);
                    mnuSuggestions.Items.Add(mnui);
                }

                mnuSuggestions.Items.Add(new ToolStripSeparator());

                // door up/down/still
                ToolStripMenuItem doorc = new ToolStripMenuItem("Door is going down");
                doorc.Click += new EventHandler(mnuSuggestionsItem_Click);
                doorc.Tag = " DoorDown ";
                mnuSuggestions.Items.Add(doorc);

                doorc = new ToolStripMenuItem("Door is still");
                doorc.Click += new EventHandler(mnuSuggestionsItem_Click);
                doorc.Tag = " DoorStill ";
                mnuSuggestions.Items.Add(doorc);

                doorc = new ToolStripMenuItem("Door is going up");
                doorc.Click += new EventHandler(mnuSuggestionsItem_Click);
                doorc.Tag = " DoorUp ";
                mnuSuggestions.Items.Add(doorc);

                mnuSuggestions.Items.Add(new ToolStripSeparator());

                // customize
                ToolStripMenuItem mnuc = new ToolStripMenuItem("Customize...");
                mnuc.Click += new EventHandler(mnuSuggestionsCustomize_Click);
                mnuSuggestions.Items.Add(mnuc);
            }
        }

        void mnuSuggestionsCustomize_Click(object sender, EventArgs e)
        {
            if (new AutoCompleteExpressionBoxCustomization(settings).ShowDialog() == DialogResult.OK)
                Settings = settings;  // force a reset
        }

        void mnuSuggestionsItem_Click(object sender, EventArgs e)
        {
            txtExpression.SelectedText =
                (sender as ToolStripMenuItem).Tag as string;
            txtExpression.Focus();
        }

        private void AutoCompleteExpressionBox_Load(object sender, EventArgs e)
        {
        }

        private void btnAutoComplete_Click(object sender, EventArgs e)
        {
            Point pt = PointToScreen(
                new Point(btnAutoComplete.Left + btnAutoComplete.Width,
                    btnAutoComplete.Top));

            mnuSuggestions.Show(pt);
        }
    }
}
