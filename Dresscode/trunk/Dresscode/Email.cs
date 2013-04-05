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
        bool looping = false;
        StreamWriter SW;
        globals gl = new globals();
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
                        gl.oleconnection.Open();
                        OleDbDataAdapter oledbd_addemail = new OleDbDataAdapter();
                        string sql = "INSERT INTO `" + gl.tbl_mailinglist + "` VALUES (@email)";
                        oledbd_addemail.InsertCommand = new OleDbCommand(sql, gl.oleconnection);
                        oledbd_addemail.InsertCommand.Parameters.Add("email", OleDbType.VarChar, 255).Value = textBox_add_email.Text;
                        oledbd_addemail.InsertCommand.CommandType = CommandType.Text;
                        oledbd_addemail.InsertCommand.ExecuteNonQuery();
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
                        gl.oleconnection.Close();
                    }
                }
            }
        }

        private void Email_Load(object sender, EventArgs e)
        {
            textBox_console.Text += "Initializing Settings from database.\r\n";
            try
            {
                gl.oleconnection.Open();
                OleDbCommand oledbc_loadsettings = gl.oleconnection.CreateCommand();
                oledbc_loadsettings.CommandText = "SELECT * FROM `" + gl.tbl_emailsettings + "`";
                OleDbDataReader oledbdr_readersettings = oledbc_loadsettings.ExecuteReader();
                while (oledbdr_readersettings.Read())
                {
                    numericUpDown_hours.Value = int.Parse(oledbdr_readersettings[gl.col_timehour].ToString());
                    numericUpDown_minutes.Value = int.Parse(oledbdr_readersettings[gl.col_timeminute].ToString());
                    textBox_smtp.Text = oledbdr_readersettings[gl.col_smtpserver].ToString();
                    textBox_host_email.Text = oledbdr_readersettings[gl.col_hostemail].ToString();
                    textBox_email_password.Text = oledbdr_readersettings[gl.col_hostpassword].ToString();
                    textBox_email_subject.Text = oledbdr_readersettings[gl.col_emailsubject].ToString();
                    textBox_email_body.Text = oledbdr_readersettings[gl.col_emailbody].ToString();
                    numericUpDown_port.Value = int.Parse(oledbdr_readersettings[gl.col_portnumber].ToString());
                }
                gl.oleconnection.Close();
                gl.oleconnection.Open();
                OleDbCommand oledbc_reademailscommand = gl.oleconnection.CreateCommand();
                oledbc_reademailscommand.CommandText = "SELECT * FROM `" + gl.tbl_mailinglist + "`";
                OleDbDataReader oledbc_reademails = oledbc_reademailscommand.ExecuteReader();
                while (oledbc_reademails.Read())
                {
                    listBox_emails.Items.Add(oledbc_reademails[gl.col_emaillist].ToString());
                }
            }
            catch (Exception x)
            {
                textBox_console.Text += "Error Loading data from database! \r\n";
                MessageBox.Show(x.Message);
            }
            finally
            {
                gl.oleconnection.Close();
            }
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            textBox_console.Text += "Starting task...\r\n";
            looping = true;
            timer1.Enabled = true;
        }



        private void button_remove_email_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete " + listBox_emails.SelectedItem.ToString() + "?", "Really Delete Email?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    gl.oleconnection.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter();
                    string sql = "DELETE * FROM `" + gl.tbl_mailinglist + "` WHERE `" + gl.col_emaillist + "`=@demail";
                    adapter.InsertCommand = new OleDbCommand(sql, gl.oleconnection);
                    //adapter.InsertCommand.Parameters.Add(gl. listBox_emails.SelectedItem
                    adapter.InsertCommand.ExecuteNonQuery();
                    textBox_console.Text += "Removed: " + listBox_emails.SelectedItem + ".\r\n";
                    listBox_emails.Items.Remove(listBox_emails.SelectedItem);
                }
                catch (Exception x)
                {
                    textBox_console.Text += "Error Loading data from database! \r\n";
                    MessageBox.Show(x.Message);
                }
                finally
                {
                    gl.oleconnection.Close();
                }
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
                checkbox_showpassword.Enabled = true;
                timer1.Enabled = false;
                button_start.Enabled = false;
                button_stop.Enabled = false;
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
                checkbox_showpassword.Enabled = false;
                button_start.Enabled = true;
                button_stop.Enabled = true;
            }
        }

        public void saveSettings()
        {
            //send new settings to database here.
            try
            {
                gl.oleconnection.Open();
                OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
                string sql = "";
                sql = "UPDATE `" + gl.tbl_emailsettings + "` SET [" + gl.col_timehour + "]=@timehour, [" + gl.col_timeminute + "]=@timeminute";
                oledbAdapter.UpdateCommand = new OleDbCommand(sql, gl.oleconnection);
                oledbAdapter.UpdateCommand.Parameters.AddWithValue("timehour", numericUpDown_hours.Value.ToString());
                oledbAdapter.UpdateCommand.Parameters.AddWithValue("timeminute", numericUpDown_minutes.Value.ToString());
                oledbAdapter.UpdateCommand.ExecuteNonQuery();
                sql = "UPDATE `" + gl.tbl_emailsettings + "` SET [" + gl.col_smtpserver + "]=@smtpserver, [" + gl.col_portnumber + "]=@portnum";
                oledbAdapter.UpdateCommand = new OleDbCommand(sql, gl.oleconnection);
                oledbAdapter.UpdateCommand.Parameters.AddWithValue("smtpserver", textBox_smtp.Text);
                oledbAdapter.UpdateCommand.Parameters.AddWithValue("portnum", numericUpDown_port.Value.ToString());
                oledbAdapter.UpdateCommand.ExecuteNonQuery();
                sql = "UPDATE `" + gl.tbl_emailsettings + "` SET [" + gl.col_hostemail + "]=@hostmemail, [" + gl.col_hostpassword + "]=@hostpass, [" + gl.col_emailsubject + "]=@esubject, [" + gl.col_emailbody + "]=@ebody";
                oledbAdapter.UpdateCommand = new OleDbCommand(sql, gl.oleconnection);
                oledbAdapter.UpdateCommand.Parameters.AddWithValue("hostmemail", textBox_host_email.Text);
                oledbAdapter.UpdateCommand.Parameters.AddWithValue("hostpass", textBox_email_password.Text);
                oledbAdapter.UpdateCommand.Parameters.AddWithValue("esubject", textBox_email_subject.Text);
                oledbAdapter.UpdateCommand.Parameters.AddWithValue("ebody", textBox_email_body.Text);
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
                gl.oleconnection.Close();
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
            textBox_console.Text += "Stopping task.\r\n";
            looping = false;
            timer1.Enabled = false;
            button_start.Enabled = true;
            button_stop.Enabled = false;
        }

        private void button_save_console_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text document | *.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SW = new System.IO.StreamWriter(sfd.FileName);
                SW.WriteLine(textBox_console.Text);
                SW.Flush();
                SW.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button_start.Enabled = false;
            int hour = (int)numericUpDown_hours.Value;
            int min = (int)numericUpDown_minutes.Value;
            if (looping && System.DateTime.Now.Hour == hour && System.DateTime.Now.Minute == min)
            {
                looping = false;
                //--------Datagrid start ========
                string sql = "SELECT  * FROM `" + gl.tbl_reports + "` WHERE `" + gl.col_deanaction + "`='None'";
                DB_Interaction dbi = new DB_Interaction();
                dbi.dgvselectioncommand(sql,"","","","","",this.Name,dataGridView1.Name);

                //--------Datagrid stop ========
                //--Excel export ---
                try
                {
                    Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();

                    ExcelApp.Application.Workbooks.Add(Type.Missing);
                    ExcelApp.Columns.ColumnWidth = 15;
                    for (int i = 3; i < dataGridView1.Columns.Count + 1; i++) //4
                    {
                        ExcelApp.Cells[1, i - 2] = dataGridView1.Columns[i - 1].HeaderText; //1 3
                    }
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        for (int j = 2; j < dataGridView1.Columns.Count; j++) //3
                        {
                            ExcelApp.Cells[i + 2, j - 1] = dataGridView1.Rows[i].Cells[j].Value.ToString(); //2 2
                        }
                    }
                    ExcelApp.ActiveWorkbook.SaveCopyAs(AppDomain.CurrentDomain.BaseDirectory + "Report " + DateTime.Now.Date.Month + "-" + DateTime.Now.Date.Day + "-" + DateTime.Now.Date.Year + ".xlsx"); //or .xlsx file, depending of the excel version of your system
                    ExcelApp.ActiveWorkbook.Saved = true;
                    ExcelApp.Quit();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
                //--Excel export stop ----
                textBox_console.Text += "Applying SMTP settings...\r\n";
                String SMTPHost = textBox_smtp.Text;
                int Port = (int)numericUpDown_port.Value;

                try
                {
                    textBox_console.Text += "Sending email(s) with current settings...\r\n";
                    SmtpClient sm = new SmtpClient(SMTPHost, Port);
                    sm.EnableSsl = false;
                    sm.Credentials = new NetworkCredential(textBox_host_email.Text, textBox_email_password.Text);
                    MailAddress from = new MailAddress(textBox_host_email.Text);
                    for (int i = 0; i < listBox_emails.Items.Count; i++)
                    {
                        MailAddress to = new MailAddress(listBox_emails.Items[i].ToString());
                        MailMessage mMsg = new MailMessage(from, to);
                        mMsg.Subject = textBox_email_subject.Text;
                        mMsg.Body = textBox_email_body.Text;
                        Attachment att = new Attachment("Report " + DateTime.Now.Date.Month + "-" + DateTime.Now.Date.Day + "-" + DateTime.Now.Date.Year + ".xlsx");
                        mMsg.Attachments.Add(att);
                        sm.Send(mMsg);
                        textBox_console.Text += "Email sent to " + listBox_emails.Items[i].ToString() + "!\r\n";
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }
            if (looping == false && System.DateTime.Now.Hour == hour && System.DateTime.Now.Minute == min + 1)
                looping = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_showpassword.Checked)
                textBox_email_password.PasswordChar = (char)0;
            else
                textBox_email_password.PasswordChar = '*';
        }

        private void textBox_add_email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button_add_email.PerformClick();
        }
    }
}
