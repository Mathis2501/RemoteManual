using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using RemoteManual;

namespace WindowsFormsApplication1
{
    public partial class CreateUser : Form
    {

        private string cs =
            @"Data Source=ealdb1.eal.local;Persist Security Info=True;User ID=ejl60_usr;Password=Baz1nga60";

        public CreateUser()
        {
            InitializeComponent();
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            SaltUserPassword createUser = new SaltUserPassword();
            string hashedPassword = createUser.PasswordSaltHash(txt_Password.Text);

            if (txt_UserName.Text == "" || txt_Password.Text == "")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = new SqlCommand("spAddUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@UserName", txt_UserName.Text));
                cmd.Parameters.Add(new SqlParameter("@PassWord", hashedPassword));

                cmd.ExecuteNonQuery();
                con.Close();

                this.Hide();
                MessageBox.Show("The User Has Been Created");
                MainUI fm = new MainUI();
                fm.Show();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
