namespace Dresscode
{
    partial class Learning_Center
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
            this.listBox_students = new System.Windows.Forms.ListBox();
            this.button_present = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_notpresent = new System.Windows.Forms.Button();
            this.listBox_present = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox_students
            // 
            this.listBox_students.FormattingEnabled = true;
            this.listBox_students.Location = new System.Drawing.Point(12, 51);
            this.listBox_students.Name = "listBox_students";
            this.listBox_students.Size = new System.Drawing.Size(210, 251);
            this.listBox_students.TabIndex = 0;
            // 
            // button_present
            // 
            this.button_present.Location = new System.Drawing.Point(117, 312);
            this.button_present.Name = "button_present";
            this.button_present.Size = new System.Drawing.Size(105, 23);
            this.button_present.TabIndex = 1;
            this.button_present.Text = "Present";
            this.button_present.UseVisualStyleBackColor = true;
            this.button_present.Click += new System.EventHandler(this.button_present_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Last Name:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(79, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(305, 20);
            this.textBox1.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button_notpresent
            // 
            this.button_notpresent.Location = new System.Drawing.Point(12, 312);
            this.button_notpresent.Name = "button_notpresent";
            this.button_notpresent.Size = new System.Drawing.Size(105, 23);
            this.button_notpresent.TabIndex = 4;
            this.button_notpresent.Text = "Not Present";
            this.button_notpresent.UseVisualStyleBackColor = true;
            this.button_notpresent.Click += new System.EventHandler(this.button_notpresent_Click);
            // 
            // listBox_present
            // 
            this.listBox_present.FormattingEnabled = true;
            this.listBox_present.Location = new System.Drawing.Point(250, 51);
            this.listBox_present.Name = "listBox_present";
            this.listBox_present.Size = new System.Drawing.Size(215, 251);
            this.listBox_present.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(337, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Present";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "->";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Not Present";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(390, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Learning_Center
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 347);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox_present);
            this.Controls.Add(this.button_notpresent);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_present);
            this.Controls.Add(this.listBox_students);
            this.Name = "Learning_Center";
            this.Text = "Learning_Center";
            this.Load += new System.EventHandler(this.Learning_Center_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_students;
        private System.Windows.Forms.Button button_present;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button_notpresent;
        private System.Windows.Forms.ListBox listBox_present;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}