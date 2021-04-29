using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Project.BL;
using Project.DAL;
using Project.PL;
namespace Project.PL
{
    public partial class OrderUI : Form
    {
        private string displayName;
        static DataTable table = GetTable();
        private List<int> foodId = new List<int>();
        private int tableid;
        private string tableName;
       
        public OrderUI()
        {
            InitializeComponent();
           
        }
      
        public OrderUI(string displayname) : this()
        {
            displayName = displayname;
            lblStaff.Text = displayName;
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OrderUI_Load(object sender, EventArgs e)
        {
            List<Table> tables = Table.getAllTable();
            btnPay.Enabled = false;
            btnSave.Enabled = false;
            btnChangeTable.Enabled = false;
            btnSale.Enabled = false;
            cbxCategory.Enabled = false;
            btnSearch.Enabled = false;
            txtFoodName.Enabled = false;
            btnAddFood.Enabled = false;
            cbxChangeTable.DisplayMember = "Name";
            cbxChangeTable.ValueMember = "Id";
            cbxChangeTable.DataSource = TableDAL.GetEmptyTable();
            LoadTable();
            LoadCategory();
           
           
        }
        public void LoadTable()
        {
            flpTable.Controls.Clear();
            List<Table> tables = Table.getAllTable();
            foreach (Table table in tables)
            {
                Button button = new Button() { Width = 150, Height = 150 };
                button.Click += button_Click;
                button.Tag = table;
                button.Text = table.Name + Environment.NewLine + table.Status;
                button.Image = (table.Status.Equals("Trống")) ? Project.Properties.Resources.table__1_ : Project.Properties.Resources.table__3_;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                flpTable.Controls.Add(button);
            }
        }
        private void LoadCategory()
        {
            List<Category> list = Category.GetAllCategory();
            cbxCategory.DisplayMember = "Loại Món";
            cbxCategory.ValueMember = "Id";
            cbxCategory.DataSource = CategoryDAL.GetAllCategory();
            cbxCategory.SelectedValue = list[0].Id;
            
        }
        private void RefreshDataGridView()
        {
            dgvFood.DataSource = "";
            txtFoodName.Text = "";
            LoadCategory();
        }
        private void refreshDgvOrder()
        {
            if (dgvOrder.Columns.Count >= 5)
            {
                dgvOrder.Columns.Remove("btnDeleteColumn");
            }         
            DataGridViewButtonColumn btnDeleteColumn = new DataGridViewButtonColumn();
            btnDeleteColumn.Name = "btnDeleteColumn";
            btnDeleteColumn.HeaderText = "Xóa Món";
            btnDeleteColumn.UseColumnTextForButtonValue = true;
            btnDeleteColumn.Text = "Xóa";
            dgvOrder.Columns.Add(btnDeleteColumn);

        }
        private void button_Click(object sender, EventArgs e)
        {
            btnPay.Enabled = false;
            btnSave.Enabled = true;
            btnChangeTable.Enabled = false;
            btnSale.Enabled = true;
            
            table = GetTable();
            cbxSale.Text = "0";
            RefreshDataGridView();
            tableName = ((sender as Button).Tag as Table).Name;
            tableid = ((sender as Button).Tag as Table).Id;
            string status = ((sender as Button).Tag as Table).Status;
            lblTable.Text = tableName;
           
            dgvOrder.DataSource = MenuDAL.GetMenuByTableId(tableid);
            refreshDgvOrder();
            if (!status.Equals("Trống"))
            {
                if (MenuDAL.GetMenuByTableId(tableid).Rows.Count > 0)
                {
                    txtToTal.Text = Bill.GetAllBill(tableid)[0].TotalPrice.ToString();
                    btnChangeTable.Enabled = true;
                    btnAddFood.Enabled = true;
                    cbxCategory.Enabled = false;
                    txtFoodName.Enabled = false;
                    btnSearch.Enabled = false;
                    btnPay.Enabled = true;
                    cbxSale.Text = Bill.GetAllBill(tableid)[0].Sale.ToString();
                }
                if (status.Equals("Đặt Bàn"))
                {
                    cbxCategory.Enabled = true;
                    txtFoodName.Enabled = true;
                    btnSearch.Enabled = true;
                    btnAddFood.Enabled = false;
                    txtToTal.Text = "";
                }
               
            }
            else
            {
                cbxCategory.Enabled = true;
                txtFoodName.Enabled = true;
                btnSearch.Enabled = true;
                btnAddFood.Enabled = false;               
                txtToTal.Text = "";
               
            }

        }

        static DataTable GetTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Món Ăn", typeof(string));
            table.Columns.Add("Giá Tiền", typeof(double));
            table.Columns.Add("Số Lượng", typeof(int));
            table.Columns.Add("Thành Tiền", typeof(double));           
            return table;
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Bạn có muốn đăng xuất tài khoản không?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                var formToShow = Application.OpenForms.Cast<Form>()
     .FirstOrDefault(c => c is frmLogin);
                if (formToShow != null)
                {
                    formToShow.Show();
                }
                this.Hide();
            }
        }
        private void cbxCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbxCategory.SelectedIndex >=0)
            {
                int catId = (int)cbxCategory.SelectedValue;
                dgvFood.DataSource = FoodDAL.SearchFoodByCategoryId(catId);
            }
        }
    
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int catId = (int)cbxCategory.SelectedValue;
            string name = txtFoodName.Text.Trim();
            dgvFood.DataSource = FoodDAL.SearchFood(catId, name);
        }
        private int checkName(DataGridViewCellEventArgs e)
        {
            int i = 0;
            string name = dgvFood.Rows[e.RowIndex].Cells["Tên Món"].Value.ToString();
            foreach (DataRow dr in table.Rows)
            {

                if (name.Equals(dr["Món Ăn"]))
                {
                    return i;
                }
                i++;
            }
            return -1;
        }
        private void dgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
           {
                
                if (dgvFood.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvFood.CurrentRow.Selected = true;
                    string name = dgvFood.Rows[e.RowIndex].Cells["Tên Món"].Value.ToString();
                    double price = Convert.ToDouble(dgvFood.Rows[e.RowIndex].Cells["Giá Tiền"].Value);
                    int count = 1;
                    double totalPrice = count * price;
                    string status = dgvFood.Rows[e.RowIndex].Cells["Tình Trạng"].Value.ToString();
                    if (!status.Equals("Hết Món"))
                    {if (checkName(e) != -1)
                        {
                            count = (int)table.Rows[checkName(e)]["Số Lượng"];
                            count++;
                            table.Rows[checkName(e)]["Thành tiền"] = count * price;
                            table.Rows[checkName(e)]["Số Lượng"] = count; 
                          
                            dgvOrder.DataSource = table;
                            refreshDgvOrder();
                          
                        }
                        else
                        {
                            foodId.Add((int)dgvFood.Rows[e.RowIndex].Cells["Id"].Value);
                            table.Rows.Add(name, price, count, totalPrice);     
                            dgvOrder.DataSource = table;
                            refreshDgvOrder();                              
                        }
                     double total = 0;
                            foreach (DataGridViewRow dr in dgvOrder.Rows)
                            {
                                total += (double)dr.Cells["Thành Tiền"].Value;
                            }
                            txtToTal.Text = total.ToString("#,###");
                        
                    }
                    else
                    {
                        MessageBox.Show("Món Ăn Bạn Chọn Đã Hết!");
                    }
                }
           }catch(Exception ex)
            {

          }
        }
        private void dgvOrder_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int count = (int)dgvOrder.Rows[e.RowIndex].Cells["Số Lượng"].Value;
            double price = (double)dgvOrder.Rows[e.RowIndex].Cells["Giá Tiền"].Value;
            double totalPrice = count * price;
            dgvOrder.Rows[e.RowIndex].Cells["Thành Tiền"].Value = totalPrice;
            double total = 0;
            foreach (DataGridViewRow dr in dgvOrder.Rows)
            {
                total += Convert.ToDouble(dr.Cells["Thành Tiền"].Value);
            }
            txtToTal.Text = total.ToString("#,###");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnPay.Enabled = true;
            btnChangeTable.Enabled = true;
            bool status = false;
            double totalPrice = Convert.ToDouble(txtToTal.Text);
            int sale = Convert.ToInt32(cbxSale.SelectedItem);
            List<Bill> bills = Bill.GetAllBill(tableid);
            if (!btnAddFood.Enabled)
            {
            ArrayList arrayList = new ArrayList() { DateTime.Now, tableid, status, totalPrice,lblStaff.Text,sale };
             Bill.AddBill(arrayList);
            }
             
            int billId=Bill.GetAllBill(tableid)[0].Id;
            if (Bill.GetAllBill(tableid).Count > 0)
            {
                BillInfor.DeleteBillInfor(billId);
            }
           for(int i = 0; i < dgvOrder.Rows.Count; i++)
            {
                ArrayList billInfor = new ArrayList() { billId, foodId[i], dgvOrder.Rows[i].Cells["Số Lượng"].Value, dgvOrder.Rows[i].Cells["Thành Tiền"].Value };
                BillInfor.AddBill(billInfor);
            }
            ArrayList tableList = new ArrayList() { "Có Người", tableid };
            Table.UpdateTableStatus(tableList);
            LoadTable();
            dgvOrder.DataSource = MenuDAL.GetMenuByTableId(tableid);
            refreshDgvOrder();
        }

        private void btnChangeTable_Click(object sender, EventArgs e)
        {
            if (Bill.GetAllBill(tableid).Count == 0)
            {
                MessageBox.Show("Hãy lưu bàn trước khi chuyển");
            }
            else
            {
                int billId = Bill.GetAllBill(tableid)[0].Id;
                int tableIdChange = Convert.ToInt32(cbxChangeTable.SelectedValue);
                ArrayList oldTable = new ArrayList() { "Trống", tableid };
                ArrayList NewTable = new ArrayList() { "Có Người", tableIdChange };
                ArrayList change = new ArrayList() { tableIdChange, billId };
                Table.UpdateTableStatus(oldTable);
                Table.UpdateTableStatus(NewTable);
                LoadTable();
                Bill.ChangeTableId(change);
                lblTable.Text = tableName;
            }
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            if (Bill.GetAllBill(tableid).Count == 0)
            {
                double totalPrice = Convert.ToDouble(txtToTal.Text);
                double sale = Convert.ToDouble(cbxSale.SelectedItem);
                totalPrice = totalPrice - (totalPrice * (sale / 100));
                txtToTal.Text = totalPrice.ToString("#,###");
            }
            else
            {
                int billId = Bill.GetAllBill(tableid)[0].Id;
                double totalPrice = Convert.ToDouble(txtToTal.Text);
                double sale = Convert.ToDouble(cbxSale.SelectedItem);
                totalPrice = totalPrice - (totalPrice * (sale / 100));
                txtToTal.Text = totalPrice.ToString("#,###");
                ArrayList arrayList = new ArrayList() { totalPrice, billId };
                Bill.ChangeTotalPrice(arrayList);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            string sale = cbxSale.SelectedItem+"";
            frmPrint frmPrint = new frmPrint(sale, tableid);
            PaymentUI paymentUI = new PaymentUI(Convert.ToDouble(txtToTal.Text));
            if (paymentUI.ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                if (frmPrint.ShowDialog() == DialogResult.OK)
                {

                }
                else
                {
                    int billId = Bill.GetAllBill(tableid)[0].Id;
                    ArrayList tableList = new ArrayList() { "Trống", tableid };
                    Table.UpdateTableStatus(tableList);
                    LoadTable();
                    ArrayList arrayList = new ArrayList() { true, billId };
                    if (Bill.ChangeBillStatus(arrayList) > 0)
                    {
                        MessageBox.Show("Thanh Toán Thành Công");
                    }

                    table = GetTable();
                    dgvOrder.DataSource = table;
                    refreshDgvOrder();
                    txtToTal.Text = "";
                }
            }

        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thêm món cho hóa đơn?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cbxCategory.Enabled = true;
                txtFoodName.Enabled = true;
                btnSearch.Enabled = true;
                table = GetTable();
                dgvOrder.DataSource = table;
                refreshDgvOrder();
            }
        }

        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                double total = 0;
                if (dgvOrder.Columns[e.ColumnIndex].Name == "btnDeleteColumn")
                {
                    dgvOrder.Rows.RemoveAt(e.RowIndex);

                    foreach (DataGridViewRow dr in dgvOrder.Rows)
                {
                    total += Convert.ToDouble(dr.Cells["Thành Tiền"]);
                }
                txtToTal.Text = total.ToString();
                }
                
            }
            catch(Exception ex)
            {

            }
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {   
            string clock=String.Format("{0:d/M/yyyy HH:mm:ss}", DateTime.Now);
            lblClock.Text =clock;                    
        }

        private void btnPreOrder_Click(object sender, EventArgs e)
        {
            PreOrderUI preOrder = new PreOrderUI();
            if (preOrder.ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                LoadTable();
            }
        }

      
    }
}
