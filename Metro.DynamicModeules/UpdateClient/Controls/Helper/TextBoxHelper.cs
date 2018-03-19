using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Converters;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Reflection;
using XHClient.UpdateClient.Controls;

namespace XHClient.UpdateClient.Controls
{
    public class TextBoxHelper
    {
        public static readonly DependencyProperty IsMonitoringProperty = DependencyProperty.RegisterAttached("IsMonitoring", typeof(bool), typeof(TextBoxHelper), new UIPropertyMetadata(false, OnIsMonitoringChanged));
        public static readonly DependencyProperty WatermarkProperty = DependencyProperty.RegisterAttached("Watermark", typeof(string), typeof(TextBoxHelper), new UIPropertyMetadata(string.Empty));
        public static readonly DependencyProperty PasswordTextProperty = DependencyProperty.RegisterAttached("PasswordText", typeof(string), typeof(TextBoxHelper), new PropertyMetadata
(string.Empty));

        public static readonly DependencyProperty TextBoxTextProperty = DependencyProperty.RegisterAttached("TextBoxText", typeof(string), typeof(TextBoxHelper), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty HasTextProperty = DependencyProperty.RegisterAttached("HasText", typeof(bool), typeof(TextBoxHelper), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));
        public static readonly DependencyProperty SelectAllOnFocusProperty = DependencyProperty.RegisterAttached("SelectAllOnFocus", typeof(bool), typeof(TextBoxHelper), new PropertyMetadata(false));
        //textbox内部按钮触发父亲窗口命令
        public static readonly DependencyProperty ButtonCommandProperty = DependencyProperty.RegisterAttached("ButtonCommand", typeof(ICommand), typeof(TextBoxHelper), new PropertyMetadata(null));
        public static readonly DependencyProperty ButtonCommandParameterProperty = DependencyProperty.RegisterAttached("ButtonCommandParameter", typeof(object), typeof(TextBoxHelper), new PropertyMetadata(null));
        public static readonly DependencyProperty RegisterButtonClickPorperty = DependencyProperty.RegisterAttached("RegisterButtonClick", typeof(bool), typeof(TextBoxHelper), new PropertyMetadata(false, RegisterButtonClearChanged));

        public static readonly DependencyProperty IsNeedClearButtonProperty = DependencyProperty.RegisterAttached("IsNeedClearButton", typeof(bool), typeof(TextBoxHelper), new PropertyMetadata(false));

        public static readonly DependencyProperty IsVisibilityImageProperty = DependencyProperty.RegisterAttached("IsVisibilityImage", typeof(Visibility), typeof(TextBoxHelper), new PropertyMetadata(Visibility.Collapsed));

        public static readonly DependencyProperty ImageSourcePathProperty = DependencyProperty.RegisterAttached("ImageSourcePath", typeof(ImageSource), typeof(TextBoxHelper), new PropertyMetadata(null));


        public static readonly DependencyProperty KeyNumVOffsetProperty = DependencyProperty.RegisterAttached("KeyNumVOffset", typeof(int), typeof(TextBoxHelper), new PropertyMetadata
(0));

        public static readonly DependencyProperty KeyNumHOffsetProperty = DependencyProperty.RegisterAttached("KeyNumHOffset", typeof(int), typeof(TextBoxHelper), new PropertyMetadata
(0));
        public static readonly DependencyProperty KeyNumPlacementProperty = DependencyProperty.RegisterAttached("KeyNumPlacement", typeof(PlacementMode), typeof(TextBoxHelper), new PropertyMetadata
(PlacementMode.Bottom));
        


        private static void OnIsMonitoringChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            switch (d.GetType().Name.ToLower())
            {
                case "passwordbox":
                    var passBox = d as PasswordBox;
                    if ((bool)e.NewValue)
                    {
                        passBox.PasswordChanged += PasswordChanged;
                        passBox.GotFocus += PasswordGotFocus;
                        passBox.GotMouseCapture += passBox_GotMouseCapture;
                        passBox.KeyUp += passBox_KeyUp;
                        passBox.Dispatcher.BeginInvoke((Action)(() =>
                            PasswordChanged(passBox, new RoutedEventArgs(PasswordBox.PasswordChangedEvent, passBox))));
                    }
                    else
                    {
                        passBox.PasswordChanged -= PasswordChanged;
                        passBox.GotFocus -= PasswordGotFocus;
                    }
                    break;
                case "textbox":
                    var textbox = d as TextBox;
                    if ((bool)e.NewValue)
                    {
                        textbox.TextChanged += textbox_TextChanged;
                        textbox.GotFocus += textbox_GotFocus;
                        textbox.Dispatcher.BeginInvoke(new Action(() => { textbox_TextChanged(textbox, new TextChangedEventArgs(TextBox.TextChangedEvent, UndoAction.None)); }));
                    }
                    else
                    {
                        textbox.TextChanged -= textbox_TextChanged;
                        textbox.GotFocus -= textbox_GotFocus;
                    }
                    break;
            }

        }

        static void passBox_KeyUp(object sender, KeyEventArgs e)
        {
            //NumericKeyboard.SetSelection();
        }


        static void passBox_GotMouseCapture(object sender, MouseEventArgs e)
        {
            //NumericKeyboard.SetSelection();
        }

        private static void RegisterButtonClearChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Button btn = d as Button;
            if (btn != null && (bool)e.NewValue)
            {
                btn.Click += btn_Click;
            }
            //throw new NotImplementedException();
        }

        static void btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            var parent = VisualTreeHelper.GetParent(btn);
            while (!(parent is TextBox || parent is PasswordBox || parent is ComboBox))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            //处理按钮带处理事件的情形
            ICommand command = GetButtonCommand(parent);
            if (command != null)
            {
                object para = GetButtonCommandParameter(parent);
                command.Execute(para);
            }
            if (parent is TextBox)
            {
                if (GetIsNeedClearButton(parent))//有清空按钮的时候，需要清空数据
                {
                    TextBox tbx = (TextBox)parent;
                    tbx.SetValue(TextBox.TextProperty, null);
                    //((TextBox)parent).SetValue(TextBox.TextProperty, string.Empty);
                    //((TextBox)parent).Text = null;
                    //((TextBox)parent).Clear();
                }
            }
            //throw new NotImplementedException();
        }

        static void textbox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textboxtext = sender as TextBox;//add by ada 1
            //NumericKeyboard.InputTextBox = textboxtext;
            //NumericKeyboard.GetInputType = 1;//add by ada 1
            ControlGotFocus(sender as TextBox, textbox => textbox.SelectAll());
        }

        static void textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tbx = sender as TextBox;
            SetTextLength(tbx, textbox => textbox.Text.Length);
            if (tbx.Text == "")
                tbx.SetValue(TextBox.TextProperty, null);
            //tbx.Text = null;
            SetTextBoxText(tbx, tbx.Text); //add by ada 1
        }

        private static void PasswordGotFocus(object sender, RoutedEventArgs e)
        {
           // NumericKeyboard.GetInputType = 2;//add by ada 1
            PasswordBox password = sender as PasswordBox;
           // NumericKeyboard.PasswordBox = password;//add by ada 1
            ControlGotFocus(sender as PasswordBox, passwordBox => passwordBox.SelectAll());
        }

        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox psd = sender as PasswordBox;
            SetTextLength(psd, passwordBox => passwordBox.Password.Length);
            SetPasswordText(psd, psd.Password);
        }

        private static void SetTextLength<TDependencyObject>(TDependencyObject sender, Func<TDependencyObject, int> func) where TDependencyObject : DependencyObject
        {
            if (sender != null)
            {
                int length = func(sender);
                sender.SetValue(HasTextProperty, length > 0);
            }
        }


        private static void ControlGotFocus<TDependencyObject>(TDependencyObject sender, Action<TDependencyObject> Ac) where TDependencyObject : DependencyObject
        {
            if (sender != null)
            {
                PasswordBox passwordbox;
                TextBox textbox;
                if (GetSelectAllOnFocus(sender))
                {
                    sender.Dispatcher.BeginInvoke(Ac, sender);
                }
                //if (NumericKeyboard.KeyPopUp == null)//add by ada 1
                //{
                //    NumericKeyboard.CreatPop();
                //    NumericKeyboard.KeyPopUp.MouseEnter += KeyPopUp_MouseEnter;
                //}
                //NumericKeyboard.KeyPopUp.Placement = (PlacementMode)sender.GetValue(KeyNumPlacementProperty);
                //NumericKeyboard.KeyPopUp.VerticalOffset = (int)sender.GetValue(KeyNumVOffsetProperty);
                //NumericKeyboard.KeyPopUp.HorizontalOffset = (int)sender.GetValue(KeyNumHOffsetProperty);
            
                //if (sender.GetType().Name.ToLower() == "passwordbox")
                //{
                //    passwordbox = sender as PasswordBox;
                //    NumericKeyboard.KeyPopUp.PlacementTarget = passwordbox;
                //    PopopHelper.SetPopupPlacementTarget(NumericKeyboard.KeyPopUp, passwordbox);
                //    PopopHelper.GetPopupPlacementTarget(NumericKeyboard.KeyPopUp);
                //}
                //else
                //{
                //    textbox = sender as TextBox;
                //    NumericKeyboard.KeyBoard.Value += textbox.Text;
                //    NumericKeyboard.KeyPopUp.PlacementTarget = textbox;
                //    PopopHelper.SetPopupPlacementTarget(NumericKeyboard.KeyPopUp, textbox);
                //    PopopHelper.GetPopupPlacementTarget(NumericKeyboard.KeyPopUp);
                //}
                //if (!NumericKeyboard.IsChecked)
                //    NumericKeyboard.KeyPopUp.IsOpen = false;
                //NumericKeyboard.IsChecked = false;
                //NumericKeyboard.KeyPopUp.IsOpen = true;
            }
        }



        static void KeyPopUp_MouseEnter(object sender, MouseEventArgs e)
        {
            //NumericKeyboard.KeyPopUp.IsOpen = true;
        }

        static void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static ImageSource GetImageSourcePath(DependencyObject obj)
        {
            return (ImageSource) obj.GetValue(ImageSourcePathProperty);
        }

        public static void SetImageSourcePath(DependencyObject obj, ImageSource value)
        {
            obj.SetValue(ImageSourcePathProperty, value);
        }
        public static Visibility GetIsVisibilityImage(DependencyObject obj)
        {
            return (Visibility)obj.GetValue(IsVisibilityImageProperty);
        }
        public static void SetIsVisibilityImage(DependencyObject obj, Visibility value)
        {
            obj.SetValue(IsVisibilityImageProperty, value);
        }

        public static bool GetIsMonitoring(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsMonitoringProperty);
        }
        public static void SetIsMonitoring(DependencyObject obj, bool value)
        {
            obj.SetValue(IsMonitoringProperty, value);
        }

        public static string GetWatermark(DependencyObject obj)
        {
            return (string)obj.GetValue(WatermarkProperty);
        }
        public static void SetWatermark(DependencyObject obj, string value)
        {
            obj.SetValue(WatermarkProperty, value);
        }

        public static bool GetHasText(DependencyObject obj)
        {
            return (bool)obj.GetValue(HasTextProperty);
        }
        public static void SetHasText(DependencyObject obj, bool value)
        {
            obj.SetValue(HasTextProperty, value);
        }

        public static bool GetSelectAllOnFocus(DependencyObject obj)
        {
            return (bool)obj.GetValue(SelectAllOnFocusProperty);
        }
        public static void SetSelectAllOnFocus(DependencyObject obj, bool value)
        {
            obj.SetValue(SelectAllOnFocusProperty, value);
        }

        public static ICommand GetButtonCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(ButtonCommandProperty);
        }

        public static void SetButtonCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(ButtonCommandProperty, value);
        }

        public static bool GetIsNeedClearButton(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsNeedClearButtonProperty);
        }

        public static void SetIsNeedClearButton(DependencyObject obj, bool value)
        {
            obj.SetValue(IsNeedClearButtonProperty, value);
        }

        public static bool GetRegisterButtonClick(DependencyObject obj)
        {
            return (bool)obj.GetValue(RegisterButtonClickPorperty);
        }

        public static void SetRegisterButtonClick(DependencyObject obj, bool value)
        {
            obj.SetValue(RegisterButtonClickPorperty, value);
        }

        public static object GetButtonCommandParameter(DependencyObject obj)
        {
            return obj.GetValue(ButtonCommandParameterProperty);
        }

        public static void SetButtonCommandParameter(DependencyObject obj, object value)
        {
            obj.SetValue(ButtonCommandParameterProperty, value);
        }

        public static string GetPasswordText(DependencyObject obj)
        {
            return (string)obj.GetValue(PasswordTextProperty);
        }

        public static void SetPasswordText(DependencyObject obj, string value)
        {
            obj.SetValue(PasswordTextProperty, value);
        }

        public static string GetTextBoxText(DependencyObject obj)
        {
            return (string)obj.GetValue(TextBoxTextProperty);
        }

        public static void SetTextBoxText(DependencyObject obj, string value)
        {
            obj.SetValue(TextBoxTextProperty, value);
        }

        public static int GetKeyNumVOffset(DependencyObject obj)
        {
            return (int)obj.GetValue(KeyNumVOffsetProperty);
        }

        public static void SetKeyNumVOffset(DependencyObject obj, int value)
        {
            obj.SetValue(KeyNumVOffsetProperty, value);
        }

        public static int GetKeyNumHOffset(DependencyObject obj)
        {
            return (int)obj.GetValue(KeyNumHOffsetProperty);
        }

        public static void SetKeyNumHOffset(DependencyObject obj, int value)
        {
            obj.SetValue(KeyNumHOffsetProperty, value);
        }
        public static PlacementMode GetKeyNumPlacement(DependencyObject obj)
        {
            return (PlacementMode)obj.GetValue(KeyNumPlacementProperty);
        }

        public static void SetKeyNumPlacement(DependencyObject obj, PlacementMode value)
        {
            obj.SetValue(KeyNumPlacementProperty, value);
        }
        
    }
}
