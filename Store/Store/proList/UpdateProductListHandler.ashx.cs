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
    /// UpdateProductListHandler 的摘要说明
    /// </summary>
    public class UpdateProductListHandler : IHttpHandler
    {
        ProductBLL clsBll = new ProductBLL();
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
            string cId = context.Request.QueryString["cId"];
            if (!string.IsNullOrEmpty(cId))
            {
                int sId = int.Parse(cId);
                string html = File.ReadAllText(context.Request.MapPath("UpdateProductList.html"));
                ProductInfo pro = clsBll.GetProductById(sId);
                html = html.Replace("{@cId}", pro.cId.ToString()).Replace("{@cImgUrl}", pro.cImgUrl).Replace("{@cName}", pro.cName);
                html = html.Replace("{@cNumber}", pro.cNumber.ToString()).Replace("{@cTime}", pro.cTime.ToShortDateString()).Replace("{@cDeptId}", pro.cDeptId.ToString());
                context.Response.Write(html);
            }
        }

        private void DoPost(HttpContext context)
        {
            string cId = context.Request.Form["cId"];
            string cImgUrl = context.Request.Form["cImgUrl"];
            string cName = context.Request.Form["cName"];
            string cNumber = context.Request.Form["cNumber"];
            string cTime = context.Request.Form["cTime"];
            string cDeptId = context.Request.Form["cDeptId"];
           
            ProductInfo pro = new ProductInfo();
            pro.cId = Convert.ToInt32(cId);
            pro.cImgUrl = cImgUrl;
            pro.cName = cName;
            pro.cNumber = Convert.ToInt32(cNumber);
            pro.cTime = Convert.ToDateTime(cTime);
            pro.cDeptId = Convert.ToInt32(cDeptId);
            if (clsBll.Update(pro))
            {  
                context.Response.Write("<script>alert('修改成功！');window.location='ProductList.ashx'</script>");
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