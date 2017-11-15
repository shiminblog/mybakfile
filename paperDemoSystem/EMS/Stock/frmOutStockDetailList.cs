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
    public partial class frmOutStockDetailList : Form
    {
        private string order_code = "";
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
        BaseClass.cStockBill billinfo = new EMS.BaseClass.cStockBill();
        /// <summary>
        /// 待出库销售订单号
        /// </summary>
        public string WaiteOrderCode
        {
            get { return order_code; }
            set { order_code = value; }
        }

        public frmOutStockDetailList()
        {
            InitializeComponent();
        }

        private void dateTimePickerOutStock_ValueChanged(object sender, EventArgs e)
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

        private void frmOutStockDetailList_Load(object sender, EventArgs e)
        {
            //BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
            DataSet ds = baseinfo.GetSaleDetailList("tb_orders_detailed", WaiteOrderCode);
            dataGridViewDetailList.DataSource = ds.Tables[0].DefaultView;
            dataGridViewDetailList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewDetailList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridViewDetailList.Columns[0].HeaderText = "流水号";
            dataGridViewDetailList.Columns[0].Visible = true;

            dataGridViewDetailList.Columns[1].HeaderText = "销售订单号";
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

            DataSet ds1 = baseinfo.GetTableAllDataByName("tb_outStock");
            int i = ds1.Tables[0].Rows.Count;
            if (i < 10)
                txOutStockCode.Text = DateTime.Now.ToString("yyyyMMdd") + "OUT00" + Convert.ToString(i);
            else
                txOutStockCode.Text = DateTime.Now.ToString("yyyyMMdd") + "OUT0" + Convert.ToString(i);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //往来单位和经手人不能为空！

            if (txClerkCode.Text == string.Empty || txClerkName.Text == string.Empty)
            {
                MessageBox.Show("操作员和工号不能为空！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //出库主表内容
            billinfo.BillDate = Convert.ToDateTime(dateTimePickerOutStock.Value);
            billinfo.StaffCode = txClerkCode.Text;
            billinfo.StaffName = txClerkName.Text;
            billinfo.OutCode = txOutStockCode.Text;
            billinfo.OrdersCode = WaiteOrderCode;
            billinfo.GoodsCount = dataGridViewDetailList.RowCount;

            //出库明细表内容
            int i = 0;
            for (i = 0; i < dataGridViewDetailList.RowCount - 1; i++)
            {
                //if (Convert.ToString(dataGridViewDetailList[0, i].Value) == string.Empty
                //    || Convert.ToString(dataGridViewDetailList[1, i].Value) == string.Empty
                //    || Convert.ToString(dataGridViewDetailList[2, i].Value) == string.Empty)
                //{
                //    MessageBox.Show("请核实列表中数据：‘名称’、‘数量’、‘单价’、‘单位’不能为空！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                if (i < 10)
                    billinfo.EnOutDetailCode = billinfo.OutCode + "DE00" + Convert.ToString(i);
                else
                    billinfo.EnOutDetailCode = billinfo.OutCode + "DE0" + Convert.ToString(i);
                billinfo.OtCode = billinfo.OutCode;
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
            MessageBox.Show("出库单－－过账成功！", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //this.Owner.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
