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
    public partial class frmStockCheck : Form
    {
        BaseClass.cBillInfo salesinfor = new EMS.BaseClass.cBillInfo();
        BaseClass.cStockInfo stockinfo = new EMS.BaseClass.cStockInfo();
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();

        public frmStockCheck()
        {
            InitializeComponent();
        }

        private void frmStockCheck_Load(object sender, EventArgs e)
        {
            DataSet dsStock = null;

            try
            {
                dsStock = baseinfo.GetAllBill("tb_stock");

                dgvList.DataSource = dsStock.Tables[0].DefaultView;
                dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                dgvList.Columns[0].HeaderText = "库存编号";
                dgvList.Columns[0].Visible = false;

                dgvList.Columns[1].HeaderText = "商品编号";
                dgvList.Columns[1].Visible = true;

                dgvList.Columns[2].HeaderText = "商品名字";
                dgvList.Columns[2].Visible = true;

                dgvList.Columns[3].HeaderText = "最小库存";
                dgvList.Columns[3].Visible = true;

                dgvList.Columns[4].HeaderText = "当前库存";
                dgvList.Columns[4].Visible = true;
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
    }
}
