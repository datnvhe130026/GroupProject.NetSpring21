using Project.BL;
using Project.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project.PL
{
    public partial class frmRevenue : Form
    {
        public frmRevenue()
        {
            InitializeComponent();
        }

      private void frmRevenue_Load(object sender, EventArgs e)
        {
            
            btnBack.Enabled = false;
            loadLabel();
            chartRevenue.DataSource = Revenue.GetTotalPriceByDate(dtpFrom.Value, dtpTo.Value);
            chartRevenue.Series["Doanh Thu"].YValueMembers = "price";
            chartRevenue.Series["Doanh Thu"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chartRevenue.Series["Doanh Thu"].XValueMember = "time";
            chartRevenue.Series["Doanh Thu"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
        }
        private void loadLabel()
        {
            lblTotal.Text = Revenue.GetTotalPrice() +" VND";
            lblNextMonth.Text = Revenue.GetTotalPriceMonth() + " VND";
            if (!Revenue.GetTotalPricePrevMonth().Equals("")) { 
            lblPrevMonth.Text = Revenue.GetTotalPricePrevMonth() + " VND";
                double prevMonth = Convert.ToDouble(Revenue.GetTotalPricePrevMonth());
                double nowMonth= Convert.ToDouble(Revenue.GetTotalPriceMonth());
                double percent = Math.Round ((nowMonth * 100) / prevMonth - 100);
                if (percent < 0)
                {   lblUp.Text = "Giảm";
                    percent *= -1;
                    
                }
                lblPercent.Text = percent.ToString()+" %";
            }
            else
            {
                lblPrevMonth.Text = "Chưa có";
            }
            

        }
        private void rbDate_Click(object sender, EventArgs e)
        {
            dtpFrom.Enabled = true;
            dtpTo.Enabled = true;
            btnFillter.Enabled = true;
            chartRevenue.Series["Doanh Thu"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chartRevenue.DataSource = Revenue.GetTotalPriceByDate(dtpFrom.Value, dtpTo.Value);
            chartRevenue.Series["Doanh Thu"].YValueMembers = "price";
            chartRevenue.Series["Doanh Thu"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chartRevenue.Series["Doanh Thu"].XValueMember = "time";
            chartRevenue.Series["Doanh Thu"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
        }
        private void btnFillter_Click(object sender, EventArgs e)
        {
            chartRevenue.Series["Doanh Thu"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chartRevenue.DataSource = Revenue.GetTotalPriceByDate(dtpFrom.Value, dtpTo.Value);
            chartRevenue.Series["Doanh Thu"].YValueMembers = "price";
            chartRevenue.Series["Doanh Thu"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chartRevenue.Series["Doanh Thu"].XValueMember = "time";
            chartRevenue.Series["Doanh Thu"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
        }

        private void rbMonth_Click(object sender, EventArgs e)
        {
            dtpFrom.Enabled = false;
            dtpTo.Enabled = false;
            btnFillter.Enabled = false;
            chartRevenue.Series["Doanh Thu"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chartRevenue.DataSource = Revenue.GetTotalPriceByMonth();
            chartRevenue.Series["Doanh Thu"].YValueMembers = "price";
            chartRevenue.Series["Doanh Thu"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chartRevenue.Series["Doanh Thu"].XValueMember = "time";
            chartRevenue.Series["Doanh Thu"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;


        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            dtpFrom.Enabled = true;
            dtpTo.Enabled = true;
            btnFillter.Enabled = true;
            chartRevenue.DataSource = BillDAL.GetRevenueByFood();
            chartRevenue.Series["Doanh Thu"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            chartRevenue.Series["Doanh Thu"].YValueMembers = "Doanh Thu";
            chartRevenue.Series["Doanh Thu"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chartRevenue.Series["Doanh Thu"].XValueMember = "Tên Món";
            chartRevenue.Series["Doanh Thu"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                if (dgvBillDetail.Columns.Count >= 5)
                {
                    dgvBillDetail.Columns.RemoveAt(5);
                }
                dgvBillDetail.DataSource = "";
                btnBack.Enabled = true;
                dgvBillDetail.DataSource = BillDAL.GetRevenueDetails();
                DataGridViewButtonColumn btnViewColumn = new DataGridViewButtonColumn();
                btnViewColumn.Name = "btnViewColumn";
                btnViewColumn.HeaderText = "Chi Tiết Hóa Đơn";
                btnViewColumn.UseColumnTextForButtonValue = true;
                btnViewColumn.Text = "Xem";
                dgvBillDetail.Columns.Add(btnViewColumn);
            }
            else
            {
                btnBack.Enabled = false;
            }
        }

        private void dgvBillDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           try
            {
            
               if (dgvBillDetail.Columns[e.ColumnIndex].Name == "btnViewColumn")
                {
                    
                    int id = (int)dgvBillDetail.Rows[e.RowIndex].Cells["Mã Hóa Đơn"].Value;
               dgvBillDetail.Columns.RemoveAt(e.ColumnIndex);  
                dgvBillDetail.DataSource = "";
                  dgvBillDetail.DataSource = BillDAL.GetDetailsByBillId(id);
                }

            }
           catch (Exception ex)
            {

            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (dgvBillDetail.Columns.Count >= 5)
            {
                dgvBillDetail.Columns.RemoveAt(5);
            }
            dgvBillDetail.DataSource = "";
            dgvBillDetail.DataSource = BillDAL.GetRevenueDetails();
            DataGridViewButtonColumn btnViewColumn = new DataGridViewButtonColumn();
            btnViewColumn.Name = "btnViewColumn";
            btnViewColumn.HeaderText = "Chi Tiết Hóa Đơn";
            btnViewColumn.UseColumnTextForButtonValue = true;
            btnViewColumn.Text = "Xem";
            dgvBillDetail.Columns.Add(btnViewColumn);
        }
    }
}
