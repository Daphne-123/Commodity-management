using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreModel
{
    public class UserInfo
    {
        public int uId { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }

        public static List<UserInfo> TableToList(System.Data.DataTable dt)
        {
            List<UserInfo> empList = new List<UserInfo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                UserInfo emp = new UserInfo();
                if (!dt.Rows[i].IsNull("uId")) { emp.uId = Convert.ToInt32(dt.Rows[i]["uId"]); }
                if (!dt.Rows[i].IsNull(" userName")) { emp.userName = dt.Rows[i][" userName"].ToString(); }
                if (!dt.Rows[i].IsNull(" passWord ")) { emp.passWord = dt.Rows[i]["passWord"].ToString(); }
                empList.Add(emp);

            }
            return empList;
        }

    }
}
