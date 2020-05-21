using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreDAL;
using StoreModel;

namespace StoreBLL
{
    /// <summary>
    /// 业务逻辑
    /// </summary>
    public class UserBLL
    {
        public static bool Add(UserModel user)
        {
            return  UserDAL.Add(user);
        }
    }
}
