/*
 * Matt Fleming
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace votingsystem
{
    public partial class form_login : Form
    {
        public form_login()
        {
            InitializeComponent();
        }
        static connectioninfo conninfo = new connectioninfo();
        static form_vote frm_vote = new form_vote();
        static form_admin frm_admin = new form_admin();
        string voted = "";
        private void button_login_Click(object sender, EventArgs e)
        {
            if (textbox_username.Text != "" || textbox_password.Text != "" &&  !textbox_username.Text.Contains(' ') && !textbox_password.Text.Contains(' '))
            {
                string rank = "";
                frm_vote.username = textbox_username.Text;
                frm_vote.password = textbox_password.Text;
                string sqlcheckuser = "SELECT * FROM users WHERE username=@uname AND password=@pass";
                string sqlcheckadmin = "SELECT * FROM admins WHERE username=@uname AND password=@pass";
                try
                {
                    conninfo.oleconnection.Open();
                    OleDbCommand checkadmincommand = conninfo.oleconnection.CreateCommand();
                    checkadmincommand.CommandText = sqlcheckadmin;
                    checkadmincommand.Parameters.Add("uname", frm_vote.username);
                    checkadmincommand.Parameters.Add("pass", frm_vote.password);
                    OleDbDataReader checkadminr = checkadmincommand.ExecuteReader();
                    while (checkadminr.Read())
                    {
                        rank = checkadminr["username"].ToString();
                    }
                    if (rank != textbox_username.Text)
                    {
                        conninfo.oleconnection.Close();
                        conninfo.oleconnection.Open();
                        OleDbCommand sqlcheckuserCommand = conninfo.oleconnection.CreateCommand();
                        sqlcheckuserCommand.CommandText = sqlcheckuser;
                        sqlcheckuserCommand.Parameters.Add("uname", frm_vote.username);
                        sqlcheckuserCommand.Parameters.Add("pass", frm_vote.password);
                        OleDbDataReader sqlcheckvoted = sqlcheckuserCommand.ExecuteReader();
                        while (sqlcheckvoted.Read())
                        {
                            voted = sqlcheckvoted["voted"].ToString();
                        }
                    }
                }
                catch (Exception x) { MessageBox.Show(x.Message); }
                finally
                {
                    conninfo.oleconnection.Close();
                    if (rank != textbox_username.Text && voted == "no")
                    {
                        MessageBox.Show("You have not yet voted, Press ok and vote!", "Voting Status: Not Voted");
                        frm_vote.ShowDialog();
                    }
                    else
                    {
                        if (rank == textbox_username.Text)
                        {
                            frm_admin.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("My apologies, but your account does not exist or you have already voted, so kindly let the next person vote!", "Voting Status: Voted");
                        }
                    }
                    textbox_username.Text = "";
                    textbox_password.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Missing Username or Password");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //string notice = "Everything should work,\nSo far so good :)\nAny bugs found report back.\nONLY ADMINS MAY CLOSE THIS SYSTEM UNLESS CHANGED IN CODE.";
            //MessageBox.Show(notice, System.Windows.Forms.Application.ProductName.ToString() + " - " + System.Windows.Forms.Application.ProductVersion.ToString());
        }

        private void form_login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textbox_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_login.PerformClick();
            }
        }
    }
}
