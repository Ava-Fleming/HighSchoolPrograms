using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace votingsystem
{
    public partial class Splashscreen : Form
    {
        public Splashscreen()
        {
            InitializeComponent();
        }
        int count = 1;
        bool connectable = false;
        connectioninfo conninfo = new connectioninfo();
        private void Splashscreen_Load(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = true;
                timer2.Enabled = true;
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    conninfo.oleconnection.Open();
                    connectable = true;
                }
            }
            catch(Exception)
            {
            }
            finally
            {
                conninfo.oleconnection.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            if (connectable)
            {
                form_login frm_login = new form_login();
                this.Hide();
                if (frm_login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new form_login());
                }
            }
            else
            {
                MessageBox.Show("Your connection to the database is inaccessible\nPlease relaunch the application.\nIf the problem persists, contact an administrator.", "Error");
                Application.Exit();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (count == 0)
            {
                pictureBox1.Image = Properties.Resources.markhor1;
                count++;
            }
            else
            {
                if (count == 1)
                {
                    pictureBox1.Image = Properties.Resources.markhor2;
                    count++;
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.markhor3;
                }
            }
        }
    }
}
