namespace EMS.SaleStock
{
    partial class frmSalesQuery
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
            this.dgvSalesList = new System.Windows.Forms.DataGridView();
            this.btBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSalesList
            // 
            this.dgvSalesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesList.Location = new System.Drawing.Point(12, 24);
            this.dgvSalesList.Name = "dgvSalesList";
            this.dgvSalesList.RowTemplate.Height = 23;
            this.dgvSalesList.Size = new System.Drawing.Size(486, 182);
            this.dgvSalesList.TabIndex = 0;
            this.dgvSalesList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesList_CellDoubleClick);
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(423, 227);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 23);
            this.btBack.TabIndex = 1;
            this.btBack.Text = "返回";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // frmSalesQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 262);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.dgvSalesList);
            this.Name = "frmSalesQuery";
            this.Text = "销售订单列表";
            this.Load += new System.EventHandler(this.frmSalesQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSalesList;
        private System.Windows.Forms.Button btBack;
    }
}