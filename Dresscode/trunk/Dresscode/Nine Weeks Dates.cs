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
        globals gl = new globals();
        DB_Interaction dbi = new DB_Interaction();
        string sql = "";

        private void settings_Load(object sender, EventArgs e)
        {
            try
            {
                if(gl.oleconnection.State == ConnectionState.Closed)
                    gl.oleconnection.Open();
                OleDbCommand getdatecommand = gl.oleconnection.CreateCommand();
                getdatecommand.CommandText = "SELECT * FROM `" + gl.tbl_nineweeksdates + "`";
                OleDbDataReader getdate = getdatecommand.ExecuteReader();
                while (getdate.Read())
                {
                    datetimepicker_1.Value = DateTime.Parse(getdate[gl.col_firstnineweeksstart].ToString());
                    datetimepicker_2.Value = DateTime.Parse(getdate[gl.col_firstnineweeksend].ToString());

                    datetimepicker_3.Value = DateTime.Parse(getdate[gl.col_secondnineweeksstart].ToString());
                    datetimepicker_4.Value = DateTime.Parse(getdate[gl.col_secondnineweeksend].ToString());

                    datetimepicker_5.Value = DateTime.Parse(getdate[gl.col_thirdnineweeksstart].ToString());
                    datetimepicker_6.Value = DateTime.Parse(getdate[gl.col_thirdnineweeksend].ToString());

                    datetimepicker_7.Value = DateTime.Parse(getdate[gl.col_forthnineweeksstart].ToString());
                    datetimepicker_8.Value = DateTime.Parse(getdate[gl.col_forthnineweeksend].ToString());
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

        private void button_savedates_Click(object sender, EventArgs e)
        {
            try
            {
                if (gl.oleconnection.State == ConnectionState.Closed)
                 gl.oleconnection.Open();
                OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
                sql = "UPDATE `" + gl.tbl_nineweeksdates + "` SET [" + gl.col_firstnineweeksstart + "]=@firststart,[" + gl.col_firstnineweeksend + "]=@firstend,[" + gl.col_secondnineweeksstart + "]=@secondstart,[" + gl.col_secondnineweeksend + "]=@secondend,[" + gl.col_thirdnineweeksstart + "]=@thirdstart,[" + gl.col_thirdnineweeksend + "]=@thirdend,[" + gl.col_forthnineweeksstart + "]=@forthstart,[" + gl.col_forthnineweeksend + "]=@forthend";
                string[] pars = { "@firststart", "@firstend", "@secondstart", "@secondend", "@thirdstart", "@thirdend", "@forthstart", "@forthend" };
                string[] values = { datetimepicker_1.Value.ToShortDateString(), datetimepicker_2.Value.ToShortDateString(), datetimepicker_3.Value.ToShortDateString(), datetimepicker_4.Value.ToShortDateString(), datetimepicker_5.Value.ToShortDateString(), datetimepicker_6.Value.ToShortDateString(), datetimepicker_7.Value.ToShortDateString(), datetimepicker_8.Value.ToShortDateString() };
                dbi.dbcommands(sql, pars, values);
                MessageBox.Show("9 Weeks Dates have been updated");
                this.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
