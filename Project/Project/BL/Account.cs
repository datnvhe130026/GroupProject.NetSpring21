using Project.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Project.BL
{
    class Account
    {
        private string username;
        private string password;
        private string displayname;
        private bool type;

        public Account()
        {
        }

        public Account(string username, string password, string displayname, bool type)
        {
            this.Username = username;
            this.Password = password;
            this.Displayname = displayname;
            this.Type = type;
        }
        public Account(string username,string displayname, bool type)
        {
            this.Username = username;
            this.Displayname = displayname;
            this.Type = type;
        }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Displayname { get => displayname; set => displayname = value; }
        public bool Type { get => type; set => type = value; }
        
        public static List<Account> GetAccount(string userName, string password)
        {
            List<Account> accounts = new List<Account>();
            DataTable dataTable = AccountDAL.getAccount(userName,password);
            foreach (DataRow dr in dataTable.Rows)
            {
                string user= dr["Username"].ToString();
                string pass = dr["Password"].ToString();
                string displayName = dr["Displayname"].ToString();
                bool type =(bool) dr["Type"];
                Account account = new Account(user, pass, displayName, type);
                accounts.Add(account);
            }
            return accounts;
        }
       
        internal static List<Account> GetAccountByNameValidate(string v)
        {
            List<Account> categories = new List<Account>();
            DataTable dataTable = AccountDAL.GetAccountByNameValidate(v);
            foreach (DataRow dr in dataTable.Rows)
            {
                string UserName = dr["username"].ToString();
                string displayname = dr["DisplayName"].ToString();
                bool type = (bool)(dr["TYPE"]);
                Account account = new Account(UserName, displayname, type);
                categories.Add(account);
            }
            return categories;
        }

        internal static List<Account> GetAccountByUsername(string v)
        {
            List<Account> categories = new List<Account>();
            DataTable dataTable = AccountDAL.GetAccountByUsername(v);
            foreach (DataRow dr in dataTable.Rows)
            {
                string UserName = dr["Tài Khoản"].ToString();
                string displayname = dr["Tên Hiển Thị"].ToString();
                bool type = (bool)(dr["Loại Tài Khoản"]);
                Account account = new Account(UserName, displayname, type);
                categories.Add(account);
            }
            return categories;
        }

        internal static int DeleteAccount(string text)
        {
            return AccountDAL.DeleteAccount(text);
        }

        internal static int AddAccount(ArrayList arrayList)
        {
            return AccountDAL.AddAccount(arrayList);
        }

        internal static int UpdateAccount(ArrayList arrayList)
        {
            return AccountDAL.UpdateAccount(arrayList);
        }
    }
}
