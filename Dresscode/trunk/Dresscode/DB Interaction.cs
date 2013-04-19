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

namespace Dresscode
{
    class DB_Interaction
    {
        globals gl = new globals();
        public string sql, firstname, lastname, studentid, teacher, infraction, frmname, dgn;
        public bool finished;

        public void teste()
        {
            finished = false;
            BackgroundWorker bgWorker;

            bgWorker = new BackgroundWorker();

            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);

            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);

            bgWorker.RunWorkerAsync();
        }

        void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //dbi.dgvselectioncommand(
            // Filename to process was passed to RunWorkerAsync(), so it's available

            // here in DoWorkEventArgs object.
            e.Result = dgvselectioncommand();//dbi.dgvselectioncommand("SELECT * FROM `" + gl.tbl_studentinfo + "`", "", "", "", "", "", this.Name, dataGridView1.Name);

        }

        void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }

            else
            {
                try
                {
                    DataSet dbpull = (DataSet)e.Result;
                    DataGridView dgv = Application.OpenForms[frmname].Controls[dgn] as DataGridView;
                    dgv.ScrollBars = ScrollBars.None;
                    dgv.DataSource = (dbpull.Tables[0]);
                    if (frmname == "Reports")
                    {
                        for (int i = 0; i <= 12; i++)
                        {
                            if (i <= 1)
                                dgv.Columns[i].Visible = false;
                            if (i != 11)
                                dgv.Columns[i].ReadOnly = true;
                        }
                    }
                    if (frmname == "Teacher")
                    {
                        dgv.Columns[0].Visible = false;
                        dgv.Columns[1].Visible = false;
                    }
                    if (frmname == "Teacher_Editor")
                    {
                        dgv.Columns[0].Visible = false;
                        dgv.Columns[2].Visible = false;
                    }
                    if (frmname == "Email")
                        dgv.Columns[0].Visible = false;
                    if (frmname == "Student_Editor")
                        dgv.Columns[0].Visible = false;
                    dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    finished = true;
                    dgv.ScrollBars = ScrollBars.Both;
                }
                catch (Exception) { }
            }

        }
        public DataSet dgvselectioncommand()
        {
            DataSet ds = new DataSet();
            try
            {
                ds.Clear();
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, gl.oleconnection);
                if (teacher != null && teacher != "")
                    dataAdapter.SelectCommand.Parameters.Add("teacher", OleDbType.VarChar, 50).Value = teacher;
                if (infraction != null && infraction != "")
                    dataAdapter.SelectCommand.Parameters.Add("infraction", OleDbType.VarChar, 20).Value = infraction;
                if (firstname != null && firstname != "")
                {
                    dataAdapter.SelectCommand.Parameters.Add("firstname", OleDbType.VarChar, 20).Value = firstname;
                    dataAdapter.SelectCommand.Parameters.Add("lastname", OleDbType.VarChar, 20).Value = lastname;
                    dataAdapter.SelectCommand.Parameters.Add("studentid", OleDbType.VarChar, 20).Value = studentid;
                }
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.Fill(ds);
                
            }
            catch (Exception) { }
            return ds;
        }

        public void dbcommands(string sql, string[] parameter, string[] text)
        {
            OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
            oledbAdapter.InsertCommand = new OleDbCommand(sql, gl.oleconnection);
            for (int i = 0; i < parameter.Length; i++)
                if (parameter[i] != "")
                    oledbAdapter.InsertCommand.Parameters.AddWithValue(parameter[i], text[i]);
            if (gl.oleconnection.State == ConnectionState.Closed) gl.oleconnection.Open();
            oledbAdapter.InsertCommand.ExecuteNonQuery();
            if (gl.oleconnection.State == ConnectionState.Open) gl.oleconnection.Close();
        }
    }
}
