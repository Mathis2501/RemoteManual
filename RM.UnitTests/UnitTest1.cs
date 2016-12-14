using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoteManual;

namespace Remote_Manual
{
    [TestClass]
    public class TestQRFramework
    {
        QR_Scanner QRS;
        CheckPassword CP;
        SaltUserPassword CU;


        [TestMethod]
        public void TestQRMethod()
        {
            QRS = new QR_Scanner();
            string QRFileLocation =
                @"C:\Users\MathiasBellerbySylve\Documents\Visual Studio 2015\Projects\RemoteManual\Lib\static_qr_code_without_logo.jpg";

            QRS.ScanQRCodeFromFile(QRFileLocation);

            Assert.AreEqual("https://goo.gl/zmdhuW", QRS.extractedData);
        }

        [TestMethod]
        public void CanSaltHashDehashDesalt()
        {
            CU = new SaltUserPassword();
            CP = new CheckPassword();

            string SaltedAndHashedPassword = CU.PasswordSaltHash("1");
            CP.txt_Password = SaltedAndHashedPassword;
            CP.txt_UserName = "1";
            try
            {
                CP.CheckIfLoginIsAccepted();
            }
            catch (UnauthorizedAccessException)
            {
                
            }


            Assert.IsTrue(CP.AccessAllowed);
        }
    }
}
