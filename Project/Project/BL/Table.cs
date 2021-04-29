using Project.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Project.BL
{
    class Table
    {
        private int id;
        private string name;
        private string status;

        public Table()
        {
        }

        public Table(int id, string name, string status)
        {
            this.Id = id;
            this.Name = name;
            this.Status = status;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
        public static List<Table> getAllTable()
        {
            List<Table> tables = new List<Table>();
            DataTable dataTable = TableDAL.GetAllTable();
            foreach (DataRow dr in dataTable.Rows)
            {
                int id = Convert.ToInt32(dr["id"]);
                string name = dr["Tên Bàn"].ToString();
                string status = dr["Tình trạng bàn"].ToString();
                Table table = new Table(id, name, status);
                tables.Add(table);
            }
            return tables;
        }
        public static int UpdateTableStatus(ArrayList arrayList)
        {
            return TableDAL.UpdateTableStatus(arrayList);
        }
        public static string GetTableNameById(int id)
        {
            string name = TableDAL.GetTableNameById(id).Rows[0][0].ToString();
            return name;
        }
        public static string GetTableStatusById(int id)
        {
            string name = TableDAL.GetTableStatusById(id).Rows[0][0].ToString();
            return name;
        }
        internal static List<Table> GetTableByNameValidate(string v)
        {
            List<Table> tables = new List<Table>();
            DataTable dataTable = TableDAL.GetTableByNameValidatee(v);
            foreach (DataRow dr in dataTable.Rows)
            {
                int id = Convert.ToInt32(dr["id"]);
                string name = dr["name"].ToString();
                string status = dr["status"].ToString();
                Table table = new Table(id, name, status);
                tables.Add(table);
            }
            return tables;
        }
        internal static int addTable(ArrayList arrayList)
        {
            return TableDAL.addTable(arrayList);
        }

        internal static int DeleteTable(string text)
        {
            return TableDAL.DeleteTable(text);
        }

        internal static int UpdateTable(ArrayList arrayList)
        {
            return TableDAL.UpdateTable(arrayList);
        }
        internal static List<Table> SearchTableByName(string v)
        {
            List<Table> tables = new List<Table>();
            DataTable dataTable = TableDAL.GetTableByName(v);
            foreach (DataRow dr in dataTable.Rows)
            {
                int id = Convert.ToInt32(dr["id"]);
                string name = dr["name"].ToString();
                string status = dr["status"].ToString();
                Table table = new Table(id, name, status);
                tables.Add(table);
            }
            return tables;
        }
    }
}
