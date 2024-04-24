using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BookShop.BLL;
using BookShop.Model;
using Great.Core;

/// <summary>
/// 出版社浏览
/// </summary>
public partial class AdminPlatform_PublishersList : System.Web.UI.Page
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
        gvwBookPublisherList.DataSource = GetBookPublisherList(pageindex);
        gvwBookPublisherList.DataBind();
    }

    #endregion

    #region  AspNetPager控件分页数获取方法

    /// <summary>
    /// AspNetPager控件分页数获取方法
    /// </summary>
    /// <returns></returns>
    private int GetAspNetPager_PageCount()
    {
        return PublisherManager.GetAspNetPager_PageCount();
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

    /// <summary>
    /// 初始化图书浏览方法
    /// </summary>
    /// <returns></returns>
    private IList<PublishersInfo> GetBookPublisherList(int pageindex)
    {
        return PublisherManager.GetBookPublisherList(pageindex);     
    }

    #endregion

    #region  实现光棒效果

    /// <summary>
    /// 实现光棒效果
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvwBookPublisher_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)    //指定数据控件行的类型
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#D3D7F5'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
        }
    }

    #endregion

    #region  事件RowCommand：执行命令，删除或编辑出版社信息

    /// <summary>
    /// 事件RowCommand：执行命令，删除或编辑出版社信息
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void gvwBookPublisher_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeletePublisher")
        {
            if (PublisherManager.DeleteBooksPublisher(Convert.ToInt32(e.CommandArgument)))
            {
                WindowHelper.Alert("删除成功！", this);
                //调用绑定分页和GridView    
                BindGridView(this.AspNetPager1.CurrentPageIndex);
            }
        }
    }

    #endregion

    #region  添加出版社Click事件

    /// <summary>
    /// 添加出版社Click事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddBookPublisher_Click(object sender, EventArgs e)
    {
        if (txtPubName.Text != "" || txtPubName.Text != null)
        {
            if (PublisherManager.AddPublisher(txtPubName.Text))  //出版社添加时执行判断是否已有值
            {
                Response.Write("<script>alert('名称已存在！');</script>");
            }
            else
            {
                WindowHelper.Alert("添加成功！", this);
                txtPubName.Text = "";
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
    protected void gvwBookPublisherList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvwBookPublisherList.EditIndex = e.NewEditIndex;

        BindGridView(this.AspNetPager1.CurrentPageIndex);

    }

    #endregion

    #region  当GridView生成Cancel时激发事件

    /// <summary>
    /// 当GridView生成Cancel时激发事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvwBookPublisherList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvwBookPublisherList.EditIndex = -1;

        BindGridView(this.AspNetPager1.CurrentPageIndex);
    }

    #endregion

    #region  点击编辑后点击更新事件

    /// <summary>
    /// 点击编辑后点击更新事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvwBookPublisherList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string lblId = "";
        string txtName = "";
        IList<PublishersInfo> list = GetBookPublisherList(this.AspNetPager1.CurrentPageIndex);
        foreach (PublishersInfo publishersInfo in list)
        {
            //依次判断购物车中哪行处于编辑状态
            if (publishersInfo.Id.ToString().Equals((this.gvwBookPublisherList.Rows[e.RowIndex].FindControl("lblId") as Label).Text))
            {
                //如果当前行处于编辑状态，取值
                lblId = (gvwBookPublisherList.Rows[e.RowIndex].FindControl("lblId") as Label).Text.Trim();
                txtName = (gvwBookPublisherList.Rows[e.RowIndex].FindControl("txtName") as TextBox).Text.Trim();

            }
        }
        if (GetUpdateExist(txtName))         //判断数据库是否存在编辑后的出版社值
        {
            Response.Write("<script>alert('此出版社名称已存在！');</script>");
        }
        else
        {
            UpdatePublisher(lblId, txtName);

        }
        gvwBookPublisherList.EditIndex = -1;

        BindGridView(this.AspNetPager1.CurrentPageIndex);
    }

    #endregion

    #region  出版社编辑时执行判断

    /// <summary>
    /// 出版社编辑时执行判断
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private bool GetUpdateExist(string name)
    {
        return PublisherManager.GetUpdateExist(name);
    }

    #endregion     

    #region  出版社编辑方法

    /// <summary>
    /// 出版社编辑方法
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    private bool UpdatePublisher(string id, string name)
    {
        return PublisherManager.UpdatePublisher(id,name);
    }

    #endregion

             
}