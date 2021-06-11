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
using System.Configuration;

namespace VoteIT
{
    public partial class AccControl1 : UserControl
    {
        public AccControl1()
        {
            InitializeComponent();
            panel1.Hide();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            
          
        }
    }
}
