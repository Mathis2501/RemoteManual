using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteManual
{
    public class FileFinder
    {

        public string ImgPath;

        QR_Scanner Path = new QR_Scanner();

        public void Run()
        {
            Thread threadGetFile = new Thread(GetFile) { ApartmentState = ApartmentState.STA };
            threadGetFile.Start();
        }

        internal void GetFile()
        {
            OpenFileDialog PathFinder = new OpenFileDialog();
            PathFinder.Filter = "All Files (*.*)|*.*";
            PathFinder.FilterIndex = 1;

            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            process.StartInfo = startInfo;
            
            
            if (PathFinder.ShowDialog() == DialogResult.OK)
            {
                ImgPath = PathFinder.FileName;
                Console.WriteLine(ImgPath);
                ImgPath = ImgPath.Replace(@"\", "/");
                Console.WriteLine(ImgPath);
                Console.ReadLine();
                Path.ScanQRCodeFromFile(ImgPath);

            }
        }
    }
}
