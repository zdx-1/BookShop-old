

using BookShop.DAL;
using BookShop.Model;

namespace BookShop.BLL
{
    public static class CartManager
    {
        #region 创建购物车

        /// <summary>
        /// 创建购物车
        /// </summary>
        public static CartInfo BuildCart()
        {
            //定义购物车结构
            CartInfo cart = new CartInfo();

            return cart;
        }

        #endregion

        #region  向购物车新增图书

        /// <summary>
        /// 向购物车新增图书
        /// </summary>
        /// <param name="bookId">图书编号</param>
        /// <param name="bookName">图书名称</param>
        /// <param name="number">数量</param>
        /// <param name="unitPrice">单价</param>
        private static CartInfo AppendBooks(CartInfo cart, BooksInfo book, int number)
        {
            //创建购物车图书项
            CartItemInfo item = new CartItemInfo();
            item.Book = book;
            item.Quantity = number;
            //计算小计
            item.SubTotal = item.Book.UnitPrice * item.Quantity;
            cart.Items.Add(item);

            //当前购物车总数量、总价增加新增额
            cart.TotalQuantity += item.Quantity;
            cart.TotalPrice += item.SubTotal;

            return cart;
        }

        #endregion

        #region  判断购物车是否有同ID图书

        /// <summary>
        /// 判断购物车是否有同ID图书
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        private static bool ExistBook(CartInfo cart, BooksInfo book)
        {
            //遍历购物车每行，判断是否有同ID图书，返回是或否
            foreach (CartItemInfo item in cart.Items)   //逐行读取购物车并判断
            {
                //如果当前图书ID相等，则返回真
                if (item.Book.Id == book.Id)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region  在购物车中删除所购图书项

        /// <summary>
        /// 在购物车中删除所购图书项 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static CartInfo DeleteBook(CartInfo cart, int bookId)
        {
            for (int i = 0; i < cart.Items.Count; i++)
            {
                if (cart.Items[i].Book.Id == bookId)
                {
                    //当前购物车总数量、总价
                    //减去删除图书的数量和小计额
                    cart.TotalQuantity -= cart.Items[i].Quantity;
                    cart.TotalPrice -= cart.Items[i].SubTotal;
                    //从购物车中移除该图书项
                    cart.Items.RemoveAt(i);
                }
            }
            return cart;
        }

        #endregion

        #region  增加某图书项数量

        /// <summary>
        /// 增加某图书项数量 
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="number"></param>
        private static CartInfo IncreaseBook(CartInfo cart, BooksInfo book, int number)
        {
            foreach (CartItemInfo item in cart.Items)
            {
                if (item.Book.Id == book.Id)
                {
                    //图书数量累加新增额，小计重新计算
                    item.Quantity += number;
                    item.SubTotal = item.Book.UnitPrice * item.Quantity;
                    //购物车图书总数量、总价累加新增额
                    cart.TotalQuantity += number;
                    cart.TotalPrice += item.Book.UnitPrice * number;
                }
            }
            return cart;
        }

        #endregion

        #region  更新购物车中某图书数量

        /// <summary>
        /// 更新购物车中某图书数量
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="number"></param>
        public static CartInfo UpdateBooks(CartInfo cart, string imgImgUrl, int number)
        {
            foreach (CartItemInfo item in cart.Items)
            {
                if (item.Book.ImgUrl == imgImgUrl)
                {
                    //购物车中总数量、总价累加差额部分(可正、可负) 
                    cart.TotalQuantity += number - item.Quantity; ;
                    cart.TotalPrice += item.Book.UnitPrice * (number - item.Quantity); ;

                    //当前图书数量为设定值，小计项重新计算
                    item.Quantity = number;
                    item.SubTotal = item.Book.UnitPrice * item.Quantity;
                }
            }
            return cart;
        }

        #endregion

        #region 图书取值方法（购买图书流程过渡页）

        /// <summary>
        /// 图书取值方法（购买图书流程过渡页）
        /// </summary>
        /// <param name="id"></param>
        private static BooksInfo GetPageLoad(int id)
        {
            return CartService.GetPageLoad(id);
        }

        #endregion

        #region  买书判断购物车状态方法

        /// <summary>
        /// 买书判断购物车状态方法
        /// </summary>
        /// <param name="bookId"></param>
        public static CartInfo BuyBook(CartInfo cart, int bookId)
        {
            BooksInfo book = CartManager.GetPageLoad(bookId);

            if (ExistBook(cart, book))
            {
                //已有图书，更新数量到购物车
                cart = IncreaseBook(cart, book, 1);
            }
            else
            {
                //没有同样图书，追加新图书到购物车
                cart = AppendBooks(cart,book,1);
            }
            return cart;             
        }

        #endregion

    }
}
