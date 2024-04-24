using System;
using System.Web;
using System.Web.UI;
using BookShop.BLL;

/// <summary>
/// 用户个人信息浏览
/// </summary>
public partial class MemberPortal_UserInfo : System.Web.UI.Page
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
            HttpCookie cookieLogin = Request.Cookies["loginUserInfo"];
            if(cookieLogin==null)
            {
                Response.Redirect("UserLogin.aspx");
            }
            else
            {
                dlsUserInfoList.DataSource=UserManager.GetUserInfoList(cookieLogin.Values["loginId"]);
                dlsUserInfoList.DataBind();
            }
        }
    }

    #endregion
}