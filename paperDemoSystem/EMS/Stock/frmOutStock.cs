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
    public partial class frmOutStock : Form
    {
        public frmOutStock()
        {
            InitializeComponent();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            //TODO..
            this.Owner.Show();
            this.Close();
        }

        private void btCacle_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void frmOutStock_Load(object sender, EventArgs e)
        {
            BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
            DataSet ds = baseinfo.GetTableDateByFiled("tb_orders", "statu", "待出库");
            dataGridViewOrderList.DataSource = ds.Tables[0].DefaultView;
            dataGridViewOrderList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewOrderList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridViewOrderList.Columns[0].HeaderText = "销售单编号";
            dataGridViewOrderList.Columns[0].Visible = true;

            dataGridViewOrderList.Columns[1].HeaderText = "客户编号";
            dataGridViewOrderList.Columns[1].Visible = false;

            dataGridViewOrderList.Columns[2].HeaderText = "接单员工号";
            dataGridViewOrderList.Columns[2].Visible = false;

            dataGridViewOrderList.Columns[3].HeaderText = "客户姓名";
            dataGridViewOrderList.Columns[3].Visible = true;

            dataGridViewOrderList.Columns[4].HeaderText = "客户电话";
            dataGridViewOrderList.Columns[4].Visible = true;

            dataGridViewOrderList.Columns[5].HeaderText = "客户地址";
            dataGridViewOrderList.Columns[5].Visible = true;

            dataGridViewOrderList.Columns[6].HeaderText = "下单日期";
            dataGridViewOrderList.Columns[6].Visible = false;

            dataGridViewOrderList.Columns[7].HeaderText = "录单日期";
            dataGridViewOrderList.Columns[7].Visible = false;

            dataGridViewOrderList.Columns[8].HeaderText = "商品件数";
            dataGridViewOrderList.Columns[8].Visible = true;


            dataGridViewOrderList.Columns[9].HeaderText = "订单总金额";
            dataGridViewOrderList.Columns[9].Visible = false;

            dataGridViewOrderList.Columns[10].HeaderText = "订单状态";
            dataGridViewOrderList.Columns[10].Visible = true;
        }

        private void dataGridViewOrderList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void dataGridViewOrderList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EMS.Stock.frmOutStockDetailList out_stock_detail_list = new EMS.Stock.frmOutStockDetailList();
            out_stock_detail_list.WaiteOrderCode = dataGridViewOrderList[0, e.RowIndex].Value.ToString();
            out_stock_detail_list.Owner = this;
            out_stock_detail_list.Show();
        }

        private void dataGridViewOrderList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        { 
            
        }
    }
}
