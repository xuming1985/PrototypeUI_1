using Dapper;
using PrototypeService.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace PrototypeService.Service
{
    public class AccountService: PrototypeDB
    {
        public AccountService()
        {
            TableName = "T_Account";
        }

        public Account Login(string jobNumber, string password)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.QueryFirstOrDefault<Account>("select * from T_Account where JobNumber=@JobNumber and Password=@Password", new Account() { JobNumber = jobNumber, Password = password });
            }
        }

        public int Insert(Account account)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(ConnectionString))
                {
                    string sqlSearch = $"select * from {TableName} where JobNumber = @JobNumber";
                    var entity = connection.QueryFirstOrDefault<Account>(sqlSearch, account);

                    if (entity != null)
                    {
                        return 0;
                    }
                    else
                    {
                        string sqlInsert = $"insert into {TableName} (UserName,JobNumber,Password,IsAdmin,CreateTime,CreateUser) values(@UserName,@JobNumber,@Password,@IsAdmin,@CreateTime,@CreateUser)";
                        return connection.Execute(sqlInsert, account);
                    }
                }
            }
            catch(Exception ex)
            {
                return -1;
            }
        }

        public int Delete(Account account)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.Execute($"delete from {TableName} where JobNumber=@JobNumber", account);
            }
        }

        public int Delete(List<Account> accounts)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.Execute($"delete from {TableName} where JobNumber=@JobNumber", accounts);
            }
        }

        public int Update(Account account)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.Execute($"update {TableName} set Password=@Password where JobNumber=@JobNumber", account);
            }
        }
    }
}
