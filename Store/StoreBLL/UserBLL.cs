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
        private UserDAL userDal = new UserDAL();

        public bool AddAddUser(UserInfo user)
        {
            return userDal.AddUser(user)>0;
        }

        public bool LoginUser(string userName, string passWord)
        {
            return userDal.LoginUser(userName, passWord);
        }
    }
}
