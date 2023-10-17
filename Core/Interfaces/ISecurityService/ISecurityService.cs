namespace  Core.Interfaces.ISecurityService
{
    public interface ISecurityService
    {
        string DecryptCipherText(string cipherText);
        string EncryptPlainText(string plainText);
      
    }
}
