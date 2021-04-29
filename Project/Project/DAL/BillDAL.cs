using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Project.DAL
{
    class BillDAL
    {
        public static DataTable GetBillByTableID(int tableId )
        {
            string sql = "SELECT * FROM Bill where idTable='"+tableId+"' AND status='false'";
            return Database.GetDataBySQL(sql);
        }
        public static int AddBill(ArrayList arrayList)
        {
            string sql = "INSERT INTO Bill VALUES (@timeIn,@idTable,@status,@totalprice,@staff,@sale)";
            SqlParameter[] param = new SqlParameter[] {
            new SqlParameter("@timeIn",SqlDbType.DateTime),
            new SqlParameter("@idTable",SqlDbType.Int),
            new SqlParameter("@status",SqlDbType.Bit),
            new SqlParameter("@totalprice",SqlDbType.Float),
            new SqlParameter("@staff",SqlDbType.NVarChar),
            new SqlParameter("@sale",SqlDbType.Int),
            };
            // gan gia tri cho cac tham so kieu SqlParameter
            for (int i = 0; i < arrayList.Count; i++)
            {
                param[i].Value = arrayList[i];
            }
            return Database.ExecuteSQL(sql, param);
        }
        public static int ChangeTableId(ArrayList arrayList)
        {
            string sql = "UPDATE Bill SET idTable= @idTable WHERE id=@billID";
            SqlParameter[] param = new SqlParameter[] {
            
            new SqlParameter("@idTable",SqlDbType.Int),
            new SqlParameter("@billID",SqlDbType.Int)
            };
            // gan gia tri cho cac tham so kieu SqlParameter
            for (int i = 0; i < arrayList.Count; i++)
            {
                param[i].Value = arrayList[i];
            }
            return Database.ExecuteSQL(sql, param);
        }
        public static int ChangeTotalPrice(ArrayList arrayList)
        {
            string sql = "UPDATE Bill SET totalPrice= @total WHERE id=@billID";
            SqlParameter[] param = new SqlParameter[] {

            new SqlParameter("@total",SqlDbType.Float),
            new SqlParameter("@billID",SqlDbType.Int)
            };
            // gan gia tri cho cac tham so kieu SqlParameter
            for (int i = 0; i < arrayList.Count; i++)
            {
                param[i].Value = arrayList[i];
            }
            return Database.ExecuteSQL(sql, param);
        }
        public static int ChangeBillStatus(ArrayList arrayList)
        {
            string sql = "UPDATE Bill SET status= @status WHERE id=@billID";
            SqlParameter[] param = new SqlParameter[] {

            new SqlParameter("@status",SqlDbType.Bit),
            new SqlParameter("@billID",SqlDbType.Int)
            };
            // gan gia tri cho cac tham so kieu SqlParameter
            for (int i = 0; i < arrayList.Count; i++)
            {
                param[i].Value = arrayList[i];
            }
            return Database.ExecuteSQL(sql, param);
        }
        public static DataTable GetTotalPriceByDate(DateTime date1,DateTime date2 )
        {
            string sql = "Select CAST(Timein as date) as N'Thời Gian',REPLACE(CONVERT(varchar(20), (CAST(SUM(totalPrice) AS money)),1), '.00', '') as N'Doanh Thu' from Bill where Timein BETWEEN '" + date1 + "' AND '" + date2 + "' Group by CAST(Timein as date)";
            return Database.GetDataBySQL(sql);
        }

        public static DataTable GetTotalPriceByMonth()
        {
            string sql = "Select Month(Timein) as N'Thời Gian',REPLACE(CONVERT(varchar(20), (CAST(SUM(totalPrice) AS money)),1), '.00', '') as N'Doanh Thu' from Bill Group by Month(Timein)";
            return Database.GetDataBySQL(sql);
        }
        public static DataTable GetTotalPrice()
        {
            string sql = "Select REPLACE(CONVERT(varchar(20), (CAST(SUM(totalPrice) AS money)),1), '.00', '') as N'Doanh Thu' from Bill";
            return Database.GetDataBySQL(sql);
        }
        public static DataTable GetTotalPricePrevMonth()
        {
            string sql = "Select REPLACE(CONVERT(varchar(20), (CAST(SUM(totalPrice) AS money)),1), '.00', '') as N'Doanh Thu' from Bill where  DATEPART(month,Timein) = (DATEPART(month, GETDATE()) - 1)";
            return Database.GetDataBySQL(sql);
        }
        public static DataTable GetTotalPriceMonth()
        {
            string sql = "Select REPLACE(CONVERT(varchar(20), (CAST(SUM(totalPrice) AS money)),1), '.00', '') as N'Doanh Thu' from Bill where  DATEPART(month,Timein) = (DATEPART(month, GETDATE()))";
            return Database.GetDataBySQL(sql);
        }
        public static DataTable GetRevenueByFood()
        {
            string sql = "Select  top 5 sum(totalPrice) as N'Doanh Thu' ,f.name as N'Tên Món' from BillInfor b inner join Food f on b.idFood=f.id group by f.name order by N'Doanh Thu' desc";
            return Database.GetDataBySQL(sql);
        }
        public static DataTable GetRevenueDetails()
        {
            string sql = "Select b.id as N'Mã Hóa Đơn',b.Timein as N'Thời Gian',b.staff as N'Nhân Viên',t.name as N'Tên Bàn',REPLACE(CONVERT(varchar(20), (CAST(b.totalPrice AS money)),1), '.00', '') as N'Doanh Thu'  from Bill b INNER JOIN TableFood t on b.idTable=t.id";
            return Database.GetDataBySQL(sql);
        }
        public static DataTable GetDetailsByBillId (int id)
        {
            string sql = "Select f.name as N'Tên Món',REPLACE(CONVERT(varchar(20), (CAST(f.Price AS money)),1), '.00', '') as N'Đơn Giá',b.count as N'Số Lượng',REPLACE(CONVERT(varchar(20), (CAST(b.totalPrice AS money)),1), '.00', '') as N'Thành Tiền' from BillInfor b INNER JOIN Food f on b.idFood=f.id where b.idBill="+id;
            return Database.GetDataBySQL(sql);
        }
       
    }
}
