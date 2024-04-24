using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BookShop.BLL;
using BookShop.Model;
using Great.Core;

/// <summary>
/// 图书分类浏览
/// </summary>
public partial class AdminPlatform_CategoryList : System.Web.UI.Page
{

    #region  初始化页面

    /// <summary>
    /// 初始化页面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
        gvwBookCategoryList.DataSource = GetBookCategoryList(pageindex);
        gvwBookCategoryList.DataBind();
    }

    #endregion

    #region  AspNetPager控件分页数获取方法

    /// <summary>
    /// AspNetPager控件分页数获取方法
    /// </summary>
    /// <returns></returns>
    private int GetAspNetPager_PageCount()
    {
        return CategoryManager.GetAspNetPager_PageCount();
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

    #region  初始化图书分类浏览方法

    /// <summary>
    /// 初始化图书分类浏览方法
    /// </summary>
    /// <returns></returns>
    private IList<CategoriesInfo> GetBookCategoryList(int pageindex)
    {
        return CategoryManager.GetBookCategoryList(pageindex);
    }

    #endregion

    #region  实现光棒效果

    /// <summary>
    /// 实现光棒效果
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvwBookCategory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)    //指定数据控件行的类型
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#D3D7F5'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
        }
    }

    #endregion

    #region  事件RowCommand：执行命令，删除或编辑图书分类信息

    /// <summary>
    /// 事件RowCommand：执行命令，删除或编辑图书分类信息
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void gvwBookCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteBookCategory")
        {
            if (CategoryManager.DeleteBooksCategory(Convert.ToInt32(e.CommandArgument)))
            {
                WindowHelper.Alert("删除成功！", this);
                //调用绑定分页和GridView    
                BindGridView(this.AspNetPager1.CurrentPageIndex);
            }
        }
    }

    #endregion

    #region  添加图书分类Click事件

    /// <summary>
    /// 添加图书分类Click事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddBookCategory_Click(object sender, EventArgs e)
    {
        if (txtCatName.Text != null || txtCatName.Text != "")
        {
            if (CategoryManager.AddBooksCategory(txtCatName.Text))  //图书分类添加时执行判断是否已有值
            {
                Response.Write("<script>alert('名称已存在！');</script>");
            }
            else
            {
                WindowHelper.Alert("添加成功！", this);
                txtCatName.Text = "";
                //调用绑定分页和GridView    
                BindGridView(this.AspNetPager1.CurrentPageIndex);
            }
        }
    }

    #endregion

    #region  设置编辑项索引为当前编辑项的行

    /// <summary>
    /// 设置编辑项索引为当前编辑项的行
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvwBookCategoryList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvwBookCategoryList.EditIndex = e.NewEditIndex;
        //调用绑定分页和GridView    
        BindGridView(this.AspNetPager1.CurrentPageIndex);

    }

    #endregion

    #region  当GridView生成Cancel时激发事件

    /// <summary>
    /// 当GridView生成Cancel时激发事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvwBookCategoryList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvwBookCategoryList.EditIndex = -1;
        //调用绑定分页和GridView    
        BindGridView(this.AspNetPager1.CurrentPageIndex);
    }

    #endregion

    #region  点击编辑后点击更新事件

    /// <summary>
    /// 点击编辑后点击更新事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvwBookCategoryList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string lblId = "";
        string txtName = "";
        IList<CategoriesInfo> list = GetBookCategoryList(this.AspNetPager1.CurrentPageIndex);
        foreach (CategoriesInfo categoriesInfo in list)
        {
            //依次判断购物车中哪行处于编辑状态
            if (categoriesInfo.Id.ToString().Equals((this.gvwBookCategoryList.Rows[e.RowIndex].FindControl("lblId") as Label).Text))
            {
                //如果当前行处于编辑状态，取值
                lblId = (gvwBookCategoryList.Rows[e.RowIndex].FindControl("lblId") as Label).Text.Trim();
                txtName = (gvwBookCategoryList.Rows[e.RowIndex].FindControl("txtName") as TextBox).Text.Trim();

            }
        }
        if (GetUpdateExist(txtName))         //判断数据库是否存在编辑后的图书分类值
        {
            Response.Write("<script>alert('此分类名称已存在！');</script>");
        }
        else
        {
            UpdateCategory(lblId, txtName);
        }
        gvwBookCategoryList.EditIndex = -1;

        //调用绑定分页和GridView    
        BindGridView(this.AspNetPager1.CurrentPageIndex);
    }

    #endregion

    #region  图书分类编辑时执行判断

    /// <summary>
    /// 图书分类编辑时执行判断
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private bool GetUpdateExist(string name)
    {
        return CategoryManager.GetUpdateExist(name);
    }

    #endregion

    #region  图书分类编辑方法

    /// <summary>
    /// 图书分类编辑方法
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    private bool UpdateCategory(string id, string name)
    {
        return CategoryManager.UpdateCategory(id, name);
    }

    #endregion


}