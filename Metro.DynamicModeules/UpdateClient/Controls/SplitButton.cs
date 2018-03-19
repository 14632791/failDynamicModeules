using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace XHClient.UpdateClient.Controls
{
    public class SplitButton : ItemsControl
    {
        public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SplitButton));
        public static readonly RoutedEvent SelectionChangedEvent = EventManager.RegisterRoutedEvent("SelectionChanged", RoutingStrategy.Bubble, typeof(SelectionChangedEventHandler), typeof(SplitButton));
        public event RoutedEventHandler Click
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }

        public event SelectionChangedEventHandler SelectionChanged
        {
            add { AddHandler(SelectionChangedEvent, value); }
            remove { RemoveHandler(SelectionChangedEvent, value); }
        }

        public static readonly DependencyProperty SelectedIndexProperty = DependencyProperty.Register("SelectedIndex", typeof(Int32), typeof(SplitButton), new FrameworkPropertyMetadata(-1, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(Object), typeof(SplitButton), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty SelectedValueProperty = DependencyProperty.Register("SelectedValue", typeof(Object), typeof(SplitButton), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        //public static readonly DependencyProperty ArrowBrushProperty = DependencyProperty.Register("ArrowBrush", typeof(Brush), typeof(SplitButton), new FrameworkPropertyMetadata(default(Brush), FrameworkPropertyMetadataOptions.AffectsRender));
        public static readonly DependencyProperty ArrowBrushProperty = DependencyProperty.Register("ArrowBrush", typeof(Brush), typeof(SplitButton), new FrameworkPropertyMetadata(default(Brush), FrameworkPropertyMetadataOptions.AffectsRender));
        public static readonly DependencyProperty ButtonArrowStyleProperty = DependencyProperty.Register("ButtonArrowStyle", typeof(Style), typeof(SplitButton), new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));
        public static readonly DependencyProperty ButtonStyleProperty = DependencyProperty.Register("ButtonStyle", typeof(Style), typeof(SplitButton), new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));
        public static readonly DependencyProperty ListBoxStyleProperty = DependencyProperty.Register("ListBoxStyle", typeof(Style), typeof(SplitButton), new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));
        public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register("IsExpanded", typeof(bool), typeof(SplitButton));


        public ICommand SelectedCommand
        {
            get { return (ICommand)GetValue(SelectedCommandProperty); }
            set { SetValue(SelectedCommandProperty, value); }
        }

        public static readonly DependencyProperty SelectedCommandProperty =
            DependencyProperty.Register("SelectedCommand", typeof(ICommand), typeof(SplitButton));


        public Brush ArrowBrush
        {
            get { return (Brush)GetValue(ArrowBrushProperty); }
            set { SetValue(ArrowBrushProperty, value); }
        }

        public Style ButtonArrowStyle
        {
            get { return (Style)GetValue(ButtonArrowStyleProperty); }
            set { SetValue(ButtonArrowStyleProperty, value); }
        }

        public Style ButtonStyle
        {
            get { return (Style)GetValue(ButtonStyleProperty); }
            set { SetValue(ButtonStyleProperty, value); }
        }

        public Style ListBoxStyle
        {
            get { return (Style)GetValue(ListBoxStyleProperty); }
            set { SetValue(ListBoxStyleProperty, value); }
        }

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public bool IsExpanded
        {
            get { return (bool)GetValue(IsExpandedProperty); }
            set { SetValue(IsExpandedProperty, value); }
        }

        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        public object SelectedValue
        {
            get { return (object)GetValue(SelectedValueProperty); }
            set { SetValue(SelectedValueProperty, value); }
        }

        //private Button _clickButton;
        private Button _expander;
        private ListBox _listBox;
        private Popup _popup;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _expander = GetElementControl<Button>("PART_Expander");// as Button;
            _listBox = GetElementControl<ListBox>("PART_ListBox");// as ListBox;
            _popup = GetElementControl<Popup>("PART_Popup");//as Popup;
            InitializeVisualContainer();
        }

        private T GetElementControl<T>(string name) where T : FrameworkElement, new()
        {
            T element = GetTemplateChild(name) as T ?? new T();
            return element;
        }

        private void InitializeVisualContainer()
        {
            _expander.Click -= _expander_Click;
            _listBox.PreviewMouseLeftButtonDown -= _listBox_PreviewMouseLeftButtonDown;
            _popup.Opened -= _popup_Opened;
            _popup.Closed -= _popup_Closed;


            _expander.Click += _expander_Click;
            _listBox.PreviewMouseLeftButtonDown += _listBox_PreviewMouseLeftButtonDown;
            _popup.Opened += _popup_Opened;
            _popup.Closed += _popup_Closed;
            _listBox.SelectionChanged += SplitButton_SelectionChanged;
        }

        void _popup_Closed(object sender, EventArgs e)
        {
            this.ReleaseMouseCapture();
        }

        void _popup_Opened(object sender, EventArgs e)
        {
            Mouse.Capture(this, CaptureMode.SubTree);
            Mouse.AddPreviewMouseDownOutsideCapturedElementHandler(this, OutsideCapturedElementHandler);
        }

        private void OutsideCapturedElementHandler(object sender, MouseButtonEventArgs e)
        {
            IsExpanded = false;
            Mouse.RemovePreviewMouseDownOutsideCapturedElementHandler(this, OutsideCapturedElementHandler);
        }

        void _listBox_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var source = e.OriginalSource as DependencyObject;
            if (source != null)
            {
                var item = ContainerFromElement(this._listBox, source) as ListBoxItem;
                if (item != null)
                {
                    IsExpanded = false;
                }
            }
        }

        void _expander_Click(object sender, RoutedEventArgs e)
        {
            IsExpanded = !IsExpanded;
        }

        private void SplitButton_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0) return;
            if (SelectedCommand != null)
            {
                SelectedCommand.Execute(e.AddedItems[0]);
            }
        }
    }
}
