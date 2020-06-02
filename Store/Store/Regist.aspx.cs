using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StoreBLL;
using StoreModel;

namespace Store
{
    public partial class Regist : System.Web.UI.Page
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
                    string pwd = Request.Form["pwd"];
                    if (pwd.Length > 0)
                    {
                        UserBLL uBll = new UserBLL();
                        UserInfo uInfo = new UserInfo();
                        uInfo.userName = username;
                        uInfo.passWord = pwd;
                        if (uBll.AddAddUser(uInfo))
                        {
                            Response.Write("<script>alert('注册成功');window.location='Login.aspx';</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('密码不能为空！');</script>");
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