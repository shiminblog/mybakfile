namespace EMS.BuyStock
{
    partial class frmPurchaseDetail
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
            this.dataGridViewPurchaseDetailList = new System.Windows.Forms.DataGridView();
            this.btModify = new System.Windows.Forms.Button();
            this.btBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPurchaseDetailList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPurchaseDetailList
            // 
            this.dataGridViewPurchaseDetailList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPurchaseDetailList.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewPurchaseDetailList.Name = "dataGridViewPurchaseDetailList";
            this.dataGridViewPurchaseDetailList.RowTemplate.Height = 23;
            this.dataGridViewPurchaseDetailList.Size = new System.Drawing.Size(1064, 334);
            this.dataGridViewPurchaseDetailList.TabIndex = 0;
            // 
            // btModify
            // 
            this.btModify.Location = new System.Drawing.Point(27, 370);
            this.btModify.Name = "btModify";
            this.btModify.Size = new System.Drawing.Size(123, 33);
            this.btModify.TabIndex = 1;
            this.btModify.Text = "修改明细";
            this.btModify.UseVisualStyleBackColor = true;
            this.btModify.Click += new System.EventHandler(this.btModify_Click);
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(941, 370);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(107, 32);
            this.btBack.TabIndex = 2;
            this.btBack.Text = "返回上级";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // frmPurchaseDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 415);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.btModify);
            this.Controls.Add(this.dataGridViewPurchaseDetailList);
            this.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmPurchaseDetail";
            this.Text = "采购订单明细表";
            this.Load += new System.EventHandler(this.frmPurchaseDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPurchaseDetailList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPurchaseDetailList;
        private System.Windows.Forms.Button btModify;
        private System.Windows.Forms.Button btBack;
    }
}