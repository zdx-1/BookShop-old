using BookShop.BLL;
using BookShop.Model;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;


/// <summary>
/// 订单列表浏览
/// </summary>
public partial class AdminPlatform_ShoppingCartList : System.Web.UI.Page
{
    #region 初始化页面

    /// <summary>
    /// 初始化页面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
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
        gvwShoppingCartList.DataSource = GetShoppingCartList(pageindex);
        gvwShoppingCartList.DataBind();
    }

    #endregion

    #region  AspNetPager控件分页数获取方法

    /// <summary>
    /// AspNetPager控件分页数获取方法
    /// </summary>
    /// <returns></returns>
    private int GetAspNetPager_PageCount()
    {
        return OrderManager.GetAspNetPager_PageCount();
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

    #region  初始化用户浏览方法

    /// <summary>
    /// 初始化用户浏览方法
    /// </summary>
    /// <returns></returns>
    private IList<OrdersInfo> GetShoppingCartList(int pageindex)
    {
        return OrderManager.GetShoppingCartList(pageindex);
    }

    #endregion

    #region  实现光棒效果

    /// <summary>
    /// 实现光棒效果
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvwShoppingCartList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)    //指定数据控件行的类型
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#D3D7F5'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
            string userStatesName = (e.Row.FindControl("lblUserStatesName") as Label).Text;
            int userStatesId = GetUserStatesByName(userStatesName);
            if (userStatesId == 2)
            {
                e.Row.Cells[6].ForeColor = System.Drawing.Color.Red;
            }
            if (userStatesId == 1)
            {
                e.Row.Cells[6].ForeColor = System.Drawing.Color.Blue;
            }

            string userRolesName = (e.Row.FindControl("lblUserRolesName") as Label).Text;
            int userRolesId = GetUserRolesName(userRolesName);
            if (userRolesId == 3)
            {
                e.Row.Cells[5].ForeColor = System.Drawing.Color.YellowGreen;
            }
            if (userRolesId == 2)
            {
                e.Row.Cells[5].ForeColor = System.Drawing.Color.Red;
            }
            if (userRolesId == 1)
            {
                e.Row.Cells[5].ForeColor = System.Drawing.Color.Blue;
            }
        }

    }

    #endregion

    #region  显示用户状态颜色转换前的读取状态编号的方法

    /// <summary>
    /// 显示用户状态颜色转换前的读取状态编号的方法
    /// </summary>
    /// <param name="userStatesName">状态名</param>
    /// <returns></returns>
    private int GetUserStatesByName(string name)
    {
        return UserStatesManager.GetUserStatesByName(name);

    }

    #endregion

    #region  显示用户权限颜色转换前的读取状态编号的方法

    /// <summary>
    /// 显示用户权限颜色转换前的读取状态编号的方法
    /// </summary>
    /// <param name="userStatesName">状态名</param>
    /// <returns></returns>
    private int GetUserRolesName(string userRolesName)
    {
        return UserRolesManager.GetUserRolesByName(userRolesName);
    }

    #endregion  
}