
using BookShop.BLL;
using BookShop.Model;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;


/// <summary>
/// 新增图书
/// </summary>
public partial class AdminPlatform_AddNewBook : System.Web.UI.Page
{
    #region 初始化页面

    /// <summary>
    /// 初始化页面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)   //首次次加载
        {
            ddlCategoryBind();      //初始化绑定页面类别和出版社DropDownList控件的值
            ddlPublisherBind();
        }
    }

    #endregion

    #region 新增图书Click事件

    /// <summary>
    /// 新增图书Click事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (this.ddlPublisher.SelectedValue == "===选择出版社===" || this.ddlCategory.SelectedValue == "===选择类别===")  //判断DropDownList控件是否选择
        {
            Response.Write("<SCRIPT language='javascript'>alert('出版社或图书类别未选！');</SCRIPT>");
            return;
        }
        try
        {
            if (Session["Ok"] != null)
            {
                if (Session["Ok"].ToString() == "2")
                {
                    Response.Write("<SCRIPT language='javascript'>alert('此页面过期，正跳转图书浏览....！'); location.href='BookList.aspx';</SCRIPT>");
                    return;
                }
            }
            string title = txtTitle.Text;       //从界面控件取值
            string author = txtAuthor.Text;
            int publisherId = Convert.ToInt32(ddlPublisher.SelectedValue);
            DateTime publishDate = Convert.ToDateTime(dtbPublishDate.Text);
            string ISBN = txtISBN.Text;
            int wordsCount = Convert.ToInt32(txtWordsCount.Text);
            decimal unitPrice = Convert.ToDecimal(txtUnitPrice.Text);
            string contentDescription = txtContentDescription.Text;
            string authorDescription = txtAuthorDescription.Text;
            string editorComment = txtEditorComment.Text;
            string TOC = txtTOC.Text;
            int categoryId = Convert.ToInt32(ddlCategory.SelectedValue);


            if (GetSelectTitleOrISBN(title, ISBN))      //调用getSelectTitleOrISBN方法判断图书名称与ISBN是否存在
            {
                Response.Write("<SCRIPT language='javascript'>alert('图书名称或ISBN已存在！');</SCRIPT>");
                return;
            }

            string imgUrl = "";

            if (fulImgUrl.HasFile)
            {
                getPut(ISBN);     //上传图片并取图片上传地址
                Response.Write("<SCRIPT language='javascript'>alert('图片上传成功！');</SCRIPT>");
            }
            else
            {
                Response.Write("<SCRIPT language='javascript'>alert('请选择要上传的图片！');</SCRIPT>");
                return;
            }
            //调用getInsert方法判断执行添加图书功能是否实现
            if (GetInsert(title, author, publisherId, publishDate, ISBN, wordsCount, unitPrice, contentDescription, authorDescription, editorComment, TOC, categoryId, imgUrl))
            {
                Session["Ok"] = "2";
                Response.Write("<SCRIPT language='javascript'>alert('添加成功！'); location.href='BookList.aspx';</SCRIPT>");
            }

        }
        catch
        {
            Server.Transfer("../ErrorPage.aspx");
        }
    }

    #endregion

    #region 绑定类别DropDownList控件

    /// <summary>
    /// 绑定类别DropDownList控件
    /// </summary>
    private void ddlCategoryBind()
    {
        IList<CategoriesInfo> list = CategoryManager.GetAllBookCategory();
        this.ddlCategory.DataTextField = "Name";    //按姓名下拉表框绑定
        this.ddlCategory.DataValueField = "Id";
        this.ddlCategory.DataSource = list;
        this.ddlCategory.DataBind();
        this.ddlCategory.Items.Insert(0, new ListItem("===选择类别==="));
    }

    #endregion

    #region  绑定出版社DropDownList控件

    /// <summary>
    /// 绑定出版社DropDownList控件
    /// </summary>
    private void ddlPublisherBind()
    {
        IList<PublishersInfo> list = PublisherManager.GetAllBookPublishers();
        this.ddlPublisher.DataTextField = "Name";    //按姓名下拉表框绑定
        this.ddlPublisher.DataValueField = "Id";
        this.ddlPublisher.DataSource = list;
        this.ddlPublisher.DataBind();
        this.ddlPublisher.Items.Insert(0, new ListItem("===选择出版社==="));
    }

    #endregion

    #region  上传图片方法

    /// <summary>
    /// 上传图片方法
    /// </summary>
    private string getPut(string ISBN)
    {
        bool fileOk = false;
        string imgUrl = "";
        if (fulImgUrl.HasFile)  //判断是否包含文件
        {
            if (fulImgUrl.PostedFile.ContentLength < 10485760)      //判断文件是否小于10Mb
            {
                try
                {
                    string fileExtension = System.IO.Path.GetExtension(fulImgUrl.FileName).ToLower();
                    string[] allowedExtension = { ".gif", ".png", ".jpeg", ".jpg", ".bmp" };
                    for (int i = 0; i < allowedExtension.Length; i++)
                    {
                        if (fileExtension == allowedExtension[i])
                        {
                            fileOk = true;
                        }
                    }
                    if (fileOk)
                    {
                        //System.IO.File.Move(@"d:\a.png", @"d:\b.png");     //指定文件移动到新位置并指定新文件名
                        fulImgUrl.PostedFile.SaveAs(Server.MapPath("~/MemberPortal/image/BookCovers/" + ISBN + fileExtension));   //上传文件并指定上传目录的路径
                        /*注意->这里为什么不是:FileUpLoad1.PostedFile.FileName
                            而是:FileUpLoad1.FileName? 
                            前者是获得客户端完整限定(客户端完整路径)名称
                            后者FileUpLoad1.FileName只获得文件名.
                        */
                        //上传语句也可以这样写:
                        //FileUpLoad1.SaveAs(@"D:\"+FileUpLoad1.FileName);
                        imgUrl = "~/MemberPortal/image/BookCovers/" + ISBN + fileExtension;

                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('请上传jpg、jpeg、gif、bmp、png格式');</script>");
                    }

                }
                catch
                {
                    Response.Redirect("../ErrorPage.aspx");
                    //lblMessage.Text += ex.Message;
                }
            }
            else
            {
                Response.Write("<SCRIPT language='javascript'>alert('上传文件不能大于10MB!！'); location.href='AddNewBook.aspx'</SCRIPT>");
            }
        }
        return imgUrl;
    }

    #endregion

    #region  新增图书方法

    /// <summary>
    /// 新增图书方法
    /// </summary>
    /// <returns>返回bool类型判断添加是否成功</returns>
    private bool GetInsert(string title, string author, int publisherId, DateTime publishDate, string ISBN, int wordsCount, Decimal unitPrice, string contentDescription, string authorDescription, string editorComment, string TOC, int categoryId, string imgUrl)
    {
        return BookManager.GetInsert(title, author, publisherId, publishDate, ISBN, wordsCount, unitPrice, contentDescription, authorDescription, editorComment, TOC, categoryId, imgUrl);
    }

    #endregion

    #region  判断图书名称或ISBN是否已存在

    /// <summary>
    /// 判断图书名称或ISBN是否已存在
    /// </summary>
    /// <param name="title">图书名称</param>
    /// <param name="ISBN">ISBN</param>
    /// <returns></returns>
    private bool GetSelectTitleOrISBN(string title, string ISBN)
    {
        return BookManager.GetSelectTitleOrISBN(title,ISBN);
    }

    #endregion
}