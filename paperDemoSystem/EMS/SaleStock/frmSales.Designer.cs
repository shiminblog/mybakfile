namespace EMS.SaleStock
{
    partial class frmSales
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
            this.label6 = new System.Windows.Forms.Label();
            this.txSalesNunber = new System.Windows.Forms.TextBox();
            this.dateOrderTime = new System.Windows.Forms.DateTimePicker();
            this.cbEmployeeNumber = new System.Windows.Forms.ComboBox();
            this.txEmpolyeeName = new System.Windows.Forms.TextBox();
            this.cbCustomerNumber = new System.Windows.Forms.ComboBox();
            this.dgvSalesDetailList = new System.Windows.Forms.DataGridView();
            this.goodNnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodsType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stock1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stock2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.txTotalPay = new System.Windows.Forms.TextBox();
            this.btSave = new System.Windows.Forms.Button();
            this.btCacel = new System.Windows.Forms.Button();
            this.cbGoodsNumber = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txCustomerName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesDetailList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "销售单号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "员工号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(339, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "客户编号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(500, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "下单日期";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "商品选择";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(175, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "接单员";
            // 
            // txSalesNunber
            // 
            this.txSalesNunber.Location = new System.Drawing.Point(72, 3);
            this.txSalesNunber.Name = "txSalesNunber";
            this.txSalesNunber.ReadOnly = true;
            this.txSalesNunber.Size = new System.Drawing.Size(97, 21);
            this.txSalesNunber.TabIndex = 6;
            // 
            // dateOrderTime
            // 
            this.dateOrderTime.Location = new System.Drawing.Point(561, 6);
            this.dateOrderTime.Name = "dateOrderTime";
            this.dateOrderTime.Size = new System.Drawing.Size(125, 21);
            this.dateOrderTime.TabIndex = 8;
            // 
            // cbEmployeeNumber
            // 
            this.cbEmployeeNumber.FormattingEnabled = true;
            this.cbEmployeeNumber.Location = new System.Drawing.Point(220, 6);
            this.cbEmployeeNumber.Name = "cbEmployeeNumber";
            this.cbEmployeeNumber.Size = new System.Drawing.Size(113, 20);
            this.cbEmployeeNumber.TabIndex = 9;
            this.cbEmployeeNumber.SelectedIndexChanged += new System.EventHandler(this.cbStaffNumber_SelectedIndexChanged);
            // 
            // txEmpolyeeName
            // 
            this.txEmpolyeeName.Location = new System.Drawing.Point(220, 42);
            this.txEmpolyeeName.Name = "txEmpolyeeName";
            this.txEmpolyeeName.ReadOnly = true;
            this.txEmpolyeeName.Size = new System.Drawing.Size(113, 21);
            this.txEmpolyeeName.TabIndex = 11;
            // 
            // cbCustomerNumber
            // 
            this.cbCustomerNumber.FormattingEnabled = true;
            this.cbCustomerNumber.Location = new System.Drawing.Point(398, 6);
            this.cbCustomerNumber.Name = "cbCustomerNumber";
            this.cbCustomerNumber.Size = new System.Drawing.Size(96, 20);
            this.cbCustomerNumber.TabIndex = 12;
            this.cbCustomerNumber.SelectedIndexChanged += new System.EventHandler(this.cbCustomerNumber_SelectedIndexChanged);
            // 
            // dgvSalesDetailList
            // 
            this.dgvSalesDetailList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesDetailList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.goodNnumber,
            this.goodsType,
            this.goodsName,
            this.unit,
            this.qty,
            this.price,
            this.pay,
            this.stock1,
            this.stock2});
            this.dgvSalesDetailList.Location = new System.Drawing.Point(12, 69);
            this.dgvSalesDetailList.Name = "dgvSalesDetailList";
            this.dgvSalesDetailList.RowTemplate.Height = 23;
            this.dgvSalesDetailList.Size = new System.Drawing.Size(674, 150);
            this.dgvSalesDetailList.TabIndex = 13;
            this.dgvSalesDetailList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesDetailList_CellClick);
            this.dgvSalesDetailList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesDetailList_CellDoubleClick);
            this.dgvSalesDetailList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesDetailList_CellValueChanged);
            // 
            // goodNnumber
            // 
            this.goodNnumber.HeaderText = "商品编号";
            this.goodNnumber.Name = "goodNnumber";
            this.goodNnumber.ReadOnly = true;
            // 
            // goodsType
            // 
            this.goodsType.HeaderText = "商品种类";
            this.goodsType.Name = "goodsType";
            this.goodsType.ReadOnly = true;
            // 
            // goodsName
            // 
            this.goodsName.HeaderText = "商品名称";
            this.goodsName.Name = "goodsName";
            this.goodsName.ReadOnly = true;
            // 
            // unit
            // 
            this.unit.HeaderText = "单位";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            // 
            // qty
            // 
            this.qty.HeaderText = "数量";
            this.qty.Name = "qty";
            // 
            // price
            // 
            this.price.HeaderText = "单价";
            this.price.Name = "price";
            // 
            // pay
            // 
            this.pay.HeaderText = "金额小计";
            this.pay.Name = "pay";
            this.pay.ReadOnly = true;
            // 
            // stock1
            // 
            this.stock1.HeaderText = "预销售";
            this.stock1.Name = "stock1";
            this.stock1.ReadOnly = true;
            // 
            // stock2
            // 
            this.stock2.HeaderText = "当前库存";
            this.stock2.Name = "stock2";
            this.stock2.ReadOnly = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 255);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "订单总金额";
            // 
            // txTotalPay
            // 
            this.txTotalPay.Location = new System.Drawing.Point(83, 252);
            this.txTotalPay.Name = "txTotalPay";
            this.txTotalPay.ReadOnly = true;
            this.txTotalPay.Size = new System.Drawing.Size(85, 21);
            this.txTotalPay.TabIndex = 15;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(607, 225);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 16;
            this.btSave.Text = "保存";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btCacel
            // 
            this.btCacel.Location = new System.Drawing.Point(607, 255);
            this.btCacel.Name = "btCacel";
            this.btCacel.Size = new System.Drawing.Size(75, 23);
            this.btCacel.TabIndex = 17;
            this.btCacel.Text = "取消";
            this.btCacel.UseVisualStyleBackColor = true;
            this.btCacel.Click += new System.EventHandler(this.btCacel_Click);
            // 
            // cbGoodsNumber
            // 
            this.cbGoodsNumber.FormattingEnabled = true;
            this.cbGoodsNumber.Location = new System.Drawing.Point(72, 37);
            this.cbGoodsNumber.Name = "cbGoodsNumber";
            this.cbGoodsNumber.Size = new System.Drawing.Size(97, 20);
            this.cbGoodsNumber.TabIndex = 18;
            this.cbGoodsNumber.SelectedIndexChanged += new System.EventHandler(this.cbGoodsNumber_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(335, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "客户名称";
            // 
            // txCustomerName
            // 
            this.txCustomerName.Location = new System.Drawing.Point(394, 36);
            this.txCustomerName.Name = "txCustomerName";
            this.txCustomerName.ReadOnly = true;
            this.txCustomerName.Size = new System.Drawing.Size(100, 21);
            this.txCustomerName.TabIndex = 20;
            // 
            // frmSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 289);
            this.Controls.Add(this.txCustomerName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbGoodsNumber);
            this.Controls.Add(this.btCacel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.txTotalPay);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvSalesDetailList);
            this.Controls.Add(this.cbCustomerNumber);
            this.Controls.Add(this.txEmpolyeeName);
            this.Controls.Add(this.cbEmployeeNumber);
            this.Controls.Add(this.dateOrderTime);
            this.Controls.Add(this.txSalesNunber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmSales";
            this.Text = "销售单填写";
            this.Load += new System.EventHandler(this.frmSales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesDetailList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txSalesNunber;
        private System.Windows.Forms.DateTimePicker dateOrderTime;
        private System.Windows.Forms.ComboBox cbEmployeeNumber;
        private System.Windows.Forms.TextBox txEmpolyeeName;
        private System.Windows.Forms.ComboBox cbCustomerNumber;
        private System.Windows.Forms.DataGridView dgvSalesDetailList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txTotalPay;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btCacel;
        private System.Windows.Forms.ComboBox cbGoodsNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodNnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodsType;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn pay;
        private System.Windows.Forms.DataGridViewTextBoxColumn stock1;
        private System.Windows.Forms.DataGridViewTextBoxColumn stock2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txCustomerName;
    }
}