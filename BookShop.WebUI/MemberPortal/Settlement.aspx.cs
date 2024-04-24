using System;
using System.Web;
using BookShop.BLL;
using BookShop.Model;

/// <summary>
/// 购买图书流程过渡页
/// </summary>
public partial class MemberPortal_Settlement : System.Web.UI.Page
{
    #region   初始化页面

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
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    Panel1.Visible = true;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    BuyBook(Convert.ToInt32(Request.QueryString["Id"]));
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["Clear"]))
                {
                    Panel1.Visible = false;
                    Panel2.Visible = true;
                    Panel3.Visible = false;
                }
                else
                {
                    Response.Redirect("BookLists.aspx");
                }
            }
            else
            {
                Response.Write("<script language=javascript>alert('还未登录，请登录！');location.href='UserLogin.aspx';</script>");
            }
        }
    }

    #endregion

    #region   初始化页面时图书加入购物车的方法

    /// <summary>
    /// 初始化页面时图书加入购物车的方法
    /// </summary>
    /// <param name="id"></param>
    private void BuyBook(int id)
    {
        CartInfo cart = CartManager.BuildCart();
        if (Session["Ok"] != "1")
        {
            if (Session["Cart"] != null)
            {
                //如存在，则从Session中取出购物车
                cart = Session["Cart"] as CartInfo;
            }

            //购买图书
            cart= CartManager.BuyBook(cart,id);
            //保存购物车
            Session["Cart"] = cart;
            Session["Ok"] = "1";
        }
        else
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = true;
        }

    }

    #endregion

    #region 页面跳转

    protected void lbtnShopping_Click(object sender, EventArgs e)
    {
        Response.Redirect("BookDetails.aspx?BookId=" + Request.QueryString["Id"]);
    }

    protected void lbtnCart_Click(object sender, EventArgs e)
    {
        Response.Redirect("ShoppingCart.aspx");
    }

    #endregion
}