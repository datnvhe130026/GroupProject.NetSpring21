using Project.BL;
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
    public partial class frmTable : Form
    {
        public frmTable()
        {
            InitializeComponent();
        }
        public void loadTable()
        {
            dataGridView1.DataSource = DAL.TableDAL.GetAllTable();
        }
        private void frmTable_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            txtID.Enabled = false;
            loadTable();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnReset.Enabled = true;
                //ten mon, gia , tinh trang
                string ID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string Name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string status = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtID.Text = ID;
                txtName.Text = Name;
                if (status.Equals("Có người"))
                {
                    rd0.Checked = true;
                    rd1.Checked = false;
                }
                else
                {
                    rd0.Checked = false;
                    rd1.Checked = true;
                }
            }catch(Exception ex)
            {

            }
        }

        private bool validAdd()
        {
            if (txtName.Text.Equals(""))
            {
                MessageBox.Show("Không được để trống");
                return false;
            }
            if (!Regex.IsMatch(txtName.Text, "\\w+"))
            {
                MessageBox.Show("sai format, vui lòng nhập lại");
                return false;
            }
            if (!rd0.Checked && !rd1.Checked)
            {
                MessageBox.Show("chọn trạng thái cho bàn ăn");
                return false;
            }

            // Kiem tra su ton tai cua Name trong food
            if (Table.GetTableByNameValidate(txtName.Text.Trim()).Count > 0)
            {
                MessageBox.Show("Tên " + txtName.Text + " đã tồn tại.");
                txtName.Focus();
                return false;
            }

            return true;
        }
        private bool validUpdate()
        {
            if (txtName.Text.Equals(""))
            {
                MessageBox.Show("Không được để trống");
                return false;
            }
            if (!Regex.IsMatch(txtName.Text, "\\w+"))
            {
                MessageBox.Show("sai format, vui lòng nhập lại");
                return false;
            }
            if (!rd0.Checked && !rd1.Checked)
            {
                MessageBox.Show("chọn trạng thái cho bàn ăn");
                return false;
            }


            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!validAdd()) return;
            btnReset.Enabled = true;
            string Name = txtName.Text.Trim();
            string Status = "Trống";
            bool check = rd0.Checked;
            if (check)
            {
                Status = "Có người";
            }
            ArrayList arrayList = new ArrayList() { Name, Status };


            if (Table.addTable(arrayList) > 0)
            {
                MessageBox.Show("Thêm thành công.");
            }
            else
            {
                MessageBox.Show("Thêm lỗi.");
            }
            txtID.Text = "";
            txtName.Text = "";
            dataGridView1.DataSource = null;
            loadTable();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
            rd0.Checked = false;
            rd1.Checked = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    if (MessageBox.Show("Bạn có muốn xóa bàn có ID là  " + txtID.Text + " không?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (Table.DeleteTable(txtID.Text) > 0)
                        {
                            MessageBox.Show(txtID.Text + " Đã xóa bàn");
                            dataGridView1.DataSource = null;
                            loadTable();
                            txtID.Text = "";
                            txtName.Text = "";
                            rd0.Checked = false;
                            rd1.Checked = false;
                        }
                        else
                            MessageBox.Show("Xóa bàn lỗi.");
                    }
                }
                else
                {
                    MessageBox.Show("Hãy Chọn bàn cần xóa!");
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!validUpdate()) return;
            int ID = Convert.ToInt32(txtID.Text.Trim());
            string Name = txtName.Text.Trim();
            string Status = "Trống";
            bool check = rd0.Checked;
            if (check)
            {
                Status = "Có người";
            }
            ArrayList arrayList = new ArrayList() { ID, Name, Status };
            if (Table.UpdateTable(arrayList) > 0)
            {
                MessageBox.Show("Cập nhật " + ID + " thành công.");
                dataGridView1.DataSource = null;
                loadTable();
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
                if (Table.SearchTableByName(txtSearch.Text.Trim()).Count > 0)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = Table.SearchTableByName(txtSearch.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Không tìm thấy bàn ");
                    dataGridView1.DataSource = null;
                    loadTable();
                }
            }
            else
            {
                MessageBox.Show("Nhập tên bàn cần tìm");
               
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            loadTable();
        }
    }
}
