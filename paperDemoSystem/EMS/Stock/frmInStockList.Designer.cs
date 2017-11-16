namespace EMS.Stock
{
    partial class frmInStockList
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
            this.btBackMain = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInStockList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewInStockList
            // 
            this.dataGridViewInStockList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInStockList.Location = new System.Drawing.Point(13, 12);
            this.dataGridViewInStockList.Name = "dataGridViewInStockList";
            this.dataGridViewInStockList.RowTemplate.Height = 23;
            this.dataGridViewInStockList.Size = new System.Drawing.Size(772, 334);
            this.dataGridViewInStockList.TabIndex = 0;
            this.dataGridViewInStockList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInStockList_CellContentClick);
            this.dataGridViewInStockList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInStockList_CellDoubleClick);
            this.dataGridViewInStockList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInStockList_CellValueChanged);
            // 
            // btBackMain
            // 
            this.btBackMain.Location = new System.Drawing.Point(669, 364);
            this.btBackMain.Name = "btBackMain";
            this.btBackMain.Size = new System.Drawing.Size(75, 23);
            this.btBackMain.TabIndex = 1;
            this.btBackMain.Text = "返回主菜单";
            this.btBackMain.UseVisualStyleBackColor = true;
            this.btBackMain.Click += new System.EventHandler(this.btBackMain_Click);
            // 
            // frmInStockList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 399);
            this.Controls.Add(this.btBackMain);
            this.Controls.Add(this.dataGridViewInStockList);
            this.Name = "frmInStockList";
            this.Text = "入库单列表";
            this.Load += new System.EventHandler(this.frmInStockList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInStockList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewInStockList;
        private System.Windows.Forms.Button btBackMain;
    }
}