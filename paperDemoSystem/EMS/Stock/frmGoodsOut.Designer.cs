namespace EMS.Stock
{
    partial class frmGoodsOut
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
            this.cbEmployeeNumber = new System.Windows.Forms.ComboBox();
            this.txEmployeeName = new System.Windows.Forms.TextBox();
            this.txCustomerNumber = new System.Windows.Forms.TextBox();
            this.txCustomerName = new System.Windows.Forms.TextBox();
            this.dateTimeOutStock = new System.Windows.Forms.DateTimePicker();
            this.txQty = new System.Windows.Forms.TextBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "仓管员号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "仓管员名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "客户编号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "客户姓名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(354, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "出库时间";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(354, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "当前库存";
            // 
            // cbEmployeeNumber
            // 
            this.cbEmployeeNumber.FormattingEnabled = true;
            this.cbEmployeeNumber.Location = new System.Drawing.Point(70, 3);
            this.cbEmployeeNumber.Name = "cbEmployeeNumber";
            this.cbEmployeeNumber.Size = new System.Drawing.Size(101, 20);
            this.cbEmployeeNumber.TabIndex = 6;
            this.cbEmployeeNumber.SelectedValueChanged += new System.EventHandler(this.cbEmployeeNumber_SelectedValueChanged);
            // 
            // txEmployeeName
            // 
            this.txEmployeeName.Location = new System.Drawing.Point(70, 35);
            this.txEmployeeName.Name = "txEmployeeName";
            this.txEmployeeName.ReadOnly = true;
            this.txEmployeeName.Size = new System.Drawing.Size(100, 21);
            this.txEmployeeName.TabIndex = 7;
            // 
            // txCustomerNumber
            // 
            this.txCustomerNumber.Location = new System.Drawing.Point(236, 4);
            this.txCustomerNumber.Name = "txCustomerNumber";
            this.txCustomerNumber.ReadOnly = true;
            this.txCustomerNumber.Size = new System.Drawing.Size(100, 21);
            this.txCustomerNumber.TabIndex = 8;
            // 
            // txCustomerName
            // 
            this.txCustomerName.Location = new System.Drawing.Point(236, 35);
            this.txCustomerName.Name = "txCustomerName";
            this.txCustomerName.ReadOnly = true;
            this.txCustomerName.Size = new System.Drawing.Size(100, 21);
            this.txCustomerName.TabIndex = 9;
            // 
            // dateTimeOutStock
            // 
            this.dateTimeOutStock.Location = new System.Drawing.Point(424, 7);
            this.dateTimeOutStock.Name = "dateTimeOutStock";
            this.dateTimeOutStock.Size = new System.Drawing.Size(126, 21);
            this.dateTimeOutStock.TabIndex = 10;
            // 
            // txQty
            // 
            this.txQty.Location = new System.Drawing.Point(424, 34);
            this.txQty.Name = "txQty";
            this.txQty.ReadOnly = true;
            this.txQty.Size = new System.Drawing.Size(77, 21);
            this.txQty.TabIndex = 11;
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(14, 62);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.Size = new System.Drawing.Size(536, 150);
            this.dgvList.TabIndex = 12;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            this.dgvList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellDoubleClick);
            this.dgvList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvList_CellFormatting);
            this.dgvList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellValueChanged);
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(475, 218);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 13;
            this.btOK.Text = "出库";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(475, 247);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 14;
            this.btCancel.Text = "取消";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // frmGoodsOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 270);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.txQty);
            this.Controls.Add(this.dateTimeOutStock);
            this.Controls.Add(this.txCustomerName);
            this.Controls.Add(this.txCustomerNumber);
            this.Controls.Add(this.txEmployeeName);
            this.Controls.Add(this.cbEmployeeNumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmGoodsOut";
            this.Text = "商品出库";
            this.Load += new System.EventHandler(this.frmGoodsOut_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
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
        private System.Windows.Forms.ComboBox cbEmployeeNumber;
        private System.Windows.Forms.TextBox txEmployeeName;
        private System.Windows.Forms.TextBox txCustomerNumber;
        private System.Windows.Forms.TextBox txCustomerName;
        private System.Windows.Forms.DateTimePicker dateTimeOutStock;
        private System.Windows.Forms.TextBox txQty;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
    }
}