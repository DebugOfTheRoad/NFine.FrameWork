using System;

namespace NFine.Code.Config
{
  /// <summary>
  /// 数据库连接字符串相关方法
  /// </summary>
  public class DBConnection
  {
    /// <summary>
    /// 是否需要进行加密
    /// </summary>
    /// <value><c>true</c> if encrypt; otherwise, <c>false</c>.</value>
    public static bool Encrypt
    {
      get; set;
    }

    /// <summary>
    /// 构造函数，进行初始化
    /// </summary>
    /// <param name="encrypt">If set to <c>true</c> encrypt.</param>
    public DBConnection(bool encrypt)
    {
      Encrypt = encrypt;
    }

    public string GetConnectionString()
    {
      //TODO:需要在完成安全相关代码之后才能实现加密
      throw new NotImplementedException("GetConnectionString暂未实现");
    }
  }
}