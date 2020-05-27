using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace StoreUtility
{
    public class DBHelper
    {
        private static string connString;

         static DBHelper()
        {
             connString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        }
        //params可变长度参数，数据类型必须是数组

        /// <summary>
        /// 增删改查封装方法
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int ExcuteNonQuery(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    connection.Open();
                    if (parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// 获取一个值(获取数据名，获取出生日期等等，数据类型不一样，故用object)
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>  
        public static T ExcuteScalar<T>(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    connection.Open();
                    if (parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return (T)cmd.ExecuteScalar();
                }
            }
        }
        public static SqlDataReader ExcuteReader(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    connection.Open();
                    if (parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    //CommandBehavior枚举类型，关闭ExecuteReader
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
        }
        public static DataSet GetDataSet(string cmdText, params SqlParameter[] parameters)
        {
            DataSet ds = new DataSet();
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, connString))
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        if (parameters.Length > 0)
                        {
                            adapter.SelectCommand.Parameters.AddRange(parameters);
                        }
                        adapter.Fill(ds);
                        return ds;
                    }
                }
            }
        }
        public static DataTable GetDataTable(string cmdText, params SqlParameter[] parameters)
        {
            //DataSet ds = new DataSet();
            //using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, connString))
            //{
            //    if (parameters.Length > 0)
            //    {
            //        adapter.SelectCommand.Parameters.AddRange(parameters);
            //    }
            //    adapter.Fill(ds);
            //}
            
            return GetDataSet(cmdText, parameters).Tables[0];
        }
    }
}
