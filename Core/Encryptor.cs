using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DEncrypt.Core
{
    internal class Encryptor
    {
        private const int SaltSize = 32;
        private const int KeySize = 32;
        private const int IvSize = 16;

        #region - Encrypt -
        public static void EncryptFile(string inputFile, string outputFile, string password)
        {
            // Random Salt
            byte[] salt = new byte[SaltSize];
            
            RandomNumberGenerator.Fill(salt);

            byte[] key = DeriveKey(password, salt);
            


        }

        #endregion

        #region - Helpers -

        // Derive Bytes
        public static byte[] DeriveKey(string password, byte[] salt)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, 100000))
            {
                return deriveBytes.GetBytes(KeySize);
            }
        }

        #endregion
    }
}
