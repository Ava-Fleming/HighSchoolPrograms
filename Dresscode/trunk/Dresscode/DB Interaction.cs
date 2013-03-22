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
        public string selectioncommand(string sql, string firstname, string lastname)
        {
            try
            {
                DataSet ds = new DataSet();
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, gl.oleconnection);
                dataAdapter.SelectCommand.Parameters.Add("firstname", OleDbType.VarChar, 255).Value = firstname;
                dataAdapter.SelectCommand.Parameters.Add("lastname", OleDbType.VarChar, 255).Value = lastname;
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.Fill(ds);
                DataGridView dgv = Application.OpenForms["Reports"].Controls["dataGridView_reports"] as DataGridView;
                dgv.DataSource = ds.Tables[0];

                for (int i = 0; i <= 10; i++)
                {
                    if (i <= 2)
                        dgv.Columns[i].Visible = false;
                    dgv.Columns[i].ReadOnly = true;
                }
                dgv.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error");
            }
            finally
            {
                gl.oleconnection.Close();
            }
            return null;
        }
    }
}
