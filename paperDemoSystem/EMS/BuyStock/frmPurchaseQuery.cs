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
    public partial class frmPurchaseQuery : Form
    {
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
        BaseClass.cPurchaseBill purchaseBillinfo = new EMS.BaseClass.cPurchaseBill();

        public frmPurchaseQuery()
        {
            InitializeComponent();
        }

        private void frmPurchaseQuery_Load(object sender, EventArgs e)
        {
            //1 访问采购数据表，获取所有的采购订单，并显示在 datagridview  /  tb_purchase
            DataSet dsPurchase = null;
            
            try
            {
                dsPurchase = baseinfo.GetAllBill("tb_purchase");
                dgvPurchaseList.DataSource = dsPurchase.Tables[0].DefaultView;
                dgvPurchaseList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvPurchaseList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                
                dgvPurchaseList.Columns[0].HeaderText = "采购单号";
                dgvPurchaseList.Columns[0].Visible = true;

                dgvPurchaseList.Columns[1].HeaderText = "供应商号";
                dgvPurchaseList.Columns[1].Visible = true;

                dgvPurchaseList.Columns[2].HeaderText = "采购员号";
                dgvPurchaseList.Columns[2].Visible = true;

                dgvPurchaseList.Columns[3].HeaderText = "下单日期";
                dgvPurchaseList.Columns[3].Visible = true;

                dgvPurchaseList.Columns[4].HeaderText = "要货日期";
                dgvPurchaseList.Columns[4].Visible = true;

                dgvPurchaseList.Columns[5].HeaderText = "订单总额";
                dgvPurchaseList.Columns[5].Visible = true;

                dgvPurchaseList.Columns[6].HeaderText = "订单状态";
                dgvPurchaseList.Columns[6].Visible = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("页面初始化异常！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void dgvPurchaseList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                EMS.BuyStock.frmPurchaseDetails l_detail = new EMS.BuyStock.frmPurchaseDetails();
                l_detail.Owner = this;
                //将供应商编号、员工编号、要货日期、订单定额传入明细界面，以便打印出来
                l_detail.PurchaseCode = dgvPurchaseList[0, e.RowIndex].Value.ToString();
                l_detail.SupplierNumber = dgvPurchaseList[1, e.RowIndex].Value.ToString();
                l_detail.StaffNumber = dgvPurchaseList[2, e.RowIndex].Value.ToString();
                l_detail.DateReCeive = Convert.ToDateTime(dgvPurchaseList[4, e.RowIndex].Value.ToString());
                l_detail.TotalPay = Convert.ToSingle(dgvPurchaseList[5, e.RowIndex].Value);
                l_detail.Show();
            }
            catch (System.Exception ex)
            {
                //this.Close();
            }

           // this.Close();
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
