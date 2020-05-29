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
    public class Helper
    {
        public bool ExecMake(string cmdText, CommandType Cmdtype, SqlParameter[] Paras)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ConnectionString);
            con.Open();
            //对SqlCommand对象进行初始化
            SqlCommand SqlComm = new SqlCommand(cmdText, con);
            SqlComm.CommandType = Cmdtype;
            //对参数赋值
            SqlComm.Parameters.AddRange(Paras);
            //执行命令
            SqlComm.ExecuteNonQuery();
            con.Close();
            return true;

        }

        /// <summary>
        /// 执行不带参数的查询语句
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="Paras"></param>
        /// <returns></returns>
        public DataTable ExecSelect(string cmdText, CommandType Cmdtype)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connStr"]);
            con.Open();

            //对SqlCommand对象进行实例化
            SqlCommand SqlComm = new SqlCommand(cmdText, con);
            SqlComm.CommandType = Cmdtype;
            //给参数赋值
            SqlComm.CommandTimeout = 10000;

            //返回DataReader对象
            SqlDataReader DataReader = SqlComm.ExecuteReader();
            DataTable Dt = new DataTable();
            //返回DataTable对象
            Dt.Load(DataReader);

            //返回数据表
            con.Close();
            return Dt;
        }
    }
}
