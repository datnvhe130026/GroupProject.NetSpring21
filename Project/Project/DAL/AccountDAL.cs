using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Project.DAL
{
    class AccountDAL
    {
        public static DataTable getAccount(string userName, string password)
        {
            string sql = "SELECT * FROM Account WHERE username = '" + userName + "' and password = (SELECT CONVERT(VARCHAR(32), HashBytes('MD5', '" + password + "'),2))";
            return Database.GetDataBySQL(sql);
        }
        public static DataTable GetAllAccount()
        {
            string sql = "Select username as N'Tài Khoản',DisplayName as N'Tên Hiển Thị',TYPE as N'Loại Tài Khoản' from Account";
            return Database.GetDataBySQL(sql);
        }

        internal static int AddAccount(ArrayList arrayList)
        {
            string sql = "Insert into Account(username,DisplayName,password) values(@username,@displayname,(SELECT CONVERT(VARCHAR(32), HashBytes('MD5', '@password'), 2)))";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@username",SqlDbType.NVarChar),
                new SqlParameter("@displayname",SqlDbType.NVarChar),
                new SqlParameter("@password", SqlDbType.NVarChar),

            };
            // gán giá trị cho các tham số kiểu SqlParameter
            for (int i = 0; i < arrayList.Count; i++)
            {
                param[i].Value = arrayList[i];
            }
            return Database.ExecuteSQL(sql, param);
        }

        internal static DataTable GetAccountByUsername(string username)
        {
            string sql = "Select username as N'Tài Khoản',DisplayName as N'Tên Hiển Thị',TYPE as N'Loại Tài Khoản' from Account WHERE username LIKE'%" + username + "%'";
            return Database.GetDataBySQL(sql);
        }

        internal static int UpdateAccount(ArrayList arrayList)
        {
            string sql = "Update Account SET DisplayName=@displayname, password = (SELECT CONVERT(VARCHAR(32), HashBytes('MD5', '@password'), 2)) Where username=@username";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@username",SqlDbType.NVarChar),
                new SqlParameter("@displayname",SqlDbType.NVarChar),
                new SqlParameter("@password", SqlDbType.NVarChar),

            };
            // gán giá trị cho các tham số kiểu SqlParameter
            for (int i = 0; i < arrayList.Count; i++)
            {
                param[i].Value = arrayList[i];
            }
            return Database.ExecuteSQL(sql, param);
        }

        internal static DataTable GetAccountByNameValidate(string v)
        {
            string sql = "Select * from Account WHERE username= '" + v + "'";
            return Database.GetDataBySQL(sql);
        }

        internal static int DeleteAccount(string id)
        {
            string sql = "DELETE FROM Account WHERE username=@username";
            SqlParameter param = new SqlParameter("@username", SqlDbType.Char);
            // Gan gia tri cho cac tham so kieu SqlParameter
            param.Value = id;
            return Database.ExecuteSQL(sql, param);
        }
    }
}
