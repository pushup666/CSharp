using System;
using System.Security.Cryptography;
using System.Text;

namespace BookStore
{
    static class Utils
    {
        public static string GetUID()
        {
            return Guid.NewGuid().ToString("N").ToUpper();
        }

        public static string GetHash(string content)
        {
            byte[] hash;
            using (var md5 = MD5.Create())
            {
                hash =  md5.ComputeHash(Encoding.Default.GetBytes(content));
            }
            var sb = new StringBuilder();
            foreach (var i in hash)
            {
                sb.Append(i.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
