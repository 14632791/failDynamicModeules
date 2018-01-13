using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Metro.DynamicModeules.Interfaces.Bridge;
using Metro.DynamicModeules.Bridge;
using Metro.DynamicModeules.Bridge.SystemModule;
using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Core.Log;

namespace Metro.DynamicModeules.BLL.Business
{
    public class BllBusinessLog
    {
        public static DataSet SearchLog(string logUser, string tableName, DateTime dateFrom, DateTime dateTo)
        {
            IBridgeEditLogHistory bridge = CreateEditLogHistoryBridge();
            return bridge.SearchLog(logUser, tableName, dateFrom, dateTo);
        }

        public static bool SaveFieldDef(DataTable data)
        {
            IBridgeEditLogHistory bridge = CreateEditLogHistoryBridge();
            return bridge.SaveFieldDef(data);
        }

        public static DataTable GetLogFieldDef(string tableName)
        {
            IBridgeEditLogHistory bridge = CreateEditLogHistoryBridge();
            return bridge.GetLogFieldDef(tableName);
        }
        /// <summary>
        /// 将dataset中有变化的字段保存到数据库中
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool WriteLog(DataSet data, string logUser)
        {
            if (data == null) return false;//LogDef  LogDefDtl
            if (data.Tables.Count <= 0) return false;
            List<LogDef> lstLogDef = new List<LogDef>();
            try
            {
                foreach (DataTable table in data.Tables)
                {
                    DataColumn[] cols = table.PrimaryKey;
                    StringBuilder strPrimaryKey = new StringBuilder();
                    foreach (DataColumn col in cols)
                    {
                        strPrimaryKey.Append(col.ColumnName + ",");//多个主键之间用,隔开
                    }
                    foreach (DataRow row in table.Rows)
                    {
                        //(GUID32 ,LogUser ,LogDate ,OPType ,DocNo ,TableName ,KeyFieldName,IsMaster) 
                        if (row.RowState == DataRowState.Unchanged) continue;
                        LogDef logDef = new LogDef();
                        logDef.GUID32 = Guid.NewGuid().ToString("N");
                        logDef.LogUser = logUser;
                        logDef.LogDate = DateTime.Now;
                        logDef.TableName = table.TableName;
                        logDef.KeyFieldName = strPrimaryKey.ToString().TrimEnd(',');
                        if (!string.IsNullOrEmpty(logDef.KeyFieldName))
                        {
                            if(row.RowState==DataRowState.Deleted)
                            logDef.DocNo = row[logDef.KeyFieldName,DataRowVersion.Original].ToString();
                            else logDef.DocNo = row[logDef.KeyFieldName, DataRowVersion.Current].ToString();
                        }
                        else {
                            if (row.RowState == DataRowState.Deleted)
                                logDef.DocNo = row[0, DataRowVersion.Original].ToString();
                            else logDef.DocNo = row[0, DataRowVersion.Current].ToString();
                        }
                        logDef.IsMaster = true;
                        switch (row.RowState)
                        {
                            case DataRowState.Added:
                                logDef.OPType = (int)LogOPType.LogAppend;
                                if (cols.Length>0)
                                logDef.DocNo = row[cols[0].ColumnName].ToString();//只取第一个主键的值
                                break;
                            case DataRowState.Modified:
                                logDef.OPType = (int)LogOPType.LogEdit;
                                foreach (DataColumn col in table.Columns)
                                {
                                    if(col.ColumnName=="CreationDate"||col.ColumnName=="CreatedBy"||col.ColumnName=="LastUpdateDate"||col.ColumnName=="LastUpdatedBy"
                                        || col.ColumnName == "FlagApp" || col.ColumnName == "AppUser" || col.ColumnName == "AppDate")
                                    {
                                        continue;//如果是公共字段则跳出本本次循环 2015.7.18 陈刚
                                    }
                                    //当前值与原始值不符合时才会记录
                                    string strCurrent = row.HasVersion(DataRowVersion.Current)? row[col.ColumnName, DataRowVersion.Current].ToString() : "";
                                    string strOriginal = row.HasVersion(DataRowVersion.Original)? row[col.ColumnName, DataRowVersion.Original].ToString() : "";
                                    if(strCurrent!=strOriginal)
                                    {
                                        // ,[GUID32] ,[TableName]  ,[FieldName] ,[OldValue]   ,[NewValue]
                                        LogDefDtl logDetail = new LogDefDtl();
                                        logDetail.GUID32 = logDef.GUID32;
                                        logDetail.TableName = table.TableName;
                                        logDetail.FieldName = col.ColumnName;
                                        logDetail.NewValue = strCurrent;
                                        logDetail.OldValue = strOriginal;
                                        logDef.Details.Add(logDetail);
                                    }
                                }
                                break;
                            case DataRowState.Deleted:
                                logDef.OPType = (int)LogOPType.LogDelete;
                                if (cols.Length > 0)
                                logDef.DocNo = row[cols[0].ColumnName, DataRowVersion.Original].ToString();//只取第一个主键的值
                                break;
                            default:
                                break;
                        }
                        lstLogDef.Add(logDef);
                    }
                }
                IBridgeEditLogHistory bridge = CreateEditLogHistoryBridge();
                bridge.WriteLog(lstLogDef);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 创建修改历史记录的数据层桥接实例
        /// </summary>
        /// <returns></returns>
        public static IBridgeEditLogHistory CreateEditLogHistoryBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirectLog().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WebService_Log();

            throw new CustomException("UNKNOW_BRIDGE_TYPE:CreateEditLogHistoryBridge()");
        }

    }
}
