using BookShop.DAL;
using BookShop.Model;
using System.Collections.Generic;


namespace BookShop.BLL
{
    public static class CategoryManager
    {
        #region （前台）
        #endregion

        #region 图书分类绑定显示
        /// <summary>
        /// 图书分类绑定显示
        /// </summary>
        /// <returns></returns>
        public static IList<CategoriesInfo> GetAllBookCategory()
        {
            return CategoryService.GetAllBookCategory();
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
            return CategoryService.GetAspNetPager_PageCount();
        }

        #endregion

        #region  初始化图书分类浏览方法

        /// <summary>
        /// 初始化图书分类浏览方法
        /// </summary>
        /// <returns></returns>
        public static IList<CategoriesInfo> GetBookCategoryList(int pageindex)
        {
            return CategoryService.GetBookCategoryList(pageindex);
        }

        #endregion

        #region  图书分类删除方法

        /// <summary>
        /// 图书分类删除方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteBooksCategory(int id)
        {
            bool result = false;
            if (BookService.GetSelectBooks(id))     // 删除前判断图书表内是否已有关联的方法
            {
                result = CategoryService.LogicDeleteBooksCategoryById(id);     // 图书分类逻辑删除方法
            }
            else
            {
                result = CategoryService.DeleteBooksCategoryById(id);     // 图书分类物理删除方法
            }
            return result;
        }

        #endregion

        #region  图书分类添加方法

        /// <summary>
        /// 图书分类添加方法
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool AddBooksCategory(string name)
        {
            bool result = false;
            if (CategoryService.GetAddCategoryExist(name))        //图书分类添加时执行判断是否有值
            {
                result = true;
            }
            else
            {
                CategoryService.AddCategoryById(name);            // 图书分类添加方法
            }
            return result;
        }

        #endregion

        #region  图书分类编辑时执行判断

        /// <summary>
        /// 图书分类编辑时执行判断
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool GetUpdateExist(string name)
        {
            return CategoryService.GetUpdateExist(name);
        }

        #endregion

        #region  图书分类编辑方法

        /// <summary>
        /// 图书分类编辑方法
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool UpdateCategory(string id, string name)
        {
            return CategoryService.UpdateCategory(id,name);
        }

        #endregion
    }
}
