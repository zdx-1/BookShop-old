using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BookShop.BLL;
using BookShop.Model;

/// <summary>
/// 图书浏览
/// </summary>
public partial class MemberPortal_BookLists : System.Web.UI.Page
{
    static string whereName="";
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
            BindGridView(1, "");
        }
    }

    #endregion

    #region 初始化绑定分页和GridView方法

    /// <summary>
    /// 初始化绑定分页和GridView方法
    /// </summary>
    /// <param name="whereName">指定按什么方式排序，不排序为string类型："0"字符</param>
    /// <param name="pageindex"></param>
    private void BindGridView(int pageindex, string whereName)
    {
        if (Request.QueryString["CatId"] != null)
        {
            string catId = Request.QueryString["CatId"].ToString();
            this.AspNetPager1.RecordCount = GetAspNetPager_PageCount(catId, whereName, 1);
            dlsBook.DataSource = GetBookList(pageindex, catId, whereName, 1);      //调用GetCategoriesBookList方法分类图书绑定到DataList控件dlsBook上显示
            dlsBook.DataBind();

        }
        else if (Request.QueryString["PubId"] != null)
        {
            string pubId = Request.QueryString["PubId"].ToString();
            this.AspNetPager1.RecordCount = GetAspNetPager_PageCount(pubId, whereName, 2);
            dlsBook.DataSource = GetBookList(pageindex, pubId, whereName, 2);      //调用GetPublishersBookList方法分类图书绑定到DataList控件dlsBook上显示
            dlsBook.DataBind();
        }
        else if (!string.IsNullOrEmpty(Request.QueryString["Title"]))
        {
            string loadTitle = "%" + Request.QueryString["Title"].ToString() + "%";
            this.AspNetPager1.RecordCount = GetAspNetPager_PageCount(loadTitle, whereName, 3);
            dlsBook.DataSource = GetBookList(pageindex, loadTitle, whereName, 3);      //调用GetPublishersBookList方法分类图书绑定到DataList控件dlsBook上显示
            dlsBook.DataBind();
        }
        else
        {
            this.AspNetPager1.RecordCount = GetAspNetPager_PageCount("0", whereName, 0);
            dlsBook.DataSource = GetBookList(pageindex, "0", whereName, 0);         //调用GetBookList方法图书分类绑定到DataList控件dlsBook上显示
            dlsBook.DataBind();
        }
    }

    #endregion

    #region AspNetPager控件翻页后触发

    /// <summary>
    /// AspNetPager控件翻页后触发
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        //调用绑定分页和GridView    
        BindGridView(this.AspNetPager1.CurrentPageIndex, whereName);
    }

    #endregion                  

    #region  AspNetPager控件分页数获取方法（图书浏览页）

    /// <summary>
    /// AspNetPager控件分页数获取方法
    /// </summary>
    /// <returns></returns>
    private int GetAspNetPager_PageCount(string logicId, string whereName, int x)   //x为0时说明浏览所有图书页数获取方法
    {
        return BookManager.GetAspNetPager_PageCount(logicId, whereName, x);
    }

    #endregion

    #region 浏览图书信息（图书浏览页）

    /// <summary>
    /// 浏览图书绑定到DataList控件dlsBook上显示
    /// </summary>
    /// <param name="logicId">所取参数Id，可取的有：CatId、PubId,没有指定默认为string类型："0"字符</param>
    /// <param name="whereName">指定按什么方式排序，不排序为string类型："0"字符</param>
    /// <param name="x"></param>
    /// <returns></returns>
    private IList<BooksInfo> GetBookList(int pageindex, string logicId, string whereName, int x)
    {
        return BookManager.GetBookList(pageindex, logicId, whereName, x);
    }

    #endregion

    #region  事件ItemCommand：执行命令，生成查询字符串并跳转URL，跳转到图书详细信息

    /// <summary>
    /// 事件ItemCommand：执行命令，生成查询字符串并跳转URL，跳转到图书详细信息
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

    #region  出版时间排序Click事件

    /// <summary>
    /// 出版时间排序Click事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPublishDate_Click(object sender, EventArgs e)
    {
        whereName = "PublishDate";
        BindGridView(1, "PublishDate");
    }

    #endregion

    #region  价格排序Click事件

    /// <summary>
    /// 价格排序Click事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUnitPrice_Click(object sender, EventArgs e)
    {
        whereName = "UnitPrice";
        BindGridView(1, "UnitPrice");
    }
    #endregion
}