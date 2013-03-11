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
    public partial class AddPass : Form
    {
        public AddPass()
        {
            InitializeComponent();
        }
        // globals
        globals global = new globals();

        private void button1_Click(object sender, EventArgs e)
        {
            Password pass = new Password();
            try
            {
                global.oleconnection.Open();
                OleDbDataAdapter adpt = new OleDbDataAdapter();
                adpt.UpdateCommand = new OleDbCommand("UPDATE `Teacher Info` SET email='" + textBox1.Text + "' WHERE teacherid='" + teacherid + "'", global.oleconnection);
                adpt.UpdateCommand.ExecuteNonQuery();
                pass.email = textBox1.Text;
                global.oleconnection.Close();
                this.Close();
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message, "Error");
            }
        }
    }
}
