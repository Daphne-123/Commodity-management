using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using StoreBLL;
using StoreModel;
using System.Text;
using System.IO;

namespace Store
{
    public partial class orderQuery : System.Web.UI.Page
    {
        orderBLL orderBll = new orderBLL();
        protected string ops = string.Empty;
        ProductBLL proBll = new ProductBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            OrderGridView.DataSource = orderBll.GetOrderList();
            OrderGridView.DataBind();
            /*
            List<ClassInfo> clsList = clsBll.GetClassList();
            StringBuilder sbOpts = new StringBuilder();
            foreach (ClassInfo cls in clsList)
            {
                //这个班级作为默认选项
                if (stu.ClassId == cls.Id)
                {
                    sbOpts.Append("<option value='" + cls.Id + "'selected='selected'>" + cls.Name + "</option>");
                }
                else
                {
                    sbOpts.Append("<option value='" + cls.Id + "'>" + cls.Name + "</option>");
                }

            }
            html = html.Replace("{@stuClass}", sbOpts.ToString());
            */
            List<ProductInfo> proInfo = proBll.GetProductList();
            StringBuilder sbOpts = new StringBuilder();
            foreach (ProductInfo cls in proInfo)
            {
                if (ops.Length==0)
                {
                    ops = "<option selected='selected'>请选择你要的商品</option>";

                }
                else
                {
                    ops += "<option value='" + cls.cName + "'>" + cls.cName + "</option>";
                }
            }
        }
        #region  导出
        /// <summary>
        /// 导出功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            Page page = new Page();
            HtmlForm form = new HtmlForm();

            OrderGridView.EnableViewState = false;


            page.EnableEventValidation = false;


            page.DesignerInitialize();

            page.Controls.Add(form);
            form.Controls.Add(OrderGridView);

            page.RenderControl(htw);

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=data.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();
        }

        #endregion

        #region  删除订单
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        protected string DeleteOrder(object orderId)
        {
            return "<a href='javascript:void(0)' onclick='doDeleteOrder(" + orderId.ToString() + ")'> 删除</a>";
        }
        #endregion


    }
}