using BookShop.BLL;
using System;
using System.Web.UI;


/// <summary>
/// 用户个人信息浏览
/// </summary>
public partial class AdminPlatform_UserInfo : System.Web.UI.Page
{
    #region 初始化页面

    /// <summary>
    /// 初始化页面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)     //首次加载页面
        {
            if (Request.QueryString["LoginId"] == null)
            {
                Response.Redirect("UserList.aspx");
            }
            else
            {
                dlsUserInfoList.DataSource = UserManager.GetUserInfoList(Request.QueryString["LoginId"].ToString());
                dlsUserInfoList.DataBind();
            }
        }
    }

    #endregion
}