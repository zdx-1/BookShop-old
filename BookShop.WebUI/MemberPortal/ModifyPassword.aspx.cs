using System;
using System.Web;
using BookShop.BLL;

/// <summary>
/// 会员修改密码
/// </summary>
public partial class MemberPortal_ModifyPassword : System.Web.UI.Page
{
    #region 初始化页面
    /// <summary>
    /// 初始化页面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookieLogin = Request.Cookies["loginUserInfo"];  //获取cookie值并判断
        if (cookieLogin == null)
        {
            txtId.ReadOnly = false;
        }
        else
        {
            txtId.Text = cookieLogin.Values["loginId"];
        }
    }

    #endregion

    #region  MD5加密算法

    ///  <summary> 
    /// MD5加密算法 
    ///  </summary> 
    ///  <param name="str">字符串 </param> 
    ///  <param name="code">加密方式,16或32 </param> 
    ///  <returns>返回加密后string类型值</returns> 
    public static string MD5(string str, int code)
    {
        if (code == 16) //16位MD5加密（取32位加密的9~25字符）  	
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToUpper().Substring(8, 16);

        }
        else//32位加密  	
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToUpper();
        }
    }

    #endregion

    #region  确认修改Click事件

    /// <summary>
    /// 确认修改Click事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            string loginId = txtId.Text.Trim();     //从页面控件取值，分别获取用户名、原密码、新密码，并调用MD5方法对密码MD5加密
            string loginPwd = MD5(txtPassword.Text.Trim(), 32);
            string newloginPwd = MD5(txtAgainNewPassword.Text.Trim(), 32);

            if (getExecuteSelect(loginId, loginPwd))     //调用getExecuteSelect方法判断原密码输入是否正确
            {
                if (getExecuteUpdate(loginId, newloginPwd))     //调用getExecuteUpdate方法判断更新是否成功
                {
                    Response.Write("<SCRIPT language='javascript'>alert('更新成功，正跳转首页！'); location.href='../Default.aspx'</SCRIPT>");
                }
                else
                {
                    Response.Write("<SCRIPT language='javascript'>location.href='../ErrorPage.aspx'</SCRIPT>");
                }
            }
            else
            {
                Response.Write("<SCRIPT language='javascript'>alert('原密码输入错误！');</SCRIPT>");
            }
        }
        catch
        {
            Response.Redirect("ModifyPassword.aspx");
        }
    }

    #endregion

    #region  判断原密码输入是否正确方法

    /// <summary>
    /// 判断原密码输入是否正确方法
    /// </summary>
    /// <param name="loginId">用户名</param>
    /// <param name="loginPwd">原密码</param>
    /// <returns>返回bool类型值</returns>
    private bool getExecuteSelect(string loginId, string loginPwd)
    {
        return UserManager.CheckValidUser(loginId, loginPwd) > 0;
    }

    #endregion

    #region  修改密码方法

    /// <summary>
    /// 修改密码方法
    /// </summary>
    /// <param name="loginId">用户名</param>
    /// <param name="newloginPwd">新密码</param>
    /// <returns>返回bool类型值</returns>
    private bool getExecuteUpdate(string loginId, string newloginPwd)
    {
        return UserManager.GetExecuteUpdate(loginId, newloginPwd);
    }

    #endregion
}