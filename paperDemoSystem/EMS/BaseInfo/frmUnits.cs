using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//引用类库
using System.Data.SqlClient;

namespace EMS.BaseInfo
{
    public partial class frmUnits : Form
    {
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
        BaseClass.cUnitsInfo unitsInfo = new EMS.BaseClass.cUnitsInfo();
        int G_Int_addOrUpdate = 0;
        public frmUnits()
        {
            InitializeComponent();
        }

        private void frmUnits_Load(object sender, EventArgs e)
        {
            txtUnitCode.ReadOnly =true;　　　　//单位编号为唯一标识不能更改
            this.cancelEnabled();
            dgvUnitsList.DataSource = baseinfo.GetAllUnits("tb_units").Tables[0].DefaultView;
            this.SetdgvUnitsListHeadText();
        }

        private void tlBtnAdd_Click(object sender, EventArgs e)
        {

            this.editEnabled();
            this.clearText();
            G_Int_addOrUpdate = 0;   //等于０为添加数据
            //设置自动编号
            DataSet ds = null;
            string P_Str_newUnitcode = "";
            int P_Int_newUnitcode = 0;
            ds = baseinfo.GetAllUnits("tb_units");
            if (ds.Tables[0].Rows.Count == 0)
            {
                txtUnitCode.Text = "U1001";
            }
            else
            {
                P_Str_newUnitcode = Convert.ToString(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["unitcode"]);
                P_Int_newUnitcode = Convert.ToInt32(P_Str_newUnitcode.Substring(1, 4)) + 1;
                P_Str_newUnitcode = "U" + P_Int_newUnitcode.ToString();
                txtUnitCode.Text = P_Str_newUnitcode;
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
            txtUnitCode.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtTax.Text = string.Empty;
            txtTel.Text = string.Empty;
            txtLinkMan.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtAccounts.Text = string.Empty;
        }

        private void tlBtnCancel_Click(object sender, EventArgs e)
        {
            this.cancelEnabled();
        }

        private void tlBtnEdit_Click(object sender, EventArgs e)
        {
            this.editEnabled();
            G_Int_addOrUpdate = 1;   //等于１为修改数据
        }

        private void tlBtnSave_Click(object sender, EventArgs e)
        {
            //判断是添加还是修改数据
            if (G_Int_addOrUpdate == 0)
            {
                try
                {
                    //添加数据
                    unitsInfo.UnitCode = txtUnitCode.Text;
                    unitsInfo.FullName = txtFullName.Text;
                    unitsInfo.Tax = txtTax.Text;
                    unitsInfo.Tel = txtTel.Text;
                    unitsInfo.LinkMan = txtLinkMan.Text;
                    unitsInfo.Address = txtAddress.Text;
                    unitsInfo.Accounts = txtAccounts.Text;
                    //执行添加
                    int id = baseinfo.AddUnits(unitsInfo);
                    MessageBox.Show("新增--往来单位数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message,"错误提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                //修改数据
                unitsInfo.UnitCode = txtUnitCode.Text;
                unitsInfo.FullName = txtFullName.Text;
                unitsInfo.Tax = txtTax.Text;
                unitsInfo.Tel = txtTel.Text;
                unitsInfo.LinkMan = txtLinkMan.Text;
                unitsInfo.Address = txtAddress.Text;
                unitsInfo.Accounts = txtAccounts.Text;
                //执行修改
                int id = baseinfo.UpdateUnits(unitsInfo);
                MessageBox.Show("修改--往来单位数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvUnitsList.DataSource = baseinfo.GetAllUnits("tb_units").Tables[0].DefaultView;
            this.SetdgvUnitsListHeadText();
            this.cancelEnabled();
        }
        //查询往来单位
        private void tlBtnFind_Click(object sender, EventArgs e)
        {
            if (tlCmbUnitsType.Text == string.Empty)
            {
                MessageBox.Show("查询类别不能为空！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tlCmbUnitsType.Focus();
                return;
            }
            else
            {
                if (tlTxtFindUnits.Text.Trim() == string.Empty)
                {
                    dgvUnitsList.DataSource = baseinfo.GetAllUnits("tb_units").Tables[0].DefaultView;
                    this.SetdgvUnitsListHeadText();
                    return;
                }
            }
            DataSet ds = null;   //创建DataSet对象
            if (tlCmbUnitsType.Text == "单位编号")  //按单位编号查询
            {
                unitsInfo.UnitCode = tlTxtFindUnits.Text;
                ds = baseinfo.FindUnitsByUnitCode(unitsInfo, "tbUnits");
                dgvUnitsList.DataSource = ds.Tables[0].DefaultView;
            }
            else　　　　　　　　　　　　　　　　　//按单位名称查询
            {
                unitsInfo.FullName = tlTxtFindUnits.Text;
                ds = baseinfo.FindUnitsByFullName(unitsInfo, "tbUnits");
                dgvUnitsList.DataSource = ds.Tables[0].DefaultView;
            }
            this.SetdgvUnitsListHeadText(); 
        }
        //设置DataGridView标题
        public void SetdgvUnitsListHeadText()
        {
            dgvUnitsList.Columns[0].HeaderText = "单位编号";
            dgvUnitsList.Columns[1].HeaderText = "单位名称";
            dgvUnitsList.Columns[2].HeaderText = "税号";
            dgvUnitsList.Columns[3].HeaderText = "单位电话";
            dgvUnitsList.Columns[4].HeaderText = "联系人";
            dgvUnitsList.Columns[5].HeaderText = "单位地址";
            dgvUnitsList.Columns[6].HeaderText = "开户行及账号";
            dgvUnitsList.Columns[7].HeaderText = "累计应收款";
            dgvUnitsList.Columns[7].Visible = false;
            dgvUnitsList.Columns[8].HeaderText = "累计应付款";
            dgvUnitsList.Columns[8].Visible = false;
        }

        private void dgvUnitsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUnitCode.Text = this.dgvUnitsList[0, dgvUnitsList.CurrentCell.RowIndex].Value.ToString();
            txtFullName.Text = this.dgvUnitsList[1, dgvUnitsList.CurrentCell.RowIndex].Value.ToString();
            txtTax.Text = this.dgvUnitsList[2, dgvUnitsList.CurrentCell.RowIndex].Value.ToString();
            txtTel.Text = this.dgvUnitsList[3, dgvUnitsList.CurrentCell.RowIndex].Value.ToString();
            txtLinkMan.Text = this.dgvUnitsList[4, dgvUnitsList.CurrentCell.RowIndex].Value.ToString();
            txtAddress.Text = this.dgvUnitsList[5, dgvUnitsList.CurrentCell.RowIndex].Value.ToString();
            txtAccounts.Text = this.dgvUnitsList[6, dgvUnitsList.CurrentCell.RowIndex].Value.ToString();
        }

        private void tlBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlBtnDelete_Click(object sender, EventArgs e)
        {
            if (txtUnitCode.Text.Trim() == string.Empty)
            {
                MessageBox.Show("删除--往来单位数据--失败！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            unitsInfo.UnitCode = txtUnitCode.Text;
            //执行删除
            int id = baseinfo.DeleteUnits(unitsInfo);
            MessageBox.Show("删除--往来单位数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvUnitsList.DataSource = baseinfo.GetAllUnits("tb_units").Tables[0].DefaultView;
            this.SetdgvUnitsListHeadText();
            this.clearText();
        }
    }
}