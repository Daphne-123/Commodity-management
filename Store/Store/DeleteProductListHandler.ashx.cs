using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreModel;
using StoreBLL;
using StoreUtility;

namespace Store
{
    /// <summary>
    /// DeleteProductListHandler 的摘要说明
    /// </summary>
    public class DeleteProductListHandler : IHttpHandler
    {
        ProductBLL clsBll = new ProductBLL();
        public void ProcessRequest(HttpContext context)
        { 
            string cId = context.Request.QueryString["cId"];
            if (!string.IsNullOrEmpty(cId))
            {
                if (StringHelper.IsNumber(cId))
                {
                    int sId = int.Parse(cId);
                  
                    int clsId = clsBll.GetProductById(sId).cDeptId;
                    if (clsBll.Delete(sId))
                    {
                        context.Response.Redirect("ProductList.ashx");
                    }
                }
                else
                {
                    context.Response.Write("你给的参数不是数字!<a href ='ProductList.ashx'>点击这里</a>");
                }

            }
            else
            {
                context.Response.Redirect("ProductList.ashx");
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