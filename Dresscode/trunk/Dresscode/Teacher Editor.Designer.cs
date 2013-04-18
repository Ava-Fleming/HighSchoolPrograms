namespace Dresscode
{
    partial class Teacher_Editor
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
            this.textbox_teacherid = new System.Windows.Forms.TextBox();
            this.label_teacherid = new System.Windows.Forms.Label();
            this.label_firstname = new System.Windows.Forms.Label();
            this.textbox_firstname = new System.Windows.Forms.TextBox();
            this.label_lastname = new System.Windows.Forms.Label();
            this.textbox_lastname = new System.Windows.Forms.TextBox();
            this.label_email = new System.Windows.Forms.Label();
            this.textbox_email = new System.Windows.Forms.TextBox();
            this.button_addteacher = new System.Windows.Forms.Button();
            this.checkbox_dean = new System.Windows.Forms.CheckBox();
            this.datagridview_teachers = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_teachers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // textbox_teacherid
            // 
            this.textbox_teacherid.Location = new System.Drawing.Point(206, 25);
            this.textbox_teacherid.Name = "textbox_teacherid";
            this.textbox_teacherid.Size = new System.Drawing.Size(100, 20);
            this.textbox_teacherid.TabIndex = 1;
            // 
            // label_teacherid
            // 
            this.label_teacherid.AutoSize = true;
            this.label_teacherid.Location = new System.Drawing.Point(223, 9);
            this.label_teacherid.Name = "label_teacherid";
            this.label_teacherid.Size = new System.Drawing.Size(64, 13);
            this.label_teacherid.TabIndex = 2;
            this.label_teacherid.Text = "Teacher ID:";
            // 
            // label_firstname
            // 
            this.label_firstname.AutoSize = true;
            this.label_firstname.Location = new System.Drawing.Point(223, 48);
            this.label_firstname.Name = "label_firstname";
            this.label_firstname.Size = new System.Drawing.Size(60, 13);
            this.label_firstname.TabIndex = 4;
            this.label_firstname.Text = "First Name:";
            // 
            // textbox_firstname
            // 
            this.textbox_firstname.Location = new System.Drawing.Point(206, 64);
            this.textbox_firstname.Name = "textbox_firstname";
            this.textbox_firstname.Size = new System.Drawing.Size(100, 20);
            this.textbox_firstname.TabIndex = 2;
            // 
            // label_lastname
            // 
            this.label_lastname.AutoSize = true;
            this.label_lastname.Location = new System.Drawing.Point(223, 87);
            this.label_lastname.Name = "label_lastname";
            this.label_lastname.Size = new System.Drawing.Size(61, 13);
            this.label_lastname.TabIndex = 6;
            this.label_lastname.Text = "Last Name:";
            // 
            // textbox_lastname
            // 
            this.textbox_lastname.Location = new System.Drawing.Point(206, 103);
            this.textbox_lastname.Name = "textbox_lastname";
            this.textbox_lastname.Size = new System.Drawing.Size(100, 20);
            this.textbox_lastname.TabIndex = 3;
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Location = new System.Drawing.Point(234, 126);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(32, 13);
            this.label_email.TabIndex = 7;
            this.label_email.Text = "Email";
            // 
            // textbox_email
            // 
            this.textbox_email.Location = new System.Drawing.Point(206, 142);
            this.textbox_email.Name = "textbox_email";
            this.textbox_email.Size = new System.Drawing.Size(100, 20);
            this.textbox_email.TabIndex = 4;
            // 
            // button_addteacher
            // 
            this.button_addteacher.Location = new System.Drawing.Point(206, 191);
            this.button_addteacher.Name = "button_addteacher";
            this.button_addteacher.Size = new System.Drawing.Size(100, 23);
            this.button_addteacher.TabIndex = 6;
            this.button_addteacher.Text = "Add Teacher";
            this.button_addteacher.UseVisualStyleBackColor = true;
            this.button_addteacher.Click += new System.EventHandler(this.button_addteacher_Click);
            // 
            // checkbox_dean
            // 
            this.checkbox_dean.AutoSize = true;
            this.checkbox_dean.Location = new System.Drawing.Point(226, 168);
            this.checkbox_dean.Name = "checkbox_dean";
            this.checkbox_dean.Size = new System.Drawing.Size(52, 17);
            this.checkbox_dean.TabIndex = 5;
            this.checkbox_dean.Text = "Dean";
            this.checkbox_dean.UseVisualStyleBackColor = true;
            // 
            // datagridview_teachers
            // 
            this.datagridview_teachers.AllowUserToAddRows = false;
            this.datagridview_teachers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridview_teachers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview_teachers.Location = new System.Drawing.Point(12, 220);
            this.datagridview_teachers.Name = "datagridview_teachers";
            this.datagridview_teachers.Size = new System.Drawing.Size(493, 140);
            this.datagridview_teachers.TabIndex = 12;
            this.datagridview_teachers.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview_teachers_CellEndEdit);
            this.datagridview_teachers.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.datagridview_teachers_UserDeletingRow);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Dresscode.Properties.Resources._161_202markor1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 202);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Dresscode.Properties.Resources._161_202markor2;
            this.pictureBox2.Location = new System.Drawing.Point(344, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(161, 202);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Dresscode.Properties.Resources.morkhorcomputerdms;
            this.pictureBox3.Location = new System.Drawing.Point(237, 288);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(493, 140);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // Teacher_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 214);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.datagridview_teachers);
            this.Controls.Add(this.checkbox_dean);
            this.Controls.Add(this.button_addteacher);
            this.Controls.Add(this.textbox_email);
            this.Controls.Add(this.label_email);
            this.Controls.Add(this.label_lastname);
            this.Controls.Add(this.textbox_lastname);
            this.Controls.Add(this.label_firstname);
            this.Controls.Add(this.textbox_firstname);
            this.Controls.Add(this.label_teacherid);
            this.Controls.Add(this.textbox_teacherid);
            this.MaximumSize = new System.Drawing.Size(533, 410);
            this.MinimumSize = new System.Drawing.Size(533, 252);
            this.Name = "Teacher_Editor";
            this.Text = "Teacher Editor";
            this.Load += new System.EventHandler(this.Teacher_Editor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_teachers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textbox_teacherid;
        private System.Windows.Forms.Label label_teacherid;
        private System.Windows.Forms.Label label_firstname;
        private System.Windows.Forms.TextBox textbox_firstname;
        private System.Windows.Forms.Label label_lastname;
        private System.Windows.Forms.TextBox textbox_lastname;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.TextBox textbox_email;
        private System.Windows.Forms.Button button_addteacher;
        private System.Windows.Forms.CheckBox checkbox_dean;
        private System.Windows.Forms.DataGridView datagridview_teachers;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}