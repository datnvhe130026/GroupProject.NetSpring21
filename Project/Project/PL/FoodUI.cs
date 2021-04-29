using Project.BL;
using Project.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Project
{
    public partial class frmFood : Form
    {
       
        public frmFood()
        {
            InitializeComponent();
        }

        private void frmFood_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            loadFoodData();
            loadFoodCategory();
            txtId.Enabled = false;
        }
        public void loadFoodData()
        {
            dataGridView1.DataSource = FoodDAL.GetAllFood();
        }
        //load foodCategory into Combobox
        public void loadFoodCategory()
        {
            //   comboBox2.Items.Insert(0, "-----All-----");
            //set value for combobox 2
            cbxCatname.DisplayMember = "name";
            cbxCatname.ValueMember = "id";
            cbxCatname.DataSource = Category.GetAllCategory();
            cbxCatname.SelectedIndex = 0;
            //set value for combobox 1
            cbxSearch.DisplayMember = "name";
            cbxSearch.ValueMember = "id";
            cbxSearch.DataSource = Category.GetAllCategory();
            cbxSearch.SelectedIndex = 0;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //set status for add, update, delete, reset button
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnReset.Enabled = true;
                //ten mon, gia , tinh trang
                string foodID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string foodName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string status = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                string price = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                string foodCateID = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtId.Text = foodID;
                txtName.Text = foodName;
                txtPrice.Text = price;
                if (status.Equals("Còn Món"))
                {
                    rd0.Checked = true;
                    rd1.Checked = false;
                }
                else
                {
                    rd0.Checked = false;
                    rd1.Checked = true;
                }
                cbxCatname.SelectedIndex = cbxCatname.FindStringExact(foodCateID);
            }
            catch { }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            cbxCatname.SelectedIndex = 0;
            txtId.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            rd0.Checked = false;
            rd1.Checked = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void RefreshDgvCategory()
        {
            dataGridView1.DataSource = null;
            loadFoodData();
            loadFoodCategory();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (!validAdd()) return;
            btnReset.Enabled = true;
            string foodName = txtName.Text.Trim();
            int foodCategory = Convert.ToInt32(cbxCatname.SelectedValue.ToString());
            double price = Convert.ToDouble(txtPrice.Text.Trim());
            string foodStatus = "Hết Món";
            bool check = rd0.Checked;
            if (check)
            {
                foodStatus = "Còn Món";
            }
            ArrayList arrayList = new ArrayList() { foodName, foodCategory, foodStatus, price };


            if (Food.addFood(arrayList) > 0)
            {
                MessageBox.Show("Thêm thành công.");
            }
            else
            {
                MessageBox.Show("Thêm lỗi.");
            }
            RefreshDgvCategory();

        }
        private bool validAdd()
        {
            if ((txtName.Text.Equals("")) || (txtPrice.Text.Equals("")))
            {
                MessageBox.Show("Không được để trống");
                return false;
            }
            if (!Regex.IsMatch(txtName.Text, "\\w+") || !Regex.IsMatch(txtPrice.Text, "\\d+"))
            {
                MessageBox.Show("sai format, vui lòng nhập lại");
                return false;
            }
            if (!rd0.Checked && !rd1.Checked)
            {
                MessageBox.Show("chọn trạng thái cho món ăn");
                return false;
            }

            // Kiem tra su ton tai cua Name trong food
            if (Food.GetFoodByNameValidate(txtName.Text.Trim()).Count > 0)
            {
                MessageBox.Show("Tên " + txtName.Text + " đã tồn tại.");
                txtName.Focus();
                return false;
            }

            return true;
        }
        private bool validUpdate()
        {
            if ((txtName.Text.Equals("")) || (txtPrice.Text.Equals("")))
            {
                MessageBox.Show("Không được để trống");
                return false;
            }
            if (!Regex.IsMatch(txtName.Text, "\\w+") || !Regex.IsMatch(txtPrice.Text, "\\d+"))
            {
                MessageBox.Show("sai format, vui lòng nhập lại");
                return false;
            }
            if (!rd0.Checked && !rd1.Checked)
            {
                MessageBox.Show("chọn trạng thái cho món ăn");
                return false;
            }

            return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    if (MessageBox.Show("Bạn có muốn xóa món ăn có ID là  " + txtId.Text + " không?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (Food.DeleteFood(txtId.Text) > 0)
                        {
                            MessageBox.Show(txtId.Text + " Đã xóa món ăn");
                            RefreshDgvCategory();
                            txtId.Text = "";
                            txtName.Text = "";
                            txtPrice.Text = "";
                        }
                        else
                            MessageBox.Show("Xóa món ăn lỗi.");
                    }
                }
                else
                {
                    MessageBox.Show("Hãy Chọn Món ăn cần xóa!");
                }
            }
            catch { }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (!validUpdate()) return;
            int fooID = Convert.ToInt32(txtId.Text.Trim());
            string foodName = txtName.Text.Trim();
            int foodCate = Convert.ToInt32(cbxCatname.SelectedValue);
            double price = Convert.ToDouble(txtPrice.Text.Trim());

            string foodStatus = "Hết Món";
            bool check = rd0.Checked;
            if (check)
            {
                foodStatus = "Còn Món";
            }
            ArrayList arrayList = new ArrayList() { fooID, foodName, foodCate, foodStatus, price };
            if (Food.UpdateFood(arrayList) > 0)
            {
                MessageBox.Show("Cập nhật " + fooID + " thành công.");
                RefreshDgvCategory();
            }
            else
            {
                MessageBox.Show("Cập nhật lỗi.");
            }
        }

        private void cbxSearch_SelectedValueChanged(object sender, EventArgs e)
        {
            int foodCateID = Convert.ToInt32(cbxSearch.SelectedValue);
            dataGridView1.DataSource = FoodDAL.SearchFoodByCategoryId(foodCateID);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int catId =Convert.ToInt32(cbxSearch.SelectedValue);
            if (txtSearch.Text.Length != 0)
            {
                if (Food.SearchFood(catId,txtSearch.Text.Trim()).Count > 0)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = Food.SearchFood(catId, txtSearch.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Không tìm thấy danh mục");
                    RefreshDgvCategory();
                }
            }
            else
            {
                MessageBox.Show("Điền danh mục cần tìm!");
                RefreshDgvCategory();
                txtSearch.Focus();
            }
        }

    }

}
