using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMS.SaleStock
{
    public partial class frmSalesDetails : Form
    {
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
        BaseClass.cBillInfo salesinfor = new EMS.BaseClass.cBillInfo();
        BaseClass.cStockInfo stockinfo = new EMS.BaseClass.cStockInfo();
        protected DataSet dsGoods = null;

        private string sales_code = "";
        private string staff_number = "";
        private string customer_number = "";
        private DateTime order_date = DateTime.Now;
        private float total_pay = 0;

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
        public string StaffNumber
        {
            set { staff_number = value; }
            get { return staff_number; }
        }

        /// <summary>
        ///客户编号
        /// </summary>
        public string CustomerNumber
        {
            set { customer_number = value; }
            get { return customer_number; }
        }
        /// <summary>
        /// 下单日期
        /// </summary>
        public DateTime DateOrderTime
        {
            set { order_date = value; }
            get { return order_date; }
        }

        /// <summary>
        /// 订单总金额
        /// </summary>
        public float TotalPay
        {
            set { total_pay = value; }
            get { return total_pay; }
        }
        public frmSalesDetails()
        {
            InitializeComponent();
        }

        private void frmSalesDetails_Load(object sender, EventArgs e)
        {
            DataSet dsSalesDetail = null;
            DataSet dsStaff = null;
            DataSet dsCustomer = null;

            int dgv_row = 0;

            try
            {
                dsGoods = baseinfo.GetAllBill("tb_goods");
                dsStaff = baseinfo.GetTableDateByFiled("tb_employee", "number", StaffNumber, "name");
                dsCustomer = baseinfo.GetTableDateByFiled("tb_customer", "number", CustomerNumber, "name");
                dsSalesDetail = baseinfo.GetTableDateByFiled("tb_sales_details", "sales_number", SalesCode);
                dgvDetailList.DataSource = dsSalesDetail.Tables[0].DefaultView;
                dgvDetailList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvDetailList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                dgv_row = dgvDetailList.RowCount;

                dgvDetailList.Columns[0].HeaderText = "明细编号";
                dgvDetailList.Columns[0].Visible = true;

                dgvDetailList.Columns[1].HeaderText = "采购单号";
                dgvDetailList.Columns[1].Visible = true;

                dgvDetailList.Columns[2].HeaderText = "商品名字";
                dgvDetailList.Columns[2].Visible = true;

                dgvDetailList.Columns[3].HeaderText = "商品数量";
                dgvDetailList.Columns[3].Visible = true;

                dgvDetailList.Columns[4].HeaderText = "商品单价";
                dgvDetailList.Columns[4].Visible = true;

                dgvDetailList.Columns[5].HeaderText = "商品单位";
                dgvDetailList.Columns[5].Visible = true;

                //填充表头
                txBillNumber.Text = SalesCode;
                dateOrderTime.Value = DateOrderTime;
                txTotalPay.Text = TotalPay.ToString();
                txStaffName.Text = dsStaff.Tables[0].Rows[0]["name"].ToString();
                txCustomerName.Text = dsCustomer.Tables[0].Rows[0]["name"].ToString();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("页面初始化异常！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            try
            {
                this.Owner.Show();
            }
            catch (System.Exception ex)
            {

            }
            finally
            {
                this.Close();
            }

        }

        private void dgvDetailList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e == null || e.Value == null || !(sender is DataGridView))
            {
                return;
            }
            try
            {
                int goods_row = 0;
                int dgv_row = dgvDetailList.RowCount;
                //DataSet dsGoods = baseinfo.GetAllBill("tb_goods");
                //获取商品名字，使用商品名字替换 dgvDetailList 中的商品编号
                if (e.ColumnIndex == 2)
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
