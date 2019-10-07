using PrototypeService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrototypeService
{
    public class MockDataService
    {
        private static List<Account> Accounts = new List<Account>()
        {
            new Account(){UserName = "admin",JobNumber = "admin",Password = "admin", IsAdmin=true },
            new Account(){UserName = "test",JobNumber = "test",Password = "test", IsAdmin=false }
        };

        public List<Account> GetAccounts()
        {
            return Accounts;
        }


        public Account Login(string jobNumber, string password)
        {
            var account = Accounts.FirstOrDefault(o => o.JobNumber == jobNumber && o.Password == password);

            return account;
        }

        public bool CheckJobNumber(string jobNumber)
        {
            return Accounts.Exists(o => o.JobNumber == jobNumber);
        }

        public int AddUser(Account account)
        {
            if(Accounts.Exists(o=>o.JobNumber == account.JobNumber))
            {
                //0 存在 JobNumber
                return 0;
            }
            else
            {
                Accounts.Add(account);
                return 1;
            }
        }

        public int UpdateUser(string jobNumber, string password)
        {
            var account = Accounts.FirstOrDefault(o=>o.JobNumber == jobNumber);
            if (account!=null)
            {
                account.Password = password;
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int DeleteUser(string jobNumber)
        {
            var account = Accounts.FirstOrDefault(o => o.JobNumber == jobNumber);
            if (account != null)
            {
                Accounts.Remove(account);
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
