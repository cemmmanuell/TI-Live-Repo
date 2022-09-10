namespace mmmSelfservice.Models
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public static class PasswordEncryption
    {
        public static string DecryptData(string EncryptedText)
        {
            string s = "Le33r@5g3***";
            RijndaelManaged managed = new RijndaelManaged {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 0x80,
                BlockSize = 0x80
            };
            byte[] inputBuffer = Convert.FromBase64String(EncryptedText);
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            byte[] destinationArray = new byte[0x10];
            int length = bytes.Length;
            if (length > destinationArray.Length)
            {
                length = destinationArray.Length;
            }
            Array.Copy(bytes, destinationArray, length);
            managed.Key = destinationArray;
            managed.IV = destinationArray;
            byte[] buffer4 = managed.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
            return Encoding.UTF8.GetString(buffer4);
        }

        public static string EncryptData(string textData)
        {
            string s = "Le33r@5g3***";
            RijndaelManaged managed = new RijndaelManaged {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 0x80,
                BlockSize = 0x80
            };
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            byte[] destinationArray = new byte[0x10];
            int length = bytes.Length;
            if (length > destinationArray.Length)
            {
                length = destinationArray.Length;
            }
            Array.Copy(bytes, destinationArray, length);
            managed.Key = destinationArray;
            managed.IV = destinationArray;
            ICryptoTransform transform = managed.CreateEncryptor();
            byte[] inputBuffer = Encoding.UTF8.GetBytes(textData);
            return Convert.ToBase64String(transform.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length));
        }
    }
}

