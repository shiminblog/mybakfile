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
    public partial class frmInStockList : Form
    {
        public frmInStockList()
        {
            InitializeComponent();
        }

        private void btBackMain_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void frmInStockList_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewInStockList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewInStockList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EMS.Stock.frmInStockListDetail frm_in_list = new EMS.Stock.frmInStockListDetail();
            frm_in_list.Owner = this;
            frm_in_list.EnCodeS = dataGridViewInStockList[0, e.RowIndex].Value.ToString();
            frm_in_list.Show();
        }

        private void dataGridViewInStockList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        { 
            
        }
    }
}
