using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VoteIT
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            Program.UserName = txtUsername.Text;
            Program.PassWord = txtPassword.Text;
            SqlConnection sqlCon = new SqlConnection(@"Data Source=devlabpm.westeurope.cloudapp.azure.com; Initial Catalog = PSIM1619I_RodrigoRego_2219113; User ID = PSIM1619I_RodrigoRego_2219113; Password = 2dM8B2B5; ");
            string query = "Select * from tbl_User Where username = '" + txtUsername.Text.Trim() + "' and password = '" + txtPassword.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlCon);
            DataTable tbl_User = new DataTable();
            sda.Fill(tbl_User);
            if (tbl_User.Rows.Count == 1)
            {
                Main objMain = new Main();
                this.Hide();
                objMain.Show();

            }
            else
            {
                MessageBox.Show("Check your username and password");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void registerLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            register reg = new register();
            reg.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
