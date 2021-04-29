using Project.BL;
using Project.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
           
        }

        
         private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn Có Chắc Muốn Thoát Khỏi Chương Trình?", "Chú Ý!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
        }
        private void login()
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassWord.Text.Trim();
            List<Account> list = Account.GetAccount(username, password);

            if (list.Count > 0)
            {
                if (list[0].Type)
                {
                    frmAdmin frmAdmin = new frmAdmin();
                    frmAdmin.Show();
                    txtUserName.Text = "";
                    txtPassWord.Text = "";
                    this.Hide();
                }
                else
                {
                    OrderUI order = new OrderUI(list[0].Displayname);
                    order.Show();
                    txtUserName.Text = "";
                    txtPassWord.Text = "";
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Tên Đăng Nhập hoặc Mật Khẩu không chính xác! Xin vui lòng nhập lại!");

            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }
        
        private void txtPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }         
        }
    }
}
