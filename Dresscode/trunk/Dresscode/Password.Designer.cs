namespace Dresscode
{
    partial class Password
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
            this.linkLabel_forgot = new System.Windows.Forms.LinkLabel();
            this.textBox_old_pass = new System.Windows.Forms.TextBox();
            this.textBox_new_pass_first = new System.Windows.Forms.TextBox();
            this.textBox_new_pass_second = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_change_pass = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_teacherID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // linkLabel_forgot
            // 
            this.linkLabel_forgot.AutoSize = true;
            this.linkLabel_forgot.Location = new System.Drawing.Point(193, 61);
            this.linkLabel_forgot.Name = "linkLabel_forgot";
            this.linkLabel_forgot.Size = new System.Drawing.Size(131, 13);
            this.linkLabel_forgot.TabIndex = 0;
            this.linkLabel_forgot.TabStop = true;
            this.linkLabel_forgot.Text = "Forgot your old password?";
            this.linkLabel_forgot.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_forgot_LinkClicked);
            // 
            // textBox_old_pass
            // 
            this.textBox_old_pass.Location = new System.Drawing.Point(133, 38);
            this.textBox_old_pass.Name = "textBox_old_pass";
            this.textBox_old_pass.Size = new System.Drawing.Size(191, 20);
            this.textBox_old_pass.TabIndex = 1;
            // 
            // textBox_new_pass_first
            // 
            this.textBox_new_pass_first.Location = new System.Drawing.Point(133, 77);
            this.textBox_new_pass_first.Name = "textBox_new_pass_first";
            this.textBox_new_pass_first.Size = new System.Drawing.Size(191, 20);
            this.textBox_new_pass_first.TabIndex = 2;
            // 
            // textBox_new_pass_second
            // 
            this.textBox_new_pass_second.Location = new System.Drawing.Point(133, 103);
            this.textBox_new_pass_second.Name = "textBox_new_pass_second";
            this.textBox_new_pass_second.Size = new System.Drawing.Size(191, 20);
            this.textBox_new_pass_second.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Old Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "New Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Re-Type New Password";
            // 
            // button_change_pass
            // 
            this.button_change_pass.Location = new System.Drawing.Point(115, 129);
            this.button_change_pass.Name = "button_change_pass";
            this.button_change_pass.Size = new System.Drawing.Size(102, 23);
            this.button_change_pass.TabIndex = 7;
            this.button_change_pass.Text = "Change Password";
            this.button_change_pass.UseVisualStyleBackColor = true;
            this.button_change_pass.Click += new System.EventHandler(this.button_change_pass_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Teacher ID";
            // 
            // textBox_teacherID
            // 
            this.textBox_teacherID.Location = new System.Drawing.Point(133, 12);
            this.textBox_teacherID.Name = "textBox_teacherID";
            this.textBox_teacherID.Size = new System.Drawing.Size(191, 20);
            this.textBox_teacherID.TabIndex = 8;
            // 
            // Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 161);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_teacherID);
            this.Controls.Add(this.button_change_pass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_new_pass_second);
            this.Controls.Add(this.textBox_new_pass_first);
            this.Controls.Add(this.textBox_old_pass);
            this.Controls.Add(this.linkLabel_forgot);
            this.Name = "Password";
            this.Text = "Password";
            this.Load += new System.EventHandler(this.Password_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel_forgot;
        private System.Windows.Forms.TextBox textBox_old_pass;
        private System.Windows.Forms.TextBox textBox_new_pass_first;
        private System.Windows.Forms.TextBox textBox_new_pass_second;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_change_pass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_teacherID;
        public string email;

    }
}