using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.IconPacks;
using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.Interface.Sys;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Models.Sys;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using Metro.DynamicModeules.Interface;
using System.Collections;

namespace Metro.DynamicModeules.BaseControls.ViewModel
{
    /// <summary>
    /// 模板子项的基类
    /// </summary>
    //[Export(typeof(IMdiChildWindow))]
    public abstract class ChildBaseViewModel : CommonModuleBaseViewModel, IDataOperatable, IMdiChildWindow, ISystemButtons, IPurviewControllable
    {
        public ChildBaseViewModel()
        {
            MenuItem = GetMenu();
        }
        ICommand _closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand(() =>
                {
                    Messenger.Default.Send(MessengerToken.ClosedTagPage, Owner);
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
            Messenger.Default.Send(MessengerToken.FocusedChild, Owner);
        }

        tb_MyMenu _item;
        /// <summary>
        /// 对应的子项实体
        /// </summary>
        public tb_MyMenu MenuItem
        {
            get
            {
                return _item;
            }
            set
            {
                _item = value;
                RaisePropertyChanged(() => MenuItem);
            }
        }
        protected abstract tb_MyMenu GetMenu();

        ObservableCollection<ButtonInfoViewModel> _buttons;
        /// <summary>
        /// 初始化子窗体的按钮数组
        /// </summary>
        public IList Buttons
        {
            get
            {
                return _buttons;
            }
            set
            {
                _buttons = (ObservableCollection<ButtonInfoViewModel>)value;
                RaisePropertyChanged(() => Buttons);
            }
        }

        ObservableCollection<ButtonInfoViewModel> _systemButtons = new ObservableCollection<ButtonInfoViewModel>();
        /// <summary>
        /// 子窗体的系统按钮
        /// </summary>
        public ObservableCollection<ButtonInfoViewModel> SystemButtons
        {
            get
            {
                return _systemButtons;
            }
            set
            {
                _systemButtons = value;
                RaisePropertyChanged(() => SystemButtons);
            }
        }

        /// <summary>
        /// 数据操作状态
        /// </summary>
        private UpdateType _updateType = UpdateType.None;
        public UpdateType UpdateType
        {
            get
            {
                return _updateType;
            }
            set
            {
                _updateType = value;
                StateName = GetStateName();
            }
        }

        string _stateName;
        /// <summary>
        /// 状态字符
        /// </summary>
        public string StateName
        {
            get
            {
                return _stateName;
            }
            set
            {
                _stateName = value;
                RaisePropertyChanged(() => StateName);
            }
        }


        protected virtual string GetStateName()
        {
            string utype = "(查看模式)";
            switch (_updateType)
            {
                case UpdateType.Add:
                    utype = "(新增模式)";
                    break;
                case UpdateType.Modify:
                    utype = "(修改模式)";
                    break;
                default:
                    break;
            }
            return utype;
        }

        public virtual bool DataChanged
        {
            get;
        }

        /// <summary>
        /// 是否允许用户操作数据
        /// </summary>
        protected bool _allowDataOperate;

        /// <summary>
        /// 是否允许用户操作数据
        /// </summary>
        public bool AllowDataOperate
        {
            get { return _allowDataOperate; }
            set
            {
                _allowDataOperate = value;
                this.SetViewMode();
            }
        }
        /// <summary>        
        ///设置为查看模式
        ///数据操作两种状态.1：数据修改状态 2：查看数据状态 
        /// </summary>
        protected virtual void SetViewMode()
        {
            //_buttons.FirstOrDefault(b=>b.Name=="btnView").IsEnabled = _AllowDataOperate;
            //_buttons.FirstOrDefault(b=>b.Name=="btnAdd").IsEnabled = _AllowDataOperate && ButtonAuthorized(ButtonAuthority.ADD);
            }

        public object Data { get; set; }

        #region IPurviewControllable 接口实现



        /// <summary>
        /// 派生类通过重写该虚方法自定义每个按钮可用状态
        /// </summary>
        public virtual bool ButtonAuthorized(int authorityValue)
        {
            return false;
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
        /// 获取该界面的功能点
        /// </summary>
        public abstract ObservableCollection<tb_MyAuthorityItem> GetAuthoritys();

        #endregion

        #region IMdiChildForm 接口实现



        /// <summary>
        /// 模板方法.初始化本窗体的按钮.
        ///  </summary>
        public virtual void InitButtons()
        {
            var bi = this.GetSystemButtons();
            foreach (var item in bi)
            {
                SystemButtons.Add((ButtonInfoViewModel)item);
            }
        }

        /// <summary>
        /// 系统按钮列表。注：子窗体享用系统按钮，如帮助/关闭窗体常用功能。
        /// </summary>        
        public virtual IList GetSystemButtons()
        {
            return new List<ButtonInfoViewModel>();

        }

        public virtual void DoHelp()
        {
            //Msg.AskQuestion("帮助文档!");
        }

        public virtual void DoClose()
        {
            //NotifyObserver();
        }

        public void InitMenu()
        {
        }

        public IList GetDataOperatableButtons()
        {
            List<ButtonInfoViewModel> list = new List<ButtonInfoViewModel>();
            //list.Add(this.ToolbarRegister.CreateButton("btnView", "查看", PackIconModernKind.SocialReadability, new Size(57, 57), this.DoViewContent));
            //list.Add(this.ToolbarRegister.CreateButton("btnAdd", "新增(F4)", PackIconModernKind.EditAdd, new Size(57, 57), this.DoAdd));
            //list.Add(this.ToolbarRegister.CreateButton("btnDelete", "删除(F6)", PackIconModernKind.Delete, new Size(57, 57), (sender) => { this.DoDelete(sender); }));
            //list.Add(this.ToolbarRegister.CreateButton("btnEdit", "修改(F5)", PackIconModernKind.Edit, new Size(57, 57), this.DoEdit));
            //list.Add(this.ToolbarRegister.CreateButton("btnSave", "保存(F2)", PackIconModernKind.Save, new Size(57, 57), (sender) => { this.DoSave(sender); } ));
            //list.Add(this.ToolbarRegister.CreateButton("btnCancel", "取消(F3)", PackIconModernKind.Cancel, new Size(57, 57), this.DoCancel));
            return list;
        }
        #endregion

       
        #region IDataOperatable的接口

        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="sender"></param>
        public virtual void DoAdd()
        {
            this._updateType = UpdateType.Add;
            //this.SetEditMode();
            //this.ButtonStateChanged(_updateType);
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="sender"></param>
        public virtual void DoEdit()
        {
            this._updateType = UpdateType.Modify;
            //this.SetEditMode();
            //this.ButtonStateChanged(_updateType);
        }

        /// <summary>
        /// 取消新增或修改
        /// </summary>
        /// <param name="sender"></param>
        public virtual void DoCancel()
        {
            try
            {
                this._updateType = UpdateType.None;
                this.SetViewMode();
                //this.ButtonStateChanged(_updateType);

                //if (_updateType == UpdateType.Add)
                //    this.ShowSummaryPage(true);
                //else if (RowCount > 0)
                //{
                //    //this.DoViewContent(row);
                //}
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
            this._updateType = UpdateType.None;
            this.SetViewMode();
            //this.ShowDetailPage(false);
            //this.ButtonStateChanged(_updateType);
            //return true;
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="sender"></param>
        public virtual void DoDelete()
        {

        }

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


    }
}
