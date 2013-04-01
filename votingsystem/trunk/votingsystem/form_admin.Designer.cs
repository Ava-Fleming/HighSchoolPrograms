namespace votingsystem
{
    partial class form_admin
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
            this.numericupdown_allowedvotes = new System.Windows.Forms.NumericUpDown();
            this.label_allowedvotes = new System.Windows.Forms.Label();
            this.button_addcandidate = new System.Windows.Forms.Button();
            this.textbox_addcandidate = new System.Windows.Forms.TextBox();
            this.button_resetvoters = new System.Windows.Forms.Button();
            this.button_removecandidate = new System.Windows.Forms.Button();
            this.listview_candiates = new System.Windows.Forms.ListView();
            this.ch_candidate_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_candidate_votes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_gender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.groupbox_candidateeditor = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button_liverefresh = new System.Windows.Forms.Button();
            this.button_refreshcandidates = new System.Windows.Forms.Button();
            this.groupbox_miscsettings = new System.Windows.Forms.GroupBox();
            this.button_resetcandidatevotes = new System.Windows.Forms.Button();
            this.combobox_liverefreshinterval = new System.Windows.Forms.ComboBox();
            this.label_liverefreshinterval = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupbox_votermonitor = new System.Windows.Forms.GroupBox();
            this.button_refreshvoters = new System.Windows.Forms.Button();
            this.label_notvoted = new System.Windows.Forms.Label();
            this.listview_voters = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.numericupdown_allowedvotes)).BeginInit();
            this.groupbox_candidateeditor.SuspendLayout();
            this.groupbox_miscsettings.SuspendLayout();
            this.groupbox_votermonitor.SuspendLayout();
            this.SuspendLayout();
            // 
            // numericupdown_allowedvotes
            // 
            this.numericupdown_allowedvotes.Location = new System.Drawing.Point(83, 12);
            this.numericupdown_allowedvotes.Name = "numericupdown_allowedvotes";
            this.numericupdown_allowedvotes.Size = new System.Drawing.Size(48, 20);
            this.numericupdown_allowedvotes.TabIndex = 2;
            this.numericupdown_allowedvotes.ValueChanged += new System.EventHandler(this.label_allowedvotes_ValueChanged);
            // 
            // label_allowedvotes
            // 
            this.label_allowedvotes.AutoSize = true;
            this.label_allowedvotes.Location = new System.Drawing.Point(6, 16);
            this.label_allowedvotes.Name = "label_allowedvotes";
            this.label_allowedvotes.Size = new System.Drawing.Size(77, 13);
            this.label_allowedvotes.TabIndex = 3;
            this.label_allowedvotes.Text = "Allowed Votes:";
            // 
            // button_addcandidate
            // 
            this.button_addcandidate.Location = new System.Drawing.Point(220, 61);
            this.button_addcandidate.Name = "button_addcandidate";
            this.button_addcandidate.Size = new System.Drawing.Size(69, 20);
            this.button_addcandidate.TabIndex = 4;
            this.button_addcandidate.Text = "Add";
            this.button_addcandidate.UseVisualStyleBackColor = true;
            this.button_addcandidate.Click += new System.EventHandler(this.button_addcandidate_Click);
            // 
            // textbox_addcandidate
            // 
            this.textbox_addcandidate.Location = new System.Drawing.Point(9, 32);
            this.textbox_addcandidate.Name = "textbox_addcandidate";
            this.textbox_addcandidate.Size = new System.Drawing.Size(205, 20);
            this.textbox_addcandidate.TabIndex = 5;
            this.textbox_addcandidate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textbox_addcandidate_KeyDown);
            // 
            // button_resetvoters
            // 
            this.button_resetvoters.Location = new System.Drawing.Point(9, 38);
            this.button_resetvoters.Name = "button_resetvoters";
            this.button_resetvoters.Size = new System.Drawing.Size(122, 23);
            this.button_resetvoters.TabIndex = 6;
            this.button_resetvoters.Text = "Reset Voters";
            this.button_resetvoters.UseVisualStyleBackColor = true;
            this.button_resetvoters.Click += new System.EventHandler(this.button_resetvoters_Click);
            // 
            // button_removecandidate
            // 
            this.button_removecandidate.Location = new System.Drawing.Point(220, 85);
            this.button_removecandidate.Name = "button_removecandidate";
            this.button_removecandidate.Size = new System.Drawing.Size(69, 23);
            this.button_removecandidate.TabIndex = 7;
            this.button_removecandidate.Text = "Remove";
            this.button_removecandidate.UseVisualStyleBackColor = true;
            this.button_removecandidate.Click += new System.EventHandler(this.button_removecandidate_Click);
            // 
            // listview_candiates
            // 
            this.listview_candiates.CheckBoxes = true;
            this.listview_candiates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_candidate_name,
            this.ch_candidate_votes,
            this.ch_gender});
            this.listview_candiates.Location = new System.Drawing.Point(6, 61);
            this.listview_candiates.Name = "listview_candiates";
            this.listview_candiates.Size = new System.Drawing.Size(208, 116);
            this.listview_candiates.TabIndex = 8;
            this.listview_candiates.UseCompatibleStateImageBehavior = false;
            this.listview_candiates.View = System.Windows.Forms.View.Details;
            this.listview_candiates.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listview_candiates_KeyDown);
            // 
            // ch_candidate_name
            // 
            this.ch_candidate_name.Text = "Candidate";
            this.ch_candidate_name.Width = 118;
            // 
            // ch_candidate_votes
            // 
            this.ch_candidate_votes.Text = "Votes";
            this.ch_candidate_votes.Width = 40;
            // 
            // ch_gender
            // 
            this.ch_gender.Text = "Gender";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Add candidate:";
            // 
            // groupbox_candidateeditor
            // 
            this.groupbox_candidateeditor.Controls.Add(this.label1);
            this.groupbox_candidateeditor.Controls.Add(this.comboBox1);
            this.groupbox_candidateeditor.Controls.Add(this.button_liverefresh);
            this.groupbox_candidateeditor.Controls.Add(this.button_refreshcandidates);
            this.groupbox_candidateeditor.Controls.Add(this.label2);
            this.groupbox_candidateeditor.Controls.Add(this.button_removecandidate);
            this.groupbox_candidateeditor.Controls.Add(this.button_addcandidate);
            this.groupbox_candidateeditor.Controls.Add(this.listview_candiates);
            this.groupbox_candidateeditor.Controls.Add(this.textbox_addcandidate);
            this.groupbox_candidateeditor.Location = new System.Drawing.Point(12, 12);
            this.groupbox_candidateeditor.Name = "groupbox_candidateeditor";
            this.groupbox_candidateeditor.Size = new System.Drawing.Size(295, 183);
            this.groupbox_candidateeditor.TabIndex = 10;
            this.groupbox_candidateeditor.TabStop = false;
            this.groupbox_candidateeditor.Text = "Candidate Editor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Gender:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Boy",
            "Girl",
            "Hermaphrodite"});
            this.comboBox1.Location = new System.Drawing.Point(220, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(69, 21);
            this.comboBox1.TabIndex = 12;
            // 
            // button_liverefresh
            // 
            this.button_liverefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_liverefresh.Location = new System.Drawing.Point(220, 143);
            this.button_liverefresh.Name = "button_liverefresh";
            this.button_liverefresh.Size = new System.Drawing.Size(69, 34);
            this.button_liverefresh.TabIndex = 11;
            this.button_liverefresh.Text = "Live Refresh";
            this.button_liverefresh.UseVisualStyleBackColor = true;
            this.button_liverefresh.Click += new System.EventHandler(this.button_liverefresh_Click);
            // 
            // button_refreshcandidates
            // 
            this.button_refreshcandidates.Location = new System.Drawing.Point(220, 114);
            this.button_refreshcandidates.Name = "button_refreshcandidates";
            this.button_refreshcandidates.Size = new System.Drawing.Size(69, 23);
            this.button_refreshcandidates.TabIndex = 10;
            this.button_refreshcandidates.Text = "Refresh";
            this.button_refreshcandidates.UseVisualStyleBackColor = true;
            this.button_refreshcandidates.Click += new System.EventHandler(this.button_refreshcandidates_Click_1);
            // 
            // groupbox_miscsettings
            // 
            this.groupbox_miscsettings.Controls.Add(this.button_resetcandidatevotes);
            this.groupbox_miscsettings.Controls.Add(this.combobox_liverefreshinterval);
            this.groupbox_miscsettings.Controls.Add(this.label_liverefreshinterval);
            this.groupbox_miscsettings.Controls.Add(this.label_allowedvotes);
            this.groupbox_miscsettings.Controls.Add(this.numericupdown_allowedvotes);
            this.groupbox_miscsettings.Controls.Add(this.button_resetvoters);
            this.groupbox_miscsettings.Location = new System.Drawing.Point(312, 12);
            this.groupbox_miscsettings.Name = "groupbox_miscsettings";
            this.groupbox_miscsettings.Size = new System.Drawing.Size(140, 183);
            this.groupbox_miscsettings.TabIndex = 11;
            this.groupbox_miscsettings.TabStop = false;
            this.groupbox_miscsettings.Text = "Misc Settings";
            // 
            // button_resetcandidatevotes
            // 
            this.button_resetcandidatevotes.Location = new System.Drawing.Point(9, 73);
            this.button_resetcandidatevotes.Name = "button_resetcandidatevotes";
            this.button_resetcandidatevotes.Size = new System.Drawing.Size(122, 35);
            this.button_resetcandidatevotes.TabIndex = 9;
            this.button_resetcandidatevotes.Text = "Reset Candidate\r\nVotes";
            this.button_resetcandidatevotes.UseVisualStyleBackColor = true;
            this.button_resetcandidatevotes.Click += new System.EventHandler(this.button_resetcandidatevotes_Click);
            // 
            // combobox_liverefreshinterval
            // 
            this.combobox_liverefreshinterval.FormattingEnabled = true;
            this.combobox_liverefreshinterval.Items.AddRange(new object[] {
            "1 Second",
            "2 Seconds",
            "3 Seconds",
            "4 Seconds",
            "5 Seconds"});
            this.combobox_liverefreshinterval.Location = new System.Drawing.Point(9, 143);
            this.combobox_liverefreshinterval.Name = "combobox_liverefreshinterval";
            this.combobox_liverefreshinterval.Size = new System.Drawing.Size(102, 21);
            this.combobox_liverefreshinterval.TabIndex = 8;
            this.combobox_liverefreshinterval.Text = "1 Second";
            this.combobox_liverefreshinterval.SelectedIndexChanged += new System.EventHandler(this.comboBox_liverefreshinterval_SelectedIndexChanged);
            // 
            // label_liverefreshinterval
            // 
            this.label_liverefreshinterval.AutoSize = true;
            this.label_liverefreshinterval.Location = new System.Drawing.Point(6, 127);
            this.label_liverefreshinterval.Name = "label_liverefreshinterval";
            this.label_liverefreshinterval.Size = new System.Drawing.Size(105, 13);
            this.label_liverefreshinterval.TabIndex = 7;
            this.label_liverefreshinterval.Text = "Live Refresh Interval";
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupbox_votermonitor
            // 
            this.groupbox_votermonitor.Controls.Add(this.button_refreshvoters);
            this.groupbox_votermonitor.Controls.Add(this.label_notvoted);
            this.groupbox_votermonitor.Controls.Add(this.listview_voters);
            this.groupbox_votermonitor.Location = new System.Drawing.Point(458, 12);
            this.groupbox_votermonitor.Name = "groupbox_votermonitor";
            this.groupbox_votermonitor.Size = new System.Drawing.Size(185, 183);
            this.groupbox_votermonitor.TabIndex = 12;
            this.groupbox_votermonitor.TabStop = false;
            this.groupbox_votermonitor.Text = "Voter Monitor";
            // 
            // button_refreshvoters
            // 
            this.button_refreshvoters.Location = new System.Drawing.Point(67, 13);
            this.button_refreshvoters.Name = "button_refreshvoters";
            this.button_refreshvoters.Size = new System.Drawing.Size(82, 19);
            this.button_refreshvoters.TabIndex = 15;
            this.button_refreshvoters.Text = "Refresh";
            this.button_refreshvoters.UseVisualStyleBackColor = true;
            this.button_refreshvoters.Click += new System.EventHandler(this.button_refreshvoters_Click);
            // 
            // label_notvoted
            // 
            this.label_notvoted.AutoSize = true;
            this.label_notvoted.Location = new System.Drawing.Point(6, 16);
            this.label_notvoted.Name = "label_notvoted";
            this.label_notvoted.Size = new System.Drawing.Size(55, 13);
            this.label_notvoted.TabIndex = 14;
            this.label_notvoted.Text = "Not Voted";
            // 
            // listview_voters
            // 
            this.listview_voters.Location = new System.Drawing.Point(6, 38);
            this.listview_voters.MultiSelect = false;
            this.listview_voters.Name = "listview_voters";
            this.listview_voters.Size = new System.Drawing.Size(167, 131);
            this.listview_voters.TabIndex = 12;
            this.listview_voters.UseCompatibleStateImageBehavior = false;
            this.listview_voters.View = System.Windows.Forms.View.List;
            // 
            // form_admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 207);
            this.Controls.Add(this.groupbox_votermonitor);
            this.Controls.Add(this.groupbox_miscsettings);
            this.Controls.Add(this.groupbox_candidateeditor);
            this.Name = "form_admin";
            this.Text = "Admin";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.form_admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericupdown_allowedvotes)).EndInit();
            this.groupbox_candidateeditor.ResumeLayout(false);
            this.groupbox_candidateeditor.PerformLayout();
            this.groupbox_miscsettings.ResumeLayout(false);
            this.groupbox_miscsettings.PerformLayout();
            this.groupbox_votermonitor.ResumeLayout(false);
            this.groupbox_votermonitor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericupdown_allowedvotes;
        private System.Windows.Forms.Label label_allowedvotes;
        private System.Windows.Forms.Button button_addcandidate;
        private System.Windows.Forms.TextBox textbox_addcandidate;
        private System.Windows.Forms.Button button_resetvoters;
        private System.Windows.Forms.Button button_removecandidate;
        private System.Windows.Forms.ListView listview_candiates;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupbox_candidateeditor;
        private System.Windows.Forms.ColumnHeader ch_candidate_name;
        private System.Windows.Forms.ColumnHeader ch_candidate_votes;
        private System.Windows.Forms.GroupBox groupbox_miscsettings;
        private System.Windows.Forms.Button button_refreshcandidates;
        private System.Windows.Forms.Button button_liverefresh;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox combobox_liverefreshinterval;
        private System.Windows.Forms.Label label_liverefreshinterval;
        private System.Windows.Forms.Button button_resetcandidatevotes;
        private System.Windows.Forms.GroupBox groupbox_votermonitor;
        private System.Windows.Forms.Button button_refreshvoters;
        private System.Windows.Forms.Label label_notvoted;
        private System.Windows.Forms.ListView listview_voters;
        public bool killit = true;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ColumnHeader ch_gender;
        private System.Windows.Forms.Label label1;

    }
}