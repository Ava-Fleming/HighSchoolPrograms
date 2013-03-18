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
            this.linklabel_forgotpassword = new System.Windows.Forms.LinkLabel();
            this.textBox_old_pass = new System.Windows.Forms.TextBox();
            this.textBox_new_pass_first = new System.Windows.Forms.TextBox();
            this.textBox_new_pass_second = new System.Windows.Forms.TextBox();
            this.label_oldpassword = new System.Windows.Forms.Label();
            this.label_newpassword = new System.Windows.Forms.Label();
            this.label_newpasswordretype = new System.Windows.Forms.Label();
            this.button_change_pass = new System.Windows.Forms.Button();
            this.label_teacherid = new System.Windows.Forms.Label();
            this.textBox_teacherID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // linklabel_forgotpassword
            // 
            this.linklabel_forgotpassword.AutoSize = true;
            this.linklabel_forgotpassword.Location = new System.Drawing.Point(193, 61);
            this.linklabel_forgotpassword.Name = "linklabel_forgotpassword";
            this.linklabel_forgotpassword.Size = new System.Drawing.Size(131, 13);
            this.linklabel_forgotpassword.TabIndex = 0;
            this.linklabel_forgotpassword.TabStop = true;
            this.linklabel_forgotpassword.Text = "Forgot your old password?";
            this.linklabel_forgotpassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_forgot_LinkClicked);
            // 
            // textBox_old_pass
            // 
            this.textBox_old_pass.Location = new System.Drawing.Point(133, 38);
            this.textBox_old_pass.Name = "textBox_old_pass";
            this.textBox_old_pass.PasswordChar = '*';
            this.textBox_old_pass.Size = new System.Drawing.Size(191, 20);
            this.textBox_old_pass.TabIndex = 1;
            // 
            // textBox_new_pass_first
            // 
            this.textBox_new_pass_first.Location = new System.Drawing.Point(133, 77);
            this.textBox_new_pass_first.Name = "textBox_new_pass_first";
            this.textBox_new_pass_first.PasswordChar = '*';
            this.textBox_new_pass_first.Size = new System.Drawing.Size(191, 20);
            this.textBox_new_pass_first.TabIndex = 2;
            // 
            // textBox_new_pass_second
            // 
            this.textBox_new_pass_second.Location = new System.Drawing.Point(133, 103);
            this.textBox_new_pass_second.Name = "textBox_new_pass_second";
            this.textBox_new_pass_second.PasswordChar = '*';
            this.textBox_new_pass_second.Size = new System.Drawing.Size(191, 20);
            this.textBox_new_pass_second.TabIndex = 3;
            // 
            // label_oldpassword
            // 
            this.label_oldpassword.AutoSize = true;
            this.label_oldpassword.Location = new System.Drawing.Point(55, 41);
            this.label_oldpassword.Name = "label_oldpassword";
            this.label_oldpassword.Size = new System.Drawing.Size(72, 13);
            this.label_oldpassword.TabIndex = 4;
            this.label_oldpassword.Text = "Old Password";
            // 
            // label_newpassword
            // 
            this.label_newpassword.AutoSize = true;
            this.label_newpassword.Location = new System.Drawing.Point(49, 80);
            this.label_newpassword.Name = "label_newpassword";
            this.label_newpassword.Size = new System.Drawing.Size(78, 13);
            this.label_newpassword.TabIndex = 5;
            this.label_newpassword.Text = "New Password";
            // 
            // label_newpasswordretype
            // 
            this.label_newpasswordretype.AutoSize = true;
            this.label_newpasswordretype.Location = new System.Drawing.Point(5, 106);
            this.label_newpasswordretype.Name = "label_newpasswordretype";
            this.label_newpasswordretype.Size = new System.Drawing.Size(122, 13);
            this.label_newpasswordretype.TabIndex = 6;
            this.label_newpasswordretype.Text = "Re-Type New Password";
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
            // label_teacherid
            // 
            this.label_teacherid.AutoSize = true;
            this.label_teacherid.Location = new System.Drawing.Point(66, 15);
            this.label_teacherid.Name = "label_teacherid";
            this.label_teacherid.Size = new System.Drawing.Size(61, 13);
            this.label_teacherid.TabIndex = 9;
            this.label_teacherid.Text = "Teacher ID";
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
            this.Controls.Add(this.label_teacherid);
            this.Controls.Add(this.textBox_teacherID);
            this.Controls.Add(this.button_change_pass);
            this.Controls.Add(this.label_newpasswordretype);
            this.Controls.Add(this.label_newpassword);
            this.Controls.Add(this.label_oldpassword);
            this.Controls.Add(this.textBox_new_pass_second);
            this.Controls.Add(this.textBox_new_pass_first);
            this.Controls.Add(this.textBox_old_pass);
            this.Controls.Add(this.linklabel_forgotpassword);
            this.Name = "Password";
            this.Text = "Password";
            this.Load += new System.EventHandler(this.Password_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linklabel_forgotpassword;
        private System.Windows.Forms.TextBox textBox_old_pass;
        private System.Windows.Forms.TextBox textBox_new_pass_first;
        private System.Windows.Forms.TextBox textBox_new_pass_second;
        private System.Windows.Forms.Label label_oldpassword;
        private System.Windows.Forms.Label label_newpassword;
        private System.Windows.Forms.Label label_newpasswordretype;
        private System.Windows.Forms.Button button_change_pass;
        private System.Windows.Forms.Label label_teacherid;
        private System.Windows.Forms.TextBox textBox_teacherID;
        public string email;

    }
}