using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;
using BookShop.Model;
using Great.Core;

/// <summary>
/// 图书浏览
/// </summary>
public partial class AdminPlatform_BookList : System.Web.UI.Page
{
    #region  初始化页面

    /// <summary>
    /// 初始化页面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session["Ok"] = null;
            ddlCategoryBind();      //调用ddlCategoryBind方法绑定图书分类信息
            AspNetPager1.RecordCount = GetAspNetPager_PageCount();
            BindGridView(1);
        }
    }

    #endregion

    #region  绑定分页和GridView方法

    /// <summary>
    /// 绑定分页和GridView方法
    /// </summary>
    /// <param name="pageindex"></param>
    private void BindGridView(int pageindex)
    {
        gvwBookList.DataSource = GetBookList(Convert.ToInt32(ddlCategory.SelectedValue), pageindex);
        gvwBookList.DataBind();
    }

    #endregion

    #region  AspNetPager控件分页数获取方法

    /// <summary>
    /// AspNetPager控件分页数获取方法
    /// </summary>
    /// <returns></returns>
    private int GetAspNetPager_PageCount()
    {
        return BookManager.GetAdminAspNetPager_PageCount(Convert.ToInt32(ddlCategory.SelectedValue));
    }

    #endregion

    #region  AspNetPager控件翻页后触发

    /// <summary>
    /// AspNetPager控件翻页后触发
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        //调用绑定分页和GridView    
        BindGridView(this.AspNetPager1.CurrentPageIndex);
    }

    #endregion

    #region  初始化图书浏览方法

    /// <param name="sender"></param>
    /// 初始化图书浏览方法
    /// </summary>
    /// <returns></returns>
    private IList<BooksInfo> GetBookList(int catId, int pageindex)
    {
        return BookManager.GetAdminBookList(catId, pageindex);
    }

    #endregion

    #region  ”全选“复选框CheckedChanged事件

    /// <summary>
    /// ”全选“复选框CheckedChanged事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= gvwBookList.Rows.Count - 1; i++)
        {
            CheckBox chkSel = (CheckBox)gvwBookList.Rows[i].FindControl("chkSelect");
            chkSel.Checked = chkSelectAll.Checked;
        }
    }

    #endregion

    #region  绑定图书分类DropDownList控件

    /// <summary>
    /// 绑定图书分类DropDownList控件
    /// </summary>
    private void ddlCategoryBind()
    {
        IList<CategoriesInfo> list = CategoryManager.GetAllBookCategory();

        this.ddlCategory.DataTextField = "Name";    //按姓名下拉表框绑定
        this.ddlCategory.DataValueField = "Id";
        this.ddlCategory.DataSource = list;
        this.ddlCategory.DataBind();
    }

    #endregion

    #region  图书分类DropDownList控件值改变时执行事件

    /// <summary>
    /// 图书分类DropDownList控件值改变时执行事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {

        AspNetPager1.RecordCount = GetAspNetPager_PageCount();
        //调用绑定分页和GridView    
        BindGridView(this.AspNetPager1.CurrentPageIndex);
    }

    #endregion

    #region  实现光棒效果

    /// <summary>
    /// 实现光棒效果
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvwBookList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)    //指定数据控件行的类型
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#D3D7F5'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
        }
    }

    #endregion

    #region  多选删除方法

    /// <summary>
    /// 多选删除方法
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnDelete_Click(object sender, EventArgs e)
    {
        for (int i = 0; i <= gvwBookList.Rows.Count - 1; i++)
        {
            CheckBox chkSel = (CheckBox)gvwBookList.Rows[i].FindControl("chkSelect");
            if (chkSel.Checked == true)
            {
                int selId = (int)gvwBookList.DataKeys[i].Value;
                BookManager.DeleteBooks(selId);
            }
        }
        //调用绑定分页和GridView    
        BindGridView(this.AspNetPager1.CurrentPageIndex);
    }

    #endregion

    #region   事件RowCommand：执行命令，删除或编辑图书信息

    /// <summary>
    /// 事件RowCommand：执行命令，删除或编辑图书信息
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void gvwBookList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteBook")
        {
            if (BookManager.DeleteBooks(Convert.ToInt32(e.CommandArgument)))
            {
                WindowHelper.Alert("删除成功！", this);
                //调用绑定分页和GridView    
                BindGridView(this.AspNetPager1.CurrentPageIndex);
            }
        }
        if (e.CommandName == "UpdateBook")
        {
            Response.Redirect("ModifyBook.aspx?Id=" + e.CommandArgument);
            return;
        }
    }

    #endregion
}