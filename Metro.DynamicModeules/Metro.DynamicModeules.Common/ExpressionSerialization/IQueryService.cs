// 源文件头信息：
// <copyright file="IQueryService.cs">
// Copyright(c)2012-2012 EBOOOY.All rights reserved.
// CLR版本：4.0.30319.239




// 创建时间：2012/04/08 6:49
// 最后修改：2012/04/08 7:49
// </copyright>

using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Xml.Linq;


namespace Metro.DynamicModeules.Common.ExpressionSerialization
{
    /// <summary>
    ///   WCF Web HTTP (REST) query service. Derive your ServiceContract from this.
    /// </summary>
    [ServiceContract]
    public interface IQueryService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/execute", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare)]
        object[] ExecuteQuery(XElement xml);
    }
}