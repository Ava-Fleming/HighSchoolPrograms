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
            this.button_login_click = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textbox_teacherid
            // 
            this.textbox_teacherid.Location = new System.Drawing.Point(12, 25);
            this.textbox_teacherid.Name = "textbox_teacherid";
            this.textbox_teacherid.Size = new System.Drawing.Size(135, 20);
            this.textbox_teacherid.TabIndex = 0;
            this.textbox_teacherid.Text = "000";
            // 
            // textbox_password
            // 
            this.textbox_password.Location = new System.Drawing.Point(12, 64);
            this.textbox_password.Name = "textbox_password";
            this.textbox_password.PasswordChar = '*';
            this.textbox_password.Size = new System.Drawing.Size(135, 20);
            this.textbox_password.TabIndex = 1;
            this.textbox_password.Text = "1234";
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
            // button_login_click
            // 
            this.button_login_click.Location = new System.Drawing.Point(12, 90);
            this.button_login_click.Name = "button_login_click";
            this.button_login_click.Size = new System.Drawing.Size(135, 40);
            this.button_login_click.TabIndex = 4;
            this.button_login_click.Text = "Login";
            this.button_login_click.UseVisualStyleBackColor = true;
            this.button_login_click.Click += new System.EventHandler(this.button_login_click_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(159, 142);
            this.Controls.Add(this.button_login_click);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.label_user);
            this.Controls.Add(this.textbox_password);
            this.Controls.Add(this.textbox_teacherid);
            this.Name = "Login";
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textbox_teacherid;
        private System.Windows.Forms.TextBox textbox_password;
        private System.Windows.Forms.Label label_user;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.Button button_login_click;
    }
}