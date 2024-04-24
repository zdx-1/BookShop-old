using System;
using System.Web;
using System.Web.UI.WebControls;
using BookShop.BLL;
using BookShop.Model;

/// <summary>
///  我的购物车
/// </summary>
public partial class MemberPortal_ShoppingCart : System.Web.UI.Page
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
            HttpCookie cookieLogin = Request.Cookies["loginUserInfo"];
            if (cookieLogin != null)
            {
                if (Session["Cart"] != null)
                {
                    //“购物车”不为空，则将其作为数据源绑定到GridView
                    bindCart();   //该方法另定义，从Session中取购物车并绑定
                }
                else
                {
                    lblShowNon.Text = "目前您还没有购买任何图书！";
                }
            }
            else
            {
                Response.Write("<script language=javascript>alert('还未登录，请登录！');location.href='UserLogin.aspx';</script>");
            }
        }
    }

    #endregion

    #region 购物车绑定

    /// <summary>
    /// 购物车绑定
    /// </summary>
    private void bindCart()
    {
        CartInfo cart = CartManager.BuildCart();
        cart = Session["Cart"] as CartInfo;
        gvwCart.DataSource = cart.Items;
        gvwCart.DataBind();
    }

    #endregion

    #region  实现光棒效果与总计显示

    /// <summary>
    /// 实现光棒效果
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvwCart_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)    //指定数据控件行的类型
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#D4D8F6'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
        }
        if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
        {
            if (e.Row.RowIndex >= 0)
            {
                (e.Row.FindControl("lblPrices") as Label).Text = (Convert.ToDouble((e.Row.FindControl("lblNumber") as Label).Text) * Convert.ToDouble((e.Row.FindControl("lblUnitPrice") as Label).Text)).ToString();
                totalNumbers += Convert.ToDouble((e.Row.FindControl("lblNumber") as Label).Text);
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
    }

    #endregion

    #region  分页导航按钮单击处理

    /// <summary>
    /// 分页导航按钮单击处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvwCart_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //refer to the GridView       
        int newPageIndex = 0;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            //GridViewRow pagerRow = gvwCart.Controls[0].Controls[gvwCart.Controls[0].Controls.Count - 1] as GridViewRow; // refer to PagerTemplate  
            GridViewRow pagerRow = gvwCart.BottomPagerRow; //GridView较DataGrid提供了更多的API，获取分页块可以使用BottomPagerRow 或者TopPagerRow，当然还增加了HeaderRow和FooterRow               
            if (null != pagerRow)
            {
                txtNewPageIndex = pagerRow.FindControl("txtNewPageIndex") as TextBox;   // refer to the TextBox with the NewPageIndex value       
            }
            if (null != txtNewPageIndex)
            {
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1; // get the NewPageIndex    
            }
        }
        else
        {
            // when click the first, last, previous and next Button        
            newPageIndex = e.NewPageIndex;
        }
        //// check to prevent form the NewPageIndex out of the range   
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        if (newPageIndex >= gvwCart.PageCount)
        {
            newPageIndex = gvwCart.PageCount - 1;
        }
        // specify the NewPageIndex      
        gvwCart.PageIndex = newPageIndex;

        bindCart();
    }

    #endregion

    #region GO分页跳转Click事件

    /// <summary>
    /// GO分页跳转Click事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGo_Click(object sender, EventArgs e)
    {
        //获取GridView中文本控件
        TextBox txtPageNum = gvwCart.BottomPagerRow.FindControl("txtNewPageIndex") as TextBox;
        //页码序号为0......n
        int newPageIndex = gvwCart.PageIndex;
        int a = 0;
        if (int.TryParse(txtPageNum.Text.Trim(), out a))
        {
            newPageIndex = Convert.ToInt32(txtPageNum.Text.Trim()) - 1;
            newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        }
        gvwCart.PageIndex = newPageIndex;
        bindCart();
    }

    #endregion

    #region  编辑事件

    /// <summary>
    /// 设置编辑项索引为当前编辑项的行
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvwCart_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvwCart.EditIndex = e.NewEditIndex;
        bindCart();
    }

    protected void gvwCart_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvwCart.EditIndex = -1;
        bindCart();
    }

    /// <summary>
    /// 点击编辑后更新按钮执行事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvwCart_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int number = 0;
        string imgImgUrl="";
        CartInfo cart = CartManager.BuildCart();
        cart = Session["Cart"] as CartInfo;
        foreach (CartItemInfo item in cart.Items)
        {
            string title = item.Book.Title.ToString().Length > 20 ? item.Book.Title.ToString().Substring(0, 20) + "..." : item.Book.Title.ToString();
            //依次判断购物车中哪行处于编辑状态
            if (title.Equals((gvwCart.Rows[e.RowIndex].FindControl("lblTitle") as Label).Text))
            {
                //如果当前行处于编辑状态，则获取用户输入的商品数量
                imgImgUrl = (gvwCart.Rows[e.RowIndex].FindControl("ImgImgUrl") as Image).ImageUrl.Trim();
                number= Convert.ToInt32((gvwCart.Rows[e.RowIndex].FindControl("txtNumber") as TextBox).Text.Trim());
            }
        }
        cart = CartManager.UpdateBooks(cart, imgImgUrl, number);
        //将购物车保存到Session中
        Session["Cart"] = cart;
        gvwCart.EditIndex = -1;
        bindCart();

    }

    #endregion

    #region  点击删除时执行事件

    /// <summary>
    /// 点击删除时执行事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvwCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        CartInfo cart = CartManager.BuildCart();
        cart = Session["Cart"] as CartInfo;
        Session["Cart"] = CartManager.DeleteBook(cart,cart.Items[e.RowIndex].Book.Id);
        cart = Session["Cart"] as CartInfo;
        if (cart.Items.Count <= 0)
        {
            Session["Cart"] = "";
        }
        bindCart();
    }

    #endregion

    #region  结算Click事件

    /// <summary>
    /// 结算Click事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnSettlement_Click(object sender, EventArgs e)
    {
        if (Session["Cart"] == null || Session["Cart"] == "")
        {
            Session["Cart"] = null;
            return;
        }
        HttpCookie cookieLogin = Request.Cookies["loginUserInfo"];  //获取cookie
        string loginId = cookieLogin.Values["loginId"];
        int userId = GetUsersId(loginId);   //用cookie给页面控件赋值
        DateTime orderDate = DateTime.Now;
        CartInfo cart = CartManager.BuildCart();
        cart = Session["Cart"] as CartInfo;
        if (GetAddOrders(orderDate, userId, cart.TotalPrice))
        {
            int orderId = GetExistAddOrder(userId, cart.TotalPrice);           // 调用GetExistAddOrder方法获取刚添加订单表Oders表内记录的主键

            for (int i = 0; i <= cart.Items.Count - 1; i++)
            {
                CartItemInfo item = cart.Items[i];
                int bookId =item.Book.Id;
                int number =item.Quantity;
                decimal unitPrice = item.Book.UnitPrice;
                GetAddOrderBooks(orderId, bookId, number, unitPrice);            // 调用GetAddOrderBooks方法OrderBooks表添加记录
            }
            Session["Cart"] =null;
            Response.Redirect("Settlement.aspx?Clear=112");
        }  
    }

    #endregion

    #region  点击结算OrderBooks表添加记录的方法

    /// <summary>
    /// 点击结算OrderBooks表添加记录的方法
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="bookId"></param>
    /// <param name="number"></param>
    /// <param name="unitPrice"></param>
    private int GetAddOrderBooks(int orderId, int bookId, int number, decimal unitPrice)
    {
        return OrderBookManager.GetAddOrderBooks(orderId, bookId, number, unitPrice);
    }

    #endregion

    #region  获取Users表内个人的主键的方法

    /// <summary>
    /// 获取Users表内个人的主键的方法
    /// </summary>
    /// <param name="orderDate"></param>
    /// <param name="userId"></param>
    /// <param name="TotalPrices"></param>
    /// <returns></returns>
    private int GetUsersId(string loginId)
    {
        return UserManager.GetUsersId(loginId);
    }

    #endregion

    #region  获取刚添加订单表Oders表内记录的主键的方法

    /// <summary>
    /// 获取刚添加订单表Oders表内记录的主键的方法
    /// </summary>
    /// <param name="orderDate"></param>
    /// <param name="userId"></param>
    /// <param name="TotalPrices"></param>
    /// <returns></returns>
    private int GetExistAddOrder(int userId, decimal TotalPrices)
    {
        return OrderManager.GetExistAddOrder(userId, TotalPrices);
    }

    #endregion

    #region  对订单表Orders表添加记录方法

    /// <summary>
    /// 对订单表Orders表添加记录方法
    /// </summary>
    /// <param name="orderDate">添加时间</param>
    /// <param name="userId">用户编号</param>
    /// <param name="TotalPrices">订单总价格</param>
    /// <returns></returns>
    private bool GetAddOrders(DateTime orderDate, int userId, decimal TotalPrices)
    {
        return OrderManager.GetAddOrders(orderDate, userId, TotalPrices);
    }

    #endregion
}