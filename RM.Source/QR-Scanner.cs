using PQScan.BarcodeScanner;

//Transfer to Desktop

namespace RemoteManual
{
    public class QR_Scanner
    {
        public string extractedData = "";


        public void ScanQRCodeFromFile(string ImgPath)
        {
            
            
            BarcodeResult[] results = BarCodeScanner.Scan(ImgPath);

            foreach (BarcodeResult result in results)
            {
                extractedData = result.Data;
                extractedData = extractedData.Substring(1);
                System.Diagnostics.Process.Start(extractedData);

            }
        }

        
    }
}
