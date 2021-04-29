using Project.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Project.BL
{
    class Menus
    {
        private string name;
        private double price;
        private int count;
        private double totalPrice;

        public Menus()
        {
        }

        public Menus(string name, double price, int count, double totalPrice)
        {
            this.Name = name;
            this.Price = price;
            this.Count = count;
            this.TotalPrice = totalPrice;
        }

        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public int Count { get => count; set => count = value; }
        public double TotalPrice { get => totalPrice; set => totalPrice = value; }
        public static List<Menus> getMenuByTableID(int tableid) { 
        List<Menus> menus = new List<Menus>();
        DataTable dataTable = MenuDAL.GetMenuByTableId(tableid);
        foreach (DataRow dr in dataTable.Rows)
        {
        string name = dr["Món Ăn"].ToString();
        double price = Convert.ToDouble(dr["Giá Tiền"]);
        int count = (int)dr["Số Lượng"];
        double totalPrice = (double)dr["Thành Tiền"];
        Menus menu = new Menus(name, price, count, totalPrice);
        menus.Add(menu);
        }
        return menus;
        }
    }
    
}
