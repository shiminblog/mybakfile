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
    public partial class frmInStockListDetail : Form
    {
        private string en_code = "";
        /// <summary>
        /// 入库单号
        /// </summary>
        public string EnCodeS
        {
            get { return en_code; }
            set { en_code = value; }
        }

        public frmInStockListDetail()
        {
            InitializeComponent();
        }

        private void dataGridViewInStockListDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btBack_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void frmInStockListDetail_Load(object sender, EventArgs e)
        {
            BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
            DataSet ds = baseinfo.GetTableDateByFiled("tb_entryStock_detail", "entry_code", EnCodeS);
            dataGridViewInStockListDetail.DataSource = ds.Tables[0].DefaultView;
            dataGridViewInStockListDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewInStockListDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridViewInStockListDetail.Columns[0].HeaderText = "明细流水号";
            dataGridViewInStockListDetail.Columns[0].Visible = true;

            dataGridViewInStockListDetail.Columns[1].HeaderText = "入库单号";
            dataGridViewInStockListDetail.Columns[1].Visible = true;

            dataGridViewInStockListDetail.Columns[2].HeaderText = "商品编号";
            dataGridViewInStockListDetail.Columns[2].Visible = true;

            dataGridViewInStockListDetail.Columns[3].HeaderText = "商品名字";
            dataGridViewInStockListDetail.Columns[3].Visible = true;

            dataGridViewInStockListDetail.Columns[4].HeaderText = "商品单位";
            dataGridViewInStockListDetail.Columns[4].Visible = true;

            dataGridViewInStockListDetail.Columns[5].HeaderText = "商品单价";
            dataGridViewInStockListDetail.Columns[5].Visible = true;

            dataGridViewInStockListDetail.Columns[6].HeaderText = "数量小计";
            dataGridViewInStockListDetail.Columns[6].Visible = true;

            dataGridViewInStockListDetail.Columns[7].HeaderText = "金额小计";
            dataGridViewInStockListDetail.Columns[7].Visible = true;
        }
    }
}
