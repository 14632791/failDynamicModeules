using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Metro.DynamicModeules.BaseControls.ControlEx;
using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.BLL.Security;
using Metro.DynamicModeules.Interface.Sys;
using Metro.DynamicModeules.Models.Sys;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using Metro.DynamicModeules.BLL;
using Metro.DynamicModeules.BaseControls.Commands;
using Metro.DynamicModeules.Common;

namespace Metro.DynamicModeules.BaseControls.ViewModel
{
    /// <summary>
    /// 模板子项的基类
    /// </summary>
    public abstract class ChildBaseViewModel : CommonModuleBaseViewModel, IDataOperatable, IMdiChildViewModel, IPurviewControllable//ISystemButtons
    {
        public ChildBaseViewModel()
        {
        }
        protected FlipPanel _flipPanel
        {
            get
            {
                return (FlipPanel)Owner;
            }
        }

        ICommand _closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand(() =>
                {
                    if (DataHasChanged())
                    {
                        //        e.Cancel = !Msg.AskQuestion("您修改了数据没有保存，确定要退出吗?");
                    }
                    if (MdiMainWindow.TabPages.Contains(this))
                    {
                        MdiMainWindow.TabPages.Remove(this);
                    }
                }));
            }
        }
        /// <summary>
        /// 单击该控件时，打开对应的控件
        /// </summary>
        public ICommand OpenOwnerCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new RelayCommand(OnOpenOwner));
            }
        }
        ICommand _clickCommand;
        protected virtual void OnOpenOwner()
        {
            if (!MdiMainWindow.TabPages.Contains(this))
            {
                MdiMainWindow.TabPages.Add(this);
            }
            if (MdiMainWindow.FocusedPage != this)
            {
                MdiMainWindow.FocusedPage = this;
            }
        }

        tb_MyMenu _item;
        /// <summary>
        /// 对应的子项实体
        /// </summary>
        public tb_MyMenu MyMenu
        {
            get
            {
                return _item;
            }
            set
            {
                _item = value;
                RaisePropertyChanged(() => MyMenu);
            }
        }
        protected abstract Task<tb_MyMenu> GetMenu();

        IList<IButtonInfo> _buttons;
        /// <summary>
        /// 初始化子窗体的按钮数组
        /// </summary>
        public IList<IButtonInfo> Buttons
        {
            get
            {
                return _buttons;
            }
            set
            {
                _buttons = value;
                RaisePropertyChanged(() => Buttons);
            }
        }

        //ObservableCollection<ButtonInfoViewModel> _systemButtons = new ObservableCollection<ButtonInfoViewModel>();
        ///// <summary>
        ///// 子窗体的系统按钮
        ///// </summary>
        //public ObservableCollection<ButtonInfoViewModel> SystemButtons
        //{
        //    get
        //    {
        //        return _systemButtons;
        //    }
        //    set
        //    {
        //        _systemButtons = value;
        //        RaisePropertyChanged(() => SystemButtons);
        //    }
        //}

        /// <summary>
        /// 数据操作状态
        /// </summary>
        private DataRowState _updateType = DataRowState.Unchanged;
        public DataRowState UpdateType
        {
            get
            {
                return _updateType;
            }
            set
            {
                _updateType = value;
                RaisePropertyChanged(() => UpdateType);
                switch (UpdateType)
                {
                    case DataRowState.Added:
                        UpdateTypeName = "(新增模式)";
                        break;
                    case DataRowState.Deleted:
                        UpdateTypeName = "(删除模式)";
                        break;
                    case DataRowState.Modified:
                        UpdateTypeName = "(修改模式)";
                        break;
                    default:
                        UpdateTypeName = "(查看模式)";
                        break;
                }
            }
        }

        string _updateTypeName;
        public string UpdateTypeName
        {
            get
            {
                return _updateTypeName;
            }
            set
            {
                _updateTypeName = value;
                RaisePropertyChanged(() => UpdateTypeName);
            }
        }

        /// <summary>
        /// 判断数据是否有改变
        /// </summary>
        /// <returns></returns>
        public virtual bool DataHasChanged()
        {
            return true;
        }

        /// <summary>
        /// 是否允许用户操作数据
        /// </summary>
        protected bool _allowDataOperate;

        /// <summary>
        /// 是否允许用户操作数据
        /// </summary>
        //public bool AllowDataOperate
        //{
        //    get { return _allowDataOperate; }
        //    set
        //    {
        //        _allowDataOperate = value;
        //        this.SetViewMode();
        //    }
        //}

        /// <summary>
        /// 当操作状态发生变化时,按钮的可用属性也会变
        /// </summary>        
        protected virtual void ButtonStateChanged(DataRowState currentState)
        {
            //PackIconModern _3dCollada;  //PackIconControl<PackIconModernKind>
            //PackIconEntypo AircraftLand;  //PackIconControl<PackIconEntypoKind>
            //PackIconSimpleIcons Amazon;  // PackIconControl<PackIconSimpleIconsKind>

        }
        /// <summary>        
        ///设置为查看模式
        ///数据操作两种状态.1：数据修改状态 2：查看数据状态 
        /// </summary>
        protected virtual void SetViewMode()
        {
            _flipPanel.IsFlipped = false;
            foreach (ButtonInfoViewModel button in Buttons)
            {
                button.IsEnabled = ButtonAuthorized(button.AuthorityItem.AuthorityValue.Value);
            }
        }

        /// <summary>        
        ///设置为编辑模式
        /// </summary>
        protected virtual void SetEditMode()
        {
            _flipPanel.IsFlipped = true;
            foreach (ButtonInfoViewModel button in Buttons)
            {
                button.IsEnabled = false;
            }
        }

        #region IPurviewControllable 接口实现



        /// <summary>
        /// 检查按钮的权限
        /// </summary>
        public virtual bool ButtonAuthorized(int authorityValue)
        {
            //超级用户拥有所有权限
            //窗体可用权限=2^n= 1+2+4=7
            //比如新增功能点是2,那么检查新增按钮的方法是：  2 & 7 = 2，表示有权限。
            bool isAuth = DataDictCache.Instance.LoginUser.FlagAdmin == "Y" || (authorityValue & this.MyMenu.Authorities) == authorityValue;
            return isAuth;
        }


        /// <summary>
        /// 检查当前用户是否拥有本窗体的特定权限
        /// </summary>
        /// <param name="authorityValue">需要检查的权限值</param>
        /// <returns></returns>
        public bool HasPurview(int value)
        {
            return true;// (value & _formAuthorities) == value;
        }

        /// <summary>
        /// 该界面的功能点
        /// </summary>
        //public ObservableCollection<ButtonInfoViewModel> Authoritys
        //{
        //    get; set;
        //}
        public IModuleBase IModule { get; set; }

        #endregion

        #region IMdiChildForm 接口实现



        /// <summary>
        /// 模板方法.初始化本窗体的按钮.
        ///  </summary>
        public virtual void InitButtons()
        {
            Buttons = new ObservableCollection<IButtonInfo>();
            var bi = this.GetSystemButtons();
            var bi2 = GetDataOperatableButtons();
            foreach (var item in bi)
            {
                Buttons.Add((ButtonInfoViewModel)item);
            }
            foreach (var item in bi2)
            {
                Buttons.Add((ButtonInfoViewModel)item);
            }
        }

        /// <summary>
        /// 系统按钮列表。注：子窗体享用系统按钮，如帮助/关闭窗体常用功能。默认有增删查改
        /// </summary>        
        public virtual IList GetSystemButtons()
        {
            List<ButtonInfoViewModel> btns = new List<ButtonInfoViewModel>();
            btns.AddRange(
                new List<ButtonInfoViewModel>
                {
                    AuthorityItemsMgr.GenerateButton(AuthorityItemType.Close, this),
                    AuthorityItemsMgr.GenerateButton(AuthorityItemType.CloseBox, this),
                    AuthorityItemsMgr.GenerateButton(AuthorityItemType.Question, this),
        });

            return btns;
        }



        public virtual async void InitMenu()
        {
            MyMenu = await GetMenu();
        }
        /// <summary>
        /// 这里要加增删查改或自定义按钮
        /// </summary>
        /// <returns></returns>
        protected virtual IList GetDataOperatableButtons()
        {
            List<ButtonInfoViewModel> btns = new List<ButtonInfoViewModel>();
            btns.AddRange(
               new List<ButtonInfoViewModel>
               {
                    AuthorityItemsMgr.GenerateButton(AuthorityItemType.Add, this),
                    AuthorityItemsMgr.GenerateButton(AuthorityItemType.Delete, this),
                    AuthorityItemsMgr.GenerateButton(AuthorityItemType.Search, this),
                    AuthorityItemsMgr.GenerateButton(AuthorityItemType.EditBox, this)
       });
            return btns;
        }
        #endregion


        #region IDataOperatable的接口

        public virtual void DoHelp()
        {
            //Msg.AskQuestion("帮助文档!");
        }

        public virtual void DoClose()
        {
            //NotifyObserver();
        }
        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="sender"></param>
        public virtual void DoAdd()
        {
            UpdateType = DataRowState.Added;
            //this.SetEditMode();
            //this.ButtonStateChanged(_updateType);
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="sender"></param>
        public virtual void DoEdit()
        {
            UpdateType = DataRowState.Modified;
            this.SetEditMode();
            this.ButtonStateChanged(UpdateType);
        }

        /// <summary>
        /// 取消新增或修改
        /// </summary>
        /// <param name="sender"></param>
        public virtual void DoCancel()
        {
            try
            {
                this.SetViewMode();
                this.ButtonStateChanged(UpdateType);

                if (UpdateType == DataRowState.Added)
                {
                    SetViewMode();
                }
                //else if (RowCount > 0)
                //{
                //    //this.DoViewContent(row);
                //}
                UpdateType = DataRowState.Unchanged;
            }
            catch (Exception e)
            {
                // Msg.ShowException(e);
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        public virtual void DoSave()
        {
            UpdateType = DataRowState.Unchanged;
            this.SetViewMode();
            //this.ShowDetailPage(false);
            this.ButtonStateChanged(_updateType);
            //return true;
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="sender"></param>
        public virtual void DoDelete()
        {

        }

        /// <summary>
        /// 查看数据
        /// </summary>
        public virtual void DoViewContent()
        {

        }



        public virtual void SetButtonAuthority()
        {

        }

        public virtual void DoCloseBox()
        {

        }

        public virtual void DoHistory()
        {

        }

        public virtual void DoApprove()
        {

        }
        /// <summary>
        /// 变更
        /// </summary>
        public virtual void DoChange()
        {

        }

        public virtual void DoPrint()
        {

        }

        public virtual void DoPreview()
        {

        }

        public virtual void DoTrashSolid()
        {

        }

        public virtual void DoReceipt()
        {

        }

        public virtual void DoCopySolid()
        {

        }

        public virtual void DoExport()
        {

        }

        public virtual void DoLock()
        {

        }


        public virtual void DoAttachment()
        {

        }

        public virtual void DoVersions()
        {

        }

        public virtual void DoSearch()
        {

        }

        #endregion

        public override async void Initialize()
        {
            base.Initialize();
            Icon = GetIcon();
            Owner = GetOwner(); //指定窗体
            Owner.DataContext = this;
            await Task.Factory.StartNew(InitMenu);
            InitButtons();
            this.SetViewMode();//预设为数据查看模式
        }
        protected override Control GetOwner()
        {
            Owner = new FlipPanel();
            return Owner;
        }

        /// <summary>
        /// 当被选中时的方法
        /// </summary>
        protected override void OnChecked()
        {
            try
            {
                base.OnChecked();
                IModule.IsSelfTrigger = false;
                //遍历IModule的所有子集
                if (IModule.SubModuleList.All(c => c.Checked.HasValue&& c.Checked.Value))
                {
                    IModule.Checked = true;
                }
                else if (IModule.SubModuleList.Any(c => c.Checked.HasValue && c.Checked.Value))
                {
                    IModule.Checked = null;
                }
                else
                {
                    IModule.Checked = false;
                }
                //向下兼容
                if (!Checked.HasValue)
                {
                    return;
                }
                foreach (var item in Buttons)
                {
                    item.IsSelfTrigger = false;
                    item.Checked = Checked.Value;
                    item.IsSelfTrigger = true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            finally
            {
                IModule.IsSelfTrigger = true;
            }
        }
    }
}
