namespace EMS.Stock
{
    partial class frmGoodsEntryDetail
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
            this.cbEmployeeNumber = new System.Windows.Forms.ComboBox();
            this.txEmployeeName = new System.Windows.Forms.TextBox();
            this.txSupplierName = new System.Windows.Forms.TextBox();
            this.dgvEntryDetailWait = new System.Windows.Forms.DataGridView();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.dateEntry = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txBillNumber = new System.Windows.Forms.TextBox();
            this.txSupplierNumber = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntryDetailWait)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "仓管员名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "仓管员号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "供应商号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "供应商名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(363, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "入库时间";
            // 
            // cbEmployeeNumber
            // 
            this.cbEmployeeNumber.FormattingEnabled = true;
            this.cbEmployeeNumber.Location = new System.Drawing.Point(71, 6);
            this.cbEmployeeNumber.Name = "cbEmployeeNumber";
            this.cbEmployeeNumber.Size = new System.Drawing.Size(102, 20);
            this.cbEmployeeNumber.TabIndex = 5;
            this.cbEmployeeNumber.SelectedValueChanged += new System.EventHandler(this.cbEmployeeNumber_SelectedValueChanged);
            // 
            // txEmployeeName
            // 
            this.txEmployeeName.Location = new System.Drawing.Point(71, 32);
            this.txEmployeeName.Name = "txEmployeeName";
            this.txEmployeeName.ReadOnly = true;
            this.txEmployeeName.Size = new System.Drawing.Size(100, 21);
            this.txEmployeeName.TabIndex = 8;
            // 
            // txSupplierName
            // 
            this.txSupplierName.Location = new System.Drawing.Point(238, 31);
            this.txSupplierName.Name = "txSupplierName";
            this.txSupplierName.ReadOnly = true;
            this.txSupplierName.Size = new System.Drawing.Size(110, 21);
            this.txSupplierName.TabIndex = 9;
            // 
            // dgvEntryDetailWait
            // 
            this.dgvEntryDetailWait.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEntryDetailWait.Location = new System.Drawing.Point(12, 69);
            this.dgvEntryDetailWait.Name = "dgvEntryDetailWait";
            this.dgvEntryDetailWait.RowTemplate.Height = 23;
            this.dgvEntryDetailWait.Size = new System.Drawing.Size(537, 173);
            this.dgvEntryDetailWait.TabIndex = 10;
            this.dgvEntryDetailWait.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEntryDetailWait_CellClick);
            this.dgvEntryDetailWait.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvEntryDetailWait_CellFormatting);
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(474, 262);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 13;
            this.btOK.Text = "入库";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(474, 301);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 14;
            this.btCancel.Text = "取消";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // dateEntry
            // 
            this.dateEntry.Location = new System.Drawing.Point(422, 5);
            this.dateEntry.Name = "dateEntry";
            this.dateEntry.Size = new System.Drawing.Size(136, 21);
            this.dateEntry.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(354, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "供货单号";
            // 
            // txBillNumber
            // 
            this.txBillNumber.Location = new System.Drawing.Point(422, 32);
            this.txBillNumber.Name = "txBillNumber";
            this.txBillNumber.ReadOnly = true;
            this.txBillNumber.Size = new System.Drawing.Size(132, 21);
            this.txBillNumber.TabIndex = 17;
            // 
            // txSupplierNumber
            // 
            this.txSupplierNumber.Location = new System.Drawing.Point(239, 6);
            this.txSupplierNumber.Name = "txSupplierNumber";
            this.txSupplierNumber.ReadOnly = true;
            this.txSupplierNumber.Size = new System.Drawing.Size(109, 21);
            this.txSupplierNumber.TabIndex = 18;
            // 
            // frmGoodsEntryDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 336);
            this.Controls.Add(this.txSupplierNumber);
            this.Controls.Add(this.txBillNumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateEntry);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.dgvEntryDetailWait);
            this.Controls.Add(this.txSupplierName);
            this.Controls.Add(this.txEmployeeName);
            this.Controls.Add(this.cbEmployeeNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmGoodsEntryDetail";
            this.Text = "商品入库";
            this.Load += new System.EventHandler(this.frmGoodsEntryDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntryDetailWait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbEmployeeNumber;
        private System.Windows.Forms.TextBox txEmployeeName;
        private System.Windows.Forms.TextBox txSupplierName;
        private System.Windows.Forms.DataGridView dgvEntryDetailWait;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.DateTimePicker dateEntry;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txBillNumber;
        private System.Windows.Forms.TextBox txSupplierNumber;
    }
}