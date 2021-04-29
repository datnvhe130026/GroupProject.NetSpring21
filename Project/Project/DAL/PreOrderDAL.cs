using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Project.DAL
{
    class PreOrderDAL
    {
        public static int AddPreOrder(ArrayList arrayList)
        {
            string sql = "INSERT INTO PreOrder VALUES (@idTable,@name,@phone,@time)";
            SqlParameter[] param = new SqlParameter[] {
           
            new SqlParameter("@idTable",SqlDbType.Int),
            new SqlParameter("@name",SqlDbType.NVarChar),
            new SqlParameter("@phone",SqlDbType.NVarChar),
            new SqlParameter("@time",SqlDbType.DateTime)
            };
            // gan gia tri cho cac tham so kieu SqlParameter
            for (int i = 0; i < arrayList.Count; i++)
            {
                param[i].Value = arrayList[i];
            }
            return Database.ExecuteSQL(sql, param);
        }
        public static DataTable SearchPreOrderByCusNameOrPhone(string name)
        {
            string sql = "SELECT p.id,t.name AS N'Tên Bàn',customerName AS N'Tên Khách Hàng', customerPhone AS N'Số Điện Thoại',CAST(time AS time) AS N'Thời Gian Đặt Bàn' FROM PreOrder p INNER JOIN TableFood t ON p.idTable=t.id WHERE customerName = N'" + name + "' OR customerPhone='"+name+"'";
            return Database.GetDataBySQL(sql);
        }
        public static DataTable getALlPreOrder()
        {
            string sql = "SELECT p.id,t.name AS N'Tên Bàn',customerName AS N'Tên Khách Hàng', customerPhone AS N'Số Điện Thoại',time AS N'Thời Gian Đặt Bàn' FROM PreOrder p INNER JOIN TableFood t ON p.idTable=t.id";
            return Database.GetDataBySQL(sql);
        }
        public static int DeletePreOrder(int id)
        {
            string sql = "DELETE FROM PreOrder WHERE id=@Id";
            SqlParameter param = new SqlParameter("@Id", SqlDbType.Int);
            // Gan gia tri cho cac tham so kieu SqlParameter
            param.Value = id;

            return Database.ExecuteSQL(sql, param);
        }

    }
}
