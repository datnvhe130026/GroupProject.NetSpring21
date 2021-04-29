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

namespace Project.PL
{
    public partial class frmCategory : Form
    {
        public frmCategory()
        {
            InitializeComponent();
        }
        private bool validAdd()
        {
            if ((txtCategory.Text.Equals("")))
            {
                MessageBox.Show("Không được để trống");
                return false;
            }
            if (!Regex.IsMatch(txtCategory.Text, "\\w+"))
            {
                MessageBox.Show("sai format, vui lòng nhập lại");
                return false;
            }

            // Kiem tra su ton tai cua Name trong food
            if (Category.GetFoodByNameValidate(txtCategory.Text.Trim()).Count > 0)
            {
                MessageBox.Show("Tên " + txtCategory.Text + " đã tồn tại.");
                txtCategory.Focus();
                return false;
            }

            return true;
        }
        private bool validUpdate()
        {
            if ((txtCategory.Text.Equals("")))
            {
                MessageBox.Show("Không được để trống");
                return false;
            }
            if (!Regex.IsMatch(txtCategory.Text, "\\w+"))
            {
                MessageBox.Show("sai format, vui lòng nhập lại");
                return false;
            }

            return true;
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {  btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            txtId.Enabled = false;
            dataGridView1.DataSource = CategoryDAL.GetAllCategory();
        }

        private void RefreshDgvCategory()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = CategoryDAL.GetAllCategory();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (!validAdd()) return;
            string foodCateName = txtCategory.Text.Trim();
            ArrayList arrayList = new ArrayList() { foodCateName };

            if (Category.addNewCategory(arrayList) > 0)
            {
                MessageBox.Show("Thêm thành công !");
                dataGridView1.DataSource = CategoryDAL.GetAllCategory();
            }
            else
            {
                MessageBox.Show("Thêm lỗi !");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    if (MessageBox.Show("Bạn có muốn xóa món ăn có ID là  " + txtId.Text + " không?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (Category.DeleteCategory(txtId.Text) > 0)
                        {
                            MessageBox.Show(txtId.Text + " Đã xóa món ăn");
                            RefreshDgvCategory();
                            txtId.Text = "";
                            txtCategory.Text = "";
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnReset.Enabled = true;
                string foodCateID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCategory.Text = name;
                txtId.Text = foodCateID;
            }
            catch { }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = true;
            txtCategory.Text = "";
            txtId.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!validUpdate()) return;
            int ID = Convert.ToInt32(txtId.Text.Trim());
            string CatagoryName = txtCategory.Text.Trim();

            ArrayList arrayList = new ArrayList() { ID, CatagoryName };
            if (Category.UpdateCategory(arrayList) > 0)
            {
                MessageBox.Show("Cập nhật " + ID + " thành công.");
                RefreshDgvCategory();
            }
            else
            {
                MessageBox.Show("Cập nhật lỗi.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length != 0)
            {
                if (Category.SearchCategoryByName(txtSearch.Text.Trim()).Count > 0)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = CategoryDAL.GetCatagoryByName(txtSearch.Text.Trim());
                }
                else
                {
                    MessageBox.Show("không tìm thấy tên danh mục!");
                    RefreshDgvCategory();
                }
            }
            else
            {
                MessageBox.Show("Nhập tên danh mục bạn cần tìm");
                RefreshDgvCategory();
                txtSearch.Focus();
            }
        }
    }
}
