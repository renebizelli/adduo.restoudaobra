using adduo.methodextension;
using System;
using System.Security.Cryptography;
using System.Text;

namespace adduo.helper.hash
{
    public class HashHelper
    {
        public static string HashSHA1(string input)
        {
            return Hash(input, new SHA1Managed());
        }

        public static string HashSHA256(string input)
        {
            return Hash(input, new SHA256Managed());
        }

        public static string HashSHA384(string input)
        {
            return Hash(input, new SHA384Managed());
        }

        public static string HashSHA512(string input)
        {
            return Hash(input, new SHA512Managed());
        }

        public static string HashMD5(string input)
        {
            return Hash(input, new MD5CryptoServiceProvider());
        }

        private static string Hash(string input, HashAlgorithm transform)
        {
            var hash = string.Empty;

            if (input.NotIsNullOrEmpty())
            {
                byte[] originalBytes = ASCIIEncoding.Default.GetBytes(input);
                byte[] encodedBytes = transform.ComputeHash(originalBytes);

                hash = BitConverter.ToString(encodedBytes).Replace("-", "");
            }

            return hash;
        }
    }
}
