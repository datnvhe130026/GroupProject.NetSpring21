using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Project.DAL
{
    class FoodDAL
    {
        public static DataTable SearchFoodByCategoryId(int categoryId)
        {
            string sql = "SELECT f.id,f.name AS 'Tên Món',c.name AS 'Loại Món',REPLACE(CONVERT(varchar(20), (CAST(Price AS money)),1), '.00', '') AS 'Giá tiền' ,status AS 'Tình Trạng' FROM Food f INNER JOIN FoodCategory c ON f.CatID=c.id WHERE CatID='" + categoryId + "'";
            return Database.GetDataBySQL(sql);
        }
        public static DataTable SearchFood(int categoryId,string name)
        {
            string sql = "SELECT f.id,f.name AS 'Tên Món',c.name AS 'Loại Món',REPLACE(CONVERT(varchar(20), (CAST(Price AS money)),1), '.00', '') AS 'Giá tiền' ,status AS 'Tình Trạng' FROM Food f INNER JOIN FoodCategory c ON f.CatID=c.id WHERE CatID='" + categoryId + "' AND f.name LIKE '%"+name+"%'";
            return Database.GetDataBySQL(sql);
        }
        internal static DataTable GetAllFood()
        {
            string sql = "SELECT Food.id as N'Mã Món', Food.name AS N'Tên Món', FoodCategory.name AS 'Loại Món', Food.status AS 'Tình Trạng', REPLACE(CONVERT(varchar(20), (CAST(Food.Price AS money)),1), '.00', '') AS 'Giá tiền' FROM Food INNER JOIN FoodCategory ON Food.CatID = FoodCategory.id";
            return Database.GetDataBySQL(sql);
        }
        internal static int addFood(ArrayList arrayList)
        {
            string sql = "Insert into Food(name,CatID,status,Price) values(@name,@CatID,@status,@Price)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@name",SqlDbType.NVarChar),
                new SqlParameter("@CatID",SqlDbType.Int),
                new SqlParameter("@status", SqlDbType.NVarChar),
                new SqlParameter("@Price",SqlDbType.Float),

            };
            // gán giá trị cho các tham số kiểu SqlParameter
            for (int i = 0; i < arrayList.Count; i++)
            {
                param[i].Value = arrayList[i];
            }
            return Database.ExecuteSQL(sql, param);
        }
        internal static DataTable GetFoodByNameValidate(string name)
        {
            string sql = "SELECT Food.id, Food.name, FoodCategory.name AS categoryName, Food.status, Food.Price FROM Food INNER JOIN FoodCategory ON Food.CatID = FoodCategory.id WHERE Food.name ='" + name + "'";
            return Database.GetDataBySQL(sql);
        }
        internal static int DeleteFood(string id)
        {
            string sql = "DELETE FROM Food WHERE id=@id";
            SqlParameter param = new SqlParameter("@id", SqlDbType.Char);
            // Gan gia tri cho cac tham so kieu SqlParameter
            param.Value = id;
            return Database.ExecuteSQL(sql, param);
        }

        internal static int UpdateFood(ArrayList arrayList)
        {
            string sql = "UPDATE Food SET name=@Name, CatID=@catId, status=@status,Price=@price WHERE id=@id";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@id",SqlDbType.Int),
                new SqlParameter("@Name",SqlDbType.NVarChar),
                new SqlParameter("@catId",SqlDbType.Int),
                new SqlParameter("@status", SqlDbType.NVarChar),
                new SqlParameter("@price",SqlDbType.Float),

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
