using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoteIT
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            createControl1.Hide();
            homeControl1.Hide();
            accControl11.Hide();
            voteControl1.Hide();
            statsControl1.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            createControl1.Hide();
            homeControl1.Hide();
            accControl11.Hide();
            voteControl1.Show();
            statsControl1.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            voteControl1.Hide();
            homeControl1.Hide();
            accControl11.Hide();
            statsControl1.Hide();
            createControl1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            voteControl1.Hide();
            createControl1.Hide();
            accControl11.Hide();
            homeControl1.Show();
            statsControl1.Hide();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            lblUserName.Text = Program.UserName;
            homeControl1.Show();
            createControl1.Hide();
            voteControl1.Hide();
            accControl11.Hide();
            statsControl1.Hide();

        }

        private void lblUserName_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            accControl11.Show();
            voteControl1.Hide();
            createControl1.Hide();
            homeControl1.Hide();
            statsControl1.Hide();

        }
    }
}
