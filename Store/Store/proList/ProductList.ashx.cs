﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using StoreModel;
using StoreBLL;

namespace Store
{
    /// <summary>
    /// ProductList 的摘要说明
    /// </summary>
    public class ProductList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            
          
            string html = System.IO.File.ReadAllText(context.Request.MapPath("ProductListHTML.html"));

            ProductBLL clsBll = new ProductBLL();
            List<ProductInfo> clsList = clsBll.GetProductList();
           
            StringBuilder sbTrs = new StringBuilder();
            foreach (ProductInfo cls in clsList)
            {
                sbTrs.Append("<tr>");
                sbTrs.Append("<th>" + cls.cId.ToString() + "</th>");
                sbTrs.Append(cls.cImgUrl.Trim() != "" ? "<td><a href=\"" + cls.cImgUrl + "\">点击查看</a></td>" : "<td>暂无图片</td>");
                sbTrs.Append("<td>" + cls.cName + "</td>");
                sbTrs.Append("<td>" + cls.cNumber.ToString() + "</td>");
                sbTrs.Append("<td>" + cls.cTime.ToString("yyyy-MM-dd") + "</td>");
                sbTrs.Append("<td>" + cls.DeptName.ToString() + "</td>");
                sbTrs.Append("<td>" + cls.Price.ToString() + "</td>");
                sbTrs.Append("<td><a class=\"btn btn-outline-primary btn-sm\" href='UpdateProductListHandler.ashx?cId=" + cls.cId + "'>修改</a> <a class=\"btn btn-outline-danger btn-sm\" href='javascript:void(0)' onclick='doDelete(" + cls.cId + ")'> 删除</a></td>");
                sbTrs.Append("</tr>");
            }
            //4.把生成字符串，嵌入到静态页的tbody标签里
            html = html.Replace("{@ClassContent}", sbTrs.ToString());
            //5.把拼写完整的html页面内容输出到客户端 
            context.Response.Write(html);

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