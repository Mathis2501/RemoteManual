using System;
using System.Drawing;
using System.Windows.Forms;
using RemoteManual;

namespace WindowsFormsApplication1
{
    public partial class MainUI : Form
    {
        private string ImagePath = "";

        public MainUI()
        {
            InitializeComponent();
        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin fl = new frmLogin();
            fl.Show();
        }

        private void btn_CreateUser_Click(object sender, EventArgs e)
        {
            CreateUser cu = new CreateUser();
            cu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FileFinder myProgram = new FileFinder();
                ImageResize IR = new ImageResize();
                myProgram.GetFile();
                Image QRImage = Image.FromFile(myProgram.ImgPath);
                QRImage = IR.ResizeImage(QRImage, 128, 128);
                pictureBox1.Image = QRImage;
                ImagePath = myProgram.ImgPath;
            }
            catch (ArgumentNullException)
            {
                
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ImagePath != "")
            {
                QR_Scanner QRS = new QR_Scanner();
                QRS.ScanQRCodeFromFile(ImagePath);
                System.Diagnostics.Process.Start(QRS.extractedData);
            }
            else
            {
                MessageBox.Show("Error: Please Specify QR-Code to Scan");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PreviouslyDownloadedManuals PDM = new PreviouslyDownloadedManuals();
            PDM.Show();
            MessageBox.Show(@"This feature has not been implemented but is intended to show all previously downloaded manuals");
            PDM.Hide();
        }
    }
}
