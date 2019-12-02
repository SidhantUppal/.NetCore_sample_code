using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CFMCommon
{
    public class MD5Generator
    {
        public static string ToMD5Hash(string str)
        {
            if (string.IsNullOrEmpty(str))
                return null;

            return ToMD5Hash(Encoding.ASCII.GetBytes(str));
        }

        public static string ToMD5Hash(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return null;

            using (var md5 = MD5.Create())
            {
                return string.Join("", md5.ComputeHash(bytes).Select(x => x.ToString("X2")));
            }
        }
    }
}
