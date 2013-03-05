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
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                global.oleconnection.Open();
                OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
                
                sql = "UPDATE DATES SET firstnineweeksstart='" + dateTimePicker1.Value.ToShortDateString() + "'";
                oledbAdapter.InsertCommand = new OleDbCommand(sql, global.oleconnection);
                oledbAdapter.InsertCommand.ExecuteNonQuery();
                sql = "UPDATE DATES SET firstnineweeksend='" + dateTimePicker2.Value.ToShortDateString() + "'";
                oledbAdapter.InsertCommand = new OleDbCommand(sql, global.oleconnection);
                oledbAdapter.InsertCommand.ExecuteNonQuery();
                sql = "UPDATE DATES SET secondnineweeksstart='" + dateTimePicker3.Value.ToShortDateString() + "'";
                oledbAdapter.InsertCommand = new OleDbCommand(sql, global.oleconnection);
                oledbAdapter.InsertCommand.ExecuteNonQuery();
                sql = "UPDATE DATES SET secondnineweeksend='" + dateTimePicker4.Value.ToShortDateString() + "'";
                oledbAdapter.InsertCommand = new OleDbCommand(sql, global.oleconnection);
                oledbAdapter.InsertCommand.ExecuteNonQuery();
                sql = "UPDATE DATES SET thirdnineweeksstart='" + dateTimePicker5.Value.ToShortDateString() + "'";
                oledbAdapter.InsertCommand = new OleDbCommand(sql, global.oleconnection);
                oledbAdapter.InsertCommand.ExecuteNonQuery();
                sql = "UPDATE DATES SET thridnineweeksend='" + dateTimePicker6.Value.ToShortDateString() + "'";
                oledbAdapter.InsertCommand = new OleDbCommand(sql, global.oleconnection);
                oledbAdapter.InsertCommand.ExecuteNonQuery();
                sql = "UPDATE DATES SET forthnineweeksstart='" + dateTimePicker7.Value.ToShortDateString() + "'";
                oledbAdapter.InsertCommand = new OleDbCommand(sql, global.oleconnection);
                oledbAdapter.InsertCommand.ExecuteNonQuery();
                sql = "UPDATE DATES SET forthnineweeksend='" + dateTimePicker8.Value.ToShortDateString() + "'";
                oledbAdapter.InsertCommand = new OleDbCommand(sql, global.oleconnection);
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

        private void settings_Load(object sender, EventArgs e)
        {
            try
            {
                global.oleconnection.Open();
                OleDbCommand getdatecommand = global.oleconnection.CreateCommand();
                getdatecommand.CommandText = "SELECT * FROM DATES";
                OleDbDataReader getdate = getdatecommand.ExecuteReader();
                while (getdate.Read())
                {
                    dateTimePicker1.Value = DateTime.Parse(getdate["firstnineweeksstart"].ToString());
                    dateTimePicker2.Value = DateTime.Parse(getdate["firstnineweeksend"].ToString());

                    dateTimePicker3.Value = DateTime.Parse(getdate["secondnineweeksstart"].ToString());
                    dateTimePicker4.Value = DateTime.Parse(getdate["secondnineweeksend"].ToString());

                    dateTimePicker5.Value = DateTime.Parse(getdate["thirdnineweeksstart"].ToString());
                    dateTimePicker6.Value = DateTime.Parse(getdate["thirdnineweeksend"].ToString());

                    dateTimePicker7.Value = DateTime.Parse(getdate["forthnineweeksstart"].ToString());
                    dateTimePicker8.Value = DateTime.Parse(getdate["forthnineweeksend"].ToString());
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
    }
}
