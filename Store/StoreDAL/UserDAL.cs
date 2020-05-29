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
        public static bool Add(UserModel user)
        {
            bool result = false;
            string sql = $"insert into [user](username, password) values('{user.Username}', '{user.Password}')";
           
            if (SqlServer.NotQuery(sql)!= -1)
            {
                result = true;
            }
            return result;
        }
        

        public static bool Login(string username,string password)
        {
            bool result = false;
            string sql = "select * from [user] where username = '" + username + "' and password='"+ password +"' ";

            DataTable dataTable = StoreUtility.MsSqlHelper.Query(sql).Tables[0];
            if (dataTable.Rows.Count != 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }


        //public static bool Search(string username)
        //{
        //    bool result = false;
        //    string sql = "select * from [user] where username =  '"+username+ ' ;
        //    /*if (db.NotQuery(sql) != -1)
        //    {
        //        result = true;
        //    }
        //    else
        //    {
        //        result = false;
        //    }
        //    return result;*/
        //    DataTable dataTable = MsSqlHelper.Query(sql).Tables[0];
        //    if (dataTable.Rows.Count == 0)
        //    {
        //        result = true;
        //    }
        //    else
        //    {
        //        result = false;
        //    }
        //    return result;
        //}
    }
}

     