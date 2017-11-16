using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EMS.Stock
{
    public partial class frmCheckStock : Form
    {
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
        BaseClass.cStockInfo stockinfo = new EMS.BaseClass.cStockInfo();
        string G_Str_tradecode = "";
        

        public frmCheckStock()
        {
            InitializeComponent();
        }
        //设置DataGridView标题
        private void SetdgvStockListHeadText()
        {
            dgvStockList.Columns[0].HeaderText = "商品编号";
            dgvStockList.Columns[1].HeaderText = "商品名称";
            dgvStockList.Columns[2].HeaderText = "商品型号";
            dgvStockList.Columns[3].HeaderText = "商品规格";
            dgvStockList.Columns[4].HeaderText = "商品单位";
            dgvStockList.Columns[5].HeaderText = "商品产地";
            dgvStockList.Columns[6].HeaderText = "库存数量";
            dgvStockList.Columns[7].Visible = false;
            dgvStockList.Columns[8].Visible = false;
            dgvStockList.Columns[9].Visible = false;
            dgvStockList.Columns[10].HeaderText = "盘点数量";
            dgvStockList.Columns[11].Visible = false;
            dgvStockList.Columns[12].Visible = false;
        }
        private void tlBtnFind_Click(object sender, EventArgs e)
        {
            if (tlCmbStockType.Text == string.Empty)
            {
                MessageBox.Show("查询类别不能为空！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tlCmbStockType.Focus();
                return;
            }
            else
            {
                if (tlTxtFindStock.Text.Trim() == string.Empty)
                {
                    dgvStockList.DataSource = baseinfo.GetAllStock("tb_stock").Tables[0].DefaultView;
                    this.SetdgvStockListHeadText();
                    return;
                }
            }
            DataSet ds = null;   //创建DataSet对象
            if (tlCmbStockType.Text == "商品产地")  //按单位编号查询
            {
                stockinfo.Produce = tlTxtFindStock.Text;
                ds = baseinfo.FindStockByProduce(stockinfo, "tb_Stock");
                dgvStockList.DataSource = ds.Tables[0].DefaultView;
            }
            else　　　　　　　　　　　　　　　　　//按单位名称查询
            {
                stockinfo.FullName = tlTxtFindStock.Text;
                ds = baseinfo.FindStockByFullName(stockinfo, "tb_stock");
                dgvStockList.DataSource = ds.Tables[0].DefaultView;
            }
            this.SetdgvStockListHeadText();
        }

        private void frmCheckStock_Load(object sender, EventArgs e)
        {
            dgvStockList.DataSource = baseinfo.GetAllStock("tb_stock").Tables[0].DefaultView;
            this.SetdgvStockListHeadText();
        }

        private void dgvStockList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            tltxtFullName.Text = dgvStockList[1, e.RowIndex].Value.ToString();
            G_Str_tradecode = dgvStockList[0, e.RowIndex].Value.ToString();
        }

        private void tlbtnCheckStock_Click(object sender, EventArgs e)
        {
            if (tltxtCheckStock.Text == string.Empty)
            {
                MessageBox.Show("盘点数量不能为空！","错误提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            //验证输入的文本必须为阿拉伯数字。
            for (int i = 0; i < tltxtCheckStock.Text.Length; i++)
            {
                if (!Char.IsNumber(tltxtCheckStock.Text, i))
                {
                    MessageBox.Show("库存上限设置必须为阿拉伯数字！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            stockinfo.TradeCode = G_Str_tradecode;
            stockinfo.Check = Convert.ToSingle(tltxtCheckStock.Text);
            int d= baseinfo.CheckStock(stockinfo);
            dgvStockList.DataSource = baseinfo.GetAllStock("tb_stock").Tables[0].DefaultView;
            this.SetdgvStockListHeadText();
            MessageBox.Show("保存库存商品盘点成功！","成功提示",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void tlBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void dgvStockList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}