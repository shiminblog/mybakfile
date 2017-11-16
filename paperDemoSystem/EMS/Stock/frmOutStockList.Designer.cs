namespace EMS.Stock
{
    partial class frmOutStockList
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
            this.dataGridViewOutStockList = new System.Windows.Forms.DataGridView();
            this.btBackMain = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutStockList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewOutStockList
            // 
            this.dataGridViewOutStockList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOutStockList.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewOutStockList.Name = "dataGridViewOutStockList";
            this.dataGridViewOutStockList.RowTemplate.Height = 23;
            this.dataGridViewOutStockList.Size = new System.Drawing.Size(537, 215);
            this.dataGridViewOutStockList.TabIndex = 0;
            this.dataGridViewOutStockList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOutStockList_CellContentClick);
            this.dataGridViewOutStockList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOutStockList_CellDoubleClick);
            this.dataGridViewOutStockList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOutStockList_CellValueChanged);
            // 
            // btBackMain
            // 
            this.btBackMain.Location = new System.Drawing.Point(474, 245);
            this.btBackMain.Name = "btBackMain";
            this.btBackMain.Size = new System.Drawing.Size(75, 23);
            this.btBackMain.TabIndex = 1;
            this.btBackMain.Text = "返回主菜单";
            this.btBackMain.UseVisualStyleBackColor = true;
            this.btBackMain.Click += new System.EventHandler(this.btBackMain_Click);
            // 
            // frmOutStockList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 272);
            this.Controls.Add(this.btBackMain);
            this.Controls.Add(this.dataGridViewOutStockList);
            this.Name = "frmOutStockList";
            this.Text = "出库单列表";
            this.Load += new System.EventHandler(this.frmOutStockList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutStockList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewOutStockList;
        private System.Windows.Forms.Button btBackMain;
    }
}