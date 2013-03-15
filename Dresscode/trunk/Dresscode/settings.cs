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
    public partial class settings : Form
    {
        public settings()
        {
            InitializeComponent();
        }
        globals global = new globals();
        string sql = "";

        private void settings_Load(object sender, EventArgs e)
        {
            try
            {
                global.oleconnection.Open();
                OleDbCommand getdatecommand = global.oleconnection.CreateCommand();
                getdatecommand.CommandText = "SELECT * FROM `Nine Weeks Dates`";
                OleDbDataReader getdate = getdatecommand.ExecuteReader();
                while (getdate.Read())
                {
                    datetimepicker_1.Value = DateTime.Parse(getdate["firstnineweeksstart"].ToString());
                    datetimepicker_2.Value = DateTime.Parse(getdate["firstnineweeksend"].ToString());

                    datetimepicker_3.Value = DateTime.Parse(getdate["secondnineweeksstart"].ToString());
                    datetimepicker_4.Value = DateTime.Parse(getdate["secondnineweeksend"].ToString());

                    datetimepicker_5.Value = DateTime.Parse(getdate["thirdnineweeksstart"].ToString());
                    datetimepicker_6.Value = DateTime.Parse(getdate["thirdnineweeksend"].ToString());

                    datetimepicker_7.Value = DateTime.Parse(getdate["forthnineweeksstart"].ToString());
                    datetimepicker_8.Value = DateTime.Parse(getdate["forthnineweeksend"].ToString());
                }
                global.oleconnection.Close();
                global.oleconnection.Open();
                OleDbCommand getinfractionscommand = global.oleconnection.CreateCommand();
                getinfractionscommand.CommandText = "SELECT * FROM `Infraction List`";
                OleDbDataReader getinfraction = getinfractionscommand.ExecuteReader();
                while (getinfraction.Read())
                {
                    listBox_infractions.Items.Add(getinfraction["infractions"].ToString());
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
        private void button_removeinfraction_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox_infractions.SelectedItem != null)
                {
                    global.oleconnection.Open();
                    OleDbDataAdapter oledba_deleteinfraction = new OleDbDataAdapter();
                    sql = "DELETE * FROM `Infraction List` WHERE infractions=@infraction";
                    oledba_deleteinfraction.DeleteCommand = new OleDbCommand(sql, global.oleconnection);
                    oledba_deleteinfraction.DeleteCommand.Parameters.Add("infraction", OleDbType.VarChar, 255).Value = listBox_infractions.SelectedItem;
                    oledba_deleteinfraction.DeleteCommand.ExecuteNonQuery();
                    listBox_infractions.Items.Remove(listBox_infractions.SelectedItem);
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

        private void textBox_infraction_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button_addinfraction.PerformClick();
        }

        private void button_addinfraction_Click(object sender, EventArgs e)
        {
            bool words = false;
            string labcs = "abcdefghijklmnopqrstuvwxyz";
            string uabcs = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            try
            {
                for (int i = 0; i < textBox_infraction.Text.Length; i++)
                {
                    for (int h = 0; h < labcs.Length; h++)
                    {
                        if (textBox_infraction.Text[i] == labcs[h] || textBox_infraction.Text[i] == uabcs[h])
                        {
                            words = true;
                        }
                    }
                }
                if (words)
                {
                    global.oleconnection.Open();
                    OleDbDataAdapter oledba_addinfraction = new OleDbDataAdapter();
                    sql = "INSERT INTO `Infraction List` VALUES (@infraction)";
                    oledba_addinfraction.InsertCommand = new OleDbCommand(sql, global.oleconnection);
                    oledba_addinfraction.InsertCommand.Parameters.Add("infraction", OleDbType.VarChar, 255).Value = textBox_infraction.Text;
                    oledba_addinfraction.InsertCommand.ExecuteNonQuery();
                    listBox_infractions.Items.Add(textBox_infraction.Text);
                    textBox_infraction.Clear();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            finally
            {
                if (global.oleconnection.State == ConnectionState.Open)
                    global.oleconnection.Close();
            }
        }

        private void button_savedates_Click(object sender, EventArgs e)
        {
            try
            {
                global.oleconnection.Open();
                OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
                sql = "UPDATE `Nine Weeks Dates` SET [firstnineweeksstart]=@firststart,[firstnineweeksend]=@firstend,[secondnineweeksstart]=@secondstart,[secondnineweeksend]=@secondend,[thirdnineweeksstart]=@thirdstart,[thirdnineweeksend]=@thirdend,[forthnineweeksstart]=@forthstart,[forthnineweeksend]=@forthend";
                
                oledbAdapter.InsertCommand = new OleDbCommand(sql, global.oleconnection);
                oledbAdapter.InsertCommand.Parameters.Add("firststart", OleDbType.Date, 255).Value = datetimepicker_1.Value.ToShortDateString();
                oledbAdapter.InsertCommand.Parameters.Add("firstend", OleDbType.Date, 255).Value = datetimepicker_2.Value.ToShortDateString();
                oledbAdapter.InsertCommand.Parameters.Add("secondstart", OleDbType.Date, 255).Value = datetimepicker_3.Value.ToShortDateString();
                oledbAdapter.InsertCommand.Parameters.Add("secondend", OleDbType.Date, 255).Value = datetimepicker_4.Value.ToShortDateString();
                oledbAdapter.InsertCommand.Parameters.Add("thirdstart", OleDbType.Date, 255).Value = datetimepicker_5.Value.ToShortDateString();
                oledbAdapter.InsertCommand.Parameters.Add("thirdend", OleDbType.Date, 255).Value = datetimepicker_6.Value.ToShortDateString();
                oledbAdapter.InsertCommand.Parameters.Add("forthstart", OleDbType.Date, 255).Value = datetimepicker_7.Value.ToShortDateString();
                oledbAdapter.InsertCommand.Parameters.Add("forthend", OleDbType.Date, 255).Value = datetimepicker_8.Value.ToShortDateString();
                /*sql = "UPDATE `Nine Weeks Dates` SET [firstnineweeksstart]='" + dateTimePicker1.Value.ToShortDateString() + "'";
                oledbAdapter.InsertCommand = new OleDbCommand(sql, global.oleconnection);
                oledbAdapter.InsertCommand.ExecuteNonQuery();
                sql = "UPDATE `Nine Weeks Dates` SET [firstnineweeksend]='" + dateTimePicker2.Value.ToShortDateString() + "'";
                oledbAdapter.InsertCommand = new OleDbCommand(sql, global.oleconnection);
                oledbAdapter.InsertCommand.ExecuteNonQuery();
                sql = "UPDATE `Nine Weeks Dates` SET [secondnineweeksstart]='" + dateTimePicker3.Value.ToShortDateString() + "'";
                oledbAdapter.InsertCommand = new OleDbCommand(sql, global.oleconnection);
                oledbAdapter.InsertCommand.ExecuteNonQuery();
                sql = "UPDATE `Nine Weeks Dates` SET [secondnineweeksend]='" + dateTimePicker4.Value.ToShortDateString() + "'";
                oledbAdapter.InsertCommand = new OleDbCommand(sql, global.oleconnection);
                oledbAdapter.InsertCommand.ExecuteNonQuery();
                sql = "UPDATE `Nine Weeks Dates` SET [thirdnineweeksstart]='" + dateTimePicker5.Value.ToShortDateString() + "'";
                oledbAdapter.InsertCommand = new OleDbCommand(sql, global.oleconnection);
                oledbAdapter.InsertCommand.ExecuteNonQuery();
                sql = "UPDATE `Nine Weeks Dates` SET [thirdnineweeksend]='" + dateTimePicker6.Value.ToShortDateString() + "'";
                oledbAdapter.InsertCommand = new OleDbCommand(sql, global.oleconnection);
                oledbAdapter.InsertCommand.ExecuteNonQuery();
                sql = "UPDATE `Nine Weeks Dates` SET [forthnineweeksstart]='" + dateTimePicker7.Value.ToShortDateString() + "'";
                oledbAdapter.InsertCommand = new OleDbCommand(sql, global.oleconnection);
                oledbAdapter.InsertCommand.ExecuteNonQuery();
                sql = "UPDATE `Nine Weeks Dates` SET [forthnineweeksend]='" + dateTimePicker8.Value.ToShortDateString() + "'";
                oledbAdapter.InsertCommand = new OleDbCommand(sql, global.oleconnection);*/
                oledbAdapter.InsertCommand.ExecuteNonQuery();
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
    }
}
