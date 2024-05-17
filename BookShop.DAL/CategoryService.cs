using BookShop.Common.DB;
using BookShop.Model;
using System;
using System.Collections.Generic;
using System.Data;



namespace BookShop.DAL
{
    public static class CategoryService
    {

        #region （前台）
        #endregion
        //已确认
        #region 图书分类绑定显示

        /// <summary>
        /// 图书分类绑定显示    
        /// </summary>
        /// <returns></returns>
        public static IList<CategoriesInfo> GetAllBookCategory()
        {
            string sql = "select Id,Name from Categories";
            List<CategoriesInfo> list = new List<CategoriesInfo>();
            try
            {
                DataTable dt = DBHelper.ExecuteDataTable(sql);
                foreach (DataRow row in dt.Rows)
                {
                    CategoriesInfo categoriesInfo = new CategoriesInfo();
                    categoriesInfo.Id = Convert.ToInt32(row["Id"]);
                    categoriesInfo.Name = row["Name"].ToString();
                    list.Add(categoriesInfo);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        #endregion
        //已确认
        #region 图书分类查询

        /// <summary>
        ///  图书分类查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static CategoriesInfo GetCategoriesById(int id)
        {
            string sql = "select Id,Name from Categories where Id=@Id";
            CategoriesInfo categoriesInfo = new CategoriesInfo();
            try
            {
                //先创建参数，然后才能添加参数 

                DBHelper.CreateParameters(1);  //参数个数，1个
                DBHelper.AddParameters(0, "@Id", id);
                DataTable dt = DBHelper.ExecuteDataTable(sql);
                foreach (DataRow row in dt.Rows)
                {
                    categoriesInfo.Id = Convert.ToInt32(row["Id"]);
                    categoriesInfo.Name = row["Name"].ToString();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return categoriesInfo;
        }

        #endregion

        #region 后台
        #endregion
        //已修改
        #region  AspNetPager控件分页数获取方法 （图书分类浏览）

        /// <summary>
        /// AspNetPager控件分页数获取方法    //已修改
        /// </summary>
        /// <returns></returns>
        public static int GetAspNetPager_PageCount()
        {
            string sql = "select count(Id) count from Categories";
            try
            {
                object result = DBHelper.ExecuteScalar(sql);
                if (result != null) 
                {
                    return Convert.ToInt32(result);
                }else { return 0; }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        #endregion
        //已修改
        #region  初始化图书分类浏览方法

        /// <summary>
        /// 初始化图书分类浏览方法
        /// </summary>
        /// <returns></returns>
        public static IList<CategoriesInfo> GetBookCategoryList(int pageindex)
        {

            //string strSQL = "and Id NOT IN (SELECT TOP " + 10 * (pageindex - 1) + "Id FROM Categories where DeleteFlag=0)";
            //string sql = "select top 10 Id,Name from Categories where DeleteFlag=0 " + strSQL;

            string sqlPlus = "select Id,Name from Categories where DeleteFlag=0 limit " + 10 * (pageindex - 1)+",10";
            List<CategoriesInfo> list = new List<CategoriesInfo>();
            try
            {
                DataTable dt = DBHelper.ExecuteDataTable(sqlPlus);
                foreach (DataRow row in dt.Rows)
                {
                    CategoriesInfo categoriesInfo = new CategoriesInfo();
                    categoriesInfo.Id = Convert.ToInt32(row["Id"]);
                    categoriesInfo.Name = row["Name"].ToString();
                    list.Add(categoriesInfo);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        #endregion
        //已确认
        #region  图书分类逻辑删除方法

        /// <summary>
        /// 图书分类逻辑删除方法  //已确认
        /// </summary>
        /// <param name="id"></param>
        public static bool LogicDeleteBooksCategoryById(int id)
        {
            bool result = false;
            string sql="update Categories set DeleteFlag=1 where Id=@Id";
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0, "@Id",id);
                result= DBHelper.ExecuteNonQuery(sql)>0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;            
        }

        #endregion
        //已修改
        #region  图书分类物理删除方法

        /// <summary>
        /// 图书分类物理删除方法
        /// </summary>
        /// <param name="id"></param>
        public static bool DeleteBooksCategoryById(int id)
        {
            string sql = "delete from Categories where Id=@Id";
            //object result;
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0, "@Id", id);
                //result = DBHelper.ExecuteNonQuery(sql) > 0;
                if (DBHelper.ExecuteNonQuery(sql) > 0)
                {
                    return true;
                }
                else { 
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        #endregion
        //已确认
        #region  图书分类添加时执行判断是否已有值

        /// <summary>
        /// 图书分类添加时执行判断是否已有值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool GetAddCategoryExist(string name)
        {
            bool result = false;
            string sql= "select Id from Categories where Name=@Name";
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0, "@Name", name);
                IDataReader reader = DBHelper.ExecuteReader(sql);
                if (reader.Read())
                {
                    result = true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                DBHelper.Close();
            }
            return result;
        }

        #endregion
        //已确认
        #region  图书分类添加方法

        /// <summary>
        /// 图书分类添加方法
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool AddCategoryById(string name)
        {
            bool result = false;
            string sql ="insert into Categories(Name) values(@Name)";
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0, "@Name", name);
                result = DBHelper.ExecuteNonQuery(sql) > 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;   
        }

        #endregion
        //已确认
        #region  图书分类编辑时执行判断

        /// <summary>
        /// 图书分类编辑时执行判断
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool GetUpdateExist(string name)
        {
            bool result = false;
            string sql = "select Id from Categories where Name=@Name";
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0, "@Name", name);
                IDataReader reader = DBHelper.ExecuteReader(sql);
                if (reader.Read())
                {
                    result = true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                DBHelper.Close();
            }
            return result;  
        }

        #endregion
        //已确认
        #region  图书分类编辑方法

        /// <summary>
        /// 图书分类编辑方法
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool UpdateCategory(string id, string name)
        {
            bool result = false;
            string sql = "update Categories set Name=@Name where Id=@Id";
            try
            {
                DBHelper.CreateParameters(2);
                DBHelper.AddParameters(0, "@Name", name);
                DBHelper.AddParameters(1, "@Id",id);
                result = DBHelper.ExecuteNonQuery(sql) > 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }

        #endregion
    }
}
