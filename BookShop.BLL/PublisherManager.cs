using BookShop.DAL;
using BookShop.Model;
using System.Collections.Generic;


namespace BookShop.BLL
{
    public static class PublisherManager
    {
        #region 前台
        #endregion

        #region  出版社前10绑定显示

        /// <summary>
        /// 出版社前10绑定显示
        /// </summary>
        /// <returns></returns>
        public static List<PublishersInfo> GetTopBookPublishers()
        {
            return PublisherService.GetTopBookPublishers();
        }

        #endregion

        #region 后台
        #endregion

        #region  AspNetPager控件分页数获取方法 （图书分类浏览）

        /// <summary>
        /// AspNetPager控件分页数获取方法
        /// </summary>
        /// <returns></returns>
        public static int GetAspNetPager_PageCount()
        {
            return PublisherService.GetAspNetPager_PageCount();
        }

        #endregion

        #region  初始化出版社浏览方法

        /// <summary>
        /// 初始化出版社浏览方法
        /// </summary>
        /// <returns></returns>
        public static IList<PublishersInfo> GetBookPublisherList(int pageindex)
        {
            return PublisherService.GetBookPublisherList(pageindex);
        }

        #endregion

        #region  出版社删除方法

        /// <summary>
        /// 出版社删除方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteBooksPublisher(int id)
        {
            bool result = false;
            if (BookService.GetSelectBooksByPublisherId(id))     // 删除前判断出版社表内是否已有关联的方法
            {
                result = PublisherService.LogicDeleteBooksPublisherById(id);     // 出版社逻辑删除方法
            }
            else
            {
                result = PublisherService.DeleteBooksPublisherById(id); ;     // 出版社物理删除方法
            }
            return result;
        }

        #endregion

        #region  出版社添加方法

        /// <summary>
        /// 出版社添加方法
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool AddPublisher(string name)
        {
            bool result = false;
            if (PublisherService.GetAddPublisherExist(name))        //图书分类添加时执行判断是否有值
            {
                result = true;
            }
            else
            {
                PublisherService.AddPublisher(name);            // 图书分类添加方法
            }
            return result;
        }

        #endregion

        #region  出版社编辑时执行判断

        /// <summary>
        /// 出版社编辑时执行判断
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool GetUpdateExist(string name)
        {
            return PublisherService.GetUpdateExist(name);
        }

        #endregion

        #region  出版社编辑方法

        /// <summary>
        /// 出版社编辑方法
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool UpdatePublisher(string id, string name)
        {
            return PublisherService.UpdatePublisher(id, name);
        }

        #endregion

        #region 出版社绑定显示

        /// <summary>
        /// 出版社绑定显示
        /// </summary>
        /// <returns></returns>
        public static List<PublishersInfo> GetAllBookPublishers()
        {
            return PublisherService.GetAllBookPublishers();
        }

        #endregion
    }
}
