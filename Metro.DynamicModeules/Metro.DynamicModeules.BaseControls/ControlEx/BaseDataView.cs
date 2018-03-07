using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Metro.DynamicModeules.BaseControls.ControlEx
{
    public class BaseDataView : Control
    {
        static BaseDataView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseDataView),
             new FrameworkPropertyMetadata(typeof(BaseDataView)));
        }
        public DataGrid DataGrid
        {
            get { return (DataGrid)GetValue(DataGridProperty); }
            set { SetValue(DataGridProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataGrid.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataGridProperty =
            DependencyProperty.Register("DataGrid", typeof(DataGrid), typeof(BaseDataView), new PropertyMetadata(null));

    }
}
