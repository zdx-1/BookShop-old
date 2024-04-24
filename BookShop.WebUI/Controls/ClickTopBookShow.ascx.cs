using System;
using System.Web.UI.WebControls;
using BookShop.BLL;

/// <summary>
/// 点击率排行榜用户控件
/// </summary>
public partial class Controls_ClickTopBookShow : System.Web.UI.UserControl
{

    #region  初始化页面

    /// <summary>
    /// 初始化页面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        dlsClicks.DataSource =BookManager.GetClicks();         //调用GetClicks方法点击榜绑定到DataList控件dlsClicks上显示
        dlsClicks.DataBind();
    }

    #endregion

    #region  事件ItemCommand：执行命令，生成查询字符串并跳转URL,跳转的有：点击率排行榜

    /// <summary>
    /// 事件ItemCommand：执行命令，生成查询字符串并跳转URL,跳转的有：点击率排行榜
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void dlsNewBooks_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "ShowBookDetails")
        {
            Response.Redirect("~/MemberPortal/BookDetails.aspx?BookId=" + e.CommandArgument.ToString());//如有多个键-值，以&分隔
        }
    }

    #endregion

}