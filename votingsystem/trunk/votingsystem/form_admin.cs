/*
 * Matt Fleming
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace votingsystem
{
    public partial class form_admin : Form
    {
        public form_admin()
        {
            InitializeComponent();
        }
        connectioninfo conninfo = new connectioninfo();
        int arrayhold = 0;
        string[] candidate_name = new string[1000];
        int[] candidates_votes = new int[1000];
        string[] monkey = new string[1000]; //This means gender, I have no clue why "Gender" is an issue ~ Matt.
        bool exists = false;

        public void getvoters()
        {
            listview_voters.Items.Clear();
            conninfo.oleconnection.Open();
            string sqlgetvoters = "SELECT * FROM users WHERE voted='no' or voted=''";
            OleDbCommand voteallowancecommand = conninfo.oleconnection.CreateCommand();
            voteallowancecommand.CommandText = sqlgetvoters;
            OleDbDataReader rdrcandidates = voteallowancecommand.ExecuteReader();
            while (rdrcandidates.Read())
            {
                ListViewItem lvi = new ListViewItem(rdrcandidates["username"].ToString());
                listview_voters.Items.Add(lvi.Text);
            }
            conninfo.oleconnection.Close();
        }

        public void getcandidates()
        {
            arrayhold = 0;
            conninfo.oleconnection.Open();
            string sqlgetcandidates = "SELECT * FROM candidates";
            OleDbCommand voteallowancecommand = conninfo.oleconnection.CreateCommand();
            voteallowancecommand.CommandText = sqlgetcandidates;
            OleDbDataReader rdrcandidates = voteallowancecommand.ExecuteReader();
            while (rdrcandidates.Read())
            {
                candidate_name[arrayhold] = rdrcandidates["candidate_name"].ToString();
                arrayhold++;
            }
            conninfo.oleconnection.Close();
        }

        public void getgender()
        {
            arrayhold = 0;
            conninfo.oleconnection.Open();
            string sqlgetcandidates = "SELECT * FROM candidates";
            OleDbCommand getgendercommand = conninfo.oleconnection.CreateCommand();
            getgendercommand.CommandText = sqlgetcandidates;
            OleDbDataReader rdrgender = getgendercommand.ExecuteReader();
            while (rdrgender.Read())
            {
                if (rdrgender["gender"].ToString() != null && rdrgender["gender"].ToString() != "")
                {
                    monkey[arrayhold] = rdrgender["gender"].ToString();
                    arrayhold++;
                }
            }
            conninfo.oleconnection.Close();
        }

        public void clearlogs()
        {
            listview_candiates.Items.Clear();
            for (int i = 0; i < 999; i++)
            {
                candidate_name[i] = null;
                candidates_votes[i] = 0;
                monkey[i] = null;
            }
        }

        private void form_admin_Load(object sender, EventArgs e)
        {
            try
            {
                clearlogs();
                getcandidates();
                getvotes();
                getgender();
                readdinfo();
                getvoters();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "ERR0rz?");
            }
            finally
            {
                conninfo.oleconnection.Close();
            }
        }

        public void readdinfo()
        {
            for (int i = 0; i < 1000; i++)
            {
                listview_candiates.Items.Add(new ListViewItem(new string[] { candidate_name[i], candidates_votes[i].ToString(), monkey[i] }));
                if (candidate_name[i + 1] == null || monkey[i + 1] == null) break;
            }
        }

        public void getvotes()
        {
            arrayhold = 0;
            conninfo.oleconnection.Open();
            string sqlgetvotes1 = "SELECT * FROM candidates";
            OleDbCommand voteallowancecommand = conninfo.oleconnection.CreateCommand();
            voteallowancecommand.CommandText = sqlgetvotes1;
            OleDbDataReader rdrvotes1 = voteallowancecommand.ExecuteReader();
            while (rdrvotes1.Read())
            {
                candidates_votes[arrayhold] = int.Parse(rdrvotes1["candidates_votes"].ToString());
                arrayhold++;
            }
            conninfo.oleconnection.Close();
        }

        public void allowance()
        {
            try
            {
                conninfo.oleconnection.Open();
                int allowance = 0;
                allowance = (int)numericupdown_allowedvotes.Value;
                string pop = "UPDATE settings SET vote_allowance=@allowa";
                OleDbCommand updatevoted1 = conninfo.oleconnection.CreateCommand();
                OleDbDataAdapter oledbda1 = new OleDbDataAdapter();
                oledbda1.InsertCommand = new OleDbCommand(pop, conninfo.oleconnection);
                oledbda1.InsertCommand.Parameters.Add("allowa", allowance);
                oledbda1.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception x) { MessageBox.Show(x.Message, "ErR0Rz"); }
            finally { conninfo.oleconnection.Close(); }
        }

        public void resetvoters()
        {
            try
            {
                conninfo.oleconnection.Open();
                string voted = "no";
                string pop = "UPDATE users SET [voted]=@votedd";
                OleDbCommand updatevoted1 = conninfo.oleconnection.CreateCommand();
                OleDbDataAdapter oledbda1 = new OleDbDataAdapter();
                oledbda1.InsertCommand = new OleDbCommand(pop, conninfo.oleconnection);
                oledbda1.InsertCommand.Parameters.Add("votedd", voted);
                oledbda1.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception x) { MessageBox.Show(x.Message, "ErR0Rz"); }
            finally { conninfo.oleconnection.Close(); }
        }

        private void label_allowedvotes_ValueChanged(object sender, EventArgs e)
        {
            int voteamount = (int)numericupdown_allowedvotes.Value;
            if (listview_candiates.Items.Count < voteamount)
            {
                MessageBox.Show("Too Many Votes!?");
                numericupdown_allowedvotes.Value = voteamount - 1;
            }
            else
            {
                allowance();
            }
        }

        public void addcandidate()
        {
            foreach (ListViewItem lvi in listview_candiates.Items)
            {
                if (lvi.Text == textbox_addcandidate.Text)
                {
                    exists = true;
                    MessageBox.Show(textbox_addcandidate.Text + " already exists", "Existing Candidate");
                    textbox_addcandidate.Clear();
                    break;
                }
                else
                {
                    exists = false;
                }
            }
            if (exists == false)
            {

                conninfo.oleconnection.Open();
                OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
                string sql = null;
                sql = "INSERT INTO candidates VALUES (@candidatename,'" + 0 + "',@gendert)";
                oledbAdapter.InsertCommand = new OleDbCommand(sql, conninfo.oleconnection);
                oledbAdapter.InsertCommand.Parameters.Add("candidatename", textbox_addcandidate.Text);
                oledbAdapter.InsertCommand.Parameters.Add("gendert", comboBox1.Text);
                oledbAdapter.InsertCommand.ExecuteNonQuery();
                conninfo.oleconnection.Close();
                textbox_addcandidate.Clear();


            }
        }

        private void button_addcandidate_Click(object sender, EventArgs e)
        {
            if (textbox_addcandidate.Text != "")
            {
                if (comboBox1.Text != "")
                {
                    addcandidate();
                    /*clearlogs();
                    getcandidates();
                    getvotes();
                    readdinfo();*/
                    button_refreshcandidates.PerformClick();
                }
                else
                {
                    MessageBox.Show("Please Select a gender for " + textbox_addcandidate.Text, "Is it a Boy or a Girl?");
                }
            }
        }

        private void button_removecandidate_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem line in listview_candiates.CheckedItems)
            {
                string sqlvote = "DELETE FROM candidates WHERE candidate_name=@canname";
                conninfo.oleconnection.Open();
                OleDbCommand updatevoted = conninfo.oleconnection.CreateCommand();
                OleDbDataAdapter oledbda = new OleDbDataAdapter();
                oledbda.DeleteCommand = new OleDbCommand(sqlvote, conninfo.oleconnection);
                oledbda.DeleteCommand.Parameters.Add("canname", line.Text);
                oledbda.DeleteCommand.ExecuteNonQuery();
                conninfo.oleconnection.Close();
            }
            listview_candiates.Items.Clear();
            clearlogs();
            getcandidates();
            getvotes();
            readdinfo();
            button_refreshcandidates.PerformClick();
        }

        private void button_refreshcandidates_Click(object sender, EventArgs e)
        {
            listview_candiates.Items.Clear();
            clearlogs();
            getcandidates();
            getvotes();
            readdinfo();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button_refreshcandidates.PerformClick();
        }

        private void comboBox_liverefreshinterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combobox_liverefreshinterval.Text == "1 Second")
            {
                timer1.Interval = int.Parse(combobox_liverefreshinterval.Text.Replace(" Second", ""));
            }
            else
            {
                timer1.Interval = int.Parse(combobox_liverefreshinterval.Text.Replace(" Seconds", ""));
            }
        }

        private void button_liverefresh_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
                button_liverefresh.Text = "Live Refresh\nEnabled";
            }
            else
            {
                timer1.Enabled = false;
                button_liverefresh.Text = "Live Refresh\nDisabled";
            }
        }

        private void button_resetcandidatevotes_Click(object sender, EventArgs e)
        {
            try
            {
                conninfo.oleconnection.Open();
                string sqlresetcanvotes = "UPDATE candidates SET candidates_votes='0'";
                OleDbCommand resetcandidatevotes = conninfo.oleconnection.CreateCommand();
                OleDbDataAdapter oledbdaresetcandidatevotes = new OleDbDataAdapter();
                oledbdaresetcandidatevotes.InsertCommand = new OleDbCommand(sqlresetcanvotes, conninfo.oleconnection);
                oledbdaresetcandidatevotes.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception x) { MessageBox.Show(x.Message, "ErRorz?"); }
            finally { conninfo.oleconnection.Close(); button_refreshcandidates.PerformClick(); }
        }
        private void button_exitvotingsystem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close entire application?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (System.Diagnostics.Process proc in System.Diagnostics.Process.GetProcesses())
                {
                    if (proc.ProcessName == "votingsystem")
                    {
                        proc.Kill();
                    }
                }
            }
        }

        private void textbox_addcandidate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_addcandidate.PerformClick();
            }
        }
        private void button_refreshcandidates_Click_1(object sender, EventArgs e)
        {
            clearlogs();
            getcandidates();
            getvotes();
            getgender();
            readdinfo();
        }

        private void listview_candiates_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                button_removecandidate.PerformClick();
            }
        }

        private void button_resetvoters_Click(object sender, EventArgs e)
        {
            conninfo.oleconnection.Open();
            string sqlvote = "UPDATE users SET voted='no'";
            OleDbCommand updatevoted = conninfo.oleconnection.CreateCommand();
            OleDbDataAdapter oledbda = new OleDbDataAdapter();
            oledbda.InsertCommand = new OleDbCommand(sqlvote, conninfo.oleconnection);
            oledbda.InsertCommand.ExecuteNonQuery();
            conninfo.oleconnection.Close();
            getvoters();
        }

        private void button_refreshvoters_Click(object sender, EventArgs e)
        {
            getvoters();
        }
    }
}
