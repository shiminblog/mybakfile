using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMS.SaleStock
{
    public partial class frmSellStockList : Form
    {
        //public string orderdetailcode = "";
        public frmSellStockList()
        {
            InitializeComponent();
        }

        private void frmSellStockList_Load(object sender, EventArgs e)
        {
            BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
            //DataSet ds = baseinfo.GetAllStock("tb_Stock");
            DataSet ds = baseinfo.GetSaleList("tb_orders");
            dataGridViewSellList.DataSource = ds.Tables[0].DefaultView;
            //dgvSelectStockList.DataSource = ds.Tables[0].DefaultView;

            dataGridViewSellList.Columns[0].HeaderText = "订单编号";
            dataGridViewSellList.Columns[0].Width = 160;
            dataGridViewSellList.Columns[0].Visible = true;

            dataGridViewSellList.Columns[1].HeaderText = "客户编号";
            dataGridViewSellList.Columns[1].Width = 160;
            dataGridViewSellList.Columns[1].Visible = true;

            dataGridViewSellList.Columns[2].HeaderText = "接单员号";
            dataGridViewSellList.Columns[2].Width = 160;
            dataGridViewSellList.Columns[2].Visible = true;

            dataGridViewSellList.Columns[3].HeaderText = "客户姓名";
            dataGridViewSellList.Columns[3].Width = 160;
            dataGridViewSellList.Columns[3].Visible = true;

            dataGridViewSellList.Columns[4].HeaderText = "客户电话";
            dataGridViewSellList.Columns[4].Visible = true;
            dataGridViewSellList.Columns[4].Width = 160;

            dataGridViewSellList.Columns[5].HeaderText = "客户地址";
            dataGridViewSellList.Columns[5].Visible = true;
            dataGridViewSellList.Columns[5].Width = 160;

            dataGridViewSellList.Columns[6].HeaderText = "下单日期";
            dataGridViewSellList.Columns[6].Visible = true;
            dataGridViewSellList.Columns[6].Width = 160;

            dataGridViewSellList.Columns[7].HeaderText = "录单日期";
            dataGridViewSellList.Columns[7].Visible = true;
            dataGridViewSellList.Columns[7].Width = 160;

            dataGridViewSellList.Columns[8].HeaderText = "商品件数";
            dataGridViewSellList.Columns[8].Visible = true;
            dataGridViewSellList.Columns[8].Width = 160;

            dataGridViewSellList.Columns[9].HeaderText = "订单总金额";
            dataGridViewSellList.Columns[9].Visible = true;
            dataGridViewSellList.Columns[9].Width = 160;

            dataGridViewSellList.Columns[10].HeaderText = "订单状态";
            dataGridViewSellList.Columns[10].Visible = true;
            dataGridViewSellList.Columns[10].Width = 160;
        }

        private void dataGridViewSellList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //SelectDataDialog.frmSelectStock selectStock = new EMS.SelectDataDialog.frmSelectStock();
            //selectStock.sellStock = this;          //将新创建的窗体对象设置为同一个窗体类的实例（对象）
            //selectStock.M_int_CurrentRow = e.RowIndex;
            //selectStock.M_str_object = "SellStock";　　//用于识别　是那一个窗体调用的selectStock窗口的
            //selectStock.ShowDialog();
            //new EMS.SaleStock.frmSellStockList().Show();
           // EMSfrmOrderDetailList 
            //dgvSelectStockList[0, e.RowIndex].Value.ToString();
            EMS.SaleStock.frmOrderDetailList orderdetail_list = new EMS.SaleStock.frmOrderDetailList();
            orderdetail_list.Owner = this;
            //orderdetail_list.OrderDetailListCode = dataGridViewSellList[0, e.RowIndex].ToString();
            orderdetail_list.OrderDetailListCode = dataGridViewSellList[0, e.RowIndex].Value.ToString();
            //this.Text = "" + 
           // orderdetail_list.Text = "销售订单 " + 
            orderdetail_list.Show();
        }

        private void dataGridViewSellList_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
 
        }

        private void dataGridViewSellList_CellStateChanged(object sender, DataGridViewCellEventArgs e)
        {
 
        }

        private void dataGridViewSellList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        { 
            
        }

        private void back_main_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
