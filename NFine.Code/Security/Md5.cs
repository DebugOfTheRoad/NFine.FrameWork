using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Code.Security
{
    public static class Md5
    {
        public static string Encrypt(string str)
        {
            string ret = string.Empty;
            ret = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
            return ret;
        }
    }
}
