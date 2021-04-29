using Project.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.BL
{
    class BillInfor
    {
        private int idBill;
        private int idFood;
        private int count;
        private double price;

        public BillInfor()
        {
        }

        public BillInfor(int idBill, int idFood, int count, double price)
        {
            this.IdBill = idBill;
            this.IdFood = idFood;
            this.Count = count;
            this.Price = price;
        }

        public int IdBill { get => idBill; set => idBill = value; }
        public int IdFood { get => idFood; set => idFood = value; }
        public int Count { get => count; set => count = value; }
        public double Price { get => price; set => price = value; }
        public static int AddBill(ArrayList arrayList)
        {
            return BillInforDAL.AddBillInfor(arrayList);
        }
        public static int DeleteBillInfor(int id)
        {
            return BillInforDAL.DeleteBillInfor(id);
        }
    }
}
