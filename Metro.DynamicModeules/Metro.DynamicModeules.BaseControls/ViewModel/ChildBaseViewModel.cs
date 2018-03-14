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

namespace Metro.DynamicModeules.BaseControls.ViewModel
{
    /// <summary>
    /// 模板子项的基类
    /// </summary>
    //[Export(typeof(IMdiChildWindow))]
    public abstract class ChildBaseViewModel : CommonModuleBaseViewModel//, IMdiChildWindow, ISystemButtons,IPurviewControllable
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
                return _closeCommand ?? (_closeCommand = new RelayCommand(()=> {
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
            Messenger.Default.Send( MessengerToken.FocusedChild, Owner);
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

        ObservableCollection<ButtonInfoViewModel> _buttons ;
        /// <summary>
        /// 初始化子窗体的按钮数组
        /// </summary>
        public ObservableCollection<ButtonInfoViewModel> Buttons {
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
                _buttons.Add(item);
            }
        }

        /// <summary>
        /// 系统按钮列表。注：子窗体享用系统按钮，如帮助/关闭窗体常用功能。
        /// </summary>        
        public virtual List<ButtonInfoViewModel> GetSystemButtons()
        {
            return new List<ButtonInfoViewModel>();
            //if (SystemButtons == null)
            //{
            //    //_systemButtons.Add(this.ToolbarRegister.CreateButton("btnHelp", "帮助",
            //    //    PackIconModernKind.BookPerspectiveHelp, new Size(57, 28), this.DoHelp));
            //    //_systemButtons.Add(this.ToolbarRegister.CreateButton("btnClose", "关闭(F7)",
            //    //   PackIconModernKind.WindowClosed, new Size(57, 28), this.DoClose));
            //}
            //return _systemButtons;
        }

        public virtual void DoHelp( )
        {
            //Msg.AskQuestion("帮助文档!");
        }

        public virtual void DoClose( )
        {
            //NotifyObserver();
        }

        public void InitMenu()
        {
            throw new NotImplementedException();
        }



        #endregion


    }
}
