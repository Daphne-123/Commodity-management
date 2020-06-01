using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store
{
    /// <summary>
    /// ValidateView 的摘要说明
    /// </summary>
    public class ValidateView : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
              StoreUtility.ValidateCode  vc = new StoreUtility.ValidateCode(context);
              string code = vc.GetCode(4);
              vc.CreateValidateImage(code, 100, 35);
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