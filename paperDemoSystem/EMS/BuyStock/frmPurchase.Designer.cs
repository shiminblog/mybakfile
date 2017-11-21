namespace EMS.BuyStock
{
    partial class frmPurchase
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
            this.dtPurchaseDetail = new System.Windows.Forms.DataGridView();
            this.goodNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btSave = new System.Windows.Forms.Button();
            this.btCacel = new System.Windows.Forms.Button();
            this.txPurchaseNumber = new System.Windows.Forms.TextBox();
            this.cbEmployeeNumber = new System.Windows.Forms.ComboBox();
            this.txEmpolyeeName = new System.Windows.Forms.TextBox();
            this.cbSupplierNumber = new System.Windows.Forms.ComboBox();
            this.txSupplierName = new System.Windows.Forms.TextBox();
            this.dateOrder = new System.Windows.Forms.DateTimePicker();
            this.dateReceive = new System.Windows.Forms.DateTimePicker();
            this.txTotalPay = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtPurchaseDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dtPurchaseDetail
            // 
            this.dtPurchaseDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtPurchaseDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.goodNumber,
            this.goodsName,
            this.unit,
            this.qty,
            this.price,
            this.totalPrice});
            this.dtPurchaseDetail.Location = new System.Drawing.Point(14, 113);
            this.dtPurchaseDetail.Name = "dtPurchaseDetail";
            this.dtPurchaseDetail.RowTemplate.Height = 23;
            this.dtPurchaseDetail.Size = new System.Drawing.Size(623, 150);
            this.dtPurchaseDetail.TabIndex = 0;
            this.dtPurchaseDetail.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtPurchaseDetail_CellContentDoubleClick);
            this.dtPurchaseDetail.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.dtPurchaseDetail_CellStateChanged);
            this.dtPurchaseDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtPurchaseDetail_CellValueChanged);
            // 
            // goodNumber
            // 
            this.goodNumber.HeaderText = "商品编号";
            this.goodNumber.Name = "goodNumber";
            this.goodNumber.ReadOnly = true;
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
            // totalPrice
            // 
            this.totalPrice.HeaderText = "金额小计";
            this.totalPrice.Name = "totalPrice";
            this.totalPrice.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "采购单号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "采购员";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "员工号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(331, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "供应商名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(331, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "供应商号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(481, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "下单日期";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(481, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "要货日期";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 305);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "订单金额总计";
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(562, 305);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 9;
            this.btSave.Text = "保存";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btCacel
            // 
            this.btCacel.Location = new System.Drawing.Point(562, 354);
            this.btCacel.Name = "btCacel";
            this.btCacel.Size = new System.Drawing.Size(75, 23);
            this.btCacel.TabIndex = 10;
            this.btCacel.Text = "取消";
            this.btCacel.UseVisualStyleBackColor = true;
            this.btCacel.Click += new System.EventHandler(this.btCacel_Click);
            // 
            // txPurchaseNumber
            // 
            this.txPurchaseNumber.Location = new System.Drawing.Point(71, 30);
            this.txPurchaseNumber.Name = "txPurchaseNumber";
            this.txPurchaseNumber.ReadOnly = true;
            this.txPurchaseNumber.Size = new System.Drawing.Size(100, 21);
            this.txPurchaseNumber.TabIndex = 11;
            // 
            // cbEmployeeNumber
            // 
            this.cbEmployeeNumber.FormattingEnabled = true;
            this.cbEmployeeNumber.Location = new System.Drawing.Point(225, 27);
            this.cbEmployeeNumber.Name = "cbEmployeeNumber";
            this.cbEmployeeNumber.Size = new System.Drawing.Size(91, 20);
            this.cbEmployeeNumber.TabIndex = 12;
            this.cbEmployeeNumber.SelectedValueChanged += new System.EventHandler(this.cbEmployeeNumber_SelectedValueChanged);
            // 
            // txEmpolyeeName
            // 
            this.txEmpolyeeName.Location = new System.Drawing.Point(224, 58);
            this.txEmpolyeeName.Name = "txEmpolyeeName";
            this.txEmpolyeeName.ReadOnly = true;
            this.txEmpolyeeName.Size = new System.Drawing.Size(91, 21);
            this.txEmpolyeeName.TabIndex = 13;
            // 
            // cbSupplierNumber
            // 
            this.cbSupplierNumber.FormattingEnabled = true;
            this.cbSupplierNumber.Location = new System.Drawing.Point(390, 32);
            this.cbSupplierNumber.Name = "cbSupplierNumber";
            this.cbSupplierNumber.Size = new System.Drawing.Size(84, 20);
            this.cbSupplierNumber.TabIndex = 14;
            this.cbSupplierNumber.SelectedValueChanged += new System.EventHandler(this.cbSupplierNumber_SelectedValueChanged);
            // 
            // txSupplierName
            // 
            this.txSupplierName.Location = new System.Drawing.Point(390, 61);
            this.txSupplierName.Name = "txSupplierName";
            this.txSupplierName.ReadOnly = true;
            this.txSupplierName.Size = new System.Drawing.Size(84, 21);
            this.txSupplierName.TabIndex = 15;
            // 
            // dateOrder
            // 
            this.dateOrder.Location = new System.Drawing.Point(541, 35);
            this.dateOrder.Name = "dateOrder";
            this.dateOrder.Size = new System.Drawing.Size(106, 21);
            this.dateOrder.TabIndex = 16;
            // 
            // dateReceive
            // 
            this.dateReceive.Location = new System.Drawing.Point(541, 70);
            this.dateReceive.Name = "dateReceive";
            this.dateReceive.Size = new System.Drawing.Size(106, 21);
            this.dateReceive.TabIndex = 17;
            // 
            // txTotalPay
            // 
            this.txTotalPay.Location = new System.Drawing.Point(112, 296);
            this.txTotalPay.Name = "txTotalPay";
            this.txTotalPay.ReadOnly = true;
            this.txTotalPay.Size = new System.Drawing.Size(94, 21);
            this.txTotalPay.TabIndex = 18;
            // 
            // frmPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 389);
            this.Controls.Add(this.txTotalPay);
            this.Controls.Add(this.dateReceive);
            this.Controls.Add(this.dateOrder);
            this.Controls.Add(this.txSupplierName);
            this.Controls.Add(this.cbSupplierNumber);
            this.Controls.Add(this.txEmpolyeeName);
            this.Controls.Add(this.cbEmployeeNumber);
            this.Controls.Add(this.txPurchaseNumber);
            this.Controls.Add(this.btCacel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtPurchaseDetail);
            this.Name = "frmPurchase";
            this.Text = "采购单";
            this.Load += new System.EventHandler(this.frmPurchase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtPurchaseDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtPurchaseDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btCacel;
        private System.Windows.Forms.TextBox txPurchaseNumber;
        private System.Windows.Forms.ComboBox cbEmployeeNumber;
        private System.Windows.Forms.TextBox txEmpolyeeName;
        private System.Windows.Forms.ComboBox cbSupplierNumber;
        private System.Windows.Forms.TextBox txSupplierName;
        private System.Windows.Forms.DateTimePicker dateOrder;
        private System.Windows.Forms.DateTimePicker dateReceive;
        private System.Windows.Forms.TextBox txTotalPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPrice;
    }
}