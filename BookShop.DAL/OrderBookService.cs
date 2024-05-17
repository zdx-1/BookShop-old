using BookShop.Common.DB;
using BookShop.Model;
using System;
using System.Collections.Generic;
using System.Data;


namespace BookShop.DAL
{
    public static class OrderBookService
    {

        #region 前台
        #endregion
        
        #region  点击结算OrderBooks表添加记录的方法

        /// <summary>
        /// 点击结算OrderBooks表添加记录的方法
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="bookId"></param>
        /// <param name="number"></param>
        /// <param name="unitPrice"></param>
        public static int GetAddOrderBooks(int orderId, int bookId, int number, decimal unitPrice)
        {
            int result=0;
            string sql="insert into OrderBooks(OrderID,BookID,Quantity,UnitPrice) values(@OrderID,@BookID,@Quantity,@UnitPrice)";
            try
            {
                DBHelper.CreateParameters(4);
                DBHelper.AddParameters(0,"@OrderID",orderId);
                DBHelper.AddParameters(1,"@BookID",bookId);
                DBHelper.AddParameters(2,"@Quantity",number);
                DBHelper.AddParameters(3,"@UnitPrice",unitPrice);
                result= DBHelper.ExecuteNonQuery(sql);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }

        #endregion

        #region 后台
        #endregion
        
        #region  AspNetPager控件分页数获取方法 （后台订单详细信息浏览）

        /// <summary>
        /// AspNetPager控件分页数获取方法 （后台订单详细信息浏览）
        /// </summary>
        /// <returns></returns>
        public static int GetAspNetPager_PageCount(int ordersId)
        {
            
            string sql = "select count(Id) count from OrderBooks where OrderID=@OrderID";
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0, "@OrderID", ordersId);
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
        
        #region  初始化订单详细信息浏览

        /// <summary>
        /// 初始化订单详细信息浏览
        /// </summary>
        /// <param name="ordersId"></param>
        /// <returns></returns>
        public static IList<OrderBooksInfo> GetOrderBooksPageLoad(int ordersId, int pageindex)
        {
            //string strSQL = " Id NOT IN (SELECT TOP " + 5 * (pageindex - 1) + " Id from OrderBooks where OrderID=@OrderID)";
            //string sql = "select top 5 Id,UnitPrice,Quantity,OrderID,BookID from OrderBooks where" + strSQL + " and OrderID=@OrderID";
            string sqlPlus = "select Id,UnitPrice,Quantity,OrderID,BookID from OrderBooks where OrderID=@OrderID limit "+5*(pageindex-1)+",5";
            List<OrderBooksInfo> list = new List<OrderBooksInfo>();
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0, "@OrderID",ordersId);
                IDataReader reader = DBHelper.ExecuteReader(sqlPlus);
                while (reader.Read())
                {
                    OrderBooksInfo orderBooksInfo = new OrderBooksInfo();
                    orderBooksInfo.Id = Convert.ToInt32(reader["Id"]);
                    orderBooksInfo.UnitPrice = Decimal.Parse(reader["UnitPrice"].ToString());
                    orderBooksInfo.Quantity = Convert.ToInt32(reader["Quantity"]);
                    orderBooksInfo.Books = BookService.GetSelectBooksInfoById(Convert.ToInt32(reader["BookID"]));  

                    list.Add(orderBooksInfo);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        #endregion
        
        #region  删除前判断订单表内是否已有关联的方法

        /// <summary>
        /// 删除前判断订单表内是否已有关联的方法
        /// </summary>
        /// <returns></returns>
        public static bool GetSelectBooks(int id)
        {
            bool result = false;
            string sql="select Id from OrderBooks where BookID=@BookID";
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0, "@BookID", id);
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
    }
}
