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
    public partial class frmGoodsEntryDetail : Form
    {
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
        BaseClass.cPurchaseBill purchaseBillinfo = new EMS.BaseClass.cPurchaseBill();
        protected DataSet dsGoods = null;
        BaseClass.cStockBill entry_billinfo = new EMS.BaseClass.cStockBill();
        BaseClass.cStockInfo stockinfo = new BaseClass.cStockInfo();

        private string purchase_code = "";
        private string staff_number = "";
        private string supplier_number = "";
        private DateTime recevive_date = DateTime.Now;
        private float total_pay = 0;

        /// <summary>
        /// 供货单号
        /// </summary>
        public string PurchaseCode
        {
            set { purchase_code = value; }
            get { return purchase_code; }
        }

        /// <summary>
        /// 员工编号
        /// </summary>
        public string StaffNumber
        {
            set { staff_number = value; }
            get { return staff_number; }
        }

        /// <summary>
        /// 供应商编号
        /// </summary>
        public string SupplierNumber
        {
            set { supplier_number = value; }
            get { return supplier_number; }
        }
        /// <summary>
        /// 要货日期
        /// </summary>
        public DateTime DateReCeive
        {
            set { recevive_date = value; }
            get { return recevive_date; }
        }

        /// <summary>
        /// 订单总金额
        /// </summary>
        public float TotalPay
        {
            set { total_pay = value; }
            get { return total_pay; }
        }


        public frmGoodsEntryDetail()
        {
            InitializeComponent();
        }

        private void frmGoodsEntryDetail_Load(object sender, EventArgs e)
        {

            ArrayList listEmployee = new ArrayList();
            DataSet dsEmployee = null;
            DataSet dsSupplier = null;
            DataSet dsPurchaseDetail = null;

            int dgv_row = 0;

            try
            {
                dsGoods = baseinfo.GetAllBill("tb_goods");
                //dsEmployee = baseinfo.GetTableDateByFiled("tb_employee", "number", StaffNumber, "name");
                dsSupplier = baseinfo.GetTableDateByFiled("tb_supplier", "number", SupplierNumber, "name");
                //没有供货单，直接通过采购单进行入库，根据单号，获取明细
                dsPurchaseDetail = baseinfo.GetTableDateByFiled("tb_purchase_details", "purchase_number", PurchaseCode);
                dgvEntryDetailWait.DataSource = dsPurchaseDetail.Tables[0].DefaultView;
                //datagrivdview 1 显示采购单明细
                dgvEntryDetailWait.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvEntryDetailWait.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                ////datagrivdview 2 显示入库单明细
                //dgvEntryDetailList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //dgvEntryDetailList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                dgv_row = dgvEntryDetailWait.RowCount;

                dgvEntryDetailWait.Columns[0].HeaderText = "明细编号";
                dgvEntryDetailWait.Columns[0].Visible = true;

                dgvEntryDetailWait.Columns[1].HeaderText = "采购单号";
                dgvEntryDetailWait.Columns[1].Visible = true;

                dgvEntryDetailWait.Columns[2].HeaderText = "商品名字";
                dgvEntryDetailWait.Columns[2].Visible = true;

                dgvEntryDetailWait.Columns[3].HeaderText = "商品数量";
                dgvEntryDetailWait.Columns[3].Visible = true;

                dgvEntryDetailWait.Columns[4].HeaderText = "商品单价";
                dgvEntryDetailWait.Columns[4].Visible = true;

                dgvEntryDetailWait.Columns[5].HeaderText = "商品单位";
                dgvEntryDetailWait.Columns[5].Visible = true;


                //2. 访问员工表，获取员工信息（采购员）
                dsEmployee = baseinfo.GetAllBill("tb_employee");
                DataTable dtEmployee = dsEmployee.Tables[0];
                foreach (DataRow dr in dtEmployee.Rows)
                {
                    listEmployee.Add(dr[0].ToString().Trim());
                }
                cbEmployeeNumber.DataSource = listEmployee;

                //填充表头
                txBillNumber.Text = PurchaseCode;
                //txEmployeeName.Text = dsEmployee.Tables[0].Rows[0]["name"].ToString();
                txSupplierName.Text = dsSupplier.Tables[0].Rows[0]["name"].ToString();
                txSupplierNumber.Text = SupplierNumber;
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

        private void dgvEntryDetailWait_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

            }
            catch (System.Exception ex)
            { 
            
            }
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            try
            {
                //0.访问入库单表，构建入库单号
                DataSet dsEntry = baseinfo.GetAllBill("tb_entry_stock");
                int tb_entry_row = dsEntry.Tables[0].Rows.Count;
                
                // 1.构建入库单表
                //入库单号
                entry_billinfo.EnOutCode = Convert.ToString(700000001 + tb_entry_row);
                //采购单号
                entry_billinfo.PurchaseCode = PurchaseCode;
                //仓管员号
                entry_billinfo.StaffCode = cbEmployeeNumber.Text;
                //入库日期
                entry_billinfo.BillDate = dateEntry.Value;

                // 2.构建入库单明细表
                // 2.2 
                DataSet dsEntryDetail = baseinfo.GetAllBill("tb_entry_stock_details");
                int rowCount = dsEntryDetail.Tables[0].Rows.Count;
                //先把库存表读取出来
                DataSet dsStock = baseinfo.GetAllBill("tb_stock");

                DataSet dsPurchaseDetail = baseinfo.GetTableDateByFiled("tb_purchase_details", "purchase_number", PurchaseCode);

                for (int i = 0; i < dgvEntryDetailWait.RowCount - 1; i++)
                {
                    // 2.2.0 自动增长明细编号
                    // 2.2.2 明细编号
                    entry_billinfo.EnOutDetailCode = Convert.ToString(700000001 + rowCount + i);
                    
                    // 2.2.3 入库单号
                    entry_billinfo.EnOutCode = Convert.ToString(700000001 + tb_entry_row);
                    // 2.2.4 商品编号
                    entry_billinfo.GoodCode = dsPurchaseDetail.Tables[0].Rows[i]["goods_number"].ToString();
                    // 2.2.5 商品数量
                    entry_billinfo.Qty = Convert.ToInt32(dgvEntryDetailWait[3,i].Value);
                    
                    // 2.2.8 保存明细表
                    baseinfo.AddTableEntryStockDetail(entry_billinfo, "tb_entry_stock_details");
                    
                    //2.2.9 更新库存
                    stockinfo.TradeCode = entry_billinfo.GoodCode;
                    stockinfo.Qty = entry_billinfo.Qty;
                    baseinfo.UpdateStockQty(stockinfo);
                    // 2.2.9 增加明细表 row 数，在缓存中
                    rowCount += i;
                }
                // 3.保存采购订单
                baseinfo.AddTableEntryStock(entry_billinfo, "tb_entry_stock");
                MessageBox.Show("入库单－－过账成功！", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //4.更新采购单状态
                purchaseBillinfo.BillCode = PurchaseCode;
                purchaseBillinfo.Status = "已入库";
                baseinfo.UpdatePurchaseStatu(purchaseBillinfo);
                MessageBox.Show("采购单状态更新成功！", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("数据错误，入库失败!", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvEntryDetailWait_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e == null || e.Value == null || !(sender is DataGridView))
            {
                return;
            }
            try
            {
                int goods_row = 0;
                int dgv_row = dgvEntryDetailWait.RowCount;
                //DataSet dsGoods = baseinfo.GetAllBill("tb_goods");
                //获取商品名字，使用商品名字替换 dgvDetailList 中的商品编号
                if (e.ColumnIndex == 3)
                {
                    foreach (DataRow dr in dsGoods.Tables[0].Rows)
                    {
                        if (e.Value.ToString() == dsGoods.Tables[0].Rows[goods_row]["number"].ToString())
                        {

                            e.Value = dsGoods.Tables[0].Rows[goods_row]["name"].ToString();
                            continue;
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
