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
