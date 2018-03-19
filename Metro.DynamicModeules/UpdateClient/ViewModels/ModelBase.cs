/*************************************************************************************
 * CLR 版本：4.0.30319.42000
 * 机器名称：HUANGHE-WORK
 * 命名空间：Models.Extend
 * 文 件 名：IModelBase
 * 创建时间：2017/4/10 17:45:00
 * 作    者：陈刚
 * 说    明：
 * 修改时间：
 * 修 改 人：
*************************************************************************************/

using System.ComponentModel;

namespace UpdateClient.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                PropertyChanged(this, e);
            }
        }
    }
}
