using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DEncrypt.Core;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Runtime.InteropServices;
namespace DEncrypt.Core
{
    internal class Encryptor
    {
        // Signatures
        public const string SignaturePrefix = "ENC_DFILE_";
        private const int SaltSize = 32;
        private const int KeySize = 32;
        private const int IvSize = 16;

        
        #region - Encrypt -
        public static async void EncryptFile(string inputFile, string outputFile, string password, Guid fileGuid)
        {
            DEncryptor.Instance.SetBarProgress(0);
            DEncryptor.Instance.AddBarProgress(15);
            // Generate a random salt
            byte[] salt = new byte[SaltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            DEncryptor.Instance.AddBarProgress(15);
            // Derive key from password
            byte[] key = DeriveKey(password, salt);

            // Generate random IV
            byte[] iv = new byte[IvSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(iv);
            }
            DEncryptor.Instance.AddBarProgress(15);
            // Create signature using GUID
            string signature = SignaturePrefix + fileGuid.ToString();
            DEncryptor.Instance.AddBarProgress(15);
            byte[] signatureBytes = Encoding.UTF8.GetBytes(signature);
            DEncryptor.Instance.AddBarProgress(15);
            using (var fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
            using (var fsOutput = new FileStream(outputFile, FileMode.Create))
            {
                // Write salt, IV, and signature length
                fsOutput.Write(salt, 0, salt.Length);
                fsOutput.Write(iv, 0, iv.Length);
                fsOutput.Write(BitConverter.GetBytes(signatureBytes.Length), 0, 4);
                fsOutput.Write(signatureBytes, 0, signatureBytes.Length);
                DEncryptor.Instance.AddBarProgress(15);
                // Encrypt the file content
                using (var aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;

                    using (var cs = new CryptoStream(fsOutput, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        fsInput.CopyTo(cs);
                    }
                }
            }
            DEncryptor.Instance.AddBarProgress(10);
            
            MessageBox.Show($"File encrypted successfully!\nSaved to: {outputFile}");
            DEncryptor.Instance.SetBarProgress(0);
        }

        #endregion

        #region - Decrypt -

        public static async Task<bool> DecryptFile(string inputFile, string outputFile, string password, Guid expectedGuid)
        {
            try
            {
                using (var fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                {
                    // Read salt and IV
                    byte[] salt = new byte[SaltSize];
                    byte[] iv = new byte[IvSize];
                    fsInput.Read(salt, 0, salt.Length);
                    fsInput.Read(iv, 0, iv.Length);

                    // Read signature
                    byte[] signatureLengthBytes = new byte[4];
                    fsInput.Read(signatureLengthBytes, 0, 4);
                    int signatureLength = BitConverter.ToInt32(signatureLengthBytes, 0);
                    byte[] signatureBytes = new byte[signatureLength];
                    fsInput.Read(signatureBytes, 0, signatureLength);
                    string signature = Encoding.UTF8.GetString(signatureBytes);

                    // Verify signature
                    if (!signature.StartsWith(SignaturePrefix))
                        return false;

                    string guidString = signature.Substring(SignaturePrefix.Length);
                    if (!Guid.TryParse(guidString, out Guid fileGuid) || fileGuid != expectedGuid)
                        return false;

                    // Derive key from password
                    byte[] key = DeriveKey(password, salt);

                    using (var fsOutput = new FileStream(outputFile, FileMode.Create))
                    using (var aes = Aes.Create())
                    {
                        aes.Key = key;
                        aes.IV = iv;

                        using (var cs = new CryptoStream(fsInput, aes.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            cs.CopyTo(fsOutput);
                        }
                    }

                    return true;
                }
            }
            catch
            {
                return false;
            }
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

        // Encryption Check
        public static bool IsFileEncrypted(string filePath, Guid expectedGuid)
        {
            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    // Skip salt and IV
                    fs.Seek(SaltSize + IvSize, SeekOrigin.Begin);

                    // Read signature
                    byte[] signatureLengthBytes = new byte[4];
                    fs.Read(signatureLengthBytes, 0, 4);
                    int signatureLength = BitConverter.ToInt32(signatureLengthBytes, 0);
                    byte[] signatureBytes = new byte[signatureLength];
                    fs.Read(signatureBytes, 0, signatureLength);
                    string signature = Encoding.UTF8.GetString(signatureBytes);

                    // Verify signature
                    if (!signature.StartsWith(SignaturePrefix))
                        return false;

                    string guidString = signature.Substring(SignaturePrefix.Length);
                    return Guid.TryParse(guidString, out Guid fileGuid) && fileGuid == expectedGuid;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
