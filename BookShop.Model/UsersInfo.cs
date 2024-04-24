using System;

namespace BookShop.Model
{
    /// <summary>
    /// 成员表
    /// </summary>
    [Serializable]
    public class UsersInfo
    {
        public UsersInfo()
        { }
        #region Model
        private int _id;
        private string _loginid;
        private string _loginpwd;
        private string _name;
        private string _address;
        private string _phone;
        private string _mail;
        private UserRolesInfo _userRoles;
        private UserStatesInfo _userStates;
        private DateTime _regdate = DateTime.Now;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LoginId
        {
            set { _loginid = value; }
            get { return _loginid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LoginPwd
        {
            set { _loginpwd = value; }
            get { return _loginpwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mail
        {
            set { _mail = value; }
            get { return _mail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public UserRolesInfo UserRoles
        {
            set { _userRoles = value; }
            get { return _userRoles; }
        }
        /// <summary>
        /// 
        /// </summary>
        public UserStatesInfo UserStates
        {
            set { _userStates = value; }
            get { return _userStates; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime RegDate
        {
            set { _regdate = value; }
            get { return _regdate; }
        }
        #endregion Model

    }
}
