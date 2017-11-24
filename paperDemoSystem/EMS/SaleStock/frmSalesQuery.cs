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
    public partial class frmSalesQuery : Form
    {
        BaseClass.cBillInfo salesinfor = new EMS.BaseClass.cBillInfo();
        BaseClass.cStockInfo stockinfo = new EMS.BaseClass.cStockInfo();
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();

        public frmSalesQuery()
        {
            InitializeComponent();
        }

        private void frmSalesQuery_Load(object sender, EventArgs e)
        {
            DataSet dsSales = null;

            try
            {
                dsSales = baseinfo.GetAllBill("tb_sales");
                dgvSalesList.DataSource = dsSales.Tables[0].DefaultView;
                dgvSalesList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvSalesList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                dgvSalesList.Columns[0].HeaderText = "销售单号";
                dgvSalesList.Columns[0].Visible = true;

                dgvSalesList.Columns[1].HeaderText = "客户编号";
                dgvSalesList.Columns[1].Visible = true;

                dgvSalesList.Columns[2].HeaderText = "接单员号";
                dgvSalesList.Columns[2].Visible = true;

                dgvSalesList.Columns[3].HeaderText = "下单日期";
                dgvSalesList.Columns[3].Visible = true;

                dgvSalesList.Columns[4].HeaderText = "订单总额";
                dgvSalesList.Columns[4].Visible = true;

                dgvSalesList.Columns[5].HeaderText = "订单状态";
                dgvSalesList.Columns[5].Visible = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("页面初始化异常！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();                
            }
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSalesList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                EMS.SaleStock.frmSalesDetails l_detail = new EMS.SaleStock.frmSalesDetails();
                l_detail.Owner = this;
                //将销售单号、员工编号、下单日期、订单定额传入明细界面，以便打印出来
                l_detail.SalesCode = dgvSalesList[0, e.RowIndex].Value.ToString();
                l_detail.CustomerNumber = dgvSalesList[1, e.RowIndex].Value.ToString();
                l_detail.StaffNumber = dgvSalesList[2, e.RowIndex].Value.ToString();
                l_detail.DateOrderTime = Convert.ToDateTime(dgvSalesList[3, e.RowIndex].Value.ToString());
                l_detail.TotalPay = Convert.ToSingle(dgvSalesList[4, e.RowIndex].Value);
                l_detail.Show();
            }
            catch (System.Exception ex)
            {
                //this.Close();
            }
        }
    }
}
