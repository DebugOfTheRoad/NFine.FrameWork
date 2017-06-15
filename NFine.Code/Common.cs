using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace NFine.Code
{
    public class Common
    {
        #region 计时器

        /// <summary>
        /// 计时器开始
        /// </summary>
        /// <returns></returns>
        public static Stopwatch TimerStart()
        {
            Stopwatch watch = new Stopwatch();
            watch.Reset();
            watch.Start();
            return watch;
        }

        /// <summary>
        /// 计时器结束，并获得计时时间
        /// </summary>
        /// <param name="watch"></param>
        /// <returns></returns>
        public static string TimerEnd(Stopwatch watch)
        {
            watch.Stop();
            double custtime = watch.ElapsedMilliseconds;
            return custtime.ToString(CultureInfo.InvariantCulture);
        }

        #endregion

        #region 删除数组中重复的项

        public static T[] RemoveDup<T>(T[] values) where T : IComparable<T>
        {
            var list = new List<T>();
            foreach (T val in values)
            {
                if (!list.Contains(val))
                {
                    list.Add(val);
                }
            }
            return list.ToArray();
        }

        #endregion

        #region 生成唯一编号

        /// <summary>
        /// 生成Guid
        /// </summary>
        /// <returns></returns>
        public static string Guid() => System.Guid.NewGuid().ToString();

        /// <summary>
        /// 基于日期生成随机码
        /// </summary>
        /// <returns></returns>
        public static string CreateNo()
        {
            Random radom = new Random();
            string strNum = radom.Next(1000, 10000).ToString();
            string code = DateTime.Now.ToString("yyyyMMddHHmmss");
            return code + strNum;
        }

        #endregion

        #region 生成0~9位随机数

        /// <summary>
        /// 随机生成0~9位长度的随机码
        /// </summary>
        /// <param name="length">生成的随机码的长度</param>
        /// <returns></returns>
        public static string RndNum(int length)
        {
            StringBuilder sb = new StringBuilder();
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                int t = rand.Next(9);
                sb.AppendFormat("{0}", t);
            }
            return sb.ToString();
        }

        #endregion

        #region 删除最后一个字符之后的字符

        /// <summary>
        /// 删除指定字符串以指定字符结尾的字符
        /// </summary>
        /// <param name="str"></param>
        /// <param name="delChar"></param>
        /// <returns></returns>
        public static string DelLastChar(string str, string delChar)
        {
            return str.Substring(0, str.LastIndexOf(delChar));
        }

        /// <summary>
        /// 删除给定字符串以逗号结尾之后的字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DelLastComa(string str)
        {
            return DelLastChar(str, ",");
        }

        /// <summary>
        /// 删除指定长度之后的字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string DelLastLength(string str, int length)
        {
            if (String.IsNullOrEmpty(str))
            {
                return "";
            }
            return str.Substring(0, str.Length - length);
        }

        #endregion
    }
}
