using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace RemoteManual
{
    public class FileFinder
    {

        public string ImgPath;

        public void GetFile()
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
                ImgPath = ImgPath.Replace(@"\", "/");
            }
        }
    }
}
