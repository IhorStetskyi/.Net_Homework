using System.Configuration;
using DapperLib.StaticClasses;
using DapperLib.DALInterfaces;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Dapper;
using System;
using System.Linq;

namespace DapperLib.DALInterfaceImplementation
{
    public class ConnectionController : IConnectionController
    {
        public ConnectionController()
        {
            Configuration config = StaticSourceMethods.CreateNewConfig();
            config.ClearConfigurationManagerConnectionStrings();
            config.AddConnectionSettingsToConfig(@".\MYMSSQLSERVER", "Homework14", "MyConnection");
            config.ProtectConnectionData(true);
        }

        SqlConnection CreateConnection()
        {
            return new SqlConnection(StaticSourceMethods.GetConnectionString("MyConnection"));
        }

        public List<T> LoadData<T>(string sql)
        {
            List<T> result = new List<T>();

            using (IDbConnection connection = CreateConnection())
            {
                try
                {
                    var res = connection.Query<T>(sql);
                    result = res.ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return result;
        }
        public void SaveData<T>(string sql, T item )
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection.Execute(sql, item);
            }
        }
        public void UpdateData<T>(string sql, T item)
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection.Execute(sql, item);
            }
        }
        public void DeleteData<T>(string sql, T item)
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection.Execute(sql, item);
            }
        }
        public List<T> LoadDataFiltred<T>(string sql, object myParams)
        {
            List<T> result = new List<T>();
            using (IDbConnection connection = CreateConnection())
            {
                var res = connection.Query<T>(sql, myParams, commandType: CommandType.StoredProcedure);
                result = res.ToList();
            }
            return result;
        }
        public void DeleteDataFiltred(string sql, object myParams)
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection.Execute(sql, myParams, commandType: CommandType.StoredProcedure);
            }
        }
        public void ExecuteQuery(string sql)
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection.Execute(sql);
            }
        }
        public void ExecuteStoredProcedure(string procedureName)
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection.Execute(procedureName, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
