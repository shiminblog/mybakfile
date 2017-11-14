using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EMS.SaleStock
{
    public partial class frmSellStockStatus : Form
    {
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
        string G_Str_tradeCode = "";
        string G_Str_fullName = "";

        public frmSellStockStatus()
        {
            InitializeComponent();
        }

        private void frmSellStockStatus_Load(object sender, EventArgs e)
        {
            DataSet ds = null;
            ds=baseinfo.SellStockStatusSum("tb_SellStockStatus");
            dgvStockList.DataSource = ds.Tables[0].DefaultView;
            
        }

        private void tlbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlbtnDetailed_Click(object sender, EventArgs e)
        {
            SelectDataDialog.frmSelectDateTime selectDateTime = new EMS.SelectDataDialog.frmSelectDateTime();
            selectDateTime.groupBox1.Text = "选择--明细商品-" + G_Str_fullName+"-日期";
            selectDateTime.M_Str_object = "Detailed";
            selectDateTime.G_Str_tradeCode = G_Str_tradeCode;
            selectDateTime.G_Str_fullName = G_Str_fullName;
            selectDateTime.ShowDialog();
        }

        private void dgvStockList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
                G_Str_tradeCode = dgvStockList[0, e.RowIndex].Value.ToString();
                G_Str_fullName = dgvStockList[1, e.RowIndex].Value.ToString();
        }

        private void tlbtnSaleAnalyse_Click(object sender, EventArgs e)
        {
        }
    }
}