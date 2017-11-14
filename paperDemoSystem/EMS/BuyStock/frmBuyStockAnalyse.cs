using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EMS.BuyStock
{
    public partial class frmBuyStockAnalyse : Form
    {
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
        public frmBuyStockAnalyse()
        {
            InitializeComponent();
        }

        private void tlbtnAllBuyStock_Click(object sender, EventArgs e)
        {
            
            DataSet ds = null;
            ds = baseinfo.BuyAllStockAnalyse("tb_warehouse_detailed");
            dgvStockList.DataSource = ds.Tables[0].DefaultView;
            this.SetdgvStockListHeadText();
        }

        private void SetdgvStockListHeadText()
        {
            dgvStockList.Columns[0].HeaderText = "商品编号";
            dgvStockList.Columns[1].HeaderText = "商品名称";
            dgvStockList.Columns[2].HeaderText = "进货价格";
            dgvStockList.Columns[3].HeaderText = "进货数量";
            dgvStockList.Columns[4].HeaderText = "合计金额";
        }

        private void tlbtnBuyStock_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            ds = baseinfo.BuyStockAnalyse("tb_stockOrtb_warehouse_detailed");
            dgvStockList.DataSource = ds.Tables[0].DefaultView;
            this.SetdgvStockListHeadText();
        }

        private void tlbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}