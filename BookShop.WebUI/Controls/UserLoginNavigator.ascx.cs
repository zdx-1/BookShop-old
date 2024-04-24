using System;
using System.Web;

/// <summary>
/// 登录页面登录用户控件
/// </summary>
public partial class Controls_UserLoginNavigator : System.Web.UI.UserControl
{

    #region  初始化页面

    /// <summary>
    /// 初始化页面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        getSelect();
    }

    #endregion

    #region  判断页面显示状态

    /// <summary>
    /// 判断页面显示状态
    /// </summary>
    private void getSelect()
    {
        HttpCookie cookieLogin = Request.Cookies["loginUserInfo"];    //获取cookie值判断是否有值和状态
        if (cookieLogin != null)
        {
            if (cookieLogin.Values["roleId"] == "1")    //普通用户显示导航
            {
                hlRegister.Text = "普通用户";
                hlRegister.NavigateUrl = "~/MemberPortal/UserInfo.aspx";
                hlLogin.Text = "欢迎你，" + cookieLogin.Values["loginId"];
                hlClear.Visible = true;
                hla.Visible = true;
                return;
            }
            else if (cookieLogin.Values["roleId"] == "2")    //VIP会员显示导航
            {
                hlRegister.Text = "VIP会员";
                hlRegister.NavigateUrl = "~/MemberPortal/UserInfo.aspx";
                hlLogin.Text = "欢迎你，" + cookieLogin.Values["loginId"];
                hlClear.Visible = true;
                hla.Visible = true;
                return;
            }
            else
            {
                hlLogin.Text = "登录";
                hlLogin.NavigateUrl = "~/MemberPortal/UserLogin.aspx";
                hlRegister.Text = "新用户注册";
                hlRegister.NavigateUrl = "~/MemberPortal/UserRegister.aspx";
                hlClear.Visible = false;
                hla.Visible = false;
            }
        }
        else
        {
            hlLogin.Text = "登录";
            hlLogin.NavigateUrl = "~/MemberPortal/UserLogin.aspx";
            hlRegister.Text = "新用户注册";
            hlRegister.NavigateUrl = "~/MemberPortal/UserRegister.aspx";
            hlClear.Visible = false;
            hla.Visible = false;
        }
    }

    #endregion

    #region  注销Click事件

    /// <summary>
    /// 注销Click事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void hlClear_Click(object sender, EventArgs e)
    {
        HttpCookie cookieLogin = Response.Cookies["loginUserInfo"]; //强制cookie过期
        cookieLogin.Expires = DateTime.Now.AddDays(-1);
        Response.Cookies.Add(cookieLogin);
        getSelect();
    }

    #endregion
}