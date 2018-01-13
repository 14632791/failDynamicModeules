
///*************************************************************************/
///*
///* 文件名    ：CommonData.cs      
///
///* 程序说明  : 系统公共数据
///               
///* 原创作者  ：陈刚
///* Copyright 2015 Metro.DynamicModeules software
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Interfaces.Bridge;
using Metro.DynamicModeules.Bridge;
using Metro.DynamicModeules.Interfaces;
using Metro.DynamicModeules.Models.SystemModels;
using System.Linq;

namespace Metro.DynamicModeules.BLL
{
    /// <summary>
    /// 系统公共数据
    /// </summary>
    public class CommonData
    {
        private static TCompanyInfo _CompanyInfo = null;

        /// <summary>
        /// 公司资料
        /// </summary>
        public static TCompanyInfo CompanyInfo
        {
            get { return _CompanyInfo; }
        }

        /// <summary>
        /// 获取系统所需公共信息
        /// </summary>
        public static void GetCommonInfos()
        {
            BllCompanyInfo Bll = new BllCompanyInfo();
            Bll.GetSummaryData(false);

            //获取公司资料
            DataTable dt = Bll.SummaryTable;
            if (dt.Rows.Count > 0)
                _CompanyInfo = (TCompanyInfo)DataConverter.DataRowToObject(dt.Rows[0], typeof(TCompanyInfo));
            else
                _CompanyInfo = new TCompanyInfo();

        }
        /// <summary>
        /// 获取系统业务表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetBusinessTables()
        {
            IBridgeCommonData bridge = BridgeFactory.CreateCommonDataBridge();
            return bridge.GetBusinessTables();
        }

        public static string GetDataSN(string dataCode, bool asHeader)
        {
            IBridgeCommonData bridge = BridgeFactory.CreateCommonDataBridge();
            return bridge.GetDataSN(dataCode, asHeader);
        }

        /// <summary>
        /// 获取系统模块
        /// </summary>
        /// <returns></returns>
        public static DataTable GetModules()
        {
            IBridgeCommonData bridge = BridgeFactory.CreateCommonDataBridge();
            return bridge.GetModules();
        }

        /// <summary>
        /// 获取表的所有字段
        /// </summary>
        /// <param name="tableName">表名</param>
        public static DataTable GetTableFieldsDef(string tableName, bool onlyDisplayField)
        {
            IBridgeCommonData bridge = BridgeFactory.CreateCommonDataBridge();
            return bridge.GetTableFieldsDef(tableName, onlyDisplayField);
        }

        /// <summary>
        /// 获取数据字典
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataTable GetDataDict(string tableName)
        {
            IBridgeDataDict bridge = BridgeFactory.CreateDataDictBridge(tableName, "");
            return bridge.GetSummaryData();
        }

        /// <summary>
        /// 获取帐套
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSystemDataSet()
        {
            IBridgeCommonData bridge = BridgeFactory.CreateCommonDataBridge();
            return bridge.GetSystemDataSet();
        }

        public DataTable GetDB4Backup()
        {
            IBridgeCommonData bridge = BridgeFactory.CreateCommonDataBridge();
            return bridge.GetDB4Backup();
        }

        public DataTable GetBackupHistory(int topList)
        {
            IBridgeCommonData bridge = BridgeFactory.CreateCommonDataBridge();
            return bridge.GetBackupHistory(topList);
        }

        public bool BackupDatabase(string DBNAME, string BKPATH)
        {
            IBridgeCommonData bridge = BridgeFactory.CreateCommonDataBridge();
            return bridge.BackupDatabase(DBNAME, BKPATH);
        }

        public bool RestoreDatabase(string BKFILE, string DBNAME)
        {
            IBridgeCommonData bridge = BridgeFactory.CreateCommonDataBridge();
            return bridge.RestoreDatabase(BKFILE, DBNAME);
        }

        public static DataTable SearchOutstanding(string invoiceNo, string customer, DateTime dateFrom, DateTime dateTo, DateTime dateEnd, string outstandingType)
        {
            IBridgeCommonData bridge = BridgeFactory.CreateCommonDataBridge();
            return bridge.SearchOutstanding(invoiceNo, customer, dateFrom, dateTo, dateEnd, outstandingType);
        }

        /// <summary>
        ///  分页查询，是指是单个表的 2015.6.29 陈刚
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, string tableName)
        {
          return  BridgeFactory.CreateCommonDataBridge().GetListByPage(strWhere, orderby, startIndex, endIndex, tableName);
        }

        /// <summary>
        /// 以最原始的SQL语句方式查询返回数据集 2015.6.29 陈刚
        /// </summary>
        /// <param name="strSql">带查询条件及查询变量@XXX的完整查询字符串,但不能含有"DELETE", "UPDATE","DROP关键字
        /// <param name="lstType"></param>
        /// <returns></returns>
        public static DataSet GetSummaryByParam(string strSql, List<CustomSqlDbTypeModel> lstType, string tableName)
        {
            return BridgeFactory.CreateCommonDataBridge().GetSummaryByParam(strSql,lstType, tableName);
        }

        /// <summary>
        /// 获取当前以DocNo为前缀的所有主单号集合 陈刚 2015.7.1
        /// </summary>
        /// <param name="DocNo">例如以M ,S开头</param>
        /// <returns></returns>
        public static List<string> GetAllDocNo(string DocNo)
        {
            int iLength = DocNo.Length;
            DataTable tbl = BridgeFactory.CreateCommonDataBridge().GetAllDocNo(DocNo);
            if (tbl == null) return null;
            if (tbl.Rows.Count <= 0) return null;
            List<string> lstString = new List<string>();
            string strvalue = "0001";
            foreach (DataRow row in tbl.Select("MaxID IS NOT NULL", "MaxID ASC"))
            {
                int iMax = Convert.ToInt32(row["MaxID"]);
                string ym = row["YYMM"].ToString();
                for (int i = 1; i <= iMax; i++)
                {
                    switch (i.ToString().Length)
                    {
                        case 1:
                            strvalue = "000" + i.ToString();
                            break;
                        case 2:
                            strvalue = "00" + i.ToString();
                            break;
                        case 3:
                            strvalue = "0" + i.ToString();
                            break;
                        case 4:
                            strvalue = i.ToString();
                            break;
                        default:
                            break;
                    }
                    lstString.Add(DocNo + ym + strvalue);
                }
            }
            lstString.Sort((a, b) => {
                return -int.Parse(a.Substring(iLength)).CompareTo(int.Parse(b.Substring(iLength)));
            });//排序,截取掉非数字的字符后再比较
            return lstString;
        }
    }
}
