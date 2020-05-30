using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.vip_List
{
    /// <summary>
    /// InsertVipHandler 的摘要说明
    /// </summary>
    public class InsertVipHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
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