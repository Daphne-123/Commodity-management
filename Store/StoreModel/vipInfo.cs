using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace StoreModel
{
    public class vipInfo
    {
        public int pId { get; set; }
        public string pName { get; set; }
        public string pGender { get; set; }
        public int pAge { get; set; }
        public DateTime pJoinDate { get; set; }

        public static List<vipInfo> TableToList(DataTable dt)
        {
            List<vipInfo> clsList = new List<vipInfo>();
            foreach (DataRow row in dt.Rows)
            {
                vipInfo cls = new vipInfo
                {
                    pId = Convert.ToInt32(row["pId"]),
                    pName = row["pName"].ToString(),
                    pGender = row["pGender"].ToString(),
                    pAge = Convert.ToInt32(row["pAge"]),
                    pJoinDate = Convert.ToDateTime(row["pJoinDate"])
                };
                clsList.Add(cls);
            }
            return clsList;
        }
    }
}
