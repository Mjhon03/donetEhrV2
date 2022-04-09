using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EasyHouseRent
{
    public class Encrypt
    {
        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
        public static string generateKey(int longi)
        {
            Random rdm = new Random();
            string res = "";
            for (int count = 0; count <= longi; count++)
            {
                int num = (int)((rdm.Next() * (('z' - 'a') + 1)) + 'a');
                char letra = (char)num;
                res = res + letra;
            }
            return res;
        }

        public static string EncryptKey(string encryptKey)
        {
            string hash = $"{generateKey(10)}";
            //string hash = "keyeasyhouserent";
            byte[] data = UTF8Encoding.UTF8.GetBytes(encryptKey);

            MD5 md5 = MD5.Create();
            TripleDES tripledes = TripleDES.Create();

            tripledes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripledes.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripledes.CreateEncryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

            return Convert.ToBase64String(result);
        }

        public static string DecryptKey(string decryptKey)
        {
            string hash = $"{generateKey(10)}";
            //string hash = "keyeasyhouserent";
            byte[] data = Convert.FromBase64String(decryptKey);

            MD5 md5 = MD5.Create();
            TripleDES tripledes = TripleDES.Create();

            tripledes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripledes.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripledes.CreateDecryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

            return UTF8Encoding.UTF8.GetString(result);
        }
    }
}
