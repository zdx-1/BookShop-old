using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// 会员母版
/// </summary>
public partial class MemberPortal_MainSite : System.Web.UI.MasterPage
{
    /// <summary>
    /// 初始化页面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    

    /// <summary>
    /// 搜索事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string title = txtSearchKeyWord.Text.Trim();
        Response.Redirect("~/MemberPortal/BookLists.aspx?Title="+title);
    }

    /// <summary>
    /// 高级搜索事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdvancedSearch_Click(object sender, EventArgs e)
    {
    }

    
}
