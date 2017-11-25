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
    public partial class frmGoodsOutWaitList : Form
    {
        BaseClass.cBillInfo salesinfor = new EMS.BaseClass.cBillInfo();
        BaseClass.cStockInfo stockinfo = new EMS.BaseClass.cStockInfo();
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();

        public frmGoodsOutWaitList()
        {
            InitializeComponent();
        }

        private void frmGoodsOutWaitList_Load(object sender, EventArgs e)
        {
            DataSet dsSales = null;

            try
            {
                dsSales = baseinfo.GetTableDateByFiled("tb_sales", "statu", "待出库");
                dgvWaitList.DataSource = dsSales.Tables[0].DefaultView;
                dgvWaitList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvWaitList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                dgvWaitList.Columns[0].HeaderText = "销售单号";
                dgvWaitList.Columns[0].Visible = true;

                dgvWaitList.Columns[1].HeaderText = "客户编号";
                dgvWaitList.Columns[1].Visible = true;

                dgvWaitList.Columns[2].HeaderText = "接单员号";
                dgvWaitList.Columns[2].Visible = true;

                dgvWaitList.Columns[3].HeaderText = "下单日期";
                dgvWaitList.Columns[3].Visible = true;

                dgvWaitList.Columns[4].HeaderText = "订单总额";
                dgvWaitList.Columns[4].Visible = true;

                dgvWaitList.Columns[5].HeaderText = "订单状态";
                dgvWaitList.Columns[5].Visible = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("页面初始化异常！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void dgvWaitList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //EMS.SaleStock.frmSalesDetails l_detail = new EMS.SaleStock.frmSalesDetails();
                EMS.Stock.frmGoodsOut l_detail = new EMS.Stock.frmGoodsOut();
                l_detail.Owner = this;
                //将销售单号、员工编号、下单日期、订单定额传入明细界面，以便打印出来
                l_detail.SalesCode = dgvWaitList[0, e.RowIndex].Value.ToString();
                l_detail.CustomerNumber = dgvWaitList[1, e.RowIndex].Value.ToString();
                l_detail.Show();
            }
            catch (System.Exception ex)
            {
                //this.Close();
            }
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
