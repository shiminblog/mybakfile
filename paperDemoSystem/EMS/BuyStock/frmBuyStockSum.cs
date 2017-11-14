using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EMS.BuyStock
{
    public partial class frmBuyStockSum : Form
    {
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
        BaseClass.cBillInfo billinfo = new EMS.BaseClass.cBillInfo();
        public frmBuyStockSum()
        {
            InitializeComponent();
        }

        private void tlbtnSumDetailed_Click(object sender, EventArgs e)
        {
#if false
            DataSet ds = null;
            billinfo.Handle = tltxtHandle.Text;
            billinfo.Units = tltxtUnits.Text;
            ds = baseinfo.BuyStockSumDetailed(billinfo,"tb_StockSumDetailed",dtpStar.Value,dtpEnd.Value);
            dgvStockList.DataSource = ds.Tables[0].DefaultView;
#endif
        }

        private void tlbtnSum_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            ds = baseinfo.BuyStockSum("tb_StockSum");
            dgvStockList.DataSource = ds.Tables[0].DefaultView;
        }
    }
}