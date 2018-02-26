using MahApps.Metro.IconPacks;
using Metro.DynamicModeules.Interface.Sys;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Metro.DynamicModeules.BaseControls.Views
{
    /// <summary>
    /// BaseChildView.xaml 的交互逻辑,子窗体基类
    /// </summary>
    public partial class BaseChildView : UserControl, IMdiChildWindow, IPurviewControllable, ISystemButtons
    {
        public BaseChildView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 父窗体的Toolbar组件
        /// </summary>
        protected IToolbarRegister _toolbarRegister = null;

        /// <summary>
        /// 初始化子窗体的按钮数组
        /// </summary>
        protected List<IButtonInfo> _buttons = new List<IButtonInfo>();

        /// <summary>
        /// 子窗体的观察者
        /// </summary>
        protected IList _observers = new ArrayList();

        /// <summary>
        /// 子窗体的系统按钮
        /// </summary>
        protected List<IButtonInfo> _systemButtons = new List<IButtonInfo>();

        /// <summary>
        /// 窗体是否正在关闭状态
        /// </summary>
        protected bool _isClosing = false;

        /// <summary>
        /// 否只保留一个子窗体实例
        /// </summary>
        protected bool _allowMultiInstatnce = false;

        /// <summary>
        /// 窗体的可用权限
        /// </summary>
        protected int _formAuthorities = 0;

        /// <summary>
        /// 打开窗体的菜单名
        /// </summary>
        protected string _formMenuName = "";


        #region IPurviewControllable 接口实现

        /// <summary>
        /// 窗体可用权限.为2^n方:1,2,4,8,16.....n^2
        /// 打开窗体时从数据库获取权限值保存在该变量
        /// </summary>
        public int FormAuthorities
        {
            get
            {
                return _formAuthorities;
            }
            set
            {
                _formAuthorities = value;
            }
        }

        /// <summary>
        ///  打开窗体的菜单名
        /// </summary>
        public string FormMenuName
        {
            get
            {
                return _formMenuName;
            }
            set
            {
                _formMenuName = value;
            }
        }

        /// <summary>
        /// 派生类通过重写该虚方法自定义每个按钮可用状态
        /// </summary>
        public virtual bool ButtonAuthorized(int authorityValue)
        {
            return false;
        }

        /// <summary>
        /// 系统是否只保留一个子窗体实例
        /// </summary>
        public bool AllowMultiInstatnce
        {
            get
            {
                return _allowMultiInstatnce;
            }
            set
            {
                _allowMultiInstatnce = value;
            }
        }

        /// <summary>
        /// 检查当前用户是否拥有本窗体的特定权限
        /// </summary>
        /// <param name="authorityValue">需要检查的权限值</param>
        /// <returns></returns>
        public bool HasPurview(int value)
        {
            return (value & _formAuthorities) == value;
        }

        /// <summary>
        /// 可以通过外部调用该方法重新设置按钮权限.
        /// </summary>
        public virtual void SetButtonAuthority() { }

        #endregion

        #region IMdiChildForm 接口实现

        /// <summary>
        /// 主窗体的Toolbar按钮注册器
        /// </summary>
        public IToolbarRegister ToolbarRegister
        {
            get { return _toolbarRegister; }
            set { _toolbarRegister = value; }
        }

        public virtual void RegisterToolBar(IToolbarRegister toolBarRegister)
        {
            //this.Buttons是当前窗体的按钮数组。
            toolBarRegister.RegisteButton(this.Buttons.ToList());
        }

        /// <summary>
        /// 当前窗体是否正在关闭状态
        /// </summary>
        public bool IsClosing { get { return _isClosing; } set { _isClosing = value; } }

        /// <summary>
        /// 注册子窗体观察者
        /// </summary>        
        public void RegisterObserver(IObserver[] observers)
        {
            foreach (IObserver o in observers) _observers.Add(o);
        }

        /// <summary>
        /// 子窗体的按钮数组
        /// </summary>
        public List<IButtonInfo> Buttons { get { return _buttons; } }
        

        public int ChildAuthorities
        {
            get; set;
        }
        public string MenuName
        {
            get; set;
        }

        /// <summary>
        /// 模板方法.初始化本窗体的按钮.
        ///  </summary>
        public virtual void InitButtons()
        {
            var bi = this.GetSystemButtons();
            _buttons.AddRange(bi);
        }

        /// <summary>
        /// 系统按钮列表。注：子窗体享用系统按钮，如帮助/关闭窗体常用功能。
        /// </summary>        
        public virtual List<IButtonInfo> GetSystemButtons()
        {
            if (_systemButtons == null)
            {
                _systemButtons.Add(this.ToolbarRegister.CreateButton("btnHelp", "帮助",
                    PackIconModernKind.BookPerspectiveHelp, new Size(57, 28), this.DoHelp));
                _systemButtons.Add(this.ToolbarRegister.CreateButton("btnClose", "关闭(F7)",
                   PackIconModernKind.WindowClosed, new Size(57, 28), this.DoClose));
            }
            return _systemButtons;
        }

        public virtual void DoHelp(IButtonInfo sender)
        {
            //Msg.AskQuestion("帮助文档!");
        }

        public virtual void DoClose(IButtonInfo sender)
        {
            NotifyObserver();
        }

        #endregion

        //当子窗体获得焦点时注册本窗体的按钮。
        //通过Form Activated事件可以看到主窗体的ToolBar状态变化。
        private void FrmBaseChild_Activated(object sender, EventArgs e)
        {
            this.RegisterToolBar(this.ToolbarRegister);
            this.NotifyObserver(); //通过其它观察者
        }

        //通知观察者进行更新
        private void NotifyObserver()
        {
            foreach (IObserver o in _observers) if (o != null) o.Notify();
        }
    }
}
