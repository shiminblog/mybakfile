namespace EMS.SaleStock
{
    partial class frmSellStockList
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
            this.dataGridViewSellList = new System.Windows.Forms.DataGridView();
            this.back_main = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSellList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSellList
            // 
            this.dataGridViewSellList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSellList.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewSellList.Name = "dataGridViewSellList";
            this.dataGridViewSellList.ReadOnly = true;
            this.dataGridViewSellList.RowTemplate.Height = 23;
            this.dataGridViewSellList.Size = new System.Drawing.Size(1067, 344);
            this.dataGridViewSellList.TabIndex = 0;
            this.dataGridViewSellList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSellList_CellContentClick_1);
            this.dataGridViewSellList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSellList_CellDoubleClick);
            this.dataGridViewSellList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSellList_CellValueChanged);
            // 
            // back_main
            // 
            this.back_main.Location = new System.Drawing.Point(964, 362);
            this.back_main.Name = "back_main";
            this.back_main.Size = new System.Drawing.Size(115, 50);
            this.back_main.TabIndex = 1;
            this.back_main.Text = "返回主菜单";
            this.back_main.UseVisualStyleBackColor = true;
            this.back_main.Click += new System.EventHandler(this.back_main_Click);
            // 
            // frmSellStockList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 444);
            this.Controls.Add(this.back_main);
            this.Controls.Add(this.dataGridViewSellList);
            this.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmSellStockList";
            this.Text = "销售订单列表";
            this.Load += new System.EventHandler(this.frmSellStockList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSellList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSellList;
        private System.Windows.Forms.Button back_main;
    }
}