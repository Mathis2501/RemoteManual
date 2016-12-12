using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private string cs =
            @"Data Source=ealdb1.eal.local;Persist Security Info=True;User ID=ejl60_usr;Password=Baz1nga60";

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_UserName.Text == "" || txt_Password.Text == "")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }
            try
            {
                bool AccessAllowed = false;
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();
                    SqlCommand cmdpass = new SqlCommand("s",connection);
                    cmdpass.CommandText = "SELECT Password FROM USER_DATABASE WHERE UserName LIKE '" + txt_UserName.Text + "'";
                    string savedHashedPass = (string) cmdpass.ExecuteScalar();

                    byte[] hashBytes = Convert.FromBase64String(savedHashedPass);
                    byte[] salt = new byte[16];
                    Array.Copy(hashBytes, 0, salt, 0, 16);
                    string password;
                    var pbkdf2 = new Rfc2898DeriveBytes(txt_Password.Text, salt, 10000);
                    byte[] hash = pbkdf2.GetBytes(20);
                    for (int i = 0; i < 20; i++)
                    {
                        if (hashBytes[i+16] != hash[i])
                        {
                            throw new UnauthorizedAccessException();
                        }
                        else
                        {
                            AccessAllowed = true;
                        }
                    }
                }
                
                if (AccessAllowed)
                {
                    MessageBox.Show("Login Successful!");
                    this.Hide();
                    MainUI fm = new MainUI();
                    fm.Show();
                }
                else
                {
                    MessageBox.Show("Login Failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
