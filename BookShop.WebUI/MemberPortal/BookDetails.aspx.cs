using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BookShop.BLL;
using BookShop.Model;

/// <summary>
/// 图书详细信息显示
/// </summary>
public partial class BookDetails : System.Web.UI.Page
{
    #region 初始化页面
    /// <summary>
    /// 初始化页面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["Ok"] = null;
            if (!string.IsNullOrEmpty(Request.QueryString["BookId"]))
            {
                int bookId =Convert.ToInt32(Request.QueryString["BookId"].ToString());
                AddBookClick(bookId);
                dlsBook.DataSource = GetBookDetails(bookId);      //调用GetNewBookList方法最新图书绑定到DataList控件dlsNewBooks上显示
                dlsBook.DataBind();
            }
            else
            {
                Response.Write("<script language='javascript'>location.href='BookLists.aspx'; </script>");
            }
        }
    }

    #endregion

    #region 点击某一本图书点击率加1方法

    /// <summary>
    /// 点击某一本图书点击率加1方法
    /// </summary>
    /// <param name="bookId"></param>
    private void AddBookClick(int bookId)
    {
        BookManager.AddBookClick(bookId);
    }

    #endregion

    #region  图书详细信息浏览（图书详细页）

    /// <summary>
    /// 图书详细信息浏览（图书详细页）
    /// </summary>
    /// <returns></returns>
    private IList<BooksInfo> GetBookDetails(int bookId)
    {
        return BookManager.GetBookDetails(bookId);
    }

    #endregion

    #region  事件RowCommand：执行命令，购买图书

    /// <summary>
    /// 事件RowCommand：执行命令，购买图书
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void dlsBook_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "ShoppingBook")
        {
            Response.Redirect("Settlement.aspx?Id=" + e.CommandArgument);
        }
    }

    #endregion

}