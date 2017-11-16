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
    public partial class frmInStockDetailList : Form
    {
        private string purchase_code = "";
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
        BaseClass.cStockBill billinfo = new EMS.BaseClass.cStockBill();
        /// <summary>
        /// 待入库采购订单号
        /// </summary>
        public string WaitePurchaseCode
        {
            get { return purchase_code; }
            set { purchase_code = value; }
        }

        public frmInStockDetailList()
        {
            InitializeComponent();
        }

        private void btOk_Click(object sender, EventArgs e)
        {

            //往来单位和经手人不能为空！

            if (txClerkCode.Text == string.Empty || txClerkName.Text == string.Empty)
            {
                MessageBox.Show("操作员和工号不能为空！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //入库主表内容
            billinfo.BillDate = Convert.ToDateTime(dateTimePickerInStock.Value);
            billinfo.StaffCode = txClerkCode.Text;
            billinfo.StaffName = txClerkName.Text;
            billinfo.EnOutCode = txInStockCode.Text; //txOutStockCode.Text;
            billinfo.OrdersCode = WaitePurchaseCode;////WaiteOrderCode;
            billinfo.GoodsCount = dataGridViewDetailList.RowCount;

            //入库明细表内容
            int i = 0;
            for (i = 0; i < dataGridViewDetailList.RowCount - 1; i++)
            {
                if (i < 10)
                    billinfo.EnOutDetailCode = billinfo.EnOutCode + "DE00" + Convert.ToString(i);
                else
                    billinfo.EnOutDetailCode = billinfo.EnOutCode + "DE0" + Convert.ToString(i);
                billinfo.EnOtCode = billinfo.EnOutCode;
                billinfo.GoodCode = dataGridViewDetailList[2, i].Value.ToString();
                billinfo.GoodsName = dataGridViewDetailList[3, i].Value.ToString();
                billinfo.GoodsUint = dataGridViewDetailList[4, i].Value.ToString();
                billinfo.Qty = Convert.ToInt32(dataGridViewDetailList[5, i].Value.ToString());
                billinfo.GoodsPrice = Convert.ToSingle(dataGridViewDetailList[6, i].Value.ToString());
                billinfo.GoodsTotalPrice = Convert.ToSingle(billinfo.Qty) * billinfo.GoodsPrice;
                baseinfo.AddTableOutStockDetail(billinfo, "tb_outStock_detail");
            }

            baseinfo.AddTableOutStock(billinfo, "tb_outStock");
            baseinfo.UpdateTableStatu("tb_orders", "已出库");
            MessageBox.Show("入库单－－过账成功！", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //this.Owner.Show();
            this.Close();
        }

        private void btCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInStockDetailList_Load(object sender, EventArgs e)
        {
            DataSet ds = baseinfo.GetTableDateByFiled("tb_purchase_detail", "purchase_code", WaitePurchaseCode);
            dataGridViewDetailList.DataSource = ds.Tables[0].DefaultView;
            dataGridViewDetailList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewDetailList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridViewDetailList.Columns[0].HeaderText = "流水号";
            dataGridViewDetailList.Columns[0].Visible = true;

            dataGridViewDetailList.Columns[1].HeaderText = "采购订单号";
            dataGridViewDetailList.Columns[1].Visible = true;

            dataGridViewDetailList.Columns[2].HeaderText = "商品编号";
            dataGridViewDetailList.Columns[2].Visible = true;

            dataGridViewDetailList.Columns[3].HeaderText = "商品名字";
            dataGridViewDetailList.Columns[3].Visible = true;

            dataGridViewDetailList.Columns[4].HeaderText = "商品单位";
            dataGridViewDetailList.Columns[4].Visible = true;


            dataGridViewDetailList.Columns[5].HeaderText = "商品单价";
            dataGridViewDetailList.Columns[5].Visible = true;

            dataGridViewDetailList.Columns[6].HeaderText = "需求数量";
            dataGridViewDetailList.Columns[6].Visible = true;
            
            dataGridViewDetailList.Columns[7].HeaderText = "明细金额";
            dataGridViewDetailList.Columns[7].Visible = true;

            DataSet ds1 = baseinfo.GetTableAllDataByName("tb_entryStock");
            int i = ds1.Tables[0].Rows.Count;
            if (i < 10)
                txInStockCode.Text = DateTime.Now.ToString("yyyyMMdd") + "OUT00" + Convert.ToString(i);
            else
                txInStockCode.Text = DateTime.Now.ToString("yyyyMMdd") + "OUT0" + Convert.ToString(i);
        }

        private void dateTimePickerInStock_ValueChanged(object sender, EventArgs e)
        {
            /*
            try
            {
                txtBalance.Text = Convert.ToString(Convert.ToSingle(txtFullPayment.Text) - Convert.ToSingle(txtpayment.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("录入非法字符！！！" + ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpayment.Focus();
            }*/
            //try
            //{
            //    float tqty = 0;
            //    float tsum = 0;
            //    for (int i = 0; i <= dgvStockList.RowCount; i++)
            //    {
            //        tsum = tsum + Convert.ToSingle(dgvStockList[5, i].Value.ToString());
            //        tqty = tqty + Convert.ToSingle(dgvStockList[3, i].Value.ToString());
            //        txtFullPayment.Text = tsum.ToString();
            //        txtStockQty.Text = tqty.ToString();
            //    }

            //}
            //catch { }
        }

        private void dataGridViewDetailList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
