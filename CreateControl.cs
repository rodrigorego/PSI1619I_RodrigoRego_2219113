using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoteIT
{
    public partial class CreateControl : UserControl
    {
        string connectionString = (@"Data Source=devlabpm.westeurope.cloudapp.azure.com; Initial Catalog = PSIM1619I_RodrigoRego_2219113; User ID = PSIM1619I_RodrigoRego_2219113; Password = 2dM8B2B5; ");
        public CreateControl()
        {
            InitializeComponent();
        }

        int Disunit = 1;
        int Top = 150;
        int Left = 341;
        int count = 0;
        public static int restrict6 = 0;
        private void button1_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                if (restrict6 < 5)
                {

                    restrict6++;
                    count++;
                    for (int i = 0; i < count; i++)
                    {
                        TextBox txtUser = new TextBox();
                        flowLayoutPanel1.Controls.Add(txtUser);
                        txtUser.Name = "txtUser";
                        txtUser.Location = new System.Drawing.Point(Left, Top);
                        txtUser.TabIndex = 19;
                        txtUser.Text = "...";
                        txtUser.Size = new System.Drawing.Size(310, 38);
                        Top += 50;
                        count--;
                    }
                }

                else
                {
                    MessageBox.Show("Cant add more options !!");
                }
            }
        }
        public static int restrict = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
               
                if (restrict == 0)
                {
                    
                    restrict++;
                    char[] letters = "qwertyuioplkjhgfdsazxcmnbv1234567890".ToCharArray();
                    Random r = new Random();
                    string randomString = "";
                    for (int i = 0; i < 15; i++)
                    {
                        randomString += letters[r.Next(0, 35)].ToString();
                        UserKey.Text = randomString;
                    }
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("KeyyAdd", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@KeyID", UserKey.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
                else
                {
                    MessageBox.Show("Already Generated a key !!");
                }
            }
        }
        public static int restricti = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            if (restricti == 0)
            {

                restricti++;
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {


                    foreach (Control c in flowLayoutPanel1.Controls)
                    {
                        TextBox item = (c as TextBox);
                        

                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("VoteIT", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@Question", richTextBox1.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Option1", textBox1.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Option2", c.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Option3", c.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Option4", c.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Option5", c.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Option6", c.Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        sqlCon.Close();

                    }
                }
            }
            else
            {
                MessageBox.Show("Already Saved !!");
            }
        }
    }
}
