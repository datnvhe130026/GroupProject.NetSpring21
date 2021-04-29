using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Project.DAL
{
    class MenuDAL
    {
        public static DataTable GetMenuByTableId(int tableid)
        {
            string sql = "SELECT f.name AS 'Món Ăn',REPLACE(CONVERT(varchar(20), (CAST(f.Price AS money)),1), '.00', '') AS 'Giá Tiền',i.count AS 'Số Lượng',i.totalPrice AS 'Thành Tiền' FROM Bill b INNER JOIN BillInfor i on b.id=idBill " +
                "INNER JOIN TableFood t on b.idTable = t.id " +
                "INNER JOIN Food f on i.idFood = f.id WHERE b.idTable= '" + tableid + "' AND b.status='false'";
            return Database.GetDataBySQL(sql);
        }
    }
}
