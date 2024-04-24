using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BookShop.Common.DB
{
    /// <summary>
    /// 创建接口
    /// </summary>
   public interface IDBManager
    {
       DataProvider ProviderType
       {
           get;
           set;
       }

       IDbConnection Connection
       {
           get;
           set;
       }

       IDataReader DataReader
       {
           get;
           set;
       }

       IDbCommand Command
       {
           get;
           set;
       }

       IDbTransaction Transaction
       {
           get;
           set;
       }

       IDbDataParameter[] Parameters
       {
           get;
           set;
       }

       string ConnectionString
       {
           get;
           set;
       }

       void Open();
       void Close();
       void Dispose();
       void CreateParameters(int paramsCount);
       void AddParameters(int index, string paramName, object objValue);
       void BeginTransaction();
       void CommitTransaction();
       void CloseReader();
       IDataReader ExecuteReader(CommandType commandType, string commandText);
       int ExecuteNonQuery(CommandType commandType, string commandText);
       object ExecuteScalar(CommandType commandType, string commandText);
       DataSet ExecuteDataSet(CommandType commandType,string commandText);
       DataTable ExecuteDataTable(CommandType commandType, string commandText);
    }
}
