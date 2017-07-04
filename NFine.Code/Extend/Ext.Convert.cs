using System;
using System.Diagnostics.Contracts;

namespace NFine.Code.Extend
{
  public static partial class Ext
  {
    #region 数值转换
    /// <summary>
    /// 转换为整形
    /// </summary>
    /// <returns>The int.</returns>
    /// <param name="data">Data.</param>
    public static int ToInt(this object data)
    {
      if (data == null)
      {
        return 0;
      }
      var success = int.TryParse(data.ToString(), out int result);
      if (success)
      {
        return result;
      }
      try
      {
        return Convert.ToInt32(ToDouble(data));
      }
      catch (Exception)
      {
        return 0;
      }
    }

    /// <summary>
    /// 转换为可空整形
    /// </summary>
    /// <returns>The int or null.</returns>
    /// <param name="data">Data.</param>
    public static int? ToIntOrNull(this object data)
    {
      if (data == null)
      {
        return null;
      }
      bool isValid = int.TryParse(data.ToString(), out int result);
      if (isValid)
      {
        return result;
      }
      return null;
    }

    /// <summary>
    /// 转换为双精度浮点型
    /// </summary>
    /// <returns>The double.</returns>
    /// <param name="data">Data.</param>
    public static double ToDouble(this object data)
    {
      if (data == null)
      {
        return 0;
      }
      return double.TryParse(data.ToString(), out double result) ? result : 0;
    }

    /// <summary>
    /// 转换为双精度浮点型，并根据给定的位数进行四舍五入
    /// </summary>
    /// <returns>The double.</returns>
    /// <param name="data">Data.</param>
    /// <param name="digits">Digits.</param>
    public static double ToDouble(this object data, int digits)
    {
      return Math.Round(ToDouble(data), digits);
    }

    /// <summary>
    /// 转换为可空双精度浮点数
    /// </summary>
    /// <returns>The double or null.</returns>
    /// <param name="data">Data.</param>
    public static double? ToDoubleOrNull(this object data)
    {
      if (data == null)
      {
        return 0;
      }
      var success = double.TryParse(data.ToString(), out double result);
      if (success)
      {
        return result;
      }
      return null;
    }

    /// <summary>
    /// 转换为高精度浮点数
    /// </summary>
    /// <returns>The decimal.</returns>
    /// <param name="data">Data.</param>
    public static decimal ToDecimal(this object data)
    {
      if (data == null)
      {
        return 0M;
      }
      return decimal.TryParse(data.ToString(), out decimal result) ? result : 0M;
    }

    /// <summary>
    /// 转换为高精度浮点数，并按照指定位数进行四舍五入
    /// </summary>
    /// <returns>The decimal.</returns>
    /// <param name="data">Data.</param>
    /// <param name="digits">Digits.</param>
    public static decimal ToDecimal(this object data, int digits)
    {
      return Math.Round(ToDecimal(data), digits);
    }

    /// <summary>
    /// 转换为可为空的高精度浮点数
    /// </summary>
    /// <returns>The decimal or null.</returns>
    /// <param name="data">Data.</param>
    public static decimal? ToDecimalOrNull(this object data)
    {
      if (data == null)
      {
        return null;
      }
      bool success = decimal.TryParse(data.ToString(), out decimal result);
      if (success)
      {
        return result;
      }
      return null;
    }
    #endregion

    #region 日期转换
    /// <summary>
    /// 转换为日期
    /// </summary>
    /// <returns>The date.</returns>
    /// <param name="data">Data.</param>
    public static DateTime ToDate(this object data)
    {
      if (data == null)
      {
        return DateTime.MinValue;
      }
      return DateTime.TryParse(data.ToString(), out DateTime result) ?
                     result : DateTime.MinValue;
    }

    /// <summary>
    /// 转换为可空日期
    /// </summary>
    /// <returns>The date or null.</returns>
    /// <param name="data">Data.</param>
    public static DateTime? ToDateOrNull(this object data)
    {
      if (data == null)
      {
        return null;
      }
      bool success = DateTime.TryParse(data.ToString(), out DateTime result);
      if (success)
      {
        return result;
      }
      return null;
    }
    #endregion

    #region 布尔转换
    /// <summary>
    /// 转换为布尔值
    /// </summary>
    /// <returns><c>true</c>, if bool was toed, <c>false</c> otherwise.</returns>
    /// <param name="data">Data.</param>
    public static bool ToBool(this object data)
    {
      if (data == null)
      {
        return false;
      }
      bool? value = GetBool(data);
      if (value != null)
      {
        return value.Value;
      }
      return bool.TryParse(data.ToString(), out bool result) && result;
    }

    /// <summary>
    /// 私有方法，将给定的字符串转换为布尔值
    /// </summary>
    /// <returns>The bool.</returns>
    /// <param name="data">Data.</param>
    private static bool? GetBool(object data)
    {
      if (data == null)
      {
        return null;
      }
      switch (data.ToString().Trim().ToLower())
      {
        case "0":
          return false;
        case "1":
          return true;
        case "是":
          return true;
        case "否":
          return false;
        case "yes":
          return true;
        case "no":
          return false;
        default:
          return null;
      }
    }

    /// <summary>
    /// 转
    /// </summary>
    /// <returns>The bool or null.</returns>
    /// <param name="data">Data.</param>
    public static bool? ToBoolOrNull(this object data)
    {
      if (data == null)
        return null;
      bool? value = GetBool(data);
      if (value != null)
        return value.Value;
      bool success = bool.TryParse(data.ToString(), out bool result);
      if (success)
        return result;
      return null;
    }
    #endregion

    #region 字符串转换
    /// <summary>
    /// 转换为字符串
    /// </summary>
    /// <returns>The string.</returns>
    /// <param name="data">Data.</param>
    public static string ToString(this object data)
    {
      return data == null ? string.Empty : data.ToString().Trim();
    }
    #endregion

    #region 其他
    /// <summary>
    /// 返回安全值
    /// </summary>
    /// <returns>The value.</returns>
    /// <param name="value">Value.</param>
    /// <typeparam name="T">The 1st type parameter.</typeparam>
    public static T SaveValue<T>(this T? value)
      where T : struct
    {
      return value ?? default(T);
    }

    /// <summary>
    /// 判断是否为空
    /// </summary>
    /// <returns><c>true</c>, if empty was ised, <c>false</c> otherwise.</returns>
    /// <param name="value">Value.</param>
    public static bool IsEmpty(this string value)
    {
      return String.IsNullOrEmpty(value);
    }

    /// <summary>
    /// 判断是否为空
    /// </summary>
    /// <returns><c>true</c>, if empty was ised, <c>false</c> otherwise.</returns>
    /// <param name="value">Value.</param>
    public static bool IsEmpty(this object value)
    {
      if (value != null && !string.IsNullOrEmpty(value.ToString()))
      {
        return false;
      }
      else
      {
        return true;
      }
    }
    #endregion
  }
}
