using System;
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
    public partial class Learning_Center : Form
    {
        public Learning_Center()
        {
            InitializeComponent();
        }

        globals gl = new globals();

        private void Learning_Center_Load(object sender, EventArgs e)
        {
            timer_checklearningcenter.Enabled = true;
            timer_checklearningcenter.Interval = 2500;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (gl.oleconnection.State == ConnectionState.Closed)
                    gl.oleconnection.Open();
                OleDbCommand getlearningcenterscommand = gl.oleconnection.CreateCommand();
                getlearningcenterscommand.CommandText = "SELECT * FROM `" + gl.tbl_reports + "` WHERE `"+ gl.col_learningcenter +"`=@notpresent";
                getlearningcenterscommand.Parameters.Add("notpresent",OleDbType.VarChar,255).Value = gl.glt_notpresent;
                OleDbDataReader getlearningcenter = getlearningcenterscommand.ExecuteReader();
                while (getlearningcenter.Read())
                {
                    if (!listBox_students.Items.Contains(getlearningcenter[gl.col_lastname].ToString() + ", " + getlearningcenter[gl.col_firstname].ToString()))
                        listBox_students.Items.Add(getlearningcenter[gl.col_lastname].ToString()+ ", " + getlearningcenter[gl.col_firstname].ToString());
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            finally
            {
                if (gl.oleconnection.State == ConnectionState.Open)
                    gl.oleconnection.Close();
            }
        }

        private void button_present_Click(object sender, EventArgs e)
        {
            if (listBox_students.SelectedItem != null)
            {
                try
                {
                    timer_checklearningcenter.Enabled = false;
                    timer_checklearningcenter.Stop();
                    if (gl.oleconnection.State == ConnectionState.Closed)
                        gl.oleconnection.Open();
                    OleDbDataAdapter adpt = new OleDbDataAdapter();
                    adpt.UpdateCommand = new OleDbCommand("UPDATE `" + gl.tbl_reports + "` SET [" + gl.col_learningcenter + "]=@learncenter WHERE ["+ gl.col_lastname +"]=@lname AND ["+ gl.col_learningcenter +"]=@learnc AND ["+ gl.col_firstname +"]=@firstname AND ["+ gl.col_reportdate +"]=@reportdate", gl.oleconnection);
                    adpt.UpdateCommand.Parameters.Add("learncenter", OleDbType.VarChar, 255).Value = gl.glt_present;
                    string lastname = (listBox_students.SelectedItem.ToString().Substring(0, listBox_students.SelectedItem.ToString().IndexOf(","))).Trim();
                    adpt.UpdateCommand.Parameters.Add("lname", OleDbType.VarChar, 255).Value = lastname;
                    adpt.UpdateCommand.Parameters.Add("learnc", OleDbType.VarChar, 255).Value = gl.glt_notpresent;
                    string firstname = (listBox_students.SelectedItem.ToString().Substring((listBox_students.SelectedItem.ToString().IndexOf(", ") + 2), listBox_students.SelectedItem.ToString().Length - (listBox_students.SelectedItem.ToString().IndexOf(", ") + 2))).Trim();
                    adpt.UpdateCommand.Parameters.Add("firstname", OleDbType.VarChar, 255).Value = firstname;
                    adpt.UpdateCommand.Parameters.Add("reportdate", OleDbType.DBDate, 255).Value = DateTime.Today.ToShortDateString();
                    adpt.UpdateCommand.CommandType = CommandType.Text;
                    adpt.UpdateCommand.ExecuteNonQuery();
                    listBox_present.Items.Add(listBox_students.SelectedItem);
                    listBox_students.Items.Remove(listBox_students.SelectedItem);
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
                finally
                {
                    if (gl.oleconnection.State == ConnectionState.Open)
                        gl.oleconnection.Close();
                    timer_checklearningcenter.Enabled = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox_students.Items.Count; i++)
                if (listBox_students.Items[i].ToString().Contains(textBox1.Text))
                {
                    listBox_students.SetSelected(i, true);
                    break;
                }
                else if(listBox_students.Items[i].ToString().Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBox1.Text)))
                {
                    listBox_students.SetSelected(i, true);
                    break;
                }
                else if (listBox_students.Items[i].ToString().Contains(CultureInfo.CurrentCulture.TextInfo.ToLower(textBox1.Text)))
                {
                    listBox_students.SetSelected(i, true);
                    break;
                }
        }
        private void allNotPresentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                timer_checklearningcenter.Enabled = false;
                timer_checklearningcenter.Stop();
                if (gl.oleconnection.State == ConnectionState.Closed)
                    gl.oleconnection.Open();
                OleDbDataAdapter adpt = new OleDbDataAdapter();
                for (int i = 0; i < listBox_students.Items.Count; i++)
                {
                    adpt.UpdateCommand = new OleDbCommand("UPDATE `" + gl.tbl_reports + "` SET [" + gl.col_learningcenter + "]=@learncenter WHERE [" + gl.col_lastname + "]=@lname AND [" + gl.col_learningcenter + "]=@learnc AND [" + gl.col_firstname + "]=@firstname", gl.oleconnection);
                    adpt.UpdateCommand.Parameters.Add("learncenter", OleDbType.VarChar, 255).Value = gl.glt_present;
                    string lastname = (listBox_students.Items[i].ToString().Substring(0, listBox_students.Items[i].ToString().IndexOf(","))).Trim();
                    adpt.UpdateCommand.Parameters.Add("lname", OleDbType.VarChar, 255).Value = lastname;
                    adpt.UpdateCommand.Parameters.Add("learnc", OleDbType.VarChar, 255).Value = gl.glt_notpresent;
                    string firstname = (listBox_students.Items[i].ToString().Substring((listBox_students.Items[i].ToString().IndexOf(", ") + 2), listBox_students.Items[i].ToString().Length - (listBox_students.Items[i].ToString().IndexOf(", ") + 2))).Trim();
                    adpt.UpdateCommand.Parameters.Add("firstname", OleDbType.VarChar, 255).Value = firstname;

                    adpt.UpdateCommand.CommandType = CommandType.Text;
                    adpt.UpdateCommand.ExecuteNonQuery();
                    listBox_students.Items.Remove(listBox_students.Items[i]);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            finally
            {
                if (gl.oleconnection.State == ConnectionState.Open)
                    gl.oleconnection.Close();
                timer_checklearningcenter.Enabled = true;
            }
        }

        private void listBox_students_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button_present.PerformClick();
        }
    }
}
