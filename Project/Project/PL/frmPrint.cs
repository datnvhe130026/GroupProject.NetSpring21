using Project.BL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project.PL
{
    public partial class frmPrint : Form
    {
        string sale;
        int tableId;
        public frmPrint( string sale,int tableId)
        {
            this.sale = sale;
            this.tableId = tableId;
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            rptBill1.SetDataSource(Menus.getMenuByTableID(tableId));
            List<Bill> bills = Bill.GetAllBill(tableId);
            string tableName = Table.GetTableNameById(tableId);
            rptBill1.SetParameterValue("pId", bills[0].Id);
            rptBill1.SetParameterValue("pTable",tableName);
            rptBill1.SetParameterValue("pTime", bills[0].TimeIn);
            rptBill1.SetParameterValue("pStaff", bills[0].Staff);
            rptBill1.SetParameterValue("pSale", sale);
            rptBill1.SetParameterValue("pTotal", bills[0].TotalPrice);
            crystalReportViewer1.ReportSource = rptBill1;
            crystalReportViewer1.Refresh();
        }

        private void frmPrint_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
