using System;
using System.Collections.Generic;
using System.Text;
//引用类库
using System.Data;
//using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using MySql.Data.Types;

using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.Odbc;

namespace EMS.BaseClass
{
    class BaseInfo
    {
        //[DllImport("shell32")]
        //public static extern long ShellExecute()
        ////(ByVal hWnd As Long, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Long) As Long
        //public static extern long 
        //[DllImport("NETAPI32")]
        //public static extern long NetMessageBufferSend(string Server, byte[] yToName, byte[] yFromName, byte[] yMsg, int lSize);

        DataBase data = new DataBase();

        #region 添加--往来单位信息
        /// <summary>
        /// 添加往来单位
        /// </summary>
        /// <param name="client"></param>
        /// <returns>返回往来单位id</returns>
        public int AddUnits(cUnitsInfo units)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@unitcode",  MySqlDbType.VarChar, 5, units.UnitCode),
                						data.MakeInParam("@fullname",  MySqlDbType.VarChar, 30, units.FullName),
                						data.MakeInParam("@tax",  MySqlDbType.VarChar, 30, units.Tax),
                						data.MakeInParam("@tel",  MySqlDbType.VarChar, 20, units.Tel),
                						data.MakeInParam("@linkman",  MySqlDbType.VarChar, 10, units.LinkMan),
                						data.MakeInParam("@address",  MySqlDbType.VarChar, 60, units.Address),
                						data.MakeInParam("@accounts",  MySqlDbType.VarChar, 80, units.Accounts),
										
			};
            return (data.RunProc("INSERT INTO tb_units (unitcode, fullname, tax, tel, linkman, address, accounts) VALUES (@unitcode,@fullname,@tax,@tel,@linkman,@address,@accounts)", prams));
        }
        #endregion

        #region 修改--往来单位信息
        /// <summary>
        /// 修改往来单位信息
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
        public int UpdateUnits(cUnitsInfo units)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@unitcode",  MySqlDbType.VarChar, 5, units.UnitCode),
                						data.MakeInParam("@fullname",  MySqlDbType.VarChar, 30, units.FullName),
                						data.MakeInParam("@tax",  MySqlDbType.VarChar, 30, units.Tax),
                						data.MakeInParam("@tel",  MySqlDbType.VarChar, 20, units.Tel),
                						data.MakeInParam("@linkman",  MySqlDbType.VarChar, 10, units.LinkMan),
                						data.MakeInParam("@address",  MySqlDbType.VarChar, 60, units.Address),
                						data.MakeInParam("@accounts",  MySqlDbType.VarChar, 80, units.Accounts),
			};
            return (data.RunProc("update tb_units set fullname=@fullname,tax=@tax,tel=@tel,linkman=@linkman,address=@address,accounts=@accounts where unitcode=@unitcode", prams));
        }
        #endregion

        #region 删除--往来单位信息
        /// <summary>
        /// 删除往来单位
        /// </summary>
        /// <param name="client"></param>
        /// <returns>返回往来单位id</returns>
        public int DeleteUnits(cUnitsInfo units)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@unitcode",  MySqlDbType.VarChar, 5, units.UnitCode),
			};
            return (data.RunProc("delete from tb_units where unitcode=@unitcode", prams));
        }
        #endregion

        #region 查询--往来单位信息
        /// <summary>
        /// 根据--单位编号--得到往来单位信息
        /// </summary>
        /// <param name="units"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindUnitsByUnitCode(cUnitsInfo units, string tbName)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@unitcode",  MySqlDbType.VarChar, 5, units.UnitCode+"%"),
			};
            return (data.RunProcReturn("select * from tb_units where unitcode like @unitcode", prams, tbName));
        }
        /// <summary>
        /// 根据--单位名称--得到往来单位信息
        /// </summary>
        /// <param name="units"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindUnitsByFullName(cUnitsInfo units, string tbName)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@fullname",  MySqlDbType.VarChar, 30, units.FullName+"%"),
			};
            return (data.RunProcReturn("select * from tb_units where fullname like @fullname", prams, tbName));
        }
        /// <summary>
        /// 得到所有--往来单位信息
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetAllUnits(string tbName)
        {
            return (data.RunProcReturn("select * from tb_units ORDER BY unitcode", tbName));
        }
        #endregion


        #region 添加--库存商品信息
        /// <summary>
        /// 添加库存商品基本信息
        /// </summary>
        /// <param name="stock">库存商品数据结构类对象</param>
        /// <returns></returns>
        public int AddStock(cStockInfo stock)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  MySqlDbType.VarChar, 5, stock.TradeCode),
                						data.MakeInParam("@fullname",  MySqlDbType.VarChar, 30,stock.FullName),
                						data.MakeInParam("@type",  MySqlDbType.VarChar, 10, stock.TradeType),
                						data.MakeInParam("@standard",  MySqlDbType.VarChar, 10, stock.Standard),
                						data.MakeInParam("@unit",  MySqlDbType.VarChar, 4, stock.Unit),
                						data.MakeInParam("@produce",  MySqlDbType.VarChar, 20, stock.Produce),
			};
            return (data.RunProc("INSERT INTO tb_stock (tradecode, fullname, type, standard, unit, produce) VALUES (@tradecode,@fullname,@type,@standard,@unit,@produce)", prams));
        }
        #endregion

        #region 修改--库存商品信息
        /// <summary>
        /// 修改库存商品信息
        /// </summary>
        /// <param name="stock">库存商品数据结构类对象</param>
        /// <returns></returns>
        public int UpdateStock(cStockInfo stock)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  MySqlDbType.VarChar, 5, stock.TradeCode),
                						data.MakeInParam("@fullname",  MySqlDbType.VarChar, 30,stock.FullName),
                						data.MakeInParam("@type",  MySqlDbType.VarChar, 10, stock.TradeType),
                						data.MakeInParam("@standard",  MySqlDbType.VarChar, 10, stock.Standard),
                						data.MakeInParam("@unit",  MySqlDbType.VarChar, 4, stock.Unit),
                						data.MakeInParam("@produce",  MySqlDbType.VarChar, 20, stock.Produce),
			};
            return (data.RunProc("update tb_stock set fullname=@fullname,type=@type,standard=@standard,unit=@unit,produce=@produce where tradecode=@tradecode", prams));
        }
        #endregion

        #region 删除--库存商品信息
        /// <summary>
        /// 删除库存商品信息
        /// </summary>
        /// <param name="stock">库存商品数据结构类对象</param>
        /// <returns></returns>
        public int DeleteStock(cStockInfo stock)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  MySqlDbType.VarChar, 5, stock.TradeCode),
			};
            return (data.RunProc("delete from tb_stock where tradecode=@tradecode", prams));
        }
        #endregion

        #region 查询--往来单位信息
        /// <summary>
        /// 根据--商品产地--得到库存商品信息
        /// </summary>
        /// <param name="stock">库存商品数据结构类对象</param>
        /// <param name="tbName">映射原表名称</param>
        /// <returns></returns>
        public DataSet FindStockByProduce(cStockInfo stock, string tbName)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@produce",  MySqlDbType.VarChar, 5, stock.Produce+"%"),
			};
            return (data.RunProcReturn("select * from tb_stock where produce like @produce", prams, tbName));
        }
        /// <summary>
        /// 根据--商品名称--得到库存商品信息
        /// </summary>
        /// <param name="units"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindStockByFullName(cStockInfo stock, string tbName)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@fullname",  MySqlDbType.VarChar, 30, stock.FullName+"%"),
			};
            return (data.RunProcReturn("select * from tb_stock where fullname like @fullname", prams, tbName));
        }
        /// <summary>
        /// 得到所有--库存商品信息
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetAllStock(string tbName)
        {
            return (data.RunProcReturn("select * from tb_Stock", tbName));
        }
        #endregion

        #region 添加--公司职员信息
        /// <summary>
        /// 添加--公司职员--信息
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public int AddEmployee(cEmployeeInfo employee)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@employeecode",  MySqlDbType.VarChar, 5, employee.EmployeeCode),
                						data.MakeInParam("@fullname",  MySqlDbType.VarChar, 20,employee.FullName),
                						data.MakeInParam("@sex",  MySqlDbType.VarChar, 4, employee.Sex),
                						data.MakeInParam("@dept",  MySqlDbType.VarChar, 20, employee.Dept),
                						data.MakeInParam("@tel",  MySqlDbType.VarChar, 20, employee.Tel),
                						data.MakeInParam("@memo",  MySqlDbType.VarChar, 20, employee.Memo),
			};
            return (data.RunProc("INSERT INTO tb_Employee (employeecode, fullname, sex, dept, tel, memo) VALUES (@employeecode,@fullname,@sex,@dept,@tel,@memo)", prams));
        }
        #endregion

        #region 修改--公司职员信息
        /// <summary>
        /// 修改--公司职员--信息
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
        public int UpdateEmployee(cEmployeeInfo employee)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@employeecode",  MySqlDbType.VarChar, 5, employee.EmployeeCode),
                						data.MakeInParam("@fullname",  MySqlDbType.VarChar, 20,employee.FullName),
                						data.MakeInParam("@sex",  MySqlDbType.VarChar, 4, employee.Sex),
                						data.MakeInParam("@dept",  MySqlDbType.VarChar, 20, employee.Dept),
                						data.MakeInParam("@tel",  MySqlDbType.VarChar, 20, employee.Tel),
                						data.MakeInParam("@memo",  MySqlDbType.VarChar, 20, employee.Memo),
			};
            return (data.RunProc("update tb_Employee set fullname=@fullname,sex=@sex,dept=@dept,tel=@tel,memo=@memo where employeecode=@employeecode", prams));
        }
        #endregion

        #region 删除--公司职员信息
        /// <summary>
        /// 删除--公司职员--信息
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public int DeleteEmployee(cEmployeeInfo employee)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@employeecode",  MySqlDbType.VarChar, 5, employee.EmployeeCode),
			};
            return (data.RunProc("delete from tb_employee where employeecode=@employeecode", prams));
        }
        #endregion

        #region 查询--公司职员信息
        /// <summary>
        /// 根据--职员所在部门--得到公司职员信息
        /// </summary>
        /// <param name="units"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindEmployeeByDept(cEmployeeInfo employee, string tbName)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@dept",  MySqlDbType.VarChar, 20, employee.Dept+"%"),
			};
            return (data.RunProcReturn("select * from tb_employee where dept like @dept", prams, tbName));
        }
        /// <summary>
        /// 根据--职员姓名--得到公司职员信息
        /// </summary>
        /// <param name="units"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindEmployeeByFullName(cEmployeeInfo employee, string tbName)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@fullname",  MySqlDbType.VarChar, 20, employee.FullName+"%"),
			};
            return (data.RunProcReturn("select * from tb_employee where fullname like @fullname", prams, tbName));
        }
        /// <summary>
        /// 得到所有--公司职员信息
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetAllEmployee(string tbName)
        {
            return (data.RunProcReturn("select * from tb_Employee ORDER BY employeecode", tbName));
        }
        #endregion


        #region 商品进销存---单据过账
        /// <summary>
        /// 得到所有销售订单列表
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetSaleList(string tbName)
        {
            return (data.RunProcReturn("select * from tb_orders", tbName));
        }
        /// <summary>
        /// 通过指定的字段以及字段值获取表特定字段数据，不保证安全
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetTableDateByFiled(string tbName, string tbFiled, string filedValue, string needFiled)
        {
            string cmd = "select "+ needFiled +" from " + tbName + " where " + tbFiled + "=\'" + filedValue + "\'";
            return (data.RunProcReturn(cmd, tbName));
        }        
        /// <summary>
        /// 通过指定的字段以及字段值获取表所有数据，不保证安全
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetTableDateByFiled(string tbName, string tbFiled, string filedValue)
        {
            string cmd = "select * from " + tbName + " where " + tbFiled + "=\'" + filedValue + "\'";
            return (data.RunProcReturn(cmd, tbName));
        }
        /// <summary>
        /// 通过表名获取所有信息，不保证安全
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetTableAllDataByName(string tbName)
        {
            string cmd = "select * from " + tbName;
            return (data.RunProcReturn(cmd, tbName));          
        }
        /// <summary>
        /// 通过表名修改单据状态，不安全
        /// </summary>
        /// <param name="stock">库存商品数据结构类对象</param>
        /// <returns></returns>
        public int UpdateTableStatu(string tbName, string statu)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  MySqlDbType.VarChar, 255, tbName),
			};
            string cmd = "update " + tbName + " set statu=\'" + statu + "\'";
            return (data.RunProc(cmd, prams));
        }
        /// <summary>
        /// 得到销售订单所有明细列表
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetSaleDetailList(string tbName)
        {
            return (data.RunProcReturn("select * from tb_orders_detailed", tbName));
        }

        public DataSet GetSaleDetailList(string tbName, string tbSaleCode)
        {
            string cmd = "select * from tb_orders_detailed where orders_id=" +"\'" + tbSaleCode + "\'";
            return (data.RunProcReturn(cmd, tbName));
        }
        /// <summary>
        /// 得到采购订单所有明细列表
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetPurchaseList(string tbName)
        {
            return (data.RunProcReturn("select * from tb_purchase", tbName));
        }
        public DataSet GetPurchaseDetailList(string tbName)
        {
            return (data.RunProcReturn("select * from tb_purchase_detail", tbName));
        }
        public DataSet GetPurchaseDetailList(string tbName, string tbPurchaseCode)
        {
            string cmd = "select * from tb_purchase_detail where purchase_code=" + "\'" + tbPurchaseCode + "\'";
            return (data.RunProcReturn(cmd, tbName));
        }
        /// <summary>
        /// 得到所有tbName表中信息－－主要用来：得到最大的单据编号然后自动编号
        /// </summary>
        /// <param name="tbName">数据表名称</param>
        /// <returns></returns>
        public DataSet GetAllBill(string tbName_trueName)
        {
            return (data.RunProcReturn("select * from " + tbName_trueName + "", tbName_trueName));
        }
        /// <summary>
        /// 处理进货单和销售退货单-数据---向主表中添加数据
        /// </summary>
        /// <param name="billinfo">过账单据数据结构类对象</param>
        /// <param name="AddTableName_trueName">数据库中数据表名称</param>
        /// <returns></returns>
        public int AddTableMainWarehouse(cBillInfo billinfo, string AddTableName_trueName)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@billdate",  MySqlDbType.DateTime, 8, billinfo.BillDate),
                						data.MakeInParam("@billcode",  MySqlDbType.VarChar, 20,billinfo.BillCode),
                						//data.MakeInParam("@units",  MySqlDbType.VarChar, 30, billinfo.Units),
                						//data.MakeInParam("@handle",  MySqlDbType.VarChar, 10, billinfo.Handle),
                						//data.MakeInParam("@summary",  MySqlDbType.VarChar, 100, billinfo.Summary),
                						//data.MakeInParam("@fullpayment",  MySqlDbType.Float, 8, billinfo.FullPayment),
                                        //data.MakeInParam("@payment",  MySqlDbType.Float, 8, billinfo.Payment),
			};
            return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (billdate, billcode, units, handle, summary, fullpayment,payment) VALUES (@billdate,@billcode,@units,@handle,@summary,@fullpayment,@payment)", prams));
        }
        /// <summary>
        /// 处理进货退货单和销售单-数据---向主表中添加数据
        /// </summary>
        /// <param name="billinfo">过账单据数据结构类对象</param>
        /// <param name="AddTableName_trueName">数据库中数据表名称</param>
        /// <returns></returns>
        public int AddTableMainSellhouse(cBillInfo billinfo, string AddTableName_trueName)
        {
            if (AddTableName_trueName == "tb_orders")
            {
                MySqlParameter[] prams = {
                                        data.MakeInParam("@billcode",  MySqlDbType.VarChar, 20,billinfo.BillCode),
                                        data.MakeInParam("@customerid", MySqlDbType.VarChar, 20,billinfo.CustomerCode),
                                        data.MakeInParam("@staffid",    MySqlDbType.VarChar, 20,billinfo.SalesPersonCode),
                                        data.MakeInParam("@customername",    MySqlDbType.VarChar, 20,billinfo.CustomerName),
                                        data.MakeInParam("@customertel",    MySqlDbType.VarChar, 32,billinfo.CustomerTEL),
                                        data.MakeInParam("@customeraddress",    MySqlDbType.VarChar, 32,billinfo.CustomerAddress),
                                        data.MakeInParam("@orderdate", MySqlDbType.DateTime, 8, billinfo.orderDate),
									    data.MakeInParam("@billdate",  MySqlDbType.DateTime, 8, billinfo.BillDate),
                                        data.MakeInParam("@goodscount", MySqlDbType.Int32, 32, billinfo.Qty),
                                        data.MakeInParam("@fullpayment",  MySqlDbType.Float, 8, billinfo.OrderTotalPayment),
			    };
                return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (id, customer_id, saler_id, customer_name, customer_tel, customer_address,order_date,bile_date,goods_count,total_pay) VALUES (@billcode,@customerid,@staffid,@customername,@customertel,@customeraddress,@orderdate,@billdate,@goodscount,@fullpayment)", prams));
            }
            else 
            {
                MySqlParameter[] prams = {
									    data.MakeInParam("@billdate",  MySqlDbType.DateTime, 8, billinfo.BillDate),
                						data.MakeInParam("@billcode",  MySqlDbType.VarChar, 20,billinfo.BillCode),
                                        data.MakeInParam("@orderdate", MySqlDbType.DateTime, 8, billinfo.orderDate),
                                        data.MakeInParam("@customerid", MySqlDbType.VarChar, 20,billinfo.CustomerCode),
                                        data.MakeInParam("@staffid",    MySqlDbType.VarChar, 20,billinfo.SalesPersonCode),
                                        data.MakeInParam("@customername",    MySqlDbType.VarChar, 20,billinfo.CustomerName),
                                        data.MakeInParam("@customeraddress",    MySqlDbType.VarChar, 32,billinfo.CustomerAddress),
                                        data.MakeInParam("@customertel",    MySqlDbType.VarChar, 32,billinfo.CustomerTEL),
                                        data.MakeInParam("@goodscount", MySqlDbType.Int32, 32, billinfo.Qty),
                                        data.MakeInParam("@fullpayment",  MySqlDbType.Float, 8, billinfo.OrderTotalPayment),
			    };
                return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (billdate, billcode, units, handle, summary, fullgathering,gathering) VALUES (@billdate,@billcode,@units,@handle,@summary,@fullpayment,@payment)", prams));
                        
            }
        }
        /// <summary>
        /// 采购--向主表中添加数据
        /// </summary>
        /// <param name="billinfo">过账单据数据结构类对象</param>
        /// <param name="AddTableName_trueName">数据库中数据表名称</param>
        /// <returns></returns>
        public int AddTablePurchase(cPurchaseBill billinfo, string AddTableName_trueName)
        {
                MySqlParameter[] prams = 
                {
                        data.MakeInParam("@number",  MySqlDbType.VarChar, 255,billinfo.BillCode),
                        data.MakeInParam("@supplier_number", MySqlDbType.VarChar, 255,billinfo.SupplierCode),
                        data.MakeInParam("@employee_number",    MySqlDbType.VarChar, 255,billinfo.BuyerCode),
                        data.MakeInParam("@order_date",    MySqlDbType.DateTime, 255,billinfo.orderDate),
                        data.MakeInParam("@recive_date",    MySqlDbType.DateTime, 255,billinfo.DeadLine),
                        data.MakeInParam("@totalpay",    MySqlDbType.Float, 255,billinfo.TotalPayment),
                        data.MakeInParam("@statu",  MySqlDbType.VarChar, 255, billinfo.Status),
			    };
                return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (number,supplier_number,employee_number,order_date,recive_date,totalpay,statu) VALUES (@number,@supplier_number,@employee_number,@order_date,@recive_date,@totalpay,@statu)", prams));            
        }

        /// <summary>
        /// 采购--向明细表中添加数据
        /// </summary>
        /// <param name="billinfo">过账单据数据结构类对象</param>
        /// <param name="AddTableName_trueName">数据库中数据表名称</param>
        /// <returns></returns>
        public int AddTablePurchaseDetail(cPurchaseBill billinfo, string AddTableName_trueName)
        {
            MySqlParameter[] prams = 
                {
                        data.MakeInParam("@serial_number",  MySqlDbType.VarChar, 255,billinfo.SerialNumber),
                        data.MakeInParam("@detail_number", MySqlDbType.VarChar, 255,billinfo.PurchaseDetaildCode),
                        data.MakeInParam("@purchase_number",    MySqlDbType.VarChar, 255,billinfo.BillCode),
                        data.MakeInParam("@goods_number",    MySqlDbType.VarChar, 255,billinfo.goodsCode),
                        data.MakeInParam("@goods_qty", MySqlDbType.Float, 32, billinfo.Qty),
                        data.MakeInParam("@goods_price",    MySqlDbType.Float, 32,billinfo.goodsPrice),
                        data.MakeInParam("@goods_uint",    MySqlDbType.VarChar, 255,billinfo.goodsUnit),
			    };
            return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (serial_number,detail_number,purchase_number,goods_number,goods_qty,goods_price,goods_uint) VALUES (@serial_number,@detail_number,@purchase_number,@goods_number,@goods_qty,@goods_price,@goods_uint)", prams));
        }
        /// <summary>
        /// 入库--向主表中添加数据
        /// </summary>
        /// <param name="billinfo">过账单据数据结构类对象</param>
        /// <param name="AddTableName_trueName">数据库中数据表名称</param>
        /// <returns></returns>
        public int AddTableEntryStock(cStockBill billinfo, string AddTableName_trueName)
        {
            MySqlParameter[] prams = 
                {
                        data.MakeInParam("@entry_code",  MySqlDbType.VarChar, 255,billinfo.EnOutCode),
                        data.MakeInParam("@purchase_code", MySqlDbType.VarChar, 255,billinfo.PurchaseCode),
                        data.MakeInParam("@goods_count",    MySqlDbType.Int32, 32,billinfo.GoodsCount),
                        data.MakeInParam("@supplier_code",    MySqlDbType.VarChar, 255,billinfo.SupplierCode),
                        data.MakeInParam("@clerk_code",    MySqlDbType.VarChar, 255,billinfo.StaffCode),
                        data.MakeInParam("@clerk_name",    MySqlDbType.VarChar, 255,billinfo.StaffName),
                        data.MakeInParam("@entry_date",    MySqlDbType.DateTime, 255,billinfo.BillDate),
			    };
            return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (entry_code, purchase_code, goods_count, supplier_code,clerk_code, clerk_name, entry_date) VALUES (@entry_code, @purchase_code, @goods_count, @supplier_code,@clerk_code, @clerk_name, @out_date)", prams));
        }
        /// <summary>
        /// 入库-向明细表中添加数据
        /// </summary>
        /// <param name="billinfo">过账单据数据结构类对象</param>
        /// <param name="AddTableName_trueName">数据库中数据表名称</param>
        /// <returns></returns>
        public int AddTableEntryStockDetail(cStockBill billinfo, string AddTableName_trueName)
        {
            MySqlParameter[] prams = 
                    {
                            data.MakeInParam("@entry_detail_code",  MySqlDbType.VarChar, 255,billinfo.EnOutDetailCode),
                            data.MakeInParam("@entry_code", MySqlDbType.VarChar, 255,billinfo.EnOutCode),
                            data.MakeInParam("@goods_code",    MySqlDbType.VarChar, 255,billinfo.GoodCode),
                            data.MakeInParam("@goods_name",    MySqlDbType.VarChar, 255,billinfo.GoodsName),
                            data.MakeInParam("@goods_uint",    MySqlDbType.VarChar, 255,billinfo.GoodsUint),
                            data.MakeInParam("@goods_price",    MySqlDbType.Float, 32,billinfo.GoodsPrice),
                            data.MakeInParam("@goods_qty", MySqlDbType.Float, 32, billinfo.Qty),
                            data.MakeInParam("@goods_total_price",  MySqlDbType.Float, 32, billinfo.GoodsTotalPrice),
                    };
            return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (entry_detail_code, entry_code, goods_code, goods_name, goods_uint, goods_price,goods_qty,goods_total_price) VALUES (@entry_detail_code, @entry_code, @goods_code, @goods_name, @goods_uint, @goods_price,@goods_qty,@goods_total_price)", prams));
        }

        /// <summary>
        /// 出库--向主表中添加数据
        /// </summary>
        /// <param name="billinfo">过账单据数据结构类对象</param>
        /// <param name="AddTableName_trueName">数据库中数据表名称</param>
        /// <returns></returns>
        public int AddTableOutStock(cStockBill billinfo, string AddTableName_trueName)
        {
            MySqlParameter[] prams = 
                {
                        data.MakeInParam("@out_code",  MySqlDbType.VarChar, 255,billinfo.EnOutCode),
                        data.MakeInParam("@orders_code", MySqlDbType.VarChar, 255,billinfo.OrdersCode),
                        data.MakeInParam("@goods_count",    MySqlDbType.Int32, 32,billinfo.GoodsCount),
                        data.MakeInParam("@clerk_code",    MySqlDbType.VarChar, 255,billinfo.StaffCode),
                        data.MakeInParam("@clerk_name",    MySqlDbType.VarChar, 255,billinfo.StaffName),
                        data.MakeInParam("@out_date",    MySqlDbType.DateTime, 255,billinfo.BillDate),
			    };
            return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (out_code, orders_code, goods_count, clerk_code, clerk_name, out_date) VALUES (@out_code, @orders_code, @goods_count, @clerk_code, @clerk_name, @out_date)", prams));
        }

        /// <summary>
        /// 出库-向明细表中添加数据
        /// </summary>
        /// <param name="billinfo">过账单据数据结构类对象</param>
        /// <param name="AddTableName_trueName">数据库中数据表名称</param>
        /// <returns></returns>
        public int AddTableOutStockDetail(cStockBill billinfo, string AddTableName_trueName)
        {
                MySqlParameter[] prams = 
                    {
                            data.MakeInParam("@out_detail_code",  MySqlDbType.VarChar, 255,billinfo.EnOutDetailCode),
                            data.MakeInParam("@out_code", MySqlDbType.VarChar, 255,billinfo.EnOutCode),
                            data.MakeInParam("@goods_code",    MySqlDbType.VarChar, 255,billinfo.GoodCode),
                            data.MakeInParam("@goods_name",    MySqlDbType.VarChar, 255,billinfo.GoodsName),
                            data.MakeInParam("@goods_uint",    MySqlDbType.VarChar, 255,billinfo.GoodsUint),
                            data.MakeInParam("@goods_price",    MySqlDbType.Float, 32,billinfo.GoodsPrice),
                            data.MakeInParam("@goods_qty", MySqlDbType.Float, 32, billinfo.Qty),
                            data.MakeInParam("@goods_total_price",  MySqlDbType.Float, 32, billinfo.GoodsTotalPrice),
                    };
                return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (out_detail_code, out_code, goods_code, goods_name, goods_uint, goods_price,goods_qty,goods_total_price) VALUES (@out_detail_code, @out_code, @goods_code, @goods_name, @goods_uint, @goods_price,@goods_qty,@goods_total_price)", prams));
      }
        /// <summary>
        /// 向明细表中添加数据－进货单－销售退货单－销售单－进货退货单
        /// </summary>
        /// <param name="billinfo">过账单据数据结构类对象</param>
        /// <param name="AddTableName_trueName">数据库中数据表名称</param>
        /// <returns></returns>
        public int AddTableDetailedWarehouse(cBillInfo billinfo, string AddTableName_trueName)
        {
            if ("tb_orders_detailed" == AddTableName_trueName)
            {
                MySqlParameter[] prams = {
                                        data.MakeInParam("@orderdetailcode",MySqlDbType.VarChar, 20,billinfo.orderDetaildCode),
									    data.MakeInParam("@billcode",  MySqlDbType.VarChar, 20, billinfo.BillCode),
                                        data.MakeInParam("@goodscode", MySqlDbType.VarChar, 32, billinfo.goodsCode),
                                        data.MakeInParam("@goodsname",MySqlDbType.VarChar, 32, billinfo.goodsName),
                                        data.MakeInParam("@goodsunit", MySqlDbType.VarChar, 32, billinfo.goodsUnit),
                                        data.MakeInParam("@goodsprice", MySqlDbType.Float, 32, billinfo.goodsPrice),
                                        data.MakeInParam("@goodsqty", MySqlDbType.Float, 32, billinfo.Qty),

            };
                return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (id, orders_id, goods_id, goods_name, goods_uint, goods_price,goods_qty) VALUES (@orderdetailcode,@billcode,@goodscode,@goodsname,@goodsunit,@goodsprice,@goodsqty)", prams));
       
            }
            else
            {
                MySqlParameter[] prams = {
									    data.MakeInParam("@billcode",  MySqlDbType.VarChar, 20, billinfo.BillCode),
                						//data.MakeInParam("@tradecode",  MySqlDbType.VarChar, 20,billinfo.TradeCode),
                						//data.MakeInParam("@fullname",  MySqlDbType.VarChar, 20, billinfo.FullName),
                						//data.MakeInParam("@unit",  MySqlDbType.VarChar, 10, billinfo.TradeUnit),
                						//data.MakeInParam("@qty",  MySqlDbType.Float, 8, billinfo.Qty),
                						//data.MakeInParam("@price",  MySqlDbType.Float, 8, billinfo.Price),
                                        //data.MakeInParam("@tsum",  MySqlDbType.Float, 8, billinfo.TSum),
                                        //data.MakeInParam("@billdate",  MySqlDbType.DateTime, 8, billinfo.BillDate),

            };
                return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (billcode, tradecode, fullname, unit, qty, price,tsum,billdate) VALUES (@billcode,@tradecode,@fullname,@unit,@qty,@price,@tsum,@billdate)", prams));
                   
            }
            }
        /// <summary>
        /// 修改库存数量和加权平均价格
        /// </summary>
        /// <param name="stock">库存商品数据结构类对象</param>
        /// <returns></returns>
        public int UpdateStock_QtyAndAveragerprice(cStockInfo stock)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  MySqlDbType.VarChar, 5, stock.TradeCode),
                						data.MakeInParam("@qty",  MySqlDbType.Float, 30,stock.Qty),
                                        data.MakeInParam("@price",  MySqlDbType.Float, 30,stock.Price),
                						data.MakeInParam("@averageprice",  MySqlDbType.Float, 10, stock.AveragePrice),
			};
            return (data.RunProc("update tb_stock set qty=@qty,price=@averageprice,averageprice=@averageprice where goods_id=@tradecode", prams));
        }
        /// <summary>
        /// 修改销售商品和进货退货商品--后的库存商品数量
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public int UpdateSaleStock_Qty(cStockInfo stock)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  MySqlDbType.VarChar, 5, stock.TradeCode),
                						data.MakeInParam("@qty",  MySqlDbType.Float, 30,stock.Qty),
			};
            return (data.RunProc("update tb_stock set qty=@qty where goods_id=@tradecode", prams));
        }
        /// <summary>
        /// 修改库存数量和销售（和进货退货）最后一次价格
        /// </summary>
        /// <param name="stock">库存商品数据结构类对象</param>
        /// <returns></returns>
        public int UpdateStock_Qty(cStockInfo stock)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  MySqlDbType.VarChar, 5, stock.TradeCode),
                						data.MakeInParam("@qty",  MySqlDbType.Float, 30,stock.Qty),
                                        data.MakeInParam("@price",  MySqlDbType.Float, 30,stock.SalePrice),
			};
            return (data.RunProc("update tb_stock set qty=@qty,saleprice=@price where goods_id=@tradecode", prams));
        }
        /// <summary>
        /// 根据商品编号TradeCode,主要得到数量和加权平均价格，用于对其更新。
        /// </summary>
        /// <param name="stock">库存商品数据结构类对象</param>
        /// <param name="tbName">映射虚拟表名称</param>
        /// <returns></returns>
        public DataSet GetStockByTradeCode(cStockInfo stock, string tbName)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@tradecode",MySqlDbType.VarChar, 30, stock.TradeCode),
			};
            return (data.RunProcReturn("select * from tb_stock where goods_id like @tradecode", prams, tbName));
        }
        #endregion

        #region 商品进销存---往来账明细表
        /// <summary>
        /// 添加数据---往来账本明细表
        /// </summary>
        /// <param name="currentAccount"></param>
        /// <returns></returns>
#if false
        public int AddCurrentAccount(cCurrentAccount currentAccount)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@billdate",  MySqlDbType.DateTime, 8, currentAccount.BillDate),
                						data.MakeInParam("@billcode",  MySqlDbType.VarChar, 20,currentAccount.BillCode),
                						data.MakeInParam("@addgathering",  MySqlDbType.Float, 8, currentAccount.AddGathering),
                						data.MakeInParam("@factaddfee",  MySqlDbType.Float, 8,currentAccount.FactAddFee),
                						data.MakeInParam("@reducegathering",  MySqlDbType.Float, 8,currentAccount.ReduceGathering),
                						data.MakeInParam("@factfee",  MySqlDbType.Float, 8, currentAccount.FactReduceGathering),
                                        data.MakeInParam("@balance",  MySqlDbType.Float, 8, currentAccount.Balance),
                                        data.MakeInParam("@units",  MySqlDbType.VarChar, 20,currentAccount.Units),
			};
            return (data.RunProc("INSERT INTO tb_currentaccount (billdate, billcode, addgathering, factaddfee, reducegathering, factfee,balance,units) VALUES (@billdate,@billcode,@addgathering,@factaddfee,@reducegathering,@factfee,@balance,@units)", prams));
        }
#endif
        #endregion


        #region 进货管理--进货分析
        /// <summary>
        /// 商品进货分析--不含进货退货
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet BuyStockAnalyse(string tbName)
        {
            return (data.RunProcReturn("SELECT a.tradecode, a.fullname, a.averageprice as price, b.qty, b.tsum FROM tb_stock a INNER JOIN (SELECT SUM(qty) AS qty, SUM(tsum) AS tsum, fullname FROM tb_rewarehouse_detailed GROUP BY fullname) b ON a.fullname = b.fullname WHERE (a.price > 0)", tbName));
        }

        /// <summary>
        /// 商品进货分析（含退货）
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet BuyAllStockAnalyse(string tbName)
        {
            return (data.RunProcReturn("select tradecode,fullname,AVG(price) AS price,sum(qty) as qty,sum(tsum) as tsum from tb_warehouse_detailed group by tradecode,fullname", tbName));
        }
        #endregion

        #region  进货管理--进货统计
        /// <summary>
        /// 进货商品－－详细统计
        /// </summary>
        /// <param name="billinfo"></param>
        /// <param name="tbName"></param>
        /// <param name="starDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public DataSet BuyStockSumDetailed(cBillInfo billinfo, string tbName, DateTime starDateTime, DateTime endDateTime)
        {
            MySqlParameter[] prams = {
                						//data.MakeInParam("@units",  MySqlDbType.VarChar, 30, "%"+billinfo.Units+"%"),
                						//data.MakeInParam("@handle",  MySqlDbType.VarChar, 10,"%"+ billinfo.Handle+"%"),
			};
            return (data.RunProcReturn("SELECT b.tradecode AS 商品编号, b.fullname AS 商品名称, SUM(b.qty) AS 进货数量,SUM(b.tsum) AS 进货金额 FROM tb_purchase a INNER JOIN (SELECT billcode, tradecode, fullname, SUM(qty) AS qty, SUM(tsum) AS tsum FROM tb_warehouse_detailed GROUP BY tradecode, billcode, fullname) b ON a.billcode = b.billcode AND a.units LIKE @units AND a.handle LIKE @handle WHERE (a.billdate BETWEEN '" + starDateTime + "' AND '" + endDateTime + "') GROUP BY b.tradecode, b.fullname", prams, tbName));
        }
        /// <summary>
        /// 进货商品－－统计所有
        /// </summary>
        /// <param name="billinfo"></param>
        /// <param name="tbName"></param>
        /// <param name="starDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public DataSet BuyStockSum(string tbName)
        {
            return (data.RunProcReturn("select tradecode as 商品编号,fullname as 商品名称,sum(qty) as 进货数量,sum(tsum)as 进货金额 from tb_warehouse_detailed group by tradecode, fullname", tbName));
        }
        #endregion


        #region  销售管理--销售统计
        /// <summary>
        /// 销售商品－－详细统计
        /// </summary>
        /// <param name="billinfo"></param>
        /// <param name="tbName"></param>
        /// <param name="starDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public DataSet SellStockSumDetailed(cBillInfo billinfo, string tbName, DateTime starDateTime, DateTime endDateTime)
        {
            MySqlParameter[] prams = {
                						//data.MakeInParam("@units",  MySqlDbType.VarChar, 30,"%"+ billinfo.Units+"%"),
                						//data.MakeInParam("@handle",  MySqlDbType.VarChar, 10,"%"+ billinfo.Handle+"%"),
			};
            return (data.RunProcReturn("SELECT b.tradecode AS 商品编号, b.fullname AS 商品名称, SUM(b.qty) AS 销售数量,SUM(b.tsum) AS 销售金额 FROM tb_orders a INNER JOIN (SELECT billcode, tradecode, fullname, SUM(qty) AS qty, SUM(tsum) AS tsum FROM tb_orders_detailed GROUP BY tradecode, billcode, fullname) b ON a.billcode = b.billcode AND a.units LIKE @units AND a.handle LIKE @units WHERE (a.billdate BETWEEN '" + starDateTime + "' AND '" + endDateTime + "') GROUP BY b.tradecode, b.fullname", prams, tbName));
        }
        /// <summary>
        /// 销售商品－－统计所有
        /// </summary>
        /// <param name="billinfo"></param>
        /// <param name="tbName"></param>
        /// <param name="starDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public DataSet SellStockSum(string tbName)
        {
            return (data.RunProcReturn("select tradecode as 商品编号,fullname as 商品名称,sum(qty) as 销售数量,sum(tsum) as 销售金额 from tb_orders_detailed group by tradecode, fullname", tbName));
        }
        #endregion

        #region 销售管理--月销售状况
        /// <summary>
        /// 统计商品销售状况
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet SellStockStatusSum(string tbName)
        {
            return (data.RunProcReturn("select a.tradecode as 商品编号,a.fullname as 商品名称,a.qty as 销售数量,a.price AS 销售均价,a.tsum as 销售金额,b.qty2 as '退货数量',b.tsum2 as '退货金额' from (SELECT tradecode,fullname,avg(price)as price,sum(qty) AS qty, sum(tsum) as tsum from tb_orders_detailed group by tradecode,fullname) a left join (SELECT tradecode,fullname,sum(qty) AS qty2, sum(tsum) as tsum2 from tb_resell_detailed group by tradecode,fullname) b on a.tradecode=b.tradecode ", tbName));
        }

        /// <summary>
        /// 明细账本－－－‘商品销售’和‘商品销售退货’
        /// </summary>
        /// <param name="strTradeCode"></param>
        /// <param name="starDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet SellStockDetailed(string strTradeCode, DateTime starDateTime, DateTime endDateTime, string tbName)
        {
            return (data.RunProcReturn("SELECT billdate as 销售日期, billcode as 单据编号, tradecode as 商品编号, fullname as 商品名称, price as 销售价格, qty as 销售数量, tsum as 销售金额 FROM " + tbName + " where tradecode = '" + strTradeCode + "' AND billdate BETWEEN '" + starDateTime + "' AND '" + endDateTime + "'", tbName));
        }
        #endregion

        #region 销售管理--商品销售排行
        /// <summary>
        /// 设置排行榜条件－－往来单位-下拉列表
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet SetUnitsList(string tbName)
        {
            return (data.RunProcReturn("select * from tb_units", tbName));
        }
        /// <summary>
        /// 设置排行榜条件－－经手人-下拉列表
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet SetHandleList(string tbName)
        {
            return (data.RunProcReturn("select * from tb_employee", tbName));
        }
        /// <summary>
        /// 按销售金额排行
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="units"></param>
        /// <param name="StarDateTime"></param>
        /// <param name="EndDateTime"></param>
        /// <returns></returns>
        public DataSet GetTSumDesc(string handle, string units, DateTime StarDateTime, DateTime EndDateTime, string tbName)
        {
            return (data.RunProcReturn("SELECT * FROM (SELECT b.tradecode AS 商品编号, b.fullname AS 商品名称, SUM(b.qty) AS 销售数量, SUM(b.tsum) AS 销售金额 FROM tb_orders a INNER JOIN (SELECT billcode, tradecode, fullname, SUM(qty) AS qty, SUM(tsum) AS tsum FROM tb_orders_detailed GROUP BY tradecode, billcode, fullname) b ON a.billcode = b.billcode AND a.units LIKE '%" + units + "%' AND a.handle LIKE '%" + handle + "%' WHERE (a.billdate BETWEEN '" + StarDateTime + "' AND '" + EndDateTime + "')GROUP BY b.tradecode, b.fullname) DERIVEDTBL ORDER BY 销售金额 DESC", tbName));
        }
        /// <summary>
        /// 按销售数量排行
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="units"></param>
        /// <param name="StarDateTime"></param>
        /// <param name="EndDateTime"></param>
        /// <returns></returns>
        public DataSet GetQtyDesc(string handle, string units, DateTime StarDateTime, DateTime EndDateTime, string tbName)
        {
            return (data.RunProcReturn("SELECT * FROM (SELECT b.tradecode AS 商品编号, b.fullname AS 商品名称, SUM(b.qty) AS 销售数量, SUM(b.tsum) AS 销售金额 FROM tb_orders a INNER JOIN (SELECT billcode, tradecode, fullname, SUM(qty) AS qty, SUM(tsum) AS tsum FROM tb_orders_detailed GROUP BY tradecode, billcode, fullname) b ON a.billcode = b.billcode AND a.units LIKE '%" + units + "%' AND a.handle LIKE '%" + handle + "%' WHERE (a.billdate BETWEEN '" + StarDateTime + "' AND '" + EndDateTime + "')GROUP BY b.tradecode, b.fullname) DERIVEDTBL ORDER BY 销售数量 DESC", tbName));
        }
        #endregion

        #region 销售管理--商品销售成本明细
        /// <summary>
        /// 根据单据编号--得到销售明细表中数据
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetDetailedkByBillCode(string billCode, string tbName)
        {
            return (data.RunProcReturn("SELECT tradecode,fullname,price,tsum,SUM(qty) AS qty FROM tb_orders_detailed WHERE (billcode = '" + billCode + "')group by tradecode,fullname,price,tsum", tbName));
        }
        /// <summary>
        /// 根据单据编号--得到销售明细表中数据
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetStockByTradeCode(string tradeCode, string tbName)
        {
            return (data.RunProcReturn("select * from tb_stock where tradecode ='" + tradeCode + "'", tbName));
        }
        /// <summary>
        /// 根据日期－－查询销售主表中数据
        /// </summary>
        /// <param name="starDataTime"></param>
        /// <param name="endDataTime"></param>
        /// <returns></returns>
        public DataSet FindSellStock(DateTime starDataTime, DateTime endDataTime)
        {
            return (data.RunProcReturn("select * from tb_orders where (billdate BETWEEN '" + starDataTime + " ' AND '" + endDataTime + " ')", "tb_orders"));
        }
        #endregion


        #region 库存管理--库存状况
        /// <summary>
        /// 检索库存商品--并按数量排序
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet setStockStatus(string tbName)
        {
            return (data.RunProcReturn("select * from tb_stock order by qty", tbName));
        }
        /// <summary>
        /// 根据商品编号，获得库存商品中所有信息
        /// </summary>
        /// <param name="tradeCode"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetStockLimitByTradeCode(string tradeCode, string tbName)
        {
            return (data.RunProcReturn("select * from tb_Stock where tradecode='" + tradeCode + "'", tbName));
        }
        /// <summary>
        /// 库存商品上下限设置
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public int UpdateStockLimit(cStockInfo stock)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  MySqlDbType.VarChar,5,stock.TradeCode),
                						data.MakeInParam("@upperlimit",  MySqlDbType.Float, 8, stock.UpperLimit),
                						data.MakeInParam("@lowerlimit",  MySqlDbType.Float, 8, stock.LowerLimit),
            };
            return (data.RunProc("update tb_stock set upperlimit=@upperlimit,lowerlimit=@lowerlimit where tradecode=@tradecode", prams));
        }
        #endregion

        #region 库存商品上下限报警
        /// <summary>
        /// 库存商品下限报警
        /// </summary>
        /// <returns></returns>
        public DataSet GetLowerLimit()
        {
            return (data.RunProcReturn("SELECT tradecode as 商品编号, fullname as 商品名称, qty as 库存数量,upperlimit as 库存上限,lowerlimit as 库存下限 from tb_stock WHERE (qty < lowerlimit) and lowerlimit > 0", "tb_stock"));
        }
        /// <summary>
        /// 库存商品上限报警
        /// </summary>
        /// <returns></returns>
        public DataSet GetUpperLimit()
        {
            return (data.RunProcReturn("SELECT tradecode as 商品编号, fullname as 商品名称, qty as 库存数量,upperlimit as 库存上限,lowerlimit as 库存下限 FROM tb_stock WHERE (upperlimit < qty) and upperlimit>0", "tb_stock"));
        }
        #endregion

        #region 库存盘点
        public int CheckStock(cStockInfo stock)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  MySqlDbType.VarChar, 5, stock.TradeCode),
                						data.MakeInParam("@check",  MySqlDbType.Float, 8,stock.Check),
			};
            return (data.RunProc("update tb_stock set stockcheck=@check where tradecode=@tradecode", prams));
        }
        #endregion


        #region 本单位信息设置--系统设置
        /// <summary>
        /// 本单位信息设置
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
#if false
        public int UpdateSysUnits(cUnits units)
        {
            MySqlParameter[] prams = {
                						data.MakeInParam("@fullname",  MySqlDbType.VarChar, 30, units.FullName),
                						data.MakeInParam("@tax",  MySqlDbType.VarChar, 30, units.Tax),
                						data.MakeInParam("@tel",  MySqlDbType.VarChar, 20, units.Tel),
                						data.MakeInParam("@linkman",  MySqlDbType.VarChar, 10, units.Linkman),
                						data.MakeInParam("@address",  MySqlDbType.VarChar, 60, units.Address),
                						data.MakeInParam("@accounts",  MySqlDbType.VarChar, 80, units.Accounts),
			};
            return (data.RunProc("update tb_unit set fullname=@fullname,tax=@tax,tel=@tel,linkman=@linkman,address=@address,accounts=@accounts", prams));
        }
        public int InsertSysUnits(cUnits units)
        {
            MySqlParameter[] prams = {
                						data.MakeInParam("@fullname",  MySqlDbType.VarChar, 30, units.FullName),
                						data.MakeInParam("@tax",  MySqlDbType.VarChar, 30, units.Tax),
                						data.MakeInParam("@tel",  MySqlDbType.VarChar, 20, units.Tel),
                						data.MakeInParam("@linkman",  MySqlDbType.VarChar, 10, units.Linkman),
                						data.MakeInParam("@address",  MySqlDbType.VarChar, 60, units.Address),
                						data.MakeInParam("@accounts",  MySqlDbType.VarChar, 80, units.Accounts),
			};
            return (data.RunProc("insert into tb_unit (fullname,tax,tel,linkman,address,accounts) values (@fullname,@tax,@tel,@linkman,@address,@accounts)", prams));
        }

        /// <summary>
        /// 得到本单位信息设置
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetAllUnit()
        {
            return (data.RunProcReturn("select * from tb_unit", "tb_unit"));
        }
#endif
        #endregion

        #region  数据库备份与恢复--系统设置
        /// <summary>
        /// 备份数据库
        /// </summary>
        /// <param name="bakUpName"></param>
        public void BackUp(string bakUpName)
        {
            data.RunProc("BACKUP DATABASE db_CMS TO DISK ='" + bakUpName + "'");
        }
        /// <summary>
        /// 恢复数据库
        /// </summary>
        /// <param name="reStoreName"></param>
        public void ReStore(string reStoreName)
        {
            data.RunProc("use master RESTORE DATABASE db_CMS from disk='" + reStoreName + "'");
        }
        #endregion

        #region  系统数据清理--系统设置
        /// <summary>
        /// 根据指定的数据表清除数据表中数据
        /// </summary>
        /// <param name="tbName_true"></param>
        public void ClearTable(string tbName_true)
        {
            data.RunProc("delete from " + tbName_true + "");
        }
        #endregion

        #region 系统操作员及权限设置--系统设置
        /// <summary>
        /// 添加系统操作员
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        public void AddSysUser(string userName, string pwd)
        {
            data.RunProc("INSERT INTO tb_power (sysuser, password) VALUES ('" + userName + "', '" + pwd + "')");
        }
        /// <summary>
        /// 删除系统操作员
        /// </summary>
        /// <param name="ID"></param>
        public void DeleteSysUser(int ID)
        {
            data.RunProc("delete from tb_power where id='" + ID + "'");
        }
        /// <summary>
        /// 获得所有系统用户信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllUser()
        {
            return (data.RunProcReturn("select * from tb_power", "tb_Power"));
        }
        /// <summary>
        /// 根据用户名称---查询系统用户
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool FindUserName(string userName)
        {
            DataSet ds = null;
            ds = data.RunProcReturn("select * from tb_power where sysuser='" + userName + "'", "tb_power");
            if (ds.Tables[0].Rows.Count > 0)
            { return true; }
            else
            { return false; }
        }
        /// <summary>
        /// 修改系统用户信息及所对应的权限
        /// </summary>
        /// <param name="popedom"></param>
        public void UpdateSysUser(cPopedom popedom)
        {
            MySqlParameter[] prams = {
                                        data.MakeInParam("@id",  MySqlDbType.Int32, 4, popedom.ID),
									    data.MakeInParam("@sysuser",  MySqlDbType.VarChar, 20, popedom.SysUser),
                						data.MakeInParam("@password",  MySqlDbType.VarChar, 20,popedom.Password),
                						data.MakeInParam("@stock",  MySqlDbType.Bit, 1, popedom.Stock),
                						data.MakeInParam("@vendition",  MySqlDbType.Bit, 1, popedom.Vendition),
                						data.MakeInParam("@storage",  MySqlDbType.Bit, 1, popedom.Storage),
                						data.MakeInParam("@system",  MySqlDbType.Bit, 1, popedom.SystemSet),
                                        data.MakeInParam("@base",  MySqlDbType.Bit, 1, popedom.Base_Info),
			};
            int i = data.RunProc("update tb_power set sysuser=@sysuser,password=@password,stock=@stock,vendition=@vendition,storage=@storage,system=@system,base=@base where id=@id", prams);
        }
        #endregion

        #region 往来单位对账
        /// <summary>
        /// 往来单位列表--并统计应收额-增加及减少
        /// </summary>
        /// <returns></returns>
        public DataSet GetUnitsList()
        {
            return (data.RunProcReturn("SELECT units as 往来单位, SUM(addgathering) AS 应收增加, SUM(reducegathering) AS 应收减少 FROM tb_currentaccount GROUP BY units", "tb_currentaccount"));
        }
        /// <summary>
        ///查询在指定的日期段中--是否存在－－查询结果
        /// </summary>
        /// <param name="units"></param>
        /// <param name="starDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public DataSet FindCurrentAccountDate(string units, DateTime starDateTime, DateTime endDateTime)
        {
            return (data.RunProcReturn("SELECT * FROM tb_currentaccount WHERE units='" + units + "' AND billdate BETWEEN '" + starDateTime + "'AND '" + endDateTime + "'", "tb_currentaccount"));
        }
        /// <summary>
        /// 往来对账－－根据单据编号--查询明细表中数据
        /// </summary>
        /// <param name="billcode"></param>
        /// <param name="tb_Detailed_true"></param>
        /// <returns></returns>
        public DataSet FindDetailde(string tb_Detailed_true, string billcode)
        {
            return (data.RunProcReturn("select * from " + tb_Detailed_true + " where (billcode='" + billcode + "')ORDER BY tsum", "detailed"));
        }
        /// <summary>
        /// 往来对账－－根据单据编号--查询主表中数据
        /// </summary>
        /// <param name="tb_Main_true"></param>
        /// <param name="billcode"></param>
        /// <returns></returns>
        public DataSet FindMain(string tb_Main_true, string billcode)
        {
            return (data.RunProcReturn("select * from " + tb_Main_true + " where billcode='" + billcode + "'", "main"));
        }
        #endregion

        #region 辅助工具管理
        //ShellExecute Me.hWnd, "open", "http://www.mingrisoft.com", 1, 1, 5
        public void OpenInernet()
        {

        }
        #endregion

        #region 系统登录
        /// <summary>
        /// 系统登录
        /// </summary>
        /// <param name="popedom"></param>
        /// <returns></returns>
        public DataSet Login(cPopedom popedom)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@sysuser",  MySqlDbType.VarChar, 20, popedom.SysUser),
                						data.MakeInParam("@password",  MySqlDbType.VarChar, 20,popedom.Password),
			};
            return (data.RunProcReturn("SELECT * FROM user WHERE (userName = @sysuser) AND (userPassword = @password)", prams, "user"));
        }

        #endregion
    }
    #region 定义往来单位--数据结构
    public class cUnitsInfo
    {
        private string unitcode = "";
        private string fullname = "";
        private string tax = "";
        private string tel = "";
        private string linkman = "";
        private string address = "";
        private string accounts = "";
        private float gathering = 0;
        private float payment = 0;
        /// <summary>
        /// 单位编号
        /// </summary>
        public string UnitCode
        {
            get { return unitcode; }
            set { unitcode = value; }
        }
        /// <summary>
        /// 单位全称
        /// </summary>
        public string FullName
        {
            get { return fullname; }
            set { fullname = value; }
        }
        /// <summary>
        /// 单位税号
        /// </summary>
        public string Tax
        {
            get { return tax; }
            set { tax = value; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string LinkMan
        {
            get { return linkman; }
            set { linkman = value; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        /// <summary>
        /// 单位地址
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        /// <summary>
        /// 开户行及账号
        /// </summary>
        public string Accounts
        {
            get { return accounts; }
            set { accounts = value; }
        }
        /// <summary>
        /// 累计应收款
        /// </summary>
        public float Gathering
        {
            get { return gathering; }
            set { gathering = value; }
        }
        /// <summary>
        /// 累计应付款
        /// </summary>
        public float Payment
        {
            get { return payment; }
            set { payment = value; }
        }
    }

    #endregion

    #region 定义库存商品--数据结构
    public class cStockInfo
    {
        private string tradecode = "";
        private string fullname = "";
        private string tradetpye = "";
        private string standard = "";
        private string tradeunit = "";
        private string produce = "";
        private float qty = 0;
        private float price = 0;
        private float averageprice = 0;
        private float saleprice = 0;
        private float check = 0;
        private float upperlimit = 0;
        private float lowerlimit = 0;
        /// <summary>
        /// 商品编号
        /// </summary>
        public string TradeCode
        {
            get { return tradecode; }
            set { tradecode = value; }
        }
        /// <summary>
        /// 单位全称
        /// </summary>
        public string FullName
        {
            get { return fullname; }
            set { fullname = value; }
        }
        /// <summary>
        /// 商品型号
        /// </summary>
        public string TradeType
        {
            get { return tradetpye; }
            set { tradetpye = value; }
        }
        /// <summary>
        /// 商品规格
        /// </summary>
        public string Standard
        {
            get { return standard; }
            set { standard = value; }
        }
        /// <summary>
        /// 商品单位
        /// </summary>
        public string Unit
        {
            get { return tradeunit; }
            set { tradeunit = value; }
        }
        /// <summary>
        /// 商品产地
        /// </summary>
        public string Produce
        {
            get { return produce; }
            set { produce = value; }
        }
        /// <summary>
        /// 库存数量
        /// </summary>
        public float Qty
        {
            get { return qty; }
            set { qty = value; }
        }
        /// <summary>
        /// 进货时最后一次价格
        /// </summary>
        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        /// <summary>
        /// 加权平均价格
        /// </summary>
        public float AveragePrice
        {
            get { return averageprice; }
            set { averageprice = value; }
        }
        /// <summary>
        /// 销售时的最后一次销价
        /// </summary>
        public float SalePrice
        {
            get { return saleprice; }
            set { saleprice = value; }
        }
        /// <summary>
        /// 盘点数量
        /// </summary>
        public float Check
        {
            get { return check; }
            set { check = value; }
        }
        /// <summary>
        /// 库存报警上限
        /// </summary>
        public float UpperLimit
        {
            get { return upperlimit; }
            set { upperlimit = value; }
        }
        /// <summary>
        /// 库存报警下限
        /// </summary>
        public float LowerLimit
        {
            get { return lowerlimit; }
            set { lowerlimit = value; }
        }
    }

    #endregion

    #region 定义公司职员--数据结构
    public class cEmployeeInfo
    {
        private string employeecode = "";
        private string fullname = "";
        private string sex = "";
        private string dept = "";
        private string tel = "";
        private string memo = "";
        /// <summary>
        /// 职员编号
        /// </summary>
        public string EmployeeCode
        {
            get { return employeecode; }
            set { employeecode = value; }
        }
        /// <summary>
        /// 职员姓名
        /// </summary>
        public string FullName
        {
            get { return fullname; }
            set { fullname = value; }
        }
        /// <summary>
        /// 职员性别
        /// </summary>
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        /// <summary>
        /// 所在部门
        /// </summary>
        public string Dept
        {
            get { return dept; }
            set { dept = value; }
        }
        /// <summary>
        /// 职员电话
        /// </summary>
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string Memo
        {
            get { return memo; }
            set { memo = value; }
        }
    }

    #endregion

    #region 定义销售订单过账单据--数据结构
    public class cBillInfo
    {
        //销售订单表&结构
        private DateTime bill_date = DateTime.Now;   //录单操作日期
        private DateTime order_date = DateTime.Now;  //下单日期
        private string bill_code = "";               //销售订单编号
        private string customer_code = "";           //客户编号
        private string customer_name = "";           //客户姓名
        private string customer_tel = "";            //客户联系电话
        private string customer_address = "";        //客户收货地址
        private string salesPerson_code = "";          //接单员工号
        private string sales_person = "";            //接单员姓名  
        private float orderTotal_payment = 0;        //订单总金额
        private string status = "";                 //订单状态
         private int detail_number = 0;                //明细条数

        //销售订单明细表结构
        private string orderDetaild_code = "";       //订单明细流水号
        private string order_code = "";              //相关联的销售订单号 == billcode
        private string goods_code = "";              //商品编号
        private float qty = 0;                       //需求数量
        private string goods_name = "";              //商品名称
        private string goods_unit = "";              //商品单位
        private float goods_price = 0;             //商品单价

        /// <summary>
        /// 录单操作日期
        /// </summary>
        public DateTime BillDate
        {
            get { return bill_date; }
            set { bill_date = value; }
        }
        /// <summary>
        /// 下单日期
        /// </summary>
        public DateTime orderDate
        {
            get { return order_date; }
            set { order_date = value; }
        }
        /// <summary>
        /// 销售订单编号
        /// </summary>
        public string BillCode
        {
            get { return bill_code; }
            set { bill_code = value; }
        }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustomerCode
        {
            get { return customer_code; }
            set { customer_code = value; }
        }
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string CustomerName
        {
            get { return customer_name; }
            set { customer_name = value; }
        }
        /// <summary>
        /// 客户联系电话
        /// </summary>
        public string CustomerTEL
        {
            get { return customer_tel; }
            set { customer_tel = value; }
        }
        /// <summary>
        /// 客户收货地址
        /// </summary>
        public string CustomerAddress
        {
            get { return customer_address; }
            set { customer_address = value; }
        }
        /// <summary>
        /// 接单员工号
        /// </summary>
        public string SalesPersonCode
        {
            get { return salesPerson_code; }
            set { salesPerson_code = value; }
        }
        /// <summary>
        /// 接单员姓名
        /// </summary>
        public string SalesPersonName
        {
            get { return sales_person; }
            set { sales_person = value; }
        }
        /// <summary>
        /// 订单总金额
        /// </summary>
        public float OrderTotalPayment
        {
            get { return orderTotal_payment; }
            set { orderTotal_payment = value; }
        }

        /// <summary>
        /// 订单明细流水号
        /// </summary>
        public string orderDetaildCode
        {
            get { return orderDetaild_code; }
            set { orderDetaild_code = value; }
        }
        /// <summary>
        /// 相关联的销售订单号
        /// </summary>
        public string orderCode
        {
            get { return order_code; }
            set { order_code = value; }
        }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string goodsCode
        {
            get { return goods_code; }
            set { goods_code = value; }
        }
        /// <summary>
        /// 需求数量
        /// </summary>
        public float Qty
        {
            get { return qty; }
            set { qty = value; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string goodsName
        {
            get { return goods_name; }
            set { goods_name = value; }
        }
        /// <summary>
        /// 商品单位
        /// </summary>
        public string goodsUnit
        {
            get { return goods_unit; }
            set { goods_unit = value; }
        }
        /// <summary>
        /// 商品单价
        /// </summary>
        public float goodsPrice
        {
            get { return goods_price; }
            set { goods_price = value; }
        }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        /// <summary>
        /// 明细条数
        /// </summary>
        public int DetailNumber
        {
            get { return detail_number; }
            set { detail_number = value; }
        }
    }
    #endregion
    #region 定义采购订单过账单据--数据结构
    public class cPurchaseBill
    {
        //采购订单表&结构
        private DateTime bill_date = DateTime.Now;   //录单操作日期
        private DateTime order_date = DateTime.Now;  //下单日期
        private DateTime deadline = DateTime.Now;    //要货日期
        private string bill_code = "";               //采购订单编号
        private string supplier_code = "";           //供应商编号
        private string supplier_name = "";           //供应商姓名
        private string supplier_tel = "";            //供应商联系电话
        private string supplier_address = "";        //供应商地址
        private string buyer_code = "";             //采购员工号
        private string buyer_name = "";            //采购员姓名  
        private float Total_payment = 0;            //订单总金额
        private string status = "";                 //订单状态
        private int detail_number = 0;                //明细条数

        //采购订单明细表结构
        private string serial_number = ""; //明细编号
        private string purchase_detail_code = "";       //订单明细编号
        private string purchase_code = "";              //相关联的采购订单号 == billcode
        private string goods_code = "";              //商品编号
        private float qty = 0;                       //需求数量
        private string goods_name = "";              //商品名称
        private string goods_unit = "";              //商品单位
        private float goods_price = 0;             //商品单价
        private float goods_total_price = 0;        //单条明细小计

        /// <summary>
        /// 录单操作日期
        /// </summary>
        public DateTime BillDate
        {
            get { return bill_date; }
            set { bill_date = value; }
        }
        /// <summary>
        /// 下单日期
        /// </summary>
        public DateTime orderDate
        {
            get { return order_date; }
            set { order_date = value; }
        }
        /// <summary>
        /// 要货日期
        /// </summary>
        public DateTime DeadLine
        {
            get { return deadline; }
            set { deadline = value; }
        }

        /// <summary>
        /// 供应商地址
        /// </summary>
        public string SupplierAddress
        {
            get { return supplier_address; }
            set { supplier_address = value; }
        }


        /// <summary>
        /// 供应商联系电话
        /// </summary>
        public string SupplierTel
        {
            get { return supplier_tel; }
            set { supplier_tel = value; }
        }

        /// <summary>
        /// 供应商姓名
        /// </summary>
        public string SupplierName
        {
            get { return supplier_name; }
            set { supplier_name = value; }
        }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string SupplierCode
        {
            get { return supplier_code; }
            set { supplier_code = value; }
        }


        /// <summary>
        /// 采购订单编号
        /// </summary>
        public string BillCode
        {
            get { return bill_code; }
            set { bill_code = value; }
        }

        /// <summary>
        /// 采购员工号
        /// </summary>
        public string BuyerCode
        {
            get { return buyer_code; }
            set { buyer_code = value; }
        }
        /// <summary>
        /// 采购员姓名
        /// </summary>
        public string BuyerName
        {
            get { return buyer_name; }
            set { buyer_name = value; }
        }
        /// <summary>
        /// 订单总金额
        /// </summary>
        public float TotalPayment
        {
            get { return Total_payment; }
            set { Total_payment = value; }
        }

        /// <summary>
        /// 明细流水号
        /// </summary>
        public string SerialNumber
        {
            set { serial_number = value; }
            get { return serial_number; }
        }

        /// <summary>
        /// 订单明细编号
        /// </summary>
        public string PurchaseDetaildCode
        {
            get { return purchase_detail_code; }
            set { purchase_detail_code = value; }
        }
        /// <summary>
        /// 相关联的采购订单号
        /// </summary>
        public string PurchaseCode
        {
            get { return purchase_code; }
            set { purchase_code = value; }
        }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string goodsCode
        {
            get { return goods_code; }
            set { goods_code = value; }
        }
        /// <summary>
        /// 需求数量
        /// </summary>
        public float Qty
        {
            get { return qty; }
            set { qty = value; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string goodsName
        {
            get { return goods_name; }
            set { goods_name = value; }
        }
        /// <summary>
        /// 商品单位
        /// </summary>
        public string goodsUnit
        {
            get { return goods_unit; }
            set { goods_unit = value; }
        }
        /// <summary>
        /// 商品单价
        /// </summary>
        public float goodsPrice
        {
            get { return goods_price; }
            set { goods_price = value; }
        }
        /// <summary>
        /// 明细小计
        /// </summary>
        public float GoodsTotalPrice
        {
            get { return goods_total_price; }
            set { goods_total_price = value; }          
        }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        /// <summary>
        /// 明细条数
        /// </summary>
        public int DetailNumber
        {
            get { return detail_number; }
            set { detail_number = value; }
        }
    }
    #endregion

    #region   定义出入库单过账单据--数据结构
    public class cStockBill
    {
        private DateTime bill_date = DateTime.Now;   //操作日期
        private int goods_count = 0;

        //单主表
        private string entry_code = "";
        private string purchase_code = "";

        private string supplier_code = "";
        
        private string staff_code = "";
        private string staff_name = "";

        private string out_code = "";

        //明细表
        private string entry_detail_code = "";
        private string en_code = "";

        private string o_code = "";
        private string orders_code = "";

        private string goods_code = "";
        private string goods_name = "";
        private string goods_uint = "";
        private float goods_price = 0;
        private int goods_qty = 0;
        private float goods_total_price = 0;
        
        /// <summary>
        /// 出库入库操作日期
        /// </summary>
        public DateTime BillDate
        {
            get { return bill_date; }
            set { bill_date = value; }
        }
        /// <summary>
        /// 明细总条数
        /// </summary>
        public int GoodsCount
        {
            get { return goods_count;}
            set { goods_count = value;}
        }
        /// <summary>
        /// 入库单号
        /// </summary>
        public string EntryCode
        {
            get { return entry_code; }
            set { entry_code = value;}
        }
        /// <summary>
        /// 采购单号
        /// </summary>
        public string PurchaseCode
        {
            get { return purchase_code;}
            set {purchase_code = value;}
        }
        /// <summary>
        /// 供应商号
        /// </summary>
        public string SupplierCode
        {
            get { return supplier_code;}
            set {supplier_code = value;}
        }
        /// <summary>
        /// 员工号
        /// </summary>
        public string StaffCode
        {
            get { return staff_code;}
            set {staff_code = value;}
        }
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string StaffName
        {
            get { return staff_name; }
            set { staff_name = value; }
        }
        /// <summary>
        /// 出入库单号
        /// </summary>
        public string EnOutCode
        {
            get { return out_code;}
            set {out_code = value;}
        }

        /// <summary>
        /// 出入库明细流水号
        /// </summary>
        public string EnOutDetailCode
        { 
            get {return entry_detail_code;}
            set {entry_detail_code=value;}
        }
        ///// <summary>
        ///// 同明细相关联的入库单号
        ///// </summary>
        //public string EnCode
        //{
        //    get { return en_code;}
        //    set {en_code=value;}
        //}
        /// <summary>
        /// 同明细相关联的出入库单号
        /// </summary>
        public string EnOtCode
        {
            get { return o_code;}
            set {o_code=value;}
        }
        /// <summary>
        /// 销售单号
        /// </summary>
        public string OrdersCode
        {
            get {return orders_code;}
            set {orders_code=value;}
        }
        /// <summary>
        /// 商品号
        /// </summary>
        public string GoodCode
        {
            get {return goods_code;}
            set {goods_code=value;}
        }
        /// <summary>
        /// 商品名
        /// </summary>
        public string GoodsName
        {
            get {return goods_name;}
            set {goods_name=value;}
        }

        /// <summary>
        /// 商品计量单位
        /// </summary>
        public string GoodsUint
        {
            get {return goods_uint;}
            set {goods_uint=value;}
        }
        /// <summary>
        /// 商品价格
        /// </summary>
        public float GoodsPrice
        {
            get {return goods_price;}
            set {goods_price=value;}
        }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int Qty
        {
            get { return goods_qty;}
            set {goods_qty=value;}
        }
        /// <summary>
        /// 明细小计
        /// </summary>
        public float GoodsTotalPrice
        {
            get { return goods_total_price;}
            set {goods_total_price=value;}
        }
    }
    #endregion

    #region 定义往来账本明细--数据结构
    public class cCurrentAccount
        {
            private DateTime billdate = DateTime.Now;
            private string billcode = "";
            private float addgathering = 0;             //应收增加
            private float factaddfee = 0;             //实际增加
            private float reducegathering = 0;        //应收减少
            private float factreducegathering = 0;    //实际减少
            private float balance = 0;  //应收与增加 差额
            private string units = "";

            /// <summary>
            /// 录单日期
            /// </summary>
            public DateTime BillDate
            {
                get { return billdate; }
                set { billdate = value; }
            }/// <summary>
            /// 单据编号
            /// </summary>
            public string BillCode
            {
                get { return billcode; }
                set { billcode = value; }
            }/// <summary>
            /// 应收增加
            /// </summary>
            public float AddGathering
            {
                get { return addgathering; }
                set { addgathering = value; }
            }/// <summary>
            /// 实际增加
            /// </summary>
            public float FactAddFee
            {
                get { return factaddfee; }
                set { factaddfee = value; }
            }/// <summary>
            /// 应收减少
            /// </summary>
            public float ReduceGathering
            {
                get { return reducegathering; }
                set { reducegathering = value; }
            }/// <summary>
            /// 实际减少
            /// </summary>
            public float FactReduceGathering
            {
                get { return factreducegathering; }
                set { factreducegathering = value; }
            }/// <summary>
            /// 余额(应收金额-实际金额)
            /// </summary>
            public float Balance
            {
                get { return balance; }
                set { balance = value; }
            }/// <summary>
            /// 往来单位
            /// </summary>
            public string Units
            {
                get { return units; }
                set { units = value; }
            }
        }

        #endregion

        #region 定义本单位信息设置--数据结构
        public class cUnits
        {
            private string fullname = "";
            private string tax = "";
            private string tel = "";
            private string linkman = "";
            private string address = "";
            private string accounts = "";

            /// <summary>
            /// 单位全称
            /// </summary>
            public string FullName
            {
                get { return fullname; }
                set { fullname = value; }
            }
            /// <summary>
            /// 税号
            /// </summary>
            public string Tax
            {
                get { return tax; }
                set { tax = value; }
            }
            /// <summary>
            /// 单位电话
            /// </summary>
            public string Tel
            {
                get { return tel; }
                set { tel = value; }
            }
            /// <summary>
            /// 联系人
            /// </summary>
            public string Linkman
            {
                get { return linkman; }
                set { linkman = value; }
            }
            /// <summary>
            /// 联系地址
            /// </summary>
            public string Address
            {
                get { return address; }
                set { address = value; }
            }
            /// <summary>
            /// 开户行及账号
            /// </summary>
            public string Accounts
            {
                get { return accounts; }
                set { accounts = value; }
            }
        }

        #endregion

        #region 定义往来账明细表－－－数据结构
        public class cCurrentaccount
        {
            private DateTime billdate = DateTime.Now;
            private string billcode = "";
            private float addgathering = 0;
            private float factaddfee = 0;
            private float reducegathering = 0;
            private float factfee = 0;
            private float balance = 0;
            private string units = "";
            /// <summary>
            /// 录单日期
            /// </summary>
            public DateTime BillDate
            {
                get { return billdate; }
                set { billdate = value; }
            }
            /// <summary>
            /// 单据编号
            /// </summary>
            public string BillCode
            {
                get { return billcode; }
                set { billcode = value; }
            }
            /// <summary>
            /// 应收增加
            /// </summary>
            public float AddGathering
            {
                get { return addgathering; }
                set { addgathering = value; }
            }
            /// <summary>
            /// 实际增加
            /// </summary>
            public float FactAddfee
            {
                get { return factaddfee; }
                set { factaddfee = value; }
            }
            /// <summary>
            /// 应收减少
            /// </summary>
            public float ReduceGathering
            {
                get { return reducegathering; }
                set { reducegathering = value; }
            }
            /// <summary>
            /// 实际减少
            /// </summary>
            public float FactFee
            {
                get { return factfee; }
                set { factfee = value; }
            }
            /// <summary>
            /// 应收余额
            /// </summary>
            public float Balance
            {
                get { return balance; }
                set { balance = value; }
            }
            /// <summary>
            /// 往来单位
            /// </summary>
            public string Units
            {
                get { return units; }
                set { units = value; }
            }
        }
        #endregion

        #region 定义权限－－数据结构
        public class cPopedom
        {
            private int id = 0;
            private string sysuser = "";
            private string password = "";
            Boolean stock = false;
            Boolean vendition = false;
            Boolean storage = false;
            Boolean system = false;
            Boolean base_info = false;
            /// <summary>
            /// ID
            /// </summary>
            public int ID
            {
                get { return id; }
                set { id = value; }
            }
            /// <summary>
            /// 用户名称
            /// </summary>
            public string SysUser
            {
                get { return sysuser; }
                set { sysuser = value; }
            }
            /// <summary>
            /// 用户密码
            /// </summary>
            public string Password
            {
                get { return password; }
                set { password = value; }
            }
            /// <summary>
            /// 进货权限
            /// </summary>
            public Boolean Stock
            {
                get { return stock; }
                set { stock = value; }
            }
            /// <summary>
            /// 销售权限
            /// </summary>
            public Boolean Vendition
            {
                get { return vendition; }
                set { vendition = value; }
            }
            /// <summary>
            /// 库存权限
            /// </summary>
            public Boolean Storage
            {
                get { return storage; }
                set { storage = value; }
            }
            /// <summary>
            /// 系统设置权限
            /// </summary>
            public Boolean SystemSet
            {
                get { return system; }
                set { system = value; }
            }
            /// <summary>
            /// 基本信息权限
            /// </summary>
            public Boolean Base_Info
            {
                get { return base_info; }
                set { base_info = value; }
            }
        }
        #endregion
    }