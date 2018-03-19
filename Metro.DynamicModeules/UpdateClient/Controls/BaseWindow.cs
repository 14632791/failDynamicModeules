/********************************************************************

时间: 2015年12月8日22:44:14

作者:陈刚

描述: 自定义基窗口

其它: 

********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;


namespace XHClient.UpdateClient.Controls
{
    /// <summary>
    /// 自定义基窗口
    /// </summary>
    [TemplatePart(Name = HeaderContainerName, Type = typeof(FrameworkElement))]
    [TemplatePart(Name = MinimizeButtonName, Type = typeof(Button))]
    [TemplatePart(Name = RestoreButtonName, Type = typeof(ToggleButton))]
    [TemplatePart(Name = CloseButtonName, Type = typeof(Button))]
    [TemplatePart(Name = TopResizerName, Type = typeof(Thumb))]
    [TemplatePart(Name = LeftResizerName, Type = typeof(Thumb))]
    [TemplatePart(Name = RightResizerName, Type = typeof(Thumb))]
    [TemplatePart(Name = BottomResizerName, Type = typeof(Thumb))]
    [TemplatePart(Name = BottomRightResizerName, Type = typeof(Thumb))]
    [TemplatePart(Name = TopRightResizerName, Type = typeof(Thumb))]
    [TemplatePart(Name = TopLeftResizerName, Type = typeof(Thumb))]
    [TemplatePart(Name = BottomLeftResizerName, Type = typeof(Thumb))]
    public class BaseWindow : Window
    {
        #region Template Part Name

        private const string HeaderContainerName = "PART_HeaderContainer";
        private const string MinimizeButtonName = "PART_MinimizeButton";
        private const string RestoreButtonName = "PART_RestoreButton";
        private const string CloseButtonName = "PART_CloseButton";
        private const string TopResizerName = "PART_TopResizer";
        private const string LeftResizerName = "PART_LeftResizer";
        private const string RightResizerName = "PART_RightResizer";
        private const string BottomResizerName = "PART_BottomResizer";
        private const string BottomRightResizerName = "PART_BottomRightResizer";
        private const string TopRightResizerName = "PART_TopRightResizer";
        private const string TopLeftResizerName = "PART_TopLeftResizer";
        private const string BottomLeftResizerName = "PART_BottomLeftResizer";

        #endregion

        #region Private Fields

        private FrameworkElement headerContainer;
        private Button minimizeButton;
        private ToggleButton restoreButton;
        private Button closeButton;
        private Thumb topResizer;
        private Thumb leftResizer;
        private Thumb rightResizer;
        private Thumb bottomResizer;
        private Thumb bottomRightResizer;
        private Thumb topRightResizer;
        private Thumb topLeftResizer;
        private Thumb bottomLeftResizer;

        #endregion

        static BaseWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseWindow), new FrameworkPropertyMetadata(typeof(BaseWindow)));
        }
        // Storyboard stdStart, stdEnd;  
        public BaseWindow()
        {
            //读取资源字典文件
            ResourceDictionary rd = new ResourceDictionary();
            rd.Source = new Uri("/XHClient.UpdateClient;component/Themes/BaseWindowDictionary.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries.Add(rd);
            //获取样式
            this.Style = this.FindResource("baseWindowStyle") as Style;
            SetBaseInfo();

            this.Loaded += BaseWindow_Loaded;
        }

        private void BaseWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void SetBaseInfo()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            WindowState = WindowState.Normal;
        }
        //public string HeaderTitle
        //{
        //    get { return (string)GetValue(HeaderTitleProperty); }
        //    set { SetValue(HeaderTitleProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Version.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty HeaderTitleProperty =
        //    DependencyProperty.Register("HeaderTitle", typeof(string), typeof(BaseWindow), new PropertyMetadata(string.Empty));


        //public string Version
        //{
        //    get { return (string)GetValue(VersionProperty); }
        //    set { SetValue(VersionProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Version.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty VersionProperty =
        //    DependencyProperty.Register("Version", typeof(string), typeof(BaseWindow), new PropertyMetadata(string.Empty));



        //public string NowTime
        //{
        //    get { return (string)GetValue(NowTimeProperty); }
        //    set { SetValue(NowTimeProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for NowTime.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty NowTimeProperty =
        //    DependencyProperty.Register("NowTime", typeof(string), typeof(BaseWindow), new PropertyMetadata(CacheData.StampToDateTime().ToShortDateString()));




        //public string LineText
        //{
        //    get { return (string)GetValue(LineTextProperty); }
        //    set { SetValue(LineTextProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for LineText.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty LineTextProperty =
        //    DependencyProperty.Register("LineText", typeof(string), typeof(BaseWindow), new PropertyMetadata(string.Empty));




        //public string UserName
        //{
        //    get { return (string)GetValue(UserNameProperty); }
        //    set { SetValue(UserNameProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for UserName.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty UserNameProperty =
        //    DependencyProperty.Register("UserName", typeof(string), typeof(BaseWindow), new PropertyMetadata(string.Empty));


        public Brush DefaultBackground
        {
            get { return (Brush)GetValue(DefaultBackgroundProperty); }
            set { SetValue(DefaultBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UserName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DefaultBackgroundProperty =
            DependencyProperty.Register("DefaultBackground", typeof(Brush), typeof(BaseWindow), new PropertyMetadata(Brushes.Transparent));

        public Brush HeaderDefaultBackground
        {
            get { return (Brush)GetValue(HeaderDefaultBackgroundProperty); }
            set { SetValue(HeaderDefaultBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UserName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderDefaultBackgroundProperty =
            DependencyProperty.Register("HeaderDefaultBackground", typeof(Brush), typeof(BaseWindow), new PropertyMetadata(Brushes.Transparent));

        public Brush ContentDefaultBackground
        {
            get { return (Brush)GetValue(ContentDefaultBackgroundProperty); }
            set { SetValue(ContentDefaultBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UserName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentDefaultBackgroundProperty =
            DependencyProperty.Register("ContentDefaultBackground", typeof(Brush), typeof(BaseWindow), new PropertyMetadata(Brushes.Transparent));

        public bool Flag
        {
            get { return (bool)GetValue(FlagProperty); }
            set { SetValue(FlagProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Flag.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FlagProperty =
            DependencyProperty.Register("Flag", typeof(bool), typeof(BaseWindow), new PropertyMetadata(true));

        public static readonly DependencyProperty ShowDefaultHeaderProperty =
            DependencyProperty.Register("ShowDefaultHeader", typeof(bool), typeof(BaseWindow), new FrameworkPropertyMetadata(true));

        public static readonly DependencyProperty ShowResizeGripProperty =
            DependencyProperty.Register("ShowResizeGrip", typeof(bool), typeof(BaseWindow), new FrameworkPropertyMetadata(false));

        public static readonly DependencyProperty CanResizeProperty =
            DependencyProperty.Register("CanResize", typeof(bool), typeof(BaseWindow), new FrameworkPropertyMetadata(true));

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(object), typeof(BaseWindow), new FrameworkPropertyMetadata(null, OnHeaderChanged));

        public static readonly DependencyProperty HeaderTemplateProperty =
            DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(BaseWindow), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty HeaderTempateSelectorProperty =
            DependencyProperty.Register("HeaderTempateSelector", typeof(DataTemplateSelector), typeof(BaseWindow), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty IsFullScreenMaximizeProperty =
            DependencyProperty.Register("IsFullScreenMaximize", typeof(bool), typeof(BaseWindow), new FrameworkPropertyMetadata(false));

        private static void OnHeaderChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            BaseWindow win = sender as BaseWindow;
            win.RemoveLogicalChild(e.OldValue);
            win.AddLogicalChild(e.NewValue);
        }

        public bool ShowDefaultHeader
        {
            get { return (bool)GetValue(ShowDefaultHeaderProperty); }
            set { SetValue(ShowDefaultHeaderProperty, value); }
        }

        public bool CanResize
        {
            get { return (bool)GetValue(CanResizeProperty); }
            set { SetValue(CanResizeProperty, value); }
        }

        public bool ShowResizeGrip
        {
            get { return (bool)GetValue(ShowResizeGripProperty); }
            set { SetValue(ShowResizeGripProperty, value); }
        }

        public object Header
        {
            get { return (object)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public DataTemplate HeaderTemplate
        {
            get { return (DataTemplate)GetValue(HeaderTemplateProperty); }
            set { SetValue(HeaderTemplateProperty, value); }
        }

        public DataTemplateSelector HeaderTempateSelector
        {
            get { return (DataTemplateSelector)GetValue(HeaderTempateSelectorProperty); }
            set { SetValue(HeaderTempateSelectorProperty, value); }
        }

        public bool IsFullScreenMaximize
        {
            get { return (bool)GetValue(IsFullScreenMaximizeProperty); }
            set { SetValue(IsFullScreenMaximizeProperty, value); }
        }


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            headerContainer = GetTemplateChild<FrameworkElement>(HeaderContainerName);
            headerContainer.MouseLeftButtonDown += HeaderContainerMouseLeftButtonDown;
            closeButton = GetTemplateChild<Button>(CloseButtonName);
            closeButton.Click += delegate { Application.Current.Shutdown(); };
            restoreButton = GetTemplateChild<ToggleButton>(RestoreButtonName);
            restoreButton.Checked += delegate { ChangeWindowState(WindowState.Normal); };
            restoreButton.Unchecked += delegate { ChangeWindowState(WindowState.Maximized); };
            StateChanged += new EventHandler(HeaderedWindowStateChanged);
            minimizeButton = GetTemplateChild<Button>(MinimizeButtonName);
            minimizeButton.Click += delegate { ChangeWindowState(WindowState.Minimized); };
            topResizer = GetTemplateChild<Thumb>(TopResizerName);
            topResizer.DragDelta += new DragDeltaEventHandler(ResizeTop);
            leftResizer = GetTemplateChild<Thumb>(LeftResizerName);
            leftResizer.DragDelta += new DragDeltaEventHandler(ResizeLeft);
            rightResizer = GetTemplateChild<Thumb>(RightResizerName);
            rightResizer.DragDelta += new DragDeltaEventHandler(ResizeRight);
            bottomResizer = GetTemplateChild<Thumb>(BottomResizerName);
            bottomResizer.DragDelta += new DragDeltaEventHandler(ResizeBottom);
            bottomRightResizer = GetTemplateChild<Thumb>(BottomRightResizerName);
            bottomRightResizer.DragDelta += new DragDeltaEventHandler(ResizeBottomRight);
            topRightResizer = GetTemplateChild<Thumb>(TopRightResizerName);
            topRightResizer.DragDelta += new DragDeltaEventHandler(ResizeTopRight);
            topLeftResizer = GetTemplateChild<Thumb>(TopLeftResizerName);
            topLeftResizer.DragDelta += new DragDeltaEventHandler(ResizeTopLeft);
            bottomLeftResizer = GetTemplateChild<Thumb>(BottomLeftResizerName);
            bottomLeftResizer.DragDelta += new DragDeltaEventHandler(ResizeBottomLeft);

        }

        private T GetTemplateChild<T>(string childName) where T : FrameworkElement, new()
        {
            return (GetTemplateChild(childName) as T) ?? new T();
        }

        private void HeaderContainerMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                DragMove();
            }
            else
            {
                ChangeWindowState(WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized);
            }
        }


        private void ChangeWindowState(WindowState state)
        {
            if (state == WindowState.Maximized)
            {
                if (!IsFullScreenMaximize && IsLocationOnPrimaryScreen())
                {
                    MaxHeight = SystemParameters.WorkArea.Height;
                    MaxWidth = SystemParameters.WorkArea.Width;
                }
                else
                {
                    MaxHeight = double.PositiveInfinity;
                    MaxWidth = double.PositiveInfinity;
                }
            }
            WindowState = state;
            this.Visibility = Visibility.Visible;
        }

        private void HeaderedWindowStateChanged(object sender, EventArgs e)
        {

            if (WindowState == WindowState.Minimized)
            {
                restoreButton.IsChecked = null;
            }
            else
            {
                restoreButton.IsChecked = WindowState == WindowState.Normal;
            }
        }

        private bool IsLocationOnPrimaryScreen()
        {
            return Left < SystemParameters.PrimaryScreenWidth && Top < SystemParameters.PrimaryScreenHeight;
        }

        #region Resize

        private void ResizeBottomLeft(object sender, DragDeltaEventArgs e)
        {
            ResizeLeft(sender, e);
            ResizeBottom(sender, e);
        }

        private void ResizeTopLeft(object sender, DragDeltaEventArgs e)
        {
            ResizeTop(sender, e);
            ResizeLeft(sender, e);
        }

        private void ResizeTopRight(object sender, DragDeltaEventArgs e)
        {
            ResizeRight(sender, e);
            ResizeTop(sender, e);
        }

        private void ResizeBottomRight(object sender, DragDeltaEventArgs e)
        {
            ResizeBottom(sender, e);
            ResizeRight(sender, e);
        }

        private void ResizeBottom(object sender, DragDeltaEventArgs e)
        {

            if (ActualHeight <= MinHeight && e.VerticalChange < 0)
            {
                return;
            }

            if (double.IsNaN(Height))
            {
                Height = ActualHeight;
            }

            Height += e.VerticalChange;
        }

        private void ResizeRight(object sender, DragDeltaEventArgs e)
        {
            if (ActualWidth <= MinWidth && e.HorizontalChange < 0)
            {
                return;
            }

            if (double.IsNaN(Width))
            {
                Width = ActualWidth;
            }

            Width += e.HorizontalChange;
        }

        private void ResizeLeft(object sender, DragDeltaEventArgs e)
        {
            if (ActualWidth <= MinWidth && e.HorizontalChange > 0)
            {
                return;
            }

            if (double.IsNaN(Width))
            {
                Width = ActualWidth;
            }

            Width -= e.HorizontalChange;
            Left += e.HorizontalChange;
        }

        private void ResizeTop(object sender, DragDeltaEventArgs e)
        {
            if (ActualHeight <= MinHeight && e.VerticalChange > 0)
            {
                return;
            }

            if (double.IsNaN(Height))
            {
                Height = ActualHeight;
            }

            Height -= e.VerticalChange;
            Top += e.VerticalChange;
        }

        #endregion


        //protected  override o
    }

}

