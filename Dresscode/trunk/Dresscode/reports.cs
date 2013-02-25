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
    public partial class reports : Form
    {
        private OleDbDataAdapter dataadapter = null;
        private BindingSource bindingSource1 = new BindingSource();
        string sql = "";
        globals global = new globals();
        bool wtfbrah = true;
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
            int year =datetimepicker_date_start.Value.Date.Year;
            int month =datetimepicker_date_start.Value.Date.Month;
            int day =datetimepicker_date_start.Value.Date.Day;
            DateTime theDate = new DateTime(year,month,day);
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
                wtfbrah = false;
                if (hasStarted)
                    sql += " AND";
                //student name
                sql += " `First Name` = '" + comboBox_student_firstname + "' AND `Last Name` = '" + comboBox_student_last.Text + "'";
                hasStarted = true;
            }
            if (wtfbrah)
            {
                sql = "SELECT * FROM INFRACTIONS";
                
            }
            getinfractions();
        }
        public void getinfractions()
        {
            try
            {
                dataGridView_reports.DataSource = bindingSource1;
                // Specify a connection string. Replace the given value with a  
                // valid connection string for a Northwind SQL Server sample 
                // database accessible to your system.

                // Create a new data adapter based on the specified query.
                dataadapter = new OleDbDataAdapter(sql, global.oleconnection);

                // Create a command builder to generate SQL update, insert, and 
                // delete commands based on selectCommand. These are used to 
                // update the database.
                OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(dataadapter);


                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;

                dataadapter.Fill(table);

                bindingSource1.DataSource = table;
                // Resize the DataGridView columns to fit the newly loaded content.
                dataGridView_reports.Columns[0].Visible = false;
                dataGridView_reports.Columns[8].Visible = false;
                dataGridView_reports.Columns[6].Visible = false;
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
                dataadapter.Update((DataTable)bindingSource1.DataSource);
            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
            }
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //button_update.PerformClick();
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
    }
}
