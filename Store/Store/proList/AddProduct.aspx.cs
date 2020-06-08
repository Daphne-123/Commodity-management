using StoreBLL;
using StoreModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Store.proList
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod.ToUpper() == "POST")
            {
                string name = Request.Form["cName"].ToString();
                int num = Convert.ToInt32(Request.Form["cNumber"]);
                DateTime time = Convert.ToDateTime(Request.Form["cTime"]);
                int DeptId = Convert.ToInt32(Request.Form["cDeptId"]);
                double price = Convert.ToDouble(Request.Form["cPrice"]);

                HttpFileCollection files = Request.Files;
                string fileNewName = "";
                if (files.Count != 0)
                {
                    //设置文件名
                    fileNewName = DateTime.Now.ToString("yyyyMMddHHmmssff") + "_" + Path.GetFileName(files[0].FileName);
                    //保存文件
                    files[0].SaveAs(Server.MapPath("~/UploadFile/" + fileNewName));
                }


                ProductInfo product = new ProductInfo()
                {
                    cImgUrl = files.Count == 0 ? null : "/UploadFile/" + fileNewName,
                    cName = name,
                    cNumber = num,
                    cDeptId = DeptId,
                    cTime = time,
                    Price = price
                };
                if (new ProductBLL().Insert(product))
                {
                    Response.Write("<script>alert('添加成功')</script>");
                    Response.StatusCode = 500;
                }
                else
                {
                    Response.Write("<script>alert('添加失败')</script>");
                }
            }
        }

        protected string GetFactoryList()
        {
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
                sbTrs.Append("<option value=\"" + row["tId"] + "\">" + row["tName"].ToString() + "</option>");
            }

            return sbTrs.ToString();
        }
    }
}