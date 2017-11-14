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
    public partial class frmOrderDetailList : Form
    {
        public frmOrderDetailList()
        {
            InitializeComponent();
        }

        private void frmOrderDetailList_Load(object sender, EventArgs e)
        {
            BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
            //DataSet ds = baseinfo.GetAllStock("tb_Stock");
           // DataSet ds = baseinfo.GetSaleList();
            DataSet ds = baseinfo.GetSaleDetailList("tb_orders_detailed", OrderDetailListCode);
            dataGridViewOrderDetailList.DataSource = ds.Tables[0].DefaultView;
            //dgvSelectStockList.DataSource = ds.Tables[0].DefaultView;

            dataGridViewOrderDetailList.Columns[0].HeaderText = "流水号";
            dataGridViewOrderDetailList.Columns[0].Width = 160;
            dataGridViewOrderDetailList.Columns[0].Visible = true;

            dataGridViewOrderDetailList.Columns[1].HeaderText = "销售订单号";
            dataGridViewOrderDetailList.Columns[1].Width = 160;
            dataGridViewOrderDetailList.Columns[1].Visible = true;

            dataGridViewOrderDetailList.Columns[2].HeaderText = "商品编号";
            dataGridViewOrderDetailList.Columns[2].Width = 160;
            dataGridViewOrderDetailList.Columns[2].Visible = true;

            dataGridViewOrderDetailList.Columns[3].HeaderText = "商品名字";
            dataGridViewOrderDetailList.Columns[3].Width = 160;
            dataGridViewOrderDetailList.Columns[3].Visible = true;

            dataGridViewOrderDetailList.Columns[4].HeaderText = "商品单位";
            dataGridViewOrderDetailList.Columns[4].Visible = true;
            dataGridViewOrderDetailList.Columns[4].Width = 160;

            dataGridViewOrderDetailList.Columns[5].HeaderText = "商品单价";
            dataGridViewOrderDetailList.Columns[5].Visible = true;
            dataGridViewOrderDetailList.Columns[5].Width = 160;

            dataGridViewOrderDetailList.Columns[6].HeaderText = "需求数量";
            dataGridViewOrderDetailList.Columns[6].Visible = true;
            dataGridViewOrderDetailList.Columns[6].Width = 160;

            this.Text = "销售订单 " + OrderDetailListCode + " 明细";
        }
        /// <summary>
        /// 销售订单编号
        /// </summary>        
        public string OrderDetailListCode
        { 
            set {order_detail_list_code = value;}
            get { return order_detail_list_code;}
        }
        /// <summary>
        /// 单击单元格
        /// </summary>  
        private void dataGridViewOrderDetailList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// 双击任意单元格
        /// </summary>   
        private void dataGridViewOrderDetailList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        { 
            //TODO...
        }
        /// <summary>
        /// 单元格值发生改变
        /// </summary>  
        private void dataGridViewOrderDetailList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        { 
            //TODO...
        }

        private string order_detail_list_code;

        private void BtBack_Click(object sender, EventArgs e)
        {
            //this.Parent.Show();
            this.Owner.Show();
            this.Close();
        }

        private void BtmodifyDetail_Click(object sender, EventArgs e)
        {

        }
    }
}
