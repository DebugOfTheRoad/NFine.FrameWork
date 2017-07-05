using System;
using System.Web;
using System.Configuration;
using System.Xml;

namespace NFine.Code.Config
{
    public class ConfigHelper
    {
        /// <summary>
        /// 从配置文件中获取给定key对应的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetValue(string key)
        {
            Object obj = ConfigurationManager.AppSettings[key];
            if (obj == null)
            {
                throw new Exception($"we未能在配置文件中找到指为{key}的配置项");
            }
            return obj.ToString().Trim();
        }
    }
}