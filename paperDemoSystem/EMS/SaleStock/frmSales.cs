using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace EMS.SaleStock
{
    public partial class frmSales : Form
    {
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
        //BaseClass.cPurchaseBill purchaseBillinfo = new EMS.BaseClass.cPurchaseBill();
        BaseClass.cBillInfo salesinfor = new EMS.BaseClass.cBillInfo();
        BaseClass.cStockInfo stockinfo = new EMS.BaseClass.cStockInfo();
        protected int detailRow = 0;
        protected int check_flag = 0;
        protected float pay_row = 0; //每种商品的单价
        protected int qty_row = 0;  //每条明细的商品数

        public frmSales()
        {
            InitializeComponent();
        }

        private void frmSales_Load(object sender, EventArgs e)
        {
            ArrayList listEmployee = new ArrayList();
            ArrayList listCustomer = new ArrayList();
            ArrayList listGoods = new ArrayList();
            DataSet dsSales = null;
            DataSet dsEmployee = null;
            DataSet dsCustomer = null;
            DataSet dsGoods = null;
            try
            {
                //1. 访问销售单表，获取销售单编号
                dsSales = baseinfo.GetAllBill("tb_sales");
                int i = dsSales.Tables[0].Rows.Count;
                txSalesNunber.Text = Convert.ToString(700000001 + i);
                //2. 访问员工表，获取员工信息（销售员/接单员）
                dsEmployee = baseinfo.GetAllBill("tb_employee");
                DataTable dtEmployee = dsEmployee.Tables[0];
                foreach (DataRow dr in dtEmployee.Rows)
                {
                    listEmployee.Add(dr[0].ToString().Trim());
                }
                cbEmployeeNumber.DataSource = listEmployee;

                //3. 访问客户表表，获取客户信息信息
                dsCustomer = baseinfo.GetAllBill("tb_customer");
                DataTable dtSupplier = dsCustomer.Tables[0];
                foreach (DataRow dr in dtSupplier.Rows)
                {
                    listCustomer.Add(dr[0].ToString().Trim());
                }
                cbCustomerNumber.DataSource = listCustomer;

                //4. 访问商品数据表，将商品编号存储到下拉列表中
                dsGoods = baseinfo.GetAllBill("tb_goods");
                DataTable dtGoods = dsGoods.Tables[0];
                foreach (DataRow dr in dtGoods.Rows)
                {
                    listGoods.Add(dr[0].ToString().Trim());
                }
                cbGoodsNumber.DataSource = listGoods;   
                //此处不访问库存表
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("页面初始化异常！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        private void cbStaffNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsEmployee = null;
            try
            {
                dsEmployee = baseinfo.GetTableDateByFiled("tb_employee", "number", cbEmployeeNumber.Text, "name");
                txEmpolyeeName.Text = dsEmployee.Tables[0].Rows[0]["name"].ToString();
            }
            catch (System.Exception ex)
            {

            }
        }

        private void cbGoodsNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsGoods = null;
            DataSet dsGoodsStock = null;
            try
            {
                dsGoods = baseinfo.GetTableDateByFiled("tb_goods", "number", cbGoodsNumber.Text);
                dgvSalesDetailList[0, detailRow].Value = dsGoods.Tables[0].Rows[0]["number"].ToString();
                dgvSalesDetailList[1, detailRow].Value = dsGoods.Tables[0].Rows[0]["type"].ToString();
                dgvSalesDetailList[2, detailRow].Value = dsGoods.Tables[0].Rows[0]["name"].ToString();
                dgvSalesDetailList[3, detailRow].Value = dsGoods.Tables[0].Rows[0]["unit"].ToString();
                dsGoodsStock = baseinfo.GetTableDateByFiled("tb_stock", "goods_number", cbGoodsNumber.Text);
                dgvSalesDetailList[7, detailRow].Value = dsGoodsStock.Tables[0].Rows[0]["stock"].ToString();
                if (Convert.ToInt32(dsGoodsStock.Tables[0].Rows[0]["stock"].ToString()) < Convert.ToInt32(dsGoodsStock.Tables[0].Rows[0]["min_stock"].ToString()))
                {
                    MessageBox.Show("该款商品缺货，请补货", "库存不足", MessageBoxButtons.OK);
                }
            }
            catch (System.Exception ex)
            {
                //return;
            }
        }

        private void cbCustomerNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsCustomer = null;
            try
            {
                dsCustomer = baseinfo.GetTableDateByFiled("tb_customer", "number", cbCustomerNumber.Text, "name");
                txCustomerName.Text = dsCustomer.Tables[0].Rows[0]["name"].ToString();
            }
            catch (System.Exception ex)
            {

            }
        }

        private void dgvSalesDetailList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            detailRow = e.RowIndex;
        }

        private void dgvSalesDetailList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            detailRow = e.RowIndex;
        }

        private void dgvSalesDetailList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //初始化时不检查
            float totalPay = 0;

            //只检查数量和单价输入是否合法
            if (e.ColumnIndex < 4 || e.RowIndex < 0 || e.ColumnIndex == 6)
            {
                return;
            }

            try
            {
                if (e.ColumnIndex == 4)
                {
                    qty_row = Convert.ToInt32(dgvSalesDetailList[e.ColumnIndex, e.RowIndex].Value);
                    if (qty_row <= 0)
                    {
                        MessageBox.Show("数量必须大于0", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (qty_row > Convert.ToInt32(dgvSalesDetailList[7, e.RowIndex].Value))
                    {
                        MessageBox.Show("请注意，销售数量大于库存量", "库存不足", MessageBoxButtons.OK);
                    }
                }

                if (e.ColumnIndex == 5)
                {
                    pay_row = Convert.ToSingle(dgvSalesDetailList[e.ColumnIndex, e.RowIndex].Value);
                    if (pay_row <= 0)
                    {
                        MessageBox.Show("单价必须大于0", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                //金额小计
                if (pay_row > 0 && Convert.ToSingle(qty_row) > 0)
                {
                    totalPay = pay_row * Convert.ToSingle(qty_row);
                    dgvSalesDetailList[6, e.RowIndex].Value = Convert.ToString(totalPay);
                    totalPay = 0;
                    for (int i = 0; i < dgvSalesDetailList.RowCount - 1; i++)
                    {
                        totalPay +=  Convert.ToSingle(dgvSalesDetailList[6, i].Value.ToString());
                    }

                    //订单总金额
                    txTotalPay.Text = Convert.ToString(totalPay);
                    pay_row = 0;
                    qty_row = 0;
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("数据输入非法：数量必须为整数，单价必须为数值", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 1.构建销售订单表
                // 1.1 销售订单号
                salesinfor.BillCode = txSalesNunber.Text;//txPurchaseNumber.Text;
                // 1.2 客户编号编号
                salesinfor.CustomerCode = cbCustomerNumber.Text;//cbSupplierNumber.Text;
                // 1.3 接单员工号
                salesinfor.SalesPersonCode = cbEmployeeNumber.Text;
                // 1.4 下单日期
                salesinfor.BillDate = dateOrderTime.Value;

                // 1.6 订单金额
                salesinfor.OrderTotalPayment = Convert.ToSingle(txTotalPay.Text);
                // 1.7订单状态
                salesinfor.Status = "待出库";

                // 2.构建采购订单明细表
                // 2.1 检查每条明细数据是否合格
                for (int i = 0; i < dgvSalesDetailList.RowCount - 1; i++)
                {
                    if (Convert.ToInt32(dgvSalesDetailList[4, i].Value) <= 0)
                    {
                        MessageBox.Show("第 " + Convert.ToString(i) + " 条明细数量错误！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (Convert.ToSingle(dgvSalesDetailList[5, i].Value) <= 0)
                    {
                        MessageBox.Show("第 " + Convert.ToString(i) + " 条明细单价错误！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                // 2.2 
                DataSet dsSalesDetail = baseinfo.GetAllBill("tb_sales_details");
                int rowCount = dsSalesDetail.Tables[0].Rows.Count;
                for (int i = 0; i < dgvSalesDetailList.RowCount - 1; i++)
                {
                    // 2.2.0 自动增长明细编号
                    // 2.2.2 明细编号
                    salesinfor.orderDetaildCode = Convert.ToString(700000001 + rowCount + i);
                    // 2.2.3 采购订单号
                    salesinfor.BillCode = txSalesNunber.Text;//txPurchaseNumber.Text;
                    // 2.2.4 商品编号
                    salesinfor.goodsCode = cbGoodsNumber.Text;
                    // 2.2.5 商品数量
                    salesinfor.Qty = Convert.ToSingle(dgvSalesDetailList[4, i].Value);
                    // 2.2.6 商品单价
                    salesinfor.goodsPrice = Convert.ToSingle(dgvSalesDetailList[5, i].Value);
                    // 2.2.7 商品单位
                    salesinfor.goodsUnit = Convert.ToString(dgvSalesDetailList[3, i].Value);
                    // 2.2.8 保存明细表
                    baseinfo.AddTableSalesDetail(salesinfor, "tb_sales_details");
                    // 2.2.9 增加明细表 row 数，在缓存中
                    rowCount += i;
                }
                // 3.保存采购订单
                baseinfo.AddTableSales(salesinfor, "tb_sales");
                MessageBox.Show("销售单－－过账成功！", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("非法数据!", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Close();
        }

        private void btCacel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
