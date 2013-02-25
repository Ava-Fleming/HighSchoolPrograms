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

namespace Dresscode
{
    public partial class form_dresscode : Form
    {
        public form_dresscode()
        {
            InitializeComponent();
        }
        /**/
        globals global = new globals();
        private OleDbDataAdapter dataadapter = null;
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

        Boolean submitted = false;
        string sql = "";
        public void retrieval()
        {
            combobox_firstname.Items.Clear();
            combobox_lastname.Items.Clear();
            label_totalinfractions.Text = "Total Infractions: 0";
            #region Getbasicstudentinfo
            int retrievalcode = 0;
            if (combobox_firstname.Text == "" && combobox_lastname.Text == "")
                retrievalcode = -1;
            if (combobox_firstname.Text == "" && combobox_lastname.Text != "")
            {
                retrievalcode = 0;
                sql = "SELECT * FROM STUDENTINFO WHERE LASTNAME='" + combobox_lastname.Text + "'";
            }
            if (combobox_firstname.Text != "" && combobox_lastname.Text == "")
            {
                retrievalcode = 1;
                sql = "SELECT * FROM STUDENTINFO WHERE FIRSTNAME='" + combobox_firstname.Text + "'";
            }
            if (combobox_lastname.Text != "" && combobox_firstname.Text != "")
            {
                retrievalcode = 2;
                sql = "SELECT * FROM STUDENTINFO WHERE FIRSTNAME='" + combobox_firstname.Text + "' AND LASTNAME='" + combobox_lastname.Text + "'";
            }
            try
            {
                global.oleconnection.Open();
                if (retrievalcode != -1)
                {
                    OleDbCommand getstudentinfocommand = global.oleconnection.CreateCommand();
                    getstudentinfocommand.CommandText = sql;
                    OleDbDataReader getstudentinfo = getstudentinfocommand.ExecuteReader();
                    while (getstudentinfo.Read())
                    {
                        studentid = getstudentinfo["STUDENTID"].ToString();
                        firstname = getstudentinfo["FIRSTNAME"].ToString();
                        lastname = getstudentinfo["LASTNAME"].ToString();
                        grade = getstudentinfo["GRADE"].ToString();
                        if (retrievalcode == 0)
                        {
                            combobox_firstname.Text = firstname;
                            combobox_firstname.Items.Add(firstname);
                        }
                        if (retrievalcode == 1)
                        {
                            combobox_lastname.Text = lastname;
                            combobox_lastname.Items.Add(lastname);
                        }
                    }
                }
            }
            catch (Exception x) { MessageBox.Show(x.Message, "Error"); }
            finally { global.oleconnection.Close(); }
            #endregion
            if (studentid != "")
            {
                #region getinfractions
                try
                {
                    global.oleconnection.Open();
                    county = 0;
                    totalinfractions = 1;
                    nineWeeksDatabase = 0;
                    currentNineWeeks = 0;
                    currentDayOfYear = DateTime.Now.DayOfYear;
                    OleDbCommand getinfractioncommand = global.oleconnection.CreateCommand();
                    getinfractioncommand.CommandText = "SELECT * FROM INFRACTIONS WHERE `First Name`='" + combobox_firstname.Text + "' AND `Last Name`='" + combobox_lastname.Text + "'";
                    OleDbDataReader getinfraction = getinfractioncommand.ExecuteReader();
                    dataGridView1.DataSource = bindingSource1;

                    // Create a new data adapter based on the specified query.
                    dataadapter = new OleDbDataAdapter("SELECT * FROM INFRACTIONS WHERE `First Name`='" + combobox_firstname.Text + "' AND `Last Name`='" + combobox_lastname.Text + "'", global.oleconnection);

                    // Create a command builder to generate SQL update, insert, and 
                    // delete commands based on selectCommand. These are used to 
                    // update the database.
                    OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(dataadapter);


                    // Populate a new data table and bind it to the BindingSource.
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;

                    //table.TableName[0];
                    dataadapter.Fill(table);
                    //
                    bindingSource1.DataSource = table;


                    // Resize the DataGridView columns to fit the newly loaded content.
                    
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[12].Visible = false;
                    
                    dataGridView1.AutoResizeColumns(
                        DataGridViewAutoSizeColumnsMode.AllCells);
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
                        if (databasedate >= summerstart && databasedate <= summerend)
                        {
                            nineWeeksDatabase = 0;
                            MessageBox.Show(teacherfirstname + " " + teacherlastname + "\nwhat are you doing?\n" + teacherfirstname + " " + teacherlastname + "\nSTAHP\n\nOnly school days... I know it sadens me too.\n<3 LG Dresscode Report System", "Summer...");
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
                            label_nineweeksinfractions.Text = "Infractions this 9 weeks: " + county;
                        }
                        label_totalinfractions.Text = "Total Infractions: " + (totalinfractions++);
                    }
                    if (submitted && county >= 6)
                    {
                        MessageBox.Show("A referal is required for this report.", "Referal Required");
                        submitted = false;
                    }
                }
                catch (Exception x) { MessageBox.Show(x.Message, "Error"); }
                finally { global.oleconnection.Close(); }
                #endregion
            }
            else
                MessageBox.Show("Student: \"" + combobox_firstname.Text + " " + combobox_lastname.Text + "\" does not exist\nContact Administration", "Error");
        }

        private void button_retrieve_Click(object sender, EventArgs e)
        {
            studentid = "";
            firstname = "";
            lastname = "";
            grade = "";
            retrieval();
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
                if (combobox_period.Text == "")
                {
                    MessageBox.Show("Pick a period", "Period Required");
                }
                else
                {
                    button_retrieve.PerformClick();
                    if (studentid != "")
                    {
                        if (textbox_details.Text != "Details")
                        {
                            details = textbox_details.Text;
                        }
                        else
                        {
                            details = "N/A";
                        }

                        period = combobox_period.Text;
                        infraction = combobox_infraction.Text;
                        if (infraction != "")
                        {
                            DialogResult verification = MessageBox.Show("Is this correct?\nStudent Name: " + firstname + " " + lastname + "\nGrade: " + grade + "\nPeriod: #" + period + "\nInfractured by: (" + teacherid + ") " + teacherfirstname + " " + teacherlastname + "\nDate: " + DateTime.Now.ToShortDateString() + "\nInfraction: " + infraction + "\nDetails: " + details, "Verify your infraction", MessageBoxButtons.YesNo);
                            if (verification == DialogResult.Yes)
                            {
                                try
                                {
                                    Boolean really = false;
                                    global.oleconnection.Open();
                                    OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
                                    string sql = null;
                                    //Kicks and gigglies code, to be removed when asked.
                                    if (lastname == "Fleming")
                                        really = true;
                                    if (lastname == "Ragusa")
                                        really = true;
                                    if (lastname == "Kuell")
                                        really = true;
                                    if (really)
                                    {
                                        DialogResult specialverification = MessageBox.Show("Are you sure you really want to infracture " + firstname + " " + lastname + "?", "Are you positive?", MessageBoxButtons.YesNo);
                                    }
                                    else
                                    {
                                        if (DateTime.Now.DayOfYear >= 157 && DateTime.Now.DayOfYear <= 231)
                                        {
                                            MessageBox.Show(teacherfirstname + " " + teacherlastname + "\nwhat are you doing?\n" + teacherlastname + ", " + teacherfirstname + "\nSTAHP\n\nOnly school days... I know it sadens me too.", "Summer...");
                                        }
                                        else
                                        {
                                            for (int i = 0; i < details.Length; i++)
                                            {
                                                if (details[i] == '"')
                                                {
                                                    details.Replace('"', '\"');
                                                }
                                            }

                                            sql = "INSERT INTO INFRACTIONS VALUES ('" + 0 + "','" + teacherid + "','" + DateTime.Now.DayOfYear.ToString() + "','" + studentid + "','" + firstname + "','" + lastname + "','" + grade + "','" + period + "','" + teacherlastname + ", " + teacherfirstname + "','" + DateTime.Now.ToShortDateString() + "','" + infraction + "','" + details + "','" + "None" + "')";
                                            oledbAdapter.InsertCommand = new OleDbCommand(sql, global.oleconnection);
                                            oledbAdapter.InsertCommand.ExecuteNonQuery();
                                            submitted = true;
                                        }
                                    }
                                }
                                catch (Exception x)
                                {
                                    MessageBox.Show(x.Message);
                                }
                                finally
                                {
                                    global.oleconnection.Close();
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
            button_clear.PerformClick();
            admin = true;
            if(admin)
            {
                menuStrip1.Enabled = true;
                menuStrip1.Visible = true;
            }
            combobox_firstname.Focus();
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
            /*
            TimeSpan time = DateTime.Now.TimeOfDay;
            if (time > new TimeSpan(7, 10, 00) && time < new TimeSpan(8, 10, 00))
                combobox_period.Text = "1"; //First Block
            if (time > new TimeSpan(8, 11, 00) && time < new TimeSpan(9, 50, 00))
                combobox_period.Text = "2/3"; //Second Block
            if (time > new TimeSpan(9, 50, 00) && time < new TimeSpan(11, 30, 00))
                combobox_period.Text = "4/5"; //Third Block
            if (time > new TimeSpan(11, 30, 00) && time < new TimeSpan(13, 40, 00))
                combobox_period.Text = "6/7"; //Forth Block
             */
            label_teacherid.Text = "Teacher ID: " + teacherid;
            label_date.Text += DateTime.Now.ToShortDateString();
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            combobox_firstname.Text = "";
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
                sql = "SELECT * FROM SETTINGS";
                global.oleconnection.Open();
                OleDbCommand getpossibleinfractionscommand = global.oleconnection.CreateCommand();
                getpossibleinfractionscommand.CommandText = sql;
                OleDbDataReader getpossibleinfractions = getpossibleinfractionscommand.ExecuteReader();
                while (getpossibleinfractions.Read())
                    {
                        combobox_infraction.Items.Add(getpossibleinfractions["infractions"].ToString());
                    }
                }
            catch (Exception x) { MessageBox.Show(x.Message, "Error"); }
            finally { global.oleconnection.Close(); }
        }

        private void textbox_details_TextChanged(object sender, EventArgs e)
        {
            if (textbox_details.Text.Length >= 256)
            {
                MessageBox.Show(teacherfirstname + " " + teacherlastname + "\nwhat are you doing?\n" + teacherfirstname + " " + teacherlastname + "\nSTAHP\n\nOnly 255 characters can be reported.", "Limited report characters");
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
            MessageBox.Show("Goodbye.\nYou know, using this program just now taught me a valuable lesson:\nthe best solution to a problem is usually the easiest one.\nAnd lets be honest, using the orginal dresscode system is hard.\nYou know what the old dresscode system used to be like?\nNo one could easily report students.\nReporting was bad until I showed up.\nIt's been fun, come back anytime. <3","Closing");
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
            reports report = new reports();
            report.ShowDialog();
        }
    }
}