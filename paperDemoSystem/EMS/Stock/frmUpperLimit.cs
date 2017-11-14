using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EMS.Stock
{
    public partial class frmUpperLimit : Form
    {
        public frmUpperLimit()
        {
            InitializeComponent();
        }

        private void frmUpperLimit_Load(object sender, EventArgs e)
        {
            BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
            DataSet ds = null;
            ds = baseinfo.GetUpperLimit();
            dgvStockList.DataSource = ds.Tables[0].DefaultView;
        }
    }
}