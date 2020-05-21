using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace StoreUtility
{
    public class SqlServer
    {
        public static string GetSqlConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["connStr"].ToString();
        }
        public SqlConnection connection;

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql">sql字符串</param>
        /// <returns></returns>
        public DataSet Query(string sql)
        {
            DataSet ds = new DataSet();
            using (connection = new SqlConnection(GetSqlConnectionString()))
            {
                try
                {
                    connection.Open();
                    using (SqlDataAdapter adp = new SqlDataAdapter(sql, connection))
                    {
                        adp.Fill(ds);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return ds;
        }

        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>受影响的行数</returns>
        public int NotQuery(string sql)
        {
            int result = -1;
            using (connection = new SqlConnection(GetSqlConnectionString()))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        result = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return result;
        }
    }
}