namespace EMS.BuyStock
{
    partial class frmBuyStock
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txDeadLine = new System.Windows.Forms.TextBox();
            this.txOrderTime = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txSupplierAddress = new System.Windows.Forms.TextBox();
            this.txSupplierTel = new System.Windows.Forms.TextBox();
            this.txSupplierName = new System.Windows.Forms.TextBox();
            this.txSupplierCode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txBuyerCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txBuyer = new System.Windows.Forms.TextBox();
            this.txtBillDate = new System.Windows.Forms.TextBox();
            this.txtBillCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvStockList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEixt = new System.Windows.Forms.Button();
            this.txDetailTotal = new System.Windows.Forms.TextBox();
            this.txtFullPayment = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.txDeadLine);
            this.groupBox1.Controls.Add(this.txOrderTime);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txSupplierAddress);
            this.groupBox1.Controls.Add(this.txSupplierTel);
            this.groupBox1.Controls.Add(this.txSupplierName);
            this.groupBox1.Controls.Add(this.txSupplierCode);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txBuyerCode);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txBuyer);
            this.groupBox1.Controls.Add(this.txtBillDate);
            this.groupBox1.Controls.Add(this.txtBillCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(-2, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(1027, 284);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "采购单";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txDeadLine
            // 
            this.txDeadLine.Location = new System.Drawing.Point(485, 245);
            this.txDeadLine.Name = "txDeadLine";
            this.txDeadLine.Size = new System.Drawing.Size(130, 29);
            this.txDeadLine.TabIndex = 22;
            // 
            // txOrderTime
            // 
            this.txOrderTime.Location = new System.Drawing.Point(143, 244);
            this.txOrderTime.Name = "txOrderTime";
            this.txOrderTime.Size = new System.Drawing.Size(181, 29);
            this.txOrderTime.TabIndex = 21;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(374, 255);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 19);
            this.label13.TabIndex = 20;
            this.label13.Text = "要货日期";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 255);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 19);
            this.label12.TabIndex = 19;
            this.label12.Text = "下单日期";
            // 
            // txSupplierAddress
            // 
            this.txSupplierAddress.Location = new System.Drawing.Point(143, 209);
            this.txSupplierAddress.Name = "txSupplierAddress";
            this.txSupplierAddress.Size = new System.Drawing.Size(181, 29);
            this.txSupplierAddress.TabIndex = 18;
            // 
            // txSupplierTel
            // 
            this.txSupplierTel.Location = new System.Drawing.Point(143, 169);
            this.txSupplierTel.Name = "txSupplierTel";
            this.txSupplierTel.Size = new System.Drawing.Size(181, 29);
            this.txSupplierTel.TabIndex = 17;
            // 
            // txSupplierName
            // 
            this.txSupplierName.Location = new System.Drawing.Point(143, 127);
            this.txSupplierName.Name = "txSupplierName";
            this.txSupplierName.Size = new System.Drawing.Size(181, 29);
            this.txSupplierName.TabIndex = 16;
            // 
            // txSupplierCode
            // 
            this.txSupplierCode.Location = new System.Drawing.Point(143, 81);
            this.txSupplierCode.Name = "txSupplierCode";
            this.txSupplierCode.Size = new System.Drawing.Size(181, 29);
            this.txSupplierCode.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 212);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 19);
            this.label11.TabIndex = 14;
            this.label11.Text = "供应商地址";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 172);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 19);
            this.label10.TabIndex = 13;
            this.label10.Text = "供应商电话";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 19);
            this.label8.TabIndex = 12;
            this.label8.Text = "供应商姓名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 19);
            this.label5.TabIndex = 11;
            this.label5.Text = "供应商编号";
            // 
            // txBuyerCode
            // 
            this.txBuyerCode.Location = new System.Drawing.Point(323, 28);
            this.txBuyerCode.Name = "txBuyerCode";
            this.txBuyerCode.Size = new System.Drawing.Size(100, 29);
            this.txBuyerCode.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(249, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "工号";
            // 
            // txBuyer
            // 
            this.txBuyer.Font = new System.Drawing.Font("宋体", 9F);
            this.txBuyer.Location = new System.Drawing.Point(86, 36);
            this.txBuyer.Margin = new System.Windows.Forms.Padding(5);
            this.txBuyer.Name = "txBuyer";
            this.txBuyer.Size = new System.Drawing.Size(129, 21);
            this.txBuyer.TabIndex = 8;
            // 
            // txtBillDate
            // 
            this.txtBillDate.BackColor = System.Drawing.Color.White;
            this.txtBillDate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline);
            this.txtBillDate.ForeColor = System.Drawing.Color.Blue;
            this.txtBillDate.Location = new System.Drawing.Point(867, 41);
            this.txtBillDate.Margin = new System.Windows.Forms.Padding(5);
            this.txtBillDate.Name = "txtBillDate";
            this.txtBillDate.ReadOnly = true;
            this.txtBillDate.Size = new System.Drawing.Size(119, 21);
            this.txtBillDate.TabIndex = 6;
            this.txtBillDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBillCode
            // 
            this.txtBillCode.BackColor = System.Drawing.Color.White;
            this.txtBillCode.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline);
            this.txtBillCode.ForeColor = System.Drawing.Color.Blue;
            this.txtBillCode.Location = new System.Drawing.Point(543, 38);
            this.txtBillCode.Margin = new System.Windows.Forms.Padding(5);
            this.txtBillCode.Name = "txtBillCode";
            this.txtBillCode.ReadOnly = true;
            this.txtBillCode.Size = new System.Drawing.Size(133, 21);
            this.txtBillCode.TabIndex = 5;
            this.txtBillCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "采购员";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(753, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "录单日期：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(450, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "单据编号：";
            // 
            // dgvStockList
            // 
            this.dgvStockList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvStockList.Location = new System.Drawing.Point(0, 297);
            this.dgvStockList.Margin = new System.Windows.Forms.Padding(5);
            this.dgvStockList.Name = "dgvStockList";
            this.dgvStockList.RowTemplate.Height = 23;
            this.dgvStockList.Size = new System.Drawing.Size(777, 179);
            this.dgvStockList.TabIndex = 1;
            this.dgvStockList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockList_CellContentClick);
            this.dgvStockList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockList_CellDoubleClick);
            this.dgvStockList.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.dgvStockList_CellStateChanged);
            this.dgvStockList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockList_CellValueChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "商品编号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "商品名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 135;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "商品单位";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 120;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "需求数量";
            this.Column4.Name = "Column4";
            this.Column4.Width = 120;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "商品单价";
            this.Column5.Name = "Column5";
            this.Column5.Width = 120;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "商品金额";
            this.Column6.Name = "Column6";
            this.Column6.Width = 120;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 497);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 19);
            this.label6.TabIndex = 2;
            this.label6.Text = "明细条数";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(247, 497);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 19);
            this.label7.TabIndex = 3;
            this.label7.Text = "订单总金额";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(730, 510);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 36);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "申请";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEixt
            // 
            this.btnEixt.Location = new System.Drawing.Point(872, 510);
            this.btnEixt.Margin = new System.Windows.Forms.Padding(5);
            this.btnEixt.Name = "btnEixt";
            this.btnEixt.Size = new System.Drawing.Size(125, 36);
            this.btnEixt.TabIndex = 6;
            this.btnEixt.Text = "废弃";
            this.btnEixt.UseVisualStyleBackColor = true;
            this.btnEixt.Click += new System.EventHandler(this.btnEixt_Click);
            // 
            // txDetailTotal
            // 
            this.txDetailTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txDetailTotal.Font = new System.Drawing.Font("宋体", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txDetailTotal.Location = new System.Drawing.Point(125, 491);
            this.txDetailTotal.Margin = new System.Windows.Forms.Padding(5);
            this.txDetailTotal.Name = "txDetailTotal";
            this.txDetailTotal.Size = new System.Drawing.Size(97, 20);
            this.txDetailTotal.TabIndex = 9;
            this.txDetailTotal.TextChanged += new System.EventHandler(this.txDetailTotal_TextChanged);
            // 
            // txtFullPayment
            // 
            this.txtFullPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtFullPayment.Font = new System.Drawing.Font("宋体", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFullPayment.Location = new System.Drawing.Point(361, 496);
            this.txtFullPayment.Margin = new System.Windows.Forms.Padding(5);
            this.txtFullPayment.Name = "txtFullPayment";
            this.txtFullPayment.Size = new System.Drawing.Size(131, 20);
            this.txtFullPayment.TabIndex = 10;
            this.txtFullPayment.Text = "0";
            // 
            // frmBuyStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 557);
            this.Controls.Add(this.txtFullPayment);
            this.Controls.Add(this.txDetailTotal);
            this.Controls.Add(this.btnEixt);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvStockList);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "frmBuyStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "采购单填写";
            this.Load += new System.EventHandler(this.frmBuyStock_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBillDate;
        private System.Windows.Forms.TextBox txtBillCode;              　 //更改为公共类型
        public System.Windows.Forms.TextBox txBuyer;               //更改为公共类型
        public System.Windows.Forms.DataGridView dgvStockList;      //更改为公共类型
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEixt;
        private System.Windows.Forms.TextBox txDetailTotal;
        private System.Windows.Forms.TextBox txtFullPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.TextBox txBuyerCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txDeadLine;
        private System.Windows.Forms.TextBox txOrderTime;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txSupplierAddress;
        private System.Windows.Forms.TextBox txSupplierTel;
        private System.Windows.Forms.TextBox txSupplierName;
        private System.Windows.Forms.TextBox txSupplierCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
    }
}