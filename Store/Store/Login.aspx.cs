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

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = this.username.Text;
            string password = this.password.Text;

           /* if (UserBLL.Login(username, password)==true){
                 Response.Write("<script>alert('登录成功!');window.location='Manage.aspx';</script>");
            }*/
        }
    }
}