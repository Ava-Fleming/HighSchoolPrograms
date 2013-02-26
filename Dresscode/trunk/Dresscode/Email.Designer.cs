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
            this.textBox_console = new System.Windows.Forms.TextBox();
            this.listBox_emails = new System.Windows.Forms.ListBox();
            this.button_add_email = new System.Windows.Forms.Button();
            this.button_remove_email = new System.Windows.Forms.Button();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_main = new System.Windows.Forms.TabPage();
            this.tabPage_console = new System.Windows.Forms.TabPage();
            this.groupBox_emailing_list = new System.Windows.Forms.GroupBox();
            this.textBox_add_email = new System.Windows.Forms.TextBox();
            this.button_save_console = new System.Windows.Forms.Button();
            this.button_clear_console = new System.Windows.Forms.Button();
            this.groupBox_settings = new System.Windows.Forms.GroupBox();
            this.numericUpDown_hours = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_minutes = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_edit_settings = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_host_email = new System.Windows.Forms.TextBox();
            this.tabControl_main.SuspendLayout();
            this.tabPage_main.SuspendLayout();
            this.tabPage_console.SuspendLayout();
            this.groupBox_emailing_list.SuspendLayout();
            this.groupBox_settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_minutes)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_console
            // 
            this.textBox_console.Location = new System.Drawing.Point(6, 6);
            this.textBox_console.Multiline = true;
            this.textBox_console.Name = "textBox_console";
            this.textBox_console.Size = new System.Drawing.Size(423, 355);
            this.textBox_console.TabIndex = 0;
            // 
            // listBox_emails
            // 
            this.listBox_emails.FormattingEnabled = true;
            this.listBox_emails.Location = new System.Drawing.Point(6, 46);
            this.listBox_emails.Name = "listBox_emails";
            this.listBox_emails.Size = new System.Drawing.Size(330, 108);
            this.listBox_emails.TabIndex = 1;
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
            this.button_remove_email.TabIndex = 3;
            this.button_remove_email.Text = "Remove Email";
            this.button_remove_email.UseVisualStyleBackColor = true;
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage_main);
            this.tabControl_main.Controls.Add(this.tabPage_console);
            this.tabControl_main.Location = new System.Drawing.Point(2, 2);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(446, 422);
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
            this.tabPage_main.Size = new System.Drawing.Size(438, 396);
            this.tabPage_main.TabIndex = 0;
            this.tabPage_main.Text = "Main";
            this.tabPage_main.UseVisualStyleBackColor = true;
            // 
            // tabPage_console
            // 
            this.tabPage_console.Controls.Add(this.button_clear_console);
            this.tabPage_console.Controls.Add(this.button_save_console);
            this.tabPage_console.Controls.Add(this.textBox_console);
            this.tabPage_console.Location = new System.Drawing.Point(4, 22);
            this.tabPage_console.Name = "tabPage_console";
            this.tabPage_console.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_console.Size = new System.Drawing.Size(438, 396);
            this.tabPage_console.TabIndex = 1;
            this.tabPage_console.Text = "Output Console";
            this.tabPage_console.UseVisualStyleBackColor = true;
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
            this.textBox_add_email.TabIndex = 4;
            // 
            // button_save_console
            // 
            this.button_save_console.Location = new System.Drawing.Point(6, 367);
            this.button_save_console.Name = "button_save_console";
            this.button_save_console.Size = new System.Drawing.Size(101, 23);
            this.button_save_console.TabIndex = 1;
            this.button_save_console.Text = "Export to Text";
            this.button_save_console.UseVisualStyleBackColor = true;
            // 
            // button_clear_console
            // 
            this.button_clear_console.Location = new System.Drawing.Point(354, 367);
            this.button_clear_console.Name = "button_clear_console";
            this.button_clear_console.Size = new System.Drawing.Size(75, 23);
            this.button_clear_console.TabIndex = 2;
            this.button_clear_console.Text = "Clear";
            this.button_clear_console.UseVisualStyleBackColor = true;
            // 
            // groupBox_settings
            // 
            this.groupBox_settings.Controls.Add(this.label5);
            this.groupBox_settings.Controls.Add(this.textBox_host_email);
            this.groupBox_settings.Controls.Add(this.button_edit_settings);
            this.groupBox_settings.Controls.Add(this.label4);
            this.groupBox_settings.Controls.Add(this.textBox1);
            this.groupBox_settings.Controls.Add(this.label3);
            this.groupBox_settings.Controls.Add(this.label2);
            this.groupBox_settings.Controls.Add(this.label1);
            this.groupBox_settings.Controls.Add(this.numericUpDown_minutes);
            this.groupBox_settings.Controls.Add(this.numericUpDown_hours);
            this.groupBox_settings.Location = new System.Drawing.Point(7, 183);
            this.groupBox_settings.Name = "groupBox_settings";
            this.groupBox_settings.Size = new System.Drawing.Size(425, 178);
            this.groupBox_settings.TabIndex = 5;
            this.groupBox_settings.TabStop = false;
            this.groupBox_settings.Text = "Settings";
            // 
            // numericUpDown_hours
            // 
            this.numericUpDown_hours.Location = new System.Drawing.Point(76, 33);
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
            this.numericUpDown_hours.TabIndex = 0;
            this.numericUpDown_hours.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_minutes
            // 
            this.numericUpDown_minutes.Location = new System.Drawing.Point(127, 33);
            this.numericUpDown_minutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_minutes.Name = "numericUpDown_minutes";
            this.numericUpDown_minutes.Size = new System.Drawing.Size(56, 20);
            this.numericUpDown_minutes.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Send Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hour";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Minute";
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(112, 367);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 6;
            this.button_start.Text = "Start Task";
            this.button_start.UseVisualStyleBackColor = true;
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(229, 367);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(75, 23);
            this.button_stop.TabIndex = 7;
            this.button_stop.Text = "Stop Task";
            this.button_stop.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(89, 88);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(327, 20);
            this.textBox1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Email Subject:";
            // 
            // button_edit_settings
            // 
            this.button_edit_settings.Location = new System.Drawing.Point(344, 14);
            this.button_edit_settings.Name = "button_edit_settings";
            this.button_edit_settings.Size = new System.Drawing.Size(75, 23);
            this.button_edit_settings.TabIndex = 7;
            this.button_edit_settings.Text = "Edit Settings";
            this.button_edit_settings.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Host Email:";
            // 
            // textBox_host_email
            // 
            this.textBox_host_email.Location = new System.Drawing.Point(89, 59);
            this.textBox_host_email.Name = "textBox_host_email";
            this.textBox_host_email.Size = new System.Drawing.Size(327, 20);
            this.textBox_host_email.TabIndex = 8;
            // 
            // Email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 426);
            this.Controls.Add(this.tabControl_main);
            this.Name = "Email";
            this.Text = "Email";
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_main.ResumeLayout(false);
            this.tabPage_console.ResumeLayout(false);
            this.tabPage_console.PerformLayout();
            this.groupBox_emailing_list.ResumeLayout(false);
            this.groupBox_emailing_list.PerformLayout();
            this.groupBox_settings.ResumeLayout(false);
            this.groupBox_settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_minutes)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_minutes;
        private System.Windows.Forms.NumericUpDown numericUpDown_hours;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_host_email;
        private System.Windows.Forms.Button button_edit_settings;
    }
}