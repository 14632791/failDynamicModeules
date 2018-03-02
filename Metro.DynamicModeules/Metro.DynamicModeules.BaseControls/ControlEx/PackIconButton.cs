using Metro.DynamicModeules.Interface.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using MahApps.Metro.IconPacks;
using System.Windows.Input;
using System.Windows;

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
        /// 标题
        /// </summary>
        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Caption.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(PackIconButton), new PropertyMetadata(""));


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


      
        public object Button { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        public int Authority
        {
            get;set;
        }

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
