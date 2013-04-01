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
    public partial class form_vote : Form
    {
        public form_vote()
        {
            InitializeComponent();
        }
        //Local Path: U:\12th\Programming\C#\votingsystem\votingsystem\votesys.mdb
        /*Extra imports*/
        static connectioninfo conninfo = new connectioninfo();
        static form_login frm_login = new form_login();
        /* SQL Strings */
        string sqlgetcandidates = "SELECT * FROM candidates";
        string sqlselectvoteallowance = "SELECT * FROM settings";
        /*Storage Strings */
        string voteallowancestring = "";
        /* Storage Ints */
        int voteallowanceint = 0;
        int votenum = 0;
        string voted = "";
        string[] girls = new string[1000];
        string[] boys = new string[1000];
        /* --------------------------------------------------------------------------------------------*/
        /*Gets information of the candidates from the database */
        public void getcandidates()
        {
            int farraycount = 0;
            int marraycount = 0;
            conninfo.oleconnection.Open();
            OleDbCommand myCommand = conninfo.oleconnection.CreateCommand();
                myCommand.CommandText = sqlgetcandidates;
                OleDbDataReader rdr = myCommand.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr["gender"].ToString() == "Boy")
                    {
                        boys[marraycount] = rdr["candidate_name"].ToString();
                        marraycount++;
                    }
                    if(rdr["gender"].ToString() == "Girl")
                    {
                        girls[farraycount] = rdr["candidate_name"].ToString();
                        farraycount++;
                    }
                }
                conninfo.oleconnection.Close();
                for (int i = 0; i < 1000; i++)
                {
                    listView1.Items.Add(new ListViewItem(new string[] { boys[i]}));
                    if (boys[i + 1] == null) break;
                }
                for (int i = 0; i < 1000; i++)
                {
                    listView2.Items.Add(new ListViewItem(new string[] { girls[i] }));
                    if (girls[i + 1] == null) break;
                }
        }
        /* Gets the number of votes that is allowed per person */
        public void getvoteallowance()
        {
            conninfo.oleconnection.Open();

            OleDbCommand voteallowancecommand = conninfo.oleconnection.CreateCommand();
                voteallowancecommand.CommandText = sqlselectvoteallowance;
                OleDbDataReader rdrallowance = voteallowancecommand.ExecuteReader();
                while (rdrallowance.Read())
                {
                    voteallowancestring = rdrallowance["vote_allowance"].ToString();
                    voteallowanceint = int.Parse(voteallowancestring);
                    label1.Text = "Please vote for " + voteallowancestring.ToString() + " boys and " + voteallowancestring.ToString() + " girls.";
                }
                conninfo.oleconnection.Close();
        }
        /* Figures outs which candidates are being voted and marks the voter as "voted" */
        public void vote()
        {
            if (conninfo.oleconnection.State == ConnectionState.Open)
            {
                conninfo.oleconnection.Close();
            }
            foreach (ListViewItem lvi in listView1.CheckedItems)
            {
                /* Update votes of candidates (candidates_votes + 1) */
                conninfo.oleconnection.Open();
                    string sqlgetcandidates = "SELECT * FROM candidates WHERE candidate_name=@canname";
                    OleDbCommand myCommand = conninfo.oleconnection.CreateCommand();
                    myCommand.CommandText = sqlgetcandidates;
                    myCommand.Parameters.Add("canname", lvi.Text);
                    OleDbDataReader rdr = myCommand.ExecuteReader();
                    while (rdr.Read())
                    {
                        string votenum1 = rdr["candidates_votes"].ToString();
                        votenum = int.Parse(votenum1);
                    }
                    conninfo.oleconnection.Close();
                    conninfo.oleconnection.Open();
                    votenum++;
                    string candidatesvotes = "UPDATE candidates SET candidates_votes=@votenum WHERE candidate_name=@canname";
                    OleDbCommand updatevoted1 = conninfo.oleconnection.CreateCommand();
                    OleDbDataAdapter oledbda1 = new OleDbDataAdapter();
                    oledbda1.InsertCommand = new OleDbCommand(candidatesvotes, conninfo.oleconnection);
                    oledbda1.InsertCommand.Parameters.Add("votenum", votenum);
                    oledbda1.InsertCommand.Parameters.Add("canname", lvi.Text);
                    oledbda1.InsertCommand.ExecuteNonQuery();
                    conninfo.oleconnection.Close();
            }
            foreach (ListViewItem lvi in listView2.CheckedItems)
            {
                /* Update votes of candidates (candidates_votes + 1) */
                conninfo.oleconnection.Open();
                string sqlgetcandidates = "SELECT * FROM candidates WHERE candidate_name=@canname";
                OleDbCommand myCommand = conninfo.oleconnection.CreateCommand();
                myCommand.Parameters.Add("canname", lvi.Text);
                myCommand.CommandText = sqlgetcandidates;
                OleDbDataReader rdr = myCommand.ExecuteReader();
                while (rdr.Read())
                {
                    string votenum1 = rdr["candidates_votes"].ToString();
                    votenum = int.Parse(votenum1);
                }
                conninfo.oleconnection.Close();
                conninfo.oleconnection.Open();
                votenum++;
                string candidatesvotes = "UPDATE candidates SET candidates_votes=@votenum WHERE candidate_name=@canname";
                OleDbCommand updatevoted1 = conninfo.oleconnection.CreateCommand();
                OleDbDataAdapter oledbda1 = new OleDbDataAdapter();
                oledbda1.InsertCommand = new OleDbCommand(candidatesvotes, conninfo.oleconnection);
                oledbda1.InsertCommand.Parameters.Add("votenum", votenum);
                oledbda1.InsertCommand.Parameters.Add("canname", lvi.Text);
                oledbda1.InsertCommand.ExecuteNonQuery();
                conninfo.oleconnection.Close();
            }
            /* Disallow the voter to vote again. */
            conninfo.oleconnection.Open();
                string sqlvote = "UPDATE users SET voted='yes' WHERE username=@usern";
                OleDbCommand updatevoted = conninfo.oleconnection.CreateCommand();
                OleDbDataAdapter oledbda = new OleDbDataAdapter();
                oledbda.InsertCommand = new OleDbCommand(sqlvote, conninfo.oleconnection);
                oledbda.InsertCommand.Parameters.Add("usern", username);
                oledbda.InsertCommand.ExecuteNonQuery();
                conninfo.oleconnection.Close();
        }
        private void form_vote_Load(object sender, EventArgs e)
        {
            try { listView1.Items.Clear(); getcandidates(); getvoteallowance(); }
            catch (Exception x) { MessageBox.Show(x.Message); }
            finally { conninfo.oleconnection.Close(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((listView1.CheckedItems.Count == voteallowanceint) && listView2.CheckedItems.Count == voteallowanceint) /*Checks if the person has voted the correct amount of times. */
            {
                if (MessageBox.Show("Are you sure you want to vote for these candidate(s)\nPress Yes to confirm or No to change your choices.", "Verification", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        if (conninfo.oleconnection.State == ConnectionState.Closed)
                        {
                            conninfo.oleconnection.Open();
                        }
                        string sqlcheckuser = "SELECT * FROM users WHERE username=@uname AND password=@pass";
                        OleDbCommand sqlcheckuserCommand = conninfo.oleconnection.CreateCommand();
                        sqlcheckuserCommand.CommandText = sqlcheckuser;
                        sqlcheckuserCommand.Parameters.Add("uname",username);
                        sqlcheckuserCommand.Parameters.Add("pass",password);
                        OleDbDataReader sqlcheckvoted = sqlcheckuserCommand.ExecuteReader();
                        while (sqlcheckvoted.Read())
                        {
                            voted = sqlcheckvoted["voted"].ToString();
                            if (voted == "no")
                            {
                                vote();
                                MessageBox.Show("Your voting is now complete.", "Arigato");
                                if (conninfo.oleconnection.State == ConnectionState.Open)
                                {
                                    conninfo.oleconnection.Close();
                                }
                                break;
                            }
                            else
                            {
                                MessageBox.Show("You appear to have voted from another location,\nsorry", "Voting Status: Voted");
                            }
                        }
                    }
                    catch (Exception x) { MessageBox.Show(x.Message, "Poop"); }
                    finally
                    {
                        if (conninfo.oleconnection.State == ConnectionState.Open)
                        {
                            conninfo.oleconnection.Close();
                        }
                        this.Close();
                    }
                }
            }
            /* If the voter has picked too many candidates it tells them to remove the number they went over. */
            if (listView1.CheckedItems.Count > voteallowanceint)
            {
                MessageBox.Show("Remove " + (listView1.CheckedItems.Count - voteallowanceint).ToString() + " of your boy(s) votes");
            }
            if (listView2.CheckedItems.Count > voteallowanceint)
            {
                MessageBox.Show("Remove " + (listView2.CheckedItems.Count - voteallowanceint).ToString() + " of your girl(s) votes");
            }
            /* If the voter hasnot picked enough candidates it tells how many they need to pick*/
            if (listView1.CheckedItems.Count < voteallowanceint)
            {
                MessageBox.Show("Select " + (voteallowanceint - listView1.CheckedItems.Count) + " more boy(s)");
            }
            if (listView2.CheckedItems.Count < voteallowanceint)
            {
                MessageBox.Show("Select " + (voteallowanceint - listView2.CheckedItems.Count) + " more girl(s)");
            }
        }
    }
}
