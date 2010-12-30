namespace button_tester
{
    partial class frmEditPriority
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTestExpression = new button_tester.AutoCompleteExpressionBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstButtonOrder = new System.Windows.Forms.CheckedListBox();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtExitCondition = new button_tester.AutoCompleteExpressionBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTestExpression);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "The test expression";
            // 
            // txtTestExpression
            // 
            this.txtTestExpression.Location = new System.Drawing.Point(6, 19);
            this.txtTestExpression.Name = "txtTestExpression";
            this.txtTestExpression.Size = new System.Drawing.Size(327, 45);
            this.txtTestExpression.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstButtonOrder);
            this.groupBox2.Controls.Add(this.btnMoveDown);
            this.groupBox2.Controls.Add(this.btnMoveUp);
            this.groupBox2.Location = new System.Drawing.Point(12, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(343, 124);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Button Order";
            // 
            // lstButtonOrder
            // 
            this.lstButtonOrder.FormattingEnabled = true;
            this.lstButtonOrder.Location = new System.Drawing.Point(6, 19);
            this.lstButtonOrder.Name = "lstButtonOrder";
            this.lstButtonOrder.Size = new System.Drawing.Size(278, 94);
            this.lstButtonOrder.TabIndex = 5;
            this.lstButtonOrder.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstButtonOrder_ItemCheck);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(290, 63);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(43, 38);
            this.btnMoveDown.TabIndex = 4;
            this.btnMoveDown.Text = "Move down";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(290, 19);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(43, 38);
            this.btnMoveUp.TabIndex = 4;
            this.btnMoveUp.Text = "Move up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(281, 314);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(200, 314);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtExitCondition);
            this.groupBox3.Location = new System.Drawing.Point(13, 93);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(343, 75);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "The exit condition (leave empty for none)";
            // 
            // txtExitCondition
            // 
            this.txtExitCondition.Location = new System.Drawing.Point(6, 19);
            this.txtExitCondition.Name = "txtExitCondition";
            this.txtExitCondition.Size = new System.Drawing.Size(327, 45);
            this.txtExitCondition.TabIndex = 0;
            // 
            // frmEditPriority
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 349);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditPriority";
            this.Text = "Edit the priority";
            this.Load += new System.EventHandler(this.frmEditPriority_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private AutoCompleteExpressionBox txtTestExpression;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckedListBox lstButtonOrder;
        private System.Windows.Forms.GroupBox groupBox3;
        private AutoCompleteExpressionBox txtExitCondition;
    }
}