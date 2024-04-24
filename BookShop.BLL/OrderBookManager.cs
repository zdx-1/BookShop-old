using BookShop.DAL;
using BookShop.Model;
using System.Collections.Generic;


namespace BookShop.BLL
{
    public static class OrderBookManager
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
            return OrderBookService.GetAddOrderBooks(orderId, bookId, number, unitPrice);
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
            return OrderBookService.GetAspNetPager_PageCount(ordersId);
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
            return OrderBookService.GetOrderBooksPageLoad(ordersId,pageindex);
        }

        #endregion

    }
}
