using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace WildCircus
{
    public class Sha
    { 
        public static String CryptPassword(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            SHA512 hasher = SHA512.Create();
            byte[] encryptedPasswordBytes = hasher.ComputeHash(passwordBytes);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < encryptedPasswordBytes.Length; i++)
            {
                builder.Append(encryptedPasswordBytes[i].ToString("x2"));
            }
            String encryptedPassword = builder.ToString();
            return encryptedPassword;
        }
    }
}
