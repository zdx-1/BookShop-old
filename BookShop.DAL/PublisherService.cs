using System;
using System.Collections.Generic;
using System.Data;
using BookShop.Common.DB;
using BookShop.Model;

namespace BookShop.DAL
{
    public static class PublisherService
    {

        #region 前台
        #endregion
        
        #region 出版社前10查询

        /// <summary>
        /// 出版社前10查询
        /// </summary>
        /// <returns></returns>
        public static List<PublishersInfo> GetTopBookPublishers()
        {
            string sql = "SELECT Id, Name FROM Publishers LIMIT 10";
            List<PublishersInfo> list = new List<PublishersInfo>();
            try
            {
                DataTable dt = DBHelper.ExecuteDataTable(sql);
                foreach (DataRow row in dt.Rows)
                {
                    PublishersInfo publisherInfo = new PublishersInfo();
                    publisherInfo.Id = Convert.ToInt32(row["Id"]);
                    publisherInfo.Name = row["Name"].ToString();
                    list.Add(publisherInfo);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        #endregion
        
        #region 出版社查询

        /// <summary>
        /// 出版社查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PublishersInfo GetPublishersById(int id)
        {
            string sql = "select Id,Name from Publishers where Id=@Id";
            PublishersInfo publisherInfo = new PublishersInfo();
            try
            {
                //先创建参数，然后才能添加参数 

                DBHelper.CreateParameters(1);  //参数个数，1个
                DBHelper.AddParameters(0, "@Id", id);
                DataTable dt = DBHelper.ExecuteDataTable(sql);
                foreach (DataRow row in dt.Rows)
                {
                    publisherInfo.Id = Convert.ToInt32(row["Id"]);
                    publisherInfo.Name = row["Name"].ToString();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return publisherInfo;
        }

        #endregion

        #region 后台
        #endregion
        
        #region  AspNetPager控件分页数获取方法 （出版社浏览）

        /// <summary>
        /// AspNetPager控件分页数获取方法
        /// </summary>
        /// <returns></returns>
        public static int GetAspNetPager_PageCount()
        {
            string sql = "select count(Id) count from Publishers";
            try
            {
                object result = DBHelper.ExecuteScalar(sql);
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else 
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion
        
        #region  初始化出版社浏览方法

        /// <summary>
        /// 初始化出版社浏览方法
        /// </summary>
        /// <returns></returns>
        public static IList<PublishersInfo> GetBookPublisherList(int pageindex)
        {
            string strSQL = " and Id NOT IN (SELECT TOP " + 10 * (pageindex - 1) + "Id FROM Publishers WHERE DeleteFlag=0)";
            string sql = "SELECT TOP 10 Id,Name FROM Publishers WHERE DeleteFlag=0" + strSQL;
            string sqlPlus = "select Id,Name FROM Publishers WHERE DeleteFlag=0 limit " + 10*(pageindex-1)+",10";
            List<PublishersInfo> list = new List<PublishersInfo>();
            try
            {
                DataTable dt = DBHelper.ExecuteDataTable(sqlPlus);
                foreach (DataRow row in dt.Rows)
                {
                    PublishersInfo publishersInfo = new PublishersInfo();
                    publishersInfo.Id = Convert.ToInt32(row["Id"]);
                    publishersInfo.Name = row["Name"].ToString();
                    list.Add(publishersInfo);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
            
        }

        #endregion
        
        #region  出版社逻辑删除方法

        /// <summary>
        /// 出版社逻辑删除方法
        /// </summary>
        /// <param name="id"></param>
        public static bool LogicDeleteBooksPublisherById(int id)
        {
            bool result = false;
            string sql = "update Publishers set DeleteFlag=1 where Id=@Id";
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0, "@Id", id);
                result = DBHelper.ExecuteNonQuery(sql) > 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }

        #endregion
        
        #region  出版社物理删除方法

        /// <summary>
        /// 出版社物理删除方法
        /// </summary>
        /// <param name="id"></param>
        public static bool DeleteBooksPublisherById(int id)
        {
            bool result = false;
            string sql = "delete from Publishers where Id=@Id";
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0, "@Id", id);
                result = DBHelper.ExecuteNonQuery(sql) > 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }

        #endregion
        
        #region  出版社添加时执行判断是否已有值

        /// <summary>
        /// 出版社添加时执行判断是否已有值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool GetAddPublisherExist(string name)
        {
            bool result = false;
            string sql = "select Id from Publishers where Name=@Name";
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
            string sql = "insert into Publishers(Name) values(@Name)";
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
        
        #region  出版社编辑时执行判断

        /// <summary>
        /// 出版社编辑时执行判断
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool GetUpdateExist(string name)
        {
            bool result = false;
            string sql = "select Id from Publishers where Name=@Name";
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
            return result;
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
            bool result = false;
            string sql = "update Publishers set Name=@Name where Id=@Id";
            try
            {
                DBHelper.CreateParameters(2);
                DBHelper.AddParameters(0, "@Name", name);
                DBHelper.AddParameters(1, "@Id", id);
                result = DBHelper.ExecuteNonQuery(sql) > 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }

        #endregion
        
        #region 出版社绑定显示

        /// <summary>
        /// 出版社绑定显示
        /// </summary>
        /// <returns></returns>
        public static List<PublishersInfo> GetAllBookPublishers()
        {
            string sql = "select Id,Name from Publishers";
            List<PublishersInfo> list = new List<PublishersInfo>();
            try
            {
                DataTable dt = DBHelper.ExecuteDataTable(sql);
                foreach (DataRow row in dt.Rows)
                {
                    PublishersInfo publisherInfo = new PublishersInfo();
                    publisherInfo.Id = Convert.ToInt32(row["Id"]);
                    publisherInfo.Name = row["Name"].ToString();
                    list.Add(publisherInfo);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        #endregion
    }
}
