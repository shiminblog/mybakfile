using System;
using System.Collections.Generic;
using System.Text;
//引用类库
//using System.Data.SqlClient;
using System.Data;
//引用 mysql
using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using MySql.Data.Types;
//该源码下载自win.51aspx.com(５１ａsｐｘ．ｃｏｍ)

namespace EMS.BaseClass
{
    class DataBase:IDisposable
    {
        //private SqlConnection con;  //sql2008 创建连接对象
        private MySqlConnection conn; //MySql 5.7
        string myConnectionString = "Database=PaperDataBase;DataSource=127.0.0.1;UserId=root;Password=root;port=3306;pooling=false;charset=utf8";
        #region   打开数据库连接
        /// <summary>
        /// 打开数据库连接.
        /// </summary>
        private void Open()
        {
            // 打开数据库连接
            if (conn == null)
            {
                //con = new SqlConnection("Data Source=(local);DataBase=db_CMS;User ID=sa;PWD=sa");
                conn = new MySqlConnection(myConnectionString);
            }
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();

        }
        #endregion

        #region  关闭连接
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void Close()
        {
            if (conn != null)
                conn.Close();
        }
        #endregion

        #region 释放数据库连接资源
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            // 确认连接是否已经关闭
            if (conn != null)
            {
                conn.Dispose();
                conn = null;
            }
        }
        //该源码下载自win.51aspx.com(５１ａｓpｘ．ｃｏｍ)

        #endregion

        #region   传入参数并且转换为MySqlParameter类型
        /// <summary>
        /// 转换参数
        /// </summary>
        /// <param name="ParamName">存储过程名称或命令文本</param>
        /// <param name="DbType">参数类型</param></param>
        /// <param name="Size">参数大小</param>
        /// <param name="Value">参数值</param>
        /// <returns>新的 parameter 对象</returns>
        public MySqlParameter MakeInParam(string ParamName, MySqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }

        /// <summary>
        /// 初始化参数值
        /// </summary>
        /// <param name="ParamName">存储过程名称或命令文本</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <param name="Direction">参数方向</param>
        /// <param name="Value">参数值</param>
        /// <returns>新的 parameter 对象</returns>
        public MySqlParameter MakeParam(string ParamName, MySqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            MySqlParameter param;

            if (Size > 0)
                param = new MySqlParameter(ParamName, DbType, Size);
            else
                param = new MySqlParameter(ParamName, DbType);

            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;
            return param;
        }
        #endregion

        #region   执行参数命令文本(无数据库中数据返回)
        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="procName">命令文本</param>
        /// <param name="prams">参数对象</param>
        /// <returns></returns>
        public int RunProc(string procName, MySqlParameter[] prams)
        {
            MySqlCommand cmd = CreateCommand(procName, prams);
            cmd.ExecuteNonQuery();
            this.Close();
            //得到执行成功返回值
            return (int)cmd.Parameters["ReturnValue"].Value;
        }
        /// <summary>
        /// 直接执行SQL语句
        /// </summary>
        /// <param name="procName">命令文本</param>
        /// <returns></returns>
        public int RunProc(string procName)
        {
            this.Open();
            //SqlCommand cmd = new SqlCommand(procName, con);
            MySqlCommand cmd = new MySqlCommand(procName, conn);
            cmd.ExecuteNonQuery();
            this.Close();
            return 1;
        }

        #endregion

        #region   执行参数命令文本(有返回值)
        /// <summary>
        /// 执行查询命令文本，并且返回DataSet数据集
        /// </summary>
        /// <param name="procName">命令文本</param>
        /// <param name="prams">参数对象</param>
        /// <param name="tbName">数据表名称</param>
        /// <returns></returns>
        public DataSet RunProcReturn(string procName, MySqlParameter[] prams,string tbName)
        {
            MySqlDataAdapter dap=CreateDataAdaper(procName, prams);
            DataSet ds = new DataSet();
            dap.Fill(ds,tbName);
            this.Close();
            //得到执行成功返回值
            return ds;
        }

        /// <summary>
        /// 执行命令文本，并且返回DataSet数据集
        /// </summary>
        /// <param name="procName">命令文本</param>
        /// <param name="tbName">数据表名称</param>
        /// <returns>DataSet</returns>
        public DataSet RunProcReturn(string procName, string tbName)
        {
            MySqlDataAdapter dap = CreateDataAdaper(procName, null);
            DataSet ds = new DataSet();
            dap.Fill(ds, tbName);
            this.Close();
            //得到执行成功返回值
            return ds;
        }

        #endregion

        #region 将命令文本添加到MySqlDataAdapter
        /// <summary>
        /// 创建一个SqlDataAdapter对象以此来执行命令文本
        /// </summary>
        /// <param name="procName">命令文本</param>
        /// <param name="prams">参数对象</param>
        /// <returns></returns>
        private MySqlDataAdapter CreateDataAdaper(string procName, MySqlParameter[] prams /*SqlParameter[] prams*/)
        {
            this.Open();
            //SqlDataAdapter dap = new SqlDataAdapter(procName,con);
            MySqlDataAdapter dap = new MySqlDataAdapter(procName, conn);
            dap.SelectCommand.CommandType = CommandType.Text;  //执行类型：命令文本
            if (prams != null)
            {
                foreach (MySqlParameter parameter in prams)
                    dap.SelectCommand.Parameters.Add(parameter);
            }
            //加入返回参数
           /* 
            dap.SelectCommand.Parameters.Add(new MySqlParameter("ReturnValue", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 0, 0,
                string.Empty, DataRowVersion.Default, null));
            */
            dap.SelectCommand.Parameters.Add(new MySqlParameter("ReturnValue", MySqlDbType.Int32, 4,
                ParameterDirection.ReturnValue, false, 0, 0,
                string.Empty, DataRowVersion.Default, null));

            return dap;
        }
        #endregion

        #region   将命令文本添加到MySqlCommand
        /// <summary>
        /// 创建一个SqlCommand对象以此来执行命令文本
        /// </summary>
        /// <param name="procName">命令文本</param>
        /// <param name="prams"命令文本所需参数</param>
        /// <returns>返回SqlCommand对象</returns>
        private MySqlCommand CreateCommand(string procName, MySqlParameter[] prams)
        {
            // 确认打开连接
            this.Open();
            MySqlCommand cmd = new MySqlCommand(procName, conn);
            cmd.CommandType = CommandType.Text;　　　　 //执行类型：命令文本

            // 依次把参数传入命令文本
            if (prams != null)
            {
                foreach (MySqlParameter parameter in prams)
                    cmd.Parameters.Add(parameter);
            }
            // 加入返回参数
            /*
            cmd.Parameters.Add(
                new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 0, 0,
                string.Empty, DataRowVersion.Default, null));
            */


            //cmd.Parameters.Add(
            //    new MySqlParameter("ReturnValue", MySqlDbType.Int32, 4,
            //    ParameterDirection.ReturnValue, false, 0, 0,
            //    string.Empty, DataRowVersion.Default, 111));

            cmd.Parameters.Add(new MySqlParameter("ReturnValue", MySqlDbType.Int64, 32,
                                ParameterDirection.ReturnValue, false, 0, 0,
                                string.Empty, DataRowVersion.Default, 1111));

            return cmd;
        }
        #endregion
    }
}
