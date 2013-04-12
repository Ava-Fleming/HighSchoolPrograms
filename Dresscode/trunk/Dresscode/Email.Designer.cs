namespace Dresscode
{
    partial class Email
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
            this.components = new System.ComponentModel.Container();
            this.textBox_console = new System.Windows.Forms.TextBox();
            this.listBox_emails = new System.Windows.Forms.ListBox();
            this.button_add_email = new System.Windows.Forms.Button();
            this.button_remove_email = new System.Windows.Forms.Button();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_main = new System.Windows.Forms.TabPage();
            this.button_stop = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.groupBox_settings = new System.Windows.Forms.GroupBox();
            this.checkbox_deleteexcel = new System.Windows.Forms.CheckBox();
            this.checkbox_showpassword = new System.Windows.Forms.CheckBox();
            this.label_smtpserver = new System.Windows.Forms.Label();
            this.textBox_smtp = new System.Windows.Forms.TextBox();
            this.label_hostpassword = new System.Windows.Forms.Label();
            this.textBox_email_password = new System.Windows.Forms.TextBox();
            this.label_emailbody = new System.Windows.Forms.Label();
            this.textBox_email_body = new System.Windows.Forms.TextBox();
            this.numericUpDown_port = new System.Windows.Forms.NumericUpDown();
            this.label_port = new System.Windows.Forms.Label();
            this.label_hostemail = new System.Windows.Forms.Label();
            this.textBox_host_email = new System.Windows.Forms.TextBox();
            this.button_edit_settings = new System.Windows.Forms.Button();
            this.label_emailsubject = new System.Windows.Forms.Label();
            this.textBox_email_subject = new System.Windows.Forms.TextBox();
            this.label_minute = new System.Windows.Forms.Label();
            this.label_hour = new System.Windows.Forms.Label();
            this.label_sendtime = new System.Windows.Forms.Label();
            this.numericUpDown_minutes = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_hours = new System.Windows.Forms.NumericUpDown();
            this.groupBox_emailing_list = new System.Windows.Forms.GroupBox();
            this.textBox_add_email = new System.Windows.Forms.TextBox();
            this.tabPage_console = new System.Windows.Forms.TabPage();
            this.button_clear_console = new System.Windows.Forms.Button();
            this.button_save_console = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl_main.SuspendLayout();
            this.tabPage_main.SuspendLayout();
            this.groupBox_settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_port)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_minutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hours)).BeginInit();
            this.groupBox_emailing_list.SuspendLayout();
            this.tabPage_console.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_console
            // 
            this.textBox_console.Location = new System.Drawing.Point(6, 6);
            this.textBox_console.Multiline = true;
            this.textBox_console.Name = "textBox_console";
            this.textBox_console.ReadOnly = true;
            this.textBox_console.Size = new System.Drawing.Size(423, 397);
            this.textBox_console.TabIndex = 0;
            // 
            // listBox_emails
            // 
            this.listBox_emails.FormattingEnabled = true;
            this.listBox_emails.Location = new System.Drawing.Point(6, 46);
            this.listBox_emails.Name = "listBox_emails";
            this.listBox_emails.Size = new System.Drawing.Size(330, 108);
            this.listBox_emails.TabIndex = 3;
            // 
            // button_add_email
            // 
            this.button_add_email.Location = new System.Drawing.Point(342, 20);
            this.button_add_email.Name = "button_add_email";
            this.button_add_email.Size = new System.Drawing.Size(75, 23);
            this.button_add_email.TabIndex = 2;
            this.button_add_email.Text = "Add Email";
            this.button_add_email.UseVisualStyleBackColor = true;
            this.button_add_email.Click += new System.EventHandler(this.button_add_email_Click);
            // 
            // button_remove_email
            // 
            this.button_remove_email.Location = new System.Drawing.Point(342, 85);
            this.button_remove_email.Name = "button_remove_email";
            this.button_remove_email.Size = new System.Drawing.Size(75, 40);
            this.button_remove_email.TabIndex = 4;
            this.button_remove_email.Text = "Remove Email";
            this.button_remove_email.UseVisualStyleBackColor = true;
            this.button_remove_email.Click += new System.EventHandler(this.button_remove_email_Click);
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage_main);
            this.tabControl_main.Controls.Add(this.tabPage_console);
            this.tabControl_main.Location = new System.Drawing.Point(2, 2);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(446, 491);
            this.tabControl_main.TabIndex = 4;
            // 
            // tabPage_main
            // 
            this.tabPage_main.Controls.Add(this.button_stop);
            this.tabPage_main.Controls.Add(this.button_start);
            this.tabPage_main.Controls.Add(this.groupBox_settings);
            this.tabPage_main.Controls.Add(this.groupBox_emailing_list);
            this.tabPage_main.Location = new System.Drawing.Point(4, 22);
            this.tabPage_main.Name = "tabPage_main";
            this.tabPage_main.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_main.Size = new System.Drawing.Size(438, 465);
            this.tabPage_main.TabIndex = 0;
            this.tabPage_main.Text = "Main";
            this.tabPage_main.UseVisualStyleBackColor = true;
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(236, 434);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(75, 23);
            this.button_stop.TabIndex = 16;
            this.button_stop.Text = "Stop Task";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(119, 434);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 15;
            this.button_start.Text = "Start Task";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // groupBox_settings
            // 
            this.groupBox_settings.Controls.Add(this.checkbox_deleteexcel);
            this.groupBox_settings.Controls.Add(this.checkbox_showpassword);
            this.groupBox_settings.Controls.Add(this.label_smtpserver);
            this.groupBox_settings.Controls.Add(this.textBox_smtp);
            this.groupBox_settings.Controls.Add(this.label_hostpassword);
            this.groupBox_settings.Controls.Add(this.textBox_email_password);
            this.groupBox_settings.Controls.Add(this.label_emailbody);
            this.groupBox_settings.Controls.Add(this.textBox_email_body);
            this.groupBox_settings.Controls.Add(this.numericUpDown_port);
            this.groupBox_settings.Controls.Add(this.label_port);
            this.groupBox_settings.Controls.Add(this.label_hostemail);
            this.groupBox_settings.Controls.Add(this.textBox_host_email);
            this.groupBox_settings.Controls.Add(this.button_edit_settings);
            this.groupBox_settings.Controls.Add(this.label_emailsubject);
            this.groupBox_settings.Controls.Add(this.textBox_email_subject);
            this.groupBox_settings.Controls.Add(this.label_minute);
            this.groupBox_settings.Controls.Add(this.label_hour);
            this.groupBox_settings.Controls.Add(this.label_sendtime);
            this.groupBox_settings.Controls.Add(this.numericUpDown_minutes);
            this.groupBox_settings.Controls.Add(this.numericUpDown_hours);
            this.groupBox_settings.Location = new System.Drawing.Point(7, 183);
            this.groupBox_settings.Name = "groupBox_settings";
            this.groupBox_settings.Size = new System.Drawing.Size(425, 245);
            this.groupBox_settings.TabIndex = 5;
            this.groupBox_settings.TabStop = false;
            this.groupBox_settings.Text = "Settings";
            // 
            // checkbox_deleteexcel
            // 
            this.checkbox_deleteexcel.AutoSize = true;
            this.checkbox_deleteexcel.Enabled = false;
            this.checkbox_deleteexcel.Location = new System.Drawing.Point(6, 216);
            this.checkbox_deleteexcel.Name = "checkbox_deleteexcel";
            this.checkbox_deleteexcel.Size = new System.Drawing.Size(151, 17);
            this.checkbox_deleteexcel.TabIndex = 17;
            this.checkbox_deleteexcel.Text = "Delete report after sending";
            this.checkbox_deleteexcel.UseVisualStyleBackColor = true;
            // 
            // checkbox_showpassword
            // 
            this.checkbox_showpassword.AutoSize = true;
            this.checkbox_showpassword.Enabled = false;
            this.checkbox_showpassword.Location = new System.Drawing.Point(362, 141);
            this.checkbox_showpassword.Name = "checkbox_showpassword";
            this.checkbox_showpassword.Size = new System.Drawing.Size(53, 17);
            this.checkbox_showpassword.TabIndex = 12;
            this.checkbox_showpassword.Text = "Show";
            this.checkbox_showpassword.UseVisualStyleBackColor = true;
            this.checkbox_showpassword.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label_smtpserver
            // 
            this.label_smtpserver.AutoSize = true;
            this.label_smtpserver.Location = new System.Drawing.Point(10, 63);
            this.label_smtpserver.Name = "label_smtpserver";
            this.label_smtpserver.Size = new System.Drawing.Size(72, 13);
            this.label_smtpserver.TabIndex = 18;
            this.label_smtpserver.Text = "SMTP server:";
            // 
            // textBox_smtp
            // 
            this.textBox_smtp.Enabled = false;
            this.textBox_smtp.Location = new System.Drawing.Point(88, 60);
            this.textBox_smtp.Name = "textBox_smtp";
            this.textBox_smtp.Size = new System.Drawing.Size(327, 20);
            this.textBox_smtp.TabIndex = 8;
            // 
            // label_hostpassword
            // 
            this.label_hostpassword.AutoSize = true;
            this.label_hostpassword.Location = new System.Drawing.Point(1, 141);
            this.label_hostpassword.Name = "label_hostpassword";
            this.label_hostpassword.Size = new System.Drawing.Size(81, 13);
            this.label_hostpassword.TabIndex = 16;
            this.label_hostpassword.Text = "Host Password:";
            // 
            // textBox_email_password
            // 
            this.textBox_email_password.Enabled = false;
            this.textBox_email_password.Location = new System.Drawing.Point(88, 138);
            this.textBox_email_password.Name = "textBox_email_password";
            this.textBox_email_password.PasswordChar = '*';
            this.textBox_email_password.Size = new System.Drawing.Size(268, 20);
            this.textBox_email_password.TabIndex = 11;
            // 
            // label_emailbody
            // 
            this.label_emailbody.AutoSize = true;
            this.label_emailbody.Location = new System.Drawing.Point(21, 193);
            this.label_emailbody.Name = "label_emailbody";
            this.label_emailbody.Size = new System.Drawing.Size(62, 13);
            this.label_emailbody.TabIndex = 14;
            this.label_emailbody.Text = "Email Body:";
            // 
            // textBox_email_body
            // 
            this.textBox_email_body.Enabled = false;
            this.textBox_email_body.Location = new System.Drawing.Point(89, 190);
            this.textBox_email_body.Name = "textBox_email_body";
            this.textBox_email_body.Size = new System.Drawing.Size(327, 20);
            this.textBox_email_body.TabIndex = 14;
            // 
            // numericUpDown_port
            // 
            this.numericUpDown_port.Enabled = false;
            this.numericUpDown_port.Location = new System.Drawing.Point(88, 86);
            this.numericUpDown_port.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown_port.Name = "numericUpDown_port";
            this.numericUpDown_port.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_port.TabIndex = 9;
            this.numericUpDown_port.Value = new decimal(new int[] {
            26,
            0,
            0,
            0});
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Location = new System.Drawing.Point(53, 88);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(29, 13);
            this.label_port.TabIndex = 11;
            this.label_port.Text = "Port:";
            // 
            // label_hostemail
            // 
            this.label_hostemail.AutoSize = true;
            this.label_hostemail.Location = new System.Drawing.Point(23, 115);
            this.label_hostemail.Name = "label_hostemail";
            this.label_hostemail.Size = new System.Drawing.Size(60, 13);
            this.label_hostemail.TabIndex = 9;
            this.label_hostemail.Text = "Host Email:";
            // 
            // textBox_host_email
            // 
            this.textBox_host_email.Enabled = false;
            this.textBox_host_email.Location = new System.Drawing.Point(89, 112);
            this.textBox_host_email.Name = "textBox_host_email";
            this.textBox_host_email.Size = new System.Drawing.Size(327, 20);
            this.textBox_host_email.TabIndex = 10;
            // 
            // button_edit_settings
            // 
            this.button_edit_settings.Location = new System.Drawing.Point(344, 14);
            this.button_edit_settings.Name = "button_edit_settings";
            this.button_edit_settings.Size = new System.Drawing.Size(75, 23);
            this.button_edit_settings.TabIndex = 5;
            this.button_edit_settings.Text = "Edit Settings";
            this.button_edit_settings.UseVisualStyleBackColor = true;
            this.button_edit_settings.Click += new System.EventHandler(this.button_edit_settings_Click);
            // 
            // label_emailsubject
            // 
            this.label_emailsubject.AutoSize = true;
            this.label_emailsubject.Location = new System.Drawing.Point(9, 167);
            this.label_emailsubject.Name = "label_emailsubject";
            this.label_emailsubject.Size = new System.Drawing.Size(74, 13);
            this.label_emailsubject.TabIndex = 6;
            this.label_emailsubject.Text = "Email Subject:";
            // 
            // textBox_email_subject
            // 
            this.textBox_email_subject.Enabled = false;
            this.textBox_email_subject.Location = new System.Drawing.Point(89, 164);
            this.textBox_email_subject.Name = "textBox_email_subject";
            this.textBox_email_subject.Size = new System.Drawing.Size(327, 20);
            this.textBox_email_subject.TabIndex = 13;
            // 
            // label_minute
            // 
            this.label_minute.AutoSize = true;
            this.label_minute.Location = new System.Drawing.Point(137, 14);
            this.label_minute.Name = "label_minute";
            this.label_minute.Size = new System.Drawing.Size(39, 13);
            this.label_minute.TabIndex = 4;
            this.label_minute.Text = "Minute";
            // 
            // label_hour
            // 
            this.label_hour.AutoSize = true;
            this.label_hour.Location = new System.Drawing.Point(90, 14);
            this.label_hour.Name = "label_hour";
            this.label_hour.Size = new System.Drawing.Size(30, 13);
            this.label_hour.TabIndex = 3;
            this.label_hour.Text = "Hour";
            // 
            // label_sendtime
            // 
            this.label_sendtime.AutoSize = true;
            this.label_sendtime.Location = new System.Drawing.Point(22, 35);
            this.label_sendtime.Name = "label_sendtime";
            this.label_sendtime.Size = new System.Drawing.Size(61, 13);
            this.label_sendtime.TabIndex = 2;
            this.label_sendtime.Text = "Send Time:";
            // 
            // numericUpDown_minutes
            // 
            this.numericUpDown_minutes.Enabled = false;
            this.numericUpDown_minutes.Location = new System.Drawing.Point(140, 33);
            this.numericUpDown_minutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_minutes.Name = "numericUpDown_minutes";
            this.numericUpDown_minutes.Size = new System.Drawing.Size(56, 20);
            this.numericUpDown_minutes.TabIndex = 7;
            this.numericUpDown_minutes.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // numericUpDown_hours
            // 
            this.numericUpDown_hours.Enabled = false;
            this.numericUpDown_hours.Location = new System.Drawing.Point(89, 33);
            this.numericUpDown_hours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDown_hours.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_hours.Name = "numericUpDown_hours";
            this.numericUpDown_hours.Size = new System.Drawing.Size(45, 20);
            this.numericUpDown_hours.TabIndex = 6;
            this.numericUpDown_hours.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            // 
            // groupBox_emailing_list
            // 
            this.groupBox_emailing_list.Controls.Add(this.textBox_add_email);
            this.groupBox_emailing_list.Controls.Add(this.listBox_emails);
            this.groupBox_emailing_list.Controls.Add(this.button_add_email);
            this.groupBox_emailing_list.Controls.Add(this.button_remove_email);
            this.groupBox_emailing_list.Location = new System.Drawing.Point(6, 6);
            this.groupBox_emailing_list.Name = "groupBox_emailing_list";
            this.groupBox_emailing_list.Size = new System.Drawing.Size(423, 170);
            this.groupBox_emailing_list.TabIndex = 4;
            this.groupBox_emailing_list.TabStop = false;
            this.groupBox_emailing_list.Text = "Recipients";
            // 
            // textBox_add_email
            // 
            this.textBox_add_email.Location = new System.Drawing.Point(6, 20);
            this.textBox_add_email.Name = "textBox_add_email";
            this.textBox_add_email.Size = new System.Drawing.Size(330, 20);
            this.textBox_add_email.TabIndex = 1;
            this.textBox_add_email.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_add_email_KeyDown);
            // 
            // tabPage_console
            // 
            this.tabPage_console.Controls.Add(this.button_clear_console);
            this.tabPage_console.Controls.Add(this.button_save_console);
            this.tabPage_console.Controls.Add(this.textBox_console);
            this.tabPage_console.Location = new System.Drawing.Point(4, 22);
            this.tabPage_console.Name = "tabPage_console";
            this.tabPage_console.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_console.Size = new System.Drawing.Size(438, 465);
            this.tabPage_console.TabIndex = 1;
            this.tabPage_console.Text = "Output Console";
            this.tabPage_console.UseVisualStyleBackColor = true;
            // 
            // button_clear_console
            // 
            this.button_clear_console.Location = new System.Drawing.Point(357, 409);
            this.button_clear_console.Name = "button_clear_console";
            this.button_clear_console.Size = new System.Drawing.Size(75, 23);
            this.button_clear_console.TabIndex = 2;
            this.button_clear_console.Text = "Clear";
            this.button_clear_console.UseVisualStyleBackColor = true;
            this.button_clear_console.Click += new System.EventHandler(this.button_clear_console_Click);
            // 
            // button_save_console
            // 
            this.button_save_console.Location = new System.Drawing.Point(6, 409);
            this.button_save_console.Name = "button_save_console";
            this.button_save_console.Size = new System.Drawing.Size(101, 23);
            this.button_save_console.TabIndex = 1;
            this.button_save_console.Text = "Export to Text";
            this.button_save_console.UseVisualStyleBackColor = true;
            this.button_save_console.Click += new System.EventHandler(this.button_save_console_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(450, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(442, 468);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(447, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Report Data Preview:";
            // 
            // Email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 493);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tabControl_main);
            this.Name = "Email";
            this.Text = "Email";
            this.Load += new System.EventHandler(this.Email_Load);
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_main.ResumeLayout(false);
            this.groupBox_settings.ResumeLayout(false);
            this.groupBox_settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_port)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_minutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hours)).EndInit();
            this.groupBox_emailing_list.ResumeLayout(false);
            this.groupBox_emailing_list.PerformLayout();
            this.tabPage_console.ResumeLayout(false);
            this.tabPage_console.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_console;
        private System.Windows.Forms.ListBox listBox_emails;
        private System.Windows.Forms.Button button_add_email;
        private System.Windows.Forms.Button button_remove_email;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_main;
        private System.Windows.Forms.GroupBox groupBox_settings;
        private System.Windows.Forms.GroupBox groupBox_emailing_list;
        private System.Windows.Forms.TextBox textBox_add_email;
        private System.Windows.Forms.TabPage tabPage_console;
        private System.Windows.Forms.Button button_clear_console;
        private System.Windows.Forms.Button button_save_console;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Label label_emailsubject;
        private System.Windows.Forms.TextBox textBox_email_subject;
        private System.Windows.Forms.Label label_minute;
        private System.Windows.Forms.Label label_hour;
        private System.Windows.Forms.Label label_sendtime;
        private System.Windows.Forms.NumericUpDown numericUpDown_minutes;
        private System.Windows.Forms.NumericUpDown numericUpDown_hours;
        private System.Windows.Forms.Label label_hostemail;
        private System.Windows.Forms.TextBox textBox_host_email;
        private System.Windows.Forms.Button button_edit_settings;
        private System.Windows.Forms.NumericUpDown numericUpDown_port;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.Label label_emailbody;
        private System.Windows.Forms.TextBox textBox_email_body;
        private System.Windows.Forms.Label label_smtpserver;
        private System.Windows.Forms.TextBox textBox_smtp;
        private System.Windows.Forms.Label label_hostpassword;
        private System.Windows.Forms.TextBox textBox_email_password;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkbox_showpassword;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkbox_deleteexcel;
    }
}