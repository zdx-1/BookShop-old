using System;
namespace BookShop.Model
{
	/// <summary>
	/// 图书订单信息表
	/// </summary>
	[Serializable]
	public class OrdersInfo
	{
        public OrdersInfo()
		{}
		#region Model
		private int _id;
		private DateTime _orderdate;
        private UsersInfo _users;
		private decimal _totalprice;
		private int _orderstate=1;
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
		public DateTime OrderDate
		{
			set{ _orderdate=value;}
			get{return _orderdate;}
		}
		/// <summary>
		/// 
		/// </summary>
        public UsersInfo Users
		{
            set { _users = value; }
            get { return _users; }
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal TotalPrice
		{
			set{ _totalprice=value;}
			get{return _totalprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int OrderState
		{
			set{ _orderstate=value;}
			get{return _orderstate;}
		}
		#endregion Model

	}
}

