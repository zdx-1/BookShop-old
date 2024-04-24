using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// 管理员母版
/// </summary>
public partial class Matsers_MemberProtal : System.Web.UI.MasterPage
{
    /// <summary>
    /// 初始化页面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["userName"] == null)     //判断Session值是否为空
        //{
        //    Response.Write("<SCRIPT language='javascript'>alert('您还未登录，正跳转登录页！'); location.href='AdminLogin.aspx'</SCRIPT>");
        //}
        //else
        //{
        //    lblName.Text = Session["userName"].ToString();  //不为空时为导航控件赋值
        //    lblIP.Text = Request.ServerVariables["REMOTE_ADDRESS"].ToString();
        //}
    }
}
