using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EMS.BuyStock
{
    public partial class frmCurrentAccountBook : Form
    {
        public frmCurrentAccountBook()
        {
            InitializeComponent();
        }

        private void frmCurrentAccountBook_Load(object sender, EventArgs e)
        {

        }

        private void tlbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}