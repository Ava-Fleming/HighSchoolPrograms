using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/**/
using System.Data.OleDb;
using System.Globalization;

namespace Dresscode
{
    public partial class Teacher : Form
    {
        public Teacher()
        {
            InitializeComponent();
        }
        /**/
        globals gl = new globals();
        DB_Interaction dbi = new DB_Interaction();
        private BindingSource bindingSource1 = new BindingSource();
        /**/
        string
            /*Student info*/
            studentid = "",
            firstname = "",
            lastname = "",
            grade = "",
            /*Teacher info*/
            period = "",
            infraction = "",
            details = "";
        /**/
        int county = 0,
        nineWeeksDatabase = 0,
        currentNineWeeks = 0,
        currentDayOfYear = DateTime.Now.DayOfYear,
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

        Boolean submitted = false;
        string sql = "";
        public void retrieval()
        {
            OleDbCommand getstudentinfocommand = gl.oleconnection.CreateCommand();
            for (int i = 0; i < lastname.Length; i++)
            {
                if (lastname[i].ToString() == "'")
                    lastname = lastname.Replace("'", " ");
            }
            for (int i = 0; i < firstname.Length; i++)
            {
                if (firstname[i].ToString() == "'")
                    firstname = firstname.Replace("'", " ");
            }
            label_totalinfractions.Text = "Total Infractions: 0";
            #region Getbasicstudentinfo
            int retrievalcode = 0;
            firstname = combobox_firstname.Text;
            lastname = combobox_lastname.Text;
            sql = "SELECT * FROM `"+gl.tbl_studentinfo+"`";
            if (combobox_firstname.Text == "" && combobox_lastname.Text == "")
                retrievalcode = -1;
            if (combobox_firstname.Text == "" && combobox_lastname.Text != "")
            {
                retrievalcode = 0;
                sql += " WHERE `"+gl.col_lastname+"`=@lastname";
                getstudentinfocommand.Parameters.Add("lastname", OleDbType.VarChar, 255).Value = combobox_lastname.Text;
            }
            if (combobox_firstname.Text != "" && combobox_lastname.Text == "")
            {
                retrievalcode = 1;
                sql += " WHERE `"+gl.col_firstname+"`=@firstname";
                getstudentinfocommand.Parameters.Add("firstname", OleDbType.VarChar, 255).Value = combobox_firstname.Text;
            }
            if (combobox_lastname.Text != "" && combobox_firstname.Text != "")
            {
                firstname = combobox_firstname.Text;
                lastname = combobox_lastname.Text;
                retrievalcode = 2;
                sql += " WHERE `"+gl.col_firstname+"`=@firstname AND `"+gl.col_lastname+"`=@lastname";
                getstudentinfocommand.Parameters.Add("firstname", OleDbType.VarChar, 255).Value = combobox_firstname.Text;
                getstudentinfocommand.Parameters.Add("lastname", OleDbType.VarChar, 255).Value = combobox_lastname.Text;
            }
            try
            {
                if(gl.oleconnection.State == ConnectionState.Closed) gl.oleconnection.Open();
                if (retrievalcode != -1)
                {
                    getstudentinfocommand.CommandText = sql;
                    getstudentinfocommand.Parameters.Add("firstname", OleDbType.VarChar, 255).Value = combobox_firstname.Text;
                    getstudentinfocommand.Parameters.Add("lastname", OleDbType.VarChar, 255).Value = combobox_lastname.Text;
                    getstudentinfocommand.CommandType = CommandType.Text;
                    OleDbDataReader getstudentinfo = getstudentinfocommand.ExecuteReader();
                    while (getstudentinfo.Read())
                    {
                        studentid = getstudentinfo[gl.col_studentid].ToString();
                        firstname = getstudentinfo[gl.col_firstname].ToString();
                        lastname = getstudentinfo[gl.col_lastname].ToString();
                        grade = getstudentinfo[gl.col_grade].ToString();
                        if (retrievalcode == 0)
                        {
                            combobox_firstname.Text = firstname + " " + studentid;
                            combobox_firstname.Items.Add(firstname + " " + studentid);

                        }
                        if (retrievalcode == 1)
                        {
                            combobox_lastname.Text = lastname + " " + studentid;
                            combobox_lastname.Items.Add(lastname + " " + studentid);
                        }
                        if (retrievalcode == 2)
                        {
                            combobox_lastname.Text = lastname + " " + studentid;
                            combobox_lastname.Items.Add(lastname + " " + studentid);
                        }
                    }
                }
            }
            catch (Exception x) { MessageBox.Show(x.Message, "Error"); }
            finally { if(gl.oleconnection.State == ConnectionState.Open) gl.oleconnection.Close(); }
            #endregion
            for (int i = 0; i < combobox_firstname.Text.Length; i++)
            {
                if (combobox_firstname.Text[i] == ' ')
                {
                    firstname = combobox_firstname.Text.Substring(0, i);
                    studentid = combobox_firstname.Text.Substring(i+1, (combobox_firstname.Text.Length - (i+1)));
                }
            }
            for (int i = 0; i < combobox_lastname.Text.Length; i++)
            {
                if (combobox_lastname.Text[i] == ' ')
                {
                    lastname = combobox_lastname.Text.Substring(0, i);
                    studentid = combobox_lastname.Text.Substring(i+1, (combobox_lastname.Text.Length - (i+1)));
                }
            }

            if (studentid != "")
            {
                #region getinfractions
                try
                {

                    if(gl.oleconnection.State == ConnectionState.Closed) gl.oleconnection.Open();
                    OleDbCommand recheck = gl.oleconnection.CreateCommand();
                    recheck.CommandText = "SELECT * FROM `"+ gl.tbl_studentinfo +"` WHERE `"+gl.col_firstname+"`=@firstname AND `"+ gl.col_lastname +"`=@lastname AND `"+gl.col_studentid+"`=@studentid";
                    recheck.Parameters.Add("firstname", OleDbType.VarChar, 255).Value = firstname;
                    recheck.Parameters.Add("lastname", OleDbType.VarChar, 255).Value = lastname;
                    recheck.Parameters.Add("studentid", OleDbType.VarChar, 255).Value = studentid;
                    OleDbDataReader recheckreader = recheck.ExecuteReader();
                    while (recheckreader.Read())
                    {
                        lastname = recheckreader[gl.col_lastname].ToString();
                        firstname = recheckreader[gl.col_firstname].ToString();
                        grade = recheckreader[gl.col_grade].ToString();
                    }
                    if(gl.oleconnection.State == ConnectionState.Open) gl.oleconnection.Close();

                    if(gl.oleconnection.State == ConnectionState.Closed) gl.oleconnection.Open();
                    county = 0;
                    totalinfractions = 1;
                    nineWeeksDatabase = 0;
                    currentNineWeeks = 0;
                    currentDayOfYear = DateTime.Now.DayOfYear;
                    OleDbCommand getinfractioncommand = gl.oleconnection.CreateCommand();
                    string reportsstring = "SELECT * FROM `"+gl.tbl_reports+"` WHERE `"+gl.col_firstname+"`=@firstname AND `"+ gl.col_lastname +"`=@lastname AND `"+gl.col_studentid+"`=@studentid";
                    getinfractioncommand.CommandText = reportsstring;
                    getinfractioncommand.Parameters.Add("firstname", OleDbType.VarChar, 255).Value = firstname;
                    getinfractioncommand.Parameters.Add("lastname", OleDbType.VarChar, 255).Value = lastname;
                    getinfractioncommand.Parameters.Add("studentid", OleDbType.VarChar, 255).Value = studentid;
                    OleDbDataReader getinfraction = getinfractioncommand.ExecuteReader();
                    while (getinfraction.Read())
                    {
                        DateTime databasedate = DateTime.Parse(getinfraction["Report Date"].ToString());
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
                        if (DateTime.Today >= secondtnineweeksstart || DateTime.Today <= secondnineweeksend)
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
                            county++;
                            label_nineweeksinfractions.Text = "Infractions this 9 weeks: " + county;
                        }
                        label_totalinfractions.Text = "Total Infractions: " + (totalinfractions++);
                    }
                    if (submitted && county >= 5)
                    {
                        MessageBox.Show("A referal is required for this report.", "Referal Required");
                        submitted = false;
                    }
                    DB_Interaction dbi = new DB_Interaction();
                    dbi.dgvselectioncommand(reportsstring, firstname, lastname, studentid,"","", this.Name, dataGridView_students.Name);
                }
                catch (Exception x) { MessageBox.Show(x.Message, "Error"); }
                finally { if(gl.oleconnection.State == ConnectionState.Open) gl.oleconnection.Close(); }
                #endregion
            }
            else
                MessageBox.Show("Student: \"" + firstname + " " + lastname + "\" does not exist\nContact Administration", "Error");
        }

        private void button_retrieve_Click(object sender, EventArgs e)
        {
            studentid = "";
            firstname = "";
            lastname = "";
            grade = "";
            combobox_firstname.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(combobox_firstname.Text);
            combobox_lastname.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(combobox_lastname.Text);
            firstname = combobox_firstname.Text;
            lastname = combobox_lastname.Text;
            combobox_lastname.Items.Clear();
            combobox_firstname.Items.Clear();
            retrieval();
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
            if (combobox_period.Text == "")
                MessageBox.Show("Pick a period", "Period Required");
            else
            {
                button_retrieve.PerformClick();
                if (studentid != "")
                {
                    if (textbox_details.Text != "Details")
                        details = textbox_details.Text;
                    else
                        details = "N/A";

                    period = combobox_period.Text;
                    infraction = combobox_infraction.Text;
                    if (infraction != "")
                    {
                        DialogResult verification = MessageBox.Show("Is this correct?\nStudent Name: " + firstname + " " + lastname + "\nGrade: " + grade + "\nStudent ID: " + studentid + "\nPeriod: #" + period + "\nInfractured by: (" + teacherid + ") " + teacherfirstname + " " + teacherlastname + "\nDate: " + DateTime.Now.ToShortDateString() + "\nInfraction: " + infraction + "\nDetails: " + details, "Verify your infraction", MessageBoxButtons.YesNo);
                        if (verification == DialogResult.Yes)
                        {
                            try
                            {
                                if(gl.oleconnection.State == ConnectionState.Closed) gl.oleconnection.Open();
                                string sql = null;
                                sql = "INSERT INTO `" + gl.tbl_reports + "` VALUES ('" + 0 + "',@teacherid,@studentid,@firstname,@lastname,'" + grade + "','" + period + "',@teacher,'" + DateTime.Now.ToShortDateString() + "',@infraction,@details,'None',NULL)";
                                dbi.dbcommands(sql, this.Name, teacherid, firstname, lastname, studentid, teacherlastname + "," + teacherfirstname, infraction, details, "", "");
                                submitted = true;

                            }
                            catch (Exception x)
                            {
                                MessageBox.Show(x.Message);
                            }
                            finally
                            {
                                button_retrieve.PerformClick();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Select The Infraction. You monster", "Missing Infraction.");
                    }
                }
            }
        }

        private void form_dresscode_Load(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
            menuStrip1.Enabled = false;
            button_clear.PerformClick();
            if (admin)
            {
                menuStrip1.Enabled = true;
                menuStrip1.Visible = true;
            }
            combobox_firstname.Focus();
            try
            {
                if(gl.oleconnection.State == ConnectionState.Closed) gl.oleconnection.Open();
                OleDbCommand getdatescommand = gl.oleconnection.CreateCommand();
                getdatescommand.CommandText = "SELECT * FROM `" + gl.tbl_nineweeksdates + "`";
                OleDbDataReader getdateinfo = getdatescommand.ExecuteReader();
                while (getdateinfo.Read())
                {
                    firstnineweeksstart = DateTime.Parse(getdateinfo[gl.col_firstnineweeksstart].ToString());
                    firstnineweeksend = DateTime.Parse(getdateinfo[gl.col_firstnineweeksend].ToString());

                    secondtnineweeksstart = DateTime.Parse(getdateinfo[gl.col_secondnineweeksstart].ToString());
                    secondnineweeksend = DateTime.Parse(getdateinfo[gl.col_secondnineweeksend].ToString());

                    thirdnineweeksstart = DateTime.Parse(getdateinfo[gl.col_thirdnineweeksstart].ToString());
                    thirdnineweeksend = DateTime.Parse(getdateinfo[gl.col_thirdnineweeksend].ToString());

                    forthnineweeksstart = DateTime.Parse(getdateinfo[gl.col_forthnineweeksstart].ToString());
                    forthnineweeksend = DateTime.Parse(getdateinfo[gl.col_forthnineweeksend].ToString());
                }
            }
            catch (Exception x) { MessageBox.Show(x.Message, "Error"); }
            finally { if(gl.oleconnection.State == ConnectionState.Open) gl.oleconnection.Close(); }
            label_teacherid.Text = "Teacher ID: " + teacherid;
            label_date.Text += DateTime.Now.ToShortDateString();
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            dataGridView_students.DataSource = null;
            combobox_firstname.Text = "";
            combobox_period.Items.Clear();
            for (int i = 1; i <= gl.num_periods; i++)
                combobox_period.Items.Add(i.ToString());
            combobox_lastname.Text = "";
            textbox_details.Clear();
            combobox_firstname.Items.Clear();
            combobox_lastname.Items.Clear();
            combobox_infraction.Items.Clear();
            label_nineweeksinfractions.Text = "Infractions this 9 weeks: 0";
            label_totalinfractions.Text = "Total Infractions: 0";
            combobox_period.Text = "Period";
            textbox_details.Text = "Details";
            try
            {
                sql = "SELECT * FROM `"+gl.tbl_infractionlist+"`";
                if(gl.oleconnection.State == ConnectionState.Closed) gl.oleconnection.Open();
                OleDbCommand getpossibleinfractionscommand = gl.oleconnection.CreateCommand();
                getpossibleinfractionscommand.CommandText = sql;
                OleDbDataReader getpossibleinfractions = getpossibleinfractionscommand.ExecuteReader();
                while (getpossibleinfractions.Read())
                {
                    combobox_infraction.Items.Add(getpossibleinfractions[gl.col_infractions].ToString());
                }
            }
            catch (Exception x) { MessageBox.Show(x.Message, "Error"); }
            finally { if(gl.oleconnection.State == ConnectionState.Open) gl.oleconnection.Close(); 
            }
        }
        
        private void textbox_details_TextChanged(object sender, EventArgs e)
        {
            if (textbox_details.Text.Length >= 256)
            {
                MessageBox.Show(teacherfirstname + " " + teacherlastname + "\nwhat are you doing?\n" + teacherlastname + " " + teacherfirstname + "\nSTAHP\n\nOnly 255 characters can be reported.", "Limited report characters");
                textbox_details.Text = textbox_details.Text.Remove(255);
            }
        }

        private void textbox_details_Click(object sender, EventArgs e)
        {
            if (textbox_details.Text == "Details")
            {
                textbox_details.Text = textbox_details.Text.Remove(0, textbox_details.Text.Length);
            }
        }
        private void textbox_details_Leave(object sender, EventArgs e)
        {
            if (textbox_details.Text == "")
            {
                textbox_details.Text = "Details";
            }
        }

        private void form_dresscode_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Goodbye.\nYou know, using this program just now taught a valuable lesson:\nthe best solution to a problem is usually the easiest one.\nAnd lets be honest, using the old dresscode system was hard.\nYou know what the old dresscode system used to be like?\nNo one could easily report students.\nReporting was bad until I showed up.\nIt's been fun, come back anytime. <3", "Closing");
            //MessageBox.Show("And when you close me i'll be Still Alive.\nStill Alive.\n\nGood bye.", "Still Alive");
            Application.Exit();
        }

        private void combobox_firstname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button_retrieve.PerformClick();
        }

        private void combobox_lastname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button_retrieve.PerformClick();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Reports report = new Reports();
                report.ShowDialog();
                this.Show();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}