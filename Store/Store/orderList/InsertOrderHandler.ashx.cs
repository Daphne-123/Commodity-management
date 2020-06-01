using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using StoreModel;
using StoreBLL;

namespace Store.orderList
{
    /// <summary>
    /// InsertOrderHandler 的摘要说明
    /// </summary>
    public class InsertOrderHandler : IHttpHandler
    {
        orderBLL orderBll = new orderBLL();
        public void ProcessRequest(HttpContext context)
        {
            string cName = context.Request.Form["cName"];
            string cNumber = context.Request.Form["cNumber"];
            DateTime orderDate = Convert.ToDateTime(context.Request.Form["orderDate"]);
            string orderAddress = context.Request.Form["orderAddress"];

            orderInfo order = new orderInfo();
            order.cName = cName;
            order.cNumber = Convert.ToInt32(cNumber);
            order.orderDate = Convert.ToDateTime(orderDate);
            order.orderAddress = orderAddress;
            if (orderBll.AddOrder(order))
            {
                context.Response.Write("<script>alert('添加成功！');window.location='orderQuery.aspx'</script>");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}