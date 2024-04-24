using System;
using System.Configuration;
using BookShop.BLL;
using BookShop.Common.DB;

/// <summary>
/// 管理员登陆
/// </summary>
public partial class AdminPlatform_AdminLogin : System.Web.UI.Page
{
    #region 初始化页面
    /// <summary>
    /// 初始化页面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["c"] != null)
        {
            Session.Abandon();  //注销Session的的方法
            Response.Redirect("AdminLogin.aspx");
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

    #region  登录Click事件

    /// <summary>
    /// 登录Click事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnOk_Click(object sender, EventArgs e)
    {
        //int i = CheckValidAdmin(txtID.Text, MD5(txtPassword.Text, 32));      //调用CheckValidAdmin方法校验用户合法性并将返回值存入变量
        int i = CheckValidAdmin(txtID.Text, txtPassword.Text);
        if (i == 0)   //可以登录
        {
            Session["userName"] = txtID.Text;
            Response.Write("<script language='javascript'>window.location.href ='AdminDefault.aspx';</script>");
        }
        else if (i == -1)     //权限不足
        {
            lblShow1.Text = "*你权限不足！";
        }
        else if (i == -2)     //账号被禁用或删除
        {
            lblShow1.Text = "*此账号已被停用或删除！";
        }
        else if (i == -3)     //密码错误
        {
            lblShow2.Text = "*密码错误！";
        }
        else if (i == -4)
        {
            lblShow1.Text = "*此用户不存在！";
        }
        else
        {
            Response.Redirect("../ErrorPage.aspx");
        }
    }

    #endregion

    #region  校验用户合法性。

    /// <summary>
    /// 校验用户合法性。
    /// </summary>
    /// <param name="userName">用户名</param>
    /// <param name="password">密码</param>
    /// <returns>0/-1/-2/-3/-4</returns>
    private int CheckValidAdmin(string loginId, string loginPwd)
    {
        return UserManager.CheckValidAdmin(loginId,loginPwd);
    }

    #endregion

    #region  清空Click事件

    /// <summary>
    /// 清空Click事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtID.Text = "";
        txtPassword.Text = "";
    }

    #endregion

}
