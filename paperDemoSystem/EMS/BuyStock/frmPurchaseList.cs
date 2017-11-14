using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMS.BuyStock
{
    public partial class frmPurchaseList : Form
    {
        public frmPurchaseList()
        {
            InitializeComponent();
        }

        private void dataGridViewPurchaseList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridViewPurchaseList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //EMS.SaleStock.frmOrderDetailList orderdetail_list = new EMS.SaleStock.frmOrderDetailList();
            //orderdetail_list.Owner = this;
            ////orderdetail_list.OrderDetailListCode = dataGridViewSellList[0, e.RowIndex].ToString();
            //orderdetail_list.OrderDetailListCode = dataGridViewSellList[0, e.RowIndex].Value.ToString();
            ////this.Text = "" + 
            //// orderdetail_list.Text = "销售订单 " + 
            //orderdetail_list.Show();
            EMS.BuyStock.frmPurchaseDetail purchasedetail_list = new EMS.BuyStock.frmPurchaseDetail();
            purchasedetail_list.PurchaseCode = dataGridViewPurchaseList[0, e.RowIndex].Value.ToString();
            purchasedetail_list.Owner = this;
            purchasedetail_list.Show();
        }

        private void dataGridViewPurchaseList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        { 
            
        }

        private void frmPurchaseList_Load(object sender, EventArgs e)
        {
            BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
            DataSet ds = baseinfo.GetPurchaseList("tb_purchase");
            dataGridViewPurchaseList.DataSource = ds.Tables[0].DefaultView;
            dataGridViewPurchaseList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewPurchaseList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            
            dataGridViewPurchaseList.Columns[0].HeaderText = "采购单编号";
            //dataGridViewPurchaseList.Columns[0].Width = 160;
            dataGridViewPurchaseList.Columns[0].Visible = true;

            dataGridViewPurchaseList.Columns[1].HeaderText = "供应商编号";
            //dataGridViewPurchaseList.Columns[1].Width = 160;
            dataGridViewPurchaseList.Columns[1].Visible = true;

            dataGridViewPurchaseList.Columns[2].HeaderText = "供应商姓名";
            //dataGridViewPurchaseList.Columns[2].Width = 160;
            dataGridViewPurchaseList.Columns[2].Visible = true;

            dataGridViewPurchaseList.Columns[3].HeaderText = "供应商联系电话";
            //dataGridViewPurchaseList.Columns[3].Width = 160;
            dataGridViewPurchaseList.Columns[3].Visible = true;

            dataGridViewPurchaseList.Columns[4].HeaderText = "供应商地址";
            dataGridViewPurchaseList.Columns[4].Visible = true;
            //dataGridViewPurchaseList.Columns[4].Width = 160;

            dataGridViewPurchaseList.Columns[5].HeaderText = "采购员工号";
            dataGridViewPurchaseList.Columns[5].Visible = true;
            //dataGridViewPurchaseList.Columns[5].Width = 160;

            dataGridViewPurchaseList.Columns[6].HeaderText = "采购员姓名";
            dataGridViewPurchaseList.Columns[6].Visible = true;
            //dataGridViewPurchaseList.Columns[6].Width = 160;

            dataGridViewPurchaseList.Columns[7].HeaderText = "下单日期";
            dataGridViewPurchaseList.Columns[7].Visible = true;
            //dataGridViewPurchaseList.Columns[7].Width = 160;

            dataGridViewPurchaseList.Columns[8].HeaderText = "录单日期";
            dataGridViewPurchaseList.Columns[8].Visible = true;
            //dataGridViewPurchaseList.Columns[8].Width = 160;

            dataGridViewPurchaseList.Columns[9].HeaderText = "要货日期";
            dataGridViewPurchaseList.Columns[9].Visible = true;
            //dataGridViewPurchaseList.Columns[9].Width = 160;

            dataGridViewPurchaseList.Columns[10].HeaderText = "商品件数";
            dataGridViewPurchaseList.Columns[10].Visible = true;
            //dataGridViewPurchaseList.Columns[10].Width = 160;

            dataGridViewPurchaseList.Columns[11].HeaderText = "订单总金额";
            dataGridViewPurchaseList.Columns[11].Visible = true;
            //dataGridViewPurchaseList.Columns[11].Width = 160;

            dataGridViewPurchaseList.Columns[12].HeaderText = "订单状态";
            dataGridViewPurchaseList.Columns[12].Visible = true;
            //dataGridViewPurchaseList.Columns[12].Width = 160;
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
