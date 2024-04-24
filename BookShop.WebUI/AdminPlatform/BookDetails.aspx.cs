using BookShop.BLL;
using BookShop.Model;
using System;
using System.Collections.Generic;


/// <summary>
/// 图书详细信息
/// </summary>
public partial class AdminPlatform_BookDetails : System.Web.UI.Page
{

    #region 初始化页面

    /// <summary>
    /// 初始化页面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["BookId"]))
        {
            int bookId =Convert.ToInt32(Request.QueryString["BookId"].ToString());
            dlsBook.DataSource = GetBookDetails(bookId);      //调用GetNewBookList方法最新图书绑定到DataList控件dlsNewBooks上显示
            dlsBook.DataBind();
        }
        else
        {
            Response.Write("<script language='javascript'>location.href='BookList.aspx'; </script>");
        }
    }

    #endregion

    #region 初始页面选择图书绑定到DataList控件dlsNewBooks上显示

    /// <summary>
    /// 初始页面选择图书绑定到DataList控件dlsNewBooks上显示
    /// </summary>
    /// <returns>返回数据集DataSet</returns>
    private IList<BooksInfo> GetBookDetails(int bookId)
    {
        return BookManager.GetBookDetails(bookId);
    }

    #endregion
}