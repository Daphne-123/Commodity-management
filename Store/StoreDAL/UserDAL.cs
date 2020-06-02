using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreModel;
using StoreUtility;
using System.Data;
using System.Data.SqlClient;

namespace StoreDAL
{
    /// <summary>
    /// 用户数据访问
    /// </summary>
    public class UserDAL
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddUser(UserInfo user)
        {
            string sqlStr = $"insert into cUser (userName,passWord) values ('{user.userName}', '{user.passWord}')";
            return SqlServer.NotQuery(sqlStr);
        }
        /// <summary>
        /// 登录时判断是否注册
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public bool LoginUser(string userName,string passWord)
        {
            string sqlStr = "select * from cUser where userName ='"+ userName + "' and passWord = '"+passWord+"'";
            DataSet ds = SqlServer.Query(sqlStr);
            return ds!= null;
            /*if (ds == null)
            {
                return float;
            }
            else
            {
                return 1;
            }*/

            /* string sql = "up_Login";
             SqlParameter username = new SqlParameter("@userName", userName);
             SqlParameter password = new SqlParameter("@passWord", passWord);
             return  DBHelper.ExcuteScalar<int>(sql, CommandType.StoredProcedure, username, password);*/
        }
      
    }
}

     