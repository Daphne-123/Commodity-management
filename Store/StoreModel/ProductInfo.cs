using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace StoreModel
{
    public class ProductInfo
    {
        public int cId { get; set; }
        public string cImgUrl { get; set; }
        public string cName { get; set; }
        public int cNumber { get; set; }
        public DateTime cTime { get; set; }
        public int cDeptId { get; set; }

        public static List<ProductInfo> TableToList(DataTable dt)
        {
            List<ProductInfo> clsList = new List<ProductInfo>();
            foreach (DataRow row in dt.Rows)
            {
                ProductInfo cls = new ProductInfo();
                cls.cId = Convert.ToInt32(row["cId"]);
                cls.cImgUrl = row["cImgUrl"].ToString();
                cls.cName = row["cName"].ToString();
                cls.cNumber = Convert.ToInt32(row["cNumber"]);
                cls.cTime = Convert.ToDateTime(row["cTime"]);
                cls.cDeptId = Convert.ToInt32(row["cDeptId"]);
                clsList.Add(cls);
            }
            return clsList;
        }
    }
}
