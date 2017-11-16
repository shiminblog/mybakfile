namespace EMS.Stock
{
    partial class frmOutStock
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
            this.dataGridViewOrderList = new System.Windows.Forms.DataGridView();
            this.btCacle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewOrderList
            // 
            this.dataGridViewOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderList.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewOrderList.Name = "dataGridViewOrderList";
            this.dataGridViewOrderList.RowTemplate.Height = 23;
            this.dataGridViewOrderList.Size = new System.Drawing.Size(603, 177);
            this.dataGridViewOrderList.TabIndex = 7;
            this.dataGridViewOrderList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrderList_CellContentClick);
            this.dataGridViewOrderList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrderList_CellDoubleClick);
            this.dataGridViewOrderList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrderList_CellValueChanged);
            // 
            // btCacle
            // 
            this.btCacle.Location = new System.Drawing.Point(490, 237);
            this.btCacle.Name = "btCacle";
            this.btCacle.Size = new System.Drawing.Size(125, 34);
            this.btCacle.TabIndex = 10;
            this.btCacle.Text = "返回主菜单";
            this.btCacle.UseVisualStyleBackColor = true;
            this.btCacle.Click += new System.EventHandler(this.btCacle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "待出库订单列表";
            // 
            // frmOutStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 293);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCacle);
            this.Controls.Add(this.dataGridViewOrderList);
            this.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmOutStock";
            this.Text = "出库界面";
            this.Load += new System.EventHandler(this.frmOutStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewOrderList;
        private System.Windows.Forms.Button btCacle;
        private System.Windows.Forms.Label label1;
    }
}