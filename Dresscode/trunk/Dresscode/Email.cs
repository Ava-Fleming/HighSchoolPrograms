using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dresscode
{
    public partial class Email : Form
    {
        public Email()
        {
            InitializeComponent();
        }
        //globals
        bool editmode = false;
        //

        private void button_add_email_Click(object sender, EventArgs e)
        {
            bool exists = false;
            if (textBox_add_email.Text != "")
            {
                for (int i = 0; i < listBox_emails.Items.Count; i++)
                {
                    if (listBox_emails.Items[i].ToString() == textBox_add_email.Text)
                    {
                        MessageBox.Show("That email adress is already on the send list");
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                {
                    listBox_emails.Items.Add(textBox_add_email.Text);
                    textBox_add_email.Clear();
                }
            }
        }

        private void Email_Load(object sender, EventArgs e)
        {
            // pull old settings from database and set them here
                //hours for send time
                //minutes for send time
                //subject for email
                //hoste email adress
                //list of emails to populate the listbox
                //port
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            //http://msdn.microsoft.com/en-us/library/system.net.mail.smtpclient.aspx
        }

        private void button_remove_email_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete " + listBox_emails.SelectedItem.ToString() + "?", "Really Delete Email?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                listBox_emails.Items.Remove(listBox_emails.SelectedItem);
            }
        }

        private void button_edit_settings_Click(object sender, EventArgs e)
        {
            if (!editmode)
            {
                editmode = true;
                button_edit_settings.Text = "Done";
                numericUpDown_hours.Enabled = true;
                numericUpDown_minutes.Enabled = true;
                textBox_host_email.Enabled = true;
                textBox_email_subject.Enabled = true;
                numericUpDown_port.Enabled = true;
            }
            else
            {
                //add a method here that saves the changes to the database
                editmode = false;
                button_edit_settings.Text = "Edit Settings";
                numericUpDown_hours.Enabled = false;
                numericUpDown_minutes.Enabled = false;
                textBox_host_email.Enabled = false;
                textBox_email_subject.Enabled = false;
                numericUpDown_port.Enabled = false;
            }
        }
    }
}
