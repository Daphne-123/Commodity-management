using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Store
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string html = System.IO.File.ReadAllText(context.Request.MapPath("phoneList.html"));
            string connStr = "server =. ; database = Store; integrated security = true";
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                string sql = "select tId,tName,tPhone from Complaints";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                }
            }
            StringBuilder sbTrs = new StringBuilder();
            foreach (DataRow row in dt.Rows)
            {
                sbTrs.Append("<tr>");
                sbTrs.Append("<td>" + row["tId"].ToString() + "</td>");
                sbTrs.Append("<td>" + row["tName"].ToString() + "</td>");
                sbTrs.Append("<td>" + row["tPhone"].ToString() + "</td>");
                sbTrs.Append("</tr>");
            }
            html = html.Replace("{@ClassContent}", sbTrs.ToString());

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