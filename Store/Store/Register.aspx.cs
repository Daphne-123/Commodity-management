using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StoreModel;
using StoreBLL;
using System.Configuration;
using System.Data.SqlClient;

namespace Store
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];
           /*if (UserBLL.Search(this.username.Text)==false)
            {
                Response.Write("<script>alert('用户名已存在！');window.location='Register.aspx';</script>");
            }*/
            UserModel user = new UserModel()
            {
                Username = username,
                Password = password
            };
            if (UserBLL.Add(user))
            {
                Response.Write("<script>alert('注册成功！请登录');window.location='Login.aspx';</script>");

            }
            else
            {
                Response.Write("<script>alert('注册失败');</script>");
            }
        }
    }
}