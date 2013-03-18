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

namespace Dresscode
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        globals global = new globals();
        form_dresscode frm_dresscode = new form_dresscode();
        bool real = false;

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Adios!", "Good bye");
            Application.Exit();
        }

        private void textbox_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_login.PerformClick();
            }
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
                global.oleconnection.Open();
                OleDbCommand getteacherscommand = global.oleconnection.CreateCommand();
                getteacherscommand.CommandText = "SELECT * FROM `Teacher Info` WHERE `Teacher ID`=@tid AND Password=@pass";
                getteacherscommand.Parameters.Add("tid", OleDbType.VarChar, 255).Value = textbox_teacherid.Text;
                getteacherscommand.Parameters.Add("pass", OleDbType.VarChar, 255).Value = textbox_password.Text;
                getteacherscommand.CommandType = CommandType.Text;
                OleDbDataReader getteacher = getteacherscommand.ExecuteReader();
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

                while (getteacher.Read())
                {
                    if (real == false)
                    {
                        if (textbox_teacherid.Text.Contains(getteacher["Teacher ID"].ToString()))
                        {
                            if (strBuilder.ToString().Contains(getteacher["Password"].ToString()))
                            {
                                frm_dresscode.teacherfirstname = getteacher["First Name"].ToString();
                                frm_dresscode.teacherlastname = getteacher["Last Name"].ToString();
                                frm_dresscode.teacherid = getteacher["Teacher ID"].ToString();
                                if (getteacher["Dean"].ToString() == "yes" || getteacher["Dean"].ToString() == "Yes")
                                {
                                    frm_dresscode.admin = true;
                                }
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
                global.oleconnection.Close();
                if (real)
                {
                    frm_dresscode.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Check your user information", "Incorrect teacher I.D or Password");
            }
        }
    }
}
