using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace PrototypeService
{
    public class PrototypeDB
    {
        protected string TableName;

        protected static readonly string ConnectionString = ConfigurationManager.AppSettings["connection"];

        public List<T> Query<T>()
        {
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<T>($"select * from {TableName}").ToList();
            }
        }

        public T Query<T>(T account)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.QueryFirstOrDefault<T>($"select * from {TableName} where id=@ID", account);
            }
        }
    }
}
