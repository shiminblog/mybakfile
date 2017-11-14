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
    public partial class frmPurchaseDetail : Form
    {
        public frmPurchaseDetail()
        {
            InitializeComponent();
        }

        private void frmPurchaseDetail_Load(object sender, EventArgs e)
        {
            BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
            //DataSet ds = baseinfo.GetAllStock("tb_Stock");
            // DataSet ds = baseinfo.GetSaleList();
            DataSet ds = baseinfo.GetPurchaseDetailList("tb_purchase_detail", PurchaseCode);
            dataGridViewPurchaseDetailList.DataSource = ds.Tables[0].DefaultView;
            //dgvSelectStockList.DataSource = ds.Tables[0].DefaultView;

            dataGridViewPurchaseDetailList.Columns[0].HeaderText = "明细流水号";
            dataGridViewPurchaseDetailList.Columns[0].Width = 160;
            dataGridViewPurchaseDetailList.Columns[0].Visible = true;

            dataGridViewPurchaseDetailList.Columns[1].HeaderText = "采购订单号";
            dataGridViewPurchaseDetailList.Columns[1].Width = 160;
            dataGridViewPurchaseDetailList.Columns[1].Visible = true;

            dataGridViewPurchaseDetailList.Columns[2].HeaderText = "商品编号";
            dataGridViewPurchaseDetailList.Columns[2].Width = 160;
            dataGridViewPurchaseDetailList.Columns[2].Visible = true;

            dataGridViewPurchaseDetailList.Columns[3].HeaderText = "商品名字";
            dataGridViewPurchaseDetailList.Columns[3].Width = 160;
            dataGridViewPurchaseDetailList.Columns[3].Visible = true;

            dataGridViewPurchaseDetailList.Columns[4].HeaderText = "商品单位";
            dataGridViewPurchaseDetailList.Columns[4].Visible = true;
            dataGridViewPurchaseDetailList.Columns[4].Width = 160;

            dataGridViewPurchaseDetailList.Columns[5].HeaderText = "商品单价";
            dataGridViewPurchaseDetailList.Columns[5].Visible = true;
            dataGridViewPurchaseDetailList.Columns[5].Width = 160;

            dataGridViewPurchaseDetailList.Columns[6].HeaderText = "需求数量";
            dataGridViewPurchaseDetailList.Columns[6].Visible = true;
            dataGridViewPurchaseDetailList.Columns[6].Width = 160;

            dataGridViewPurchaseDetailList.Columns[7].HeaderText = "明细小计";
            dataGridViewPurchaseDetailList.Columns[7].Visible = true;
            dataGridViewPurchaseDetailList.Columns[7].Width = 160;

            this.Text = "采购订单 " + PurchaseCode + " 明细";
        }
        /// <summary>
        /// 当前采购单编号
        /// </summary>   
        public string PurchaseCode
        {
            set { purchase_code = value; }
            get { return purchase_code; }
        }

        //采购订单号
        private string purchase_code = "";

        private void btModify_Click(object sender, EventArgs e)
        {

        }

        private void btBack_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
