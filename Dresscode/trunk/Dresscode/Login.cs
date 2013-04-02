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
        Teacher frm_dresscode = new Teacher();
        bool real = false;

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("¡Adios! ~ Matt Fleming\nAu revoir! ~ Vincent Ragusa", "Good bye");
            Application.Exit();
        }

        private void textbox_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button_login.PerformClick();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Password pass = new Password();
            pass.ShowDialog();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            try
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                //compute hash from the bytes of text
                md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(textbox_password.Text));

                //get hash result after compute it
                byte[] result = md5.Hash;

                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    //change it into 2 hexadecimal digits
                    //for each byte
                    strBuilder.Append(result[i].ToString("x2"));
                }
                if (gl.oleconnection.State == ConnectionState.Closed)
                gl.oleconnection.Open();
                OleDbCommand getteacherscommand = gl.oleconnection.CreateCommand();
                getteacherscommand.CommandText = "SELECT * FROM `" + gl.tbl_teacherinfo + "` WHERE `" + gl.col_teacherid +"`=@tid AND `" + gl.col_password + "`=@pass";
                getteacherscommand.Parameters.Add("tid", OleDbType.VarChar, 255).Value = textbox_teacherid.Text;
                getteacherscommand.Parameters.Add("pass", OleDbType.VarChar, 255).Value = strBuilder.ToString();
                getteacherscommand.CommandType = CommandType.Text;
                OleDbDataReader getteacher = getteacherscommand.ExecuteReader();

                while (getteacher.Read())
                {
                    if (real == false)
                    {
                        if (textbox_teacherid.Text.Contains(getteacher[gl.col_teacherid].ToString()))
                        {
                            if (strBuilder.ToString() == getteacher[gl.col_password].ToString())
                            {
                                frm_dresscode.teacherfirstname = getteacher[gl.col_firstname].ToString();
                                frm_dresscode.teacherlastname = getteacher[gl.col_lastname].ToString();
                                frm_dresscode.teacherid = getteacher[gl.col_teacherid].ToString();
                                if (getteacher[gl.col_dean].ToString() == CultureInfo.CurrentCulture.TextInfo.ToLower(gl.glt_isdean) || getteacher[gl.col_dean].ToString() == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(gl.glt_isdean))
                                    frm_dresscode.admin = true;
                                real = true;
                            }
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error");
            }
            finally
            {
                if(gl.oleconnection.State == ConnectionState.Open)
                    gl.oleconnection.Close();
                if (real)
                {
                    frm_dresscode.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Check your user information", "Incorrect teacher I.D or Password");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
