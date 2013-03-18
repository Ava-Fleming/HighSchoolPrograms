using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net.Mail;
using System.Net;
namespace Dresscode
{
    public partial class Teacher_Editor : Form
    {
        public Teacher_Editor()
        {
            InitializeComponent();
        }
        globals gl = new globals();
        string SMTPHost;
        int Port;
        string host;
        string hostPass;
        string sendTo;
        private void button_addteacher_Click(object sender, EventArgs e)
        {
            try
            {
                //var initialization
                sendTo = textbox_email.Text;
                //pass gen
                string alphabet = "abcdefghijklmnopqrstuvwxyz";
                Random rand = new Random();
                String newPass = "";
                for (int i = 0; i < 8; i++)
                {
                    if (rand.NextDouble() > 0.50)
                    {
                        newPass += rand.Next(10);
                    }
                    else
                    {
                        newPass += alphabet[rand.Next(26)];
                    }
                }
                //database
                gl.oleconnection.Open();
                OleDbDataAdapter oledba_addstudent = new OleDbDataAdapter();
                string sql = "INSERT INTO `Teacher Info` VALUES (@teacherid,@password,@lastname,@firstname,@email,@admin)";
                oledba_addstudent.InsertCommand = new OleDbCommand(sql, gl.oleconnection);
                oledba_addstudent.InsertCommand.Parameters.Add("teacherid", OleDbType.VarChar, 255).Value = textbox_teacherid.Text;
                oledba_addstudent.InsertCommand.Parameters.Add("password", OleDbType.VarChar, 255).Value = newPass;
                oledba_addstudent.InsertCommand.Parameters.Add("lastname", OleDbType.VarChar, 255).Value = textbox_lastname.Text;
                oledba_addstudent.InsertCommand.Parameters.Add("firstname", OleDbType.VarChar, 255).Value = textbox_firstname.Text;
                oledba_addstudent.InsertCommand.Parameters.Add("email", OleDbType.VarChar, 255).Value = textbox_email.Text;

                if (checkbox_dean.Checked)
                {
                    oledba_addstudent.InsertCommand.Parameters.Add("admin", OleDbType.VarChar, 255).Value = "Yes";
                }
                else { oledba_addstudent.InsertCommand.Parameters.Add("admin", OleDbType.VarChar, 255).Value = ""; }
                oledba_addstudent.InsertCommand.ExecuteNonQuery();
                //email
                SmtpClient sm = new SmtpClient(SMTPHost, Port);
                sm.EnableSsl = false;
                sm.Credentials = new NetworkCredential(host, hostPass);
                MailAddress from = new MailAddress(host);
                MailAddress to = new MailAddress(sendTo);
                MailMessage mMsg = new MailMessage(from, to);
                mMsg.Subject = "Dresscode Password Reset";
                mMsg.Body = "Your Login information is, ID:\"" + textbox_teacherid.Text+"\" Password:\""+ newPass + "\".";
                sm.Send(mMsg);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            finally
            {
                gl.oleconnection.Close();
            }
        }

        private void Teacher_Editor_Load(object sender, EventArgs e)
        {
            try
            {
                gl.oleconnection.Open();
                OleDbCommand command = gl.oleconnection.CreateCommand();
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
                gl.oleconnection.Close();
            }
        }
    }
}
