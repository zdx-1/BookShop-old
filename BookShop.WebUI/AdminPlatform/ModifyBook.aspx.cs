using BookShop.BLL;
using BookShop.Model;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;


/// <summary>
/// 图书编辑
/// </summary>
public partial class AdminPlatform_ModifyBook : System.Web.UI.Page
{
    
    static string oldTitle = "";
    static string oldISBN = "";

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
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                int id =Convert.ToInt32(Request.QueryString["Id"].ToString());
                GetModifyBookPageLoadById(id);      //调用getPageLoad方法初始化页面控件属性
            }
            else
            {
                Response.Redirect("BookList.aspx");
            }
        }
    }

    #endregion

    #region 绑定类别DropDownList控件

    /// <summary>
    /// 绑定类别DropDownList控件
    /// </summary>
    private void ddlCategoryBind(string catName, string catId)
    {
        IList<CategoriesInfo> list = CategoryManager.GetAllBookCategory();
        this.ddlCategory.DataTextField = "Name";    //按姓名下拉表框绑定
        this.ddlCategory.DataValueField = "Id";
        this.ddlCategory.DataSource = list;
        this.ddlCategory.DataBind();
        this.ddlCategory.Items.Insert(0, new ListItem(catName, catId));
    }

    #endregion

    #region 绑定出版社DropDownList控件

    /// <summary>
    /// 绑定出版社DropDownList控件
    /// </summary>
    private void ddlPublisherBind(string pubName, string pubId)
    {
        IList<PublishersInfo> list = PublisherManager.GetAllBookPublishers();
        this.ddlPublisher.DataTextField = "Name";    //按姓名下拉表框绑定
        this.ddlPublisher.DataValueField = "Id";
        this.ddlPublisher.DataSource = list;
        this.ddlPublisher.DataBind();
        this.ddlPublisher.Items.Insert(0, new ListItem(pubName, pubId));
    }

    #endregion

    #region 初始化绑定页面类别和出版社DropDownList控件的值，并初始化页面控件属性的方法

    /// <summary>
    /// 初始化绑定页面类别和出版社DropDownList控件的值，并初始化页面控件属性的方法
    /// </summary>
    private void GetModifyBookPageLoadById(int id)
    {
        BooksInfo booksInfo = BookManager.GetModifyBookPageLoadById(id);
        ddlCategoryBind(booksInfo.Categories.Name, booksInfo.Categories.Id.ToString());      //初始化绑定页面类别和出版社DropDownList控件的值
        ddlPublisherBind(booksInfo.Publishers.Name, booksInfo.Publishers.Id.ToString());

        lblId.Text = id.ToString();
        txtTitle.Text = booksInfo.Title;
        txtAuthor.Text = booksInfo.Author;
        txtISBN.Text = booksInfo.ISBN;
        dtbPublishDate.Text = booksInfo.PublishDate.ToString();
        txtUnitPrice.Text = booksInfo.UnitPrice.ToString();
        txtWordsCount.Text = booksInfo.WordsCount.ToString();
        ImgfulImgUrl.ImageUrl = booksInfo.ImgUrl;
        txtContentDescription.Text = booksInfo.ContentDescription;
        txtAuthorDescription.Text = booksInfo.AuthorDescription;
        txtEditorComment.Text = booksInfo.EditorComment;
        txtTOC.Text = booksInfo.TOC;

        oldTitle = booksInfo.Title;           //赋给全局变量
        oldISBN = booksInfo.ISBN;
    }

    #endregion

    #region 上传图片方法

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
                        //OpenFileDialog Open1 = new OpenFileDialog();
                        //ofd.Filter = "图片文件(*)|*.jpg|*.jpeg|*.gif|*.bmp|*.png";

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

    #region  编辑图书Click事件

    /// <summary>
    /// 编辑图书Click事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnOk_Click(object sender, EventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(lblId.Text.Trim());       //从界面控件取值
            string title = txtTitle.Text.Trim();
            string author = txtAuthor.Text.Trim();
            int catId = Convert.ToInt32(ddlCategory.SelectedValue);
            int pubId = Convert.ToInt32(ddlPublisher.SelectedValue);
            string ISBN = txtISBN.Text.Trim();
            DateTime publishDate = Convert.ToDateTime(dtbPublishDate.Text.Trim());
            decimal unitPrice = Convert.ToDecimal(txtUnitPrice.Text.Trim());
            int wordsCount = Convert.ToInt32(txtWordsCount.Text.Trim());
            string contentDescription = txtContentDescription.Text.Trim();

            if (!(title == oldTitle && ISBN == oldISBN))
            {
                if (getSelectTitleOrISBN(title, ISBN))
                {
                    Response.Write("<SCRIPT language='javascript'>alert('图书名称或ISBN已存在！');</SCRIPT>");
                    return;
                }
            }
            string imgUrl = "";

            if (fulImgUrl.HasFile)
            {
                imgUrl = getPut(ISBN);     //上传图片并取图片上传地址
                Response.Write("<SCRIPT language='javascript'>alert('图片上传成功！');</SCRIPT>");
            }
            else
            {
                Response.Write("<SCRIPT language='javascript'>alert('请选择上传图片！');</SCRIPT>");
                return;
                //string fileExtension = System.IO.Path.GetExtension(ImgfulImgUrl.ImageUrl).ToLower();
                //System.IO.File.Move(@""+ImgfulImgUrl.ImageUrl, @"~\MemberPortal\image\BookCovers\" + ISBN + fileExtension);     //指定文件移动到新位置并指定新文件名
                //imgUrl = getPut(ISBN);     //上传图片并取图片上传地址
            }
            //调用getUpdate方法判断执行编辑图书功能是否实现
            if (GetUpdate(id, title, author, catId, pubId, ISBN, publishDate, unitPrice, wordsCount, contentDescription, imgUrl))
            {
                Response.Write("<SCRIPT language='javascript'>alert('编辑成功！'); location.href='BookList.aspx';</SCRIPT>");
            }
        }
        catch
        {
            Response.Redirect("BookList.aspx");
        }
    }

    #endregion

    #region  编辑图书方法

    /// <summary>
    /// 编辑图书方法
    /// </summary>
    /// <param name="id">图书编号</param>
    /// <param name="title">图书名称</param>
    /// <param name="author">编著者</param>
    /// <param name="categoryId">图书类别编号</param>
    /// <param name="publisherId">出版社编号</param>
    /// <param name="ISBN">ISBN</param>
    /// <param name="publishDate">出版时间</param>
    /// <param name="unitPrice">单价</param>
    /// <param name="wordsCount">字数</param>
    /// <param name="contentDescription">内容摘要</param>
    /// <param name="imgUrl">上传图片地址</param>
    /// <returns>返回bool类型判断编辑是否成功</returns>
    private bool GetUpdate(int id, string title, string author, int categoryId, int publisherId, string ISBN, DateTime publishDate, decimal unitPrice, int wordsCount, string contentDescription, string imgUrl)
    {
        return BookManager.GetUpdate(id, title, author, categoryId, publisherId, ISBN, publishDate, unitPrice, wordsCount, contentDescription, imgUrl);
    }

    #endregion

    #region  判断图书名称或ISBN是否已存在

    /// <summary>
    /// 判断图书名称或ISBN是否已存在
    /// </summary>
    /// <param name="title">图书名称</param>
    /// <param name="ISBN">ISBN</param>
    /// <returns></returns>
    private bool getSelectTitleOrISBN(string title, string ISBN)
    {
        return BookManager.GetSelectTitleOrISBN(title,ISBN);
    }

    #endregion
}