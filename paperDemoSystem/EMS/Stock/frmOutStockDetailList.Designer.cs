namespace EMS.Stock
{
    partial class frmOutStockDetailList
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
            this.txOutStockCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePickerOutStock = new System.Windows.Forms.DateTimePicker();
            this.txClerkCode = new System.Windows.Forms.TextBox();
            this.txClerkName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewDetailList = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetailList)).BeginInit();
            this.SuspendLayout();
            // 
            // txOutStockCode
            // 
            this.txOutStockCode.Location = new System.Drawing.Point(780, 59);
            this.txOutStockCode.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txOutStockCode.Name = "txOutStockCode";
            this.txOutStockCode.Size = new System.Drawing.Size(205, 29);
            this.txOutStockCode.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(664, 59);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 19);
            this.label7.TabIndex = 23;
            this.label7.Text = "出库单号";
            // 
            // dateTimePickerOutStock
            // 
            this.dateTimePickerOutStock.Location = new System.Drawing.Point(780, 12);
            this.dateTimePickerOutStock.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dateTimePickerOutStock.Name = "dateTimePickerOutStock";
            this.dateTimePickerOutStock.Size = new System.Drawing.Size(205, 29);
            this.dateTimePickerOutStock.TabIndex = 21;
            this.dateTimePickerOutStock.ValueChanged += new System.EventHandler(this.dateTimePickerOutStock_ValueChanged);
            // 
            // txClerkCode
            // 
            this.txClerkCode.Location = new System.Drawing.Point(424, 9);
            this.txClerkCode.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txClerkCode.Name = "txClerkCode";
            this.txClerkCode.Size = new System.Drawing.Size(192, 29);
            this.txClerkCode.TabIndex = 20;
            // 
            // txClerkName
            // 
            this.txClerkName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txClerkName.Location = new System.Drawing.Point(101, 6);
            this.txClerkName.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txClerkName.Name = "txClerkName";
            this.txClerkName.Size = new System.Drawing.Size(216, 29);
            this.txClerkName.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(664, 19);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 19);
            this.label4.TabIndex = 18;
            this.label4.Text = "出库日期";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(345, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 19);
            this.label3.TabIndex = 17;
            this.label3.Text = "工号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 16;
            this.label2.Text = "出库员";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 190);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 19);
            this.label1.TabIndex = 15;
            // 
            // dataGridViewDetailList
            // 
            this.dataGridViewDetailList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetailList.Location = new System.Drawing.Point(12, 96);
            this.dataGridViewDetailList.Name = "dataGridViewDetailList";
            this.dataGridViewDetailList.RowTemplate.Height = 23;
            this.dataGridViewDetailList.Size = new System.Drawing.Size(986, 246);
            this.dataGridViewDetailList.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 358);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 36);
            this.button1.TabIndex = 26;
            this.button1.Text = "确认出库";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(884, 358);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 36);
            this.button2.TabIndex = 27;
            this.button2.Text = "放弃出库";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmOutStockDetailList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 396);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewDetailList);
            this.Controls.Add(this.txOutStockCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimePickerOutStock);
            this.Controls.Add(this.txClerkCode);
            this.Controls.Add(this.txClerkName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmOutStockDetailList";
            this.Text = "出库单填写";
            this.Load += new System.EventHandler(this.frmOutStockDetailList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetailList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txOutStockCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePickerOutStock;
        private System.Windows.Forms.TextBox txClerkCode;
        private System.Windows.Forms.TextBox txClerkName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewDetailList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}