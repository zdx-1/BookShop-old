using System;
using System.Web.UI.WebControls;
using BookShop.BLL;

public partial class Controls_EditorRecommendBookShow : System.Web.UI.UserControl
{

    #region  初始化页面

    /// <summary>
    /// 初始化页面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        dlsEditorRecommendBooks.DataSource =BookManager.GetEditorRecommendBooksList();     //调用GetEditorRecommendBooks方法编辑推荐图书绑定到DataList控件dlsEditorRecommendBooks上显示
        dlsEditorRecommendBooks.DataBind();
    }

    #endregion

    #region   事件ItemCommand：执行命令，生成查询字符串并跳转URL,跳转的有：编辑推荐图书

    /// <summary>
    /// 事件ItemCommand：执行命令，生成查询字符串并跳转URL,跳转的有：编辑推荐图书
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