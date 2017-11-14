namespace EMS.SaleStock
{
    partial class frmOrderDetailList
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
            this.BtmodifyDetail = new System.Windows.Forms.Button();
            this.BtBack = new System.Windows.Forms.Button();
            this.dataGridViewOrderDetailList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderDetailList)).BeginInit();
            this.SuspendLayout();
            // 
            // BtmodifyDetail
            // 
            this.BtmodifyDetail.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtmodifyDetail.Location = new System.Drawing.Point(58, 486);
            this.BtmodifyDetail.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.BtmodifyDetail.Name = "BtmodifyDetail";
            this.BtmodifyDetail.Size = new System.Drawing.Size(193, 59);
            this.BtmodifyDetail.TabIndex = 1;
            this.BtmodifyDetail.Text = "修改明细";
            this.BtmodifyDetail.UseVisualStyleBackColor = true;
            this.BtmodifyDetail.Click += new System.EventHandler(this.BtmodifyDetail_Click);
            // 
            // BtBack
            // 
            this.BtBack.Location = new System.Drawing.Point(883, 486);
            this.BtBack.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.BtBack.Name = "BtBack";
            this.BtBack.Size = new System.Drawing.Size(125, 57);
            this.BtBack.TabIndex = 2;
            this.BtBack.Text = "返回上级";
            this.BtBack.UseVisualStyleBackColor = true;
            this.BtBack.Click += new System.EventHandler(this.BtBack_Click);
            // 
            // dataGridViewOrderDetailList
            // 
            this.dataGridViewOrderDetailList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderDetailList.Location = new System.Drawing.Point(20, 19);
            this.dataGridViewOrderDetailList.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridViewOrderDetailList.Name = "dataGridViewOrderDetailList";
            this.dataGridViewOrderDetailList.RowTemplate.Height = 23;
            this.dataGridViewOrderDetailList.Size = new System.Drawing.Size(1072, 429);
            this.dataGridViewOrderDetailList.TabIndex = 0;
            this.dataGridViewOrderDetailList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrderDetailList_CellContentClick);
            this.dataGridViewOrderDetailList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrderDetailList_CellDoubleClick);
            this.dataGridViewOrderDetailList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrderDetailList_CellValueChanged);
            // 
            // frmOrderDetailList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 564);
            this.Controls.Add(this.BtBack);
            this.Controls.Add(this.BtmodifyDetail);
            this.Controls.Add(this.dataGridViewOrderDetailList);
            this.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmOrderDetailList";
            this.Text = "销售订单明细表";
            this.Load += new System.EventHandler(this.frmOrderDetailList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderDetailList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtmodifyDetail;
        private System.Windows.Forms.Button BtBack;
        private System.Windows.Forms.DataGridView dataGridViewOrderDetailList;
    }
}