using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Project.DAL
{
    class TableDAL
    {
        public static DataTable GetAllTable()
        {
            string sql = "SELECT id,name as N'Tên Bàn', status as N'Tình trạng bàn' FROM TableFood";
            return Database.GetDataBySQL(sql);
        }
        public static DataTable GetEmptyTable()
        {
            string sql = "SELECT * FROM TableFood WHERE status=N'Trống'";
            return Database.GetDataBySQL(sql);
        }
        public static DataTable GetTableNameById(int id)
        {
            string sql = "SELECT name FROM TableFood WHERE id="+id;
            return Database.GetDataBySQL(sql);
        }
        public static int UpdateTableStatus(ArrayList arrayList)
        {
            string sql = "UPDATE TableFood SET status=@status WHERE id=@Id";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@status", SqlDbType.NVarChar),
                new SqlParameter("@id", SqlDbType.Int),
               
            };
            // Gan gia tri cho cac tham so kieu SqlParameter
            for (int i = 0; i < arrayList.Count; i++)
            {
                param[i].Value = arrayList[i];
            }

            return Database.ExecuteSQL(sql, param);
        }
        public static DataTable GetTableStatusById(int id)
        {
            string sql = "SELECT status FROM TableFood WHERE id=" + id;
            return Database.GetDataBySQL(sql);
        }
        internal static DataTable GetTableByNameValidatee(string v)
        {
            string sql = "SELECT * FROM TableFood WHERE name = '" + v + "'";
            return Database.GetDataBySQL(sql);
        }
        internal static int addTable(ArrayList arrayList)
        {
            string sql = "Insert into TableFood(name,status) values(@name,@status)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@name",SqlDbType.NVarChar),
                new SqlParameter("@status", SqlDbType.NVarChar),

            };
            // gán giá trị cho các tham số kiểu SqlParameter
            for (int i = 0; i < arrayList.Count; i++)
            {
                param[i].Value = arrayList[i];
            }
            return Database.ExecuteSQL(sql, param);
        }
        internal static int DeleteTable(string id)
        {
            string sql = "DELETE FROM TableFood WHERE id=@id";
            SqlParameter param = new SqlParameter("@id", SqlDbType.Char);
            // Gan gia tri cho cac tham so kieu SqlParameter
            param.Value = id;
            return Database.ExecuteSQL(sql, param);
        }
        internal static DataTable GetTableByName(string v)
        {
            string sql = "SELECT * FROM TableFood WHERE name LIKE '%" + v + "%'";
            return Database.GetDataBySQL(sql);
        }

        internal static int UpdateTable(ArrayList arrayList)
        {
            string sql = "UPDATE TableFood SET name=@Name,status=@status WHERE id=@id";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@id",SqlDbType.Int),
                new SqlParameter("@Name",SqlDbType.NVarChar),
                new SqlParameter("@status", SqlDbType.NVarChar),

            };
            // gán giá trị cho các tham số kiểu SqlParameter
            for (int i = 0; i < arrayList.Count; i++)
            {
                param[i].Value = arrayList[i];
            }
            return Database.ExecuteSQL(sql, param);
        }
    }
}
