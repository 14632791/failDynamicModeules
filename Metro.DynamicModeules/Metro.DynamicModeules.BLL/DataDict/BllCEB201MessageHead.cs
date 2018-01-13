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
 *   程序说明: CEB201MessageHead的业务逻辑层
 *   作者姓名: 鸿泰信 www.HTX.com
 *   创建日期: 2015/08/02 09:39:22
 *   最后修改: 2015/08/02 09:39:22
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 鸿泰信 www.HTX.com
 *==========================================*/

namespace HTX.Business
{
    public class BllCEB201MessageHead : bllBaseDataDict
    {
         public BllCEB201MessageHead()
         {
             _KeyFieldName = TblCEB201MessageHead.__KeyName; //主键字段
             _SummaryTableName = TblCEB201MessageHead.__TableName;//表名
             _WriteDataLog = true;//是否保存日志
             _DAL = new DalCEB201MessageHead(Loginer.CurrentUser);//数据层的实例
         }
     }
}
