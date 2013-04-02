namespace Dresscode
{
    partial class Dresscode
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
            this.groupbox_retrieve = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.combobox_lastname = new System.Windows.Forms.ComboBox();
            this.combobox_firstname = new System.Windows.Forms.ComboBox();
            this.label_nineweeksinfractions = new System.Windows.Forms.Label();
            this.button_retrieve = new System.Windows.Forms.Button();
            this.label_totalinfractions = new System.Windows.Forms.Label();
            this.label_firstname = new System.Windows.Forms.Label();
            this.label_lastname = new System.Windows.Forms.Label();
            this.groupbox_submit = new System.Windows.Forms.GroupBox();
            this.label_period = new System.Windows.Forms.Label();
            this.label_date = new System.Windows.Forms.Label();
            this.label_selecttheinfraction = new System.Windows.Forms.Label();
            this.combobox_period = new System.Windows.Forms.ComboBox();
            this.textbox_details = new System.Windows.Forms.TextBox();
            this.button_submit = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.combobox_infraction = new System.Windows.Forms.ComboBox();
            this.label_teacherid = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupbox_retrieve.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupbox_submit.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupbox_retrieve
            // 
            this.groupbox_retrieve.Controls.Add(this.dataGridView1);
            this.groupbox_retrieve.Controls.Add(this.combobox_lastname);
            this.groupbox_retrieve.Controls.Add(this.combobox_firstname);
            this.groupbox_retrieve.Controls.Add(this.label_nineweeksinfractions);
            this.groupbox_retrieve.Controls.Add(this.button_retrieve);
            this.groupbox_retrieve.Controls.Add(this.label_totalinfractions);
            this.groupbox_retrieve.Controls.Add(this.label_firstname);
            this.groupbox_retrieve.Controls.Add(this.label_lastname);
            this.groupbox_retrieve.Location = new System.Drawing.Point(12, 26);
            this.groupbox_retrieve.Name = "groupbox_retrieve";
            this.groupbox_retrieve.Size = new System.Drawing.Size(419, 232);
            this.groupbox_retrieve.TabIndex = 1;
            this.groupbox_retrieve.TabStop = false;
            this.groupbox_retrieve.Text = "Retrieval";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(407, 151);
            this.dataGridView1.TabIndex = 9;
            // 
            // combobox_lastname
            // 
            this.combobox_lastname.FormattingEnabled = true;
            this.combobox_lastname.Location = new System.Drawing.Point(277, 18);
            this.combobox_lastname.Name = "combobox_lastname";
            this.combobox_lastname.Size = new System.Drawing.Size(136, 21);
            this.combobox_lastname.TabIndex = 2;
            this.combobox_lastname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.combobox_lastname_KeyDown);
            // 
            // combobox_firstname
            // 
            this.combobox_firstname.FormattingEnabled = true;
            this.combobox_firstname.Location = new System.Drawing.Point(76, 19);
            this.combobox_firstname.Name = "combobox_firstname";
            this.combobox_firstname.Size = new System.Drawing.Size(128, 21);
            this.combobox_firstname.TabIndex = 1;
            this.combobox_firstname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.combobox_firstname_KeyDown);
            // 
            // label_nineweeksinfractions
            // 
            this.label_nineweeksinfractions.AutoSize = true;
            this.label_nineweeksinfractions.Location = new System.Drawing.Point(252, 51);
            this.label_nineweeksinfractions.Name = "label_nineweeksinfractions";
            this.label_nineweeksinfractions.Size = new System.Drawing.Size(130, 13);
            this.label_nineweeksinfractions.TabIndex = 17;
            this.label_nineweeksinfractions.Text = "Infractions this 9 weeks: 0";
            // 
            // button_retrieve
            // 
            this.button_retrieve.Location = new System.Drawing.Point(14, 46);
            this.button_retrieve.Name = "button_retrieve";
            this.button_retrieve.Size = new System.Drawing.Size(75, 23);
            this.button_retrieve.TabIndex = 3;
            this.button_retrieve.Text = "Retrieve";
            this.button_retrieve.UseVisualStyleBackColor = true;
            this.button_retrieve.Click += new System.EventHandler(this.button_retrieve_Click);
            // 
            // label_totalinfractions
            // 
            this.label_totalinfractions.AutoSize = true;
            this.label_totalinfractions.Location = new System.Drawing.Point(111, 51);
            this.label_totalinfractions.Name = "label_totalinfractions";
            this.label_totalinfractions.Size = new System.Drawing.Size(95, 13);
            this.label_totalinfractions.TabIndex = 16;
            this.label_totalinfractions.Text = "Total Infractions: 0";
            // 
            // label_firstname
            // 
            this.label_firstname.AutoSize = true;
            this.label_firstname.Location = new System.Drawing.Point(10, 23);
            this.label_firstname.Name = "label_firstname";
            this.label_firstname.Size = new System.Drawing.Size(60, 13);
            this.label_firstname.TabIndex = 7;
            this.label_firstname.Text = "First Name:";
            // 
            // label_lastname
            // 
            this.label_lastname.AutoSize = true;
            this.label_lastname.Location = new System.Drawing.Point(210, 23);
            this.label_lastname.Name = "label_lastname";
            this.label_lastname.Size = new System.Drawing.Size(61, 13);
            this.label_lastname.TabIndex = 2;
            this.label_lastname.Text = "Last Name:";
            // 
            // groupbox_submit
            // 
            this.groupbox_submit.Controls.Add(this.label_period);
            this.groupbox_submit.Controls.Add(this.label_date);
            this.groupbox_submit.Controls.Add(this.label_selecttheinfraction);
            this.groupbox_submit.Controls.Add(this.combobox_period);
            this.groupbox_submit.Controls.Add(this.textbox_details);
            this.groupbox_submit.Controls.Add(this.button_submit);
            this.groupbox_submit.Controls.Add(this.button_clear);
            this.groupbox_submit.Controls.Add(this.combobox_infraction);
            this.groupbox_submit.Controls.Add(this.label_teacherid);
            this.groupbox_submit.Location = new System.Drawing.Point(12, 264);
            this.groupbox_submit.Name = "groupbox_submit";
            this.groupbox_submit.Size = new System.Drawing.Size(419, 187);
            this.groupbox_submit.TabIndex = 13;
            this.groupbox_submit.TabStop = false;
            this.groupbox_submit.Text = "Submission";
            // 
            // label_period
            // 
            this.label_period.AutoSize = true;
            this.label_period.Location = new System.Drawing.Point(104, 37);
            this.label_period.Name = "label_period";
            this.label_period.Size = new System.Drawing.Size(40, 13);
            this.label_period.TabIndex = 13;
            this.label_period.Text = "Period:";
            // 
            // label_date
            // 
            this.label_date.AutoSize = true;
            this.label_date.Location = new System.Drawing.Point(3, 40);
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(36, 13);
            this.label_date.TabIndex = 12;
            this.label_date.Text = "Date: ";
            // 
            // label_selecttheinfraction
            // 
            this.label_selecttheinfraction.AutoSize = true;
            this.label_selecttheinfraction.Location = new System.Drawing.Point(254, 18);
            this.label_selecttheinfraction.Name = "label_selecttheinfraction";
            this.label_selecttheinfraction.Size = new System.Drawing.Size(109, 13);
            this.label_selecttheinfraction.TabIndex = 11;
            this.label_selecttheinfraction.Text = "Select The Infraction:";
            // 
            // combobox_period
            // 
            this.combobox_period.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_period.FormattingEnabled = true;
            this.combobox_period.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.combobox_period.Location = new System.Drawing.Point(150, 32);
            this.combobox_period.Name = "combobox_period";
            this.combobox_period.Size = new System.Drawing.Size(34, 21);
            this.combobox_period.TabIndex = 4;
            // 
            // textbox_details
            // 
            this.textbox_details.Location = new System.Drawing.Point(6, 72);
            this.textbox_details.Multiline = true;
            this.textbox_details.Name = "textbox_details";
            this.textbox_details.Size = new System.Drawing.Size(407, 80);
            this.textbox_details.TabIndex = 6;
            this.textbox_details.Text = "Details";
            this.textbox_details.Click += new System.EventHandler(this.textbox_details_Click);
            this.textbox_details.TextChanged += new System.EventHandler(this.textbox_details_TextChanged);
            this.textbox_details.Leave += new System.EventHandler(this.textbox_details_Leave);
            // 
            // button_submit
            // 
            this.button_submit.Location = new System.Drawing.Point(6, 158);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(161, 23);
            this.button_submit.TabIndex = 7;
            this.button_submit.Text = "Submit";
            this.button_submit.UseVisualStyleBackColor = true;
            this.button_submit.Click += new System.EventHandler(this.button_submit_Click);
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(255, 158);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(158, 23);
            this.button_clear.TabIndex = 8;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // combobox_infraction
            // 
            this.combobox_infraction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_infraction.FormattingEnabled = true;
            this.combobox_infraction.Location = new System.Drawing.Point(213, 34);
            this.combobox_infraction.Name = "combobox_infraction";
            this.combobox_infraction.Size = new System.Drawing.Size(181, 21);
            this.combobox_infraction.TabIndex = 5;
            // 
            // label_teacherid
            // 
            this.label_teacherid.AutoSize = true;
            this.label_teacherid.Location = new System.Drawing.Point(3, 24);
            this.label_teacherid.Name = "label_teacherid";
            this.label_teacherid.Size = new System.Drawing.Size(67, 13);
            this.label_teacherid.TabIndex = 1;
            this.label_teacherid.Text = "Teacher ID: ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(443, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            this.reportsToolStripMenuItem.Click += new System.EventHandler(this.reportsToolStripMenuItem_Click);
            // 
            // Teacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 463);
            this.Controls.Add(this.groupbox_submit);
            this.Controls.Add(this.groupbox_retrieve);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Teacher";
            this.Text = "Dress Code";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_dresscode_FormClosed);
            this.Load += new System.EventHandler(this.form_dresscode_Load);
            this.groupbox_retrieve.ResumeLayout(false);
            this.groupbox_retrieve.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupbox_submit.ResumeLayout(false);
            this.groupbox_submit.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupbox_retrieve;
        private System.Windows.Forms.GroupBox groupbox_submit;
        private System.Windows.Forms.Button button_submit;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.ComboBox combobox_infraction;
        private System.Windows.Forms.Label label_lastname;
        private System.Windows.Forms.Label label_nineweeksinfractions;
        private System.Windows.Forms.Label label_totalinfractions;
        private System.Windows.Forms.TextBox textbox_details;
        private System.Windows.Forms.Label label_firstname;
        private System.Windows.Forms.Button button_retrieve;
        private System.Windows.Forms.ComboBox combobox_period;
        private System.Windows.Forms.ComboBox combobox_firstname;
        private System.Windows.Forms.ComboBox combobox_lastname;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.Label label_teacherid;
        public bool admin;
        public string teacherfirstname;
        public string teacherlastname;
        public string teacherid;
        private System.Windows.Forms.Label label_selecttheinfraction;
        private System.Windows.Forms.Label label_date;
        private System.Windows.Forms.Label label_period;
        private System.Windows.Forms.DataGridView dataGridView1;
        
    }
}

