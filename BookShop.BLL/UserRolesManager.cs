using BookShop.DAL;

namespace BookShop.BLL
{
    public static class UserRolesManager
    {

        #region  显示用户权限颜色转换前的读取状态编号的方法

        /// <summary>
        /// 显示用户权限颜色转换前的读取状态编号的方法
        /// </summary>
        /// <param name="userStatesName">状态名</param>
        /// <returns></returns>
        public static int GetUserRolesByName(string name)
        {
            return UserRolesService.GetUserRolesByName(name);
        }

        #endregion

    }
}
