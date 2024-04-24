using System;
namespace BookShop.Model
{
	/// <summary>
	/// 图书订单详细表
	/// </summary>
	[Serializable]
	public class OrderBooksInfo
	{
        public OrderBooksInfo()
		{}
		#region Model
		private int _id;
        private OrdersInfo _orders;
        private BooksInfo _books;
		private int _quantity;
		private decimal _unitprice=0M;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
        public OrdersInfo Orders
		{
			set{ _orders=value;}
			get{return _orders;}
		}
		/// <summary>
		/// 
		/// </summary>
        public BooksInfo Books
		{
            set { _books = value; }
            get { return _books; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int Quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal UnitPrice
		{
			set{ _unitprice=value;}
			get{return _unitprice;}
		}
		#endregion Model

	}
}

