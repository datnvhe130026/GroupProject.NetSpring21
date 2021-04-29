using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Project.DAL
{
    class CategoryDAL
    {
        public static DataTable GetAllCategory()
        {
            string sql = "SELECT id,name as N'Loại Món' FROM FoodCategory";
            return Database.GetDataBySQL(sql);
        }
        internal static DataTable GetFoodByNameValidate(string v)
        {
            string sql = "SELECT id,name FROM FoodCategory WHERE name ='" + v + "'";
            return Database.GetDataBySQL(sql);
        }
        internal static int addNewCategory(ArrayList arrayList)
        {
            string sql = "INSERT INTO FoodCategory VALUES(@catname)";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@catname", SqlDbType.Char),

            };
            // Gan gia tri cho cac tham so kieu SqlParameter
            for (int i = 0; i < arrayList.Count; i++)
            {
                param[i].Value = arrayList[i];
            }

            return Database.ExecuteSQL(sql, param);
        }

        internal static int DeleteCategory(string id)
        {
            string sql = "DELETE FROM FoodCategory WHERE id=@id";
            SqlParameter param = new SqlParameter("@id", SqlDbType.Char);
            // Gan gia tri cho cac tham so kieu SqlParameter
            param.Value = id;
            return Database.ExecuteSQL(sql, param);
        }
        internal static int UpdateCategory(ArrayList arrayList)
        {
            string sql = "UPDATE FoodCategory SET name=@Name WHERE id=@id";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@id",SqlDbType.Int),
                new SqlParameter("@Name",SqlDbType.NVarChar),

            };
            // gán giá trị cho các tham số kiểu SqlParameter
            for (int i = 0; i < arrayList.Count; i++)
            {
                param[i].Value = arrayList[i];
            }
            return Database.ExecuteSQL(sql, param);
        }
        internal static DataTable GetCatagoryByName(string v)
        {
            string sql = "SELECT id,name as N'Loại Món' FROM FoodCategory WHERE name LIKE N'%" + v + "%'";
            return Database.GetDataBySQL(sql);
        }
    }
}
