using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EMS.BaseInfo
{
    public partial class frmStock : Form
    {
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
        BaseClass.cStockInfo stockinfo = new EMS.BaseClass.cStockInfo();
        int G_Int_addOrUpdate = 0;
        public frmStock()
        {
            InitializeComponent();
        }

        private void tlBtnAdd_Click(object sender, EventArgs e)
        {
            this.editEnabled();
            this.clearText();
            G_Int_addOrUpdate = 0;   //等于０为添加数据
            //设置自动编号
            DataSet ds = null;
            string P_Str_newTradeCode = "";
            int P_Int_newTradeCode = 0;
            ds = baseinfo.GetAllStock("tb_stock");
            if (ds.Tables[0].Rows.Count == 0)
            {
                txtTradeCode.Text = "T1001";
            }
            else
            {
                P_Str_newTradeCode = Convert.ToString(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["tradecode"]);
                P_Int_newTradeCode = Convert.ToInt32(P_Str_newTradeCode.Substring(1, 4)) + 1;
                P_Str_newTradeCode = "T" + P_Int_newTradeCode.ToString();
                txtTradeCode.Text = P_Str_newTradeCode;
            }
        }

        private void editEnabled()  //屏毕与此功能无关的按钮
        {
            groupBox1.Enabled = true;     //将容器可以使用，准备添加新的往来单位信息
            tlBtnAdd.Enabled = false;
            tlBtnEdit.Enabled = false;
            tlBtnDelete.Enabled = false;
            tlBtnSave.Enabled = true;
            tlBtnCancel.Enabled = true;
        }
        private void cancelEnabled()
        {
            groupBox1.Enabled = false;
            tlBtnAdd.Enabled = true;
            tlBtnEdit.Enabled = true;
            tlBtnDelete.Enabled = true;
            tlBtnSave.Enabled = false;
            tlBtnCancel.Enabled = false;
        }
        private void clearText()
        {
            txtTradeCode.Text= string.Empty;
            txtFullName.Text = string.Empty;
            txtType.Text = string.Empty;
            txtStandard.Text = string.Empty;
            txtUnit.Text = string.Empty;
            txtProduce.Text = string.Empty;
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
            dgvStockList.Columns[8].HeaderText = "商品价格（加权平均价格）";
            dgvStockList.Columns[9].Visible = false;
            dgvStockList.Columns[10].HeaderText = "盘点数量";
            dgvStockList.Columns[11].Visible = false;
            dgvStockList.Columns[12].Visible = false;
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            txtTradeCode.ReadOnly = true;　　　　//商品编号为唯一标识不能更改
            this.cancelEnabled();
            dgvStockList.DataSource = baseinfo.GetAllStock("tb_stock").Tables[0].DefaultView;
            this.SetdgvStockListHeadText();
        }

        private void tlBtnSave_Click(object sender, EventArgs e)
        {
            //判断是添加还是修改数据
            if (G_Int_addOrUpdate == 0)
            {
                try
                {
                    //添加数据
                    stockinfo.TradeCode = txtTradeCode.Text;
                    stockinfo.FullName = txtFullName.Text;
                    stockinfo.TradeType = txtType.Text;
                    stockinfo.Standard = txtStandard.Text;
                    stockinfo.Unit = txtUnit.Text;
                    stockinfo.Produce = txtProduce.Text;

                    //执行添加
                    int id = baseinfo.AddStock(stockinfo);
                    MessageBox.Show("新增--库存商品数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //修改数据
                stockinfo.TradeCode = txtTradeCode.Text;
                stockinfo.FullName = txtFullName.Text;
                stockinfo.TradeType = txtType.Text;
                stockinfo.Standard = txtStandard.Text;
                stockinfo.Unit = txtUnit.Text;
                stockinfo.Produce = txtProduce.Text;

                //执行修改
                int id = baseinfo.UpdateStock(stockinfo);
                MessageBox.Show("修改--库存商品数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvStockList.DataSource = baseinfo.GetAllStock("tb_stock").Tables[0].DefaultView;
            this.SetdgvStockListHeadText();
            this.cancelEnabled();
        }

        private void tlBtnEdit_Click(object sender, EventArgs e)
        {
            this.editEnabled();
            G_Int_addOrUpdate = 1;   //等于１为修改数据
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

        private void tlBtnDelete_Click(object sender, EventArgs e)
        {
            if (txtTradeCode.Text.Trim() == string.Empty)
            {
                MessageBox.Show("删除--库存商品数据--失败！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            stockinfo.TradeCode = txtTradeCode.Text;
            //执行删除
            try
            {
                int id = baseinfo.DeleteStock(stockinfo);
                MessageBox.Show("删除--库存商品数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvStockList.DataSource = baseinfo.GetAllStock("tb_stock").Tables[0].DefaultView;
                this.SetdgvStockListHeadText();
                this.clearText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlBtnCancel_Click(object sender, EventArgs e)
        {
            this.cancelEnabled();
        }

        private void dgvStockList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTradeCode.Text = this.dgvStockList[0, dgvStockList.CurrentCell.RowIndex].Value.ToString();
            txtFullName.Text = this.dgvStockList[1, dgvStockList.CurrentCell.RowIndex].Value.ToString();
            txtType.Text = this.dgvStockList[2, dgvStockList.CurrentCell.RowIndex].Value.ToString();
            txtStandard.Text = this.dgvStockList[3, dgvStockList.CurrentCell.RowIndex].Value.ToString();
            txtUnit.Text = this.dgvStockList[4, dgvStockList.CurrentCell.RowIndex].Value.ToString();
            txtProduce.Text = this.dgvStockList[5, dgvStockList.CurrentCell.RowIndex].Value.ToString();
        }

        private void tlBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}