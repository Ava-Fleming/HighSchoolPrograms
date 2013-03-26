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
using System.Globalization;


namespace Dresscode
{
    public partial class Reports : Form
    {
        BindingSource bSource = new BindingSource();
        string sql = "", firstname, lastname, studentid;
        globals global = new globals();
        OleDbDataAdapter dAdapter;
        DataSet ds = new DataSet();
        bool wtfbrah = true;
        //
        int county = 0,
nineWeeksDatabase = 0,
currentNineWeeks = 0,
totalinfractions = 1;
        /**/
        DateTime
firstnineweeksstart,
firstnineweeksend,

secondtnineweeksstart,
secondnineweeksend,

thirdnineweeksstart,
thirdnineweeksend,

forthnineweeksstart,
forthnineweeksend;
        //
        public Reports()
        {
            InitializeComponent();
        }

        private void reports_Load(object sender, EventArgs e)
        {
            try
            {
                global.oleconnection.Open();
                OleDbCommand getdatescommand = global.oleconnection.CreateCommand();
                getdatescommand.CommandText = "SELECT * FROM `Nine Weeks Dates`";
                OleDbDataReader getdateinfo = getdatescommand.ExecuteReader();
                while (getdateinfo.Read())
                {
                    firstnineweeksstart = DateTime.Parse(getdateinfo["firstnineweeksstart"].ToString());
                    firstnineweeksend = DateTime.Parse(getdateinfo["firstnineweeksend"].ToString());

                    secondtnineweeksstart = DateTime.Parse(getdateinfo["secondnineweeksstart"].ToString());
                    secondnineweeksend = DateTime.Parse(getdateinfo["secondnineweeksend"].ToString());

                    thirdnineweeksstart = DateTime.Parse(getdateinfo["thirdnineweeksstart"].ToString());
                    thirdnineweeksend = DateTime.Parse(getdateinfo["thirdnineweeksend"].ToString());

                    forthnineweeksstart = DateTime.Parse(getdateinfo["forthnineweeksstart"].ToString());
                    forthnineweeksend = DateTime.Parse(getdateinfo["forthnineweeksend"].ToString());
                }
            }
            catch (Exception x) { MessageBox.Show(x.Message, "Error"); }
            finally { global.oleconnection.Close(); }

            try
            {
                global.oleconnection.Open();
                OleDbCommand getinfractioncommand = global.oleconnection.CreateCommand();
                getinfractioncommand.CommandText = "SELECT * FROM `Reports`";
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
                getinfractioncommand.CommandText = "SELECT * FROM `Infraction List`";
                OleDbDataReader getinfraction = getinfractioncommand.ExecuteReader();
                while (getinfraction.Read())
                {
                    comboBox_infraction_select.Items.Add(getinfraction["infractions"].ToString());
                }
            }
            catch (Exception x) { MessageBox.Show(x.Message, "Error"); }
            finally { global.oleconnection.Close(); }
        }
        public void getinfractions()
        {
            try
            {
                DB_Interaction dbi = new DB_Interaction();
                dbi.selectioncommand(sql,firstname,lastname,studentid, this.Name,dataGridView_reports.Name);

                global.oleconnection.Open();
                OleDbCommand getinfractioncommand = global.oleconnection.CreateCommand();
                getinfractioncommand.CommandText = sql;
                getinfractioncommand.Parameters.Add("firstname", OleDbType.VarChar, 255).Value = firstname;
                getinfractioncommand.Parameters.Add("lastname", OleDbType.VarChar, 255).Value = lastname;
                getinfractioncommand.CommandType = CommandType.Text;
                OleDbDataReader getinfraction = getinfractioncommand.ExecuteReader();
                while (getinfraction.Read())
                {
                    DateTime databasedate = DateTime.Parse(getinfraction["Report Date"].ToString());
                    if (databasedate >= firstnineweeksstart && databasedate <= firstnineweeksend)
                    {
                        nineWeeksDatabase = 1;
                    }
                    if (databasedate >= secondtnineweeksstart && databasedate <= secondnineweeksend)
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
                    if (DateTime.Today >= secondtnineweeksstart && DateTime.Today <= secondnineweeksend)
                    {
                        currentNineWeeks = 2;
                    }
                    if (DateTime.Today >= thirdnineweeksstart && DateTime.Today <= thirdnineweeksend)
                    {
                        currentNineWeeks = 3;
                    }
                    if (DateTime.Today >= forthnineweeksstart && DateTime.Today <= forthnineweeksend)
                    {
                        currentNineWeeks = 4;
                    }
                    if (currentNineWeeks == nineWeeksDatabase)
                    {
                        label_nineweeks.Text = "Infractions this 9 weeks: " + (county++).ToString();
                    }
                    label_total_reports.Text = "Total Infractions: " + (totalinfractions++).ToString();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            finally
            {
                global.oleconnection.Close();
            }
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
                datetimepicker_date_end.Enabled = true;
            }
            else
            {
                datetimepicker_date_end.Enabled = false;
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
                //dataGridView_reports.Rows[dataGridView_reports.Rows.Count - 1].Selected = false;

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            finally
            {
                global.oleconnection.Close();
            }
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
            OleDbCommand getstudentinfocommand = global.oleconnection.CreateCommand();
            int retrievalcode = 0;
            comboBox_student_firstname.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(comboBox_student_firstname.Text);
            comboBox_student_last.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(comboBox_student_last.Text);
            firstname = comboBox_student_firstname.Text;
            lastname = comboBox_student_last.Text;
            comboBox_student_firstname.Items.Clear();
            comboBox_student_last.Items.Clear();
            if (comboBox_student_firstname.Text == "" && comboBox_student_last.Text == "")
                retrievalcode = -1;
            if (comboBox_student_firstname.Text == "" && comboBox_student_last.Text != "")
            {
                retrievalcode = 0;
                getstudentinfocommand.CommandText = "SELECT * FROM `Student Info` WHERE `Last Name`=@lastname";
                getstudentinfocommand.Parameters.Add("lastname", OleDbType.VarChar, 255).Value = lastname;
            }
            if (comboBox_student_firstname.Text != "" && comboBox_student_last.Text == "")
            {
                retrievalcode = 1;
                getstudentinfocommand.CommandText = "SELECT * FROM `Student Info` WHERE `First Name`=@firstname";
                getstudentinfocommand.Parameters.Add("firstname", OleDbType.VarChar, 255).Value = firstname;
            }
            if (comboBox_student_last.Text != "" && comboBox_student_firstname.Text != "")
            {
                for (int i = 0; i < comboBox_student_firstname.Text.Length; i++)
                {
                    if (comboBox_student_firstname.Text[i] == ' ')
                    {
                        firstname = comboBox_student_firstname.Text.Substring(0, i);
                        studentid = comboBox_student_firstname.Text.Substring(i + 1, (comboBox_student_firstname.Text.Length - (i + 1)));
                    }
                }
                for (int i = 0; i < comboBox_student_last.Text.Length; i++)
                {
                    if (comboBox_student_last.Text[i] == ' ')
                    {
                        lastname = comboBox_student_last.Text.Substring(0, i);
                        studentid = comboBox_student_last.Text.Substring(i + 1, (comboBox_student_last.Text.Length - (i + 1)));
                    }
                }
                retrievalcode = 2;
                getstudentinfocommand.CommandText = "SELECT * FROM `Student Info` WHERE `First Name`=@firstname AND `Last Name`=@lastname";
                getstudentinfocommand.Parameters.Add("firstname", OleDbType.VarChar, 255).Value = firstname;
                getstudentinfocommand.Parameters.Add("lastname", OleDbType.VarChar, 255).Value = lastname;
            }
            try
            {
                global.oleconnection.Open();
                if (retrievalcode != -1)
                {
                    getstudentinfocommand.CommandType = CommandType.Text;
                    OleDbDataReader getstudentinfo = getstudentinfocommand.ExecuteReader();
                    while (getstudentinfo.Read())
                    {
                        if (retrievalcode == 0)
                        {
                            comboBox_student_firstname.Text = getstudentinfo["First Name"].ToString() + " " + getstudentinfo["Student ID"].ToString();
                            comboBox_student_firstname.Items.Add(getstudentinfo["First Name"].ToString() + " " + getstudentinfo["Student ID"].ToString());
                        }
                        if (retrievalcode == 1)
                        {
                            comboBox_student_last.Text = getstudentinfo["Last Name"].ToString() + " " + getstudentinfo["Student ID"].ToString();
                            comboBox_student_last.Items.Add(getstudentinfo["Last Name"].ToString() + " " + getstudentinfo["Student ID"].ToString());
                        }
                        if (retrievalcode == 2)
                        {
                            comboBox_student_last.Text = lastname + " " + getstudentinfo["Student ID"].ToString();
                            comboBox_student_last.Items.Add(lastname + " " + getstudentinfo["Student ID"].ToString());
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
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Document | *.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
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
                    ExcelApp.ActiveWorkbook.SaveCopyAs(sfd.FileName); //or .xlsx file, depending of the excel version of your system
                    ExcelApp.ActiveWorkbook.Saved = true;
                    ExcelApp.Quit();
                }
                else
                    MessageBox.Show("Your document was not exported", "Not exported");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void dataGridView_reports_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = false;
            DialogResult dr = MessageBox.Show("Are you sure you want to delete?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                global.oleconnection.Open();
                OleDbDataAdapter adpt = new OleDbDataAdapter();
                adpt.UpdateCommand = new OleDbCommand("DELETE * FROM Reports WHERE ID=@idnum", global.oleconnection);
                adpt.UpdateCommand.Parameters.Add("@idnum", OleDbType.VarChar, 255).Value = dataGridView_reports[0, dataGridView_reports.CurrentCell.RowIndex].Value.ToString();
                adpt.UpdateCommand.CommandType = CommandType.Text;
                adpt.UpdateCommand.ExecuteNonQuery();
                global.oleconnection.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_9weeksstart.Checked == true)
            {
                comboBox_9weeksstart.Enabled = true;
                checkBox_9weeksend.Enabled = true;
            }
            else
            {
                comboBox_9weeksstart.Enabled = false;
                checkBox_9weeksend.Checked = false;
                checkBox_9weeksend.Enabled = false;
                comboBox_9weeksend.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_9weeksend.Checked == true)
            {
                comboBox_9weeksend.Enabled = true;
                comboBox_9weeksend.Enabled = true;
            }
            else
            {
                comboBox_9weeksend.Enabled = false;
                comboBox_9weeksend.Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_semester.Checked)
                comboBox_semster.Enabled = true;
            else
                comboBox_semster.Enabled = false;
        }

        private void dataGridView_reports_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                global.oleconnection.Open();
                OleDbDataAdapter adpt = new OleDbDataAdapter();
                adpt.UpdateCommand = new OleDbCommand("UPDATE Reports SET [Dean Action]=@dean WHERE [ID]=@idnum", global.oleconnection);
                adpt.UpdateCommand.Parameters.Add("dean", OleDbType.VarChar, 255).Value = dataGridView_reports[11, dataGridView_reports.CurrentCell.RowIndex].Value.ToString();
                adpt.UpdateCommand.Parameters.Add("idnum", OleDbType.Guid, 255).Value = Guid.Parse(dataGridView_reports[0, dataGridView_reports.CurrentCell.RowIndex].Value.ToString());
                adpt.UpdateCommand.CommandType = CommandType.Text;
                adpt.UpdateCommand.ExecuteNonQuery();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            finally
            {
                global.oleconnection.Close();
            }
        }
        private void weeksDatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Nine_Weeks_Dates nwd = new Nine_Weeks_Dates();
            nwd.ShowDialog();
            this.Show();

        }

        private void teacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Teacher_Editor te = new Teacher_Editor();
            te.ShowDialog();
            this.Show();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Student_Editor se = new Student_Editor();
            se.ShowDialog();
            this.Show();
        }

        private void infractionsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Infractions_List il = new Infractions_List();
            il.ShowDialog();
            this.Show();
        }
        public void getquery()
        {
            if (int.Parse(datetimepicker_date_start.Value.Year.ToString()) <= int.Parse(datetimepicker_date_end.Value.Year.ToString()))
            {
                sql = "SELECT * FROM `Reports` WHERE";
                Boolean hasStarted = false;

                if (checkBox_date_single.Checked)
                {
                    wtfbrah = false;
                    if (checkBox_date_range.Checked)
                    {
                        if (hasStarted)
                            sql += " AND";
                        sql += " `Report Date` BETWEEN #" + datetimepicker_date_start.Value.ToShortDateString() + "# AND #" + datetimepicker_date_end.Value.ToShortDateString() + "#";
                        hasStarted = true;
                    }
                    else
                    {
                        if (hasStarted)
                            sql += " AND";
                        sql += " `Report Date` = #" + datetimepicker_date_start.Value.ToShortDateString() + "#";
                        hasStarted = true;
                    }
                }

                if (checkBox_teacher.Checked)
                {
                    if (combobox_teacher.Text != "")
                    {
                        wtfbrah = false;
                        if (hasStarted)
                            sql += " AND";
                        sql += " Teacher = '" + combobox_teacher.Text + "'";
                        hasStarted = true;
                    }
                    else
                    {
                        MessageBox.Show("Please select a teacher.");
                    }
                }
                if (checkBox_infraction.Checked)
                {
                    if (checkBox_infraction.Text != "")
                    {
                        wtfbrah = false;
                        if (hasStarted)
                            sql += " AND";
                        sql += " Infraction = '" + comboBox_infraction_select.Text + "'";
                        hasStarted = true;
                    }
                    else
                    {
                        MessageBox.Show("Please select the Infraction.");
                    }
                }
                if (checkBox_period_single.Checked)
                {
                    wtfbrah = false;
                    if (checkBox_period_range.Checked)
                    {
                        if (hasStarted)
                            sql += " AND";
                        sql += " Period BETWEEN " + numericUpDown_period_start.Value.ToString() + " AND " + numericUpDown_period_end.Value.ToString() + "";
                        hasStarted = true;
                    }
                    else
                    {
                        if (hasStarted)
                            sql += " AND";
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
                        sql += " Grade BETWEEN " + numericUpDown_grade_start.Value.ToString() + " AND " + numericUpDown_grade_end.Value.ToString() + "";
                        hasStarted = true;
                    }
                    else
                    {
                        if (hasStarted)
                            sql += " AND";
                        sql += " Grade = " + numericUpDown_grade_start.Value.ToString() + "";
                        hasStarted = true;
                    }
                }
                if (checkBox_student.Checked)
                {
                    getstudentinfo();
                    wtfbrah = false;
                    if (hasStarted)
                        sql += " AND";
                    for (int i = 0; i < comboBox_student_firstname.Text.Length; i++)
                    {
                        if (comboBox_student_firstname.Text[i] == ' ')
                        {
                            firstname = comboBox_student_firstname.Text.Substring(0, i);
                            studentid = comboBox_student_firstname.Text.Substring(i + 1, (comboBox_student_firstname.Text.Length - (i + 1)));
                        }
                    }
                    for (int i = 0; i < comboBox_student_last.Text.Length; i++)
                    {
                        if (comboBox_student_last.Text[i] == ' ')
                        {
                            lastname = comboBox_student_last.Text.Substring(0, i);
                            studentid = comboBox_student_last.Text.Substring(i + 1, (comboBox_student_last.Text.Length - (i + 1)));
                        }
                    }
                    sql += " `First Name`=@firstname AND `Last Name`=@lastname AND `Student ID`='" + studentid + "'";
                    hasStarted = true;
                }
                if (checkBox_9weeksstart.Checked)
                {
                    wtfbrah = false;
                    if (checkBox_9weeksend.Checked)
                    {
                        if (comboBox_9weeksstart.Text != "" && comboBox_9weeksend.Text != "")
                        {
                            if (hasStarted)
                                sql += " AND";
                            DateTime startdate = new DateTime();
                            DateTime enddate = new DateTime();
                            if (comboBox_9weeksstart.Text == "1st 9 weeks")
                            {
                                startdate = firstnineweeksstart;
                            }
                            if (comboBox_9weeksstart.Text == "2nd 9 weeks")
                            {
                                startdate = secondtnineweeksstart;
                            }
                            if (comboBox_9weeksstart.Text == "3rd 9 weeks")
                            {
                                startdate = thirdnineweeksstart;
                            }
                            if (comboBox_9weeksstart.Text == "4th 9 weeks")
                            {
                                enddate = forthnineweeksstart;
                            }
                            if (comboBox_9weeksend.Text == "1st 9 weeks")
                            {
                                enddate = firstnineweeksend;
                            }
                            if (comboBox_9weeksend.Text == "2nd 9 weeks")
                            {
                                enddate = secondnineweeksend;
                            }
                            if (comboBox_9weeksend.Text == "3rd 9 weeks")
                            {
                                enddate = thirdnineweeksend;
                            }
                            if (comboBox_9weeksend.Text == "4th 9 weeks")
                            {
                                enddate = forthnineweeksend;
                            }
                            sql += " `Report Date` BETWEEN #" + startdate + "# AND #" + enddate + "#";
                            hasStarted = true;
                        }
                            MessageBox.Show("Please select the 9 weeks for both.");
                    }
                    else
                    {
                        if (comboBox_9weeksstart.Text != "")
                        {
                            if (hasStarted)
                                sql += " AND";
                            if (comboBox_9weeksstart.Text == "1st 9 weeks")
                            {
                                sql += " `Report Date` BETWEEN #" + firstnineweeksstart + "# AND #" + firstnineweeksend + "#";
                            }
                            if (comboBox_9weeksstart.Text == "2nd 9 weeks")
                            {
                                sql += " `Report Date` BETWEEN #" + secondtnineweeksstart + "# AND #" + secondnineweeksend + "#";
                            }
                            if (comboBox_9weeksstart.Text == "3rd 9 weeks")
                            {
                                sql += " `Report Date` BETWEEN #" + thirdnineweeksstart + "# AND #" + thirdnineweeksend + "#";
                            }
                            if (comboBox_9weeksstart.Text == "4th 9 weeks")
                            {
                                sql += " `Report Date` BETWEEN #" + forthnineweeksstart + "# AND #" + forthnineweeksend + "#";
                            }
                            hasStarted = true;
                        }
                        else
                        {
                            MessageBox.Show("Please select the 9 weeks.");
                        }
                    }
                }
                if (checkBox_semester.Checked)
                {
                    if (comboBox_semster.Text != "")
                    {
                        wtfbrah = false;
                        if (hasStarted)
                            sql += " AND";
                        if (comboBox_semster.Text == "1st semester")
                            sql += " `Report Date` BETWEEN #" + firstnineweeksstart + "# AND #" + secondnineweeksend + "#";
                        if (comboBox_semster.Text == "2nd semester")
                            sql += " `Report Date` BETWEEN #" + thirdnineweeksstart + "# AND #" + forthnineweeksend + "#";
                        hasStarted = true;
                    }

                    else
                    {
                        MessageBox.Show("Please select the semester.");
                    }
                }
                if (wtfbrah)
                {
                    sql = "SELECT * FROM `Reports`";
                }
                dAdapter = new OleDbDataAdapter(sql, global.oleconnection);
                county = 1;
                totalinfractions = 1;
            }
            else
            {
                MessageBox.Show("The date range: " + datetimepicker_date_start.Value.Year.ToString() + "-" + datetimepicker_date_end.Value.Year.ToString() + " is not possible\nThe initial date can not be more than the ending date.");
            }
        }

        private void button_retrieve_Click(object sender, EventArgs e)
        {
            getquery();
            getinfractions();
        }
    }
}