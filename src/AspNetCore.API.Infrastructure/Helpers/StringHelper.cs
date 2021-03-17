using AspNetCore.API.Core.Constants;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AspNetCore.API.Infrastructure.Helpers
{
    /// <summary>
    /// Encryption and Decryption was reference from Stackoverflow post by A Ghazal:
    /// https://stackoverflow.com/questions/10168240/encrypting-decrypting-a-string-in-c-sharp
    /// </summary>

    public static class StringHelper
    {
        public static string Encrypt(this string clearText)
        {
            try {
                byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);

                using(Aes encryptor = Aes.Create()) {
                    Rfc2898DeriveBytes pdb = new(
                        SecurityKeys.EncryptionKey,
                        new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 }
                    );

                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);

                    MemoryStream ms = new();
                    CryptoStream cs = new(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write);

                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();

                    clearText = Convert.ToBase64String(ms.ToArray());
                }

                return clearText;
            }
            catch(Exception) {
                // TODO: Error Logging
                throw new Exception(ValidationMessage.EncryptionFailed);
            }
        }

        public static string Encrypt(this int value) => value.ToString().Encrypt();
        public static string Encrypt(this long value) => value.ToString().Encrypt();

        public static string Decrypt(this string cipherText)
        {
            try {
                cipherText = cipherText.Replace(" ", "+");

                byte[] cipherBytes = Convert.FromBase64String(cipherText);

                using(Aes encryptor = Aes.Create()) {
                    Rfc2898DeriveBytes pdb = new(
                        SecurityKeys.EncryptionKey,
                        new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 }
                    );

                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);

                    MemoryStream ms = new();
                    CryptoStream cs = new(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write);

                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();

                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }

                return cipherText;
            }
            catch(Exception) {
                // TODO: Error Logging
                throw new Exception(ValidationMessage.DecryptionFailed);
            }
        }

        public static string GenerateSaltedHash(string text, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] plainText = Encoding.UTF8.GetBytes(text);
            byte[] plainTextWithSaltBytes = new byte[plainText.Length + salt.Length];

            for(int i = 0; i < plainText.Length; i++) {
                plainTextWithSaltBytes[i] = plainText[i];
            }

            for(int i = 0; i < salt.Length; i++) {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            var hashedAndSalted = algorithm.ComputeHash(plainTextWithSaltBytes);

            return Convert.ToBase64String(hashedAndSalted);
        }
    }
}
