using StoreBLL;
using StoreModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace Store
{
    public partial class First : System.Web.UI.Page
    {
        private readonly orderBLL orderBLL = new orderBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 获取日期
        /// </summary>
        /// <returns></returns>
        protected string[] GetDate()
        {
            List<orderInfo> orders = orderBLL.GetOrderList();
            List<string> dateList = new List<string>();
            foreach (orderInfo order in orders)
            {
                string newDate = order.orderDate.ToString("yyyy-MM-dd");
                foreach (string date in dateList)
                {
                    if (date == newDate)
                    {
                        continue;
                    }
                }
                dateList.Add(newDate);
            }
            return dateList.ToArray();
        }

        /// <summary>
        /// 获取成交量
        /// </summary>
        /// <returns></returns>
        protected int[] GetGoodsNum()
        {
            List<orderInfo> orders = orderBLL.GetOrderList();
            List<int> numList = new List<int>();
            orderInfo old = null;
            for (int i = 0; i < orders.Count(); i++)
            {
                if (old != null && old.orderDate == orders[i].orderDate)
                {
                    numList[i - 1] = orders[i].cNumber;
                    old = orders[i];
                    i--;
                }
                else
                {
                    numList.Add(orders[i].cNumber);
                }
            }
            return numList.ToArray();
        }

        protected string GetVipAge()
        {
            List<vipInfo> vipList = new vipBLL().GetVipList();

            List<AgePieInfo> res = new List<AgePieInfo>();

            AgePieInfo old = new AgePieInfo() { name = "61岁及以上", value = 0 };
            AgePieInfo big = new AgePieInfo() { name = "41-60岁", value = 0 };
            AgePieInfo teen = new AgePieInfo() { name = "21-40岁", value = 0 };
            AgePieInfo little = new AgePieInfo() { name = "0-20岁", value = 0 };

            foreach (vipInfo vip in vipList)
            {
                if (vip.pAge > 60)
                {
                    old.value++;
                }
                else if (vip.pAge > 40)
                {
                    big.value++;
                }
                else if (vip.pAge > 20)
                {
                    teen.value++;
                }
                else
                {
                    little.value++;
                }
            }
            res.Add(old);
            res.Add(big);
            res.Add(teen);
            res.Add(little);

            return JsonConvert.SerializeObject(res);
        }
    }
}