using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMS.Stock
{
    public partial class frmGoodsEntryWaitList : Form
    {
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
        BaseClass.cPurchaseBill purchaseBillinfo = new EMS.BaseClass.cPurchaseBill();

        public frmGoodsEntryWaitList()
        {
            InitializeComponent();
        }

        private void frmGoodsEntryWaitList_Load(object sender, EventArgs e)
        {
            //1 访问采购数据表，获取所有的采购订单，并显示在 datagridview  /  tb_purchase
            DataSet dsPurchase = null;

            try
            {
                dsPurchase = baseinfo.GetTableDateByFiled("tb_purchase","statu","待入库");
                dgvList.DataSource = dsPurchase.Tables[0].DefaultView;
                dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                dgvList.Columns[0].HeaderText = "采购单号";
                dgvList.Columns[0].Visible = true;

                dgvList.Columns[1].HeaderText = "供应商号";
                dgvList.Columns[1].Visible = true;

                dgvList.Columns[2].HeaderText = "采购员号";
                dgvList.Columns[2].Visible = true;

                dgvList.Columns[3].HeaderText = "下单日期";
                dgvList.Columns[3].Visible = true;

                dgvList.Columns[4].HeaderText = "要货日期";
                dgvList.Columns[4].Visible = true;

                dgvList.Columns[5].HeaderText = "订单总额";
                dgvList.Columns[5].Visible = true;

                dgvList.Columns[6].HeaderText = "订单状态";
                dgvList.Columns[6].Visible = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("页面初始化异常！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //EMS.BuyStock.frmPurchaseDetails l_detail = new EMS.BuyStock.frmPurchaseDetails();
                EMS.Stock.frmGoodsEntryDetail l_detail = new EMS.Stock.frmGoodsEntryDetail();
                l_detail.Owner = this;
                //将供应商编号、明细界面，以便打印出来
                l_detail.PurchaseCode = dgvList[0, e.RowIndex].Value.ToString();
                l_detail.SupplierNumber = dgvList[1, e.RowIndex].Value.ToString();
                l_detail.Show();
            }
            catch (System.Exception ex)
            {
                //this.Close();
            }
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (System.Exception ex)
            { 
                
            }
        }
    }
}
