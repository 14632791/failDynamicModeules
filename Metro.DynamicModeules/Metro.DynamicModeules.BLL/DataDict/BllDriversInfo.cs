using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Server.DataAccess;
using Metro.DynamicModeules.Core;
using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.Server.DataAccess.DalDataDict;
using Metro.DynamicModeules.Bridge;
using Metro.DynamicModeules.Interfaces;
using Metro.DynamicModeules.Bridge.InventoryModule;
using Metro.DynamicModeules.Bridge.DataDictModule;
using Metro.DynamicModeules.Interfaces.Bridge;
using Metro.DynamicModeules.Models.DataDictModels;
using System.Windows.Forms;
using System.Linq;

/*==========================================
 *   程序说明: DriversInfo的业务逻辑层
 *   作者姓名: 鸿泰信 www.Metro.DynamicModeules.com
 *   创建日期: 2015/06/18 11:37:07
 *   最后修改: 2015/06/18 11:37:07
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 鸿泰信 www.Metro.DynamicModeules.com
 *==========================================*/

namespace Metro.DynamicModeules.BLL.DataDict
{
    public class BllDriversInfo : BllBaseDataDict
    {
        private IBridgeDriversInfo _MyBridge; //桥接/策略接口
        
        /// <summary>
        /// 已选所负责车辆信息
        /// </summary>
        public DataTable SelectedCarData { get; set; }

        /// <summary>
        /// 可选车辆信息
        /// </summary>
        public DataTable AvailableCarData { get; set; }
        public BllDriversInfo()
        {
            _KeyFieldName = TblDriversInfo.__KeyName; //主键字段
            _SummaryTableName = TblDriversInfo.__TableName;//表名
            _WriteDataLog = true;//是否保存日志
            _DataDictBridge = BridgeFactory.CreateDataDictBridge(typeof(TblDriversInfo));
            _MyBridge = this.CreateBridge();
            SelectedCarData = DataDictCache.Cache.CommonDataDriversVehicleRelation.Clone();
            SelectedCarData.TableName = TblDriversVehicleRelation.__TableName;
            AvailableCarData = DataDictCache.Cache.CommonDataDriversVehicleRelation.Clone();
        }

        /// <summary>
        /// 创建桥接通信通道
        /// </summary>
        /// <returns></returns>
        private IBridgeDriversInfo CreateBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirectDriversInfo().GetInstance();
            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WebServiceDriversInfo();
            return null;
        }
        public DataTable FuzzySearch(string content)
        {
          return  _MyBridge.FuzzySearch(content);
        }
        public DataTable GetSummaryByParam(string strName, string strIdNum, string strTel, string strMobile)
        {
            return _MyBridge.GetSummaryByParam(
                Globals.RemoveInjection(strName, 16),
                Globals.RemoveInjection(strIdNum, 20),  Globals.RemoveInjection(strTel,16),  Globals.RemoveInjection(strMobile,20));
        }

        protected override void SetDefault(DataTable data)
        {
            //司机的设置默认值
           // data.Columns[TblDriversInfo.Id].DefaultValue = Guid.NewGuid().ToString("N");
            data.Columns[TblDriversInfo.Sex].DefaultValue = 1;
        }

        public override DataTable GetSummaryData(bool resetCurrent)
        {
            DataTable data = DataDictCache.Cache.CommonDataDictDriversInfo;
            this.SetDefault(data);
            if (resetCurrent) _SummaryTable = data;
            return data;
        }

        /// <summary>
        /// 保存数据字典
        /// </summary>
        /// <param name="updateType">本次操作状态(新增/修改)</param>
        /// <returns></returns>
        public override bool Update(UpdateType updateType)
        {
            //DataTable original = null; //如启用日志功能记录本次修改
            if (_WriteDataLog)
            {
                //original = _DataDictBridge.GetDataByKey(key); //保存前的原始数据
                this.WriteLog();//保存修改日志
            }
            //提交缓存数据，确保输入框的数据已提交到绑定的数据源，将记录状态改变Unchanged.
            _DataBinder.AcceptChanges();
            //再还原记录的状态
            if (updateType == UpdateType.Modify) _DataBinder.Rows[0].SetModified();
            if (updateType == UpdateType.Add) _DataBinder.Rows[0].SetAdded();
            //创建一个副本用于保存
            DataSet data = new DataSet();
            data.Tables.Add(_DataBinder.Copy());
            data.Tables.Add(SelectedCarData.Copy());//子表的更新
            //取当前记录的主键值
            string key = ConvertEx.ToString(_DataBinder.Rows[0][_KeyFieldName]);           
            //调用数据层的方法提交数据
            return _DataDictBridge.Update(data);
        }
       
    }
}
