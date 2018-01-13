using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HTX.Models;
using HTX.Common;
using HTX.Core.Interfaces;
using HTX.Server.DataAccess;
using HTX.Core;

/*==========================================
 *   程序说明: GoodsInfo的业务逻辑层
 *   作者姓名: 鸿泰信 www.HTX.com
 *   创建日期: 2015/08/02 09:23:42
 *   最后修改: 2015/08/02 09:23:42
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 鸿泰信 www.HTX.com
 *==========================================*/

namespace HTX.Business
{
    public class BllGoodsInfo : bllBaseDataDict
    {
         public BllGoodsInfo()
         {
             _KeyFieldName = TblGoodsInfo.__KeyName; //主键字段
             _SummaryTableName = TblGoodsInfo.__TableName;//表名
             _WriteDataLog = true;//是否保存日志
             _DAL = new DalGoodsInfo(Loginer.CurrentUser);//数据层的实例
         }
     }
}
