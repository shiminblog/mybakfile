using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EMS.SaleStock
{
    public partial class frmSellStockSum : Form
    {
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
        BaseClass.cBillInfo billinfo = new EMS.BaseClass.cBillInfo();
        public frmSellStockSum()
        {
            InitializeComponent();
        }

        private void tlbtnSumDetailed_Click(object sender, EventArgs e)
        {
#if false
            DataSet ds = null;
            billinfo.Handle = tltxtHandle.Text;
            billinfo.Units = tltxtUnits.Text;
            ds = baseinfo.SellStockSumDetailed(billinfo, "tb_SellStockSumDetailed", dtpStar.Value, dtpEnd.Value);
            dgvStockList.DataSource = ds.Tables[0].DefaultView;
#endif
        }

        private void tlbtnSum_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            ds = baseinfo.SellStockSum("tb_SellStock");
            dgvStockList.DataSource = ds.Tables[0].DefaultView;
        }
    }
}