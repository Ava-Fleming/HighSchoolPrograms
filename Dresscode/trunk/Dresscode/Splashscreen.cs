using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace Dresscode
{
    public partial class Splashscreen : Form
    {
        public Splashscreen()
        {
            InitializeComponent();
        }
        int time = 950;
        int count = 1;
        bool connectable = false;
        globals gl = new globals();
        private void Splashscreen_Load(object sender, EventArgs e)
        {
            try
            {
                timer1.Interval = time * 4;
                timer2.Interval = time;
                timer1.Enabled = true;
                timer2.Enabled = true;
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    if(gl.oleconnection.State == ConnectionState.Closed)
                        gl.oleconnection.Open();
                    connectable = true;
                }
                else
                    MessageBox.Show("You are not connected to the internet my young padawan", "Error");
            }
            catch (Exception)
            {
            }
            finally
            {
                if (gl.oleconnection.State == ConnectionState.Open)
                    gl.oleconnection.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            if (connectable)
            {
                Login login = new Login();
                this.Hide();
                if (login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Login());
                }
            }
            else
            {
                MessageBox.Show("Your connection to the database is inaccessible\nPlease relaunch the application.\nIf the problem persists, contact an administrator.", "Error");
                Application.Exit();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
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
                    if (count == 2)
                    {
                        pictureBox1.Image = Properties.Resources.markhor3;
                        count++;
                    }
                    else
                    {
                        pictureBox1.Image = Properties.Resources.morkhorcomputerdms;
                    }
                }
            }
        }
    }
}
