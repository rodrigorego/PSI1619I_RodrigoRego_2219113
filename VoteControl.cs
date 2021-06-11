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
    public partial class VoteControl : UserControl
    {
        public VoteControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=devlabpm.westeurope.cloudapp.azure.com; Initial Catalog = PSIM1619I_RodrigoRego_2219113; User ID = PSIM1619I_RodrigoRego_2219113; Password = 2dM8B2B5; ");
            string query = "Select * from tbl_Keyy Where KeyID = '" + textBox1.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlCon);
            DataTable tbl_Keyy = new DataTable();
            sda.Fill(tbl_Keyy);
            if (tbl_Keyy.Rows.Count == 1)
            {
               Vote2Control first = new Vote2Control();
                this.Hide();
                this.Parent.Controls.Add(first);

            }
            else
            {
                MessageBox.Show("Check your Invite Code");
            }
        }

        private void VoteControl_Load(object sender, EventArgs e)
        {
            Vote2Control first = new Vote2Control();
            this.Hide();
            
        }
    }
    
}
