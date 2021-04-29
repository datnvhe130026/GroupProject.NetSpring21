using Project.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Project.BL
{
    class Revenue
    {
        private string time;
        private string price;

        public Revenue()
        {
        }

        public Revenue(string time, string price)
        {
            this.Time = time;
            this.Price = price;
        }

        public string Time { get => time; set => time = value; }
        public string Price { get => price; set => price = value; }
        public static List<Revenue> GetTotalPriceByDate(DateTime date1, DateTime date2)
        {
            List<Revenue> revenues = new List<Revenue>();
            DataTable dataTable = BillDAL.GetTotalPriceByDate(date1, date2);
            foreach (DataRow dr in dataTable.Rows)
            {
               string timeIn = String.Format("{0:MM/dd/yyyy}",(DateTime)dr["Thời Gian"] );

                string totalPrice = dr["Doanh Thu"].ToString();
                Revenue revenue = new Revenue(timeIn,totalPrice);
                revenues.Add(revenue);
            }
            return revenues;
        }
        public static List<Revenue> GetTotalPriceByMonth()
        {
            List<Revenue> revenues = new List<Revenue>();
            DataTable dataTable = BillDAL.GetTotalPriceByMonth();
            foreach (DataRow dr in dataTable.Rows)
            {
                string timeIn =dr["Thời Gian"].ToString();

                string totalPrice = dr["Doanh Thu"].ToString();
                Revenue revenue = new Revenue(timeIn, totalPrice);
                revenues.Add(revenue);
            }
            return revenues;
        }
        public static string GetTotalPrice()
        {
            string totalPrice = "";
            DataTable dataTable = BillDAL.GetTotalPrice();
            foreach (DataRow dr in dataTable.Rows)
            {  
               totalPrice = dr["Doanh Thu"].ToString();               
            }
            return totalPrice;
        }
        public static string GetTotalPricePrevMonth()
        {
            string totalPrice = "";
            DataTable dataTable = BillDAL.GetTotalPricePrevMonth();
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    totalPrice = dr["Doanh Thu"].ToString();
                }
            }
            return totalPrice;
        }
        public static string GetTotalPriceMonth()
        {
            string totalPrice = "";
            DataTable dataTable = BillDAL.GetTotalPriceMonth();
            foreach (DataRow dr in dataTable.Rows)
            {
                totalPrice = dr["Doanh Thu"].ToString();
            }
            return totalPrice;
        }
    }
}
