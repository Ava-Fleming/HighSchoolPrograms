namespace Dresscode
{
    partial class reports
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
            this.datetimepicker_date_start = new System.Windows.Forms.DateTimePicker();
            this.combobox_teacher = new System.Windows.Forms.ComboBox();
            this.label_viewing = new System.Windows.Forms.Label();
            this.button_retrieve = new System.Windows.Forms.Button();
            this.checkBox_date_single = new System.Windows.Forms.CheckBox();
            this.checkBox_teacher = new System.Windows.Forms.CheckBox();
            this.groupBox_search = new System.Windows.Forms.GroupBox();
            this.comboBox_semster = new System.Windows.Forms.ComboBox();
            this.checkBox_semester = new System.Windows.Forms.CheckBox();
            this.checkBox_9weeksend = new System.Windows.Forms.CheckBox();
            this.comboBox_9weeksend = new System.Windows.Forms.ComboBox();
            this.comboBox_9weeksstart = new System.Windows.Forms.ComboBox();
            this.checkBox_9weeksstart = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_student_firstname = new System.Windows.Forms.Label();
            this.comboBox_student_last = new System.Windows.Forms.ComboBox();
            this.checkBox_student = new System.Windows.Forms.CheckBox();
            this.comboBox_student_firstname = new System.Windows.Forms.ComboBox();
            this.numericUpDown_grade_end = new System.Windows.Forms.NumericUpDown();
            this.checkBox_grade_range = new System.Windows.Forms.CheckBox();
            this.numericUpDown_grade_start = new System.Windows.Forms.NumericUpDown();
            this.checkBox_grade_single = new System.Windows.Forms.CheckBox();
            this.numericUpDown_period_end = new System.Windows.Forms.NumericUpDown();
            this.checkBox_period_range = new System.Windows.Forms.CheckBox();
            this.numericUpDown_period_start = new System.Windows.Forms.NumericUpDown();
            this.checkBox_period_single = new System.Windows.Forms.CheckBox();
            this.comboBox_infraction_select = new System.Windows.Forms.ComboBox();
            this.checkBox_infraction = new System.Windows.Forms.CheckBox();
            this.datetimepicker_date_end = new System.Windows.Forms.DateTimePicker();
            this.checkBox_date_range = new System.Windows.Forms.CheckBox();
            this.dataGridView_reports = new System.Windows.Forms.DataGridView();
            this.button_update = new System.Windows.Forms.Button();
            this.button_export_excel = new System.Windows.Forms.Button();
            this.label_nineweeks = new System.Windows.Forms.Label();
            this.label_total_reports = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox_search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_grade_end)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_grade_start)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_period_end)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_period_start)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_reports)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // datetimepicker_date_start
            // 
            this.datetimepicker_date_start.Enabled = false;
            this.datetimepicker_date_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetimepicker_date_start.Location = new System.Drawing.Point(109, 15);
            this.datetimepicker_date_start.Name = "datetimepicker_date_start";
            this.datetimepicker_date_start.Size = new System.Drawing.Size(80, 20);
            this.datetimepicker_date_start.TabIndex = 2;
            // 
            // combobox_teacher
            // 
            this.combobox_teacher.Enabled = false;
            this.combobox_teacher.FormattingEnabled = true;
            this.combobox_teacher.Location = new System.Drawing.Point(126, 95);
            this.combobox_teacher.Name = "combobox_teacher";
            this.combobox_teacher.Size = new System.Drawing.Size(121, 21);
            this.combobox_teacher.TabIndex = 5;
            // 
            // label_viewing
            // 
            this.label_viewing.AutoSize = true;
            this.label_viewing.Location = new System.Drawing.Point(15, 248);
            this.label_viewing.Name = "label_viewing";
            this.label_viewing.Size = new System.Drawing.Size(94, 13);
            this.label_viewing.TabIndex = 7;
            this.label_viewing.Text = "Currently Viewing: ";
            // 
            // button_retrieve
            // 
            this.button_retrieve.Location = new System.Drawing.Point(12, 451);
            this.button_retrieve.Name = "button_retrieve";
            this.button_retrieve.Size = new System.Drawing.Size(132, 23);
            this.button_retrieve.TabIndex = 9;
            this.button_retrieve.Text = "Retrieve";
            this.button_retrieve.UseVisualStyleBackColor = true;
            this.button_retrieve.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox_date_single
            // 
            this.checkBox_date_single.AutoSize = true;
            this.checkBox_date_single.Location = new System.Drawing.Point(6, 19);
            this.checkBox_date_single.Name = "checkBox_date_single";
            this.checkBox_date_single.Size = new System.Drawing.Size(97, 17);
            this.checkBox_date_single.TabIndex = 10;
            this.checkBox_date_single.Text = "Select By Date";
            this.checkBox_date_single.UseVisualStyleBackColor = true;
            this.checkBox_date_single.CheckedChanged += new System.EventHandler(this.checkBox_date_single_CheckedChanged);
            // 
            // checkBox_teacher
            // 
            this.checkBox_teacher.AutoSize = true;
            this.checkBox_teacher.Location = new System.Drawing.Point(6, 97);
            this.checkBox_teacher.Name = "checkBox_teacher";
            this.checkBox_teacher.Size = new System.Drawing.Size(114, 17);
            this.checkBox_teacher.TabIndex = 11;
            this.checkBox_teacher.Text = "Select By Teacher";
            this.checkBox_teacher.UseVisualStyleBackColor = true;
            this.checkBox_teacher.CheckedChanged += new System.EventHandler(this.checkBox_teacher_CheckedChanged);
            // 
            // groupBox_search
            // 
            this.groupBox_search.Controls.Add(this.comboBox_semster);
            this.groupBox_search.Controls.Add(this.checkBox_semester);
            this.groupBox_search.Controls.Add(this.checkBox_9weeksend);
            this.groupBox_search.Controls.Add(this.comboBox_9weeksend);
            this.groupBox_search.Controls.Add(this.comboBox_9weeksstart);
            this.groupBox_search.Controls.Add(this.checkBox_9weeksstart);
            this.groupBox_search.Controls.Add(this.label1);
            this.groupBox_search.Controls.Add(this.label_student_firstname);
            this.groupBox_search.Controls.Add(this.comboBox_student_last);
            this.groupBox_search.Controls.Add(this.checkBox_student);
            this.groupBox_search.Controls.Add(this.comboBox_student_firstname);
            this.groupBox_search.Controls.Add(this.numericUpDown_grade_end);
            this.groupBox_search.Controls.Add(this.checkBox_grade_range);
            this.groupBox_search.Controls.Add(this.numericUpDown_grade_start);
            this.groupBox_search.Controls.Add(this.checkBox_grade_single);
            this.groupBox_search.Controls.Add(this.numericUpDown_period_end);
            this.groupBox_search.Controls.Add(this.checkBox_period_range);
            this.groupBox_search.Controls.Add(this.numericUpDown_period_start);
            this.groupBox_search.Controls.Add(this.checkBox_period_single);
            this.groupBox_search.Controls.Add(this.comboBox_infraction_select);
            this.groupBox_search.Controls.Add(this.checkBox_infraction);
            this.groupBox_search.Controls.Add(this.datetimepicker_date_end);
            this.groupBox_search.Controls.Add(this.checkBox_date_range);
            this.groupBox_search.Controls.Add(this.checkBox_teacher);
            this.groupBox_search.Controls.Add(this.checkBox_date_single);
            this.groupBox_search.Controls.Add(this.datetimepicker_date_start);
            this.groupBox_search.Controls.Add(this.combobox_teacher);
            this.groupBox_search.Location = new System.Drawing.Point(12, 25);
            this.groupBox_search.Name = "groupBox_search";
            this.groupBox_search.Size = new System.Drawing.Size(489, 220);
            this.groupBox_search.TabIndex = 12;
            this.groupBox_search.TabStop = false;
            this.groupBox_search.Text = "Search Criteria";
            // 
            // comboBox_semster
            // 
            this.comboBox_semster.Enabled = false;
            this.comboBox_semster.FormattingEnabled = true;
            this.comboBox_semster.Items.AddRange(new object[] {
            "1st semester",
            "2nd semester"});
            this.comboBox_semster.Location = new System.Drawing.Point(129, 68);
            this.comboBox_semster.Name = "comboBox_semster";
            this.comboBox_semster.Size = new System.Drawing.Size(63, 21);
            this.comboBox_semster.TabIndex = 35;
            // 
            // checkBox_semester
            // 
            this.checkBox_semester.AutoSize = true;
            this.checkBox_semester.Location = new System.Drawing.Point(6, 70);
            this.checkBox_semester.Name = "checkBox_semester";
            this.checkBox_semester.Size = new System.Drawing.Size(117, 17);
            this.checkBox_semester.TabIndex = 34;
            this.checkBox_semester.Text = "Select by Semester";
            this.checkBox_semester.UseVisualStyleBackColor = true;
            this.checkBox_semester.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox_9weeksend
            // 
            this.checkBox_9weeksend.AutoSize = true;
            this.checkBox_9weeksend.Enabled = false;
            this.checkBox_9weeksend.Location = new System.Drawing.Point(195, 43);
            this.checkBox_9weeksend.Name = "checkBox_9weeksend";
            this.checkBox_9weeksend.Size = new System.Drawing.Size(58, 17);
            this.checkBox_9weeksend.TabIndex = 33;
            this.checkBox_9weeksend.Text = "Range";
            this.checkBox_9weeksend.UseVisualStyleBackColor = true;
            this.checkBox_9weeksend.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // comboBox_9weeksend
            // 
            this.comboBox_9weeksend.Enabled = false;
            this.comboBox_9weeksend.FormattingEnabled = true;
            this.comboBox_9weeksend.Items.AddRange(new object[] {
            "1st 9 weeks",
            "2nd 9 weeks",
            "3rd 9 weeks",
            "4th 9 weeks"});
            this.comboBox_9weeksend.Location = new System.Drawing.Point(259, 41);
            this.comboBox_9weeksend.Name = "comboBox_9weeksend";
            this.comboBox_9weeksend.Size = new System.Drawing.Size(63, 21);
            this.comboBox_9weeksend.TabIndex = 32;
            // 
            // comboBox_9weeksstart
            // 
            this.comboBox_9weeksstart.Enabled = false;
            this.comboBox_9weeksstart.FormattingEnabled = true;
            this.comboBox_9weeksstart.Items.AddRange(new object[] {
            "1st 9 weeks",
            "2nd 9 weeks",
            "3rd 9 weeks",
            "4th 9 weeks"});
            this.comboBox_9weeksstart.Location = new System.Drawing.Point(126, 41);
            this.comboBox_9weeksstart.Name = "comboBox_9weeksstart";
            this.comboBox_9weeksstart.Size = new System.Drawing.Size(63, 21);
            this.comboBox_9weeksstart.TabIndex = 31;
            // 
            // checkBox_9weeksstart
            // 
            this.checkBox_9weeksstart.AutoSize = true;
            this.checkBox_9weeksstart.Location = new System.Drawing.Point(7, 43);
            this.checkBox_9weeksstart.Name = "checkBox_9weeksstart";
            this.checkBox_9weeksstart.Size = new System.Drawing.Size(113, 17);
            this.checkBox_9weeksstart.TabIndex = 30;
            this.checkBox_9weeksstart.Text = "Select by 9 weeks";
            this.checkBox_9weeksstart.UseVisualStyleBackColor = true;
            this.checkBox_9weeksstart.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(296, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Last Name:";
            // 
            // label_student_firstname
            // 
            this.label_student_firstname.AutoSize = true;
            this.label_student_firstname.Location = new System.Drawing.Point(119, 198);
            this.label_student_firstname.Name = "label_student_firstname";
            this.label_student_firstname.Size = new System.Drawing.Size(60, 13);
            this.label_student_firstname.TabIndex = 28;
            this.label_student_firstname.Text = "First Name:";
            // 
            // comboBox_student_last
            // 
            this.comboBox_student_last.Enabled = false;
            this.comboBox_student_last.FormattingEnabled = true;
            this.comboBox_student_last.Location = new System.Drawing.Point(363, 197);
            this.comboBox_student_last.Name = "comboBox_student_last";
            this.comboBox_student_last.Size = new System.Drawing.Size(107, 21);
            this.comboBox_student_last.TabIndex = 27;
            this.comboBox_student_last.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_student_last_KeyDown);
            // 
            // checkBox_student
            // 
            this.checkBox_student.AutoSize = true;
            this.checkBox_student.Location = new System.Drawing.Point(6, 197);
            this.checkBox_student.Name = "checkBox_student";
            this.checkBox_student.Size = new System.Drawing.Size(111, 17);
            this.checkBox_student.TabIndex = 26;
            this.checkBox_student.Text = "Select By Student";
            this.checkBox_student.UseVisualStyleBackColor = true;
            this.checkBox_student.CheckedChanged += new System.EventHandler(this.checkBox_student_CheckedChanged);
            // 
            // comboBox_student_firstname
            // 
            this.comboBox_student_firstname.Enabled = false;
            this.comboBox_student_firstname.FormattingEnabled = true;
            this.comboBox_student_firstname.Location = new System.Drawing.Point(181, 195);
            this.comboBox_student_firstname.Name = "comboBox_student_firstname";
            this.comboBox_student_firstname.Size = new System.Drawing.Size(109, 21);
            this.comboBox_student_firstname.TabIndex = 25;
            this.comboBox_student_firstname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_student_firstname_KeyDown);
            // 
            // numericUpDown_grade_end
            // 
            this.numericUpDown_grade_end.Enabled = false;
            this.numericUpDown_grade_end.Location = new System.Drawing.Point(241, 171);
            this.numericUpDown_grade_end.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDown_grade_end.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDown_grade_end.Name = "numericUpDown_grade_end";
            this.numericUpDown_grade_end.Size = new System.Drawing.Size(49, 20);
            this.numericUpDown_grade_end.TabIndex = 24;
            this.numericUpDown_grade_end.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // checkBox_grade_range
            // 
            this.checkBox_grade_range.AutoSize = true;
            this.checkBox_grade_range.Enabled = false;
            this.checkBox_grade_range.Location = new System.Drawing.Point(177, 172);
            this.checkBox_grade_range.Name = "checkBox_grade_range";
            this.checkBox_grade_range.Size = new System.Drawing.Size(58, 17);
            this.checkBox_grade_range.TabIndex = 23;
            this.checkBox_grade_range.Text = "Range";
            this.checkBox_grade_range.UseVisualStyleBackColor = true;
            this.checkBox_grade_range.CheckedChanged += new System.EventHandler(this.checkBox_grade_range_CheckedChanged);
            // 
            // numericUpDown_grade_start
            // 
            this.numericUpDown_grade_start.Enabled = false;
            this.numericUpDown_grade_start.Location = new System.Drawing.Point(122, 171);
            this.numericUpDown_grade_start.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDown_grade_start.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDown_grade_start.Name = "numericUpDown_grade_start";
            this.numericUpDown_grade_start.Size = new System.Drawing.Size(51, 20);
            this.numericUpDown_grade_start.TabIndex = 22;
            this.numericUpDown_grade_start.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // checkBox_grade_single
            // 
            this.checkBox_grade_single.AutoSize = true;
            this.checkBox_grade_single.Location = new System.Drawing.Point(7, 169);
            this.checkBox_grade_single.Name = "checkBox_grade_single";
            this.checkBox_grade_single.Size = new System.Drawing.Size(107, 17);
            this.checkBox_grade_single.TabIndex = 21;
            this.checkBox_grade_single.Text = "Search By Grade";
            this.checkBox_grade_single.UseVisualStyleBackColor = true;
            this.checkBox_grade_single.CheckedChanged += new System.EventHandler(this.checkBox_grade_single_CheckedChanged);
            // 
            // numericUpDown_period_end
            // 
            this.numericUpDown_period_end.Enabled = false;
            this.numericUpDown_period_end.Location = new System.Drawing.Point(241, 145);
            this.numericUpDown_period_end.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericUpDown_period_end.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_period_end.Name = "numericUpDown_period_end";
            this.numericUpDown_period_end.Size = new System.Drawing.Size(49, 20);
            this.numericUpDown_period_end.TabIndex = 20;
            this.numericUpDown_period_end.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // checkBox_period_range
            // 
            this.checkBox_period_range.AutoSize = true;
            this.checkBox_period_range.Enabled = false;
            this.checkBox_period_range.Location = new System.Drawing.Point(177, 146);
            this.checkBox_period_range.Name = "checkBox_period_range";
            this.checkBox_period_range.Size = new System.Drawing.Size(58, 17);
            this.checkBox_period_range.TabIndex = 19;
            this.checkBox_period_range.Text = "Range";
            this.checkBox_period_range.UseVisualStyleBackColor = true;
            this.checkBox_period_range.CheckedChanged += new System.EventHandler(this.checkBox_period_range_CheckedChanged);
            // 
            // numericUpDown_period_start
            // 
            this.numericUpDown_period_start.Enabled = false;
            this.numericUpDown_period_start.Location = new System.Drawing.Point(122, 145);
            this.numericUpDown_period_start.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericUpDown_period_start.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_period_start.Name = "numericUpDown_period_start";
            this.numericUpDown_period_start.Size = new System.Drawing.Size(49, 20);
            this.numericUpDown_period_start.TabIndex = 18;
            this.numericUpDown_period_start.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkBox_period_single
            // 
            this.checkBox_period_single.AutoSize = true;
            this.checkBox_period_single.Location = new System.Drawing.Point(7, 145);
            this.checkBox_period_single.Name = "checkBox_period_single";
            this.checkBox_period_single.Size = new System.Drawing.Size(108, 17);
            this.checkBox_period_single.TabIndex = 17;
            this.checkBox_period_single.Text = "Search By Period";
            this.checkBox_period_single.UseVisualStyleBackColor = true;
            this.checkBox_period_single.CheckedChanged += new System.EventHandler(this.checkBox_period_single_CheckedChanged);
            // 
            // comboBox_infraction_select
            // 
            this.comboBox_infraction_select.Enabled = false;
            this.comboBox_infraction_select.FormattingEnabled = true;
            this.comboBox_infraction_select.Location = new System.Drawing.Point(126, 121);
            this.comboBox_infraction_select.Name = "comboBox_infraction_select";
            this.comboBox_infraction_select.Size = new System.Drawing.Size(121, 21);
            this.comboBox_infraction_select.TabIndex = 16;
            // 
            // checkBox_infraction
            // 
            this.checkBox_infraction.AutoSize = true;
            this.checkBox_infraction.Location = new System.Drawing.Point(7, 121);
            this.checkBox_infraction.Name = "checkBox_infraction";
            this.checkBox_infraction.Size = new System.Drawing.Size(118, 17);
            this.checkBox_infraction.TabIndex = 15;
            this.checkBox_infraction.Text = "Select By Infraction";
            this.checkBox_infraction.UseVisualStyleBackColor = true;
            this.checkBox_infraction.CheckedChanged += new System.EventHandler(this.checkBox_infraction_CheckedChanged);
            // 
            // datetimepicker_date_end
            // 
            this.datetimepicker_date_end.Enabled = false;
            this.datetimepicker_date_end.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetimepicker_date_end.Location = new System.Drawing.Point(259, 13);
            this.datetimepicker_date_end.Name = "datetimepicker_date_end";
            this.datetimepicker_date_end.Size = new System.Drawing.Size(80, 20);
            this.datetimepicker_date_end.TabIndex = 14;
            // 
            // checkBox_date_range
            // 
            this.checkBox_date_range.AutoSize = true;
            this.checkBox_date_range.Enabled = false;
            this.checkBox_date_range.Location = new System.Drawing.Point(195, 15);
            this.checkBox_date_range.Name = "checkBox_date_range";
            this.checkBox_date_range.Size = new System.Drawing.Size(58, 17);
            this.checkBox_date_range.TabIndex = 13;
            this.checkBox_date_range.Text = "Range";
            this.checkBox_date_range.UseVisualStyleBackColor = true;
            this.checkBox_date_range.CheckedChanged += new System.EventHandler(this.checkBox_date_range_CheckedChanged);
            // 
            // dataGridView_reports
            // 
            this.dataGridView_reports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_reports.Location = new System.Drawing.Point(12, 264);
            this.dataGridView_reports.Name = "dataGridView_reports";
            this.dataGridView_reports.Size = new System.Drawing.Size(489, 181);
            this.dataGridView_reports.TabIndex = 13;
            this.dataGridView_reports.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellLeave);
            this.dataGridView_reports.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView_reports_UserDeletingRow);
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(216, 451);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(118, 23);
            this.button_update.TabIndex = 14;
            this.button_update.Text = "Update";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_export_excel
            // 
            this.button_export_excel.Location = new System.Drawing.Point(388, 451);
            this.button_export_excel.Name = "button_export_excel";
            this.button_export_excel.Size = new System.Drawing.Size(113, 23);
            this.button_export_excel.TabIndex = 15;
            this.button_export_excel.Text = "Export To Excel";
            this.button_export_excel.UseVisualStyleBackColor = true;
            this.button_export_excel.Click += new System.EventHandler(this.button_export_excel_Click);
            // 
            // label_nineweeks
            // 
            this.label_nineweeks.AutoSize = true;
            this.label_nineweeks.Location = new System.Drawing.Point(156, 248);
            this.label_nineweeks.Name = "label_nineweeks";
            this.label_nineweeks.Size = new System.Drawing.Size(109, 13);
            this.label_nineweeks.TabIndex = 30;
            this.label_nineweeks.Text = "Reports this 9 weeks:";
            // 
            // label_total_reports
            // 
            this.label_total_reports.AutoSize = true;
            this.label_total_reports.Location = new System.Drawing.Point(327, 248);
            this.label_total_reports.Name = "label_total_reports";
            this.label_total_reports.Size = new System.Drawing.Size(77, 13);
            this.label_total_reports.TabIndex = 31;
            this.label_total_reports.Text = "Total Reports: ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.studentEditorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(513, 24);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // studentEditorToolStripMenuItem
            // 
            this.studentEditorToolStripMenuItem.Name = "studentEditorToolStripMenuItem";
            this.studentEditorToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.studentEditorToolStripMenuItem.Text = "Student Editor";
            this.studentEditorToolStripMenuItem.Click += new System.EventHandler(this.studentEditorToolStripMenuItem_Click);
            // 
            // reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 486);
            this.Controls.Add(this.label_total_reports);
            this.Controls.Add(this.label_nineweeks);
            this.Controls.Add(this.button_export_excel);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.dataGridView_reports);
            this.Controls.Add(this.groupBox_search);
            this.Controls.Add(this.button_retrieve);
            this.Controls.Add(this.label_viewing);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "reports";
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.reports_Load);
            this.groupBox_search.ResumeLayout(false);
            this.groupBox_search.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_grade_end)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_grade_start)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_period_end)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_period_start)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_reports)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datetimepicker_date_start;
        private System.Windows.Forms.ComboBox combobox_teacher;
        private System.Windows.Forms.Label label_viewing;
        private System.Windows.Forms.Button button_retrieve;
        private System.Windows.Forms.CheckBox checkBox_date_single;
        private System.Windows.Forms.CheckBox checkBox_teacher;
        private System.Windows.Forms.GroupBox groupBox_search;
        private System.Windows.Forms.DateTimePicker datetimepicker_date_end;
        private System.Windows.Forms.CheckBox checkBox_date_range;
        private System.Windows.Forms.ComboBox comboBox_infraction_select;
        private System.Windows.Forms.CheckBox checkBox_infraction;
        private System.Windows.Forms.NumericUpDown numericUpDown_period_end;
        private System.Windows.Forms.CheckBox checkBox_period_range;
        private System.Windows.Forms.NumericUpDown numericUpDown_period_start;
        private System.Windows.Forms.CheckBox checkBox_period_single;
        private System.Windows.Forms.DataGridView dataGridView_reports;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.NumericUpDown numericUpDown_grade_end;
        private System.Windows.Forms.CheckBox checkBox_grade_range;
        private System.Windows.Forms.NumericUpDown numericUpDown_grade_start;
        private System.Windows.Forms.CheckBox checkBox_grade_single;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_student_firstname;
        private System.Windows.Forms.ComboBox comboBox_student_last;
        private System.Windows.Forms.CheckBox checkBox_student;
        private System.Windows.Forms.ComboBox comboBox_student_firstname;
        private System.Windows.Forms.Button button_export_excel;
        private System.Windows.Forms.Label label_nineweeks;
        private System.Windows.Forms.Label label_total_reports;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox_9weeksend;
        private System.Windows.Forms.ComboBox comboBox_9weeksend;
        private System.Windows.Forms.ComboBox comboBox_9weeksstart;
        private System.Windows.Forms.CheckBox checkBox_9weeksstart;
        private System.Windows.Forms.ComboBox comboBox_semster;
        private System.Windows.Forms.CheckBox checkBox_semester;
        private System.Windows.Forms.ToolStripMenuItem studentEditorToolStripMenuItem;

    }
}