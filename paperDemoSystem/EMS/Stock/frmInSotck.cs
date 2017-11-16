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
    public partial class frmInSotck : Form
    {
        public frmInSotck()
        {
            InitializeComponent();
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void frmInSotck_Load(object sender, EventArgs e)
        {
            //this.Owner = new 
            this.Owner = frmMain.ActiveForm;
            BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
            DataSet ds = baseinfo.GetTableDateByFiled("tb_purchase", "statu", "待入库");
            dataGridViewInStockList.DataSource = ds.Tables[0].DefaultView;
            dataGridViewInStockList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewInStockList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewInStockList.Columns[0].HeaderText = "采购单编号";
            dataGridViewInStockList.Columns[0].Visible = true;

            dataGridViewInStockList.Columns[1].HeaderText = "供应商编号";
            dataGridViewInStockList.Columns[1].Visible = true;

            dataGridViewInStockList.Columns[2].HeaderText = "供应商姓名";
            dataGridViewInStockList.Columns[2].Visible = true;

            dataGridViewInStockList.Columns[3].HeaderText = "供应商联系电话";
            dataGridViewInStockList.Columns[3].Visible = true;

            dataGridViewInStockList.Columns[4].HeaderText = "供应商地址";
            dataGridViewInStockList.Columns[4].Visible = true;

            dataGridViewInStockList.Columns[5].HeaderText = "采购员工号";
            dataGridViewInStockList.Columns[5].Visible = true;


            dataGridViewInStockList.Columns[6].HeaderText = "采购员姓名";
            dataGridViewInStockList.Columns[6].Visible = true;


            dataGridViewInStockList.Columns[7].HeaderText = "下单日期";
            dataGridViewInStockList.Columns[7].Visible = true;


            dataGridViewInStockList.Columns[8].HeaderText = "录单日期";
            dataGridViewInStockList.Columns[8].Visible = true;


            dataGridViewInStockList.Columns[9].HeaderText = "要货日期";
            dataGridViewInStockList.Columns[9].Visible = true;


            dataGridViewInStockList.Columns[10].HeaderText = "商品件数";
            dataGridViewInStockList.Columns[10].Visible = true;


            dataGridViewInStockList.Columns[11].HeaderText = "订单总金额";
            dataGridViewInStockList.Columns[11].Visible = true;


            dataGridViewInStockList.Columns[12].HeaderText = "订单状态";
            dataGridViewInStockList.Columns[12].Visible = true;

        }

        private void dataGridViewInStockList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewInStockList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EMS.Stock.frmInStockDetailList in_stock_detail_list = new EMS.Stock.frmInStockDetailList();
            in_stock_detail_list.WaitePurchaseCode = dataGridViewInStockList[0, e.RowIndex].Value.ToString();
            if (in_stock_detail_list.WaitePurchaseCode != string.Empty)
            {
                in_stock_detail_list.Owner = this;
                in_stock_detail_list.Show();
            }
            else
            {
                MessageBox.Show("此行数据无效!", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewInStockList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
