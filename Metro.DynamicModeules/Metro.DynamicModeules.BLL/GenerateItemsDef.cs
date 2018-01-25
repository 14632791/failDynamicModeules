using Metro.DynamicModeules.Common;
using System;
using System.Data;

namespace Metro.DynamicModeules.BLL
{

    /// <summary>
    /// 生成单据的选择项目.
    /// </summary>
    public interface IGenerateItem
    {
        /// <summary>
        ///项目标题 
        /// </summary>
        string ItemCaption { get; }

        /// <summary>
        ///目标窗体名称 
        /// </summary>
        string TargetFormName { get; }

        /// <summary>
        /// 打开目标窗体对应的菜单名.
        /// </summary>
        string TargetFormMenuName { get; }

        /// <summary>
        ///目标窗体类型 
        /// </summary>
        Type TargetFormType { get; }

        /// <summary>
        /// 标志是否生成成功
        /// </summary>
        bool IsSuccess { get; }

        /// <summary>
        /// 由其它单生成本单时需要用户输入来源单号
        /// </summary>
        bool IsDocNoRequired { get; }

        /// <summary>
        /// 检查来源单据的单号是否存在
        /// </summary>
        /// <param name="DocNo">单据号码</param>
        /// <returns></returns>
        bool IsDocNoExists(string DocNo);

        /// <summary>
        /// 自动生成数据
        /// </summary>
        /// <param name="targetBLL">目标单据的业务逻辑层</param>
        /// <returns></returns>
        //bool Generate(BllBase targetBLL);

        /// <summary>
        /// 设置来源单据的单号
        /// </summary>
        /// <param name="DocNo">业务单据号码</param>
        void SetDocNo(string DocNo);
    }

    /// <summary>
    /// 生成单据项目定义基类
    /// </summary>
    public class IGenerateItemBase : IGenerateItem
    {
        protected bool _IsDocNoRequired;
        protected string _DocNo;
        protected bool _IsSuccess = false;
        protected string _TargetFormName;
        protected Type _TargetFormType = null;
        protected string _ItemCaption;
        protected string _TargetFormMenuName;

        public IGenerateItemBase() { }
        public IGenerateItemBase(string DocNo, bool IsDocNoRequired, Type targetFormType, string targetFormName)
        {
            _DocNo = DocNo;
            _IsDocNoRequired = IsDocNoRequired;
            _TargetFormType = targetFormType;
            _TargetFormName = targetFormName;
        }

        public string TargetFormMenuName { get { return _TargetFormMenuName; } }
        public string ItemCaption { get { return _ItemCaption; } }
        public bool IsSuccess { get { return _IsSuccess; } }
        public Type TargetFormType { get { return _TargetFormType; } }
        public string TargetFormName { get { return _TargetFormName; } }
        public bool IsDocNoRequired { get { return _IsDocNoRequired; } }
        public void SetDocNo(string DocNo) { _DocNo = DocNo; }


        //public virtual bool Generate(BllBaseBusiness targetBLL) { return false; }
        public virtual bool IsDocNoExists(string DocNo) { return false; }
    }


    #region 自动生成项目定义

    /// <summary>
    /// 入库单生成出库单
    /// </summary>
    public class IN_to_IO : IGenerateItemBase
    {
        public IN_to_IO(string DocNo, bool IsDocNoRequired, Type targetFormType, string targetFormName)
        {
            _DocNo = DocNo;
            _IsDocNoRequired = IsDocNoRequired;
            _TargetFormType = targetFormType;
            _TargetFormName = targetFormName;
            _TargetFormMenuName = "menuItemStockOut";
            _ItemCaption = "由入库单(IN)->生成出库(IO)";
        }

        // 由销售报价单生成销售发票
      

        //检查来源单号是否存在
        //public override bool IsDocNoExists(string DocNo)
        //{
        //    if (_IsDocNoRequired)
        //        return new BllIN().CheckNoExists(DocNo);
        //    else
        //        return false;
        //}
    }

    #endregion

}
