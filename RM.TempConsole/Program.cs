using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RemoteManual;
#pragma warning disable 618

// for the test use the qr-code supplied with the program

namespace RM.TempConsole
{
    class Program
    {
        static void Main()
        {
            FileFinder myProgram = new FileFinder();
            myProgram.Run();
        }

       
    }
}
