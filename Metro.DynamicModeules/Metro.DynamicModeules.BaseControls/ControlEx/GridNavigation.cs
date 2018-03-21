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
    public class GridNavigation : Control
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


        /// <summary>
        /// 最后一条提示
        /// </summary>
        public string LastTip
        {
            get { return (string)GetValue(LastTipProperty); }
            set { SetValue(LastTipProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LastTip.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LastTipProperty =
            DependencyProperty.Register("LastTip", typeof(string), typeof(GridNavigation), new PropertyMetadata("最后一页"));



        public string FirstTip
        {
            get { return (string)GetValue(FirstTipProperty); }
            set { SetValue(FirstTipProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FirstTip.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FirstTipProperty =
            DependencyProperty.Register("FirstTip", typeof(string), typeof(GridNavigation), new PropertyMetadata("第一页"));



        public string NextTip
        {
            get { return (string)GetValue(NextTipProperty); }
            set { SetValue(NextTipProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NextTip.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NextTipProperty =
            DependencyProperty.Register("NextTip", typeof(string), typeof(GridNavigation), new PropertyMetadata("下一页"));



        public string PreviousTip
        {
            get { return (string)GetValue(PreviousTipProperty); }
            set { SetValue(PreviousTipProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PreviousTip.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PreviousTipProperty =
            DependencyProperty.Register("PreviousTip", typeof(string), typeof(GridNavigation), new PropertyMetadata("上一页"));


        /// <summary>
        /// 提示类型，默认0为页，1为行
        /// </summary>
        public int TipType
        {
            get { return (int)GetValue(TipTypeProperty); }
            set { SetValue(TipTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TipType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TipTypeProperty =
            DependencyProperty.Register("TipType", typeof(int), typeof(GridNavigation), new PropertyMetadata(0, new PropertyChangedCallback((sender, e) =>
            {
                GridNavigation nav = (GridNavigation)sender;
                if (null == sender)
                {
                    return;
                }
                switch (nav.TipType)
                {
                    case 0:
                        nav.LastTip = "最后一页";
                        nav.FirstTip = "第一页";
                        nav.NextTip = "下一页";
                        nav.PreviousTip = "上一页";
                        break;
                    case 1:
                        nav.LastTip = "最后一行";
                        nav.FirstTip = "第一行";
                        nav.NextTip = "下一行";
                        nav.PreviousTip = "上一行";
                        break;
                    default:
                        break;
                }
            })));


    }

}
