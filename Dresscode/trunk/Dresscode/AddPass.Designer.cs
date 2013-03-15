namespace Dresscode
{
    partial class AddPass
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
            this.label_email = new System.Windows.Forms.Label();
            this.button_saveemail = new System.Windows.Forms.Button();
            this.textbox_email = new System.Windows.Forms.TextBox();
            this.label_notification = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Location = new System.Drawing.Point(0, 54);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(35, 13);
            this.label_email.TabIndex = 0;
            this.label_email.Text = "Email:";
            // 
            // button_saveemail
            // 
            this.button_saveemail.Location = new System.Drawing.Point(111, 77);
            this.button_saveemail.Name = "button_saveemail";
            this.button_saveemail.Size = new System.Drawing.Size(88, 23);
            this.button_saveemail.TabIndex = 1;
            this.button_saveemail.Text = "Save";
            this.button_saveemail.UseVisualStyleBackColor = true;
            this.button_saveemail.Click += new System.EventHandler(this.button_saveemail_Click);
            // 
            // textbox_email
            // 
            this.textbox_email.Location = new System.Drawing.Point(41, 51);
            this.textbox_email.Name = "textbox_email";
            this.textbox_email.Size = new System.Drawing.Size(247, 20);
            this.textbox_email.TabIndex = 2;
            // 
            // label_notification
            // 
            this.label_notification.AutoSize = true;
            this.label_notification.Location = new System.Drawing.Point(12, 9);
            this.label_notification.Name = "label_notification";
            this.label_notification.Size = new System.Drawing.Size(284, 26);
            this.label_notification.TabIndex = 3;
            this.label_notification.Text = "We do not have an email for you on record. Please\r\nenter a working email to conti" +
    "nue changing your password.";
            // 
            // AddPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 107);
            this.Controls.Add(this.label_notification);
            this.Controls.Add(this.textbox_email);
            this.Controls.Add(this.button_saveemail);
            this.Controls.Add(this.label_email);
            this.Name = "AddPass";
            this.Text = "AddPass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.Button button_saveemail;
        private System.Windows.Forms.TextBox textbox_email;
        private System.Windows.Forms.Label label_notification;
        public string teacherid;
        public string email;
    }
}