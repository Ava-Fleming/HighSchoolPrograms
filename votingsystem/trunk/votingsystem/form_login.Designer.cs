namespace votingsystem
{
    partial class form_login
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
            this.textbox_username = new System.Windows.Forms.TextBox();
            this.label_username = new System.Windows.Forms.Label();
            this.groupbox_login = new System.Windows.Forms.GroupBox();
            this.button_login = new System.Windows.Forms.Button();
            this.label_password = new System.Windows.Forms.Label();
            this.textbox_password = new System.Windows.Forms.TextBox();
            this.groupbox_login.SuspendLayout();
            this.SuspendLayout();
            // 
            // textbox_username
            // 
            this.textbox_username.Location = new System.Drawing.Point(6, 32);
            this.textbox_username.Name = "textbox_username";
            this.textbox_username.Size = new System.Drawing.Size(105, 20);
            this.textbox_username.TabIndex = 0;
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.Location = new System.Drawing.Point(26, 16);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(58, 13);
            this.label_username.TabIndex = 1;
            this.label_username.Text = "Username:";
            // 
            // groupbox_login
            // 
            this.groupbox_login.Controls.Add(this.button_login);
            this.groupbox_login.Controls.Add(this.label_password);
            this.groupbox_login.Controls.Add(this.textbox_password);
            this.groupbox_login.Controls.Add(this.label_username);
            this.groupbox_login.Controls.Add(this.textbox_username);
            this.groupbox_login.Location = new System.Drawing.Point(12, 12);
            this.groupbox_login.Name = "groupbox_login";
            this.groupbox_login.Size = new System.Drawing.Size(117, 152);
            this.groupbox_login.TabIndex = 2;
            this.groupbox_login.TabStop = false;
            this.groupbox_login.Text = "Login";
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(6, 97);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(105, 49);
            this.button_login.TabIndex = 6;
            this.button_login.Text = "Login";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(26, 55);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(56, 13);
            this.label_password.TabIndex = 3;
            this.label_password.Text = "Password:";
            // 
            // textbox_password
            // 
            this.textbox_password.Location = new System.Drawing.Point(6, 71);
            this.textbox_password.Name = "textbox_password";
            this.textbox_password.PasswordChar = '*';
            this.textbox_password.Size = new System.Drawing.Size(105, 20);
            this.textbox_password.TabIndex = 2;
            this.textbox_password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textbox_password_KeyDown);
            // 
            // form_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(141, 176);
            this.Controls.Add(this.groupbox_login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(147, 200);
            this.MinimumSize = new System.Drawing.Size(147, 200);
            this.Name = "form_login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LGHS Voting System";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_login_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupbox_login.ResumeLayout(false);
            this.groupbox_login.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textbox_username;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.GroupBox groupbox_login;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.TextBox textbox_password;
        
    }
}

