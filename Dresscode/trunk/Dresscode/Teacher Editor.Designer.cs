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
            this.textbox_teacherid = new System.Windows.Forms.TextBox();
            this.label_teacherid = new System.Windows.Forms.Label();
            this.label_firstname = new System.Windows.Forms.Label();
            this.textbox_firstname = new System.Windows.Forms.TextBox();
            this.label_lastname = new System.Windows.Forms.Label();
            this.textbox_lastname = new System.Windows.Forms.TextBox();
            this.label_email = new System.Windows.Forms.Label();
            this.textbox_email = new System.Windows.Forms.TextBox();
            this.button_addteacher = new System.Windows.Forms.Button();
            this.button_removeteacher = new System.Windows.Forms.Button();
            this.checkbox_dean = new System.Windows.Forms.CheckBox();
            this.listview_teacherlist = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // textbox_teacherid
            // 
            this.textbox_teacherid.Location = new System.Drawing.Point(78, 13);
            this.textbox_teacherid.Name = "textbox_teacherid";
            this.textbox_teacherid.Size = new System.Drawing.Size(100, 20);
            this.textbox_teacherid.TabIndex = 1;
            // 
            // label_teacherid
            // 
            this.label_teacherid.AutoSize = true;
            this.label_teacherid.Location = new System.Drawing.Point(12, 13);
            this.label_teacherid.Name = "label_teacherid";
            this.label_teacherid.Size = new System.Drawing.Size(64, 13);
            this.label_teacherid.TabIndex = 2;
            this.label_teacherid.Text = "Teacher ID:";
            // 
            // label_firstname
            // 
            this.label_firstname.AutoSize = true;
            this.label_firstname.Location = new System.Drawing.Point(12, 39);
            this.label_firstname.Name = "label_firstname";
            this.label_firstname.Size = new System.Drawing.Size(60, 13);
            this.label_firstname.TabIndex = 4;
            this.label_firstname.Text = "First Name:";
            // 
            // textbox_firstname
            // 
            this.textbox_firstname.Location = new System.Drawing.Point(78, 36);
            this.textbox_firstname.Name = "textbox_firstname";
            this.textbox_firstname.Size = new System.Drawing.Size(100, 20);
            this.textbox_firstname.TabIndex = 3;
            // 
            // label_lastname
            // 
            this.label_lastname.AutoSize = true;
            this.label_lastname.Location = new System.Drawing.Point(12, 65);
            this.label_lastname.Name = "label_lastname";
            this.label_lastname.Size = new System.Drawing.Size(61, 13);
            this.label_lastname.TabIndex = 6;
            this.label_lastname.Text = "Last Name:";
            // 
            // textbox_lastname
            // 
            this.textbox_lastname.Location = new System.Drawing.Point(78, 62);
            this.textbox_lastname.Name = "textbox_lastname";
            this.textbox_lastname.Size = new System.Drawing.Size(100, 20);
            this.textbox_lastname.TabIndex = 5;
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Location = new System.Drawing.Point(25, 92);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(32, 13);
            this.label_email.TabIndex = 7;
            this.label_email.Text = "Email";
            // 
            // textbox_email
            // 
            this.textbox_email.Location = new System.Drawing.Point(78, 89);
            this.textbox_email.Name = "textbox_email";
            this.textbox_email.Size = new System.Drawing.Size(100, 20);
            this.textbox_email.TabIndex = 8;
            // 
            // button_addteacher
            // 
            this.button_addteacher.Location = new System.Drawing.Point(48, 141);
            this.button_addteacher.Name = "button_addteacher";
            this.button_addteacher.Size = new System.Drawing.Size(105, 23);
            this.button_addteacher.TabIndex = 9;
            this.button_addteacher.Text = "Add Teacher";
            this.button_addteacher.UseVisualStyleBackColor = true;
            this.button_addteacher.Click += new System.EventHandler(this.button_addteacher_Click);
            // 
            // button_removeteacher
            // 
            this.button_removeteacher.Location = new System.Drawing.Point(239, 141);
            this.button_removeteacher.Name = "button_removeteacher";
            this.button_removeteacher.Size = new System.Drawing.Size(110, 23);
            this.button_removeteacher.TabIndex = 10;
            this.button_removeteacher.Text = "Remove Teacher";
            this.button_removeteacher.UseVisualStyleBackColor = true;
            // 
            // checkbox_dean
            // 
            this.checkbox_dean.AutoSize = true;
            this.checkbox_dean.Location = new System.Drawing.Point(20, 118);
            this.checkbox_dean.Name = "checkbox_dean";
            this.checkbox_dean.Size = new System.Drawing.Size(52, 17);
            this.checkbox_dean.TabIndex = 11;
            this.checkbox_dean.Text = "Dean";
            this.checkbox_dean.UseVisualStyleBackColor = true;
            // 
            // listview_teacherlist
            // 
            this.listview_teacherlist.Location = new System.Drawing.Point(184, 12);
            this.listview_teacherlist.Name = "listview_teacherlist";
            this.listview_teacherlist.Size = new System.Drawing.Size(213, 123);
            this.listview_teacherlist.TabIndex = 12;
            this.listview_teacherlist.UseCompatibleStateImageBehavior = false;
            // 
            // Teacher_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 176);
            this.Controls.Add(this.listview_teacherlist);
            this.Controls.Add(this.checkbox_dean);
            this.Controls.Add(this.button_removeteacher);
            this.Controls.Add(this.button_addteacher);
            this.Controls.Add(this.textbox_email);
            this.Controls.Add(this.label_email);
            this.Controls.Add(this.label_lastname);
            this.Controls.Add(this.textbox_lastname);
            this.Controls.Add(this.label_firstname);
            this.Controls.Add(this.textbox_firstname);
            this.Controls.Add(this.label_teacherid);
            this.Controls.Add(this.textbox_teacherid);
            this.Name = "Teacher_Editor";
            this.Text = "Teacher_Editor";
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
        private System.Windows.Forms.Button button_removeteacher;
        private System.Windows.Forms.CheckBox checkbox_dean;
        private System.Windows.Forms.ListView listview_teacherlist;
    }
}