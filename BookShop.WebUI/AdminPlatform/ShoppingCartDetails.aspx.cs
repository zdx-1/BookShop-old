using BookShop.BLL;
using BookShop.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;


/// <summary>
/// 订单详细
/// </summary>
public partial class AdminPlatform_ShoppingCartDetails : System.Web.UI.Page
{          
    double totalNumbers = 0;
    double totalPrices = 0;

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
            if (!string.IsNullOrEmpty(Request.QueryString["OrdersId"]))
            {
                AspNetPager1.RecordCount = GetAspNetPager_PageCount(Convert.ToInt32(Request.QueryString["OrdersId"]));
                dlsBook.DataSource = GetOrdersPageLoad(Convert.ToInt32(Request.QueryString["OrdersId"]));  //调用GetPageLoad方法初始化订单基本信息浏览     
                dlsBook.DataBind();
                BindGridView(1);
            }
            else
            {
                Response.Redirect("ShoppingCartList.aspx");
            }
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
        gvwOrdersBook.DataSource = GetOrderBooksPageLoad(Convert.ToInt32(Request.QueryString["OrdersId"]), pageindex);
        gvwOrdersBook.DataBind();
    }

    #endregion

    #region  AspNetPager控件分页数获取方法

    /// <summary>
    /// AspNetPager控件分页数获取方法
    /// </summary>
    /// <returns></returns>
    private int GetAspNetPager_PageCount(int ordersId)
    {
        return OrderBookManager.GetAspNetPager_PageCount(ordersId);
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

    #region  初始化订单基本信息浏览

    /// <summary>
    /// 初始化订单基本信息浏览
    /// </summary>
    /// <param name="ordersId"></param>
    /// <returns></returns>
    private DataTable GetOrdersPageLoad(int ordersId)
    {
        return OrderManager.GetOrdersPageLoad(ordersId);
    }

    #endregion

    #region  初始化订单详细信息浏览

    /// <summary>
    /// 初始化订单详细信息浏览
    /// </summary>
    /// <param name="ordersId"></param>
    /// <returns></returns>
    private IList<OrderBooksInfo> GetOrderBooksPageLoad(int ordersId, int pageindex)
    {
        return OrderBookManager.GetOrderBooksPageLoad(ordersId,pageindex);
    }

    #endregion

    #region  实现光棒效果

    /// <summary>
    /// 实现光棒效果
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvwOrdersBook_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)    //指定数据控件行的类型
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#D4D8F6'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
        }
        if (e.Row.RowIndex >= 0)
        {
            (e.Row.FindControl("lblPrices") as Label).Text = (Convert.ToDouble((e.Row.FindControl("lblQuantity") as Label).Text) * Convert.ToDouble((e.Row.FindControl("lblOrderBooksUnitPrice") as Label).Text)).ToString();
            totalNumbers += Convert.ToDouble((e.Row.FindControl("lblQuantity") as Label).Text);
            totalPrices += Convert.ToDouble((e.Row.FindControl("lblPrices") as Label).Text);
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotalNumber = e.Row.FindControl("lblTotalNumber") as Label;
            Label lblTotalPrice = e.Row.FindControl("lblTotalPrice") as Label;
            lblTotalNumber.Text = totalNumbers.ToString();
            lblTotalPrice.Text = totalPrices.ToString();
            e.Row.Cells[1].Text = "总计：";
            //e.Row.Cells[3].Text = totalNumbers.ToString();
            //e.Row.Cells[4].Text = TotalPrices.ToString();

        }
    }

    #endregion
}