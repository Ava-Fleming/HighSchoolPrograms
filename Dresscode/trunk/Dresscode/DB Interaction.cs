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
        public string dgvselectioncommand(string sql, string firstname, string lastname, string studentid,string teacher, string infraction, string frmname, string dgn)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.Clear();
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, gl.oleconnection);
                if(teacher != "")
                dataAdapter.SelectCommand.Parameters.Add("teacher", OleDbType.VarChar, 50).Value = teacher;
                if(infraction != "")
                dataAdapter.SelectCommand.Parameters.Add("infraction", OleDbType.VarChar, 20).Value = infraction;
                if (firstname != "")
                {
                    dataAdapter.SelectCommand.Parameters.Add("firstname", OleDbType.VarChar, 20).Value = firstname;
                    dataAdapter.SelectCommand.Parameters.Add("lastname", OleDbType.VarChar, 20).Value = lastname;
                    dataAdapter.SelectCommand.Parameters.Add("studentid", OleDbType.VarChar, 20).Value = studentid;
                }
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                DataGridView dgv = Application.OpenForms[frmname].Controls[dgn] as DataGridView;
                dataAdapter.Fill(ds);
                dgv.DataSource = (ds.Tables[0]);
                if (frmname == "Reports")
                {
                    for (int i = 0; i <= 12; i++)
                    {
                        if (i <= 1)
                            dgv.Columns[i].Visible = false;
                        if(i != 11)
                            dgv.Columns[i].ReadOnly = true;
                    }
                    dgv.AutoResizeColumns(
                        DataGridViewAutoSizeColumnsMode.AllCells);
                }
                if (frmname == "Teacher")
                {
                    dgv.Columns[0].Visible = false;
                    dgv.Columns[1].Visible = false;
                    dgv.AutoResizeColumns(
                        DataGridViewAutoSizeColumnsMode.AllCells);
                }
                if (frmname == "Teacher_Editor")
                {
                    dgv.Columns[1].Visible = false;
                    dgv.AutoResizeColumns(
                        DataGridViewAutoSizeColumnsMode.AllCells);
                }
                if (frmname == "Email")
                {
                    for (int i = 0; i <= 12; i++)
                    {
                        if (i <= 1)
                            dgv.Columns[i].Visible = false;
                        dgv.Columns[i].ReadOnly = true;
                    }
                    dgv.AutoResizeColumns(
                        DataGridViewAutoSizeColumnsMode.AllCells);
                }
            }
            catch (Exception x)
            {
               if(x.Message != "Operation is not valid because it results in a reentrant call to the SetCurrentCellAddressCore function")
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
