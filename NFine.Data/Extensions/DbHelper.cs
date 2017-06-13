using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace NFine.Data
{
    public class DbHelper
    {
        private static string connectionString = ConfigurationManager
            .ConnectionStrings["NFineDbContext"].ConnectionString;

        public static int ExecuteSqlCommand(string cmdText)
        {
            using (DbConnection conn = new SqlConnection(connectionString))
            {
                DbCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, null,
                    CommandType.Text, cmdText, null);
                return cmd.ExecuteNonQuery();
            }
        }

        private static void PrepareCommand(DbCommand cmd, DbConnection conn,
            DbTransaction trans, CommandType cmdType, string cmdText,
            DbParameter[] cmdParams)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = cmdType;
            if (cmdParams != null && cmdParams.Length > 0)
            {
                cmd.Parameters.AddRange(cmdParams);
            }
        }
    }
}
