using System;

namespace BookShop.Model
{
    [Serializable]
    public class CartItemInfo
    {
        public CartItemInfo()
        { }
        #region Model
        private BooksInfo _book;   //所购买图书
        private int _quantity;    //购买数量
        private decimal _subTotal; //小计金额
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public BooksInfo Book
        {
            get { return _book; }
            set { _book = value; }
        }
  
        public decimal SubTotal
        {
            get { return _subTotal; }
            set { _subTotal = value; }
        }

        #endregion
    }
}
