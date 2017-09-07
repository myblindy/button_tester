namespace button_tester
{
    partial class frmEdit
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkRequiresTestForButtonPress = new System.Windows.Forms.CheckBox();
            this.chkUseAll = new System.Windows.Forms.CheckBox();
            this.btnEditButton = new System.Windows.Forms.Button();
            this.btnDeleteButton = new System.Windows.Forms.Button();
            this.btnAddButton = new System.Windows.Forms.Button();
            this.txtPressedRangeEnd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPressedRangeStart = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lstButtons = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkRequiresTestForDelay = new System.Windows.Forms.CheckBox();
            this.txtRangeEnd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRangeStart = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtButtonPressTest = new button_tester.AutoCompleteExpressionBox();
            this.txtDelayPressTest = new button_tester.AutoCompleteExpressionBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtWaitForConditionCondition = new button_tester.AutoCompleteExpressionBox();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Controls.Add(this.tabPage4);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.Location = new System.Drawing.Point(12, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(296, 405);
            this.tabMain.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkRequiresTestForButtonPress);
            this.tabPage1.Controls.Add(this.txtButtonPressTest);
            this.tabPage1.Controls.Add(this.chkUseAll);
            this.tabPage1.Controls.Add(this.btnEditButton);
            this.tabPage1.Controls.Add(this.btnDeleteButton);
            this.tabPage1.Controls.Add(this.btnAddButton);
            this.tabPage1.Controls.Add(this.txtPressedRangeEnd);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtPressedRangeStart);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.lstButtons);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(288, 379);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Button press";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkRequiresTestForButtonPress
            // 
            this.chkRequiresTestForButtonPress.AutoSize = true;
            this.chkRequiresTestForButtonPress.Location = new System.Drawing.Point(6, 275);
            this.chkRequiresTestForButtonPress.Name = "chkRequiresTestForButtonPress";
            this.chkRequiresTestForButtonPress.Size = new System.Drawing.Size(133, 17);
            this.chkRequiresTestForButtonPress.TabIndex = 11;
            this.chkRequiresTestForButtonPress.Text = "Requires Test to Pass:";
            this.chkRequiresTestForButtonPress.UseVisualStyleBackColor = true;
            this.chkRequiresTestForButtonPress.CheckedChanged += new System.EventHandler(this.chkRequiresTestForButtonPress_CheckedChanged);
            // 
            // chkUseAll
            // 
            this.chkUseAll.AutoSize = true;
            this.chkUseAll.Location = new System.Drawing.Point(101, 72);
            this.chkUseAll.Name = "chkUseAll";
            this.chkUseAll.Size = new System.Drawing.Size(97, 17);
            this.chkUseAll.TabIndex = 9;
            this.chkUseAll.Text = "Use all at once";
            this.chkUseAll.UseVisualStyleBackColor = true;
            // 
            // btnEditButton
            // 
            this.btnEditButton.Location = new System.Drawing.Point(9, 238);
            this.btnEditButton.Name = "btnEditButton";
            this.btnEditButton.Size = new System.Drawing.Size(83, 21);
            this.btnEditButton.TabIndex = 4;
            this.btnEditButton.Text = "Edit Button";
            this.btnEditButton.UseVisualStyleBackColor = true;
            this.btnEditButton.Click += new System.EventHandler(this.btnEditButton_Click);
            // 
            // btnDeleteButton
            // 
            this.btnDeleteButton.Location = new System.Drawing.Point(9, 212);
            this.btnDeleteButton.Name = "btnDeleteButton";
            this.btnDeleteButton.Size = new System.Drawing.Size(83, 21);
            this.btnDeleteButton.TabIndex = 3;
            this.btnDeleteButton.Text = "Delete button";
            this.btnDeleteButton.UseVisualStyleBackColor = true;
            this.btnDeleteButton.Click += new System.EventHandler(this.btnDeleteButton_Click);
            // 
            // btnAddButton
            // 
            this.btnAddButton.Location = new System.Drawing.Point(9, 186);
            this.btnAddButton.Name = "btnAddButton";
            this.btnAddButton.Size = new System.Drawing.Size(83, 21);
            this.btnAddButton.TabIndex = 2;
            this.btnAddButton.Text = "Add Button";
            this.btnAddButton.UseVisualStyleBackColor = true;
            this.btnAddButton.Click += new System.EventHandler(this.btnAddButton_Click);
            // 
            // txtPressedRangeEnd
            // 
            this.txtPressedRangeEnd.Location = new System.Drawing.Point(101, 154);
            this.txtPressedRangeEnd.Name = "txtPressedRangeEnd";
            this.txtPressedRangeEnd.Size = new System.Drawing.Size(102, 20);
            this.txtPressedRangeEnd.TabIndex = 8;
            this.txtPressedRangeEnd.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(98, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "and:";
            // 
            // txtPressedRangeStart
            // 
            this.txtPressedRangeStart.Location = new System.Drawing.Point(101, 108);
            this.txtPressedRangeStart.Name = "txtPressedRangeStart";
            this.txtPressedRangeStart.Size = new System.Drawing.Size(102, 20);
            this.txtPressedRangeStart.TabIndex = 6;
            this.txtPressedRangeStart.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(98, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Pressed duration between:";
            // 
            // lstButtons
            // 
            this.lstButtons.FormattingEnabled = true;
            this.lstButtons.Location = new System.Drawing.Point(9, 72);
            this.lstButtons.Name = "lstButtons";
            this.lstButtons.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstButtons.Size = new System.Drawing.Size(83, 108);
            this.lstButtons.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 66);
            this.label1.TabIndex = 0;
            this.label1.Text = "This lets you insert a button press in the program. You can choose more than one " +
    "button from the list and when you run the program it will choose one button from" +
    " the list at random.";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkRequiresTestForDelay);
            this.tabPage2.Controls.Add(this.txtRangeEnd);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtRangeStart);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txtDelayPressTest);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(288, 379);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Delay";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkRequiresTestForDelay
            // 
            this.chkRequiresTestForDelay.AutoSize = true;
            this.chkRequiresTestForDelay.Location = new System.Drawing.Point(6, 122);
            this.chkRequiresTestForDelay.Name = "chkRequiresTestForDelay";
            this.chkRequiresTestForDelay.Size = new System.Drawing.Size(133, 17);
            this.chkRequiresTestForDelay.TabIndex = 13;
            this.chkRequiresTestForDelay.Text = "Requires Test to Pass:";
            this.chkRequiresTestForDelay.UseVisualStyleBackColor = true;
            this.chkRequiresTestForDelay.CheckedChanged += new System.EventHandler(this.chkRequiresTestForDelay_CheckedChanged);
            // 
            // txtRangeEnd
            // 
            this.txtRangeEnd.Location = new System.Drawing.Point(104, 86);
            this.txtRangeEnd.Name = "txtRangeEnd";
            this.txtRangeEnd.Size = new System.Drawing.Size(115, 20);
            this.txtRangeEnd.TabIndex = 4;
            this.txtRangeEnd.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "End of the range:";
            // 
            // txtRangeStart
            // 
            this.txtRangeStart.Location = new System.Drawing.Point(104, 60);
            this.txtRangeStart.Name = "txtRangeStart";
            this.txtRangeStart.Size = new System.Drawing.Size(115, 20);
            this.txtRangeStart.TabIndex = 2;
            this.txtRangeStart.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Start of the range:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(271, 60);
            this.label2.TabIndex = 0;
            this.label2.Text = "This lets you insert a random delay which ranges between the 2 values below. If y" +
    "ou don\'t want the delay to be random, set the end of the range equal to the star" +
    "t.";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(288, 379);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "End of program";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(271, 71);
            this.label5.TabIndex = 2;
            this.label5.Text = "This lets you insert an end of the program marker. Once the execution reaches thi" +
    "s point, the program will stop. If there is no end of the program marker, the pr" +
    "ogram will keep looping forever.";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(229, 423);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(148, 423);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtButtonPressTest
            // 
            this.txtButtonPressTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtButtonPressTest.Location = new System.Drawing.Point(6, 298);
            this.txtButtonPressTest.Name = "txtButtonPressTest";
            this.txtButtonPressTest.Size = new System.Drawing.Size(279, 75);
            this.txtButtonPressTest.TabIndex = 10;
            // 
            // txtDelayPressTest
            // 
            this.txtDelayPressTest.Location = new System.Drawing.Point(6, 145);
            this.txtDelayPressTest.Name = "txtDelayPressTest";
            this.txtDelayPressTest.Size = new System.Drawing.Size(268, 75);
            this.txtDelayPressTest.TabIndex = 12;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtWaitForConditionCondition);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(288, 379);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Wait for Condition";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(271, 40);
            this.label8.TabIndex = 3;
            this.label8.Text = "This lets you wait for a condition before proceeding to the next line.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Condition:";
            // 
            // txtWaitForConditionCondition
            // 
            this.txtWaitForConditionCondition.Location = new System.Drawing.Point(9, 59);
            this.txtWaitForConditionCondition.Name = "txtWaitForConditionCondition";
            this.txtWaitForConditionCondition.Size = new System.Drawing.Size(268, 75);
            this.txtWaitForConditionCondition.TabIndex = 13;
            // 
            // frmEdit
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(320, 458);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Item";
            this.Load += new System.EventHandler(this.frmEdit_Load);
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstButtons;
        private System.Windows.Forms.TextBox txtRangeEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRangeStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPressedRangeEnd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPressedRangeStart;
        private System.Windows.Forms.Button btnDeleteButton;
        private System.Windows.Forms.Button btnAddButton;
        private System.Windows.Forms.Button btnEditButton;
        private System.Windows.Forms.CheckBox chkUseAll;
        private AutoCompleteExpressionBox txtButtonPressTest;
        private System.Windows.Forms.CheckBox chkRequiresTestForButtonPress;
        private System.Windows.Forms.CheckBox chkRequiresTestForDelay;
        private AutoCompleteExpressionBox txtDelayPressTest;
        private System.Windows.Forms.TabPage tabPage4;
        private AutoCompleteExpressionBox txtWaitForConditionCondition;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}