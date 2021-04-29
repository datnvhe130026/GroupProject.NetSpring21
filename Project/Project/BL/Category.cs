using Project.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Project.BL
{
    class Category
    {
        private int id;
        private string name;

        public Category()
        {
        }

        public Category(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public static List<Category> GetAllCategory()
        {
            List<Category> categories = new List<Category>();
            DataTable dataTable = CategoryDAL.GetAllCategory();
            foreach(DataRow dr in dataTable.Rows)
            {
                int id = Convert.ToInt32(dr["Id"]);
                string name = dr["Loại Món"].ToString();
                Category category = new Category(id, name);
                categories.Add(category);
            }
            return categories;
        }
        internal static List<Category> GetFoodByNameValidate(string v)
        {
            List<Category> foodCategories = new List<Category>();
            DataTable dataTable = CategoryDAL.GetFoodByNameValidate(v);
            foreach (DataRow dr in dataTable.Rows)
            {
                int id = Convert.ToInt32(dr["id"]);
                string name = dr["name"].ToString();
                Category foodCategory = new Category(id, name);
                foodCategories.Add(foodCategory);
            }
            return foodCategories;
        }
        internal static int addNewCategory(ArrayList arrayList)
        {
            return CategoryDAL.addNewCategory(arrayList);
        }

        internal static int DeleteCategory(string id)
        {
            return CategoryDAL.DeleteCategory(id);
        }

        internal static int UpdateCategory(ArrayList arrayList)
        {
            return CategoryDAL.UpdateCategory(arrayList);
        }
        internal static List<Category> SearchCategoryByName(string v)
        {
            List<Category> foodCategories = new List<Category>();
            DataTable dataTable = CategoryDAL.GetCatagoryByName(v);
            foreach (DataRow dr in dataTable.Rows)
            {
                int id = Convert.ToInt32(dr["id"]);
                string name = dr["Loại Món"].ToString();
                Category foodCategory = new Category(id, name);
                foodCategories.Add(foodCategory);
            }
            return foodCategories;
        }
    }
}
