namespace button_tester
{
    partial class AutoCompleteExpressionBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtExpression = new System.Windows.Forms.TextBox();
            this.btnAutoComplete = new System.Windows.Forms.Button();
            this.mnuSuggestions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.noSuggestionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSuggestions.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtExpression
            // 
            this.txtExpression.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExpression.Location = new System.Drawing.Point(0, 0);
            this.txtExpression.Multiline = true;
            this.txtExpression.Name = "txtExpression";
            this.txtExpression.Size = new System.Drawing.Size(277, 163);
            this.txtExpression.TabIndex = 0;
            // 
            // btnAutoComplete
            // 
            this.btnAutoComplete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoComplete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAutoComplete.Location = new System.Drawing.Point(277, 0);
            this.btnAutoComplete.Name = "btnAutoComplete";
            this.btnAutoComplete.Size = new System.Drawing.Size(27, 163);
            this.btnAutoComplete.TabIndex = 1;
            this.btnAutoComplete.Text = "->";
            this.btnAutoComplete.UseVisualStyleBackColor = true;
            this.btnAutoComplete.Click += new System.EventHandler(this.btnAutoComplete_Click);
            // 
            // mnuSuggestions
            // 
            this.mnuSuggestions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noSuggestionsToolStripMenuItem});
            this.mnuSuggestions.Name = "mnuSuggestions";
            this.mnuSuggestions.Size = new System.Drawing.Size(166, 26);
            // 
            // noSuggestionsToolStripMenuItem
            // 
            this.noSuggestionsToolStripMenuItem.Enabled = false;
            this.noSuggestionsToolStripMenuItem.Name = "noSuggestionsToolStripMenuItem";
            this.noSuggestionsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.noSuggestionsToolStripMenuItem.Text = "(no suggestions)";
            // 
            // AutoCompleteExpressionBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAutoComplete);
            this.Controls.Add(this.txtExpression);
            this.Name = "AutoCompleteExpressionBox";
            this.Size = new System.Drawing.Size(304, 163);
            this.Load += new System.EventHandler(this.AutoCompleteExpressionBox_Load);
            this.mnuSuggestions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtExpression;
        private System.Windows.Forms.Button btnAutoComplete;
        private System.Windows.Forms.ContextMenuStrip mnuSuggestions;
        private System.Windows.Forms.ToolStripMenuItem noSuggestionsToolStripMenuItem;
    }
}
