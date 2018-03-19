using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using XHClient.UpdateClient.Common;

namespace XHClient.UpdateClient.Controls
{

    [TemplateVisualState(GroupName = CommonStates, Name = NormalState)]
    [TemplateVisualState(GroupName = CommonStates, Name = DisabledState)]
    [TemplatePart(Name = SwitchPart, Type = typeof(ToggleSwitch))]
    public class ToggleSwitch : ContentControl
    {
        private const string CommonStates = "CommonStates";
        private const string NormalState = "Normal";
        private const string DisabledState = "Disabled";
        private const string SwitchPart = "PART_Switch";
        private const string PART_DraggingThumb = "PART_DraggingThumb";

       // private ToggleButton _toggleButton;

        public static readonly DependencyProperty OffSwitchBrushProperty = DependencyProperty.RegisterAttached("OffSwitchBrush", typeof(Brush), typeof(ToggleSwitch), null);
        public static readonly DependencyProperty OnSwitchBrushProperty = DependencyProperty.RegisterAttached("OnSwitchBrush", typeof(Brush), typeof(ToggleSwitch), null);
        public static readonly DependencyProperty ThumbIndicatorBrushProperty = DependencyProperty.RegisterAttached("ThumbIndicatorBrush", typeof(Brush), typeof(ToggleSwitch), null);
        public static readonly DependencyProperty ThumbIndicatorDisabledBrushProperty = DependencyProperty.RegisterAttached("ThumbIndicatorDisabledBrush", typeof(Brush), typeof(ToggleSwitch), null);
        public static readonly DependencyProperty ThumbIndicatorWidthProperty = DependencyProperty.RegisterAttached("ThumbIndicatorWidth", typeof(double), typeof(ToggleSwitch));
        public static readonly DependencyProperty RadiusDataProperty = DependencyProperty.RegisterAttached("RadiusData", typeof(double), typeof(ToggleSwitch), new PropertyMetadata(5.0));
        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register("IsChecked", typeof(bool), typeof(ToggleSwitch), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnIsCheckedChanged));
        public static readonly DependencyProperty IsPressedProperty = DependencyProperty.RegisterAttached("IsPressed", typeof(bool), typeof(ToggleSwitch), new PropertyMetadata(false));

       // public event EventHandler<RoutedEventArgs> Click;




        private static void OnIsCheckedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Thumb _DraggingThumb = GetTemplateChild("PART_DraggingThumb") as Thumb;
            if (_DraggingThumb != null)
            {
                _DraggingThumb.DragCompleted -= _DraggingThumb_DragCompleted;
                _DraggingThumb.DragStarted += _DraggingThumb_DragStarted;
                _DraggingThumb.DragCompleted += _DraggingThumb_DragCompleted;
            }
        }

        void _DraggingThumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            this.SetValue(IsPressedProperty, true);
            //throw new NotImplementedException();
        }

        private void _DraggingThumb_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            try
            {
                this.SetValue(IsPressedProperty,false);
                this.SetValue(IsCheckedProperty, !(bool)GetValue(IsCheckedProperty));
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("ToggleSwitch->_DraggingThumb_DragCompleted", ex);
            }
        }

        public static void SetOffSwitchBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(OffSwitchBrushProperty, value);
        }

        public static Brush GetOffSwitchBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(OffSwitchBrushProperty);
        }

        public static void SetOnSwitchBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(OnSwitchBrushProperty, true);
        }

        public static Brush GetOnSwitchBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(OnSwitchBrushProperty);
        }

        public Brush ThumbIndicatorBrush
        {
            get { return (Brush)GetValue(ThumbIndicatorBrushProperty); }
            set { SetValue(ThumbIndicatorBrushProperty, value); }
        }

        public Brush ThumbIndicatorDisabledBrush
        {
            get { return (Brush)GetValue(ThumbIndicatorBrushProperty); }
            set { SetValue(ThumbIndicatorBrushProperty, value); }
        }

        public double ThumbIndicatorWidth
        {
            get { return (double)GetValue(ThumbIndicatorWidthProperty); }
            set { SetValue(ThumbIndicatorWidthProperty, value); }
        }

        public double RadiusData
        {
            get { return (double)GetValue(RadiusDataProperty); }
            set { SetValue(RadiusDataProperty, value); }
        }

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        public bool IsPressed
        {
            get { return (bool)GetValue(IsPressedProperty); }
            set { SetValue(IsPressedProperty, value); }
        }
    }
}
