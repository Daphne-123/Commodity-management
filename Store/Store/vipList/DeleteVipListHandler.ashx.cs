using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreModel;
using StoreBLL;
using StoreUtility;

namespace Store.vip_List
{
    /// <summary>
    /// DeleteVipListHandler 的摘要说明
    /// </summary>
    public class DeleteVipListHandler : IHttpHandler
    {
        vipBLL vipBLL = new vipBLL();
        public void ProcessRequest(HttpContext context)
        {
            string pId = context.Request.QueryString["pId"];
            if (!string.IsNullOrEmpty(pId))
            {
                if (StringHelper.IsNumber(pId))
                {
                    int sId = int.Parse(pId);
                   
                    if (vipBLL.DeleteVip(sId))
                    {
                        context.Response.Redirect("vipList.aspx");
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