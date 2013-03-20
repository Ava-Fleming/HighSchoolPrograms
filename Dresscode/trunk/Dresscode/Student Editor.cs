﻿using System;
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
        DataTable dTable = new DataTable();
        BindingSource bSource = new BindingSource();
        private void button2_Click(object sender, EventArgs e)
        {
            string lastname = textBox_lastname.Text;
            string firstname = textBox_firstname.Text;
            try
            {
                bool newentry = true;
                global.oleconnection.Open();
                OleDbCommand checkforstudent = global.oleconnection.CreateCommand();
                checkforstudent.CommandText = "SELECT * FROM `Student Info` WHERE STUDENTID=" + textBox_studentID.Text + " AND FIRSTNAME=@firstname AND LASTNAME=@lastname";
                checkforstudent.Parameters.Add("lastname", OleDbType.VarChar, 255).Value = lastname;
                checkforstudent.Parameters.Add("firstname", OleDbType.VarChar, 255).Value = firstname;
                OleDbDataReader checkexistingstudent = checkforstudent.ExecuteReader();
                while (checkexistingstudent.Read())
                {
                    if (newentry == true)
                    {

                        if (textBox_studentID.Text.Contains(checkexistingstudent["STUDENTID"].ToString()))
                        {

                            if (textBox_firstname.Text.Contains(checkexistingstudent["FIRSTNAME"].ToString()))
                            {
                                if (textBox_lastname.Text.Contains(checkexistingstudent["LASTNAME"].ToString()))
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
                        OleDbDataAdapter oledba_addstudent = new OleDbDataAdapter();
                        string sql = "INSERT INTO `Student Info` VALUES (" + textBox_studentID.Text + ",@lastname,@firstname," + int.Parse(numericUpDown1.Value.ToString()) + ")";
                        oledba_addstudent.InsertCommand = new OleDbCommand(sql, global.oleconnection);
                        oledba_addstudent.InsertCommand.Parameters.Add("lastname", OleDbType.VarChar, 255).Value = lastname;
                        oledba_addstudent.InsertCommand.Parameters.Add("firstname", OleDbType.VarChar, 255).Value = firstname;
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
            DialogResult dr = MessageBox.Show("Warning, this will erase all current students and repopulate with the selected Excel spreadsheet\nMake sure the Excel document is formated in this order and format \"Student ID\" \"LastName\" \"FirstName\" \"Grade\"\n\nExcel document type: 97-2003 *.xls\nDo you want to continue?", "Verification", MessageBoxButtons.YesNo);
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
                            if (global.oleconnection.State == ConnectionState.Open)
                                global.oleconnection.Close();
                            System.Data.OleDb.OleDbConnection excelconnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + ofd.FileName + "';Extended Properties=Excel 8.0;");
                            System.Data.DataSet DtSet = new System.Data.DataSet();
                            System.Data.OleDb.OleDbDataAdapter oledbd_readexcel = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", excelconnection);
                            //oledbd_readexcel.TableMappings.Add("Table", "TestTable");
                            oledbd_readexcel.Fill(DtSet);
                            excelconnection.Close();
                            global.oleconnection.Open();
                            DataTableReader dtr_excel = DtSet.CreateDataReader(DtSet.Tables[0]);
                            OleDbDataAdapter doledbAdapter = new OleDbDataAdapter();
                            string dsql = "DELETE * FROM `Student Info`";
                            doledbAdapter.InsertCommand = new OleDbCommand(dsql, global.oleconnection);
                            doledbAdapter.InsertCommand.ExecuteNonQuery();
                            global.oleconnection.Close();

                            //
                            while (dtr_excel.Read())
                            {
                                //MessageBox.Show(dtr.GetValue(0).ToString() + " " + dtr.GetValue(1).ToString() + " " + dtr.GetValue(2).ToString());
                                global.oleconnection.Open();
                                OleDbDataAdapter oledba_massadd = new OleDbDataAdapter();
                                string studentid = dtr_excel.GetValue(0).ToString();
                                string lastname = dtr_excel.GetValue(1).ToString();
                                string firstname = dtr_excel.GetValue(2).ToString();
                                string grade = dtr_excel.GetValue(3).ToString();
                                string sql = "INSERT INTO `Student Info` VALUES (" + studentid + ",@lastname,@firstname," + grade + ")";
                                oledba_massadd.InsertCommand = new OleDbCommand(sql, global.oleconnection);
                                oledba_massadd.InsertCommand.Parameters.Add("lastname", OleDbType.VarChar, 255).Value = lastname;
                                oledba_massadd.InsertCommand.Parameters.Add("firstname", OleDbType.VarChar, 255).Value = firstname;
                                oledba_massadd.InsertCommand.ExecuteNonQuery();
                                global.oleconnection.Close();
                            }
                            this.Show();
                            MessageBox.Show("Add students have been added successfully");
                        }
                        catch (Exception ex)
                        {
                            this.Show();
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    else
                        MessageBox.Show("Operation Canceled");
                }
                else
                MessageBox.Show("Operation Canceled");
            }
            else
                MessageBox.Show("Operation Canceled");
        }
    }
}