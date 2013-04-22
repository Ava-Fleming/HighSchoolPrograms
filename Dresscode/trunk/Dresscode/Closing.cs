using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dresscode
{
    public partial class Closing : Form
    {
        public Closing()
        {
            InitializeComponent();
        }
        int count = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count == 0) { pictureBox1.Image = Properties.Resources.Waving_Markhor1; count++; }
            else
            {
                if (count == 1) { pictureBox1.Image = Properties.Resources.Waving_Markhor2; count++; }
                else
                {
                    if (count == 2) { pictureBox1.Image = Properties.Resources.Waving_Markhor3; count++; }
                    else
                    {
                        if (count == 3) { pictureBox1.Image = Properties.Resources.Waving_Markhor2; count++; }
                        else
                        {
                            if (count == 4) { pictureBox1.Image = Properties.Resources.Waving_Markhor1; count++; }
                            else
                            {
                                if (count == 5) { pictureBox1.Image = Properties.Resources.Waving_Markhor2; count++; }
                                else
                                {
                                    if (count == 6) { pictureBox1.Image = Properties.Resources.Waving_Markhor3; count++; }
                                    else
                                        Application.Exit();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Closing_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Waving_Markhor1;
            timer1.Interval = 250;
            timer1.Enabled = true;

        }
    }
}
