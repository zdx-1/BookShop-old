using BookShop.Common.DB;
using BookShop.Model;
using System;
using System.Collections.Generic;
using System.Data;


namespace BookShop.DAL
{
    public static class OrderService
    {
        #region 前台
        #endregion
        //已修改
        #region  对订单表Orders表添加记录方法

        /// <summary>
        /// 对订单表Orders表添加记录方法
        /// </summary>
        /// <param name="orderDate">添加时间</param>
        /// <param name="userId">用户编号</param>
        /// <param name="TotalPrices">订单总价格</param>
        /// <returns></returns>
        public static bool GetAddOrders(DateTime orderDate, int userId, decimal TotalPrices)
        {
            bool result = false;
            string sql= "insert into Orders(OrderDate,UserId,TotalPrice ,OrderState) values(@OrderDate,@UserId,@TotalPrice ,0)";
            try
            {
                DBHelper.CreateParameters(3);
                DBHelper.AddParameters(0, "@OrderDate", orderDate);
                DBHelper.AddParameters(1, "@UserId", userId);
                DBHelper.AddParameters(2, "@TotalPrice", TotalPrices);
                result = DBHelper.ExecuteNonQuery(sql) > 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }

        #endregion
        //已修改
        #region  获取刚添加订单表Oders表内记录的主键的方法

        /// <summary>
        /// 获取刚添加订单表Oders表内记录的主键的方法
        /// </summary>
        /// <param name="orderDate"></param>
        /// <param name="userId"></param>
        /// <param name="TotalPrices"></param>
        /// <returns></returns>
        public static int GetExistAddOrder(int userId, decimal TotalPrices)
        {
            string sql="select Id from Orders where UserId=@UserId and TotalPrice=@TotalPrice order by OrderDate desc limit 1";
            try
            {
                DBHelper.CreateParameters(2);
                DBHelper.AddParameters(0,"@UserId",userId);
                DBHelper.AddParameters(1,"@TotalPrice",TotalPrices);
                object result= DBHelper.ExecuteScalar(sql);
                if (result != null) {
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

        #region 后台
        #endregion
        //已修改
        #region  AspNetPager控件分页数获取方法

        /// <summary>
        /// AspNetPager控件分页数获取方法
        /// </summary>
        /// <returns></returns>
        public static int GetAspNetPager_PageCount()
        {
            object result = 0;
            string sql = "select count(Id) as count from Orders";
            try
            {
                result = DBHelper.ExecuteScalar(sql);
                if(result !=null)
                {
                    return Convert.ToInt32(result);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return 0;
        }

        #endregion
        //已修改
        #region  初始化用户浏览方法

        /// <summary>
        /// 初始化用户浏览方法
        /// </summary>
        /// <returns></returns>
        public static IList<OrdersInfo> GetShoppingCartList(int pageindex)
        {
            //string strSQL = " Id NOT IN (SELECT TOP " + 10 * (pageindex - 1) + "Id from Orders order by OrderDate desc)";
            //string sql = "select top 10 Id,OrderDate,TotalPrice,UserId from Orders where" + strSQL + " order by OrderDate desc";
            string sqlPlus = "select Id,OrderDate,TotalPrice,UserId from Orders order by OrderDate desc limit "+10*(pageindex-1)+",10";
            List<OrdersInfo> list = new List<OrdersInfo>();
            try
            {
                IDataReader reader = DBHelper.ExecuteReader(sqlPlus);
                while (reader.Read())
                {
                    OrdersInfo ordersInfo = new OrdersInfo();
                    ordersInfo.Id = Convert.ToInt32(reader["Id"]);
                    ordersInfo.OrderDate = DateTime.Parse(reader["OrderDate"].ToString());
                    ordersInfo.TotalPrice = Decimal.Parse(reader["TotalPrice"].ToString());
                    ordersInfo.Users = UserService.GetSelectUserInfoById(Convert.ToInt32(reader["UserId"]));
                    list.Add(ordersInfo);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        #endregion
        //存在疑问
        #region  初始化订单基本信息浏览

        /// <summary>
        /// 初始化订单基本信息浏览
        /// </summary>
        /// <param name="ordersId"></param>
        /// <returns></returns>
        public static DataTable GetOrdersPageLoad(int id)
        {
            DataTable dt;
            string sql = "select Orders.Id OrdersId,OrderDate,TotalPrice,LoginId,Users.Name LoginName,Phone,Mail,Address from Orders,Users where Orders.UserId=Users.Id and Orders.Id=@OrdersId";
            
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0, "@OrdersId",id);
                dt = DBHelper.ExecuteDataTable(sql);  
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dt;
        }

        #endregion
    }
}
