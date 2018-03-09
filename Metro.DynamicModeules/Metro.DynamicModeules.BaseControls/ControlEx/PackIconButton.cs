using Metro.DynamicModeules.Interface.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using MahApps.Metro.IconPacks;
using System.Windows.Input;
using System.Windows;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Models.Sys;

namespace Metro.DynamicModeules.BaseControls.ControlEx
{
    /// <summary>
    /// 带权限值的icon button
    /// </summary>
    public class PackIconButton : Button, IButtonInfo
    {
        static PackIconButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PackIconButton),
               new FrameworkPropertyMetadata(typeof(PackIconButton)));
        }
      
        /// <summary>
        /// 排序
        /// </summary>
        public int Index
        {
            get { return (int)GetValue(IndexProperty); }
            set { SetValue(IndexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Index.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IndexProperty =
            DependencyProperty.Register("Index", typeof(int), typeof(PackIconButton), new PropertyMetadata(0));



        /// <summary>
        /// 对应的实体
        /// </summary>
        public tb_MyAuthorityItem MyAuthorityItem
        {
            get { return (tb_MyAuthorityItem)GetValue(MyAuthorityItemProperty); }
            set { SetValue(MyAuthorityItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Button.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyAuthorityItemProperty =
            DependencyProperty.Register("MyAuthorityItem", typeof(tb_MyAuthorityItem), typeof(PackIconButton), new PropertyMetadata(null));

               
       
        public PackIconControl<object> Icon
        {
            get { return (PackIconControl<object>)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
     

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(PackIconControl<object>), typeof(PackIconButton), new PropertyMetadata(null));

        /// <summary>
        /// 要执行的方法
        /// </summary>
        public ICommand ClickCommand { get; set; }
    }
}
