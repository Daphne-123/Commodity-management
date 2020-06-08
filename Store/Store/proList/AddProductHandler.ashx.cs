using StoreBLL;
using StoreModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Store.proList
{
    /// <summary>
    /// AddProductHandler 的摘要说明
    /// </summary>
    public class AddProductHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string name = context.Request.Form["cName"].ToString();
            int num = Convert.ToInt32(context.Request.Form["cNumber"]);
            DateTime time = Convert.ToDateTime(context.Request.Form["cTime"]);
            int DeptId = Convert.ToInt32(context.Request.Form["cDeptId"]);
            double price = Convert.ToDouble(context.Request.Form["cPrice"]);

            HttpFileCollection files = context.Request.Files;
            //设置文件名
            string fileNewName = DateTime.Now.ToString("yyyyMMddHHmmssff") + "_" + Path.GetFileName(files[0].FileName);
            //保存文件
            files[0].SaveAs(context.Server.MapPath("~/UploadFile/" + fileNewName));


            ProductInfo product = new ProductInfo()
            {
                cImgUrl = "/UploadFile/" + fileNewName,
                cName = name,
                cNumber = num,
                cDeptId = DeptId,
                cTime = time,
                Price = price
            };
            if (new ProductBLL().Insert(product))
            {
                context.Response.Write("<script>alert('添加成功')</script>");
                context.Response.StatusCode = 500;
            }
            else
            {
                context.Response.Write("<script>alert('添加失败')</script>");
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