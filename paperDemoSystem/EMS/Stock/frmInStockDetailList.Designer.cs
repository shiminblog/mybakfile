namespace EMS.Stock
{
    partial class frmInStockDetailList
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
            this.btCancle = new System.Windows.Forms.Button();
            this.btOk = new System.Windows.Forms.Button();
            this.dataGridViewDetailList = new System.Windows.Forms.DataGridView();
            this.txInStockCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePickerInStock = new System.Windows.Forms.DateTimePicker();
            this.txClerkCode = new System.Windows.Forms.TextBox();
            this.txClerkName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetailList)).BeginInit();
            this.SuspendLayout();
            // 
            // btCancle
            // 
            this.btCancle.Location = new System.Drawing.Point(597, 327);
            this.btCancle.Name = "btCancle";
            this.btCancle.Size = new System.Drawing.Size(114, 36);
            this.btCancle.TabIndex = 39;
            this.btCancle.Text = "放弃入库";
            this.btCancle.UseVisualStyleBackColor = true;
            this.btCancle.Click += new System.EventHandler(this.btCancle_Click);
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(12, 327);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(114, 36);
            this.btOk.TabIndex = 38;
            this.btOk.Text = "确认入库";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // dataGridViewDetailList
            // 
            this.dataGridViewDetailList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetailList.Location = new System.Drawing.Point(12, 92);
            this.dataGridViewDetailList.Name = "dataGridViewDetailList";
            this.dataGridViewDetailList.RowTemplate.Height = 23;
            this.dataGridViewDetailList.Size = new System.Drawing.Size(699, 200);
            this.dataGridViewDetailList.TabIndex = 37;
            this.dataGridViewDetailList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDetailList_CellContentClick);
            // 
            // txInStockCode
            // 
            this.txInStockCode.Location = new System.Drawing.Point(535, 55);
            this.txInStockCode.Margin = new System.Windows.Forms.Padding(5);
            this.txInStockCode.Name = "txInStockCode";
            this.txInStockCode.ReadOnly = true;
            this.txInStockCode.Size = new System.Drawing.Size(176, 29);
            this.txInStockCode.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(440, 58);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 19);
            this.label7.TabIndex = 35;
            this.label7.Text = "入库单号";
            // 
            // dateTimePickerInStock
            // 
            this.dateTimePickerInStock.Location = new System.Drawing.Point(535, 13);
            this.dateTimePickerInStock.Margin = new System.Windows.Forms.Padding(5);
            this.dateTimePickerInStock.Name = "dateTimePickerInStock";
            this.dateTimePickerInStock.Size = new System.Drawing.Size(176, 29);
            this.dateTimePickerInStock.TabIndex = 34;
            this.dateTimePickerInStock.ValueChanged += new System.EventHandler(this.dateTimePickerInStock_ValueChanged);
            // 
            // txClerkCode
            // 
            this.txClerkCode.Location = new System.Drawing.Point(303, 17);
            this.txClerkCode.Margin = new System.Windows.Forms.Padding(5);
            this.txClerkCode.Name = "txClerkCode";
            this.txClerkCode.Size = new System.Drawing.Size(113, 29);
            this.txClerkCode.TabIndex = 33;
            // 
            // txClerkName
            // 
            this.txClerkName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txClerkName.Location = new System.Drawing.Point(115, 17);
            this.txClerkName.Margin = new System.Windows.Forms.Padding(5);
            this.txClerkName.Name = "txClerkName";
            this.txClerkName.Size = new System.Drawing.Size(91, 29);
            this.txClerkName.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(440, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 19);
            this.label4.TabIndex = 31;
            this.label4.Text = "入库日期";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 19);
            this.label3.TabIndex = 30;
            this.label3.Text = "工号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 29;
            this.label2.Text = "入库员";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 201);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 19);
            this.label1.TabIndex = 28;
            // 
            // frmInStockDetailList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 368);
            this.Controls.Add(this.btCancle);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.dataGridViewDetailList);
            this.Controls.Add(this.txInStockCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimePickerInStock);
            this.Controls.Add(this.txClerkCode);
            this.Controls.Add(this.txClerkName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmInStockDetailList";
            this.Text = "入库单填写";
            this.Load += new System.EventHandler(this.frmInStockDetailList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetailList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCancle;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.DataGridView dataGridViewDetailList;
        private System.Windows.Forms.TextBox txInStockCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePickerInStock;
        private System.Windows.Forms.TextBox txClerkCode;
        private System.Windows.Forms.TextBox txClerkName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}