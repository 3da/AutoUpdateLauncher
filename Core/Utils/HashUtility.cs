using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Core.Utils
{
    public static class HashUtility
    {
        public static string GetFileHash(string path)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(path))
                {
                    return ByteArrayToString(md5.ComputeHash(stream));
                }
            }
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}
