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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.HttpMethod.ToLower() == "post")
            {
                string realVcode = Request.Cookies["vCode"].Value;
                string vCode = Request.Form["txtVcode"].ToUpper();
                if (realVcode == vCode)
                {
                    string username = Request.Form["username"];
                    string password = Request.Form["password"];
                    UserBLL uBll = new UserBLL();
                   
                    if (uBll.LoginUser(username, password) ==true)
                    {
                        //设置cookie的有效期为1分钟。
                        HttpCookie cookie = new HttpCookie("uName", username);
                        cookie.Expires = DateTime.Now.AddMinutes(5);
                        Response.AppendCookie(cookie);

                        Response.Write("<script>alert('登录成功');window.location='Manage.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('用户名或密码不正确，请重新输入！');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('验证码输入有误，请重新输入！');</script>");
                }
            }

        }

       
    }
}