using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RemoteManual;

namespace WindowsFormsApplication1
{
    public partial class MainUI : Form
    {
        private string ImagePath;
        public MainUI()
        {
            InitializeComponent();
        }

        private void MainUI_Load(object sender, EventArgs e)
        {

        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin fl = new frmLogin();
            fl.Show();
        }

        private void btn_CreateUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateUser cu = new CreateUser();
            cu.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileFinder myProgram = new FileFinder();
            myProgram.GetFile();
            pictureBox1.Image = Image.FromFile(myProgram.ImgPath);
            ImagePath = myProgram.ImgPath;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            QR_Scanner QRS = new QR_Scanner();
            QRS.ScanQRCodeFromFile(ImagePath);
        }
    }
}
