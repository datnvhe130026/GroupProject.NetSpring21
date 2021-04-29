using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Project.DAL
{
    class BillInforDAL
    {
        public static int AddBillInfor(ArrayList arrayList)
        {
            string sql = "INSERT INTO BillInfor VALUES (@idBill,@idFood,@count,@totalprice)";
            SqlParameter[] param = new SqlParameter[] {
            new SqlParameter("@idBill",SqlDbType.Int),
            new SqlParameter("@idFood",SqlDbType.Int),
            new SqlParameter("@count",SqlDbType.Int),
            new SqlParameter("@totalprice",SqlDbType.Float),

            };
            // gan gia tri cho cac tham so kieu SqlParameter
            for (int i = 0; i < arrayList.Count; i++)
            {
                param[i].Value = arrayList[i];
            }
            return Database.ExecuteSQL(sql, param);
        }

        internal static int DeleteBillInfor(int id)
        {
            string sql = "delete from BillInfor where idBill=@idBill";
            SqlParameter param =new SqlParameter("@idBill",SqlDbType.Int);

            param.Value = id;
            
            return Database.ExecuteSQL(sql, param);
        }
    }
}
