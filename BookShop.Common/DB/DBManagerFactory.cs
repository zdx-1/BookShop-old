using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Data.OleDb;
using System;
using MySql.Data.MySqlClient;


namespace BookShop.Common.DB
{
    public sealed class DBManagerFactory : IDisposable
    {
        private DBManagerFactory()
        { }

        public void Dispose() { }
        /// <summary>
        /// 取得连接对象
        /// </summary>
        public static IDbConnection GetConnection(DataProvider providerType)
        {
            IDbConnection IDbConnection;
            switch (providerType)
            {
                case DataProvider.MySql:
                    IDbConnection = new MySqlConnection();
                    break;
                case DataProvider.Odbc:
                    IDbConnection = new OdbcConnection();
                    break;
                case DataProvider.SqlServer:
                    IDbConnection = new SqlConnection();
                    break;
                case DataProvider.OleDb:
                    IDbConnection = new OleDbConnection();
                    break;
                default:
                    return null;
            }
            return IDbConnection;
        }

        /// <summary>
        /// 取得IDbCommand接口
        /// </summary>
        /// <param name="providerType"></param>
        /// <returns></returns>
        public static IDbCommand GetCommand(DataProvider providerType)
        {
            switch (providerType)
            {
                case DataProvider.MySql:
                    return new MySqlCommand();
                case DataProvider.Odbc:
                    return new OdbcCommand();
                case DataProvider.SqlServer:
                    return new SqlCommand(); 
                case DataProvider.OleDb:
                    return new OleDbCommand();
                default:
                    return null;
                    
            }
        }

        /// <summary>
        /// 取得数据适配器IDbDataAdapter接口
        /// </summary>
        /// <param name="providerType"></param>
        /// <returns></returns>
        public static IDbDataAdapter GetDataAdapter(DataProvider providerType)
        {
            switch (providerType)
            {
                case DataProvider.MySql:
                    return new MySqlDataAdapter();
                case DataProvider.Odbc:
                    return new OdbcDataAdapter();
                case DataProvider.SqlServer:
                    return new SqlDataAdapter();
                case DataProvider.OleDb:
                    return new OleDbDataAdapter();
                default:
                    return null;
            }
        }

        public static IDbTransaction GetTransaction(DataProvider providerType)
        {
            IDbConnection iDbConnection = GetConnection(providerType);
            IDbTransaction iDbTransaction = iDbConnection.BeginTransaction();

            return iDbTransaction;
        }

        public static IDbDataParameter[] GetParameters(DataProvider providerType, int paramsCount)
        {
            IDbDataParameter[] idbParams = new IDbDataParameter[paramsCount];

            switch(providerType)
            {
                case DataProvider.MySql:
                    for(int i = 0; i < paramsCount; i++)
                    {
                        idbParams[i]=new MySqlParameter();
                    }
                    break;
                case DataProvider.Odbc:
                    for(int i=0;i<paramsCount;i++)
                    {
                        idbParams[i]=new OdbcParameter();
                    }
                    break;
                case DataProvider.SqlServer:
                    for (int i = 0; i < paramsCount; i++)
                    {
                        idbParams[i] = new SqlParameter();
                    }
                    break;
                case DataProvider.OleDb:
                    for (int i = 0; i < paramsCount; i++)
                    {
                        idbParams[i] = new OleDbParameter();
                    }
                    break;
                default:
                    idbParams = null;
                    break;
            }
            return idbParams;
        }
    }
}
