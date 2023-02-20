using ECommerceV2.Services.Abstract.Encryption;
using System.Text;

namespace ECommerceV2.Services.Concrete.Encryption
{
    public class Base64Encryption : IEncryptionStrategy
    {
        public string Encrypt(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public string Decrypt(string cipherText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            return Encoding.UTF8.GetString(cipherTextBytes);
        }
    }
}
