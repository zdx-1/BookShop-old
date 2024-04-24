using System;
using System.Web.UI.WebControls;
using BookShop.BLL;

/// <summary>
/// 出版社用户控件
/// </summary>
public partial class Controls_BookPubLisherShow : System.Web.UI.UserControl
{
    #region   初始化页面

    /// <summary>
    /// 初始化页面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        dlsPublishers.DataSource = PublisherManager.GetTopBookPublishers();         //调用GetAllBookPublishers方法出版社绑定到DataList控件dlsPublishers上显示
        dlsPublishers.DataBind();
    }

    #endregion

    #region   事件ItemCommand：执行命令，生成查询字符串并跳转URL,跳转的有：出版社

    /// <summary>
    /// 事件ItemCommand：执行命令，生成查询字符串并跳转URL,跳转的有：出版社
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void dlsPublishers_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "ShowBookListPubId")
        {
            Response.Redirect("~/MemberPortal/BookLists.aspx?PubId=" + e.CommandArgument.ToString());//如有多个键-值，以&分隔
        }
    }

    #endregion
}