using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;


namespace Dresscode
{
    public partial class reports : Form
    {
        BindingSource bSource = new BindingSource();
        string sql = "";
        string findstudentinfo = null;
        globals global = new globals();
        OleDbDataAdapter dAdapter;
        DataTable dTable = new DataTable();
        OleDbCommandBuilder cBuilder;
        bool wtfbrah = true;
        //
        int county = 0,
nineWeeksDatabase = 0,
currentNineWeeks = 0,
currentDayOfYear = DateTime.Now.DayOfYear,
totalinfractions = 1,
            /**/
firstnineweeksstart = 0,
firstnineweeksend = 0,

secondtnineweeksstart = 0,
secondnineweeksend = 0,

thirdnineweeksstart = 0,
thirdnineweeksend = 0,

forthnineweeksstart = 0,
forthnineweeksend = 0,

summerstart = 0,
summerend = 0;
        //
        public reports()
        {
            InitializeComponent();
        }

        private void reports_Load(object sender, EventArgs e)
        {
            try
            {
                global.oleconnection.Open();
                OleDbCommand getdatescommand = global.oleconnection.CreateCommand();
                getdatescommand.CommandText = "SELECT * FROM DATES";
                OleDbDataReader getdateinfo = getdatescommand.ExecuteReader();
                while (getdateinfo.Read())
                {
                    firstnineweeksstart = int.Parse(getdateinfo["firstnineweeksstart"].ToString());
                    firstnineweeksend = int.Parse(getdateinfo["firstnineweeksend"].ToString());

                    secondtnineweeksstart = int.Parse(getdateinfo["secondnineweeksstart"].ToString());
                    secondnineweeksend = int.Parse(getdateinfo["secondnineweeksend"].ToString());

                    thirdnineweeksstart = int.Parse(getdateinfo["thirdnineweeksstart"].ToString());
                    thirdnineweeksend = int.Parse(getdateinfo["thridnineweeksend"].ToString());

                    forthnineweeksstart = int.Parse(getdateinfo["forthnineweeksstart"].ToString());
                    forthnineweeksend = int.Parse(getdateinfo["forthnineweeksend"].ToString());

                    summerstart = int.Parse(getdateinfo["summerstart"].ToString());
                    summerend = int.Parse(getdateinfo["summerend"].ToString());
                }
            }
            catch (Exception x) { MessageBox.Show(x.Message, "Error"); }
            finally { global.oleconnection.Close(); }

            try
            {
                global.oleconnection.Open();
                OleDbCommand getinfractioncommand = global.oleconnection.CreateCommand();
                getinfractioncommand.CommandText = "SELECT * FROM INFRACTIONS";
                OleDbDataReader getinfraction = getinfractioncommand.ExecuteReader();
                while (getinfraction.Read())
                {
                    if (!combobox_teacher.Items.Contains(getinfraction["Teacher"].ToString()))
                    {
                        combobox_teacher.Items.Add(getinfraction["Teacher"].ToString());
                    }
                }
            }
            catch (Exception x) { MessageBox.Show(x.Message, "Error"); }
            finally { global.oleconnection.Close(); }

            try
            {
                global.oleconnection.Open();
                OleDbCommand getinfractioncommand = global.oleconnection.CreateCommand();
                getinfractioncommand.CommandText = "SELECT * FROM settings";
                OleDbDataReader getinfraction = getinfractioncommand.ExecuteReader();
                while (getinfraction.Read())
                {
                    comboBox_infraction_select.Items.Add(getinfraction["infractions"].ToString());
                }
            }
            catch (Exception x) { MessageBox.Show(x.Message, "Error"); }
            finally { global.oleconnection.Close(); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sql = "SELECT * FROM INFRACTIONS WHERE";
            Boolean hasStarted = false;
            //
            int year = datetimepicker_date_start.Value.Date.Year;
            int month = datetimepicker_date_start.Value.Date.Month;
            int day = datetimepicker_date_start.Value.Date.Day;
            DateTime theDate = new DateTime(year, month, day);
            int startdate = theDate.DayOfYear;
            year = dateTimePicker_end_date.Value.Date.Year;
            month = dateTimePicker_end_date.Value.Date.Month;
            day = dateTimePicker_end_date.Value.Date.Day;
            theDate = new DateTime(year, month, day);
            int enddate = theDate.DayOfYear;

            if (checkBox_date_single.Checked)
            {
                wtfbrah = false;
                if (checkBox_date_range.Checked)
                {
                    if (hasStarted)
                        sql += " AND";
                    //sql = "SELECT * FROM INFRACTIONS WHERE dayofyear >= " + startdate + " AND dayofyear <= " + enddate + "";
                    sql += " dayofyear >= " + startdate + " AND dayofyear <= " + enddate + "";
                    hasStarted = true;
                }
                else
                {
                    if (hasStarted)
                        sql += " AND";
                    //sql = "SELECT * FROM INFRACTIONS WHERE dayofyear >= " + startdate + "";
                    sql += " dayofyear = " + startdate + "";
                    hasStarted = true;
                }
            }

            if (checkBox_teacher.Checked)
            {
                wtfbrah = false;
                if (hasStarted)
                    sql += " AND";
                //sql = "SELECT * FROM INFRACTIONS WHERE teachername = '" + combobox_teacher.Text + "'";
                sql += " Teacher = '" + combobox_teacher.Text + "'";
                hasStarted = true;
            }
            if (checkBox_infraction.Checked)
            {
                wtfbrah = false;
                if (hasStarted)
                    sql += " AND";
                //sql = "SELECT * FROM INFRACTIONS WHERE infraction = '" + comboBox_infraction_select.Text + "'";
                sql += " Infraction = '" + comboBox_infraction_select.Text + "'";
                hasStarted = true;
            }
            if (checkBox_period_single.Checked)
            {
                wtfbrah = false;
                if (checkBox_period_range.Checked)
                {
                    if (hasStarted)
                        sql += " AND";
                    //sql = "SELECT * FROM INFRACTIONS WHERE PERIOD >= " + numericUpDown_period_start.Value.ToString() + " AND PERIOD <= " + numericUpDown_period_end.Value.ToString() + "";
                    sql += " Period >= " + numericUpDown_period_start.Value.ToString() + " AND Period <= " + numericUpDown_period_end.Value.ToString() + "";
                    hasStarted = true;
                }
                else
                {
                    if (hasStarted)
                        sql += " AND";
                    //sql = "SELECT * FROM INFRACTIONS WHERE PERIOD = " + numericUpDown_period_start.Value.ToString() + "";
                    sql += " Period = " + numericUpDown_period_start.Value.ToString() + "";
                    hasStarted = true;
                }
            }
            if (checkBox_grade_single.Checked)
            {
                wtfbrah = false;
                if (checkBox_grade_range.Checked)
                {
                    if (hasStarted)
                        sql += " AND";
                    //sql = "SELECT * FROM INFRACTIONS WHERE PERIOD >= " + numericUpDown_period_start.Value.ToString() + " AND PERIOD <= " + numericUpDown_period_end.Value.ToString() + "";
                    sql += " Grade >= '" + numericUpDown_grade_start.Value.ToString() + "' AND Grade <= '" + numericUpDown_grade_end.Value.ToString() + "'";
                    hasStarted = true;
                }
                else
                {
                    if (hasStarted)
                        sql += " AND";
                    //sql = "SELECT * FROM INFRACTIONS WHERE PERIOD = " + numericUpDown_period_start.Value.ToString() + "";
                    sql += " Grade = '" + numericUpDown_grade_start.Value.ToString() + "'";
                    hasStarted = true;
                }
            }
            if (checkBox_student.Checked)
            {

                getstudentinfo();
                wtfbrah = false;
                if (hasStarted)
                    sql += " AND";
                //student name
                sql += " `First Name` = '" + comboBox_student_firstname.Text + "' AND `Last Name` = '" + comboBox_student_last.Text + "'";
                hasStarted = true;
            }
            if (wtfbrah)
            {
                sql = "SELECT * FROM INFRACTIONS";

            }
            dAdapter = new OleDbDataAdapter(sql, global.oleconnection);
            getinfractions();
        }
        public void getinfractions()
        {
            try
            {
                dTable.Rows.Clear();

                cBuilder = new OleDbCommandBuilder(dAdapter);
                cBuilder.QuotePrefix = "[";
                cBuilder.QuoteSuffix = "]";

                dAdapter.Fill(dTable);
                bSource.DataSource = dTable;
                dataGridView_reports.DataSource = bSource;
                for (int i = 0; i <= 11; i++)
                {
                    if (i <= 3)
                        dataGridView_reports.Columns[i].Visible = false;
                    dataGridView_reports.Columns[i].ReadOnly = true;
                }
                dataGridView_reports.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error");
            }
            finally
            {
                global.oleconnection.Close();
                wtfbrah = true;
            }
            try
            {
                global.oleconnection.Open();
                OleDbCommand getinfractioncommand = global.oleconnection.CreateCommand();
                getinfractioncommand.CommandText = sql;
                OleDbDataReader getinfraction = getinfractioncommand.ExecuteReader();
                while (getinfraction.Read())
                {
                    DateTime theDate = new DateTime(2013, 1, 1).AddDays(int.Parse(getinfraction["dayofyear"].ToString()) - 1);
                    //MessageBox.Show();
                    int databasedate = int.Parse(getinfraction["dayofyear"].ToString());
                    if (databasedate >= firstnineweeksstart && databasedate <= firstnineweeksend)
                    {
                        nineWeeksDatabase = 1;
                    }
                    if (databasedate >= secondtnineweeksstart || databasedate <= secondnineweeksend)
                    {
                        nineWeeksDatabase = 2;
                    }
                    if (databasedate >= thirdnineweeksstart && databasedate <= thirdnineweeksend)
                    {
                        nineWeeksDatabase = 3;
                    }
                    if (databasedate >= forthnineweeksstart && databasedate <= forthnineweeksend)
                    {
                        nineWeeksDatabase = 4;
                    }
                    if (currentDayOfYear >= secondtnineweeksstart || currentDayOfYear <= secondnineweeksend)
                    {
                        currentNineWeeks = 2;
                    }
                    if (currentDayOfYear >= thirdnineweeksstart && currentDayOfYear <= thirdnineweeksend)
                    {
                        currentNineWeeks = 3;
                    }
                    if (currentDayOfYear >= forthnineweeksstart && currentDayOfYear <= forthnineweeksend)
                    {
                        currentNineWeeks = 4;
                    }
                    if (currentNineWeeks == nineWeeksDatabase)
                    {
                        county++;
                        label_nineweeks.Text = "Infractions this 9 weeks: " + county;
                    }
                    label_total_reports.Text = "Total Infractions: " + (totalinfractions++);
                }
            }
            catch (Exception x)
            {

            }
            finally
            {
                global.oleconnection.Close();
            }
        }

        private void groupBox_search_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox_date_single_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_date_single.Checked == true)
            {
                datetimepicker_date_start.Enabled = true;
                checkBox_date_range.Enabled = true;
            }
            else
            {
                datetimepicker_date_start.Enabled = false;
                checkBox_date_range.Enabled = false;
                checkBox_date_range.Checked = false;
            }
        }

        private void checkBox_date_range_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_date_range.Checked == true)
            {
                dateTimePicker_end_date.Enabled = true;
            }
            else
            {
                dateTimePicker_end_date.Enabled = false;
            }
        }

        private void checkBox_teacher_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_teacher.Checked == true)
            {
                combobox_teacher.Enabled = true;
            }
            else
            {
                combobox_teacher.Enabled = false;
                combobox_teacher.Text = "";
            }
        }

        private void checkBox_infraction_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_infraction.Checked == true)
            {
                comboBox_infraction_select.Enabled = true;
            }
            else
            {
                comboBox_infraction_select.Enabled = false;
            }
        }

        private void checkBox_period_range_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_period_range.Checked == true)
            {
                numericUpDown_period_end.Enabled = true;
            }
            else
            {
                numericUpDown_period_end.Enabled = false;
            }
        }

        private void checkBox_period_single_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_period_single.Checked == true)
            {
                numericUpDown_period_start.Enabled = true;
                checkBox_period_range.Enabled = true;
            }
            else
            {
                numericUpDown_period_start.Enabled = false;
                checkBox_period_range.Enabled = false;
                checkBox_period_range.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                dAdapter.Update(dTable);
            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
            }
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            button_update.PerformClick();
        }

        private void checkBox_grade_single_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_grade_single.Checked == true)
            {
                numericUpDown_grade_start.Enabled = true;
                checkBox_grade_range.Enabled = true;
            }
            else
            {
                numericUpDown_grade_start.Enabled = false;
                checkBox_grade_range.Enabled = false;
                checkBox_grade_range.Checked = false;
            }
        }

        private void checkBox_grade_range_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_grade_range.Checked == true)
            {
                numericUpDown_grade_end.Enabled = true;
            }
            else
            {
                numericUpDown_grade_end.Enabled = false;
            }
        }

        private void checkBox_student_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_student.Checked == true)
            {
                comboBox_student_firstname.Enabled = true;
                comboBox_student_last.Enabled = true;
            }
            else
            {
                comboBox_student_firstname.Enabled = false;
                comboBox_student_last.Enabled = false;
            }
        }
        private void comboBox_student_last_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                getstudentinfo();
        }

        private void comboBox_student_firstname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                getstudentinfo();
        }

        public void getstudentinfo()
        {
            int retrievalcode = 0;
            findstudentinfo = null;
            if (comboBox_student_firstname.Text == "" && comboBox_student_last.Text == "")
                retrievalcode = -1;
            if (comboBox_student_firstname.Text == "" && comboBox_student_last.Text != "")
            {
                retrievalcode = 0;
                findstudentinfo = "SELECT * FROM STUDENTINFO WHERE LASTNAME='" + comboBox_student_last.Text + "'";
            }
            if (comboBox_student_firstname.Text != "" && comboBox_student_last.Text == "")
            {
                retrievalcode = 1;
                findstudentinfo = "SELECT * FROM STUDENTINFO WHERE FIRSTNAME='" + comboBox_student_firstname.Text + "'";
            }
            if (comboBox_student_last.Text != "" && comboBox_student_firstname.Text != "")
            {
                retrievalcode = 2;
                findstudentinfo = "SELECT * FROM STUDENTINFO WHERE FIRSTNAME='" + comboBox_student_firstname.Text + "' AND LASTNAME='" + comboBox_student_last.Text + "'";
            }
            try
            {
                global.oleconnection.Open();
                if (retrievalcode != -1)
                {
                    OleDbCommand getstudentinfocommand = global.oleconnection.CreateCommand();
                    getstudentinfocommand.CommandText = findstudentinfo;
                    OleDbDataReader getstudentinfo = getstudentinfocommand.ExecuteReader();
                    while (getstudentinfo.Read())
                    {
                        if (retrievalcode == 0)
                        {
                            comboBox_student_firstname.Text = getstudentinfo["FIRSTNAME"].ToString();
                            comboBox_student_firstname.Items.Add(getstudentinfo["FIRSTNAME"].ToString());
                        }
                        if (retrievalcode == 1)
                        {
                            comboBox_student_last.Text = getstudentinfo["LASTNAME"].ToString();
                            comboBox_student_last.Items.Add(getstudentinfo["LASTNAME"].ToString());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter a first or last name", "Missing Name");
                }
            }
            catch (Exception x) { MessageBox.Show(x.Message, "Error"); }
            finally { global.oleconnection.Close(); }
        }

        private void button_export_excel_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();

                ExcelApp.Application.Workbooks.Add(Type.Missing);
                ExcelApp.Columns.ColumnWidth = 15;
                for (int i = 4; i < dataGridView_reports.Columns.Count + 1; i++)
                {
                    ExcelApp.Cells[1, i - 3] = dataGridView_reports.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView_reports.Rows.Count - 1; i++)
                {
                    for (int j = 3; j < dataGridView_reports.Columns.Count; j++)
                    {
                        ExcelApp.Cells[i + 2, j - 2] = dataGridView_reports.Rows[i].Cells[j].Value.ToString();
                    }
                }
                SaveFileDialog sfd = new SaveFileDialog();
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExcelApp.ActiveWorkbook.SaveCopyAs(sfd.FileName); //or .xlsx file, depending of the excel version of your system
                    ExcelApp.ActiveWorkbook.Saved = true;
                }
                else
                {
                    ExcelApp.ActiveWorkbook.Saved = false;
                }
                ExcelApp.Quit();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
