using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.Mail;
using System.Data.OleDb;

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
        StreamWriter SR;
        SmtpClient smtp;
        MailMessage message;
        AttachmentCollection AC;
        globals global = new globals();
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
            try
            {
                global.oleconnection.Open();
                OleDbCommand command = global.oleconnection.CreateCommand();
                command.CommandText = "SELECT * FROM settings_email";
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    numericUpDown_hours.Value = int.Parse(reader["time hour"].ToString());
                    numericUpDown_minutes.Value = int.Parse(reader["time minute"].ToString());
                    textBox_smtp.Text = reader["smtp server"].ToString();
                    textBox_host_email.Text = reader["host email"].ToString();
                    textBox_email_password.Text = reader["host password"].ToString();
                    textBox_email_subject.Text = reader["email subject"].ToString();
                    textBox_email_body.Text = reader["email body"].ToString();
                    numericUpDown_port.Value = int.Parse(reader["port number"].ToString());
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            finally
            {
                global.oleconnection.Close();
            }

                //list of emails to populate the listbox
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            //http://msdn.microsoft.com/en-us/library/system.net.mail.smtpclient.aspx

            textBox_console.Text += "Starting task...\r\n";

            textBox_console.Text += "Applying SMTP settings...\r\n";
            smtp = new SmtpClient(textBox_smtp.Text, (int)numericUpDown_port.Value);
            smtp.EnableSsl = false;
            textBox_console.Text += "Inserting Message...\r\n";
            string Esender;
            string Erecipients;
            string adshflakj;
            textBox_console.Text += "Email sent.\r\n";
            smtp.Send(message);
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
                textBox_console.Text += "Edit Mode Active.\r\n";
                editmode = true;
                button_edit_settings.Text = "Done";
                numericUpDown_hours.Enabled = true;
                numericUpDown_minutes.Enabled = true;
                textBox_host_email.Enabled = true;
                textBox_email_subject.Enabled = true;
                numericUpDown_port.Enabled = true;
                textBox_email_password.Enabled = true;
                textBox_smtp.Enabled = true;
                textBox_email_body.Enabled = true;
            }
            else
            {
                saveSettings();
                textBox_console.Text += "Edit Mode Disabled.\r\n";
                editmode = false;
                button_edit_settings.Text = "Edit Settings";
                numericUpDown_hours.Enabled = false;
                numericUpDown_minutes.Enabled = false;
                textBox_host_email.Enabled = false;
                textBox_email_subject.Enabled = false;
                numericUpDown_port.Enabled = false;
                textBox_email_password.Enabled = false;
                textBox_smtp.Enabled = false;
                textBox_email_body.Enabled = false;
            }
        }

        public void saveSettings()
        {
            //send new settings to database here.
            try
            {
                global.oleconnection.Open();
                OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
                string sql = "";
                sql = "UPDATE settings_email SET smtpserver=" + textBox_smtp.Text + "";
                oledbAdapter.UpdateCommand = new OleDbCommand(sql, global.oleconnection);
                oledbAdapter.UpdateCommand.ExecuteNonQuery();
                textBox_console.Text += "Send time set to " + numericUpDown_hours.Value.ToString() + ":" + numericUpDown_minutes.Value.ToString() + "\r\n";
                //Console output.
                
                textBox_console.Text += "SMTP server set to " + textBox_smtp.Text + "\r\n";
                textBox_console.Text += "SMTP port set to " + numericUpDown_port.Value.ToString() + "\r\n";
                textBox_console.Text += "Host email set to " + textBox_host_email.Text + "\r\n";
                textBox_console.Text += "Email password set to " + textBox_email_password.Text + "\r\n";
                textBox_console.Text += "Email subject set to " + textBox_email_subject.Text + "\r\n";
                textBox_console.Text += "Email body set to " + textBox_email_body.Text + "\r\n";
                textBox_console.Text += "Settings saved to database\r\n";
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            finally
            {
                global.oleconnection.Close();
            }
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
            textBox_console.Text += "Stopping task.\r\n";
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
