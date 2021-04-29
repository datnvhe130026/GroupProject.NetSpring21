using Project.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Project.BL
{
    class Food
    {
        private int id;
        private string name;
        private string catName;
        private double price;
        private string status;
        public Food()
        {
        }
       
        public Food(int id, string name, string catName, double price, string status)
        {
            this.id = id;
            this.name = name;
            this.catName = catName;
            this.price = price;
            this.Status = status;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string CatName { get => catName; set => catName = value; }
        public double Price { get => price; set => price = value; }
        public string Status { get => status; set => status = value; }

        public static List<Food> SearchFoodByCategoryId(int categoryId)
        {
            List<Food> foods = new List<Food>();
            DataTable dataTable = FoodDAL.SearchFoodByCategoryId(categoryId);
            foreach(DataRow dr in dataTable.Rows)
            {
                int id = Convert.ToInt32(dr["id"]);
                string name = dr["Tên Món"].ToString();
                string catName= dr["Loại Món"].ToString();
                double price = Convert.ToDouble( dr["Giá Tiền"]);
                string status = dr["Tình Trạng"].ToString();
                Food food = new Food(id, name, catName, price,status);
                foods.Add(food);
            }
            return foods;
        }
        public static List<Food> SearchFood(int categoryId,string name)
        {
            List<Food> foods = new List<Food>();
            DataTable dataTable = FoodDAL.SearchFood(categoryId,name);
            foreach (DataRow dr in dataTable.Rows)
            {
                int id = Convert.ToInt32(dr["id"]);
                string foodname = dr["Tên Món"].ToString();
                string catName= dr["Loại Món"].ToString();
                double price = Convert.ToDouble( dr["Giá Tiền"]);
                string status = dr["Tình Trạng"].ToString();
                Food food = new Food( id,foodname, catName, price,status);
                foods.Add(food);
            }
            return foods;
        }
        internal static int addFood(ArrayList arrayList)
        {
            return FoodDAL.addFood(arrayList);
        }
        internal static List<Food> GetFoodByNameValidate(string name)
        {
            List<Food> foods = new List<Food>();
            DataTable dataTable = FoodDAL.GetFoodByNameValidate(name);
            foreach (DataRow dr in dataTable.Rows)
            {
                int id = Convert.ToInt32(dr["id"]);
                string catname = dr["categoryName"].ToString();
                string status = dr["status"].ToString();
                double price = Convert.ToDouble(dr["Price"]);
                Food food = new Food(id, name, catname, price,status);
                foods.Add(food);
            }
            return foods;
        }
        internal static int DeleteFood(string id)
        {
            return FoodDAL.DeleteFood(id);
        }

        internal static int UpdateFood(ArrayList arrayList)
        {
            return FoodDAL.UpdateFood(arrayList);
        }
    }
}
