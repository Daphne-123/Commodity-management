using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreModel;
using StoreUtility;
using System.Data;

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
            string sqlStr = $"insert into user (userName,passWord) values ('{user.userName}', '{user.passWord}')";
            return SqlServer.NotQuery(sqlStr);
        }
      
    }
}

     