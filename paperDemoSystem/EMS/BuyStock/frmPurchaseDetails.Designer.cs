namespace EMS.BuyStock
{
    partial class frmPurchaseDetails
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
            this.dgvDetailList = new System.Windows.Forms.DataGridView();
            this.btBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txStaffName = new System.Windows.Forms.TextBox();
            this.txSupplierName = new System.Windows.Forms.TextBox();
            this.txBillNumber = new System.Windows.Forms.TextBox();
            this.txTotablPay = new System.Windows.Forms.TextBox();
            this.btPrint = new System.Windows.Forms.Button();
            this.dateRecive = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDetailList
            // 
            this.dgvDetailList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailList.Location = new System.Drawing.Point(12, 85);
            this.dgvDetailList.Name = "dgvDetailList";
            this.dgvDetailList.RowTemplate.Height = 23;
            this.dgvDetailList.Size = new System.Drawing.Size(559, 174);
            this.dgvDetailList.TabIndex = 0;
            this.dgvDetailList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDetailList_CellFormatting);
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(460, 283);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(111, 23);
            this.btBack.TabIndex = 1;
            this.btBack.Text = "返回采购单列表";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "采购员";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "供应商";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "要货日期";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(366, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "订单金额";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(174, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "采购单号";
            // 
            // txStaffName
            // 
            this.txStaffName.Location = new System.Drawing.Point(59, 5);
            this.txStaffName.Name = "txStaffName";
            this.txStaffName.ReadOnly = true;
            this.txStaffName.Size = new System.Drawing.Size(100, 21);
            this.txStaffName.TabIndex = 7;
            // 
            // txSupplierName
            // 
            this.txSupplierName.Location = new System.Drawing.Point(62, 24);
            this.txSupplierName.Name = "txSupplierName";
            this.txSupplierName.ReadOnly = true;
            this.txSupplierName.Size = new System.Drawing.Size(100, 21);
            this.txSupplierName.TabIndex = 8;
            // 
            // txBillNumber
            // 
            this.txBillNumber.Location = new System.Drawing.Point(233, 4);
            this.txBillNumber.Name = "txBillNumber";
            this.txBillNumber.ReadOnly = true;
            this.txBillNumber.Size = new System.Drawing.Size(100, 21);
            this.txBillNumber.TabIndex = 9;
            // 
            // txTotablPay
            // 
            this.txTotablPay.Location = new System.Drawing.Point(439, 28);
            this.txTotablPay.Name = "txTotablPay";
            this.txTotablPay.ReadOnly = true;
            this.txTotablPay.Size = new System.Drawing.Size(82, 21);
            this.txTotablPay.TabIndex = 11;
            // 
            // btPrint
            // 
            this.btPrint.Location = new System.Drawing.Point(16, 283);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(75, 23);
            this.btPrint.TabIndex = 12;
            this.btPrint.Text = "打印订单";
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // dateRecive
            // 
            this.dateRecive.Location = new System.Drawing.Point(233, 28);
            this.dateRecive.Name = "dateRecive";
            this.dateRecive.Size = new System.Drawing.Size(117, 21);
            this.dateRecive.TabIndex = 13;
            // 
            // frmPurchaseDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 318);
            this.Controls.Add(this.dateRecive);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.txTotablPay);
            this.Controls.Add(this.txBillNumber);
            this.Controls.Add(this.txSupplierName);
            this.Controls.Add(this.txStaffName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.dgvDetailList);
            this.Name = "frmPurchaseDetails";
            this.Text = "采购单明细";
            this.Load += new System.EventHandler(this.frmPurchaseDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetailList;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txStaffName;
        private System.Windows.Forms.TextBox txSupplierName;
        private System.Windows.Forms.TextBox txBillNumber;
        private System.Windows.Forms.TextBox txTotablPay;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.DateTimePicker dateRecive;
    }
}