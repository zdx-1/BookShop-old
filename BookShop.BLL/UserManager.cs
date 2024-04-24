using BookShop.DAL;
using BookShop.Model;
using System.Collections.Generic;


namespace BookShop.BLL
{
    public static class UserManager
    {
        #region 前台部分
        #endregion

        #region (前台）登录是否成功判断方法
        /// <summary>
        /// 登录是否成功判断方法
        /// </summary>
        /// <param name="loginId">用户名</param>
        /// <param name="loginPwd">密码</param>
        /// <returns>返回int类型</returns>
        public static int CheckValidUser(string loginId, string loginPwd)
        {
            return UserService.CheckValidUser(loginId, loginPwd);
        }

        #endregion

        #region 个人信息显示

        /// <summary>
        /// 个人信息显示
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public static IList<UsersInfo> GetUserInfoList(string loginId)
        {
            return UserService.GetUserInfoList(loginId);
        }

        #endregion

        #region （前台）检验输入用户名是否已存在方法

        /// <summary>
        /// 检验输入用户名是否已存在方法
        /// </summary>
        /// <param name="loginId">用户名</param>
        /// <param name="mail">E-Mail电子邮箱</param>
        /// <returns>返回bool类型值</returns>
        public static bool GetbtnSelect(string loginId, string mail)
        {
            return UserService.GetbtnSelect(loginId, mail);
        }

        #endregion

        #region 用户注册方法

        /// <summary>
        /// 用户注册方法
        /// </summary>
        /// <param name="loginId">用户名</param>
        /// <param name="loginPwd">密码</param>
        /// <param name="name">姓名</param>
        /// <param name="address">地址</param>
        /// <param name="phone">电话或手机号码</param>
        /// <param name="mail">E-mail</param>
        /// <returns>返回int类型值</returns>
        public static int GetExecuteNonQuery(string loginId, string loginPwd, string name, string address, string phone, string mail)
        {
            return UserService.GetExecuteNonQuery(loginId, loginPwd, name, address, phone, mail);
        }

        #endregion

        #region  获取Users表内个人的主键的方法

        /// <summary>
        /// 获取Users表内个人的主键的方法
        /// </summary>
        /// <param name="orderDate"></param>
        /// <param name="userId"></param>
        /// <param name="TotalPrices"></param>
        /// <returns></returns>
        public static int GetUsersId(string loginId)
        {
            return UserService.GetUsersId(loginId);
        }

        #endregion

        #region  修改密码方法

        /// <summary>
        /// 修改密码方法
        /// </summary>
        /// <param name="loginId">用户名</param>
        /// <param name="newloginPwd">新密码</param>
        /// <returns>返回bool类型值</returns>
        public static bool GetExecuteUpdate(string loginId, string newloginPwd)
        {
            return UserService.GetExecuteUpdate(loginId, newloginPwd); 
        }

        #endregion

        #region 后台部分
        #endregion

        #region  校验用户合法性。

        /// <summary>
        /// 校验用户合法性。
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>0/-1/-2/-3/-4</returns>
        public static int CheckValidAdmin(string loginId, string loginPwd)
        {
            return UserService.CheckValidAdmin(loginId, loginPwd);
        }

        #endregion

        #region  AspNetPager控件分页数获取方法

        /// <summary>
        /// AspNetPager控件分页数获取方法
        /// </summary>
        /// <returns></returns>
        public static int GetAspNetPager_PageCount()
        {
            return UserService.GetAspNetPager_PageCount();
        }

        #endregion

        #region  初始化用户浏览方法

        /// <summary>
        /// 初始化用户浏览方法
        /// </summary>
        /// <returns></returns>
        public static IList<UsersInfo> GetUserList(int pageindex)
        {
             return UserService.GetUserList(pageindex);
        }

        #endregion

        #region  用户删除方法

        /// <summary>
        /// 用户删除方法
        /// </summary>
        /// <param name="id"></param>
        public static bool DeleteUsersById(string id)
        {
            return UserService.DeleteUsersById(id);
        }

        #endregion   

        #region  用户编辑前判断状态方法

        /// <summary>
        /// 用户编辑前判断状态方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static int GetUpdateUsersById(int id)
        {
            return UserService.GetUpdateUsersById(id);
        }

        #endregion

        #region  用户编辑方法

        /// <summary>
        /// 用户编辑方法
        /// </summary>
        /// <param name="id"></param>
        public static bool UpdateUsersById(int id)
        {
            if (GetUpdateUsersById(id) == 1)
            {
                return UserService.UpdateUsersById1(id);
            }
            else
            {
                return UserService.UpdateUsersById2(id);
            }
        }

        #endregion



    }
}
