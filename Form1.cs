using System;
using System.Data;
using System.Windows.Forms;
using VoteIT.Connection;
namespace VoteIT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            usernameTextBox.Select();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OpenRegisterFormLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm register = new RegisterForm();
            register.ShowDialog();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(usernameTextBox.Text) &&
                    !string.IsNullOrEmpty(passwordTextBox.Text))
            {
                string mySQL = string.Empty;

                mySQL += "SELECT * From LoginTb1 ";
                mySQL += "WHERE Username _= '" + usernameTextBox.Text + "' ";
                mySQL += "AND Password = '" + passwordTextBox.Text + "' ";

                DataTable userData = ServerConnection.executeSQL(mySQL);
                
                if(userData.Rows.Count > 0)
                {
                    usernameTextBox.Clear();
                    passwordTextBox.Clear();
                    showPasswordCheckBox.Checked = false;

                    this.Hide();

                   Main formMain = new Main();
                    formMain.ShowDialog();
                    formMain = null;

                    this.Show();
                    this.usernameTextBox.Select();

                }
                else
                {
                    MessageBox.Show("The username or pssword is incorrect. Try again.",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    usernameTextBox.Focus();
                    usernameTextBox.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("Please enter username and password.",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                usernameTextBox.Select();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
