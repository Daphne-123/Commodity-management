using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Store
{
    public partial class Manage : System.Web.UI.Page
    {
        protected string name = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["uName"];
            if (cookie == null)
            {
                Response.Write("<script>alert('你还没有登录，请先登录');window.location='Login.aspx';</script>");
            }
            else
            {
                this.name = cookie.Value;
            }
        }
    }
}