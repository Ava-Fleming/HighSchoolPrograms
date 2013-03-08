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
    public partial class Student_Editor : Form
    {
        public Student_Editor()
        {
            InitializeComponent();
        }
        globals global = new globals();
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                global.oleconnection.Open();
                OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
                string sql = "INSERT INTO `Student Info` VALUES (" + textBox_studentID.Text + ",'" + textBox_lastname.Text + "','" + textBox_firstname.Text + "'," + int.Parse(numericUpDown1.Value.ToString()) + ")";
                oledbAdapter.InsertCommand = new OleDbCommand(sql, global.oleconnection);
                oledbAdapter.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error");
            }
            finally
            {
                global.oleconnection.Close();
            }
        }
    }
}
