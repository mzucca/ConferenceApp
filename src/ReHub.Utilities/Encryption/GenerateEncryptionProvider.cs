using System.Security.Cryptography;
using System.Text;

namespace ReHub.Utilities.Encryption
{
    public class GenerateEncryptionProvider : IEncryptionProvider
    {
        private Encryption _encrypt;

        public GenerateEncryptionProvider(string password, EncryptionAlgorithm algorithm)
        {
            _encrypt = new Encryption(password, algorithm);
        }

        public string Encrypt(string dataToEncrypt)
        {
            return _encrypt.Encrypt(dataToEncrypt);
        }

        public string Decrypt(string dataToDecrypt)
        {
            return _encrypt.DecryptString(dataToDecrypt);
        }
    }
}
