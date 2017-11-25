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
    public partial class frmEntryCheck : Form
    {
        BaseClass.cBillInfo salesinfor = new EMS.BaseClass.cBillInfo();
        BaseClass.cStockInfo stockinfo = new EMS.BaseClass.cStockInfo();
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();

        public frmEntryCheck()
        {
            InitializeComponent();
        }

        private void frmEntryCheck_Load(object sender, EventArgs e)
        {
            DataSet dsSales = null;

            try
            {
                dsSales = baseinfo.GetAllBill("tb_entry_stock");

                dgvList.DataSource = dsSales.Tables[0].DefaultView;
                dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                dgvList.Columns[0].HeaderText = "入库编号";
                dgvList.Columns[0].Visible = true;

                dgvList.Columns[1].HeaderText = "采购单号";
                dgvList.Columns[1].Visible = true;

                dgvList.Columns[2].HeaderText = "操作员号";
                dgvList.Columns[2].Visible = true;

                dgvList.Columns[3].HeaderText = "入库日期";
                dgvList.Columns[3].Visible = true;
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
