using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using StoreModel;
using StoreBLL;

namespace Store
{
    /// <summary>
    /// UpdateVipListHandler 的摘要说明
    /// </summary>
    public class UpdateVipListHandler : IHttpHandler
    {
        vipBLL vipBll = new vipBLL();
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.HttpMethod.ToUpper() == "GET")
            {
                this.DoGet(context);
            }
            else
            {
                this.DoPost(context);
            }
        }
        private void DoGet(HttpContext context)
        {
            string pId = context.Request.QueryString["pId"];
            if (!string.IsNullOrEmpty(pId))
            {
                int sId = int.Parse(pId);
                string html = File.ReadAllText(context.Request.MapPath("UpdateVipList.html"));
                vipInfo vip = vipBll.GetVipById(sId);
                html = html.Replace("{@pId}", vip.pId.ToString()).Replace("{@pName}", vip.pName).Replace("{@pGender}", vip.pGender);
                html = html.Replace("{@pAge}", vip.pAge.ToString()).Replace("{@pJoinDate}", vip.pJoinDate.ToShortDateString());
                context.Response.Write(html);
            }
        }

        private void DoPost(HttpContext context)
        {
            string pId = context.Request.Form["pId"];
            string pName = context.Request.Form["pName"];
            string pGender = context.Request.Form["pGender"];
            string pAge = context.Request.Form["pAge"];
            string pJoinDate = context.Request.Form["pJoinDate"];

            vipInfo vip = new vipInfo();
            vip.pId = Convert.ToInt32(pId);
            vip.pName = pName;
            vip.pGender = pGender;
            vip.pAge = Convert.ToInt32(pAge);
            vip.pJoinDate = Convert.ToDateTime(pJoinDate);
            if (vipBll.UpdateVip(vip))
            {
                context.Response.Write("<script>alert('修改成功！');window.location='vipList.aspx'</script>");
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