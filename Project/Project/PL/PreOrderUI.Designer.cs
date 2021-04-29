
namespace Project.PL
{
    partial class PreOrderUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pBExit = new System.Windows.Forms.PictureBox();
            this.tcPreOrder = new System.Windows.Forms.TabControl();
            this.tbPreOrder = new System.Windows.Forms.TabPage();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.cbxTableName = new System.Windows.Forms.ComboBox();
            this.txtCusName = new System.Windows.Forms.TextBox();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnPreOrder = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbViewPreOrder = new System.Windows.Forms.TabPage();
            this.dgvViewPreOrder = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBExit)).BeginInit();
            this.tcPreOrder.SuspendLayout();
            this.tbPreOrder.SuspendLayout();
            this.tbViewPreOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewPreOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pBExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(935, 49);
            this.panel1.TabIndex = 1;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label.Location = new System.Drawing.Point(81, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(97, 29);
            this.label.TabIndex = 11;
            this.label.Text = "Đặt Bàn";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Project.Properties.Resources.clover;
            this.pictureBox1.Location = new System.Drawing.Point(8, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pBExit
            // 
            this.pBExit.BackColor = System.Drawing.Color.Transparent;
            this.pBExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.pBExit.Image = global::Project.Properties.Resources.cancel;
            this.pBExit.Location = new System.Drawing.Point(910, 0);
            this.pBExit.Name = "pBExit";
            this.pBExit.Size = new System.Drawing.Size(25, 49);
            this.pBExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBExit.TabIndex = 9;
            this.pBExit.TabStop = false;
            this.pBExit.Click += new System.EventHandler(this.pBExit_Click);
            // 
            // tcPreOrder
            // 
            this.tcPreOrder.Controls.Add(this.tbPreOrder);
            this.tcPreOrder.Controls.Add(this.tbViewPreOrder);
            this.tcPreOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcPreOrder.Location = new System.Drawing.Point(4, 50);
            this.tcPreOrder.Name = "tcPreOrder";
            this.tcPreOrder.SelectedIndex = 0;
            this.tcPreOrder.Size = new System.Drawing.Size(919, 514);
            this.tcPreOrder.TabIndex = 2;
            this.tcPreOrder.SelectedIndexChanged += new System.EventHandler(this.tcPreOrder_SelectedIndexChanged);
            // 
            // tbPreOrder
            // 
            this.tbPreOrder.Controls.Add(this.dtpTime);
            this.tbPreOrder.Controls.Add(this.txtPhone);
            this.tbPreOrder.Controls.Add(this.cbxTableName);
            this.tbPreOrder.Controls.Add(this.txtCusName);
            this.tbPreOrder.Controls.Add(this.btnOrder);
            this.tbPreOrder.Controls.Add(this.btnPreOrder);
            this.tbPreOrder.Controls.Add(this.label4);
            this.tbPreOrder.Controls.Add(this.label3);
            this.tbPreOrder.Controls.Add(this.label2);
            this.tbPreOrder.Controls.Add(this.label1);
            this.tbPreOrder.Location = new System.Drawing.Point(4, 29);
            this.tbPreOrder.Name = "tbPreOrder";
            this.tbPreOrder.Padding = new System.Windows.Forms.Padding(3);
            this.tbPreOrder.Size = new System.Drawing.Size(911, 481);
            this.tbPreOrder.TabIndex = 0;
            this.tbPreOrder.Text = "Đặt Bàn";
            this.tbPreOrder.UseVisualStyleBackColor = true;
            // 
            // dtpTime
            // 
            this.dtpTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime.Location = new System.Drawing.Point(219, 205);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new System.Drawing.Size(200, 30);
            this.dtpTime.TabIndex = 9;
            this.dtpTime.Value = new System.DateTime(2021, 3, 19, 17, 0, 0, 0);
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(219, 87);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(328, 30);
            this.txtPhone.TabIndex = 8;
            // 
            // cbxTableName
            // 
            this.cbxTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTableName.FormattingEnabled = true;
            this.cbxTableName.Location = new System.Drawing.Point(219, 138);
            this.cbxTableName.Name = "cbxTableName";
            this.cbxTableName.Size = new System.Drawing.Size(121, 33);
            this.cbxTableName.TabIndex = 7;
            // 
            // txtCusName
            // 
            this.txtCusName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusName.Location = new System.Drawing.Point(219, 29);
            this.txtCusName.Name = "txtCusName";
            this.txtCusName.Size = new System.Drawing.Size(328, 30);
            this.txtCusName.TabIndex = 6;
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.ForestGreen;
            this.btnOrder.ForeColor = System.Drawing.Color.White;
            this.btnOrder.Location = new System.Drawing.Point(411, 309);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(75, 62);
            this.btnOrder.TabIndex = 5;
            this.btnOrder.Text = "Đặt Món";
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnPreOrder
            // 
            this.btnPreOrder.BackColor = System.Drawing.Color.ForestGreen;
            this.btnPreOrder.ForeColor = System.Drawing.Color.White;
            this.btnPreOrder.Location = new System.Drawing.Point(208, 309);
            this.btnPreOrder.Name = "btnPreOrder";
            this.btnPreOrder.Size = new System.Drawing.Size(75, 62);
            this.btnPreOrder.TabIndex = 4;
            this.btnPreOrder.Text = "Đặt Bàn";
            this.btnPreOrder.UseVisualStyleBackColor = false;
            this.btnPreOrder.Click += new System.EventHandler(this.btnPreOrder_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Thời Gian Đặt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên Bàn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số Điện Thoại";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Khách Hàng";
            // 
            // tbViewPreOrder
            // 
            this.tbViewPreOrder.Controls.Add(this.dgvViewPreOrder);
            this.tbViewPreOrder.Controls.Add(this.btnSearch);
            this.tbViewPreOrder.Controls.Add(this.txtSearch);
            this.tbViewPreOrder.Location = new System.Drawing.Point(4, 29);
            this.tbViewPreOrder.Name = "tbViewPreOrder";
            this.tbViewPreOrder.Padding = new System.Windows.Forms.Padding(3);
            this.tbViewPreOrder.Size = new System.Drawing.Size(911, 481);
            this.tbViewPreOrder.TabIndex = 1;
            this.tbViewPreOrder.Text = "Xem Bàn Đã Đặt";
            this.tbViewPreOrder.UseVisualStyleBackColor = true;
            // 
            // dgvViewPreOrder
            // 
            this.dgvViewPreOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvViewPreOrder.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvViewPreOrder.BackgroundColor = System.Drawing.Color.White;
            this.dgvViewPreOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewPreOrder.Location = new System.Drawing.Point(40, 81);
            this.dgvViewPreOrder.Name = "dgvViewPreOrder";
            this.dgvViewPreOrder.RowHeadersWidth = 51;
            this.dgvViewPreOrder.RowTemplate.Height = 24;
            this.dgvViewPreOrder.Size = new System.Drawing.Size(821, 362);
            this.dgvViewPreOrder.TabIndex = 3;
            this.dgvViewPreOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViewPreOrder_CellClick);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(496, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(121, 32);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(40, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(429, 27);
            this.txtSearch.TabIndex = 0;
            // 
            // PreOrderUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Project.Properties.Resources._1;
            this.ClientSize = new System.Drawing.Size(935, 587);
            this.Controls.Add(this.tcPreOrder);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PreOrderUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PreOrder";
            this.Load += new System.EventHandler(this.PreOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBExit)).EndInit();
            this.tcPreOrder.ResumeLayout(false);
            this.tbPreOrder.ResumeLayout(false);
            this.tbPreOrder.PerformLayout();
            this.tbViewPreOrder.ResumeLayout(false);
            this.tbViewPreOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewPreOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pBExit;
        private System.Windows.Forms.TabControl tcPreOrder;
        private System.Windows.Forms.TabPage tbPreOrder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tbViewPreOrder;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.ComboBox cbxTableName;
        private System.Windows.Forms.TextBox txtCusName;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnPreOrder;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvViewPreOrder;
        private System.Windows.Forms.Button btnSearch;
    }
}