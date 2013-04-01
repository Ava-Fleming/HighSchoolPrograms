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
        // globals
        globals gl = new globals();

        private void button_saveemail_Click(object sender, EventArgs e)
        {
            Password pass = new Password();
            try
            {
                gl.oleconnection.Open();
                OleDbDataAdapter adpt = new OleDbDataAdapter();
                adpt.UpdateCommand = new OleDbCommand("UPDATE `"+ gl.tbl_teacherinfo + "` SET [" + gl.col_email + "]=@ema WHERE ["+ gl.col_teacherid+"]=@tid", gl.oleconnection);
                adpt.UpdateCommand.Parameters.Add("ema", OleDbType.VarChar, 255).Value = textbox_email.Text;
                adpt.UpdateCommand.Parameters.Add("tid", OleDbType.VarChar, 255).Value = teacherid;
                adpt.UpdateCommand.CommandType = CommandType.Text;
                adpt.UpdateCommand.ExecuteNonQuery();
                email = textbox_email.Text;
                gl.oleconnection.Close();
                this.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error");
            }
        }

        private void textbox_email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button_saveemail.PerformClick();
        }
    }
}
