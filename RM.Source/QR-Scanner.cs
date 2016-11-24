using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PQScan.BarcodeScanner;
using System.Drawing;
using System.Net;

namespace RemoteManual
{
    class QR_Scanner
    {
        public string extractedData = "";
        public string Manual;


        internal void ScanQRCodeFromFile(string ImgPath)
        {
            
            
            BarcodeResult[] results = BarCodeScanner.Scan(ImgPath);

            foreach (BarcodeResult result in results)
            {
                extractedData = result.Data;
                Console.WriteLine(extractedData);
                extractedData = extractedData.Substring(1);
                Console.WriteLine(extractedData);
                System.Diagnostics.Process.Start(extractedData);

            }
        }

        
    }
}
