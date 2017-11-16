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
    public partial class frmOutStockList : Form
    {
        public frmOutStockList()
        {
            InitializeComponent();
        }

        private void btBackMain_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void dataGridViewOutStockList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewOutStockList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EMS.Stock.frmOutStockListDetail frm_out_detail = new EMS.Stock.frmOutStockListDetail();

            frm_out_detail.OutCode = dataGridViewOutStockList[0, e.RowIndex].Value.ToString();
            frm_out_detail.Owner = this;
            frm_out_detail.Show();
        }

        private void dataGridViewOutStockList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        { 
            
        }

        private void frmOutStockList_Load(object sender, EventArgs e)
        {
            BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
            DataSet ds = baseinfo.GetTableAllDataByName("tb_outStock");
            dataGridViewOutStockList.DataSource = ds.Tables[0].DefaultView;
            dataGridViewOutStockList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewOutStockList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridViewOutStockList.Columns[0].HeaderText = "出库单号";
            dataGridViewOutStockList.Columns[0].Visible = true;

            dataGridViewOutStockList.Columns[1].HeaderText = "销售订单号";
            dataGridViewOutStockList.Columns[1].Visible = true;

            dataGridViewOutStockList.Columns[2].HeaderText = "明细条数";
            dataGridViewOutStockList.Columns[2].Visible = true;

            dataGridViewOutStockList.Columns[3].HeaderText = "出库员工号";
            dataGridViewOutStockList.Columns[3].Visible = true;

            dataGridViewOutStockList.Columns[4].HeaderText = "出库员姓名";
            dataGridViewOutStockList.Columns[4].Visible = true;

            dataGridViewOutStockList.Columns[5].HeaderText = "出库日期";
            dataGridViewOutStockList.Columns[5].Visible = true;

            //dataGridViewOrderList.Columns[6].HeaderText = "下单日期";
            //dataGridViewOrderList.Columns[6].Visible = false;

            //dataGridViewOrderList.Columns[7].HeaderText = "录单日期";
            //dataGridViewOrderList.Columns[7].Visible = false;

            //dataGridViewOrderList.Columns[8].HeaderText = "商品件数";
            //dataGridViewOrderList.Columns[8].Visible = true;


            //dataGridViewOrderList.Columns[9].HeaderText = "订单总金额";
            //dataGridViewOrderList.Columns[9].Visible = false;

            //dataGridViewOrderList.Columns[10].HeaderText = "订单状态";
            //dataGridViewOrderList.Columns[10].Visible = true;
        }
    }
}
