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
using System.Net;

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
                    try
                    {
                        global.oleconnection.Open();
                        OleDbDataAdapter adapter = new OleDbDataAdapter();
                        string sql = "INSERT INTO emails VALUES ('" + textBox_add_email.Text + "')";
                        adapter.InsertCommand = new OleDbCommand(sql, global.oleconnection);
                        adapter.InsertCommand.ExecuteNonQuery();
                        listBox_emails.Items.Add(textBox_add_email.Text);
                        textBox_console.Text += "Added Email: " + textBox_add_email.Text + " \r\n";
                        textBox_add_email.Clear();
                    }
                    catch (Exception x)
                    {
                        textBox_console.Text += "Error adding email! \r\n";
                        MessageBox.Show(x.Message);
                    }
                    finally
                    {
                        global.oleconnection.Close();
                    }
                }
            }
        }

        private void Email_Load(object sender, EventArgs e)
        {
            button_add_email.PerformClick();
            textBox_console.Text += "Initializing Settings from database.\r\n";
            try
            {
                global.oleconnection.Open();
                OleDbCommand command = global.oleconnection.CreateCommand();
                command.CommandText = "SELECT * FROM settings_email";
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    numericUpDown_hours.Value = int.Parse(reader["timehour"].ToString());
                    numericUpDown_minutes.Value = int.Parse(reader["timeminute"].ToString());
                    textBox_smtp.Text = reader["smtpserver"].ToString();
                    textBox_host_email.Text = reader["hostemail"].ToString();
                    textBox_email_password.Text = reader["hostpassword"].ToString();
                    textBox_email_subject.Text = reader["emailsubject"].ToString();
                    textBox_email_body.Text = reader["emailbody"].ToString();
                    numericUpDown_port.Value = int.Parse(reader["portnumber"].ToString());
                }
                global.oleconnection.Close();
                global.oleconnection.Open();
                command = global.oleconnection.CreateCommand();
                command.CommandText = "SELECT * FROM emails";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listBox_emails.Items.Add(reader["emaillist"].ToString());
                }
            }
            catch (Exception x)
            {
                textBox_console.Text += "Error Loading data from database! \r\n";
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
            textBox_console.Text += "Starting task...\r\n";

            textBox_console.Text += "Applying SMTP settings...\r\n";
            String SMTPHost =  textBox_smtp.Text;
            int Port = (int)numericUpDown_port.Value;

            try
            {
                textBox_console.Text += "Attempting to send email with current settings...\r\n";
                SmtpClient sm = new SmtpClient(SMTPHost, Port);
                sm.EnableSsl = true;
                sm.Credentials = new NetworkCredential("username", "password");//?
                MailAddress from = new MailAddress(textBox_host_email.Text);
                string strAddress="saKDLFHLASKJDF";
                MailAddress to = new MailAddress(strAddress); // use this with a 4 loop
                MailMessage mMsg = new MailMessage(from, to);
                mMsg.Subject = textBox_email_subject.Text;
                mMsg.Body = textBox_email_body.Text;
                sm.Send(mMsg);
                textBox_console.Text += "Email sent!\r\n";
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

        }



        private void button_remove_email_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete " + listBox_emails.SelectedItem.ToString() + "?", "Really Delete Email?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                textBox_console.Text += "Removed: " + listBox_emails.SelectedItem + ".\r\n";
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
                sql = "UPDATE settings_email SET timehour='" + numericUpDown_hours.Value.ToString() + "', timeminute='" + numericUpDown_minutes.Value.ToString() + "'";
                oledbAdapter.UpdateCommand = new OleDbCommand(sql, global.oleconnection);
                oledbAdapter.UpdateCommand.ExecuteNonQuery();
                sql = "UPDATE settings_email SET smtpserver='" + textBox_smtp.Text + "', portnumber='" + numericUpDown_port.Value.ToString() + "'";
                oledbAdapter.UpdateCommand = new OleDbCommand(sql, global.oleconnection);
                oledbAdapter.UpdateCommand.ExecuteNonQuery();

                sql = "UPDATE settings_email SET hostemail='" + textBox_smtp.Text + "', hostpassword='" + textBox_email_password.Text + "', emailsubject='" + textBox_email_subject.Text + "', emailbody='" + textBox_email_body.Text + "'";
                oledbAdapter.UpdateCommand = new OleDbCommand(sql, global.oleconnection);
                oledbAdapter.UpdateCommand.ExecuteNonQuery();
                //Console output.
                textBox_console.Text += "Send time set to " + numericUpDown_hours.Value.ToString() + ":" + numericUpDown_minutes.Value.ToString() + "\r\n";
                textBox_console.Text += "SMTP server set to " + textBox_smtp.Text + " AND SMTP port set to " + numericUpDown_port.Value.ToString() + "\r\n";
                textBox_console.Text += "Host email set to " + textBox_host_email.Text + " AND Email password set to " + textBox_email_password.Text + "\r\n";
                textBox_console.Text += "Email subject set to " + textBox_email_subject.Text + "\r\n";
                textBox_console.Text += "Email body set to " + textBox_email_body.Text + "\r\n";
                textBox_console.Text += "Settings saved to database\r\n";
            }
            catch (Exception x)
            {
                textBox_console.Text += "Error saving settings! \r\n";
                MessageBox.Show(x.Message);
            }
            finally
            {
                global.oleconnection.Close();
            }
        }

        private void button_clear_console_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Really clear console?", "Clear", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
