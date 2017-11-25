using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace EMS
{
    public partial class frmLogin : Form
    {
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
        BaseClass.cPopedom popedom = new EMS.BaseClass.cPopedom();
        static int login_times = 0;
        string testConn = "Database=PaperDataBase;DataSource=127.0.0.1;UserId=root;Password=root;port=3306;pooling=false;charset=utf8";
        public frmLogin()
        {
            InitializeComponent();
        }
        private void backWelcomeForm()
        {
                        //this.Close();
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Close();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
                //int i = 0;
                if (txtUserName.Text == string.Empty)
                {
                    MessageBox.Show("用户名称不能为空！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //DataView DataSource = MySqlHelper.GetDataSet(testConn, CommandType.Text, "select * from user", null).Tables[0].DefaultView;

                DataSet ds = null;
                popedom.SysUser = txtUserName.Text;
                popedom.Password = txtUserPwd.Text;
                ds = baseinfo.Login(popedom);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    frmMain frm_main = new frmMain();
                    frm_main.Show();

                    //if (Convert.ToBoolean(ds.Tables[0].Rows[0]["stock"]))
                    frm_main.tlmBuy.Enabled = true;
                    //if (Convert.ToBoolean(ds.Tables[0].Rows[0]["vendition"])) 
                    frm_main.tlmSale.Enabled = true;
                    //if (Convert.ToBoolean(ds.Tables[0].Rows[0]["storage"])) 
                    frm_main.tlmStock.Enabled = true;
                    //if (Convert.ToBoolean(ds.Tables[0].Rows[0]["system"])) 
                    frm_main.tlmSystem.Enabled = true;
                    //if (Convert.ToBoolean(ds.Tables[0].Rows[0]["base"])) 
                    frm_main.tlmBase.Enabled = true;
                    this.Visible = false;
                    login_times = 0;
                }
                else
                {
                    MessageBox.Show("用户名称或密码不正确，请重新输入！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    login_times++;
                }
                if (login_times >= 3)
                {
                    MessageBox.Show("三次登陆不成功，系统拒绝登陆", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.backWelcomeForm();
                }
        }

        private void txtUserName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) txtUserPwd.Focus();
        }

        private void txtUserPwd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) btnLogin.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.backWelcomeForm();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}