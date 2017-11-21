using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace EMS.BuyStock
{
    public partial class frmPurchase : Form
    {
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
        BaseClass.cPurchaseBill billinfo = new EMS.BaseClass.cPurchaseBill();
        BaseClass.cStockInfo stockinfo = new EMS.BaseClass.cStockInfo();

        public frmPurchase()
        {
            InitializeComponent();
        }

        private void frmPurchase_Load(object sender, EventArgs e)
        {
            ArrayList listEmployee = new ArrayList();
            ArrayList listSupplier = new ArrayList();
            DataSet dsPurchase = null;
            DataSet dsEmployee = null;
            DataSet dsSupplier = null;

            //1. 访问采购单表，获取采购单编号
            dsPurchase = baseinfo.GetAllBill("tb_purchase");
            int i = dsPurchase.Tables[0].Rows.Count;
            txPurchaseNumber.Text = Convert.ToString(1006);
            //2. 访问员工表，获取员工信息（采购员）
            dsEmployee = baseinfo.GetAllBill("tb_employee");
            DataTable dtEmployee = dsEmployee.Tables[0];
            foreach (DataRow dr in dtEmployee.Rows)
            {
                listEmployee.Add(dr[0].ToString().Trim());
            }
            cbEmployeeNumber.DataSource = listEmployee;
            
            //3. 访问供应商表，获取供应商信息
            dsSupplier = baseinfo.GetAllBill("tb_supplier");
            DataTable dtSupplier = dsSupplier.Tables[0];
            foreach (DataRow dr in dtSupplier.Rows)
            {
                listSupplier.Add(dr[0].ToString().Trim());
            }
            cbSupplierNumber.DataSource = listSupplier;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btCacel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dtPurchaseDetail_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtPurchaseDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtPurchaseDetail_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {

        }

        private void cbEmployeeNumber_SelectedValueChanged(object sender, EventArgs e)
        {
            DataSet dsEmployee = null;
            dsEmployee = baseinfo.GetTableDateByFiled("tb_employee", "number", cbEmployeeNumber.Text,"name");
            txEmpolyeeName.Text = dsEmployee.Tables[0].Rows[0]["name"].ToString();
        }

        private void cbSupplierNumber_SelectedValueChanged(object sender, EventArgs e)
        {
            DataSet dsPurchase = null;
            dsPurchase = baseinfo.GetTableDateByFiled("tb_supplier", "number", cbSupplierNumber.Text, "name");
            txSupplierName.Text = dsPurchase.Tables[0].Rows[0]["name"].ToString();
        }
    }
}
