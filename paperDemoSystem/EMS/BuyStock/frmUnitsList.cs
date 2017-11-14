using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EMS.BuyStock
{
    public partial class frmUnitsList : Form
    {
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
        public frmUnitsList()
        {
            InitializeComponent();
        }

        private void frmUnitsList_Load(object sender, EventArgs e)
        {
            DataSet ds = null;
            ds = baseinfo.GetUnitsList();
            dgvUnitsList.DataSource = ds.Tables[0].DefaultView;
            dgvUnitsList.Columns[0].Width = 200;
        }

        private void dgvUnitsList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectDataDialog.frmSelectDateTime selectDateTime = new EMS.SelectDataDialog.frmSelectDateTime();
            selectDateTime.M_Str_units = dgvUnitsList[0, e.RowIndex].Value.ToString();
            selectDateTime.Show();
        }

        private void dgvUnitsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}