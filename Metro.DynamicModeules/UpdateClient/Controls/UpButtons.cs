using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Shapes;

namespace XHClient.UpdateClient.Controls
{
    public class UpButtons : Button
    {

        /// <summary>
        /// 内部Path的填充色
        /// </summary>
        public Brush InnerPathFill
        {
            get { return (Brush)GetValue(InnerPathFillProperty); }
            set { SetValue(InnerPathFillProperty, value); }
        }

        public static readonly DependencyProperty InnerPathFillProperty =
            DependencyProperty.Register("InnerPathFill", typeof(Brush), typeof(UpButtons), new PropertyMetadata(Brushes.White));


        /// <summary>
        /// 按键选中时内部Path的填充色
        /// </summary>
        public Brush PressInnerPathFill
        {
            get { return (Brush)GetValue(PressInnerPathFillProperty); }
            set { SetValue(PressInnerPathFillProperty, value); }
        }

        public static readonly DependencyProperty PressInnerPathFillProperty =
            DependencyProperty.Register("PressInnerPathFill", typeof(Brush), typeof(UpButtons), new PropertyMetadata(Brushes.White));

        public static readonly DependencyProperty PressedForegroundProperty =
          DependencyProperty.Register("PressedForeground", typeof(Brush), typeof(UpButtons), new PropertyMetadata(Brushes.White));
        public static readonly DependencyProperty MouseOverForegroundProperty =
 DependencyProperty.Register("MouseOverForeground", typeof(Brush), typeof(UpButtons), new PropertyMetadata(Brushes.White));
        public static readonly DependencyProperty MouseOverBackgroundProperty =
          DependencyProperty.Register("MouseOverBackground", typeof(Brush), typeof(UpButtons), new PropertyMetadata(Brushes.RoyalBlue));
        public static readonly DependencyProperty PressedBackgroundProperty =
   DependencyProperty.Register("PressedBackground", typeof(Brush), typeof(UpButtons), new PropertyMetadata(Brushes.DarkBlue));
        public static readonly DependencyProperty RIconProperty =
          DependencyProperty.Register("RIcon", typeof(ImageSource), typeof(UpButtons), new PropertyMetadata(null));
        public static readonly DependencyProperty CornerRadiusProperty =
         DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(UpButtons), new PropertyMetadata(new CornerRadius(0)));

        public static readonly DependencyProperty NavIdProperty = DependencyProperty.Register("NavId", typeof(string), typeof(UpButtons), new PropertyMetadata(null));
        public static readonly DependencyProperty AllowRIconProperty =
       DependencyProperty.Register("AllowRIcon", typeof(Visibility), typeof(UpButtons), new PropertyMetadata(System.Windows.Visibility.Visible));

        //是否需要启用选择按钮选中
        public static readonly DependencyProperty IsNeedSelectedProperty = DependencyProperty.RegisterAttached("IsNeedSelected", typeof(bool), typeof(UpButtons), new PropertyMetadata(false));
        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.RegisterAttached("IsSelected", typeof(bool), typeof(UpButtons), new PropertyMetadata(false));
        public static readonly DependencyProperty GroupNameProperty = DependencyProperty.RegisterAttached("GroupName", typeof(string), typeof(UpButtons), new PropertyMetadata(""));
        public static readonly DependencyProperty PathDataProperty = DependencyProperty.RegisterAttached("PathData", typeof(Geometry), typeof(UpButtons), new PropertyMetadata(null, PathDataChanged));
        public static readonly DependencyProperty HasPathDataProperty = DependencyProperty.RegisterAttached("HasPathData", typeof(bool), typeof(UpButtons), new PropertyMetadata(false));
        //public static readonly DependencyProperty DesertNavIdProperty = DependencyProperty.RegisterAttached("DesertNavId", typeof(string), typeof(Buttons), new PropertyMetadata(""));
        //和GroupNameProperty配合使用
        private static Dictionary<string, List<UpButtons>> Dic = new Dictionary<string, List<UpButtons>>();
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            Border border = this.GetTemplateChild("PART_Background") as Border;
            if (border == null)
                return;
            if ((bool)this.GetValue(IsNeedSelectedProperty))
            {
                border.MouseDown -= thumb_MouseDown;
                border.MouseDown += thumb_MouseDown;
            }
            //是否需要并组
            string groupName = (string)this.GetValue(GroupNameProperty);
            if (!string.IsNullOrEmpty(groupName))
            {
                List<UpButtons> listButtons = new List<UpButtons>();
                if (Dic.ContainsKey(groupName))
                    listButtons = Dic[groupName];
                else
                    Dic.Add(groupName, listButtons);
                listButtons.Add(this);
            }
        }

        void thumb_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            string groupName = (string)this.GetValue(GroupNameProperty);
            if (!string.IsNullOrEmpty(groupName) && Dic.ContainsKey(groupName))
            {
                List<UpButtons> list = Dic[groupName];
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].SetValue(IsSelectedProperty, false);
                }
            }
            this.SetValue(IsSelectedProperty, true);
        }

        private static void PathDataChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is Geometry)
            {
                UpButtons btn = d as UpButtons;
                btn.SetValue(HasPathDataProperty, true);
            }
        }

        public string GroupName
        {
            get { return (string)GetValue(GroupNameProperty); }
            set { SetValue(GroupNameProperty, value); }
        }

        public bool IsNeedSelected
        {
            get { return (bool)GetValue(IsNeedSelectedProperty); }
            set { SetValue(IsNeedSelectedProperty, value); }
        }

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public Geometry PathData
        {
            get { return (Geometry)GetValue(PathDataProperty); }
            set { SetValue(PathDataProperty, value); }
        }

        public bool HasPathData
        {
            get { return (bool)GetValue(HasPathDataProperty); }
            set { SetValue(HasPathDataProperty, value); }
        }

        /// <summary>
        /// 鼠标按下背景样式
        /// </summary>
        public Brush PressedBackground
        {
            get { return (Brush)GetValue(PressedBackgroundProperty); }
            set { SetValue(PressedBackgroundProperty, value); }
        }

        /// <summary>
        /// 鼠标按下前景样式（图标、文字）
        /// </summary>
        public Brush PressedForeground
        {
            get { return (Brush)GetValue(PressedForegroundProperty); }
            set { SetValue(PressedForegroundProperty, value); }
        }

        /// <summary>
        /// 鼠标进入背景样式
        /// </summary>
        public Brush MouseOverBackground
        {
            get { return (Brush)GetValue(MouseOverBackgroundProperty); }
            set { SetValue(MouseOverBackgroundProperty, value); }
        }

        /// <summary>
        /// 鼠标进入前景样式
        /// </summary>
        public Brush MouseOverForeground
        {
            get { return (Brush)GetValue(MouseOverForegroundProperty); }
            set { SetValue(MouseOverForegroundProperty, value); }
        }

        /// <summary>
        /// 按钮图片
        /// </summary>
        public ImageSource RIcon
        {
            get { return (ImageSource)GetValue(RIconProperty); }
            set { SetValue(RIconProperty, value); }
        }

        /// <summary>
        /// 按钮图片
        /// </summary>
        public Visibility AllowRIcon
        {
            get { return (Visibility)GetValue(AllowRIconProperty); }
            set { SetValue(AllowRIconProperty, value); }
        }

        /// <summary>
        /// 按钮圆角大小,左上，右上，右下，左下
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public string NavId
        {
            get { return (string)GetValue(NavIdProperty); }
            set { SetValue(NavIdProperty, value); }
        }

        //public string DesertNavId
        //{
        //    get { return (string)GetValue(DesertNavIdProperty); }
        //    set { SetValue(DesertNavIdProperty, value); }
        //}
    }
}
