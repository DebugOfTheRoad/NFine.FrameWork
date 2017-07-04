using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Code.Extend
{
    public static partial class Ext
    {
        /// <summary>
        /// 获取布尔类型值得描述信息
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Description(this bool value)
        {
            return value ? "是" : "否";
        }

        /// <summary>
        /// 获取可空布尔类型的值的描述，如果对象为空，则返回空字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Description(this bool? value)
        {
            return value == null ? "" : Description(value.Value);
        }
    }
}
