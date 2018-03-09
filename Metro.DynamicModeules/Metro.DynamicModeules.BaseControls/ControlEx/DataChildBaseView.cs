using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Metro.DynamicModeules.BaseControls.ControlEx
{
    public class DataChildBaseView : Control
    {
        static DataChildBaseView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DataChildBaseView),
             new FrameworkPropertyMetadata(typeof(DataChildBaseView)));
        }
        public DataGrid DataGrid
        {
            get { return (DataGrid)GetValue(DataGridProperty); }
            set { SetValue(DataGridProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataGrid.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataGridProperty =
            DependencyProperty.Register("DataGrid", typeof(DataGrid), typeof(DataChildBaseView), new PropertyMetadata(null));

    }
}
