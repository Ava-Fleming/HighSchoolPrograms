﻿using System;
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
using System.Security.Cryptography;
using System.Globalization;

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
        DataSet ds = new DataSet();
        private void button_addteacher_Click(object sender, EventArgs e)
        {
            bool legit = false;
            if (textbox_teacherid.Text != "")
                legit = true;
            else
                legit = false;
            if (textbox_lastname.Text != "")
                legit = true;
            else
                legit = false;
            if (textbox_firstname.Text != "")
                legit = true;
            else
                legit = false;
            if (textbox_email.Text != "")
                legit = true;
            else
                legit = false;

            if (legit)
            {
                try
                {
                    bool newuser = true;
                    if (gl.oleconnection.State == ConnectionState.Closed)
                    gl.oleconnection.Open();
                    OleDbCommand getteacherscommand = gl.oleconnection.CreateCommand();
                    getteacherscommand.CommandText = "SELECT * FROM `"+gl.tbl_teacherinfo+"` WHERE `"+gl.col_teacherid+"`=@tid";
                    getteacherscommand.Parameters.Add("tid", OleDbType.VarChar, 255).Value = textbox_teacherid.Text;
                    getteacherscommand.CommandType = CommandType.Text;
                    OleDbDataReader getteacher = getteacherscommand.ExecuteReader();

                    while (getteacher.Read())
                        if (getteacher[gl.col_teacherid].ToString() == textbox_teacherid.Text)
                            newuser = false;
                    if(gl.oleconnection.State == ConnectionState.Open)
                        gl.oleconnection.Close();
                    if (newuser)
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
                                newPass += rand.Next(10);
                            else
                                newPass += alphabet[rand.Next(26)];
                        }
                        MD5 md51 = new MD5CryptoServiceProvider();
                        md51.ComputeHash(ASCIIEncoding.ASCII.GetBytes(newPass));
                        byte[] result1 = md51.Hash;
                        StringBuilder strBuilder1 = new StringBuilder();
                        for (int i = 0; i < result1.Length; i++)
                            strBuilder1.Append(result1[i].ToString("x2"));

                        //database
                        if (gl.oleconnection.State == ConnectionState.Closed)
                        gl.oleconnection.Open();
                        OleDbDataAdapter oledba_addstudent = new OleDbDataAdapter();
                        string sql = "INSERT INTO `"+gl.tbl_teacherinfo+"` VALUES (@teacherid,@password,@lastname,@firstname,@email,@admin)";
                        oledba_addstudent.InsertCommand = new OleDbCommand(sql, gl.oleconnection);
                        oledba_addstudent.InsertCommand.Parameters.Add("teacherid", OleDbType.VarChar, 255).Value = textbox_teacherid.Text;
                        oledba_addstudent.InsertCommand.Parameters.Add("password", OleDbType.VarChar, 255).Value = strBuilder1.ToString();
                        oledba_addstudent.InsertCommand.Parameters.Add("lastname", OleDbType.VarChar, 255).Value = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textbox_lastname.Text);
                        oledba_addstudent.InsertCommand.Parameters.Add("firstname", OleDbType.VarChar, 255).Value = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textbox_firstname.Text);
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
                        mMsg.Subject = "Dresscode User Creation";
                        mMsg.Body = "Hello " + textbox_firstname.Text + " " + textbox_lastname.Text + "\nYour Login information is, ID: \"" + textbox_teacherid.Text + "\" Password:\"" + newPass + "\".";
                        sm.Send(mMsg);
                        datagridupdate();
                        MessageBox.Show(textbox_firstname.Text + " " + textbox_lastname.Text + " was successfully added");
                        textbox_email.Clear();
                        textbox_firstname.Clear();
                        textbox_teacherid.Clear();
                        textbox_lastname.Clear();
                        checkbox_dean.Checked = false;
                    }
                    else
                        MessageBox.Show("The teacher ID: " + textbox_teacherid.Text + " is already in use.");
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
                finally
                {
                    if(gl.oleconnection.State == ConnectionState.Open)
                        gl.oleconnection.Close();
                }
            }
            else
                MessageBox.Show("Something appears to be empty");
        }

        private void Teacher_Editor_Load(object sender, EventArgs e)
        {
            try
            {
                if (gl.oleconnection.State == ConnectionState.Closed)
                gl.oleconnection.Open();
                OleDbCommand emailcommand = gl.oleconnection.CreateCommand();
                emailcommand.CommandText = "SELECT * FROM `"+gl.tbl_emailsettings+"`";
                OleDbDataReader emailreader = emailcommand.ExecuteReader();
                while (emailreader.Read())
                {
                    SMTPHost = emailreader[gl.col_smtpserver].ToString();
                    host = emailreader[gl.col_hostemail].ToString();
                    hostPass = emailreader[gl.col_hostpassword].ToString();
                    Port = int.Parse(emailreader[gl.col_portnumber].ToString());
                }
                datagridupdate();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            finally
            {
                if(gl.oleconnection.State == ConnectionState.Open)
                gl.oleconnection.Close();
            }
        }

        private void datagridview_teachers_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = false;
            DialogResult dr = MessageBox.Show("Are you sure you want to delete:\n" + datagridview_teachers[3, datagridview_teachers.CurrentCell.RowIndex].Value.ToString() + " " + datagridview_teachers[2, datagridview_teachers.CurrentCell.RowIndex].Value.ToString(), "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                gl.oleconnection.Open();
                OleDbDataAdapter adpt = new OleDbDataAdapter();
                adpt.DeleteCommand = new OleDbCommand("DELETE * FROM `"+gl.tbl_teacherinfo+"` WHERE `"+gl.col_teacherid+"`=@idnum", gl.oleconnection);
                adpt.DeleteCommand.Parameters.Add("@idnum", OleDbType.VarChar, 255).Value = datagridview_teachers[0, datagridview_teachers.CurrentCell.RowIndex].Value.ToString();
                adpt.DeleteCommand.CommandType = CommandType.Text;
                adpt.DeleteCommand.ExecuteNonQuery();
                gl.oleconnection.Close();
            }
        }
        public void datagridupdate()
        {
                DB_Interaction dbi = new DB_Interaction();
                dbi.dgvselectioncommand("SELECT * FROM `" + gl.tbl_teacherinfo + "`", "", "", "", this.Name, datagridview_teachers.Name);
        }
    }
}