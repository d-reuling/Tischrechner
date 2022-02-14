using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tischrechner
{
    public partial class Bruch : Form
    {
        public Bruch()
        {
            InitializeComponent();
        }

        byte selected_label;

        private void label1_Click(object sender, EventArgs e)
        {
            selected_label = 1;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            selected_label = 2;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            selected_label = 3;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            selected_label = 4;
        }

        private void bPlus_Click(object sender, EventArgs e)
        {
            op.Visible = true;
            op.Text = "+";
        }

        private void bMinus_Click(object sender, EventArgs e)
        {
            op.Visible = true;
            op.Text = "-";
        }

        private void bMal_Click(object sender, EventArgs e)
        {
            op.Visible = true;
            op.Text = "*";
        }

        private void bGeteilt_Click(object sender, EventArgs e)
        {
            op.Visible = true;
            op.Text = "/";
        }

        private void b1_Click(object sender, EventArgs e)
        {
            if (selected_label != null)
            {

            }
        }
    }
}
