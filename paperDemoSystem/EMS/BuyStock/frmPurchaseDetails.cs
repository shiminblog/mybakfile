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
    public partial class frmPurchaseDetails : Form
    {
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
        BaseClass.cPurchaseBill purchaseBillinfo = new EMS.BaseClass.cPurchaseBill();
        protected DataSet dsGoods = null;

        private string purchase_code = "";
        private string staff_number = "";
        private string supplier_number = "";
        private DateTime recevive_date = DateTime.Now;
        private float total_pay = 0;

        /// <summary>
        /// 采购单号
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
            get { return recevive_date;}
        }

        /// <summary>
        /// 订单总金额
        /// </summary>
        public float TotalPay
        {
            set { total_pay = value; }
            get { return total_pay;}
        }

        public frmPurchaseDetails()
        {
            InitializeComponent();
        }

        private void frmPurchaseDetails_Load(object sender, EventArgs e)
        {
            DataSet dsPurchaseDetail = null;
            DataSet dsStaff = null;
            DataSet dsSupplier = null;
            
            int dgv_row = 0;
  
            try
            {
                dsGoods = baseinfo.GetAllBill("tb_goods");
                dsStaff = baseinfo.GetTableDateByFiled("tb_employee", "number", StaffNumber,"name");
                dsSupplier = baseinfo.GetTableDateByFiled("tb_supplier", "number", SupplierNumber, "name");
                dsPurchaseDetail = baseinfo.GetTableDateByFiled("tb_purchase_details", "purchase_number", PurchaseCode);
                dgvDetailList.DataSource = dsPurchaseDetail.Tables[0].DefaultView;
                dgvDetailList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvDetailList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                dgv_row = dgvDetailList.RowCount;

                //dgvDetailList.Columns[0].HeaderText = "流水号";
                //dgvDetailList.Columns[0].Visible = true;

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
                txBillNumber.Text = PurchaseCode;
                dateRecive.Value = DateReCeive;
                txTotalPay.Text = TotalPay.ToString();
                txStaffName.Text = dsStaff.Tables[0].Rows[0]["name"].ToString();
                txSupplierName.Text = dsSupplier.Tables[0].Rows[0]["name"].ToString();               
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

        private void btPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
