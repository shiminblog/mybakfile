namespace EMS.BuyStock
{
    partial class frmPurchaseList
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
            this.dataGridViewPurchaseList = new System.Windows.Forms.DataGridView();
            this.btBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPurchaseList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPurchaseList
            // 
            this.dataGridViewPurchaseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPurchaseList.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewPurchaseList.Name = "dataGridViewPurchaseList";
            this.dataGridViewPurchaseList.RowTemplate.Height = 23;
            this.dataGridViewPurchaseList.Size = new System.Drawing.Size(1171, 345);
            this.dataGridViewPurchaseList.TabIndex = 0;
            this.dataGridViewPurchaseList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPurchaseList_CellContentClick);
            this.dataGridViewPurchaseList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPurchaseList_CellDoubleClick);
            this.dataGridViewPurchaseList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPurchaseList_CellValueChanged);
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(1029, 366);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(154, 37);
            this.btBack.TabIndex = 2;
            this.btBack.Text = "返回主菜单";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // frmPurchaseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 415);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.dataGridViewPurchaseList);
            this.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmPurchaseList";
            this.Text = "采购订单列表";
            this.Load += new System.EventHandler(this.frmPurchaseList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPurchaseList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPurchaseList;
        private System.Windows.Forms.Button btBack;
    }
}