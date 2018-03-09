using GalaSoft.MvvmLight;
using MahApps.Metro.IconPacks;
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

namespace Metro.DynamicModeules.BaseControls.ViewModel
{
    /// <summary>
    /// 模板子项的基类
    /// </summary>
    //[Export(typeof(IMdiChildWindow))]
    public abstract class ChildBaseViewModel : ModuleBaseViewModel, IMdiChildWindow, ISystemButtons//IPurviewControllable
    {
      

        tb_MyMenu _subItem;
        /// <summary>
        /// 对应的子项实体
        /// </summary>
        public tb_MyMenu SubItem
        {
            get
            {
                return _subItem;
            }
            set
            {
                _subItem = value;
                RaisePropertyChanged(() => SubItem);
            }
        }

        ObservableCollection<IButtonInfo> _buttons = new ObservableCollection<IButtonInfo>();
        /// <summary>
        /// 初始化子窗体的按钮数组
        /// </summary>
        public ObservableCollection<IButtonInfo> Buttons {
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

        ObservableCollection<IButtonInfo> _systemButtons = new ObservableCollection<IButtonInfo>();
        /// <summary>
        /// 子窗体的系统按钮
        /// </summary>
        public ObservableCollection<IButtonInfo> SystemButtons
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
        /// 可以通过外部调用该方法重新设置按钮权限.
        /// </summary>
        public abstract void SetButtonAuthority();

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
        public virtual List<IButtonInfo> GetSystemButtons()
        {
            return new List<IButtonInfo>();
            //if (SystemButtons == null)
            //{
            //    //_systemButtons.Add(this.ToolbarRegister.CreateButton("btnHelp", "帮助",
            //    //    PackIconModernKind.BookPerspectiveHelp, new Size(57, 28), this.DoHelp));
            //    //_systemButtons.Add(this.ToolbarRegister.CreateButton("btnClose", "关闭(F7)",
            //    //   PackIconModernKind.WindowClosed, new Size(57, 28), this.DoClose));
            //}
            //return _systemButtons;
        }

        public virtual void DoHelp(IButtonInfo sender)
        {
            //Msg.AskQuestion("帮助文档!");
        }

        public virtual void DoClose(IButtonInfo sender)
        {
            //NotifyObserver();
        }

        public override void InitMenu()
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
