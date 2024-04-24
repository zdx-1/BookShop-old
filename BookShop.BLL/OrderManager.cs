using BookShop.DAL;
using BookShop.Model;
using System;
using System.Collections.Generic;
using System.Data;


namespace BookShop.BLL
{
    public static class OrderManager
    {

        #region 前台
        #endregion

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
            return OrderService.GetAddOrders(orderDate, userId, TotalPrices);
        }

        #endregion

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
            return OrderService.GetExistAddOrder(userId,TotalPrices);
        }

        #endregion

        #region 后台
        #endregion

        #region  AspNetPager控件分页数获取方法

        /// <summary>
        /// AspNetPager控件分页数获取方法
        /// </summary>
        /// <returns></returns>
        public static int GetAspNetPager_PageCount()
        {
            return OrderService.GetAspNetPager_PageCount();
        }

        #endregion

        #region  初始化用户浏览方法

        /// <summary>
        /// 初始化用户浏览方法
        /// </summary>
        /// <returns></returns>
        public static IList<OrdersInfo> GetShoppingCartList(int pageindex)
        {
            return OrderService.GetShoppingCartList(pageindex);
        }

        #endregion

        #region  初始化订单基本信息浏览

        /// <summary>
        /// 初始化订单基本信息浏览
        /// </summary>
        /// <param name="ordersId"></param>
        /// <returns></returns>
        public static DataTable GetOrdersPageLoad(int id)
        {
            return OrderService.GetOrdersPageLoad(id);
        }

        #endregion

    }
}
