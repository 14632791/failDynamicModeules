using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Metro.DynamicModeules.Main.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Metro.DynamicModeules.Main
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        //private bool _shutdown;
        private readonly MainWindowViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel(DialogCoordinator.Instance);
            DataContext = _viewModel;

            Closing += (s, e) =>
            {               
                if (!e.Cancel)
                {
                    _viewModel.Dispose();
                }
            };
        }
        public static readonly DependencyProperty ToggleFullScreenProperty =
           DependencyProperty.Register("ToggleFullScreen",
                                       typeof(bool),
                                       typeof(MainWindow),
                                       new PropertyMetadata(default(bool), ToggleFullScreenPropertyChangedCallback));

        private static void ToggleFullScreenPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var metroWindow = (MetroWindow)dependencyObject;
            if (e.OldValue != e.NewValue)
            {
                var fullScreen = (bool)e.NewValue;
                if (fullScreen)
                {
                    metroWindow.IgnoreTaskbarOnMaximize = true;
                    metroWindow.WindowState = WindowState.Maximized;
                    metroWindow.UseNoneWindowStyle = true;
                }
                else
                {
                    metroWindow.WindowState = WindowState.Normal;
                    metroWindow.UseNoneWindowStyle = false;
                    metroWindow.ShowTitleBar = true; // <-- this must be set to true
                    metroWindow.IgnoreTaskbarOnMaximize = false;
                }
            }
        }

        public bool ToggleFullScreen
        {
            get { return (bool)GetValue(ToggleFullScreenProperty); }
            set { SetValue(ToggleFullScreenProperty, value); }
        }

        public static readonly DependencyProperty UseAccentForDialogsProperty =
            DependencyProperty.Register("UseAccentForDialogs",
                                        typeof(bool),
                                        typeof(MainWindow),
                                        new PropertyMetadata(default(bool), ToggleUseAccentForDialogsPropertyChangedCallback));

        private static void ToggleUseAccentForDialogsPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var metroWindow = (MetroWindow)dependencyObject;
            if (e.OldValue != e.NewValue)
            {
                var useAccentForDialogs = (bool)e.NewValue;
                metroWindow.MetroDialogOptions.ColorScheme = useAccentForDialogs ? MetroDialogColorScheme.Accented : MetroDialogColorScheme.Theme;
            }
        }

        public bool UseAccentForDialogs
        {
            get { return (bool)GetValue(UseAccentForDialogsProperty); }
            set { SetValue(UseAccentForDialogsProperty, value); }
        }
    }
}
