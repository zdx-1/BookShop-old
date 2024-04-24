using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;
using BookShop.Model;
using Great.Core;

/// <summary>
/// 用户浏览
/// </summary>
public partial class AdminPlatform_UserList : System.Web.UI.Page
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
        gvwUserList.DataSource = GetUserList(pageindex);
        gvwUserList.DataBind();
    }

    #endregion

    #region  AspNetPager控件分页数获取方法

    /// <summary>
    /// AspNetPager控件分页数获取方法
    /// </summary>
    /// <returns></returns>
    private int GetAspNetPager_PageCount()
    {
        return UserManager.GetAspNetPager_PageCount();
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
    private IList<UsersInfo> GetUserList(int pageindex)
    {
        return UserManager.GetUserList(pageindex);
    }

    #endregion

    #region  实现光棒效果

    /// <summary>
    /// 实现光棒效果
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvwUserList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)    //指定数据控件行的类型
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#D3D7F5'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
            string userStatesName = (e.Row.FindControl("lblUserStatesName") as Label).Text;
            int userStatesId = GetUserStatesByName(userStatesName);
            if (userStatesId == 2)
            {
                e.Row.Cells[8].ForeColor = System.Drawing.Color.Red;
            }
            if (userStatesId == 1)
            {
                e.Row.Cells[8].ForeColor = System.Drawing.Color.Blue;
            }

            string userRolesName = (e.Row.FindControl("lblUserRolesName") as Label).Text;
            int userRolesId = GetUserRolesName(userRolesName);
            if (userRolesId == 3)
            {
                e.Row.Cells[7].ForeColor = System.Drawing.Color.YellowGreen;
            }
            if (userRolesId == 2)
            {
                e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;
            }
            if (userRolesId == 1)
            {
                e.Row.Cells[7].ForeColor = System.Drawing.Color.Blue;
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

    #region  事件RowCommand：执行命令，删除或编辑用户信息

    /// <summary>
    /// 事件RowCommand：执行命令，删除或编辑用户信息
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void gvwUserList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteUser")
        {
            if (DeleteUsersById(e.CommandArgument.ToString()))  //调用DeleteBooksById方法删除图书
            {
                WindowHelper.Alert("删除成功！", this);
            }
            //调用绑定分页和GridView    
            BindGridView(this.AspNetPager1.CurrentPageIndex);
        }
        if (e.CommandName == "UpdateUser")
        {
            UpdateUsersById(Convert.ToInt32(e.CommandArgument));  //调用UpdateUsersById方法编辑

            //调用绑定分页和GridView    
            BindGridView(this.AspNetPager1.CurrentPageIndex);
        }
    }

    #endregion

    #region  用户删除方法

    /// <summary>
    /// 用户删除方法
    /// </summary>
    /// <param name="id"></param>
    private bool DeleteUsersById(string id)
    {
        return UserManager.DeleteUsersById(id);
    }

    #endregion

    #region  用户编辑方法

    /// <summary>
    /// 用户编辑方法
    /// </summary>
    /// <param name="id"></param>
    private bool UpdateUsersById(int id)
    {
        return UserManager.UpdateUsersById(id);
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
        for (int i = 0; i <= gvwUserList.Rows.Count - 1; i++)
        {
            CheckBox chkSel = (CheckBox)gvwUserList.Rows[i].FindControl("chkSelect");
            chkSel.Checked = chkSelectAll.Checked;
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
        string imessage = "-1";
        for (int i = 0; i <= gvwUserList.Rows.Count - 1; i++)
        {
            CheckBox chkSel = (CheckBox)gvwUserList.Rows[i].FindControl("chkSelect");
            if (chkSel.Checked == true)
            {
                int selId = (int)gvwUserList.DataKeys[i].Value;
                imessage = imessage + "," + selId.ToString();
            }
        }
        DeleteUsersById(imessage);
        //调用绑定分页和GridView    
        BindGridView(this.AspNetPager1.CurrentPageIndex);
    }

    #endregion

}
    