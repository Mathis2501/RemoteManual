using System;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace RemoteManual
{
    public class CheckPassword
    {
        public string txt_UserName;
        public string txt_Password;
        public bool AccessAllowed = false;

        public void CheckIfLoginIsAccepted()
        {
            

            try
            {
                const string cs = @"Data Source=ealdb1.eal.local;Persist Security Info=True;User ID=ejl60_usr;Password=Baz1nga60";

                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();
                    SqlCommand cmdpass = new SqlCommand("s", connection);
                    cmdpass.CommandText = "SELECT Password FROM USER_DATABASE WHERE UserName LIKE '" + txt_UserName + "'";
                    string savedHashedPass = (string)cmdpass.ExecuteScalar();

                    byte[] hashBytes = Convert.FromBase64String(savedHashedPass);
                    byte[] salt = new byte[16];
                    Array.Copy(hashBytes, 0, salt, 0, 16);
                    var pbkdf2 = new Rfc2898DeriveBytes(txt_Password, salt, 10000);
                    byte[] hash = pbkdf2.GetBytes(20);
                    for (int i = 0; i < 20; i++)
                    {
                        if (hashBytes[i + 16] != hash[i])
                        {
                            throw new UnauthorizedAccessException();
                        }
                        else
                        {
                            AccessAllowed = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }
    }
}
