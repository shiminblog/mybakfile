namespace EMS.Stock
{
    partial class frmGoodsOutWaitList
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
            this.dgvWaitList = new System.Windows.Forms.DataGridView();
            this.btBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWaitList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvWaitList
            // 
            this.dgvWaitList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWaitList.Location = new System.Drawing.Point(12, 21);
            this.dgvWaitList.Name = "dgvWaitList";
            this.dgvWaitList.RowTemplate.Height = 23;
            this.dgvWaitList.Size = new System.Drawing.Size(523, 184);
            this.dgvWaitList.TabIndex = 0;
            this.dgvWaitList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWaitList_CellDoubleClick);
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(460, 227);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 23);
            this.btBack.TabIndex = 1;
            this.btBack.Text = "返回";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // frmGoodsOutWaitList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 262);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.dgvWaitList);
            this.Name = "frmGoodsOutWaitList";
            this.Text = "待出库列表";
            this.Load += new System.EventHandler(this.frmGoodsOutWaitList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWaitList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvWaitList;
        private System.Windows.Forms.Button btBack;
    }
}