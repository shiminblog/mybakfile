using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EMS.SaleStock
{
    public partial class frmSellStock : Form
    {
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
        BaseClass.cBillInfo billinfo = new EMS.BaseClass.cBillInfo();
        //BaseClass.cCurrentAccount currentAccount = new EMS.BaseClass.cCurrentAccount();
        BaseClass.cStockInfo stockinfo = new EMS.BaseClass.cStockInfo();
        public frmSellStock()
        {
            InitializeComponent();
        }
        //该源码下载自win.51aspx.com(５１ａｓｐx．ｃｏｍ)

        private void frmSellStock_Load(object sender, EventArgs e)
        {
            //txtBillDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            int i = 0;

            DataSet ds = null;
            //string P_Str_newBillCode = "";
            //int P_Int_newBillCode = 0;

            ds = baseinfo.GetAllBill("tb_orders");
            i = 1000001 + ds.Tables[0].Rows.Count;
            //txtBillCode.Text = DateTime.Now.ToString("yyyyMMdd") + Convert.ToString(i);
            txtBillCode.Text = DateTime.Now.ToString("yyyyMMdd") + "XS" + Convert.ToString(i);
            //if (ds.Tables[0].Rows.Count == 0)
            //{
            //    txtBillCode.Text = DateTime.Now.ToString("yyyyMMdd") + "XS" + "1000001";
            //}
            //else
            //{
            //    P_Str_newBillCode = Convert.ToString(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["billcode"]);
            //    P_Int_newBillCode = Convert.ToInt32(P_Str_newBillCode.Substring(10, 7)) + 1;
            //    P_Str_newBillCode = DateTime.Now.ToString("yyyyMMdd") + "XS" + P_Int_newBillCode.ToString();
            //    txtBillCode.Text = P_Str_newBillCode;
            //}
            sales_name.Focus();
        }

        private void btnSelectHandle_Click(object sender, EventArgs e)
        {
#if false
            EMS.SelectDataDialog.frmSelectHandle selecthandle;
            selecthandle = new EMS.SelectDataDialog.frmSelectHandle();
            selecthandle.sellStock = this;          //将新创建的窗体对象设置为同一个窗体类的实例（对象）
            selecthandle.M_str_object = "SellStock";　　//用于识别　是那一个窗体调用的selecthandle窗口的
            selecthandle.ShowDialog();
#endif
        }

        private void btnSelectUnits_Click(object sender, EventArgs e)
        {
#if false
            EMS.SelectDataDialog.frmSelectUnits selectUnits;
            selectUnits = new EMS.SelectDataDialog.frmSelectUnits();
            selectUnits.sellStock = this;          //将新创建的窗体对象设置为同一个窗体类的实例（对象）
            selectUnits.M_str_object = "SellStock";　　//用于识别　是那一个窗体调用的selectUnits窗口的
            selectUnits.ShowDialog();
#endif
        }

        private void dgvStockList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //SelectDataDialog.frmSelectStock selectStock = new EMS.SelectDataDialog.frmSelectStock();
            //selectStock.sellStock = this;          //将新创建的窗体对象设置为同一个窗体类的实例（对象）
            //selectStock.M_int_CurrentRow = e.RowIndex;
            //selectStock.M_str_object = "SellStock";　　//用于识别　是那一个窗体调用的selectStock窗口的
            //selectStock.ShowDialog();
        }

        private void dgvStockList_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            //统计商品进货数量和金额
            try
            {
                float tqty = 0;
                float tsum = 0;
                for (int i = 0; i <= dgvStockList.RowCount; i++)
                {
                    tsum = tsum + Convert.ToSingle(dgvStockList[5, i].Value.ToString());
                    tqty = tqty + Convert.ToSingle(dgvStockList[3, i].Value.ToString());
                    txtFullPayment.Text = tsum.ToString();
                    txtStockQty.Text = tqty.ToString();
                }

            }
            catch { }
        }

        private void dgvStockList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)　　//计算－－统计商品金额
            {
                try
                {
                    float tsum = Convert.ToSingle(dgvStockList[3, e.RowIndex].Value.ToString()) * Convert.ToSingle(dgvStockList[4, e.RowIndex].Value.ToString());
                    dgvStockList[5, e.RowIndex].Value = tsum.ToString();
                }
                catch { }
            }
            if (e.ColumnIndex == 4)
            {
                try
                {
                    float tsum = Convert.ToSingle(dgvStockList[3, e.RowIndex].Value.ToString()) * Convert.ToSingle(dgvStockList[4, e.RowIndex].Value.ToString());
                    dgvStockList[5, e.RowIndex].Value = tsum.ToString();
                }
                catch { }
            }
        }

        private void txtpayment_TextChanged(object sender, EventArgs e)
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //往来单位和经手人不能为空！

            if (sales_name.Text == string.Empty || sales_code.Text == string.Empty)
            {
                MessageBox.Show("操作员和工号不能为空！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //客户信息不能为空
            if (customer_name.Text == string.Empty
                || customer_tel.Text == string.Empty
                || customer_address.Text == string.Empty
                || cusomter_code.Text == string.Empty)
            {
                MessageBox.Show("请完整填写客户信息","错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //列表中数据不能为空
#if false
            if (Convert.ToString(dgvStockList[3, 0].Value) == string.Empty 
                || Convert.ToString(dgvStockList[4, 0].Value) == string.Empty 
                || Convert.ToString(dgvStockList[5, 0].Value) == string.Empty)
            {
                MessageBox.Show("请核实列表中数据：‘名称’、‘数量’、‘单价’、‘单位’不能为空！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
#endif
            //应付金额不能为空
            /*
            if (txtFullPayment.Text.Trim() == "0")
            {
                MessageBox.Show("应付金额不能为‘０’！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
             */

            //向销售表（主表）录入商品单据信息
            //txtBillCode.Text = DateTime.Now.ToString("yyyyMMdd") + "XS" + "1000001";
#if true
            billinfo.SalesPersonName = sales_name.Text;
            billinfo.SalesPersonCode = sales_code.Text;
            billinfo.BillCode = txtBillCode.Text;
            billinfo.CustomerName = customer_name.Text;
            billinfo.CustomerTEL = customer_tel.Text;
            billinfo.CustomerAddress = customer_address.Text;
            billinfo.CustomerCode = cusomter_code.Text;
            billinfo.orderDate = dateTimePicker1.Value; // Convert.ToDateTime(order_date.Text);
            billinfo.BillDate = dateTimePicker2.Value;//
            billinfo.OrderTotalPayment = Convert.ToSingle(txtFullPayment.Text);
#else
            billinfo.SalesPersonName = "wangshi"; //sales_name.Text;
            billinfo.SalesPersonCode = "10000";// sales_code.Text;
            //billinfo.BillCode = "1010";// txtBillCode.Text;
            billinfo.BillCode = txtBillCode.Text;
            billinfo.CustomerName = "lidaxue";// customer_name.Text;
            billinfo.CustomerTEL = "021021";// customer_tel.Text;
            billinfo.CustomerAddress = "上海";// customer_address.Text;
            billinfo.CustomerCode = "301";// cusomter_code.Text;
            billinfo.orderDate = Convert.ToDateTime("2017-11-13");//Convert.ToDateTime(order_date.Text);
            billinfo.OrderTotalPayment = Convert.ToSingle("120");//Convert.ToSingle(txtFullPayment.Text);
#endif
            //baseinfo.AddTableMainSellhouse(billinfo, "tb_orders");

            //向销售（明细表）中录入商品单据信息
#if true
            int i = 0;
            for (i = 0; i < dgvStockList.RowCount - 1; i++)
            {
                if (Convert.ToString(dgvStockList[0, i].Value) == string.Empty
                    || Convert.ToString(dgvStockList[1, i].Value) == string.Empty
                    || Convert.ToString(dgvStockList[2, i].Value) == string.Empty)
                {
                    MessageBox.Show("请核实列表中数据：‘名称’、‘数量’、‘单价’、‘单位’不能为空！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //检查库存
                
                //stockinfo.TradeCode = dgvStockList[0, i].Value.ToString();
                if (Convert.ToSingle(dgvStockList[2, i].Value.ToString()) <= 0)
                {
                    MessageBox.Show("销售数量错误，请重新输入", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //检查单价
                if (Convert.ToSingle(dgvStockList[4, i].Value.ToString()) <= 0)
                {
                    MessageBox.Show("单价输入错误，请重新输入", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }                            
            }

            for (i = 0; i < dgvStockList.RowCount - 1; i++)
            {
                billinfo.BillCode = txtBillCode.Text;
               // billinfo.orderDetaildCode = Convert.ToString(Convert.ToSingle(txtBillCode.Text) * 10 + Convert.ToSingle(dgvStockList[0, i].Value.ToString()));
                billinfo.orderDetaildCode = txtBillCode.Text + "MX"+ Convert.ToString(i);
                billinfo.goodsCode = dgvStockList[0, i].Value.ToString();
                billinfo.goodsName = dgvStockList[1, i].Value.ToString();
                billinfo.Qty = Convert.ToSingle(dgvStockList[2, i].Value.ToString());
                billinfo.goodsUnit = dgvStockList[3, i].Value.ToString();
                billinfo.goodsPrice = Convert.ToSingle(dgvStockList[4, i].Value.ToString());
                

                //执行多行录入数据（添加到明细表中）
                baseinfo.AddTableDetailedWarehouse(billinfo, "tb_orders_detailed");
                //更改库存数量
                DataSet ds = null;
                stockinfo.TradeCode = billinfo.goodsCode;//dgvStockList[0, i].Value.ToString();
                ds = baseinfo.GetStockByTradeCode(stockinfo, "tb_Stock");
                stockinfo.Qty = Convert.ToSingle(ds.Tables[0].Rows[0]["qty"]);
                
                stockinfo.Qty = stockinfo.Qty - billinfo.Qty;
                int d = baseinfo.UpdateSaleStock_Qty(stockinfo);

            }
#endif
            baseinfo.AddTableMainSellhouse(billinfo, "tb_orders");
#if false
            //向往来单位明细表--录入数据--这样以来为分析
            currentAccount.BillCode = txtBillCode.Text;
            currentAccount.AddGathering = Convert.ToSingle(txtFullPayment.Text);
            currentAccount.FactAddFee = Convert.ToSingle(txtpayment.Text);
            currentAccount.Balance = Convert.ToSingle(txtBalance.Text);
            currentAccount.Units = sales_code.Text;
            //执行添加
            int ca = baseinfo.AddCurrentAccount(currentAccount);
#endif
            MessageBox.Show("销售单－－过账成功！", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }        

        private void btnEixt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvStockList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtHandle_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtBillDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvStockList_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}