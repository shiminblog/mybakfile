using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace EMS.Stock
{
    public partial class frmGoodsOut : Form
    {
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
        BaseClass.cPurchaseBill purchaseBillinfo = new EMS.BaseClass.cPurchaseBill();
        protected DataSet dsGoods = null;
        protected DataSet dsStock = null;
        BaseClass.cStockBill out_billinfo = new EMS.BaseClass.cStockBill();
        BaseClass.cStockInfo stockinfo = new BaseClass.cStockInfo();
        BaseClass.cBillInfo saleinfo = new EMS.BaseClass.cBillInfo();

        private string sales_code = "";
        private string employee_number = "";
        private string customer_number = "";
        private DateTime outstock_date = DateTime.Now;
        private float total_pay = 0;

        protected int detailRow = 0;
        protected int check_flag = 0;
        protected float pay_row = 0; //每种商品的单价
        protected int qty_row = 0;  //每条明细的商品数
        protected string goods_number = "";

        /// <summary>
        /// 销售单号
        /// </summary>
        public string SalesCode
        {
            set { sales_code = value; }
            get { return sales_code; }
        }

        /// <summary>
        /// 员工编号
        /// </summary>
        public string EmployeeNumber
        {
            set { employee_number = value; }
            get { return employee_number; }
        }

        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustomerNumber
        {
            set { customer_number = value; }
            get { return customer_number; }
        }
        /// <summary>
        /// 出库日期
        /// </summary>
        public DateTime DateOutStock
        {
            set { outstock_date = value; }
            get { return outstock_date; }
        }

        /// <summary>
        /// 订单总金额
        /// </summary>
        public float TotalPay
        {
            set { total_pay = value; }
            get { return total_pay; }
        }

        public frmGoodsOut()
        {
            InitializeComponent();
        }

        private void frmGoodsOut_Load(object sender, EventArgs e)
        {
            ArrayList listEmployee = new ArrayList();
            DataSet dsEmployee = null;
            DataSet dsCustomer = null;
            DataSet dsSalesDetails = null;

            int dgv_row = 0;
            try
            {
                dsGoods = baseinfo.GetAllBill("tb_goods");
                dsStock = baseinfo.GetAllBill("tb_stock");
                
                //根据客户编号获取客户信息
                dsCustomer = baseinfo.GetTableDateByFiled("tb_customer", "number", CustomerNumber, "name");
                //获取待出库销售单明细
                dsSalesDetails = baseinfo.GetTableDateByFiled("tb_sales_details", "sales_number", SalesCode);
                dgvList.DataSource = dsSalesDetails.Tables[0].DefaultView;
                
                //datagrivdview 1 显示销售单明细
                dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                dgv_row = dgvList.RowCount;

                dgvList.Columns[0].HeaderText = "明细编号";
                dgvList.Columns[0].Visible = true;
                dgvList.Columns[0].ReadOnly = true;

                dgvList.Columns[1].HeaderText = "销售单号";
                dgvList.Columns[1].Visible = true;
                dgvList.Columns[1].ReadOnly = true;

                dgvList.Columns[2].HeaderText = "商品名字";
                dgvList.Columns[2].Visible = true;
                dgvList.Columns[2].ReadOnly = true;

                dgvList.Columns[3].HeaderText = "商品数量";
                dgvList.Columns[3].Visible = true;

                dgvList.Columns[4].HeaderText = "商品单价";
                dgvList.Columns[4].Visible = true;
                dgvList.Columns[4].ReadOnly = true;

                dgvList.Columns[5].HeaderText = "商品单位";
                dgvList.Columns[5].Visible = true;
                dgvList.Columns[5].ReadOnly = true;

                int i = dgvList.Columns.Add("stock","当前库存");
                dgvList.Columns[i].Visible = true;
                dgvList.Columns[i].ReadOnly = true;

                //int j = dgvList.Columns.Count;

                //2. 访问员工表，获取员工信息（采购员）
                dsEmployee = baseinfo.GetAllBill("tb_employee");
                DataTable dtEmployee = dsEmployee.Tables[0];
                foreach (DataRow dr in dtEmployee.Rows)
                {
                    listEmployee.Add(dr[0].ToString().Trim());
                }
                cbEmployeeNumber.DataSource = listEmployee;

                //销售单号
                txQty.Text = "0";
                txCustomerName.Text = dsCustomer.Tables[0].Rows[0]["name"].ToString();
                txCustomerNumber.Text = CustomerNumber;

                //再次获取
                dsSalesDetails = baseinfo.GetTableDateByFiled("tb_sales_details", "sales_number", SalesCode);
                for (int row = 0; row < dsSalesDetails.Tables[0].Rows.Count; row++)
                {
                    int j = 0;
                    foreach (DataRow dr in dsStock.Tables[0].Rows)
                    {
                        string stockgoods_number = dsStock.Tables[0].Rows[j]["goods_number"].ToString();
                        string salegoods_number = dsSalesDetails.Tables[0].Rows[row]["goods_number"].ToString();
                        int stock_qty = Convert.ToInt32(dsStock.Tables[0].Rows[j]["stock"].ToString());
                        //根据商品号，找到库存
                        if (stockgoods_number == salegoods_number)
                        {
                            //dgvList = dsStock.Tables[0].Rows[i]["stock"].ToString();
                            dgvList[6, row].Value = dsStock.Tables[0].Rows[j]["stock"].ToString();
                            continue;
                        }
                        j++;
                    }                    
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("页面初始化异常！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void cbEmployeeNumber_SelectedValueChanged(object sender, EventArgs e)
        {
            DataSet dsEmployee = null;
            try
            {
                dsEmployee = baseinfo.GetTableDateByFiled("tb_employee", "number", cbEmployeeNumber.Text, "name");
                txEmployeeName.Text = dsEmployee.Tables[0].Rows[0]["name"].ToString();
            }
            catch (System.Exception ex)
            {

            }
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //初始化时不检查
            //float totalPay = 0;

            //只检查数量和单价输入是否合法
            if (e.ColumnIndex != 3 || e.RowIndex < 0)
            {
                return;
            }

            try
            {
                if (e.ColumnIndex == 3)
                {
                    // 0《  单元格输入数据 < 库存
                    qty_row = Convert.ToInt32(dgvList[3, e.RowIndex].Value);
                    if (qty_row <= 0)
                    {
                        MessageBox.Show("数量必须大于0", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (qty_row > Convert.ToInt32(dgvList[6, e.RowIndex].Value))
                    {
                        MessageBox.Show("非法操作: 出库数量大于库存数量!!!", "库存不足", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    if (Convert.ToInt32(dgvList[6, e.RowIndex].Value) - qty_row <= 2)
                    {
                        MessageBox.Show("剩余库存低于2件！！！", "存量预警", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("数据输入非法：数量必须为整数，单价必须为数值", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            try
            {
                //先检查数据是否合法，检查出库明细是否合法
                for (int i = 0; i < dgvList.RowCount - 1; i++)
                {
                    if (Convert.ToInt32(dgvList[3, i].Value) <= 0 || 
                        Convert.ToInt32(dgvList[3, i].Value) > Convert.ToInt32(dgvList[6, i].Value))
                    {
                        MessageBox.Show("第 " + Convert.ToString(i) + " 条明细数量错误，无法出库！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                //0.访问出库单表，构建出库单号
                DataSet dsOutStock = baseinfo.GetAllBill("tb_out_stock");
                int tb_out_row = dsOutStock.Tables[0].Rows.Count;

                // 1.构建出库单表
                //出库单号
                out_billinfo.EnOutCode = Convert.ToString(700000001 + tb_out_row);
                //销售单号
                out_billinfo.OrdersCode = SalesCode;
                //仓管员号
                out_billinfo.StaffCode = cbEmployeeNumber.Text;
                //出库日期
                out_billinfo.BillDate = dateTimeOutStock.Value;

                // 2.构建入库单明细表
                // 2.2 
                DataSet dsOutDetail = baseinfo.GetAllBill("tb_out_stock_details");
                int rowCount = dsOutDetail.Tables[0].Rows.Count;
                //先把库存表读取出来
                DataSet dsStock = null;//baseinfo.GetAllBill("tb_stock");

                //把销售明细读出来，以便获取商品编号
                DataSet dsSalesDetail = baseinfo.GetTableDateByFiled("tb_sales_details", "sales_number", SalesCode);

                for (int i = 0; i < dgvList.RowCount - 1; i++)
                {
                    // 2.2.0 自动增长明细编号
                    // 2.2.2 明细编号
                    out_billinfo.EnOutDetailCode = Convert.ToString(700000001 + rowCount + i);

                    // 2.2.3 入库单号
                    out_billinfo.EnOutCode = Convert.ToString(700000001 + tb_out_row);
                    // 2.2.4 商品编号
                    out_billinfo.GoodCode = dsSalesDetail.Tables[0].Rows[i]["goods_number"].ToString();
                    // 2.2.5 商品数量
                    out_billinfo.Qty = Convert.ToInt32(dgvList[3, i].Value);

                    // 2.2.8 保存出库明细表
                    baseinfo.AddTableOutStockDetail(out_billinfo, "tb_out_stock_details");

                    //2.2.9 更新库存（减库存）
                    stockinfo.TradeCode = out_billinfo.GoodCode;
                    dsStock = baseinfo.GetTableDateByFiled("tb_stock", "goods_number", out_billinfo.GoodCode);
                    stockinfo.TradeCode = out_billinfo.GoodCode;
                    stockinfo.Qty = Convert.ToSingle(dsStock.Tables[0].Rows[0]["stock"].ToString()) - out_billinfo.Qty;
                    baseinfo.UpdateStockQty(stockinfo);
                    // 2.2.9 增加明细表 row 数，在缓存中
                    rowCount += i;
                }
                // 3.保存出库单
                baseinfo.AddTableOutStock(out_billinfo, "tb_out_stock");
                MessageBox.Show("出库单－－过账成功！", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //4.更新销售单状态
                saleinfo.BillCode = SalesCode;
                saleinfo.Status = "已出库";
                baseinfo.UpdateSalesStatu(saleinfo);
                MessageBox.Show("销售单状态更新成功！", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("数据错误，出库失败!", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (System.Exception ex)
            { 
            
            }
        }

        private void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e == null || e.Value == null || !(sender is DataGridView))
            {
                return;
            }
            try
            {
                int goods_row = 0;
                int dgv_row = dgvList.RowCount;
                //DataSet dsGoods = baseinfo.GetAllBill("tb_goods");
                //获取商品名字，使用商品名字替换 dgvDetailList 中的商品编号
                if (e.ColumnIndex == 2)
                {
                    foreach (DataRow dr in dsGoods.Tables[0].Rows)
                    {
                        if (e.Value.ToString() == dsGoods.Tables[0].Rows[goods_row]["number"].ToString())
                        {
                            goods_number = dsGoods.Tables[0].Rows[goods_row]["number"].ToString();
                            e.Value = dsGoods.Tables[0].Rows[goods_row]["name"].ToString();
                            break; ;
                        }
                        goods_row++;
                    }
                }               
            }
            catch (System.Exception ex)
            {

            }
        }
    }
}
