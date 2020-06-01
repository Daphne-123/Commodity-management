using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreModel;
using StoreBLL;
using StoreUtility;


namespace Store.orderList
{
    /// <summary>
    /// DeleteOrderHandler 的摘要说明
    /// </summary>
    public class DeleteOrderHandler : IHttpHandler
    {

        orderBLL orderBLL = new orderBLL();
        public void ProcessRequest(HttpContext context)
        {
            string orderId = context.Request.QueryString["orderId"];
            if (!string.IsNullOrEmpty(orderId))
            {
                if (StringHelper.IsNumber(orderId))
                {
                    int sId = int.Parse(orderId);

                    if (orderBLL.DeleteOrder(sId))
                    {
                        context.Response.Redirect("orderQuery.aspx");
                    }
                }
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