using Metro.DynamicModeules.BaseControls.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Metro.DynamicModeules.BaseControls.ControlEx
{
  public  class GridNavigation: Control
    {
        static GridNavigation()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GridNavigation),
               new FrameworkPropertyMetadata(typeof(GridNavigation)));
        }

        public ICommand NavigateCommand
        {
            get { return (ICommand)GetValue(NavigateCommandProperty); }
            set { SetValue(NavigateCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NavigateCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NavigateCommandProperty =
            DependencyProperty.Register("NavigateCommand", typeof(ICommand), typeof(GridNavigation), new PropertyMetadata(null));

        

        /// <summary>
        /// 总数量
        /// </summary>
        public int TotalItems
        {
            get { return (int)GetValue(TotalItemsProperty); }
            set { SetValue(TotalItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TotalItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TotalItemsProperty =
            DependencyProperty.Register("TotalItems", typeof(int), typeof(GridNavigation), new PropertyMetadata(0));



        /// <summary>
        /// 当前数据
        /// </summary>
        public int CurrentItem
        {
            get { return (int)GetValue(CurrentItemProperty); }
            set { SetValue(CurrentItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentItemProperty =
            DependencyProperty.Register("CurrentItem", typeof(int), typeof(GridNavigation), new PropertyMetadata(0));
        

    }
        
}
