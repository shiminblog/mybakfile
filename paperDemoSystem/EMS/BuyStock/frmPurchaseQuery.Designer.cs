namespace EMS.BuyStock
{
    partial class frmPurchaseQuery
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
            this.dgvPurchaseList = new System.Windows.Forms.DataGridView();
            this.btBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPurchaseList
            // 
            this.dgvPurchaseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseList.Location = new System.Drawing.Point(12, 38);
            this.dgvPurchaseList.Name = "dgvPurchaseList";
            this.dgvPurchaseList.RowTemplate.Height = 23;
            this.dgvPurchaseList.Size = new System.Drawing.Size(468, 163);
            this.dgvPurchaseList.TabIndex = 0;
            this.dgvPurchaseList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchaseList_CellDoubleClick);
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(405, 227);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 23);
            this.btBack.TabIndex = 1;
            this.btBack.Text = "返回";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // frmPurchaseQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 262);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.dgvPurchaseList);
            this.Name = "frmPurchaseQuery";
            this.Text = "采购单列表";
            this.Load += new System.EventHandler(this.frmPurchaseQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPurchaseList;
        private System.Windows.Forms.Button btBack;
    }
}