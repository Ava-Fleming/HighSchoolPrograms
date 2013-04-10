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
        DB_Interaction dbi = new DB_Interaction();
        string sql = "";
        private void Infractions_List_Load(object sender, EventArgs e)
        {
            try
            {
                if (gl.oleconnection.State == ConnectionState.Closed)
                    gl.oleconnection.Open();
                OleDbCommand getinfractionscommand = gl.oleconnection.CreateCommand();
                getinfractionscommand.CommandText = "SELECT * FROM `"+gl.tbl_infractionlist+"`";
                OleDbDataReader getinfraction = getinfractionscommand.ExecuteReader();
                while (getinfraction.Read())
                {
                    listBox_infractions.Items.Add(getinfraction[gl.col_infractions].ToString());
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
                    sql = "INSERT INTO `" + gl.tbl_infractionlist + "` VALUES (@infraction)";
                    dbi.dbcommands(sql, this.Name, "", "", "", "", "", textBox_infraction.Text, "", "", "");
                    listBox_infractions.Items.Add(textBox_infraction.Text);
                    textBox_infraction.Clear();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("ERROR ON INSERTION\n" + x.Message,"Error");
            }
        }

        private void button_removeinfraction_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox_infractions.SelectedItem != null)
                {
                    sql = "DELETE * FROM `" + gl.tbl_infractionlist + "` WHERE " + gl.col_infractions + "=@infraction";
                    dbi.dbcommands(sql, this.Name, "", "", "", "", "", listBox_infractions.SelectedItem.ToString(), "", "", "");
                    listBox_infractions.Items.Remove(listBox_infractions.SelectedItem);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}