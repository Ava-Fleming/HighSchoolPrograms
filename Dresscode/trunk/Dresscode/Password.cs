using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.OleDb;

namespace Dresscode
{
    public partial class Password : Form
    {
        public Password()
        {
            InitializeComponent();
        }
        //
        string oldPass;
        string SMTPHost;
        int Port;
        string host;
        string hostPass;
        string sendTo;
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        globals global = new globals();
        //

        private void Password_Load(object sender, EventArgs e)
        {
            //pull old info here.
            try
            {
                global.oleconnection.Open();
                OleDbCommand command = global.oleconnection.CreateCommand();
                command.CommandText = "SELECT * FROM `Email Settings`";
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    SMTPHost = reader["smtpserver"].ToString();
                    host = reader["hostemail"].ToString();
                    hostPass = reader["hostpassword"].ToString();
                    Port = int.Parse(reader["portnumber"].ToString());
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
        }

        private void linkLabel_forgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (textBox_teacherID.Text != "")
            {
                string message = "By clicking OK you confirm that you wish to have a new password emailed to you.";
                DialogResult dr = MessageBox.Show(message, "Password Reset", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        //database pull
                        global.oleconnection.Open();
                        OleDbCommand command = global.oleconnection.CreateCommand();
                        command.CommandText = "SELECT * FROM `Teacher Info` WHERE teacherid ='" + textBox_teacherID.Text + "'";
                        OleDbDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            sendTo = reader["email"].ToString();
                        }
                        if (sendTo == "" || sendTo == " ")
                        {
                            AddPass adp = new AddPass();
                            adp.teacherid = textBox_teacherID.Text;
                            adp.ShowDialog();
                            sendTo = email;
                        }
                        // email
                        SmtpClient sm = new SmtpClient(SMTPHost, Port);
                        sm.EnableSsl = false;
                        sm.Credentials = new NetworkCredential(host, hostPass);
                        MailAddress from = new MailAddress(host);
                        MailAddress to = new MailAddress(sendTo);
                        MailMessage mMsg = new MailMessage(from, to);
                        mMsg.Subject = "Dresscode Password Reset";
                        // password generator
                        Random rand = new Random();
                        string newPass = "";
                        for (int i = 0; i <= 8; i++)
                        {
                            if (rand.NextDouble() > 0.75)
                            {
                                newPass += rand.Next(10);
                            }
                            else
                            {
                                newPass += alphabet[rand.Next(26)];
                            }
                        }
                        //
                        mMsg.Body = "Your password has been changed to " + newPass + ".";
                        sm.Send(mMsg);

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
            }
            else
            {
                MessageBox.Show("You must enter your teacher ID first.");
            }
        }

        private void button_change_pass_Click(object sender, EventArgs e)
        {
            if (textBox_teacherID.Text != "")
            {
                if (oldPass == textBox_old_pass.Text)
                {
                    if (oldPass == textBox_old_pass.Text)
                    {
                        // NEST ALL THE STATMENTS \(@_@)
                    }
                    else
                    {
                        MessageBox.Show("You must enter your old password.");
                    }
                }
                else
                {
                    MessageBox.Show("You must enter your old password.");
                }
            }
            else
            {
                MessageBox.Show("You must enter your teacher ID first.");
            }
        }
    }
}
