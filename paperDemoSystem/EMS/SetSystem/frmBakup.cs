using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EMS.SetSystem
{
    public partial class frmBakup : Form
    {
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
        public frmBakup()
        {
            InitializeComponent();
        }

        private void btnBak_Click(object sender, EventArgs e)
        {
            string fileName = "";
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".bak";
            saveFile.ShowDialog();
            fileName = saveFile.FileName;
            if (fileName == "") return;
            baseinfo.BackUp(fileName);
            MessageBox.Show("数据库备份--成功！", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRestor_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "BakUp files (*.bak)|*.bak";
            openFile.ShowDialog();
            string fileName = "";
            fileName = openFile.FileName;
            if (fileName == "") return;
            baseinfo.ReStore(fileName);
            MessageBox.Show("数据库恢复--成功！", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}