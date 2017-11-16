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
    public partial class frmOutStockListDetail : Form
    {
        private string out_code = "";

        /// <summary>
        /// 出库订单号
        /// </summary>
        public string OutCode
        {
            get { return out_code; }
            set { out_code = value; }
        }

        public frmOutStockListDetail()
        {
            InitializeComponent();
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void frmOutStockListDetail_Load(object sender, EventArgs e)
        {
            BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
            DataSet ds = baseinfo.GetTableDateByFiled("tb_outStock_detail", "out_code", OutCode);
            dataGridViewOutStockListDetail.DataSource = ds.Tables[0].DefaultView;
            dataGridViewOutStockListDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewOutStockListDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridViewOutStockListDetail.Columns[0].HeaderText = "明细流水号";
            dataGridViewOutStockListDetail.Columns[0].Visible = true;

            dataGridViewOutStockListDetail.Columns[1].HeaderText = "出库单号";
            dataGridViewOutStockListDetail.Columns[1].Visible = true;

            dataGridViewOutStockListDetail.Columns[2].HeaderText = "商品编号";
            dataGridViewOutStockListDetail.Columns[2].Visible = true;

            dataGridViewOutStockListDetail.Columns[3].HeaderText = "商品名字";
            dataGridViewOutStockListDetail.Columns[3].Visible = true;

            dataGridViewOutStockListDetail.Columns[4].HeaderText = "商品单位";
            dataGridViewOutStockListDetail.Columns[4].Visible = true;

            dataGridViewOutStockListDetail.Columns[5].HeaderText = "商品单价";
            dataGridViewOutStockListDetail.Columns[5].Visible = true;

            dataGridViewOutStockListDetail.Columns[6].HeaderText = "数量小计";
            dataGridViewOutStockListDetail.Columns[6].Visible = true;

            dataGridViewOutStockListDetail.Columns[7].HeaderText = "金额小计";
            dataGridViewOutStockListDetail.Columns[7].Visible = true;
        }
    }
}
