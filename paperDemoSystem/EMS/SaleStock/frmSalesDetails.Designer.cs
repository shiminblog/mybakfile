namespace EMS.SaleStock
{
    partial class frmSalesDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txStaffName = new System.Windows.Forms.TextBox();
            this.txBillNumber = new System.Windows.Forms.TextBox();
            this.txCustomerName = new System.Windows.Forms.TextBox();
            this.dateOrderTime = new System.Windows.Forms.DateTimePicker();
            this.txTotalPay = new System.Windows.Forms.TextBox();
            this.dgvDetailList = new System.Windows.Forms.DataGridView();
            this.btPrint = new System.Windows.Forms.Button();
            this.btBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "接单员";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "客户名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "销售单号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(156, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "下单日期";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(361, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "订单金额";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txStaffName
            // 
            this.txStaffName.Location = new System.Drawing.Point(49, 6);
            this.txStaffName.Name = "txStaffName";
            this.txStaffName.ReadOnly = true;
            this.txStaffName.Size = new System.Drawing.Size(100, 21);
            this.txStaffName.TabIndex = 5;
            // 
            // txBillNumber
            // 
            this.txBillNumber.Location = new System.Drawing.Point(214, 6);
            this.txBillNumber.Name = "txBillNumber";
            this.txBillNumber.ReadOnly = true;
            this.txBillNumber.Size = new System.Drawing.Size(100, 21);
            this.txBillNumber.TabIndex = 6;
            // 
            // txCustomerName
            // 
            this.txCustomerName.Location = new System.Drawing.Point(50, 34);
            this.txCustomerName.Name = "txCustomerName";
            this.txCustomerName.ReadOnly = true;
            this.txCustomerName.Size = new System.Drawing.Size(100, 21);
            this.txCustomerName.TabIndex = 7;
            // 
            // dateOrderTime
            // 
            this.dateOrderTime.Location = new System.Drawing.Point(214, 34);
            this.dateOrderTime.Name = "dateOrderTime";
            this.dateOrderTime.Size = new System.Drawing.Size(121, 21);
            this.dateOrderTime.TabIndex = 8;
            // 
            // txTotalPay
            // 
            this.txTotalPay.Location = new System.Drawing.Point(420, 34);
            this.txTotalPay.Name = "txTotalPay";
            this.txTotalPay.ReadOnly = true;
            this.txTotalPay.Size = new System.Drawing.Size(100, 21);
            this.txTotalPay.TabIndex = 9;
            // 
            // dgvDetailList
            // 
            this.dgvDetailList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailList.Location = new System.Drawing.Point(4, 72);
            this.dgvDetailList.Name = "dgvDetailList";
            this.dgvDetailList.RowTemplate.Height = 23;
            this.dgvDetailList.Size = new System.Drawing.Size(530, 150);
            this.dgvDetailList.TabIndex = 10;
            this.dgvDetailList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDetailList_CellFormatting);
            // 
            // btPrint
            // 
            this.btPrint.Location = new System.Drawing.Point(4, 227);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(75, 23);
            this.btPrint.TabIndex = 11;
            this.btPrint.Text = "打印订单";
            this.btPrint.UseVisualStyleBackColor = true;
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(458, 227);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 23);
            this.btBack.TabIndex = 12;
            this.btBack.Text = "返回销售列表";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // frmSalesDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 262);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.dgvDetailList);
            this.Controls.Add(this.txTotalPay);
            this.Controls.Add(this.dateOrderTime);
            this.Controls.Add(this.txCustomerName);
            this.Controls.Add(this.txBillNumber);
            this.Controls.Add(this.txStaffName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmSalesDetails";
            this.Text = "销售单明细";
            this.Load += new System.EventHandler(this.frmSalesDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txStaffName;
        private System.Windows.Forms.TextBox txBillNumber;
        private System.Windows.Forms.TextBox txCustomerName;
        private System.Windows.Forms.DateTimePicker dateOrderTime;
        private System.Windows.Forms.TextBox txTotalPay;
        private System.Windows.Forms.DataGridView dgvDetailList;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.Button btBack;
    }
}