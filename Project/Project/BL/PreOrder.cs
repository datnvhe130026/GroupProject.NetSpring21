using Project.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.BL
{
    class PreOrder
    {
      private int idTable;
      private string customName;
        private string phone;
        private DateTime time;

        public PreOrder()
        {
        }

        public PreOrder(int idTable, string customName, string phone, DateTime time)
        {
            this.IdTable = idTable;
            this.CustomName = customName;
            this.Phone = phone;
            this.Time = time;
        }

        public int IdTable { get => idTable; set => idTable = value; }
        public string CustomName { get => customName; set => customName = value; }
        public string Phone { get => phone; set => phone = value; }
        public DateTime Time { get => time; set => time = value; }
        public static int AddPreOrder(ArrayList arrayList)
        {
            return PreOrderDAL.AddPreOrder(arrayList);
        }
        public static int DeletePreOrder(int id)
        {
            return PreOrderDAL.DeletePreOrder(id);
        }
    }
}
