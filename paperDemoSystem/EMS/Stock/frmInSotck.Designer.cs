namespace EMS.Stock
{
    partial class frmInSotck
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
            this.dataGridViewInStockList = new System.Windows.Forms.DataGridView();
            this.btBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInStockList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewInStockList
            // 
            this.dataGridViewInStockList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInStockList.Location = new System.Drawing.Point(20, 19);
            this.dataGridViewInStockList.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridViewInStockList.Name = "dataGridViewInStockList";
            this.dataGridViewInStockList.RowTemplate.Height = 23;
            this.dataGridViewInStockList.Size = new System.Drawing.Size(1152, 456);
            this.dataGridViewInStockList.TabIndex = 0;
            this.dataGridViewInStockList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInStockList_CellContentClick);
            this.dataGridViewInStockList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInStockList_CellDoubleClick);
            this.dataGridViewInStockList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInStockList_CellValueChanged);
            // 
            // 
            // btBack
            // 
            this.btBack.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btBack.Location = new System.Drawing.Point(1005, 508);
            this.btBack.Margin = new System.Windows.Forms.Padding(5);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(125, 36);
            this.btBack.TabIndex = 1;
            this.btBack.Text = "返回主菜单";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // frmInSotck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 564);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.dataGridViewInStockList);
            this.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmInSotck";
            this.Text = "待入库清单列表";
            this.Load += new System.EventHandler(this.frmInSotck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInStockList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewInStockList;
        private System.Windows.Forms.Button btBack;
    }
}