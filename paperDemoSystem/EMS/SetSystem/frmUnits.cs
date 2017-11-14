using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EMS.SetSystem
{
    public partial class frmUnits : Form
    {
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
        BaseClass.cUnits units = new EMS.BaseClass.cUnits();
        public frmUnits()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            ds = baseinfo.GetAllUnit();
            if (ds.Tables[0].Rows.Count==0)
            {
                units.FullName = txtFullname.Text;
                units.Tax = txtTax.Text;
                units.Tel = txtTel.Text;
                units.Linkman = txtLinkMan.Text;
                units.Address = txtAddress.Text;
                units.Accounts = txtAccounts.Text;
                baseinfo.InsertSysUnits(units);
                MessageBox.Show("本单位信息设置成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            units.FullName = txtFullname.Text;
            units.Tax = txtTax.Text;
            units.Tel = txtTel.Text;
            units.Linkman = txtLinkMan.Text;
            units.Address = txtAddress.Text;
            units.Accounts = txtAccounts.Text;
            baseinfo.UpdateSysUnits(units);
            MessageBox.Show("本单位信息设置成功！","成功提示！",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void frmUnits_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = null;
                ds = baseinfo.GetAllUnit();
                txtFullname.Text = ds.Tables[0].Rows[0]["fullname"].ToString();
                txtTax.Text = ds.Tables[0].Rows[0]["tax"].ToString();
                txtTel.Text = ds.Tables[0].Rows[0]["tel"].ToString();
                txtLinkMan.Text = ds.Tables[0].Rows[0]["linkman"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0]["address"].ToString();
                txtAccounts.Text = ds.Tables[0].Rows[0]["accounts"].ToString();
            }
            catch { }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}