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
    public partial class dgt : Form
    {
        public dgt()
        {
            InitializeComponent();
        }
        private OleDbDataAdapter dataadapter = null;
        globals gl = new globals();

        private BindingSource bindingSource1 = new BindingSource();

        private void dgt_Load(object sender, EventArgs e)
        {
            
            //
            try
            {
                dataGridView1.DataSource = bindingSource1;
                // Specify a connection string. Replace the given value with a  
                // valid connection string for a Northwind SQL Server sample 
                // database accessible to your system.

                // Create a new data adapter based on the specified query.
                dataadapter = new OleDbDataAdapter("SELECT * FROM `Reports` WHERE dayofyear BETWEEN #3/2/2013# AND #3/2/2013#", gl.oleconnection);

                // Create a command builder to generate SQL update, insert, and 
                // delete commands based on selectCommand. These are used to 
                // update the database.
                OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(dataadapter);
                

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                
                //table.TableName[0];
                dataadapter.Fill(table);
                //
                bindingSource1.DataSource = table;
                

                // Resize the DataGridView columns to fit the newly loaded content.
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataadapter.Update((DataTable)bindingSource1.DataSource);
            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
            }
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            button1.PerformClick();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
