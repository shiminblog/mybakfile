namespace EMS.Stock
{
    partial class frmOutStockListDetail
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
            this.dataGridViewOutStockListDetail = new System.Windows.Forms.DataGridView();
            this.btBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutStockListDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewOutStockListDetail
            // 
            this.dataGridViewOutStockListDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOutStockListDetail.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewOutStockListDetail.Name = "dataGridViewOutStockListDetail";
            this.dataGridViewOutStockListDetail.RowTemplate.Height = 23;
            this.dataGridViewOutStockListDetail.Size = new System.Drawing.Size(874, 292);
            this.dataGridViewOutStockListDetail.TabIndex = 0;
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(801, 333);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 23);
            this.btBack.TabIndex = 1;
            this.btBack.Text = "返回出库单列表";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // frmOutStockListDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 368);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.dataGridViewOutStockListDetail);
            this.Name = "frmOutStockListDetail";
            this.Text = "出库订单明细表";
            this.Load += new System.EventHandler(this.frmOutStockListDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutStockListDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewOutStockListDetail;
        private System.Windows.Forms.Button btBack;
    }
}