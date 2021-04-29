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
    public partial class PreOrderUI : Form
    {
        public PreOrderUI()
        {
            InitializeComponent();
        }
        private void addButton()
        {
            if (dgvViewPreOrder.Columns.Count > 5)
            {
                dgvViewPreOrder.Columns.Remove("btnDeleteColumn");
            }
            DataGridViewButtonColumn btnDeleteColumn = new DataGridViewButtonColumn();
            btnDeleteColumn.Name = "btnDeleteColumn";
            btnDeleteColumn.HeaderText = "Check In";
            btnDeleteColumn.UseColumnTextForButtonValue = true;
            btnDeleteColumn.Text = "Đã Check In";
            dgvViewPreOrder.Columns.Add(btnDeleteColumn);

        }
        private void pBExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool Valid()
        {
            if (txtCusName.Equals(""))
            {
                MessageBox.Show("Tên Khách Hàng Không được để trống!");
                return false;
            }
            if (!Regex.IsMatch(txtPhone.Text, @"\d{10}"))
            {
                MessageBox.Show("Số Điện Thoại cần có độ dài 10 kí tự");
                return false;
            }        
            return true;

        }
        private void PreOrder_Load(object sender, EventArgs e)
        {
            cbxTableName.DisplayMember = "Name";
            cbxTableName.ValueMember = "Id";
            cbxTableName.DataSource = TableDAL.GetEmptyTable();
            
        }
        private void LoadPreOrder()
        {
            dgvViewPreOrder.DataSource = PreOrderDAL.getALlPreOrder();
            addButton();
        }
        private void btnPreOrder_Click(object sender, EventArgs e)
        {
            if (!Valid()) return;
            ArrayList changTable = new ArrayList() { "Đặt Bàn", cbxTableName.SelectedValue };
            Table.UpdateTableStatus(changTable);
            int Idtable =Convert.ToInt32(cbxTableName.SelectedValue);
            string cusName = txtCusName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            DateTime time = dtpTime.Value;
            ArrayList preOrder = new ArrayList() { Idtable, cusName, phone, time };
            if(PreOrder.AddPreOrder(preOrder) > 0)
            {
                MessageBox.Show("Đặt Bàn Thành Công!");
            }
            else
            {
                MessageBox.Show("Xin Lỗi,Đã Có Lỗi Xảy Ra! Đặt Bàn Thất Bại!");
            }
           

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            OrderUI orderUI = new OrderUI();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();
            dgvViewPreOrder.DataSource = PreOrderDAL.SearchPreOrderByCusNameOrPhone(search);
            addButton();
        }

        private void dgvViewPreOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvViewPreOrder.Columns[e.ColumnIndex].Name == "btnDeleteColumn")
            {
                int pId =(int) dgvViewPreOrder.Rows[e.RowIndex].Cells["Id"].Value;
               
                    if (PreOrder.DeletePreOrder(pId) > 0)
                    {
                        MessageBox.Show("Khách Hàng đã Check In!");
                        dgvViewPreOrder.DataSource = null;
                        LoadPreOrder();

                    }
                    else
                    {
                        MessageBox.Show("Có Lỗi Xảy Ra! Check In không thành công!");
                    }
                
            }
        }

        private void tcPreOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcPreOrder.SelectedIndex == 1)
            {
                LoadPreOrder();
            }
        }
    }
}
