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
        OleDbDataAdapter dAdapter;
        DataTable dTable = new DataTable();
        OleDbCommandBuilder cBuilder;
        BindingSource bSource = new BindingSource();
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                bool newentry = true;
                global.oleconnection.Open();
                OleDbCommand getteacherscommand = global.oleconnection.CreateCommand();
                getteacherscommand.CommandText = "SELECT * FROM `Student Info` WHERE STUDENTID=" + textBox_studentID.Text + " AND FIRSTNAME='" + textBox_firstname.Text + "' AND LASTNAME='" + textBox_lastname.Text + "'";
                OleDbDataReader getteacher = getteacherscommand.ExecuteReader();
                while (getteacher.Read())
                {
                    if (newentry == true)
                    {

                        if (textBox_studentID.Text.Contains(getteacher["STUDENTID"].ToString()))
                        {

                            if (textBox_firstname.Text.Contains(getteacher["FIRSTNAME"].ToString()))
                            {
                                if (textBox_lastname.Text.Contains(getteacher["LASTNAME"].ToString()))
                                {
                                    newentry = false;
                                }
                            }
                        }
                    }
                }
                global.oleconnection.Close();
                if (newentry)
                {
                    DialogResult dr = MessageBox.Show("Is this correct?\nStudent ID: " + textBox_studentID.Text + "\nStudent Name: " + textBox_firstname.Text + " " + textBox_lastname.Text + "\nGrade: " + numericUpDown1.Value.ToString() + "", "Verification", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        global.oleconnection.Open();
                        OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
                        string sql = "INSERT INTO `Student Info` VALUES (" + textBox_studentID.Text + ",'" + textBox_lastname.Text + "','" + textBox_firstname.Text + "'," + int.Parse(numericUpDown1.Value.ToString()) + ")";
                        oledbAdapter.InsertCommand = new OleDbCommand(sql, global.oleconnection);
                        oledbAdapter.InsertCommand.ExecuteNonQuery();
                        MessageBox.Show("Student ID: " + textBox_studentID.Text + "\nStudent Name: " + textBox_firstname.Text + " " + textBox_lastname.Text + "\nGrade: " + numericUpDown1.Value.ToString() + "\nHas been successfully added to the student list.", "Success");
                        textBox_studentID.Text = "";
                        textBox_firstname.Text = "";
                        textBox_lastname.Text = "";
                        numericUpDown1.Value = 9;
                    }
                }
                else
                {
                    MessageBox.Show("The Student with the following information:\nStudent ID: " + textBox_studentID.Text + "\nStudent Name: " + textBox_firstname.Text + " " + textBox_lastname.Text + "\nGrade: " + numericUpDown1.Value.ToString() + "\nAlready exists");
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void textBox_studentID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}
