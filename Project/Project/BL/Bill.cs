using Project.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Project.BL
{
    class Bill
    {
        private int id;
        private DateTime timeIn;
        private int idTable;
        private bool status;
        private double totalPrice;
        private string staff;
        private int sale;
        public Bill()
        {
        }

        public Bill(DateTime timeIn, int idTable, bool status, double totalPrice,int sale)
        {
            this.TimeIn = timeIn;
            this.IdTable = idTable;
            this.Status = status;
            this.TotalPrice = totalPrice;
            this.Sale = sale;
        }

        public Bill(int id, DateTime timeIn, int idTable, bool status, double totalPrice,string staff, int sale)
        {
            this.id = id;
            this.timeIn = timeIn;
            this.idTable = idTable;
            this.status = status;
            this.totalPrice = totalPrice;
            this.Staff = staff;
            this.Sale = sale;
        }

        public DateTime TimeIn { get => timeIn; set => timeIn = value; }
        public int IdTable { get => idTable; set => idTable = value; }
        public bool Status { get => status; set => status = value; }
        public double TotalPrice { get => totalPrice; set => totalPrice = value; }
        public int Id { get => id; set => id = value; }
        public string Staff { get => staff; set => staff = value; }
        public int Sale { get => sale; set => sale = value; }

        public static int AddBill(ArrayList arrayList)
        {
            return BillDAL.AddBill(arrayList);
        }
        public static List<Bill> GetAllBill(int tableID)
        {
            List<Bill> bills = new List<Bill>();
            DataTable dataTable = BillDAL.GetBillByTableID(tableID);
            foreach (DataRow dr in dataTable.Rows)
            {
                DateTime timeIn = (DateTime) dr["TimeIn"];
                int idTable = (int)dr["idTable"];
                bool status =(bool) dr["status"];
                double totalPrice = (double)dr["totalPrice"];
                int id= (int)dr["id"];
                string staff = dr["staff"].ToString();
                int sale= (int)dr["sale"];
                Bill bill = new Bill(id, timeIn, idTable, status, totalPrice,staff,sale);
                bills.Add(bill);
            }
            return bills;
        }
        public static int ChangeTableId(ArrayList arrayList)
        {
            return BillDAL.ChangeTableId(arrayList);
        }
        public static int ChangeTotalPrice(ArrayList arrayList)
        {
            return BillDAL.ChangeTotalPrice(arrayList);
        }
        public static int ChangeBillStatus(ArrayList arrayList)
        {
            return BillDAL.ChangeBillStatus(arrayList);
        }
       
    }
}
