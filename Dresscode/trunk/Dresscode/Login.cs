using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Globalization;

namespace Dresscode
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        globals gl = new globals();
        
        bool real = false;
        bool relaunched = false;

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (relaunched == false)
            {
                MessageBox.Show("¡Adios! ~ Matt Fleming\nAu revoir! ~ Vincent Ragusa\nMUAHM! (Bye) ~ Ethan Kuell", "Good bye");
                Application.Exit();
            }
        }

        private void textbox_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button_login.PerformClick();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Password pass = new Password();
            pass.teacherid = textbox_teacherid.Text;
            pass.ShowDialog();
            this.Show();
            if (textbox_teacherid.Text == "")
                textbox_teacherid.Focus();
            else
                textbox_password.Focus();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            Teacher teachr = new Teacher();
            string teacherid = textbox_teacherid.Text;
            if (textbox_teacherid.Text == "ESYSTEM" && textbox_password.Text == "emailpassword")
            {
                this.Hide();
                Email ema = new Email();
                ema.ShowDialog();
                Application.Restart();
            }
            else
            {
                try
                {
                    teacherid = CultureInfo.CurrentCulture.TextInfo.ToLower(teacherid);
                    MD5 md5 = new MD5CryptoServiceProvider();
                    md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(textbox_password.Text));
                    byte[] result = md5.Hash;
                    StringBuilder hashedpassword = new StringBuilder();
                    for (int i = 0; i < result.Length; i++)
                        hashedpassword.Append(result[i].ToString("x2"));

                    if (gl.oleconnection.State == ConnectionState.Closed) gl.oleconnection.Open();
                    OleDbCommand getteacherscommand = gl.oleconnection.CreateCommand();
                    getteacherscommand.CommandText = "SELECT * FROM `" + gl.tbl_teacherinfo + "` WHERE `" + gl.col_teacherid + "`=@tid AND `" + gl.col_password + "`=@pass";
                    getteacherscommand.Parameters.Add("tid", OleDbType.VarChar, 255).Value = teacherid;
                    getteacherscommand.Parameters.Add("pass", OleDbType.VarChar, 255).Value = hashedpassword.ToString();
                    getteacherscommand.CommandType = CommandType.Text;
                    OleDbDataReader getteacher = getteacherscommand.ExecuteReader();

                    while (getteacher.Read())
                    {
                        if (real == false)
                        {

                            if (teacherid.Contains(getteacher[gl.col_teacherid].ToString()))
                            {
                                if (hashedpassword.ToString() == getteacher[gl.col_password].ToString())
                                {
                                    teachr.teacherfirstname = getteacher[gl.col_firstname].ToString();
                                    teachr.teacherlastname = getteacher[gl.col_lastname].ToString();
                                    teachr.teacherid = getteacher[gl.col_teacherid].ToString();
                                    if (getteacher[gl.col_dean].ToString() == CultureInfo.CurrentCulture.TextInfo.ToLower(gl.glt_isdean) || getteacher[gl.col_dean].ToString() == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(gl.glt_isdean))
                                        teachr.admin = true;
                                    real = true;
                                }
                            }
                        }
                    }
                }
                catch (Exception x) { MessageBox.Show(x.Message, "Error"); }
                finally
                {
                    if (gl.oleconnection.State == ConnectionState.Open) gl.oleconnection.Close();
                    if (real)
                    {
                        this.Hide();
                        teachr.ShowDialog();
                        Application.Restart();
                    }
                    else
                        MessageBox.Show("Check your user information", "Incorrect teacher I.D or Password");
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            relaunched = false;
        }
    }
}
