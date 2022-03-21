using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace SDOBusinessCore.Business.Common
{
    /// <summary>
    /// Cipher
    /// https://www.selamigungor.com/post/7/encrypt-decrypt-a-string-in-csharp
    /// </summary>
    /// <example>
    /// var strEncryptred = Cipher.Encrypt(str, SettingsManager.ReadSetting("encrPss"));
    /// var strDecrypted = Cipher.Decrypt(strEncryptred, SettingsManager.ReadSetting("encrPss"));
    /// </example>
    public class Cipher
    {
        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static string Encrypt(string plainText, string password)
        {
            if (plainText == null)           
                return null;            

            if (password == null)            
                password = String.Empty;
            

            // Get the bytes of the string
            var bytesToBeEncrypted = Encoding.UTF8.GetBytes(plainText);
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            var bytesEncrypted = Cipher.Encrypt(bytesToBeEncrypted, passwordBytes);

            return Convert.ToBase64String(bytesEncrypted);
        }

        /// <summary>
        /// Decrypts the specified encrypted text.
        /// </summary>
        /// <param name="encryptedText">The encrypted text.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static string Decrypt(string encryptedText, string password)
        {
            if (encryptedText == null)            
                return null;
            
            if (password == null)            
                password = String.Empty;
            
            // Get the bytes of the string
            var bytesToBeDecrypted = Convert.FromBase64String(encryptedText);
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            var bytesDecrypted = Cipher.Decrypt(bytesToBeDecrypted, passwordBytes);

            return Encoding.UTF8.GetString(bytesDecrypted);
        }

        /// <summary>
        /// Encrypts the specified bytes to be encrypted.
        /// </summary>
        /// <param name="bytesToBeEncrypted">The bytes to be encrypted.</param>
        /// <param name="passwordBytes">The password bytes.</param>
        /// <returns></returns>
        private static byte[] Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }

                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        /// <summary>
        /// Decrypts the specified bytes to be decrypted.
        /// </summary>
        /// <param name="bytesToBeDecrypted">The bytes to be decrypted.</param>
        /// <param name="passwordBytes">The password bytes.</param>
        /// <returns></returns>
        private static byte[] Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }

                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }
    }
}

