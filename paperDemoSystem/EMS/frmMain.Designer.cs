namespace EMS
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tlmBuy = new System.Windows.Forms.ToolStripMenuItem();
            this.SaleOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.fileRebuyStock = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.采购信息检索ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlmSale = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSellStock = new System.Windows.Forms.ToolStripMenuItem();
            this.fileResellStock = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.客户信息检索ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlmStock = new System.Windows.Forms.ToolStripMenuItem();
            this.fileStockStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.fileUpperLimit = new System.Windows.Forms.ToolStripMenuItem();
            this.fileLowerLimit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tlmBase = new System.Windows.Forms.ToolStripMenuItem();
            this.fileStore = new System.Windows.Forms.ToolStripMenuItem();
            this.tlmSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileUnit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.frmSysPopedom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.fileBakupAndRestor = new System.Windows.Forms.ToolStripMenuItem();
            this.fileClearTable = new System.Windows.Forms.ToolStripMenuItem();
            this.员工管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.员工信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.源码下载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.采购信息查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlmBuy
            // 
            this.tlmBuy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaleOrder,
            this.采购信息检索ToolStripMenuItem,
            this.fileRebuyStock,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.采购信息查询ToolStripMenuItem});
            this.tlmBuy.Name = "tlmBuy";
            this.tlmBuy.Size = new System.Drawing.Size(68, 21);
            this.tlmBuy.Text = "采购管理";
            this.tlmBuy.Click += new System.EventHandler(this.tlmBuy_Click);
            // 
            // SaleOrder
            // 
            this.SaleOrder.Image = global::EMS.Properties.Resources._45;
            this.SaleOrder.Name = "SaleOrder";
            this.SaleOrder.Size = new System.Drawing.Size(152, 22);
            this.SaleOrder.Text = "采购订单制作";
            this.SaleOrder.Click += new System.EventHandler(this.fileBuyStock_Click);
            // 
            // fileRebuyStock
            // 
            this.fileRebuyStock.Image = global::EMS.Properties.Resources._44;
            this.fileRebuyStock.Name = "fileRebuyStock";
            this.fileRebuyStock.Size = new System.Drawing.Size(152, 22);
            this.fileRebuyStock.Text = "供应单录入";
            this.fileRebuyStock.Click += new System.EventHandler(this.fileRebuyStock_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // 采购信息检索ToolStripMenuItem
            // 
            this.采购信息检索ToolStripMenuItem.Name = "采购信息检索ToolStripMenuItem";
            this.采购信息检索ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.采购信息检索ToolStripMenuItem.Text = "采购订单查询";
            this.采购信息检索ToolStripMenuItem.Click += new System.EventHandler(this.采购信息检索ToolStripMenuItem_Click);
            // 
            // tlmSale
            // 
            this.tlmSale.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileSellStock,
            this.fileResellStock,
            this.toolStripSeparator3,
            this.toolStripSeparator4,
            this.客户信息检索ToolStripMenuItem});
            this.tlmSale.Name = "tlmSale";
            this.tlmSale.Size = new System.Drawing.Size(68, 21);
            this.tlmSale.Text = "销售管理";
            this.tlmSale.Click += new System.EventHandler(this.tlmSale_Click);
            // 
            // fileSellStock
            // 
            this.fileSellStock.Image = global::EMS.Properties.Resources._44;
            this.fileSellStock.Name = "fileSellStock";
            this.fileSellStock.Size = new System.Drawing.Size(152, 22);
            this.fileSellStock.Text = "销售订单录入";
            this.fileSellStock.Click += new System.EventHandler(this.fileSellStock_Click);
            // 
            // fileResellStock
            // 
            this.fileResellStock.Image = global::EMS.Properties.Resources._44;
            this.fileResellStock.Name = "fileResellStock";
            this.fileResellStock.Size = new System.Drawing.Size(152, 22);
            this.fileResellStock.Text = "销售订单查询";
            this.fileResellStock.Click += new System.EventHandler(this.fileResellStock_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // 客户信息检索ToolStripMenuItem
            // 
            this.客户信息检索ToolStripMenuItem.Name = "客户信息检索ToolStripMenuItem";
            this.客户信息检索ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.客户信息检索ToolStripMenuItem.Text = "客户信息检索";
            // 
            // tlmStock
            // 
            this.tlmStock.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileStockStatus,
            this.toolStripSeparator5,
            this.fileUpperLimit,
            this.fileLowerLimit,
            this.toolStripSeparator6});
            this.tlmStock.Name = "tlmStock";
            this.tlmStock.Size = new System.Drawing.Size(68, 21);
            this.tlmStock.Text = "仓库管理";
            // 
            // fileStockStatus
            // 
            this.fileStockStatus.Image = global::EMS.Properties.Resources._171;
            this.fileStockStatus.Name = "fileStockStatus";
            this.fileStockStatus.Size = new System.Drawing.Size(124, 22);
            this.fileStockStatus.Text = "出库管理";
            this.fileStockStatus.Click += new System.EventHandler(this.fileStockStatus_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(121, 6);
            // 
            // fileUpperLimit
            // 
            this.fileUpperLimit.Name = "fileUpperLimit";
            this.fileUpperLimit.Size = new System.Drawing.Size(124, 22);
            this.fileUpperLimit.Text = "入库管理";
            this.fileUpperLimit.Click += new System.EventHandler(this.fileUpperLimit_Click);
            // 
            // fileLowerLimit
            // 
            this.fileLowerLimit.Name = "fileLowerLimit";
            this.fileLowerLimit.Size = new System.Drawing.Size(124, 22);
            this.fileLowerLimit.Text = "库存查询";
            this.fileLowerLimit.Click += new System.EventHandler(this.fileLowerLimit_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(121, 6);
            // 
            // tlmBase
            // 
            this.tlmBase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileStore});
            this.tlmBase.Enabled = false;
            this.tlmBase.Name = "tlmBase";
            this.tlmBase.Size = new System.Drawing.Size(68, 21);
            this.tlmBase.Text = "安全管理";
            // 
            // fileStore
            // 
            this.fileStore.Image = global::EMS.Properties.Resources._171;
            this.fileStore.Name = "fileStore";
            this.fileStore.Size = new System.Drawing.Size(148, 22);
            this.fileStore.Text = "用户密码修改";
            this.fileStore.Click += new System.EventHandler(this.fileStore_Click);
            // 
            // tlmSystem
            // 
            this.tlmSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileUnit,
            this.toolStripSeparator10,
            this.frmSysPopedom,
            this.toolStripSeparator11,
            this.fileBakupAndRestor,
            this.fileClearTable});
            this.tlmSystem.Enabled = false;
            this.tlmSystem.Name = "tlmSystem";
            this.tlmSystem.Size = new System.Drawing.Size(88, 21);
            this.tlmSystem.Text = "系统维护(&M)";
            this.tlmSystem.Click += new System.EventHandler(this.tlmSystem_Click);
            // 
            // fileUnit
            // 
            this.fileUnit.Name = "fileUnit";
            this.fileUnit.Size = new System.Drawing.Size(148, 22);
            this.fileUnit.Text = "新建用户";
            this.fileUnit.Click += new System.EventHandler(this.本单位ToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(145, 6);
            // 
            // frmSysPopedom
            // 
            this.frmSysPopedom.Name = "frmSysPopedom";
            this.frmSysPopedom.Size = new System.Drawing.Size(148, 22);
            this.frmSysPopedom.Text = "职位授予";
            this.frmSysPopedom.Click += new System.EventHandler(this.frmSysPopedom_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(145, 6);
            // 
            // fileBakupAndRestor
            // 
            this.fileBakupAndRestor.Name = "fileBakupAndRestor";
            this.fileBakupAndRestor.Size = new System.Drawing.Size(148, 22);
            this.fileBakupAndRestor.Text = "权限分配";
            this.fileBakupAndRestor.Click += new System.EventHandler(this.fileBakupAndRestor_Click);
            // 
            // fileClearTable
            // 
            this.fileClearTable.Name = "fileClearTable";
            this.fileClearTable.Size = new System.Drawing.Size(148, 22);
            this.fileClearTable.Text = "系统数据清理";
            this.fileClearTable.Click += new System.EventHandler(this.fileClearTable_Click);
            // 
            // 员工管理ToolStripMenuItem
            // 
            this.员工管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.员工信息ToolStripMenuItem});
            this.员工管理ToolStripMenuItem.Name = "员工管理ToolStripMenuItem";
            this.员工管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.员工管理ToolStripMenuItem.Text = "员工管理";
            // 
            // 员工信息ToolStripMenuItem
            // 
            this.员工信息ToolStripMenuItem.Name = "员工信息ToolStripMenuItem";
            this.员工信息ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.员工信息ToolStripMenuItem.Text = "员工信息";
            // 
            // 系统信息ToolStripMenuItem
            // 
            this.系统信息ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统帮助ToolStripMenuItem,
            this.关于ToolStripMenuItem,
            this.源码下载ToolStripMenuItem});
            this.系统信息ToolStripMenuItem.Name = "系统信息ToolStripMenuItem";
            this.系统信息ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.系统信息ToolStripMenuItem.Text = "系统信息(&I)";
            // 
            // 系统帮助ToolStripMenuItem
            // 
            this.系统帮助ToolStripMenuItem.Image = global::EMS.Properties.Resources.help;
            this.系统帮助ToolStripMenuItem.Name = "系统帮助ToolStripMenuItem";
            this.系统帮助ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.系统帮助ToolStripMenuItem.Text = "系统帮助";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // 源码下载ToolStripMenuItem
            // 
            this.源码下载ToolStripMenuItem.Name = "源码下载ToolStripMenuItem";
            this.源码下载ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.源码下载ToolStripMenuItem.Text = "下载该源码";
            this.源码下载ToolStripMenuItem.Click += new System.EventHandler(this.源码下载ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileEnd});
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.退出ToolStripMenuItem.Text = "退出系统";
            // 
            // fileEnd
            // 
            this.fileEnd.Image = global::EMS.Properties.Resources.Close;
            this.fileEnd.Name = "fileEnd";
            this.fileEnd.Size = new System.Drawing.Size(148, 22);
            this.fileEnd.Text = "直接退出系统";
            this.fileEnd.Click += new System.EventHandler(this.fileEnd_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlmSale,
            this.tlmBuy,
            this.tlmStock,
            this.tlmBase,
            this.tlmSystem,
            this.员工管理ToolStripMenuItem,
            this.系统信息ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(788, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 采购信息查询ToolStripMenuItem
            // 
            this.采购信息查询ToolStripMenuItem.Name = "采购信息查询ToolStripMenuItem";
            this.采购信息查询ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.采购信息查询ToolStripMenuItem.Text = "采购信息查询";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 468);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "网上销售信息管理系统";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStripMenuItem tlmBuy;
        private System.Windows.Forms.ToolStripMenuItem SaleOrder;
        private System.Windows.Forms.ToolStripMenuItem fileRebuyStock;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripMenuItem tlmSale;
        private System.Windows.Forms.ToolStripMenuItem fileSellStock;
        private System.Windows.Forms.ToolStripMenuItem fileResellStock;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public System.Windows.Forms.ToolStripMenuItem tlmStock;
        private System.Windows.Forms.ToolStripMenuItem fileStockStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem fileUpperLimit;
        private System.Windows.Forms.ToolStripMenuItem fileLowerLimit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        public System.Windows.Forms.ToolStripMenuItem tlmBase;
        private System.Windows.Forms.ToolStripMenuItem fileStore;
        public System.Windows.Forms.ToolStripMenuItem tlmSystem;
        private System.Windows.Forms.ToolStripMenuItem fileUnit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem frmSysPopedom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem fileBakupAndRestor;
        private System.Windows.Forms.ToolStripMenuItem fileClearTable;
        private System.Windows.Forms.ToolStripMenuItem 员工管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 源码下载ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileEnd;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 员工信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 客户信息检索ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 采购信息检索ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 采购信息查询ToolStripMenuItem;

    }
}

