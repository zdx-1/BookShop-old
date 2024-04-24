using System;
using System.Collections.Generic;

namespace BookShop.Model
{
    [Serializable]
    public class CartInfo
    {
        public CartInfo()
        { }
        #region Model
        private List<CartItemInfo> _items = new List<CartItemInfo>();
        private int _totalQuantity;
        private decimal _totalPrice;

        public List<CartItemInfo> Items
        {
            get { return _items; }
            set { _items = value; }
        }
        public int TotalQuantity
        { get; set; }
        public decimal TotalPrice
        { get; set; }

        #endregion
    }
}
