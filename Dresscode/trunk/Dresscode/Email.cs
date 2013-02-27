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
        System.IO.StreamWriter SR;
        //textBox_console.Text += "\r\n";
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
                        textBox_console.Text += "That email adress is already on the send list \r\n";
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                {
                    listBox_emails.Items.Add(textBox_add_email.Text);
                    textBox_console.Text += "Added Email: " + textBox_add_email.Text +" \r\n";
                    textBox_add_email.Clear();
                }
            }
        }

        private void Email_Load(object sender, EventArgs e)
        {
            textBox_console.Text += "Initializing Settings from database.\r\n";
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
            textBox_console.Text += "Starting task\r\n";
        }

        private void button_remove_email_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete " + listBox_emails.SelectedItem.ToString() + "?", "Really Delete Email?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                textBox_console.Text += "Removed: "+ listBox_emails.SelectedItem +".\r\n";
                listBox_emails.Items.Remove(listBox_emails.SelectedItem);
            }
        }

        private void button_edit_settings_Click(object sender, EventArgs e)
        {
            if (!editmode)
            {
                textBox_console.Text += "Edit Mode Active\r\n";
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
                saveSettings();
                textBox_console.Text += "Edit Mode Disabled\r\n";
                editmode = false;
                button_edit_settings.Text = "Edit Settings";
                numericUpDown_hours.Enabled = false;
                numericUpDown_minutes.Enabled = false;
                textBox_host_email.Enabled = false;
                textBox_email_subject.Enabled = false;
                numericUpDown_port.Enabled = false;
            }
        }

        public void saveSettings()
        {
            //send new settings to database here.
            textBox_console.Text += "Send time set to "+ numericUpDown_hours.Value.ToString() +":"+ numericUpDown_minutes.Value.ToString() +"\r\n";
            textBox_console.Text += "Host email set to "+ textBox_host_email.Text +"\r\n";
            textBox_console.Text += "Email subject set to "+ textBox_email_subject.Text +"\r\n";
            textBox_console.Text += "Host email port set to "+ numericUpDown_port.Value.ToString() +"\r\n";
            textBox_console.Text += "Settings saved to database\r\n";
        }

        private void button_clear_console_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Really clear console?","Clear",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                textBox_console.Clear();
                textBox_console.Text += "Console Cleared.\r\n";
            }
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            //stop
            textBox_console.Text += "Stopping task\r\n";
        }

        private void button_save_console_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text document | *.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SR = new System.IO.StreamWriter(sfd.FileName);
                SR.WriteLine(textBox_console.Text);
                SR.Flush();
                SR.Close();
            }
        }
    }
}
