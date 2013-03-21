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
    public partial class Nine_Weeks_Dates : Form
    {
        public Nine_Weeks_Dates()
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
                oledbAdapter.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("9 Weeks Dates have been updated");
                this.Close();
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
