using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
#pragma warning disable 618

namespace RM.TempConsole
{
    class Program
    {
        static void Main()
        {
            Program myProgram = new Program();
            myProgram.Run();
        }

        private void Run()
        {
            Thread threadGetFile = new Thread(GetFile) {ApartmentState = ApartmentState.STA};
            threadGetFile.Start();
        }

        void GetFile()
        {
            OpenFileDialog PathFinder = new OpenFileDialog();
            PathFinder.Filter = "PDF Files|*.PDF";
            PathFinder.FilterIndex = 1;

            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            process.StartInfo = startInfo;

            string PDFName;
            

            FolderBrowserDialog FolderLocation = new FolderBrowserDialog();

            if (PathFinder.ShowDialog() == DialogResult.OK)
            {
                PDFName = PathFinder.FileName;
                startInfo.FileName = PDFName;
                process.Start();
            }

            



        }

    }
}
