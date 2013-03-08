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

namespace Dresscode
{
    public partial class Password : Form
    {
        public Password()
        {
            InitializeComponent();
        }
        //
        string email;
        string oldPass;
        string SMTPHost;
        int Port;
        string host;
        string hostPass;
        string sendTo;
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        //

        private void Password_Load(object sender, EventArgs e)
        {
            //pull old info here.
            //also pull smtp info here.
        }

        private void linkLabel_forgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (textBox_teacherID.Text != "")
            {
                string message = "By clicking OK you conferm that this:\n" + email +
                    "\nis your email address and you wish to have a new password emailed to you.";
                DialogResult dr = MessageBox.Show(message, "Password Reset", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
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
                }
            }
            else
            {
                MessageBox.Show("You msut enter your teacher ID first.");
            }
        }
    }
}
