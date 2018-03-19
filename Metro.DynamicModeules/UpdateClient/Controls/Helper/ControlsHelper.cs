using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace XHClient.UpdateClient.Controls
{
    public class ControlsHelper
    {
        //圆形的直径
        public static readonly DependencyProperty BigEllipseDiameterProperty = DependencyProperty.RegisterAttached("BigEllipseDiameter", typeof(int), typeof(ControlsHelper), new PropertyMetadata(28));

        //内圆的直径
        public static readonly DependencyProperty InnerEllipseDiameterProperty = DependencyProperty.RegisterAttached("InnerEllipseDiameter", typeof(int), typeof(ControlsHelper), new PropertyMetadata(10));

        public static readonly DependencyProperty InnerBrushProperty = DependencyProperty.RegisterAttached("InnerBrush", typeof(Brush), typeof(ControlsHelper), new PropertyMetadata(new SolidColorBrush(Colors.LightGray)));

        public static readonly DependencyProperty ImageSourcePathProperty = DependencyProperty.RegisterAttached("ImageSourcePath", typeof(ImageSource), typeof(ControlsHelper), new PropertyMetadata(null));

        public static ImageSource GetImageSourcePath(DependencyObject obj)
        {
            return (ImageSource)obj.GetValue(ImageSourcePathProperty);
        }

        public static void SetImageSourcePath(DependencyObject obj, ImageSource value)
        {
            obj.SetValue(ImageSourcePathProperty, value);
        }

        public static int GetBigEllipseDiameter(DependencyObject obj)
        {
            return (int)obj.GetValue(BigEllipseDiameterProperty);
        }
        public static void SetBigEllipseDiameter(DependencyObject obj, object value)
        {
            obj.SetValue(BigEllipseDiameterProperty, value);
        }

        public static int GetInnerEllipseDiameter(DependencyObject obj)
        {
            return (int)obj.GetValue(InnerEllipseDiameterProperty);
        }

        public static void SetInnerEllipseDiameter(DependencyObject obj, object value)
        {
            obj.SetValue(BigEllipseDiameterProperty, value);
        }

        public static Brush GetInnerBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(InnerBrushProperty);
        }

        public static void SetInnerBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(InnerBrushProperty, value);
        }
    }
}
