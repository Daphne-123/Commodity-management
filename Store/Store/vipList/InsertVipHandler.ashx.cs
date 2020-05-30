using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using StoreModel;
using StoreBLL;


namespace Store.vip_List
{
    /// <summary>
    /// InsertVipHandler 的摘要说明
    /// </summary>
    public class InsertVipHandler : IHttpHandler
    {
        vipBLL vipBll = new vipBLL();
        public void ProcessRequest(HttpContext context)
        {
            /*  string pName = context.Request.Form["pName"].ToString();
               string pGender = context.Request.Form["pGender"].ToString();
               int pAge = Convert.ToInt32(context.Request.Form["pAge"]);
               DateTime pJoinDate = Convert.ToDateTime(context.Request.Form["pJoinDate"]);
             */
           
            string pName = context.Request.Form["pName"];
            string pGender = context.Request.Form["pGender"];
            string pAge = context.Request.Form["pAge"];
            DateTime pJoinDate = Convert.ToDateTime(context.Request.Form["pJoinDate"]);

            vipInfo vip = new vipInfo();
            vip.pName = pName;
            vip.pGender = pGender;
            vip.pAge = Convert.ToInt32(pAge);
            vip.pJoinDate = Convert.ToDateTime(pJoinDate);
            if (vipBll.AddVip(vip))
            {
                context.Response.Write("<script>alert('添加成功！');window.location='vipList.aspx'</script>");
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