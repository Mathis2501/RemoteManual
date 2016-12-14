using System;
using System.Windows.Forms;
using RemoteManual;

namespace WindowsFormsApplication1
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
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
                CheckPassword CP = new CheckPassword();
                CP.txt_Password = txt_Password.Text;
                CP.txt_UserName = txt_UserName.Text;
                
                CP.CheckIfLoginIsAccepted();

                if (CP.AccessAllowed)
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
    }
}
