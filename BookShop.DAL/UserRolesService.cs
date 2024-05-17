using BookShop.Common.DB;
using BookShop.Model;
using System;
using System.Data;


namespace BookShop.DAL
{
    public static class UserRolesService
    {
        
        #region 成员权限查询

        /// <summary>
        ///  成员权限查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static UserRolesInfo GetUserRolesById(int id)
        {
            string sql = "select Id,Name from UserRoles where Id=@Id";
            UserRolesInfo userRolesInfo = new UserRolesInfo();
            try
            {
                //先创建参数，然后才能添加参数 

                DBHelper.CreateParameters(1);  //参数个数，1个
                DBHelper.AddParameters(0, "@Id", id);
                DataTable dt = DBHelper.ExecuteDataTable(sql);
                foreach (DataRow row in dt.Rows)
                {
                    userRolesInfo.Id = Convert.ToInt32(row["Id"]);
                    userRolesInfo.Name = row["Name"].ToString();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return userRolesInfo;
        }

        #endregion
        
        #region  显示用户权限颜色转换前的读取状态编号的方法

        /// <summary>
        /// 显示用户权限颜色转换前的读取状态编号的方法
        /// </summary>
        /// <param name="userStatesName">状态名</param>
        /// <returns></returns>
        public static int GetUserRolesByName(string name)
        {
         
            string sql = "select Id from UserRoles where Name=@Name";
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0, "@Name", name);
                object result = DBHelper.ExecuteScalar(sql);
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else { return 0; }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion

    }
}
