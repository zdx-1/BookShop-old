using System;
namespace BookShop.Model
{
	/// <summary>
	/// 成员权限表
	/// </summary>
	[Serializable]
	public class UserRolesInfo
	{
        public UserRolesInfo()
		{}
		#region Model
		private int _id;
		private string _name;
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
		#endregion Model

	}
}

