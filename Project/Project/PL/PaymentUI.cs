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
    public partial class PaymentUI : Form
    {
       double total;
        public PaymentUI(double total)
        {
            InitializeComponent();
            this.total = total;
        }

        private void PaymentUI_Load(object sender, EventArgs e)
        {
            lblTotal.Text = total.ToString("#,###");
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            double total = Convert.ToDouble(lblTotal.Text);
            double money = Convert.ToDouble(txtMoney.Text);
            double result =  money-total;
            if (result < 0)
            {
                result *= result;
                MessageBox.Show("Khách Còn Thiếu " + string.Format("{0:0,#0}", result));
                this.Close();
                this.DialogResult = DialogResult.Cancel;
            }else if (result == 0)
            {
                result *= result;
                MessageBox.Show("Đã Thanh Toán Đủ!");
                this.Close();
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                MessageBox.Show("Cần Trả Lại " + string.Format("{0:0,#0}", result));
                this.Close();
                this.DialogResult = DialogResult.Cancel;
            }
        }
   
    }
}
