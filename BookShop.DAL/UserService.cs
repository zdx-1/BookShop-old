using BookShop.Common.DB;
using BookShop.Model;
using System;
using System.Collections.Generic;
using System.Data;


namespace BookShop.DAL
{
    public static class UserService
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
            int errld = 0;

            try
            {
                string sql = "select LoginPwd,UserStateId,UserRoleId from Users where LoginId=@LoginId";
                //先创建参数，然后才能添加参数 

                DBHelper.CreateParameters(1);  //参数个数，1个
                DBHelper.AddParameters(0, "@LoginId", loginId);
                IDataReader reader = DBHelper.ExecuteReader(sql);
                if (reader.Read())
                {
                    if (loginPwd != reader["LoginPwd"].ToString())
                    {
                        errld = -3;  //密码错误
                    }
                    else if (Convert.ToInt32(reader["UserStateId"].ToString()) != 1)
                    {
                        errld = -2;  //用户已被禁用或删除
                    }
                    else if (Convert.ToInt32(reader["UserRoleId"].ToString()) == 3)
                    {
                        errld = -1;  //权限不足
                    }
                    else if (Convert.ToInt32(reader["UserRoleId"].ToString()) == 1)
                    {
                        errld = 1;   //普通会员
                    }
                    else if (Convert.ToInt32(reader["UserRoleId"].ToString()) == 2)
                    {
                        errld = 2;    //VIP会员
                    }
                    else
                    {
                        return 404;
                    }
                }
                else
                {
                    errld = -3;//用户不存在
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                DBHelper.Close();
            }

            return errld;
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
            string sql = "select LoginId,UserRoleId,Name,Address,Phone,Mail,RegDate from Users where LoginId=@LoginId";
            List<UsersInfo> list = new List<UsersInfo>();
            try
            {
                //先创建参数，然后才能添加参数 

                DBHelper.CreateParameters(1);  //参数个数，1个
                DBHelper.AddParameters(0, "@LoginId", loginId);
                DataTable dt = DBHelper.ExecuteDataTable(sql);
                foreach (DataRow row in dt.Rows)
                {
                    UsersInfo usersInfo = new UsersInfo();
                    usersInfo.LoginId = row["LoginId"].ToString();
                    usersInfo.Name = row["Name"].ToString();
                    usersInfo.Address = row["Address"].ToString();
                    usersInfo.Phone = row["Phone"].ToString();
                    usersInfo.Mail = row["Mail"].ToString();
                    usersInfo.RegDate = DateTime.Parse(row["RegDate"].ToString());
                    usersInfo.UserRoles = UserRolesService.GetUserRolesById(Convert.ToInt32(row["UserRoleId"]));
                    list.Add(usersInfo);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
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
            bool result = false;
            string sql = "select Id from Users where LoginId=@LoginId or Mail=@Mail";
            try
            {
                DBHelper.CreateParameters(2);
                DBHelper.AddParameters(0, "@LoginId", loginId);
                DBHelper.AddParameters(1, "@Mail", mail);
                IDataReader reader = DBHelper.ExecuteReader(sql);
                if (reader.Read())
                {
                    result = true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                DBHelper.Close();
            }
            return result;
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
            int result = 0;
            string sql = "insert into Users(LoginId,LoginPwd,Name,Address,Phone,Mail,UserRoleId,UserStateId) values(@loginId,@loginPwd,@name,@address,@phone,@mail,1,1)";   //执行数据库新增语句
            try
            {
                DBHelper.CreateParameters(6);
                DBHelper.AddParameters(0, "@loginId", loginId);
                DBHelper.AddParameters(1, "@loginPwd", loginPwd);
                DBHelper.AddParameters(2, "@name", name);
                DBHelper.AddParameters(3, "@address", address);
                DBHelper.AddParameters(4, "@phone", phone);
                DBHelper.AddParameters(5, "@mail", mail);
                result = DBHelper.ExecuteNonQuery(sql);
     
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
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
            
            string sql = "select Id from Users where LoginId=@LoginId";
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0, "@LoginId", loginId);
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
        //存在问题 
        #region  修改密码方法

        /// <summary>
        /// 修改密码方法
        /// </summary>
        /// <param name="loginId">用户名</param>
        /// <param name="newloginPwd">新密码</param>
        /// <returns>返回bool类型值</returns>
        public static bool GetExecuteUpdate(string loginId, string newloginPwd)
        {
            bool result = false;
            string sql = "update Users set LoginPwd=@NewLoginPwd where LoginId=@LoginId";
            try
            {
                DBHelper.CreateParameters(2);
                DBHelper.AddParameters(0, "@NewLoginPwd", newloginPwd);
                DBHelper.AddParameters(1, "@LoginId", loginId);
                result = DBHelper.ExecuteNonQuery(sql) > 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
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
            int errld = 0;      //定义变量
            string sql = "select LoginId,LoginPwd,UserStateId,UserRoleId,Name from Users where LoginId=@LoginId";
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0, "@LoginId", loginId);
                IDataReader reader = DBHelper.ExecuteReader(sql);
                if (reader.Read())  //判断已存在用户状态并返回int类型值
                {
                    if (loginPwd != reader["LoginPwd"].ToString())
                    {
                        errld = -3;     //密码错误
                    }
                    else if (Convert.ToInt32(reader["UserStateId"]) != 1)
                    {
                        errld = -2;     //账号被禁用或删除
                    }
                    else if (Convert.ToInt32(reader["UserRoleId"]) != 3)
                    {
                        errld = -1;     //权限不足
                    }
                    else
                    {
                        errld = 0;   //可以登录
                    }
                }
                else
                {
                    errld = -4;//用户不存在
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return errld;
        }

        #endregion
        
        #region  AspNetPager控件分页数获取方法

        /// <summary>
        /// AspNetPager控件分页数获取方法
        /// </summary>
        /// <returns></returns>
        public static int GetAspNetPager_PageCount()
        {
            object result = 0;
            string sql = "SELECT COUNT(Id) AS count FROM Users WHERE UserStateId != 3";
            try
            {
                result = DBHelper.ExecuteScalar(sql);
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else {
                    return 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
          
        }

        #endregion
        
        #region  初始化用户浏览方法

        /// <summary>
        /// 初始化用户浏览方法
        /// </summary>
        /// <returns></returns>
        public static IList<UsersInfo> GetUserList(int pageindex)
        {
            //string strSQL = " and Id NOT IN (SELECT Id from Users where UserStateId!=3) limit 10";
            //string sql = "select Id,LoginId,Name,Address,Phone,Mail,RegDate,UserStateId,UserRoleId from Users where  UserStateId!=3" + strSQL ;

            string sqlPlus = "select Id,LoginId,Name,Address,Phone,Mail,RegDate,UserStateId,UserRoleId from Users where  UserStateId!=3 limit 10";
            List<UsersInfo> list = new List<UsersInfo>();
            try
            {
                IDataReader reader = DBHelper.ExecuteReader(sqlPlus);
                while (reader.Read())
                {
                    UsersInfo usersInfo = new UsersInfo();
                    usersInfo.Id = Convert.ToInt32(reader["Id"]);
                    usersInfo.LoginId = reader["LoginId"].ToString();
                    usersInfo.Name = reader["Name"].ToString();
                    usersInfo.Address = reader["Address"].ToString();
                    usersInfo.Phone = reader["Phone"].ToString();
                    usersInfo.Mail = reader["Mail"].ToString();
                    usersInfo.RegDate = DateTime.Parse(reader["RegDate"].ToString());
                    usersInfo.UserStates = UserStatesService.GetUserStatesById(Convert.ToInt32(reader["UserStateId"].ToString()));
                    usersInfo.UserRoles = UserRolesService.GetUserRolesById(Convert.ToInt32(reader["UserRoleId"].ToString()));
                    list.Add(usersInfo);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
            
        }

        #endregion    
        
        #region  用户删除方法

        /// <summary>
        /// 用户删除方法
        /// </summary>
        /// <param name="id"></param>
        public static bool DeleteUsersById(string id)
        {
            bool result = false;
            string sql="update Users set UserStateId=3 where Id in (" + id + ")";
            try
            {
                result= DBHelper.ExecuteNonQuery(sql)>0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }    
            return result;
        }

        #endregion
        
        #region  用户编辑前判断状态方法

        /// <summary>
        /// 用户编辑前判断状态方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int GetUpdateUsersById(int id)
        {
            int result =0;
            string sql = "select UserStateId from Users where Id=@Id";
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0,"@Id",id);
                result=(int) DBHelper.ExecuteScalar(sql);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;

        }

        #endregion
        
        #region  用户编辑方法

        /// <summary>
        /// 用户编辑正常时调用方法
        /// </summary>
        /// <param name="id"></param>
        public static bool UpdateUsersById1(int id)
        {
            bool result = false;
            string sql="update Users set UserStateId=2 where Id=@Id";
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0, "@Id",id);
                result= DBHelper.ExecuteNonQuery(sql) > 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;

        }

        /// <summary>
        /// 用户编辑暂停时调用方法
        /// </summary>
        /// <param name="id"></param>
        public static bool UpdateUsersById2(int id)
        {
            bool result = false;
            string sql = "update Users set UserStateId=1 where Id=@Id";
            try
            {
                DBHelper.CreateParameters(1);
                DBHelper.AddParameters(0, "@Id", id);
                result = DBHelper.ExecuteNonQuery(sql) > 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }

        #endregion
        
        #region 订单表会员编号关联查询 （后台订单表浏览）

        /// <summary>
        /// 订单表会员编号关联查询 （后台订单表浏览）
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public static UsersInfo GetSelectUserInfoById(int id)
        {
            string sql = "select LoginId,Name,Phone,Mail,Address,UserRoleId,UserStateId from Users where Id=@Id";
            UsersInfo usersInfo = new UsersInfo();
            try
            {
                //先创建参数，然后才能添加参数 

                DBHelper.CreateParameters(1);  //参数个数，1个
                DBHelper.AddParameters(0, "@Id", id);
                DataTable dt = DBHelper.ExecuteDataTable(sql);
                foreach (DataRow row in dt.Rows)
                {
                    usersInfo.LoginId = row["LoginId"].ToString();
                    usersInfo.Name = row["Name"].ToString();
                    usersInfo.Phone = row["Phone"].ToString();
                    usersInfo.Mail = row["Mail"].ToString();
                    usersInfo.Address = row["Address"].ToString();
                    usersInfo.UserRoles = UserRolesService.GetUserRolesById(Convert.ToInt32(row["UserRoleId"]));
                    usersInfo.UserStates = UserStatesService.GetUserStatesById(Convert.ToInt32(row["UserStateId"]));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return usersInfo;
        }

        #endregion

    }
}
