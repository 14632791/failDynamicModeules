using GalaSoft.MvvmLight;
using MahApps.Metro.IconPacks;
using Metro.DynamicModeules.Interface.Sys;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Models.Sys;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Metro.DynamicModeules.BaseControls.ViewModel
{
    [Export(typeof(IMdiChildWindow))]
    public class BaseChildViewModel : ViewModelBase, IMdiChildWindow//, IPurviewControllable, ISystemButtons
    {
        public BaseChildViewModel()
        {
            
        }

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

            }
        }
        /// <summary>
        /// 按钮矢量图片类型
        /// </summary>
      public  PackIconControl<object> Icon { get; set; }

        /// <summary>
        /// 应用的控件
        /// </summary>
        public Control Owner { get; set; }
        /// <summary>
        /// 初始化子窗体的按钮数组
        /// </summary>
        protected List<IButtonInfo> _buttons = new List<IButtonInfo>();



        /// <summary>
        /// 子窗体的系统按钮
        /// </summary>
        protected List<IButtonInfo> _systemButtons = new List<IButtonInfo>();

    


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
        public virtual void SetButtonAuthority() { }

        #endregion

        #region IMdiChildForm 接口实现

        

       

        /// <summary>
        /// 子窗体的按钮数组
        /// </summary>
        public List<IButtonInfo> Buttons { get { return _buttons; } }


        
        
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
                //_systemButtons.Add(this.ToolbarRegister.CreateButton("btnHelp", "帮助",
                //    PackIconModernKind.BookPerspectiveHelp, new Size(57, 28), this.DoHelp));
                //_systemButtons.Add(this.ToolbarRegister.CreateButton("btnClose", "关闭(F7)",
                //   PackIconModernKind.WindowClosed, new Size(57, 28), this.DoClose));
            }
            return _systemButtons;
        }

        public virtual void DoHelp(IButtonInfo sender)
        {
            //Msg.AskQuestion("帮助文档!");
        }

        public virtual void DoClose(IButtonInfo sender)
        {
            //NotifyObserver();
        }

        #endregion

       
    }
}
