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
using MongoDB.Driver.Core.Configuration;
using System.Configuration;
using System.IO;

namespace VoteIT
{
    public partial class register : Form
    {
        string connectionString = (@"Data Source=devlabpm.westeurope.cloudapp.azure.com; Initial Catalog = PSIM1619I_RodrigoRego_2219113; User ID = PSIM1619I_RodrigoRego_2219113; Password = 2dM8B2B5; ");
        public register()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
                MessageBox.Show("please fill mandatory fields");
            else if (txtPassword.Text != txtConfirmPass.Text)
                MessageBox.Show("Password do not match");
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("UserAdd", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Registration is successfull");
                    this.Close();
                    Clear();
                }
            }
            void Clear()
            {
                txtFirstName.Text = txtLastName.Text = txtContact.Text = txtAddress.Text = txtUsername.Text = txtPassword.Text = txtConfirmPass.Text = "";
            }
        }

        private void register_Load(object sender, EventArgs e)
        {
            

        }
        
    }
}

