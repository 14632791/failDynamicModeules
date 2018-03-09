using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Metro.DynamicModeules.BaseControls.ControlEx
{
    public class DataChildBaseView : ContentControl
    {
        static DataChildBaseView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DataChildBaseView),
             new FrameworkPropertyMetadata(typeof(DataChildBaseView)));
        }


        public object BackContent
        {
            get { return (object)GetValue(BackContentProperty); }
            set { SetValue(BackContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackContentProperty =
            DependencyProperty.Register("BackContent", typeof(object), typeof(DataChildBaseView), new PropertyMetadata(0));
              
    }
}
