using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Dresscode
{
    public partial class AddEmail : Form
    {
        public AddEmail()
        {
            InitializeComponent();
        }
        //Password pass = new Password();
        globals gl = new globals();
        DB_Interaction dbi = new DB_Interaction();
        string sql = "";
        private void button_saveemail_Click(object sender, EventArgs e)
        {
            
            try
            {
                sql = "UPDATE `" + gl.tbl_teacherinfo + "` SET [" + gl.col_email + "]=@ema WHERE [" + gl.col_teacherid + "]=@tid";
                string[] pars = { "@ema", "@tid" };
                string[] values = { textbox_email.Text, teacherid };
                dbi.dbcommands(sql, pars, values);
                email = textbox_email.Text;
                gl.oleconnection.Close();
                this.Close();
            }
            catch (Exception x) { MessageBox.Show(x.Message, "Error"); }
            finally { if (gl.oleconnection.State == ConnectionState.Open) gl.oleconnection.Close(); }
        }

        private void textbox_email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button_saveemail.PerformClick();
        }
    }
}
