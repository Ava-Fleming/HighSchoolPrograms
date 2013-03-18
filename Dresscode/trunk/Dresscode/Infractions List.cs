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
    public partial class Infractions_List : Form
    {
        public Infractions_List()
        {
            InitializeComponent();
        }
        globals gl = new globals();
        string sql = "";
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
                    gl.oleconnection.Open();
                    OleDbDataAdapter oledba_addinfraction = new OleDbDataAdapter();
                    sql = "INSERT INTO `Infraction List` VALUES (@infraction)";
                    oledba_addinfraction.InsertCommand = new OleDbCommand(sql, gl.oleconnection);
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
                if (gl.oleconnection.State == ConnectionState.Open)
                    gl.oleconnection.Close();
            }
        }

        private void button_removeinfraction_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox_infractions.SelectedItem != null)
                {
                    gl.oleconnection.Open();
                    OleDbDataAdapter oledba_deleteinfraction = new OleDbDataAdapter();
                    sql = "DELETE * FROM `Infraction List` WHERE infractions=@infraction";
                    oledba_deleteinfraction.DeleteCommand = new OleDbCommand(sql, gl.oleconnection);
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
                gl.oleconnection.Close();
            }
        }

        private void Infractions_List_Load(object sender, EventArgs e)
        {
            gl.oleconnection.Open();
            OleDbCommand getinfractionscommand = gl.oleconnection.CreateCommand();
            getinfractionscommand.CommandText = "SELECT * FROM `Infraction List`";
            OleDbDataReader getinfraction = getinfractionscommand.ExecuteReader();
            while (getinfraction.Read())
            {
                listBox_infractions.Items.Add(getinfraction["infractions"].ToString());
            }
        }

        private void textBox_infraction_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button_addinfraction.PerformClick();
        }
    }
}