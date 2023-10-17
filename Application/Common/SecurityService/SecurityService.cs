using Core.Interfaces.ISecurityService;
using System.Security.Cryptography;
using System.Text;

namespace Application.Common.SecurityService
{
    public class SecurityService : ISecurityService
    {
        private const string _constantNumberP1 = "for key";
        private const string _constantNumberP2 = "%%&*";
        private string _key;
        private string _SystemPassword;


        public SecurityService()
        {
        }


        private void GenerateKey()
        {

            _key = _constantNumberP2 + _constantNumberP1;
        }


        #region Token Operations

        public string EncryptPlainText(string plainText)
        {
            GenerateKey();
            return EncryptData(plainText);
        }
        public string DecryptCipherText(string cipherText)
        {
            GenerateKey();
            return DecryptData(cipherText);
        }

        #endregion

        #region Data Protection

        private string EncryptData(string plainText)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(plainText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(_key, new byte[] {
                    0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    _SystemPassword = Convert.ToBase64String(ms.ToArray());
                }
            }
            return _SystemPassword;
        }
        private string DecryptData(string cipherText)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(_key, new byte[] {
                    0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    _SystemPassword = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return _SystemPassword;
        }
        #endregion
    }
}
