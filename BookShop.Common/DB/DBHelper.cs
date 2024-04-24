using System;
using System.Data;
using System.Configuration;

namespace BookShop.Common.DB
{
    public static class DBHelper
    {

        private static readonly IDBManager dbManager = new DBManager(GetDataProvider(), GetConnectionString());

        /// <summary>
        /// 从配置文件中选择数据库类型
        /// </summary>
        /// <returns>DataProvider枚举值</returns>
        private static DataProvider GetDataProvider()
        {
            string providerType = ConfigurationManager.AppSettings["DataProvider"];
            DataProvider dataProvider;
            switch (providerType)
            {
                case "MySql":
                    dataProvider = DataProvider.MySql; 
                    break;
                case "Odbc":
                    dataProvider = DataProvider.Odbc;
                    break;
                case "SqlServer":
                    dataProvider = DataProvider.SqlServer;
                    break;
                case "OleDb":
                    dataProvider = DataProvider.OleDb;
                    break;
                default:
                    return DataProvider.SqlServer;
            }
            return dataProvider;
        }

        /// <summary>
        /// 从配置文件获取连接字符串
        /// </summary>
        /// <returns>连接字符串</returns>
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["BookShopWeb.ConnectionString"].ConnectionString;
        }

        /// <summary>
        /// 关闭数据库连接的方法
        /// </summary>
        public static void Close()
        {
            dbManager.Dispose();
        }

        /// <summary>
        /// 创建参数
        /// </summary>
        /// <param name="paramsCount">参数个数</param>
        public static void CreateParameters(int paramsCount)
        {
            dbManager.CreateParameters(paramsCount);
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="index">参数索引</param>
        /// <param name="paramName">参数名</param>
        /// <param name="objValue">参数值</param>
        public static void AddParameters(int index, string paramName, object objValue)
        {
            dbManager.AddParameters(index, paramName, objValue);
        }

        /// <summary>
        /// 执行增删改、非查询的调用,仅SQL语句
        /// </summary>
        /// <param name="sqlString">安全的sql语句string.Format()</param>
        /// <returns>操作成功返回非0正数</returns>
        public static int ExecuteNonQuery(string sqlString)
        {
            try
            {
                dbManager.Open();
                return dbManager.ExecuteNonQuery(CommandType.Text, sqlString);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                dbManager.Dispose();
            }
        }

        /// <summary>
        /// 返回基于连接的数据记录，仅SQL语句
        /// </summary>
        /// <param name="sqlString">安全的sql语句string.Format()</param>
        /// <returns>返回IDataReader</returns>
        public static IDataReader ExecuteReader(string sqlString)
        {
            try
            {
                dbManager.Open();
                return dbManager.ExecuteReader(CommandType.Text, sqlString);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
          
        }

        /// <summary>
        /// 执行返回第一行第一列
        /// </summary>
        /// <param name="sqlString">安全的sql语句string.Format()</param>
        /// <returns>返回object</returns>
        public static object ExecuteScalar(string sqlString)
        {
            try
            {
                dbManager.Open();
                return dbManager.ExecuteScalar(CommandType.Text, sqlString);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                dbManager.Dispose();
            }
        }

        /// <summary>
        /// 返回基于非连接的数据记录，仅SQL语句。
        /// </summary>
        /// <param name="sqlString">安全的sql语句string.Format()</param>
        /// <returns>返回DataTable</returns>
        public static DataTable ExecuteDataTable(string sqlString)
        {
            try
            {
                dbManager.Open();
                return dbManager.ExecuteDataTable(CommandType.Text, sqlString);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                dbManager.Dispose();
            }
        }

        /// <summary>
        /// 返回基于非连接的数据记录，仅SQL语句。
        /// </summary>
        /// <param name="sqlString">安全的sql语句string.Format()</param>
        /// <returns>返回DataSet</returns>
        public static DataSet ExecuteDataSet(string sqlString)
        {
            try
            {
                dbManager.Open();
                return dbManager.ExecuteDataSet(CommandType.Text, sqlString);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                dbManager.Dispose();
            }
        }
    }
}
