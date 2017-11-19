namespace EMS.SaleStock
{
    partial class frmSellStock
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
            this.txtBillCode = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cusomter_code = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.customer_address = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.customer_tel = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.customer_name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.sales_code = new System.Windows.Forms.TextBox();
            this.sales_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFullPayment = new System.Windows.Forms.TextBox();
            this.txtStockQty = new System.Windows.Forms.TextBox();
            this.btnEixt = new System.Windows.Forms.Button();
            this.dgvStockList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockList)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBillCode
            // 
            this.txtBillCode.BackColor = System.Drawing.Color.White;
            this.txtBillCode.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline);
            this.txtBillCode.ForeColor = System.Drawing.Color.Blue;
            this.txtBillCode.Location = new System.Drawing.Point(346, 12);
            this.txtBillCode.Name = "txtBillCode";
            this.txtBillCode.ReadOnly = true;
            this.txtBillCode.Size = new System.Drawing.Size(115, 21);
            this.txtBillCode.TabIndex = 5;
            this.txtBillCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(439, 321);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(149, 313);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "订单总金额";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(149, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "工号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-2, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "商品件数";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.cusomter_code);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.customer_address);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.customer_tel);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.customer_name);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.sales_code);
            this.groupBox1.Controls.Add(this.sales_name);
            this.groupBox1.Controls.Add(this.txtBillCode);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(654, 163);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cusomter_code
            // 
            this.cusomter_code.Location = new System.Drawing.Point(76, 36);
            this.cusomter_code.Name = "cusomter_code";
            this.cusomter_code.Size = new System.Drawing.Size(172, 21);
            this.cusomter_code.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "客户编码";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 142);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 16;
            this.label12.Text = "下单日期";
            // 
            // customer_address
            // 
            this.customer_address.Location = new System.Drawing.Point(76, 114);
            this.customer_address.Name = "customer_address";
            this.customer_address.Size = new System.Drawing.Size(172, 21);
            this.customer_address.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 117);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 14;
            this.label11.Text = "收货地址";
            // 
            // customer_tel
            // 
            this.customer_tel.Location = new System.Drawing.Point(76, 89);
            this.customer_tel.Name = "customer_tel";
            this.customer_tel.Size = new System.Drawing.Size(172, 21);
            this.customer_tel.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "联系电话";
            // 
            // customer_name
            // 
            this.customer_name.Location = new System.Drawing.Point(76, 62);
            this.customer_name.Name = "customer_name";
            this.customer_name.Size = new System.Drawing.Size(172, 21);
            this.customer_name.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "客户名称";
            // 
            // sales_code
            // 
            this.sales_code.Font = new System.Drawing.Font("宋体", 9F);
            this.sales_code.Location = new System.Drawing.Point(184, 14);
            this.sales_code.Name = "sales_code";
            this.sales_code.Size = new System.Drawing.Size(64, 21);
            this.sales_code.TabIndex = 9;
            // 
            // sales_name
            // 
            this.sales_name.Font = new System.Drawing.Font("宋体", 9F);
            this.sales_name.Location = new System.Drawing.Point(57, 12);
            this.sales_name.Name = "sales_name";
            this.sales_name.Size = new System.Drawing.Size(79, 21);
            this.sales_name.TabIndex = 8;
            this.sales_name.TextChanged += new System.EventHandler(this.txtHandle_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "接单员";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(464, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "录单日期：";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(284, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "订单编号";
            // 
            // txtFullPayment
            // 
            this.txtFullPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtFullPayment.Font = new System.Drawing.Font("宋体", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFullPayment.Location = new System.Drawing.Point(220, 309);
            this.txtFullPayment.Name = "txtFullPayment";
            this.txtFullPayment.ReadOnly = true;
            this.txtFullPayment.Size = new System.Drawing.Size(80, 20);
            this.txtFullPayment.TabIndex = 34;
            this.txtFullPayment.Text = "0";
            // 
            // txtStockQty
            // 
            this.txtStockQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtStockQty.Font = new System.Drawing.Font("宋体", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStockQty.Location = new System.Drawing.Point(76, 309);
            this.txtStockQty.Name = "txtStockQty";
            this.txtStockQty.ReadOnly = true;
            this.txtStockQty.Size = new System.Drawing.Size(60, 20);
            this.txtStockQty.TabIndex = 31;
            // 
            // btnEixt
            // 
            this.btnEixt.Location = new System.Drawing.Point(524, 321);
            this.btnEixt.Name = "btnEixt";
            this.btnEixt.Size = new System.Drawing.Size(75, 23);
            this.btnEixt.TabIndex = 29;
            this.btnEixt.Text = "退出";
            this.btnEixt.UseVisualStyleBackColor = true;
            this.btnEixt.Click += new System.EventHandler(this.btnEixt_Click);
            // 
            // dgvStockList
            // 
            this.dgvStockList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvStockList.Location = new System.Drawing.Point(0, 171);
            this.dgvStockList.Name = "dgvStockList";
            this.dgvStockList.RowTemplate.Height = 23;
            this.dgvStockList.Size = new System.Drawing.Size(543, 137);
            this.dgvStockList.TabIndex = 35;
            this.dgvStockList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockList_CellContentClick_1);
            this.dgvStockList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockList_CellDoubleClick);
            this.dgvStockList.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.dgvStockList_CellStateChanged);
            this.dgvStockList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockList_CellValueChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "商品编号";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "商品名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "数量";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "单位";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "单价";
            this.Column5.Name = "Column5";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(524, 11);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(124, 21);
            this.dateTimePicker1.TabIndex = 20;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(76, 142);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(160, 21);
            this.dateTimePicker2.TabIndex = 21;
            // 
            // frmSellStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 357);
            this.Controls.Add(this.dgvStockList);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtFullPayment);
            this.Controls.Add(this.txtStockQty);
            this.Controls.Add(this.btnEixt);
            this.MaximizeBox = false;
            this.Name = "frmSellStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "销售单录入";
            this.Load += new System.EventHandler(this.frmSellStock_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBillCode;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox sales_code;
        public System.Windows.Forms.TextBox sales_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFullPayment;
        private System.Windows.Forms.TextBox txtStockQty;
        private System.Windows.Forms.Button btnEixt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox customer_address;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox customer_tel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox customer_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox cusomter_code;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.DataGridView dgvStockList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}