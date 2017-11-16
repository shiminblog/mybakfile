namespace EMS.Stock
{
    partial class frmInStockListDetail
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
            this.dataGridViewInStockListDetail = new System.Windows.Forms.DataGridView();
            this.btBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInStockListDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewInStockListDetail
            // 
            this.dataGridViewInStockListDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInStockListDetail.Location = new System.Drawing.Point(13, 12);
            this.dataGridViewInStockListDetail.Name = "dataGridViewInStockListDetail";
            this.dataGridViewInStockListDetail.RowTemplate.Height = 23;
            this.dataGridViewInStockListDetail.Size = new System.Drawing.Size(824, 310);
            this.dataGridViewInStockListDetail.TabIndex = 0;
            this.dataGridViewInStockListDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInStockListDetail_CellContentClick);
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(710, 339);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(99, 23);
            this.btBack.TabIndex = 1;
            this.btBack.Text = "返回入库单列表";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // frmInStockListDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 374);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.dataGridViewInStockListDetail);
            this.Name = "frmInStockListDetail";
            this.Text = "入库单明细表";
            this.Load += new System.EventHandler(this.frmInStockListDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInStockListDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewInStockListDetail;
        private System.Windows.Forms.Button btBack;
    }
}