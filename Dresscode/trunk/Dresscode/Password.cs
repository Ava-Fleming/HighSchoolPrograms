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
using System.Security.Cryptography;

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
        globals gl = new globals();
        DB_Interaction dbi = new DB_Interaction();
        //

        private void Password_Load(object sender, EventArgs e)
        {
            textBox_teacherID.Text = teacherid;
            //Get all email settings 
            try
            {
                if (gl.oleconnection.State == ConnectionState.Closed)
                    gl.oleconnection.Open();
                OleDbCommand command = gl.oleconnection.CreateCommand();
                command.CommandText = "SELECT * FROM `" + gl.tbl_emailsettings + "`";
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    SMTPHost = reader[gl.col_smtpserver].ToString();
                    host = reader[gl.col_hostemail].ToString();
                    hostPass = reader[gl.col_hostpassword].ToString();
                    Port = int.Parse(reader[gl.col_portnumber].ToString());
                }
            }
            catch (Exception x) {MessageBox.Show(x.Message);}
            finally { if (gl.oleconnection.State == ConnectionState.Open) gl.oleconnection.Close(); }
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
                        //Get email from DB
                        if (gl.oleconnection.State == ConnectionState.Closed)
                        gl.oleconnection.Open();
                        OleDbCommand command = gl.oleconnection.CreateCommand();
                        command.CommandText = "SELECT * FROM `"+ gl.tbl_teacherinfo +"` WHERE `"+ gl.col_teacherid +"`=@tid";
                        command.Parameters.AddWithValue("tid", textBox_teacherID.Text);
                        OleDbDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                            sendTo = reader[gl.col_email].ToString();
                        if (sendTo == "" || sendTo == " ")
                        {
                            AddEmail adp = new AddEmail();
                            adp.teacherid = textBox_teacherID.Text;
                            adp.ShowDialog();
                            sendTo = adp.email;
                        }
                        if (sendTo != null)
                        {
                            // password generator
                            Random rand = new Random();
                            String newPass = "";
                            for (int i = 0; i < 8; i++)
                            {
                                if (rand.NextDouble() > 0.50)
                                    newPass += rand.Next(10);
                                else
                                    newPass += alphabet[rand.Next(26)];
                            }
                            MD5 md5 = new MD5CryptoServiceProvider();
                            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(newPass));
                            byte[] result = md5.Hash;
                            StringBuilder strBuilder = new StringBuilder();
                            for (int i = 0; i < result.Length; i++)
                                strBuilder.Append(result[i].ToString("x2"));
                            //Set new [Random password] password.
                            string[] pars = { "@newpass", "@tid"};
                            string[] values = { strBuilder.ToString(), textBox_teacherID.Text };
                            dbi.dbcommands("UPDATE `" + gl.tbl_teacherinfo + "` SET [" + gl.col_password + "]=@newpass WHERE [" + gl.col_teacherid + "]=@tid", pars, values);
                            // email
                            SmtpClient sm = new SmtpClient(SMTPHost, Port);
                            sm.EnableSsl = false;
                            sm.Credentials = new NetworkCredential(host, hostPass);
                            MailAddress from = new MailAddress(host);
                            MailAddress to = new MailAddress(sendTo);
                            MailMessage mMsg = new MailMessage(from, to);
                            mMsg.Subject = "Dresscode Password Reset";
                            mMsg.Body = "Your password has been changed to \"" + newPass + "\".";
                            sm.Send(mMsg);
                        }
                        else
                            MessageBox.Show("The Teacher ID: " + textBox_teacherID.Text +" does not exist.", "ERROR");
                    }
                    catch (Exception x){ MessageBox.Show(x.Message); }
                    finally{ if (gl.oleconnection.State == ConnectionState.Open) gl.oleconnection.Close();}
                }
            }
            else
                MessageBox.Show("You must enter your teacher ID first.");
        }

        private void button_change_pass_Click(object sender, EventArgs e)
        {
            if (textBox_teacherID.Text != "")
            {
                if (gl.oleconnection.State == ConnectionState.Closed)
                gl.oleconnection.Open();
                OleDbCommand com = gl.oleconnection.CreateCommand();
                com.CommandText = "SELECT * FROM `"+gl.tbl_teacherinfo+"` WHERE `"+ gl.col_teacherid +"`=@tid";
                com.Parameters.Add("tid", OleDbType.VarChar, 255).Value = textBox_teacherID.Text;
                com.CommandType = CommandType.Text;
                OleDbDataReader read = com.ExecuteReader();
                while (read.Read())
                    oldPass = read[gl.col_password].ToString();
                if(gl.oleconnection.State == ConnectionState.Open) gl.oleconnection.Close();
                MD5 md5 = new MD5CryptoServiceProvider();
                md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(textBox_old_pass.Text));
                byte[] result = md5.Hash;
                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                    strBuilder.Append(result[i].ToString("x2"));
                if (oldPass == strBuilder.ToString())
                {
                    if (textBox_new_pass_first.Text != textBox_old_pass.Text)
                    {
                        if (textBox_new_pass_first.Text == textBox_new_pass_second.Text)
                        {
                            try
                            {
                                MD5 md51 = new MD5CryptoServiceProvider();
                                md51.ComputeHash(ASCIIEncoding.ASCII.GetBytes(textBox_new_pass_second.Text));
                                byte[] result1 = md51.Hash;
                                StringBuilder strBuilder1 = new StringBuilder();
                                for (int i = 0; i < result1.Length; i++)
                                    strBuilder1.Append(result1[i].ToString("x2"));

                                string[] pars = { "@pass", "@tid" };
                                string[] values = { strBuilder1.ToString(), textBox_teacherID.Text };
                                dbi.dbcommands("UPDATE `" + gl.tbl_teacherinfo + "` SET [" + gl.col_password + "]=@pass WHERE [" + gl.col_teacherid + "]=@tid", pars, values);
                                MessageBox.Show("Your password has been successfully updated", "Success!");
                                TextBox tb = Application.OpenForms["Login"].Controls["textbox_teacherid"] as TextBox;
                                tb.Text = textBox_teacherID.Text;
                                this.Close();
                            }
                            catch (Exception x) { MessageBox.Show(x.Message, "ERROR"); }

                        }
                        else
                            MessageBox.Show("Your new password must be the same in both boxes.");
                    }
                    else
                        MessageBox.Show("Your new password can not match your old one.");
                }
                else
                    MessageBox.Show("You must enter your old password.");
            }
            else
                MessageBox.Show("You must enter your teacher ID first.");
        }
    }
}
