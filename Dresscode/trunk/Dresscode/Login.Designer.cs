namespace Dresscode
{
    partial class Login
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
            this.textbox_teacherid = new System.Windows.Forms.TextBox();
            this.textbox_password = new System.Windows.Forms.TextBox();
            this.label_user = new System.Windows.Forms.Label();
            this.label_password = new System.Windows.Forms.Label();
            this.button_login = new System.Windows.Forms.Button();
            this.linklabel_changepassword = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // textbox_teacherid
            // 
            this.textbox_teacherid.Location = new System.Drawing.Point(12, 25);
            this.textbox_teacherid.Name = "textbox_teacherid";
            this.textbox_teacherid.Size = new System.Drawing.Size(135, 20);
            this.textbox_teacherid.TabIndex = 0;
            // 
            // textbox_password
            // 
            this.textbox_password.Location = new System.Drawing.Point(12, 64);
            this.textbox_password.Name = "textbox_password";
            this.textbox_password.PasswordChar = '*';
            this.textbox_password.Size = new System.Drawing.Size(135, 20);
            this.textbox_password.TabIndex = 1;
            this.textbox_password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textbox_password_KeyDown);
            // 
            // label_user
            // 
            this.label_user.AutoSize = true;
            this.label_user.Location = new System.Drawing.Point(42, 9);
            this.label_user.Name = "label_user";
            this.label_user.Size = new System.Drawing.Size(61, 13);
            this.label_user.TabIndex = 2;
            this.label_user.Text = "Teacher ID";
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(50, 48);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(53, 13);
            this.label_password.TabIndex = 3;
            this.label_password.Text = "Password";
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(12, 90);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(135, 40);
            this.button_login.TabIndex = 4;
            this.button_login.Text = "Login";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // linklabel_changepassword
            // 
            this.linklabel_changepassword.AutoSize = true;
            this.linklabel_changepassword.Location = new System.Drawing.Point(30, 135);
            this.linklabel_changepassword.Name = "linklabel_changepassword";
            this.linklabel_changepassword.Size = new System.Drawing.Size(93, 13);
            this.linklabel_changepassword.TabIndex = 5;
            this.linklabel_changepassword.TabStop = true;
            this.linklabel_changepassword.Text = "Change Password";
            this.linklabel_changepassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(159, 157);
            this.Controls.Add(this.linklabel_changepassword);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.label_user);
            this.Controls.Add(this.textbox_password);
            this.Controls.Add(this.textbox_teacherid);
            this.Name = "Login";
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textbox_teacherid;
        private System.Windows.Forms.TextBox textbox_password;
        private System.Windows.Forms.Label label_user;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.LinkLabel linklabel_changepassword;
    }
}