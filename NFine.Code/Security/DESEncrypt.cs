using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace NFine.Code.Security
{
    public class DESEncrypt
    {
        const string DES_KEY = "NFine_desencrypt_2016";

        #region 加密
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="text">需要进行加密的文本</param>
        /// <param name="key">进行加密的Key值</param>
        /// <returns></returns>
        public static string Encrypt(string text, string key)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] input = Encoding.Default.GetBytes(text);
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(key, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(key, "ms5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(input, 0, input.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        /// <summary>
        /// 使用默认的key进行加密
        /// </summary>
        /// <param name="text">需要进行加密的文本</param>
        /// <returns></returns>
        public static string Encrypt(string text)
        {
            return Encrypt(text, DES_KEY);
        }
        #endregion

        #region 解密
        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="text">需要进行解密的字符串</param>
        /// <param name="key">解密的键值</param>
        /// <returns></returns>
        public static string Decrypt(string text, string key)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            int len = text.Length / 2;
            byte[] input = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(text.Substring(x * 2, 2), 16);
                input[x] = (byte)i;
            }
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(key, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(key, "ms5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(input, 0, input.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }

        /// <summary>
        /// 使用默认的键值进行解密
        /// </summary>
        /// <param name="text">需要解密的字符串</param>
        /// <returns></returns>
        public static string Decrypt(string text)
        {
            return Decrypt(text, DES_KEY);
        }
        #endregion
    }
}
