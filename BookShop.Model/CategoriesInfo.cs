using System;
namespace BookShop.Model
{
	/// <summary>
	/// 图书分类信息表
	/// </summary>
	[Serializable]
	public class CategoriesInfo
	{
        public CategoriesInfo()
		{}
		#region Model
		private int _id;
		private string _name;
		private int _deleteflag=0;
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
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DeleteFlag
		{
			set{ _deleteflag=value;}
			get{return _deleteflag;}
		}
		#endregion Model

	}
}

