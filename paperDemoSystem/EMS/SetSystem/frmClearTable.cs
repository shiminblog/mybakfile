using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EMS.SetSystem
{
    public partial class frmClearTable : Form
    {
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
        public frmClearTable()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (chkCurrent.Checked) baseinfo.ClearTable("tb_currentaccount");
            if (chkWarehouse.Checked)
            {
                baseinfo.ClearTable("tb_warehouse_main");
                baseinfo.ClearTable("tb_warehouse_detailed");
            }
            if (chkRewarehouse.Checked)
            {
                baseinfo.ClearTable("tb_rewarehouse_main");
                baseinfo.ClearTable("tb_rewarehouse_detailed");
            }
            if (chkSell.Checked)
            {
                baseinfo.ClearTable("tb_orders");
                baseinfo.ClearTable("tb_orders_detailed");
            }
            if (chkResell.Checked)
            {
                baseinfo.ClearTable("tb_resell_main");
                baseinfo.ClearTable("tb_resell_detailed");
            }
            if (chkUser.Checked) baseinfo.ClearTable("tb_power");
            if (chkUnit.Checked) baseinfo.ClearTable("tb_unit");
            if (chkStock.Checked) baseinfo.ClearTable("tb_stock");
            if (chkEmployee.Checked) baseinfo.ClearTable("tb_employee");
            if (chkUnits.Checked) baseinfo.ClearTable("tb_units");

            MessageBox.Show("磁盘清理成功！","成功提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}