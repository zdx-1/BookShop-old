using System;
using System.Collections.Generic;
using System.Data;
using BookShop.Common.DB;
using BookShop.Model;


namespace BookShop.DAL
{
    public static class BookService
    {
        #region 前台
        #endregion
        //已修改
        #region 最热图书获取前4本信息 
        /// <summary>
        /// 最热图书获取前4本信息 //已修改
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public static List<BooksInfo> GetHotSellBookList()
        {
            string sql = "SELECT Id, Title, ImgUrl, PublishDate, UnitPrice, ISBN FROM Books WHERE DeleteFlag = 0 ORDER BY Clicks DESC LIMIT 4;";
            List<BooksInfo> list = new List<BooksInfo>();
            try
            {
                DataTable dt = DBHelper.ExecuteDataTable(sql);
                foreach (DataRow row in dt.Rows)
                {
                    BooksInfo booksInfo = new BooksInfo();
                    booksInfo.Id = Convert.ToInt32(row["Id"]);
                    booksInfo.Title = row["Title"].ToString();
                    booksInfo.ImgUrl = row["ImgUrl"].ToString();
                    booksInfo.PublishDate = DateTime.Parse(row["PublishDate"].ToString());
                    booksInfo.UnitPrice = Decimal.Parse(row["UnitPrice"].ToString());
                    booksInfo.ISBN = row["ISBN"].ToString();
                    list.Add(booksInfo);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        #endregion
        //已修改
        #region  编辑推荐图书获取1本信息

        /// <summary>
        /// 编辑推荐图书获取1本信息 //已修改
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public static List<BooksInfo> GetEditorRecommendBooksList()
        {
            string sql = "SELECT Id, Title, EditorComment, ImgUrl, PublishDate, UnitPrice, ISBN FROM Books WHERE EditorComment != '' AND DeleteFlag = 0 ORDER BY Clicks DESC LIMIT 1;";
            List<BooksInfo> list = new List<BooksInfo>();
            try
            {
                DataTable dt = DBHelper.ExecuteDataTable(sql);
                foreach (DataRow row in dt.Rows)
                {
                    BooksInfo booksInfo = new BooksInfo();
                    booksInfo.Id = Convert.ToInt32(row["Id"]);
                    booksInfo.Title = row["Title"].ToString();
                    booksInfo.EditorComment = row["EditorComment"].ToString();
                    booksInfo.ImgUrl = row["ImgUrl"].ToString();
                    booksInfo.PublishDate = DateTime.Parse(row["PublishDate"].ToString());
                    booksInfo.UnitPrice = Decimal.Parse(row["UnitPrice"].ToString());
                    booksInfo.ISBN = row["ISBN"].ToString();
                    list.Add(booksInfo);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        #endregion
        //已修改
        #region  最新图书获取8本信息

        /// <summary>
        /// 最新图书获取8本信息  //已修改
        /// </summary>
        /// <returns>返回List</returns>
        public static List<BooksInfo> GetNewBooksList()
        {
            string sql = "SELECT Id, Title, UnitPrice, ImgUrl, PublishDate, ISBN FROM Books WHERE DeleteFlag = 0 ORDER BY PublishDate DESC LIMIT 8;";
            List<BooksInfo> list = new List<BooksInfo>();
            try
            {
                DataTable dt = DBHelper.ExecuteDataTable(sql);
                foreach (DataRow row in dt.Rows)
                {
                    BooksInfo booksInfo = new BooksInfo();
                    booksInfo.Id = Convert.ToInt32(row["Id"]);
                    booksInfo.Title = row["Title"].ToString();
                    booksInfo.ImgUrl = row["ImgUrl"].ToString();
                    booksInfo.PublishDate = DateTime.Parse(row["PublishDate"].ToString());
                    booksInfo.UnitPrice = Decimal.Parse(row["UnitPrice"].ToString());
                    booksInfo.ISBN = row["ISBN"].ToString();
                    list.Add(booksInfo);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        #endregion
        //已修改
        #region 点击率排行榜前10位图书信息

        /// <summary>
        /// 点击率排行榜前10位图书信息  //已修改
        /// </summary>
        /// <returns></returns>
        public static List<BooksInfo> GetClicks()
        {
            string sql = "SET @row_number = 0;  SELECT @row_number := @row_number + 1 AS row_number, Id, Clicks, Title FROM Books WHERE DeleteFlag = 0 ORDER BY Clicks DESC LIMIT 10;";
            List<BooksInfo> list = new List<BooksInfo>();
            try
            {
                DataTable dt = DBHelper.ExecuteDataTable(sql);
                foreach (DataRow row in dt.Rows)
                {
                    BooksInfo booksInfo = new BooksInfo();

                    booksInfo.WordsCount = Convert.ToInt32(row["row_number"]);
                    booksInfo.Id = Convert.ToInt32(row["Id"]);
                    booksInfo.Clicks = Convert.ToInt32(row["Clicks"]);
                    booksInfo.Title = row["Title"].ToString();
                    list.Add(booksInfo);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        #endregion
        //已修改
        #region  AspNetPager控件分页数获取方法（前台图书浏览页）

        /// <summary>
        /// AspNetPager控件分页数获取方法    //已修改
        /// </summary>
        /// <returns></returns>
        public static int GetAspNetPager_PageCount(string logicId, string whereName, int x)   //x为0时说明浏览所有图书页数获取方法
        {
            string sql = "select count(Id) as count from Books";
            try
            {
                object result = DBHelper.ExecuteScalar(sql);
                if (result != null) { 
                    return Convert.ToInt32(result);
                }else { return 0; }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public static int GetAspNetPager_PageCount1(string logicId, string whereName, int x)  //x为1时说明所接收参数logicId是图书分类编号页数获取方法
        {
            string sql = "select count(Id) count from Books";
            string strSQL = " where CategoryId=@CatId";
            sql += strSQL;
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0, "@CatId", logicId);
                object result = DBHelper.ExecuteScalar(sql);
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else { return 0; }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public static int GetAspNetPager_PageCount2(string logicId, string whereName, int x)  //x为2时说明所接收参数logicId是出版社编号页数获取方法
        {
            string sql = "select count(Id) as count from Books";
            string strSQL = " where PublisherId=@PubId";
            sql += strSQL;
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0, "@PubId", logicId);
                object result = DBHelper.ExecuteScalar(sql);
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else { return 0; }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public static int GetAspNetPager_PageCount3(string logicId, string whereName, int x)  //x为3时说明所接收参数logicId是搜索编号页数获取方法
        {
            string sql = "select count(Id) count from Books";
            string strSQL = " where Title like @Title";
            sql += strSQL;
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0, "@Title", logicId);
                object result = DBHelper.ExecuteScalar(sql);
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else { return 0; }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
           
        }

        #endregion
        //已修改
        #region 浏览图书信息（图书浏览页）

        /// <summary>
        /// 浏览图书绑定到DataList控件dlsBook上显示 //已修改
        /// </summary>
        /// <param name="logicId">所取参数Id，可取的有：CatId、PubId,没有指定默认为string类型："0"字符</param>
        /// <param name="whereName">指定按什么方式排序，不排序为string类型："0"字符</param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static IList<BooksInfo> GetBookList(int pageindex, string logicId, string whereName, int x)   //x为0时说明浏览所有图书页数获取方法
        {
            //string sql = "select TOP 5 Id,Title,Author,ImgUrl,UnitPrice,PublishDate,ContentDescription from Books";
            //string strSQL = " where";
            //if (whereName != "")
            //{
            //    strSQL += " Id NOT IN (SELECT TOP " + 5 * (pageindex - 1) + " Id from Books" + " order by " + whereName + " desc" + ")" + " order by "
            //    + whereName + "  desc";
            //    sql += strSQL;
            //}
            //else
            //{
            //    sql += strSQL + " Id NOT IN (SELECT TOP " + 5 * (pageindex - 1) + " Id from Books)";
            //}
            //string sqlPlus = "";
            //if (whereName != null)
            //{
            //     sqlPlus = "SELECT Id, Title, Author, ImgUrl, UnitPrice, PublishDate, ContentDescription " +
            //                    "FROM Books b1 " +
            //                    "WHERE NOT EXISTS (" +
            //                    " SELECT 1 FROM ( " +
            //                    "SELECT Id FROM Books ORDER BY " + whereName + " DESC LIMIT " + 5 * (pageindex - 1) +
            //                    " ) b2 WHERE b1.Id = b2.Id ) " +
            //                    "ORDER BY " + whereName + " DESC LIMIT " + 5 + ";";
            //}
            //else
            //{
            //     sqlPlus = "SELECT Id, Title, Author, ImgUrl, UnitPrice, PublishDate, ContentDescription " +
            //                    "FROM Books b1 " +
            //                    "WHERE NOT EXISTS (" +
            //                    " SELECT 1 FROM ( " +
            //                    "SELECT Id FROM Books LIMIT " + 5 * (pageindex - 1) +
            //                    " ) b2 WHERE b1.Id = b2.Id ) " +"LIMIT " + 5 + ";";
            //}
            string sqlPlus = " SELECT Id, Title, Author, ImgUrl, UnitPrice, PublishDate, ContentDescription From Books b1 ";
            string isParm = " Where "+ whereName +" limit " +
                5*(pageindex-1)+",5";
            string noParm = " limit "+5*(pageindex-1)+",5";
            if (whereName != "")
            {
                sqlPlus += isParm;
            }
            else { sqlPlus += noParm; }


            List<BooksInfo> list = new List<BooksInfo>();
            try
            {
                IDataReader reader = DBHelper.ExecuteReader(sqlPlus);
                while (reader.Read())
                {
                    BooksInfo booksInfo = new BooksInfo();
                    booksInfo.Id = Convert.ToInt32(reader["Id"]);
                    booksInfo.Title = reader["Title"].ToString();
                    booksInfo.Author = reader["Author"].ToString();
                    booksInfo.ImgUrl = reader["ImgUrl"].ToString();
                    booksInfo.UnitPrice = Decimal.Parse(reader["UnitPrice"].ToString());
                    booksInfo.PublishDate = DateTime.Parse(reader["PublishDate"].ToString());
                    booksInfo.ContentDescription = reader["ContentDescription"].ToString();
                    list.Add(booksInfo);
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
            return list;
        }

        public static IList<BooksInfo> GetBookList1(int pageindex, string logicId, string whereName, int x)  //x为1时说明所接收参数logicId是图书分类编号
        {
            //string sql = "select Id,Title,Author,ImgUrl,UnitPrice,PublishDate,ContentDescription from Books";
            //string strSQL = " where CategoryId=@CatId";

            //if (whereName != "")
            //{
            //    string strSQL1 = " order by " + whereName + " desc";
            //    string sqlStr = " and Id NOT IN (SELECT TOP " + 5 * (pageindex - 1) + " Id from Books " + strSQL + strSQL1 + ")";
            //    sql += strSQL + sqlStr + strSQL1;
            //}
            //else
            //{
            //    string sqlStr = " and Id NOT IN (SELECT TOP " + 5 * (pageindex - 1) + " Id from Books " + strSQL + ")";
            //    sql += strSQL + sqlStr;
            //}
            string sqlPlus = "select Id,Title,Author,ImgUrl,UnitPrice,PublishDate,ContentDescription from Books where CategoryId=@CatId ";
            string isParm = " Where " + whereName + " limit " +5 * (pageindex - 1) + ",5";
            string noParm = " limit " + 5 * (pageindex - 1) + ",5";
         
                if (whereName != "")
                {
                    sqlPlus += isParm;
                }
                else
                {
                    sqlPlus += noParm;
                }
            
            List<BooksInfo> list = new List<BooksInfo>();
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0, "@CatId", logicId);
                IDataReader reader = DBHelper.ExecuteReader(sqlPlus);
                while (reader.Read())
                {
                    BooksInfo booksInfo = new BooksInfo();
                    booksInfo.Id = Convert.ToInt32(reader["Id"]);
                    booksInfo.Title = reader["Title"].ToString();
                    booksInfo.Author = reader["Author"].ToString();
                    booksInfo.ImgUrl = reader["ImgUrl"].ToString();
                    booksInfo.UnitPrice = Decimal.Parse(reader["UnitPrice"].ToString());
                    booksInfo.PublishDate = DateTime.Parse(reader["PublishDate"].ToString());
                    booksInfo.ContentDescription = reader["ContentDescription"].ToString();
                    list.Add(booksInfo);
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
            return list;


        }

        public static IList<BooksInfo> GetBookList2(int pageindex, string logicId, string whereName, int x)   //x为2时说明所接收参数logicId是出版社编号
        {
            //string sql = "select TOP 5 Id,Title,Author,ImgUrl,UnitPrice,PublishDate,ContentDescription from Books where PublisherId=@PubId and Id NOT IN (SELECT TOP " + 5 * (pageindex - 1) + " Id from Books where PublisherId=@PubId)";
            //if (whereName != "")
            //{
            //    sql = "select TOP 5 Id,Title,Author,ImgUrl,UnitPrice,PublishDate,ContentDescription from Books where PublisherId=@PubId and Id NOT IN (SELECT TOP " + 5 * (pageindex - 1) + " Id from Books where PublisherId=@PubId order by " + whereName + " desc ) order by " + whereName + " desc ";
            //}
            string sqlPlus = "select Id,Title,Author,ImgUrl,UnitPrice,PublishDate,ContentDescription from Books where PublisherId=@PubId ";
            string isParm= "limit "+5*(pageindex-1)+",5";
            string noParm="order by "+whereName + " limit " + 5 * (pageindex - 1) + ",5";
            if (pageindex == 1) 
            {
                sqlPlus+= " limit 5";
            } else 
            {
                if (whereName != "")
                {
                    sqlPlus += isParm;
                }
                else
                {
                    sqlPlus += noParm;
                }
            }
            
            List<BooksInfo> list = new List<BooksInfo>();
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0, "@PubId", logicId);
                IDataReader reader = DBHelper.ExecuteReader(sqlPlus);
                while (reader.Read())
                {
                    BooksInfo booksInfo = new BooksInfo();
                    booksInfo.Id = Convert.ToInt32(reader["Id"]);
                    booksInfo.Title = reader["Title"].ToString();
                    booksInfo.Author = reader["Author"].ToString();
                    booksInfo.ImgUrl = reader["ImgUrl"].ToString();
                    booksInfo.UnitPrice = Decimal.Parse(reader["UnitPrice"].ToString());
                    booksInfo.PublishDate = DateTime.Parse(reader["PublishDate"].ToString());
                    booksInfo.ContentDescription = reader["ContentDescription"].ToString();
                    list.Add(booksInfo);
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
            return list;
        }

        public static IList<BooksInfo> GetBookList3(int pageindex, string logicId, string whereName, int x)   //x为3时说明所接收参数logicId是搜索编号
        {
            //string sql = "select TOP 5 Id,Title,Author,ImgUrl,UnitPrice,PublishDate,ContentDescription from Books";
            //string strSQL = " where Title like @Title";
            //if (whereName != "")
            //{
            //    string strSQL1 = " order by " + whereName + " desc";
            //    string sqlStr = " and Id NOT IN (SELECT TOP " + 5 * (pageindex - 1) + " Id from Books " + strSQL + strSQL1 + ")";
            //    sql += strSQL + sqlStr + strSQL1;
            //}
            //else
            //{
            //    string sqlStr = " and Id NOT IN (SELECT TOP " + 5 * (pageindex - 1) + " Id from Books " + strSQL + ")";
            //    sql += strSQL + sqlStr;
            //}
            string sqlPlus = "select Id,Title,Author,ImgUrl,UnitPrice,PublishDate,ContentDescription from Books where Title like @Title ";
            string isParm = " order by " + whereName + " desc limit "+5*(pageindex-1)+",5" ;
            string noParm = " limit " + 5 * (pageindex - 1) + ",5";
            if (whereName != "")
            {
                sqlPlus += isParm;
            }
            else { sqlPlus += noParm; }
            List<BooksInfo> list = new List<BooksInfo>();
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0, "@Title", logicId);
                IDataReader reader = DBHelper.ExecuteReader(sqlPlus);
                while (reader.Read())
                {
                    BooksInfo booksInfo = new BooksInfo();
                    booksInfo.Id = Convert.ToInt32(reader["Id"]);
                    booksInfo.Title = reader["Title"].ToString();
                    booksInfo.Author = reader["Author"].ToString();
                    booksInfo.ImgUrl = reader["ImgUrl"].ToString();
                    booksInfo.UnitPrice = Decimal.Parse(reader["UnitPrice"].ToString());
                    booksInfo.PublishDate = DateTime.Parse(reader["PublishDate"].ToString());
                    booksInfo.ContentDescription = reader["ContentDescription"].ToString();
                    list.Add(booksInfo);
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
            return list;
        }

        #endregion
        //已确认
        #region 点击某一本图书点击率加1方法

        /// <summary>
        /// 点击某一本图书点击率加1方法
        /// </summary>
        /// <param name="bookId"></param>
        public static void AddBookClick(int bookId)
        {
            string sql = "update Books set Clicks=Clicks+1 where Id=@Id";
            DBHelper.CreateParameters(1);
            DBHelper.AddParameters(0, "@Id", bookId);
            DBHelper.ExecuteNonQuery(sql);
        }

        #endregion
        //已修改
        #region  图书详细信息浏览（图书详细页）

        /// <summary>
        /// 图书详细信息浏览（图书详细页）
        /// </summary>
        /// <returns></returns>
        public static IList<BooksInfo> GetBookDetails(int bookId)
        {
            string sql = "select Id,Title,Author,CategoryId,PublisherId,ISBN,PublishDate,WordsCount,ImgUrl,UnitPrice,ContentDescription,AuthorDescription,TOC,EditorComment from Books where Id=@BookId limit 1";
            List<BooksInfo> list = new List<BooksInfo>();
            try
            {
                //先创建参数，然后才能添加参数 

                DBHelper.CreateParameters(1);  //参数个数，1个
                DBHelper.AddParameters(0, "@BookId", bookId);
                DataTable dt = DBHelper.ExecuteDataTable(sql);
                foreach (DataRow row in dt.Rows)
                {
                    BooksInfo booksInfo = new BooksInfo();
                    booksInfo.Id = Convert.ToInt32(row["Id"]);
                    booksInfo.Title = row["Title"].ToString();
                    booksInfo.Author = row["Author"].ToString();
                    booksInfo.ISBN = row["ISBN"].ToString();
                    booksInfo.PublishDate = DateTime.Parse(row["PublishDate"].ToString());
                    booksInfo.WordsCount = Convert.ToInt32(row["WordsCount"]);
                    booksInfo.ImgUrl = row["ImgUrl"].ToString();
                    booksInfo.UnitPrice = Decimal.Parse(row["UnitPrice"].ToString());
                    booksInfo.ContentDescription = row["ContentDescription"].ToString();
                    booksInfo.AuthorDescription = row["AuthorDescription"].ToString();
                    booksInfo.TOC = row["TOC"].ToString();
                    booksInfo.EditorComment = row["EditorComment"].ToString();
                    booksInfo.Categories = CategoryService.GetCategoriesById(Convert.ToInt32(row["CategoryId"]));
                    booksInfo.Publishers = PublisherService.GetPublishersById(Convert.ToInt32(row["PublisherId"]));
                    list.Add(booksInfo);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        #endregion

        #region 后台
        #endregion
        //已确认
        #region  删除前判断图书表内是否已有关联的方法

        /// <summary>
        /// 删除前判断图书表内是否已有关联的方法
        /// </summary>
        /// <param name="title">图书名称</param>
        /// <returns></returns>
        public static bool GetSelectBooks(int id)
        {
            bool result = false;
            string sql = "select Id from Books where CategoryId=@CategoryId";
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0, "@CategoryId", id);
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
        #region  删除前判断出版社表内是否已有关联的方法

        /// <summary>
        /// 删除前判断出版社表内是否已有关联的方法
        /// </summary>
        /// <param name="title">出版社名称</param>
        /// <returns></returns>
        public static bool GetSelectBooksByPublisherId(int id)
        {
            bool result = false;
            string sql = "select Id from Books where PublisherId=@PublisherId";
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0, "@PublisherId", id);
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
        #region 订单表会员编号关联查询 （后台订单详细表浏览）

        /// <summary>
        /// 订单表会员编号关联查询 （后台订单详细表浏览）
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public static BooksInfo GetSelectBooksInfoById(int id)
        {
            string sql = "select Id,Title from Books where Id=@Id";
            BooksInfo booksInfo = new BooksInfo();
            try
            {
                //先创建参数，然后才能添加参数 

                DBHelper.CreateParameters(1);  //参数个数，1个
                DBHelper.AddParameters(0, "@Id", id);
                DataTable dt = DBHelper.ExecuteDataTable(sql);
                foreach (DataRow row in dt.Rows)
                {
                    booksInfo.Id = Convert.ToInt32(row["Id"]);
                    booksInfo.Title = row["Title"].ToString();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return booksInfo;
        }

        #endregion
        //已修改
        #region  AspNetPager控件分页数获取方法  （后台图书浏览页）

        /// <summary>
        /// AspNetPager控件分页数获取方法 （后台图书浏览页浏览所有图书）
        /// </summary>
        /// <returns></returns>
        public static int GetAdminAspNetPager_PageCount()
        {
            string sql = "select count(Id) count from Books where DeleteFlag=0 ";
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

        /// <summary>
        /// AspNetPager控件分页数获取方法 （后台图书浏览页按图书分类浏览）
        /// </summary>
        /// <returns></returns>
        public static int GetAdminAspNetPager_PageCount(int ddlCategorySelectedValue)
        {
            string sqlSQLCat = "and Books.CategoryId=@CatId";
            string sql = "select count(Id) count from Books where DeleteFlag=0 " + sqlSQLCat;
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0, "@CatId", ddlCategorySelectedValue);
                object result = DBHelper.ExecuteScalar(sql);
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else { 
                    return 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion
        //已修改
        #region  初始化图书浏览方法

        /// <param name="sender"></param>
        /// 所有图书浏览方法
        /// </summary>
        /// <returns></returns>
        public static IList<BooksInfo> GetAdminBookList(int pageindex)
        {
            //string strSQL = " and Id NOT IN (SELECT TOP " + 10 * (pageindex - 1) + " Id from Books where DeleteFlag=0 order by PublishDate desc)";
            //string sql = "select top 10 Id,Title,Author,UnitPrice,PublishDate,PublisherId from Books where DeleteFlag=0" + strSQL + " order by PublishDate desc";
            string sqlPlus = "select Id,Title,Author,UnitPrice,PublishDate,PublisherId from Books where DeleteFlag=0 order by PublishDate desc limit "+10*(pageindex-1)+",10";
            List<BooksInfo> list = new List<BooksInfo>();
            try
            {
                DataTable dt = DBHelper.ExecuteDataTable(sqlPlus);
                foreach (DataRow row in dt.Rows)
                {
                    BooksInfo booksInfo = new BooksInfo();
                    booksInfo.Id = Convert.ToInt32(row["Id"]);
                    booksInfo.Title = row["Title"].ToString();
                    booksInfo.Author = row["Author"].ToString();
                    booksInfo.UnitPrice = Decimal.Parse(row["UnitPrice"].ToString());
                    booksInfo.PublishDate = DateTime.Parse(row["PublishDate"].ToString());
                    booksInfo.Publishers = PublisherService.GetPublishersById(Convert.ToInt32(row["PublisherId"]));

                    list.Add(booksInfo);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        /// <param name="sender"></param>
        /// 按图书分类图书浏览方法
        /// </summary>
        /// <returns></returns>
        public static IList<BooksInfo> GetAdminBookList(int catId, int pageindex)
        {
            //string strSQL = " and Id NOT IN (SELECT TOP " + 10 * (pageindex - 1) + " Id from Books where DeleteFlag=0 order by PublishDate desc)";
            //string sqlSQLCat = "and CategoryId=@CatId";
            //string sql = "select top 10 Id,Title,Author,UnitPrice,PublishDate,PublisherId from Books where DeleteFlag=0" + strSQL + sqlSQLCat + " order by PublishDate desc";
            string sqlPlus = "select Id,Title,Author,UnitPrice,PublishDate,PublisherId from Books " +
                "where DeleteFlag=0 and CategoryId=@CatId " +
                "order by PublishDate desc limit " + 10 * (pageindex - 1)+",10"; ;
            List<BooksInfo> list = new List<BooksInfo>();
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0, "@CatId", catId);
                DataTable dt = DBHelper.ExecuteDataTable(sqlPlus);
                foreach (DataRow row in dt.Rows)
                {
                    BooksInfo booksInfo = new BooksInfo();
                    booksInfo.Id = Convert.ToInt32(row["Id"]);
                    booksInfo.Title = row["Title"].ToString();
                    booksInfo.Author = row["Author"].ToString();
                    booksInfo.UnitPrice = Decimal.Parse(row["UnitPrice"].ToString());
                    booksInfo.PublishDate = DateTime.Parse(row["PublishDate"].ToString());
                    booksInfo.Publishers = PublisherService.GetPublishersById(Convert.ToInt32(row["PublisherId"]));

                    list.Add(booksInfo);
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
        #region  图书物理删除方法

        /// <summary>
        /// 图书物理删除方法
        /// </summary>
        /// <param name="id"></param>
        public static bool DeleteBooksById(int id)
        {
            bool result = false;
            string sql = "delete from Books where Id=@Id";
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
        //已确认
        #region  图书逻辑删除方法

        /// <summary>
        /// 图书逻辑删除方法
        /// </summary>
        /// <param name="id"></param>
        public static bool LogicDeleteBooksById(int id)
        {
            bool result = false;
            string sql = "update Books set DeleteFlag=1 where Id=@Id";
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
        //已确认
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
            bool result = false;
            string sql = "insert into Books(Title,Author,PublisherId,PublishDate,ISBN,WordsCount,UnitPrice,ContentDescription,AuthorDescription,EditorComment,TOC,CategoryId,Clicks,ImgUrl,DeleteFlag) values(@Title,@Author,@PublisherId,@PublishDate,@ISBN,@WordsCount,@UnitPrice,@ContentDescription,@AuthorDescription,@EditorComment,@TOC,@CategoryId,0,@ImgUrl,0)";
            try
            {
                DBHelper.CreateParameters(13);
                DBHelper.AddParameters(0, "@Title", title);
                DBHelper.AddParameters(1, "@Author", author);
                DBHelper.AddParameters(2, "@PublisherId", publisherId);
                DBHelper.AddParameters(3, "@PublishDate", publishDate);
                DBHelper.AddParameters(4, "@ISBN", ISBN);
                DBHelper.AddParameters(5, "@WordsCount", wordsCount);
                DBHelper.AddParameters(6, "@UnitPrice", unitPrice);
                DBHelper.AddParameters(7, "@ContentDescription", contentDescription);
                DBHelper.AddParameters(8, "@AuthorDescription", authorDescription);
                DBHelper.AddParameters(9, "@EditorComment", editorComment);
                DBHelper.AddParameters(10, "@TOC", TOC);
                DBHelper.AddParameters(11, "@CategoryId", categoryId);
                DBHelper.AddParameters(12, "@ImgUrl", imgUrl);
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
        #region  判断图书名称或ISBN是否已存在

        /// <summary>
        /// 判断图书名称或ISBN是否已存在
        /// </summary>
        /// <param name="title">图书名称</param>
        /// <param name="ISBN">ISBN</param>
        /// <returns></returns>
        public static bool GetSelectTitleOrISBN(string title, string ISBN)
        {
            bool result = false;
            string sql = "select Id from Books where Title=@Title or ISBN=@ISBN";
            try
            {
                DBHelper.CreateParameters(2);
                DBHelper.AddParameters(0, "@Title", title);
                DBHelper.AddParameters(1, "@ISBN", ISBN);
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
        #region 初始化绑定页面类别和出版社DropDownList控件的值，并初始化页面控件属性的方法

        /// <summary>
        /// 初始化绑定页面类别和出版社DropDownList控件的值，并初始化页面控件属性的方法
        /// </summary>
        public static BooksInfo GetModifyBookPageLoadById(int id)
        {
            string sql="select Title,Author,ISBN,PublishDate,UnitPrice,WordsCount,ImgUrl,ContentDescription,AuthorDescription,EditorComment,TOC,CategoryId,PublisherId from Books where Id=@Id";
            BooksInfo booksInfo = new BooksInfo();
            try
            {
                //先创建参数，然后才能添加参数 

                DBHelper.CreateParameters(1);  //参数个数，1个
                DBHelper.AddParameters(0, "@Id", id);
                DataTable dt = DBHelper.ExecuteDataTable(sql);
                foreach (DataRow row in dt.Rows)
                {
                    booksInfo.Title = row["Title"].ToString();
                    booksInfo.Author = row["Author"].ToString();
                    booksInfo.ISBN = row["ISBN"].ToString();
                    booksInfo.PublishDate = DateTime.Parse(row["PublishDate"].ToString());
                    booksInfo.UnitPrice =Decimal.Parse(row["UnitPrice"].ToString());
                    booksInfo.WordsCount =Convert.ToInt32(row["WordsCount"]);
                    booksInfo.ImgUrl = row["ImgUrl"].ToString();
                    booksInfo.ContentDescription = row["ContentDescription"].ToString();
                    booksInfo.AuthorDescription = row["AuthorDescription"].ToString();
                    booksInfo.EditorComment = row["EditorComment"].ToString();
                    booksInfo.TOC = row["TOC"].ToString();
                    booksInfo.Categories = CategoryService.GetCategoriesById(Convert.ToInt32(row["CategoryId"]));
                    booksInfo.Publishers = PublisherService.GetPublishersById(Convert.ToInt32(row["PublisherId"]));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return booksInfo;
        }

        #endregion
        //测试中
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
        public static bool GetUpdate(int id, string title, string author, int categoryId, int publisherId, string ISBN, DateTime publishDate, Decimal unitPrice, int wordsCount, string contentDescription, string imgUrl)
        {
            bool result = false;
            string sql = "update Books set Title=@Title,Author=@Author,CategoryId=@CategoryId,PublisherId=@PublisherId,ISBN=@ISBN,PublishDate=@PublishDate,UnitPrice=@UnitPrice,WordsCount=@WordsCount,ContentDescription=@ContentDescription,ImgUrl=@ImgUrl where Id=@Id";
            try
            {
                DBHelper.CreateParameters(11);
                DBHelper.AddParameters(0, "@Title", title);
                DBHelper.AddParameters(1, "@Author", author);
                DBHelper.AddParameters(2, "@CategoryId", categoryId);
                DBHelper.AddParameters(3, "@PublisherId", publisherId);
                DBHelper.AddParameters(4, "@ISBN", ISBN);
                DBHelper.AddParameters(5, "@PublishDate", publishDate);
                DBHelper.AddParameters(6, "@UnitPrice", unitPrice);
                DBHelper.AddParameters(7, "@WordsCount", wordsCount);
                DBHelper.AddParameters(8, "@ContentDescription", contentDescription);
                DBHelper.AddParameters(9, "@ImgUrl", imgUrl);
                DBHelper.AddParameters(10, "@Id", id);
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
