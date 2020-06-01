using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace StoreModel
{
    public class orderInfo
    {
        public int orderId { get; set; }
        public string cName  { get; set; }
        public int cNumber { get; set; }
        public DateTime orderDate { get; set; }
        public string orderAddress { get; set; }

        public static List<orderInfo> TableToList(DataTable dt)
        {
            List<orderInfo> orderList = new List<orderInfo>();
            foreach (DataRow row in dt.Rows)
            {
                orderInfo order = new orderInfo
                {
                    orderId = Convert.ToInt32(row["orderId"]),
                    cName = row["cName"].ToString(),
                    cNumber = Convert.ToInt32(row["cNumber"]),
                    orderDate = Convert.ToDateTime(row["orderDate"]),
                    orderAddress = row["orderAddress"].ToString()
                };
                orderList.Add(order);
            }
            return orderList;
        }
    }
}
