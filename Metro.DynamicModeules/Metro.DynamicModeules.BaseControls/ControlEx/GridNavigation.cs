﻿using Metro.DynamicModeules.BaseControls.Commands;
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
        /// 总页数
        /// </summary>
        public int Total
        {
            get { return (int)GetValue(TotalProperty); }
            set { SetValue(TotalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Total.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TotalProperty =
            DependencyProperty.Register("Total", typeof(int), typeof(GridNavigation), new PropertyMetadata(0));



        /// <summary>
        /// 当前页数
        /// </summary>
        public int CurrentPage
        {
            get { return (int)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentPage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register("CurrentPage", typeof(int), typeof(GridNavigation), new PropertyMetadata(0));


    }
        
}
