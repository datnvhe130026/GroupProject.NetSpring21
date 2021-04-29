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
    public partial class frmAccount : Form
    {
        public frmAccount()
        {
            InitializeComponent();
        }
        private void Refresh()
        {
            txtNewPass.Enabled = false;
            txtUsername.Enabled = true;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = AccountDAL.GetAllAccount();
        }
        private bool validAdd()
        {
            if ((txtDisplayName.Text.Equals("")) || (txtPassword.Text.Equals("")) || (txtRepass.Text.Equals("")) || (txtUsername.Text.Equals("")))
            {
                MessageBox.Show("Không được để trống");
                return false;
            }
            if (!Regex.IsMatch(txtDisplayName.Text, "\\w+") || !Regex.IsMatch(txtUsername.Text, "\\w+"))
            {
                MessageBox.Show("sai format, vui lòng nhập lại");
                return false;
            }
            if (Account.GetAccountByNameValidate(txtUsername.Text.Trim()).Count > 0)
            {
                MessageBox.Show("Tên " + txtUsername.Text + " đã tồn tại.");
                txtUsername.Focus();
                return false;
            }
            if (!txtPassword.Text.Equals(txtRepass.Text))
            {
                MessageBox.Show("Sai mật khẩu");
                return false;
            }

            return true;
        }
        private bool validUpdate()
        {

            if ((txtDisplayName.Text.Equals("")) || (txtPassword.Text.Equals("")) || (txtRepass.Text.Equals("")) || (txtUsername.Text.Equals("")))
            {
                MessageBox.Show("Không được để trống");
                return false;
            }
            if (!Regex.IsMatch(txtDisplayName.Text, "\\w+") || !Regex.IsMatch(txtUsername.Text, "\\w+"))
            {
                MessageBox.Show("sai format, vui lòng nhập lại");
                return false;
            }
            if (!txtNewPass.Text.Equals(txtRepass.Text))
            {
                MessageBox.Show("Sai mật khẩu mới");
                return false;
            }
            string password = txtPassword.Text.Trim();
            if (Account.GetAccount(txtUsername.Text.Trim(), txtPassword.Text.Trim()).Count > 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Sai mật khẩu");
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
                    if (MessageBox.Show("Bạn có muốn xóa tài khoản có Username là  " + txtUsername.Text + " không?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (Account.DeleteAccount(txtUsername.Text) > 0)
                        {
                            MessageBox.Show(txtUsername.Text + " Đã xóa tài khoản");
                            Refresh();
                            txtUsername.Text = "";
                            txtDisplayName.Text = "";
                        }
                        else
                            MessageBox.Show("Xóa tài khoản lỗi.");
                    }
                }
                else
                {
                    MessageBox.Show("Hãy Chọn tài khoản cần xóa!");
                }
            }
            catch { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (!validAdd()) return;
            txtNewPass.Enabled = false;
            btnReset.Enabled = true;
            string username = txtUsername.Text.Trim();
            string displayname = txtDisplayName.Text.Trim();
            string password = txtPassword.Text.Trim();
            ArrayList arrayList = new ArrayList() { username, displayname, password };

            if (Account.AddAccount(arrayList) > 0)
            {
                txtDisplayName.Text = "";
                txtPassword.Text = "";
                txtRepass.Text = "";
                txtUsername.Text = "";
                MessageBox.Show("Thêm thành công.");
            }
            else
            {
                MessageBox.Show("Thêm lỗi.");
            }
            Refresh();

        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            txtNewPass.Enabled = false;
            dataGridView1.DataSource = AccountDAL.GetAllAccount();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!validUpdate()) return;
            string username = txtUsername.Text.Trim();
            string displayname = txtDisplayName.Text.Trim();
            string password = txtNewPass.Text.Trim();
            ArrayList arrayList = new ArrayList() { username, displayname, password };
            if (Account.UpdateAccount(arrayList) > 0)
            {
                txtNewPass.Enabled = false;
                MessageBox.Show("Cập nhật " + username + " thành công.");
                txtDisplayName.Text = "";
                txtPassword.Text = "";
                txtNewPass.Text = "";
                txtRepass.Text = "";
                Refresh();
            }
            else
            {
                MessageBox.Show("Cập nhật lỗi.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtUsername.Enabled = false;
                txtNewPass.Enabled = true;
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnReset.Enabled = true;
                //ten mon, gia , tinh trang
                string username = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string Displayname = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtUsername.Text = username;
                txtDisplayName.Text = Displayname;
            }
            catch { }
            }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Enabled = true;
            txtDisplayName.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtNewPass.Text = "";
            txtRepass.Text = "";
            txtNewPass.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length != 0)
            {
                if (Account.GetAccountByUsername(txtSearch.Text.Trim()).Count > 0)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = AccountDAL.GetAccountByUsername(txtSearch.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Không tìm thấy danh mục");
                    Refresh();
                }
            }
            else
            {
                MessageBox.Show("Điền danh mục cần tìm!");
                Refresh();
                txtSearch.Focus();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = AccountDAL.GetAllAccount();
        }
    }
}
