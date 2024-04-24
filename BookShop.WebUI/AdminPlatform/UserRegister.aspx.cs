using BookShop.BLL;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;


/// <summary>
/// 会员新增
/// </summary>
public partial class AdminPlatform_UserRegister : System.Web.UI.Page
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
            gvcCheckCode.Create();  //验证码初始化
            CompareValidator2.ValueToCompare = gvcCheckCode.ValidateCode;
        }
    }

    #endregion

    #region MD5加密算法

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

    #region  确认注册Click事件

    /// <summary>
    /// 确认注册Click事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            string passwordMD5 = MD5(txtPassword.Text.Trim(), 32);    //调用MD5方法加密密码

            if (GetbtnSelect(txtId.Text, txtEmail.Text))   //调用getbtnSelect方法检验输入用户名是否已存在
            {
                Response.Write("<SCRIPT language='javascript'>alert('用户名已存在，或E-Mail已被注册过！');</SCRIPT>");
                return;
            }
            if (!gvcCheckCode.CheckValidateCode(txtValidator.Text.Trim()))      //验证码验证
            {
                txtValidator.Focus();       //校验码输入不正确，使校验码输入文本框控件具有焦点
                return;
            }
            string strGender = rdoMail.Checked ? rdoMail.Text : rdoFemail.Text.ToString();  //获取男女单选按钮值
            string strDegree = ddlDegree.SelectedValue;     //获取下拉列表值
            string originMessage = string.Empty;       //获取CheckBox选项值
            foreach (ListItem cbOrigin in Items)
            {
                if (cbOrigin.Selected == true)
                {
                    originMessage = originMessage + string.Format("{0};", cbOrigin.Value.ToString().Trim());
                }
            }

            if (GetExecuteNonQuery(txtId.Text, passwordMD5, txtName.Text, txtAddress.Text, txtPhone.Text, txtEmail.Text) > 0)   //调用getExecuteNonQuery方法实现注册功能
            {
                Response.Write("<SCRIPT language='javascript'>alert('注册成功！'); location.href='UserList.aspx'</SCRIPT>");
            }
            else
            {
                Response.Write("<SCRIPT language='javascript'>location.href='../ErrorPage.aspx'</SCRIPT>");
            }
        }
        catch
        {
            Response.Redirect("UserRegister.aspx");
        }
    }

    #endregion

    #region  检验输入用户名是否已存在Click事件

    /// <summary>
    /// 检验输入用户名是否已存在Click事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        if (GetbtnSelect(txtId.Text, txtEmail.Text))    //调用getbtnSelect方法检验输入用户名是否已存在
        {

            lblMessages.Visible = true;
            lblMessages.Text = "用户名已存在，或E-Mail已被注册过！";
        }
        else
        {
            lblMessages.Visible = true;
            lblMessages.Text = "用户名和E-mail可以使用";
        }
    }

    #endregion

    #region 检验输入用户名是否已存在方法

    /// <summary>
    /// 检验输入用户名是否已存在方法
    /// </summary>
    /// <param name="loginId">用户名</param>
    /// <param name="mail">E-Mail电子邮箱</param>
    /// <returns>返回bool类型值</returns>
    private bool GetbtnSelect(string loginId, string mail)
    {
        return UserManager.GetbtnSelect(loginId,mail);
    }

    #endregion

    #region 用户注册方法

    /// <summary>
    /// 用户注册方法
    /// </summary>
    /// <param name="loginId">用户名</param>
    /// <param name="loginPwd">密码</param>
    /// <param name="name">姓名</param>
    /// <param name="address">地址</param>
    /// <param name="phone">电话或手机号码</param>
    /// <param name="mail">E-mail</param>
    /// <returns>返回int类型值</returns>
    private int GetExecuteNonQuery(string loginId, string loginPwd, string name, string address, string phone, string mail)
    {
        return UserManager.GetExecuteNonQuery(loginId, loginPwd, name, address, phone, mail);
    }

    #endregion
}