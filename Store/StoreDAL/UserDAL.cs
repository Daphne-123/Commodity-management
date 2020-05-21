using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreModel;
using StoreUtility;

namespace StoreDAL
{
    /// <summary>
    /// 用户数据访问
    /// </summary>
    public class UserDAL
    {
        public static bool Add(UserModel user)
        {
            bool result = false;
            string sql = $"insert into [user](username, password) values('{user.Username}', '{user.Password}')";

            if (SqlServer.NotQuery(sql) != -1)
            {
                result = true;
            }
            return result;
        }

        /* readonly SqlServer db = new SqlServer();
         public int Add(UserModel user)
         {
             string sql = "insert into user (username,password) value('" + user.Username + "','" + user.Password + "') ";
             return db.NotQuery(sql);
         }*/
    }
}
