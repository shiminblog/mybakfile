using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EMS.SelectDataDialog
{
    public partial class frmSelectStock : Form
    {
        public BuyStock.frmBuyStock buyStock;
        public SaleStock.frmResellStock resellStock;
        public BuyStock.frmRebuyStock reBuyStock;
        public SaleStock.frmSellStock sellStock;

        public int M_int_CurrentRow;
        public string M_str_object = "";

        public frmSelectStock()
        {
            InitializeComponent();
        }

        private void SelectStock_Load(object sender, EventArgs e)
        {
            BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
            DataSet ds = baseinfo.GetAllStock("tb_Stock");
            dgvSelectStockList.DataSource = ds.Tables[0].DefaultView;

            dgvSelectStockList.Columns[0].HeaderText = "商品编号";
            dgvSelectStockList.Columns[0].Width = 80;
            dgvSelectStockList.Columns[0].Visible = true;

            dgvSelectStockList.Columns[1].HeaderText = "商品名称";
            dgvSelectStockList.Columns[1].Width = 80;
            dgvSelectStockList.Columns[1].Visible = true;

            dgvSelectStockList.Columns[2].HeaderText = "库存数量";
            dgvSelectStockList.Columns[2].Width = 80;
            dgvSelectStockList.Columns[2].Visible = true;

            dgvSelectStockList.Columns[3].HeaderText = "商品单位";
            dgvSelectStockList.Columns[3].Width = 80;
            dgvSelectStockList.Columns[3].Visible = true;

            dgvSelectStockList.Columns[4].HeaderText = "成本均价";
            dgvSelectStockList.Columns[4].Width = 80;
            dgvSelectStockList.Columns[4].Visible = true;

            dgvSelectStockList.Columns[5].HeaderText = "成本总价";
            dgvSelectStockList.Columns[5].Width = 80;
            dgvSelectStockList.Columns[5].Visible = true;

            //dgvSelectStockList.Columns[5].Visible = false;
            //dgvSelectStockList.Columns[6].HeaderText = "库存数量";
            //dgvSelectStockList.Columns[6].Width = 80;
            //dgvSelectStockList.Columns[7].Visible = false;
            //dgvSelectStockList.Columns[8].Visible = false;
            //dgvSelectStockList.Columns[9].Visible = false;
            //dgvSelectStockList.Columns[10].HeaderText = "盘点数量";
            //dgvSelectStockList.Columns[10].Width = 80;
            //dgvSelectStockList.Columns[11].Visible = false;
            //dgvSelectStockList.Columns[12].Visible = false;
        }

        private void dgvSelectStockList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (M_str_object == "BuyStock")
            {
                buyStock.dgvStockList[0, M_int_CurrentRow].Value = dgvSelectStockList[0, e.RowIndex].Value.ToString();
                buyStock.dgvStockList[1, M_int_CurrentRow].Value = dgvSelectStockList[1, e.RowIndex].Value.ToString();
                buyStock.dgvStockList[2, M_int_CurrentRow].Value = dgvSelectStockList[4, e.RowIndex].Value.ToString();
                buyStock.dgvStockList[4, M_int_CurrentRow].Value = dgvSelectStockList[7, e.RowIndex].Value.ToString();
                this.Close();
            }
            if (M_str_object == "ResellStock")
            {
                resellStock.dgvStockList[0, M_int_CurrentRow].Value = dgvSelectStockList[0, e.RowIndex].Value.ToString();
                resellStock.dgvStockList[1, M_int_CurrentRow].Value = dgvSelectStockList[1, e.RowIndex].Value.ToString();
                resellStock.dgvStockList[2, M_int_CurrentRow].Value = dgvSelectStockList[4, e.RowIndex].Value.ToString();
                resellStock.dgvStockList[4, M_int_CurrentRow].Value = dgvSelectStockList[7, e.RowIndex].Value.ToString();
                this.Close();
            }
            if (M_str_object == "RebuyStock")
            {
                reBuyStock.dgvStockList[0, M_int_CurrentRow].Value = dgvSelectStockList[0, e.RowIndex].Value.ToString();
                reBuyStock.dgvStockList[1, M_int_CurrentRow].Value = dgvSelectStockList[1, e.RowIndex].Value.ToString();
                reBuyStock.dgvStockList[2, M_int_CurrentRow].Value = dgvSelectStockList[4, e.RowIndex].Value.ToString();
                reBuyStock.dgvStockList[4, M_int_CurrentRow].Value = dgvSelectStockList[7, e.RowIndex].Value.ToString();
                this.Close();
            }
            if (M_str_object == "SellStock")
            {
                sellStock.dgvStockList[0, M_int_CurrentRow].Value = dgvSelectStockList[0, e.RowIndex].Value.ToString();
                sellStock.dgvStockList[1, M_int_CurrentRow].Value = dgvSelectStockList[1, e.RowIndex].Value.ToString();
                sellStock.dgvStockList[2, M_int_CurrentRow].Value = dgvSelectStockList[2, e.RowIndex].Value.ToString();
                sellStock.dgvStockList[3, M_int_CurrentRow].Value = dgvSelectStockList[3, e.RowIndex].Value.ToString();
                sellStock.dgvStockList[4, M_int_CurrentRow].Value = dgvSelectStockList[4, e.RowIndex].Value.ToString();
                //sellStock.dgvStockList[5, M_int_CurrentRow].Value = dgvSelectStockList[5, e.RowIndex].Value.ToString();
                this.Close();
            }
        }
    }
}