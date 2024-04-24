using System;
using System.Web.UI.WebControls;
using BookShop.BLL;

/// <summary>
/// 首页最新图书用户控件
/// </summary>
public partial class Controls_RecentNewBookShow : System.Web.UI.UserControl
{

    #region  初始化页面

    /// <summary>
    /// 初始化页面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        dlsNewBooks.DataSource = BookManager.GetNewBooksList();      //调用GetBookById方法最新图书绑定到DataList控件dlsNewBooks上显示
        dlsNewBooks.DataBind();
    }

    #endregion

    #region  事件ItemCommand：执行命令，生成查询字符串并跳转URL,跳转的有：最新图书

    /// <summary>
    /// 事件ItemCommand：执行命令，生成查询字符串并跳转URL,跳转的有：最新图书
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