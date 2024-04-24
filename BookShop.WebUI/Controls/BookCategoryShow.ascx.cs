using System;
using System.Web.UI.WebControls;
using BookShop.BLL;

/// <summary>
/// 图书分类用户控件
/// </summary>
public partial class Controls_BookCategoryShow : System.Web.UI.UserControl
{

    #region  初始化页面
    /// <summary>
    /// 初始化页面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        dlsCategories.DataSource =CategoryManager.GetAllBookCategory();         //调用GetAllBookCategory方法图书分类绑定到DataList控件dlsCategories上显示
        dlsCategories.DataBind();
    }

    #endregion

    #region  事件ItemCommand：执行命令，生成查询字符串并跳转URL,跳转的有：图书分类

    /// <summary>
    /// 事件ItemCommand：执行命令，生成查询字符串并跳转URL,跳转的有：图书分类
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void dlsCategories_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "ShowBookListsCatId")
        {
            Response.Redirect("~/MemberPortal/BookLists.aspx?CatId=" + e.CommandArgument.ToString());//如有多个键-值，以&分隔
        }
    }

    #endregion

}