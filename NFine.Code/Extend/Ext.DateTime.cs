using System;
using System.Text;

namespace NFine.Code.Extend
{
  public static partial class Ext
  {
    /// <summary>
    /// 将日期转化为yyyy-MM-dd HH:mm:ss的形式
    /// </summary>
    /// <returns>The date time string.</returns>
    /// <param name="dateTime">Date time.</param>
    /// <param name="isRemoveSecond">If set to <c>true</c> is remove second.</param>
    public static string ToDateTimeString(this DateTime dateTime,
                                          bool isRemoveSecond = false)
    {
      if (isRemoveSecond)
      {
        return dateTime.ToString("yyyy-MM-dd HH:mm");
      }
      return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
    }

    /// <summary>
    /// 将可空日期转化为yyyy-MM-dd HH:mm:ss的形式
    /// </summary>
    /// <returns>The date time string.</returns>
    /// <param name="dateTime">Date time.</param>
    /// <param name="isRemoveSecond">If set to <c>true</c> is remove second.</param>
    public static string ToDateTimeString(this DateTime? dateTime,
                                          bool isRemoveSecond = false)
    {
      if (dateTime == null)
      {
        return string.Empty;
      }
      return ToDateTimeString(dateTime.Value, isRemoveSecond);
    }

    /// <summary>
    /// 获取格式化字符串，不带时分秒
    /// </summary>
    /// <returns>The date string.</returns>
    /// <param name="dateTime">Date time.</param>
    public static string ToDateString(this DateTime dateTime)
    {
      return dateTime.ToString("yyyy-MM-dd");
    }

    /// <summary>
    /// 将现在时间转换为yyyy-MM-dd的形式
    /// </summary>
    /// <returns>The date string.</returns>
    private static string ToDateString()
    {
      return DateTime.Now.ToString("yyyy-MM-dd");
    }

    /// <summary>
    /// 将可空类型时间转换为yyyy-MM-dd的形式
    /// </summary>
    /// <returns>The date string.</returns>
    /// <param name="dateTime">Date time.</param>
    public static string ToDateString(this DateTime? dateTime)
    {
      if (dateTime == null)
      {
        return string.Empty;
      }
      return ToDateString(dateTime.Value);
    }

    /// <summary>
    /// 将日期类型转换为带毫秒的字符串形式
    /// </summary>
    /// <returns>The millsecond string.</returns>
    /// <param name="dateTime">Date time.</param>
    public static string ToMillsecondString(this DateTime dateTime)
    {
      return dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
    }

    /// <summary>
    /// 将可空日期类型转换为带毫秒的字符串形式
    /// </summary>
    /// <returns>The millsecond string.</returns>
    /// <param name="dateTime">Date time.</param>
    public static string ToMillsecondString(this DateTime? dateTime)
    {
      if (dateTime == null)
      {
        return string.Empty;
      }
      return ToMillsecondString(dateTime.Value);
    }

    /// <summary>
    /// 获取格式化字符串，并转换成中文输出形式
    /// </summary>
    /// <returns>The chinese date string.</returns>
    /// <param name="dateTime">Date time.</param>
    public static string ToChineseDateString(this DateTime dateTime)
    {
      return $"{dateTime.Year}年{dateTime.Month}月{dateTime.Day}日";
    }

    /// <summary>
    /// 将可空的日期转换为中文格式输出
    /// </summary>
    /// <returns>The chinese date string.</returns>
    /// <param name="dateTime">Date time.</param>
    public static string ToChineseDateString(this DateTime? dateTime)
    {
      if (dateTime == null)
      {
        return string.Empty;
      }
      return ToChineseDateString(dateTime.Value);
    }

    /// <summary>
    /// 将日期转换为日期时间格式 xxxx年xx月xx日 xx时xx分xx秒
    /// </summary>
    /// <returns>The chinese date time string.</returns>
    /// <param name="dateTime">Date time.</param>
    /// <param name="isRemoveSecond">If set to <c>true</c> is remove second.</param>
    public static string ToChineseDateTimeString(this DateTime dateTime, bool isRemoveSecond = false)
    {
      StringBuilder sb = new StringBuilder();
      sb.Append($"{dateTime.Year}年{dateTime.Month}月{dateTime.Day}日");
      sb.Append($" {dateTime.Hour}时{dateTime.Minute}分");
      if (!isRemoveSecond)
      {
        sb.Append($"{dateTime.Minute}秒");
      }
      return sb.ToString();
    }

    /// <summary>
    /// 将可空日期转换为日期时间格式
    /// </summary>
    /// <returns>The chinese date time string.</returns>
    /// <param name="dateTime">Date time.</param>
    /// <param name="isRemoveSecond">If set to <c>true</c> is remove second.</param>
    public static string ToChineseDateTimeString(this DateTime? dateTime, bool isRemoveSecond = false)
    {
      if (dateTime == null)
      {
        return String.Empty;
      }
      return ToChineseDateTimeString(dateTime.Value, isRemoveSecond);
    }
  }
}
