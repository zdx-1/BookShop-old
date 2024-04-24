using System;
using System.Collections.Generic;
using BookShop.DAL;
using BookShop.Model;

namespace BookShop.BLL
{
    public static class BookManager
    {
        #region 前台
        #endregion

        #region 最热图书获取前4本信息
        /// <summary>
        /// 最热图书获取前4本信息
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public static List<BooksInfo> GetHotSellBookList()
        {
            return BookService.GetHotSellBookList();
        }

        #endregion

        #region  编辑推荐图书获取1本信息

        /// <summary>
        /// 编辑推荐图书获取1本信息
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public static List<BooksInfo> GetEditorRecommendBooksList()
        {
            return BookService.GetEditorRecommendBooksList();
        }

        #endregion

        #region  最新图书获取8本信息

        /// <summary>
        /// 最新图书获取8本信息
        /// </summary>
        /// <returns>返回List</returns>
        public static List<BooksInfo> GetNewBooksList()
        {
            return BookService.GetNewBooksList();
        }

        #endregion

        #region 点击率排行榜前10位图书信息

        /// <summary>
        /// 点击率排行榜前10位图书信息
        /// </summary>
        /// <returns></returns>
        public static List<BooksInfo> GetClicks()
        {
            return BookService.GetClicks();
        }

        #endregion

        #region  AspNetPager控件分页数获取方法（图书浏览页）

        /// <summary>
        /// AspNetPager控件分页数获取方法（图书浏览页）
        /// </summary>
        /// <returns></returns>
        public static int GetAspNetPager_PageCount(string logicId, string whereName, int x)
        {
            int result = 0;
            if (x == 0)    //x为0时说明浏览所有图书页数获取方法
            {
                result = BookService.GetAspNetPager_PageCount(logicId, whereName, x);
            }
            else if (x == 1)    //x为1时说明所接收参数logicId是图书分类编号
            {
                result = BookService.GetAspNetPager_PageCount1(logicId, whereName, x);
            }
            else if (x == 2)    //x为2时说明所接收参数logicId是出版社编号
            {
                result = BookService.GetAspNetPager_PageCount2(logicId, whereName, x);
            }
            else if (x == 3)    //x为3时说明所接收参数logicId是搜索编号
            {
                result = BookService.GetAspNetPager_PageCount3(logicId, whereName, x);
            }
            return result;
        }

        #endregion

        #region 浏览图书信息（图书浏览页）

        /// <summary>
        /// 浏览图书绑定到DataList控件dlsBook上显示
        /// </summary>
        /// <param name="logicId">所取参数Id，可取的有：CatId、PubId,没有指定默认为string类型："0"字符</param>
        /// <param name="whereName">指定按什么方式排序，不排序为string类型："0"字符</param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static IList<BooksInfo> GetBookList(int pageindex, string logicId, string whereName, int x)
        {
            if (x == 0)    //x为0时说明浏览所有图书页数获取方法
            {
                return BookService.GetBookList(pageindex,logicId, whereName, x);
            }
            else if (x == 1)    //x为1时说明所接收参数logicId是图书分类编号
            {
                return BookService.GetBookList1(pageindex, logicId, whereName, x);
            }
            else if (x == 2)    //x为2时说明所接收参数logicId是出版社编号
            {
                return BookService.GetBookList2(pageindex, logicId, whereName, x);
            }
            else if (x == 3)    //x为3时说明所接收参数logicId是搜索编号
            {
                return BookService.GetBookList3(pageindex, logicId, whereName, x);
            }
            else
            {
                return BookService.GetBookList(pageindex, logicId, whereName, x);
            }
        }  

        #endregion

        #region 点击某一本图书点击率加1方法

        /// <summary>
        /// 点击某一本图书点击率加1方法
        /// </summary>
        /// <param name="bookId"></param>
        public static void AddBookClick(int bookId)
        {
            BookService.AddBookClick(bookId);
        }

        #endregion

        #region  图书详细信息浏览（图书详细页）

        /// <summary>
        /// 图书详细信息浏览（图书详细页）
        /// </summary>
        /// <returns></returns>
        public static IList<BooksInfo> GetBookDetails(int bookId)
        {
            return BookService.GetBookDetails(bookId);
        }

        #endregion

        #region 后台
        #endregion

        #region  AspNetPager控件分页数获取方法  （后台图书浏览页）

        /// <summary>
        /// AspNetPager控件分页数获取方法 （后台图书浏览页）
        /// </summary>
        /// <returns></returns>
        public static int GetAdminAspNetPager_PageCount(int ddlCategorySelectedValue)
        {
            if (ddlCategorySelectedValue == -1)
            {
                return BookService.GetAdminAspNetPager_PageCount();
            }
            else
            {
                return BookService.GetAdminAspNetPager_PageCount(ddlCategorySelectedValue);
            }
        }

        #endregion

        #region  初始化图书浏览方法

        /// <param name="sender"></param>
        /// 按图书分类图书浏览方法
        /// </summary>
        /// <returns></returns>
        public static IList<BooksInfo> GetAdminBookList(int catId, int pageindex)
        {
            if (catId == -1)
            {
                return BookService.GetAdminBookList(pageindex);
            }
            else
            {
                return BookService.GetAdminBookList(catId,pageindex);
            }
        }

        #endregion

        #region  图书删除方法

        /// <summary>
        /// 图书删除方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteBooks(int id)
        {
            bool result = false;
            if (OrderBookService.GetSelectBooks(id))     // 删除前判断订单表内是否已有关联的方法
            {
                result = BookService.LogicDeleteBooksById(id);     // 图书分类逻辑删除方法
            }
            else
            {
                result = BookService.DeleteBooksById(id);     // 图书分类物理删除方法
            }
            return result;
        }

        #endregion

        #region  新增图书方法

        /// <summary>
        /// 新增图书方法
        /// </summary>
        /// <param name="title">图书名称</param>
        /// <param name="author">编著者</param>
        /// <param name="publisherId">出版社编号</param>
        /// <param name="publishDate">出版时间</param>
        /// <param name="ISBN">ISBN</param>
        /// <param name="wordsCount">字数</param>
        /// <param name="unitPrice">单价</param>
        /// <param name="contentDescription">内容摘要</param>
        /// <param name="authorDescription">作者简介</param>
        /// <param name="editorComment">编辑推荐</param>
        /// <param name="TOC">目录</param>
        /// <param name="categoryId">图书类别</param>
        /// <param name="imgUrl">上传图片地址</param>
        /// <returns>返回bool类型判断添加是否成功</returns>
        public static bool GetInsert(string title, string author, int publisherId, DateTime publishDate, string ISBN, int wordsCount, Decimal unitPrice, string contentDescription, string authorDescription, string editorComment, string TOC, int categoryId, string imgUrl)
        {
            return BookService.GetInsert(title, author, publisherId, publishDate, ISBN, wordsCount, unitPrice, contentDescription, authorDescription, editorComment, TOC, categoryId, imgUrl);
        }

        #endregion

        #region  判断图书名称或ISBN是否已存在

        /// <summary>
        /// 判断图书名称或ISBN是否已存在
        /// </summary>
        /// <param name="title">图书名称</param>
        /// <param name="ISBN">ISBN</param>
        /// <returns></returns>
        public static bool GetSelectTitleOrISBN(string title, string ISBN)
        {
            return BookService.GetSelectTitleOrISBN(title,ISBN); 
        }

        #endregion

        #region 初始化绑定页面类别和出版社DropDownList控件的值，并初始化页面控件属性的方法

        /// <summary>
        /// 初始化绑定页面类别和出版社DropDownList控件的值，并初始化页面控件属性的方法
        /// </summary>
        public static BooksInfo GetModifyBookPageLoadById(int id)
        {
            return BookService.GetModifyBookPageLoadById(id);
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
        public static bool GetUpdate(int id, string title, string author, int categoryId, int publisherId, string ISBN, DateTime publishDate, decimal unitPrice, int wordsCount, string contentDescription, string imgUrl)
        {
            return BookService.GetUpdate(id, title, author, categoryId, publisherId, ISBN, publishDate, unitPrice, wordsCount, contentDescription, imgUrl);
        }

        #endregion

    }
}
