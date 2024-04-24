using System;
using System.Web;
using System.Web.UI;
using BookShop.BLL;

/// <summary>
/// 首页登录用户控件
/// </summary>
public partial class Controls_UserLogin : System.Web.UI.UserControl
{

    #region  初始化页面

    /// <summary>
    /// 初始化页面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)   //首次加载页面
        {
            lblMessage.Text = "欢迎访问当当网上书店！";
            GetHttpCookie();    //调用GetHttpCookie方法初始判断登陆状态并获取状态信息
            HttpCookie cookieCount = Request.Cookies["count"];
            if (cookieCount == null)   //判断是否存在或被禁用
            {
                Response.Cookies["count"].Value = "3";      //请求响应写入临时cookie["count"]初始值
                Response.Cookies["count"].Expires = DateTime.Now.AddMinutes(15);
            }
        }
        else
        {
            GetHttpCookie();
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

    #region   登录Click事件

    /// <summary>
    /// 登录Click事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            string loginId = txtLoginId.Text.Trim();   //定义变量、获取客户输入用户名，并调用MD5方法加密密码。
            //string loginPwd = MD5(txtLoginPwd.Text.Trim(), 32);
            string loginPwd = txtLoginPwd.Text.Trim();
            int errId = UserManager.CheckValidUser(loginId, loginPwd);
            if (errId>0)     //调用CheckValidUser方法判断登录是否成功并返回1
            {
                getLoginOk(loginId,errId.ToString());      //调用getLoginOk_1方法实现普通用户登录
            }
            else
            {
                getCount(); //调用getCount方法实现登录失败方案
            }
        }
        catch
        {
            Response.Redirect("Default.aspx");
        }
    }

    #endregion

    #region   注销Click事件

    /// <summary>
    /// 注销Click事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        HttpCookie cookieLogin = Response.Cookies["loginUserInfo"]; //强制cookie过期
        cookieLogin.Expires = DateTime.Now.AddDays(-1);
        Response.Cookies.Add(cookieLogin);

        Response.Write("<script language='javascript'>location.href='Default.aspx';</script>");
        Response.Cookies["count"].Value = "3";      //请求响应写入临时cookie["count"]初始值
        Response.Cookies["count"].Expires = DateTime.Now.AddMinutes(15);
        pnlTwo.Visible = false;
        pnlOne.Visible = true;
    }

    #endregion

    #region   初始判断登陆状态并获取状态信息

    /// <summary>
    /// 初始判断登陆状态并获取状态信息
    /// </summary>
    private void GetHttpCookie()
    {
        HttpCookie cookieLogin = Request.Cookies["loginUserInfo"];  //获取cookie

        if (cookieLogin == null)     //判断cookie值状态
        {
            HttpCookie cookieCount = Request.Cookies["count"];
            if (cookieCount != null)
            {
                if (Convert.ToInt32(Request.Cookies["count"].Value) <= 0)
                {
                    btnLogin.Enabled = false;
                }
                else
                {
                    if (Convert.ToString(Request.Cookies["count"]) != "System.Web.HttpCookie")
                    {
                        lblMessage.Text = "登录失败，您还有" + Request.Cookies["count"] + "次登录次数";
                    }
                    else
                        lblMessage.Text = "用户登录";
                }
            }

            pnlOne.Visible = true;
            pnlTwo.Visible = false;
        }
        else
        {
            lblGreet.Text = cookieLogin.Values["loginId"];   //用cookie给页面控件赋值
            lblBrithday.Text = cookieLogin.Values["visitDate"];
            lblIP.Text = Request.ServerVariables["REMOTE_ADDRESS"].ToString();
            //this.lblIP.Text = Request.UserHostAddress;
            lblMessage.Text = "欢迎登录，" + cookieLogin.Values["loginId"];
            pnlOne.Visible = false;
            pnlTwo.Visible = true;
        }
    }

    #endregion

    #region  用户登录成功方法

    /// <summary>
    /// 用户登录成功方法
    /// </summary>
    /// <param name="loginId">取出赋给cookie</param>
    private void getLoginOk(string loginId, string errId)
    {
        /*单值
                //通过新建HttpCookie对象来添加Cookie
                HttpCookie cookieLogin = new HttpCookie("userName");
                cookieLogin.Value = loginId;
                cookieLogin.Expires = DateTime.Now.AddDays(1);//设置cookie的过期
                Response.Cookies.Add(cookieLogin);//将Cookie添加到Cookies集合
                //通过键-值对添加Cookie
                Response.Cookies["userName"].Value = loginId;
                Response.Cookies["userName"].Expires = DateTime.Now.AddDays(1);
            */
        //多值
        HttpCookie cookieLogin = Response.Cookies["loginUserInfo"];     //请求响应写入cookie值
        cookieLogin.Values["loginId"] = loginId;
        cookieLogin.Values["RoleId"] = errId;
        cookieLogin.Values["visitDate"] = DateTime.Now.ToString();
        Response.Cookies.Add(cookieLogin);

        Response.Write("<script language='javascript'>location.href='Default.aspx';</script>");
    }

    #endregion

    #region  登录次数限制方法

    /// <summary>
    /// 登录次数限制方法
    /// </summary>
    private void getCount()
    {
        string count = Request.Cookies["count"].Value;  //获取临时cookie["count"]值

        if (Convert.ToInt32(count) <= 0)    //判断次数限制
        {
            Response.Cookies["count"].Value = Convert.ToString(Convert.ToInt32(count) - 1);     //提示登录次数
            lblMessage.Text = "您已达到限制登录次数,15分钟内无法再次登录！";
            btnLogin.Enabled = false;
            return;
        }
        if (txtLoginId.Text == "" && txtLoginPwd.Text == "")    //未输入内容
        {
            lblMessage.Text = "欢迎你，请登录！";
        }
        else
        {
            Response.Cookies["count"].Value = Convert.ToString(Convert.ToInt32(count) - 1);     //提示登录次数
            lblMessage.Text = "登录失败，您还有" + count + "次登录次数";
        }
    }

    #endregion
}