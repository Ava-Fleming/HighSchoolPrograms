﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Globalization;

namespace Dresscode
{
    public partial class Student_Editor : Form
    {
        public Student_Editor()
        {
            InitializeComponent();
        }
        globals gl = new globals();
        DataTable dTable = new DataTable();
        BindingSource bSource = new BindingSource();

        private void textBox_studentID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bool goodop = false;
            DialogResult dr = MessageBox.Show("Warning, this will erase all current students and repopulate with the selected Excel spreadsheet\nMake sure the Excel document is formated in this order and format \"Student ID\" \"LastName\" \"FirstName\" \"Grade\"\nAll student Info must be on sheet1\nExcel document type: 97-2003 *.xls\nDo you want to continue?", "Verification", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dr2 = MessageBox.Show("Warning, this will erase all current students and repopulate with the selected Excel spreadsheet\nMake sure the Excel document is formated in this order\n\"Student ID\" \"LastName\" \"FirstName\" \"Grade\"\nThis will reappear and notify when the operation is completed\n5-10 minutes is required to complete this operation.\nDo you want to continue?", "Verification", MessageBoxButtons.YesNo);
                    if (dr2 == DialogResult.Yes)
                    {
                        try
                        {
                            this.Hide();
                            if (gl.oleconnection.State == ConnectionState.Open)
                                gl.oleconnection.Close();
                            System.Data.OleDb.OleDbConnection excelconnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + ofd.FileName + "';Extended Properties=Excel 8.0;");
                            System.Data.DataSet DtSet = new System.Data.DataSet();
                            System.Data.OleDb.OleDbDataAdapter oledbd_readexcel = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", excelconnection);
                            oledbd_readexcel.Fill(DtSet);
                            excelconnection.Close();
                            if(gl.oleconnection.State == ConnectionState.Closed) gl.oleconnection.Open();
                            DataTableReader dtr_excel = DtSet.CreateDataReader(DtSet.Tables[0]);
                            OleDbDataAdapter doledbAdapter = new OleDbDataAdapter();
                            string dsql = "DELETE * FROM `" + gl.tbl_studentinfo + "`";
                            doledbAdapter.InsertCommand = new OleDbCommand(dsql, gl.oleconnection);
                            doledbAdapter.InsertCommand.ExecuteNonQuery();
                            if(gl.oleconnection.State == ConnectionState.Open) gl.oleconnection.Close();
                            while (dtr_excel.Read())
                            {
                                if(gl.oleconnection.State == ConnectionState.Closed) gl.oleconnection.Open();
                                OleDbDataAdapter oledba_massadd = new OleDbDataAdapter();
                                string studentid = dtr_excel.GetValue(0).ToString();
                                string lastname = dtr_excel.GetValue(1).ToString();
                                string firstname = dtr_excel.GetValue(2).ToString();
                                string grade = dtr_excel.GetValue(3).ToString();
                                string sql = "INSERT INTO `" + gl.tbl_studentinfo + "` VALUES (@studentid,@lastname,@firstname,@grade)";
                                oledba_massadd.InsertCommand = new OleDbCommand(sql, gl.oleconnection);
                                oledba_massadd.InsertCommand.Parameters.Add("studentid", OleDbType.Numeric, 255).Value = studentid;
                                oledba_massadd.InsertCommand.Parameters.Add("lastname", OleDbType.VarChar, 255).Value = lastname;
                                oledba_massadd.InsertCommand.Parameters.Add("firstname", OleDbType.VarChar, 255).Value = firstname;
                                oledba_massadd.InsertCommand.Parameters.Add("grade", OleDbType.VarChar, 255).Value = grade;
                                oledba_massadd.InsertCommand.ExecuteNonQuery();
                                if(gl.oleconnection.State == ConnectionState.Open) gl.oleconnection.Close();
                            }
                            this.Show();
                            MessageBox.Show("Add students have been added successfully");
                            goodop = true;
                        }
                        catch (Exception ex)
                        {
                            this.Show();
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }
            if (!goodop)
                MessageBox.Show("Canceled", "Operation Status");
        }

        private void button_addstudent_Click(object sender, EventArgs e)
        {
            textBox_lastname.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBox_lastname.Text);
            textBox_firstname.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBox_firstname.Text);
            string lastname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBox_lastname.Text);
            string firstname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBox_firstname.Text);
            bool properinfo = false;
            if (lastname != "")
                if (firstname != "")
                    if (textBox_studentID.Text != "")
                        properinfo = true;
            if (properinfo)
            {
                try
                {
                    bool newentry = true;
                    if(gl.oleconnection.State == ConnectionState.Closed) gl.oleconnection.Open();
                    OleDbCommand checkforstudent = gl.oleconnection.CreateCommand();
                    checkforstudent.CommandText = "SELECT * FROM `"+gl.tbl_studentinfo+"`";
                    OleDbDataReader checkexistingstudent = checkforstudent.ExecuteReader();
                    while (checkexistingstudent.Read())
                    {
                        if (newentry == true)
                        {
                            if (textBox_studentID.Text.Contains(checkexistingstudent[gl.col_studentid].ToString()))
                            {
                                newentry = false;
                                break;
                            }
                        }
                    }
                    if(gl.oleconnection.State == ConnectionState.Open) gl.oleconnection.Close();
                    if (newentry)
                    {
                        DialogResult dr = MessageBox.Show("Is this correct?\nStudent ID: " + textBox_studentID.Text + "\nStudent Name: " + textBox_firstname.Text + " " + textBox_lastname.Text + "\nGrade: " + numericUpDown1.Value.ToString() + "", "Verification", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            if(gl.oleconnection.State == ConnectionState.Closed) gl.oleconnection.Open();
                            OleDbDataAdapter oledba_addstudent = new OleDbDataAdapter();
                            string sql = "INSERT INTO `" + gl.tbl_studentinfo + "` VALUES (@studentid,@lastname,@firstname,@grade)";
                            oledba_addstudent.InsertCommand = new OleDbCommand(sql, gl.oleconnection);
                            oledba_addstudent.InsertCommand.Parameters.Add("studentid", OleDbType.VarChar, 255).Value = textBox_studentID.Text;
                            oledba_addstudent.InsertCommand.Parameters.Add("lastname", OleDbType.VarChar, 255).Value = lastname;
                            oledba_addstudent.InsertCommand.Parameters.Add("firstname", OleDbType.VarChar, 255).Value = firstname;
                            oledba_addstudent.InsertCommand.Parameters.Add("grade", OleDbType.VarChar, 255).Value = int.Parse(numericUpDown1.Value.ToString());
                            oledba_addstudent.InsertCommand.ExecuteNonQuery();
                            MessageBox.Show("Student ID: " + textBox_studentID.Text + "\nStudent Name: " + textBox_firstname.Text + " " + textBox_lastname.Text + "\nGrade: " + numericUpDown1.Value.ToString() + "\nHas been successfully added to the student list.", "Success");
                            textBox_studentID.Text = "";
                            textBox_firstname.Text = "";
                            textBox_lastname.Text = "";
                            numericUpDown1.Value = 9;
                        }
                    }
                    else
                    {
                        if(gl.oleconnection.State == ConnectionState.Closed) gl.oleconnection.Open();
                        OleDbCommand getexisting = gl.oleconnection.CreateCommand();
                        getexisting.CommandText = "SELECT * FROM `"+gl.tbl_studentinfo+"` WHERE `"+gl.col_studentid+"`=@studentid";
                        getexisting.Parameters.AddWithValue("studentid", textBox_studentID.Text);
                        OleDbDataReader getexistingstudent = checkforstudent.ExecuteReader();
                        string efirst = "";
                        string elast = "";
                        string egrade = "";
                        while (getexistingstudent.Read())
                        {
                            if (textBox_studentID.Text.Contains(getexistingstudent[gl.col_studentid].ToString()))
                            {
                                efirst = getexistingstudent[gl.col_firstname].ToString();
                                elast = getexistingstudent[gl.col_lastname].ToString();
                                egrade = getexistingstudent[gl.col_grade].ToString();
                                break;
                            }
                        }
                        MessageBox.Show("The Student ID: " + textBox_studentID.Text + " already exists.\nExisting Student: " + efirst + " " + elast + "\nGrade: " + egrade);
                        if(gl.oleconnection.State == ConnectionState.Open)
                        gl.oleconnection.Close();
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "Error");
                }
                finally
                {
                    if (gl.oleconnection.State == ConnectionState.Open)
                        gl.oleconnection.Close();
                }
            }
            else
                MessageBox.Show("Something appears to be missing");
        }

        private void textBox_firstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.Handled = true;
        }

        private void textBox_lastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == ' ')
                e.Handled = true;
        }
    }
}