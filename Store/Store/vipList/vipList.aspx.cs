﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using StoreBLL;
using StoreModel;

namespace Store
{
    public partial class vipList : System.Web.UI.Page
    {
        vipBLL vipBll = new vipBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            VipGridView.DataSource = vipBll.GetVipList();
            VipGridView.DataBind();
        }

        #region  修改信息
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        protected string UpdateVipList(object pId)
        {
            return "<a href='UpdateVipListHandler.ashx?pId=" + pId.ToString() + "'>修改</a>";
        }
        #endregion

        #region  删除信息
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        protected string DeleteVipList(object pId)
        {
            return "<a href='javascript:void(0)' onclick='doDeleteVip(" + pId.ToString() + ")'> 删除</a>";
        }
        #endregion

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

            VipGridView.EnableViewState = false;

           
            page.EnableEventValidation = false;

         
            page.DesignerInitialize();

            page.Controls.Add(form);
            form.Controls.Add(VipGridView);

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
        
      
    }

}