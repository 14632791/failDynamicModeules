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

namespace Metro.DynamicModeules.BaseControls.ControlEx
{
    /// <summary>
    /// 带权限值的icon button
    /// </summary>
    public class PackIconButton : Button
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




        public tb_MyAuthorityItem Button
        {
            get { return (tb_MyAuthorityItem)GetValue(ButtonProperty); }
            set { SetValue(ButtonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Button.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonProperty =
            DependencyProperty.Register("Button", typeof(tb_MyAuthorityItem), typeof(PackIconButton), new PropertyMetadata(null));

               
       
        public PackIconControl<object> Icon
        {
            get { return (PackIconControl<object>)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(PackIconControl<object>), typeof(PackIconButton), new PropertyMetadata(null));
        
    }
}
