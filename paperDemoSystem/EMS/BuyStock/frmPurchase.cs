using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace EMS.BuyStock
{
    public partial class frmPurchase : Form
    {
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
        BaseClass.cPurchaseBill purchaseBillinfo = new EMS.BaseClass.cPurchaseBill();
        BaseClass.cStockInfo stockinfo = new EMS.BaseClass.cStockInfo();
        protected int detailRow = 0;
        protected int check_flag = 0;
        protected float pay_row = 0; //每种商品的单价
        protected int qty_row = 0;  //每条明细的商品数

        public frmPurchase()
        {
            InitializeComponent();
        }

        private void frmPurchase_Load(object sender, EventArgs e)
        {
            ArrayList listEmployee = new ArrayList();
            ArrayList listSupplier = new ArrayList();
            ArrayList listGoods = new ArrayList();
            DataSet dsPurchase = null;
            DataSet dsEmployee = null;
            DataSet dsSupplier = null;
            DataSet dsGoods = null;
            try 
            {
                //1. 访问采购单表，获取采购单编号
                dsPurchase = baseinfo.GetAllBill("tb_purchase");
                int i = dsPurchase.Tables[0].Rows.Count;
                txPurchaseNumber.Text = Convert.ToString(700000001 + i);
                //2. 访问员工表，获取员工信息（采购员）
                dsEmployee = baseinfo.GetAllBill("tb_employee");
                DataTable dtEmployee = dsEmployee.Tables[0];
                foreach (DataRow dr in dtEmployee.Rows)
                {
                    listEmployee.Add(dr[0].ToString().Trim());
                }
                cbEmployeeNumber.DataSource = listEmployee;

                //3. 访问供应商表，获取供应商信息
                dsSupplier = baseinfo.GetAllBill("tb_supplier");
                DataTable dtSupplier = dsSupplier.Tables[0];
                foreach (DataRow dr in dtSupplier.Rows)
                {
                    listSupplier.Add(dr[0].ToString().Trim());
                }
                cbSupplierNumber.DataSource = listSupplier;

                //4. 访问商品数据表，将商品编号存储到下拉列表中
                dsGoods = baseinfo.GetAllBill("tb_goods");
                DataTable dtGoods = dsGoods.Tables[0];
                foreach (DataRow dr in dtGoods.Rows)
                {
                    listGoods.Add(dr[0].ToString().Trim());
                }
                cbGoodsNumber.DataSource = listGoods;            
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("页面初始化异常！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 1.构建采购订单表
                // 1.1 采购订单号
                purchaseBillinfo.BillCode = txPurchaseNumber.Text;
                // 1.2 供应商编号
                purchaseBillinfo.SupplierCode = cbSupplierNumber.Text;
                // 1.3 采购员工号
                purchaseBillinfo.BuyerCode = cbEmployeeNumber.Text;
                // 1.4 下单日期
                purchaseBillinfo.BillDate = dateOrder.Value;
                // 1.5 要货日期
                purchaseBillinfo.DeadLine = dateReceive.Value;
                // 1.6 订单金额
                purchaseBillinfo.TotalPayment = Convert.ToSingle(txTotalPay.Text);
                // 1.7订单状态
                purchaseBillinfo.Status = "待入库";

                // 2.构建采购订单明细表
                // 2.1 检查每条明细数据是否合格
                for (int i = 0; i < dtPurchaseDetail.RowCount - 1; i++)
                {
                    if (Convert.ToInt32(dtPurchaseDetail[4, i].Value) <= 0)
                    {
                        MessageBox.Show("第 " + Convert.ToString(i) + " 条明细数量错误！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (Convert.ToSingle(dtPurchaseDetail[5, i].Value) <= 0)
                    {
                        MessageBox.Show("第 " + Convert.ToString(i) + " 条明细单价错误！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                // 2.2 
                DataSet dsPurchaseDetail = baseinfo.GetAllBill("tb_purchase_details");
                int rowCount = dsPurchaseDetail.Tables[0].Rows.Count;
                for (int i = 0; i < dtPurchaseDetail.RowCount - 1; i++)
                {
                    // 2.2.0 自动增长明细编号
                    // 2.2.1 明细流水号
                    purchaseBillinfo.SerialNumber = Convert.ToString(rowCount + i);
                    // 2.2.2 明细编号
                    purchaseBillinfo.PurchaseDetaildCode = Convert.ToString(700000001 + rowCount + i);
                    // 2.2.3 采购订单号
                    purchaseBillinfo.BillCode = txPurchaseNumber.Text;
                    // 2.2.4 商品编号
                    purchaseBillinfo.goodsCode = cbGoodsNumber.Text;
                    // 2.2.5 商品数量
                    purchaseBillinfo.Qty = Convert.ToSingle(dtPurchaseDetail[4, i].Value);
                    // 2.2.6 商品单价
                    purchaseBillinfo.goodsPrice = Convert.ToSingle(dtPurchaseDetail[5, i].Value);
                    // 2.2.7 商品单位
                    purchaseBillinfo.goodsUnit = Convert.ToString(dtPurchaseDetail[3, i].Value);
                    // 2.2.8 保存明细表
                    baseinfo.AddTablePurchaseDetail(purchaseBillinfo, "tb_purchase_details");
                    
                    // 2.2.9 增加明细表 row 数，在缓存中
                    rowCount += i;
                }
                // 3.保存采购订单
                baseinfo.AddTablePurchase(purchaseBillinfo, "tb_purchase");
                MessageBox.Show("采购单－－过账成功！", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void dtPurchaseDetail_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtPurchaseDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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
                    qty_row = Convert.ToInt32(dtPurchaseDetail[e.ColumnIndex, e.RowIndex].Value);
                    if (qty_row <= 0)
                    {
                        MessageBox.Show("数量必须大于0", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (e.ColumnIndex == 5)
                {
                    pay_row = Convert.ToSingle(dtPurchaseDetail[e.ColumnIndex, e.RowIndex].Value);
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
                    dtPurchaseDetail[6, e.RowIndex].Value = Convert.ToString(totalPay);
                    totalPay = 0;
                    for (int i = 0; i < dtPurchaseDetail.RowCount-1; i++)
                    {
                        totalPay +=  Convert.ToSingle(dtPurchaseDetail[6, i].Value.ToString());
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

        private void dtPurchaseDetail_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            //detailRow = e.RowIndex;
        }

        private void cbEmployeeNumber_SelectedValueChanged(object sender, EventArgs e)
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

        private void cbSupplierNumber_SelectedValueChanged(object sender, EventArgs e)
        {
            DataSet dsPurchase = null;
            try
            {
                dsPurchase = baseinfo.GetTableDateByFiled("tb_supplier", "number", cbSupplierNumber.Text, "name");
                txSupplierName.Text = dsPurchase.Tables[0].Rows[0]["name"].ToString();
            }
            catch (System.Exception ex)
            { 
            
            }
        }

        private void dtPurchaseDetail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //TODO...
        }

        private void cbGoodsNumber_SelectedValueChanged(object sender, EventArgs e)
        {
            DataSet dsGoods = null;
            try 
            {
                dsGoods = baseinfo.GetTableDateByFiled("tb_goods", "number", cbGoodsNumber.Text);
                dtPurchaseDetail[0, detailRow].Value = dsGoods.Tables[0].Rows[0]["number"].ToString();
                dtPurchaseDetail[1, detailRow].Value = dsGoods.Tables[0].Rows[0]["type"].ToString();
                dtPurchaseDetail[2, detailRow].Value = dsGoods.Tables[0].Rows[0]["name"].ToString();
                dtPurchaseDetail[3, detailRow].Value = dsGoods.Tables[0].Rows[0]["unit"].ToString();
                //dtPurchaseDetail[4, detailRow].Value = Convert.ToString(1);
                //dtPurchaseDetail[5, detailRow].Value = Convert.ToString(0.1);            
            }
            catch (System.Exception ex) 
            {
                //return;
            }

        }

        private void dtPurchaseDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            detailRow = e.RowIndex;
        }

        private void dtPurchaseDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            detailRow = e.RowIndex;
        }

        private void cbGoodsNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TOTO..
        }

        private void cbEmployeeNumber_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
