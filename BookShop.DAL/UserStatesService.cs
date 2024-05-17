using BookShop.Common.DB;
using BookShop.Model;
using System;
using System.Data;


namespace BookShop.DAL
{
    public static class UserStatesService
    {
        
        #region 成员状态查询

        /// <summary>
        ///  成员状态查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static UserStatesInfo GetUserStatesById(int id)
        {
            string sql = "select Id,Name from UserStates where Id=@Id";
            UserStatesInfo userStatesInfo = new UserStatesInfo();
            try
            {
                //先创建参数，然后才能添加参数 

                DBHelper.CreateParameters(1);  //参数个数，1个
                DBHelper.AddParameters(0, "@Id", id);
                DataTable dt = DBHelper.ExecuteDataTable(sql);
                foreach (DataRow row in dt.Rows)
                {
                    userStatesInfo.Id = Convert.ToInt32(row["Id"]);
                    userStatesInfo.Name = row["Name"].ToString();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return userStatesInfo;
        }

        #endregion

        
        #region  显示用户状态颜色转换前的读取状态编号的方法

        /// <summary>
        /// 显示用户状态颜色转换前的读取状态编号的方法
        /// </summary>
        /// <param name="userStatesName">状态名</param>
        /// <returns></returns>
        public static int GetUserStatesByName(string name)
        {
            object result;
            string sql="select Id from UserStates where Name=@Name";
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0,"@Name",name);
                result=DBHelper.ExecuteScalar(sql);
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else 
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion
    }
}
