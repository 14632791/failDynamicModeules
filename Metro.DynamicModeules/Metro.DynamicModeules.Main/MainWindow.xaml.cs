using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Metro.DynamicModeules.BaseControls.Commands;
using Metro.DynamicModeules.BaseControls.ViewModel;
using Metro.DynamicModeules.Interface.Sys;
using Metro.DynamicModeules.Main.ViewModel;
using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Metro.DynamicModeules.Main
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(IHost))]
    public partial class MainWindow : MetroWindow, IHost
    {
        //private bool _shutdown;
        private readonly MainWindowViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = MainWindowViewModel.Instance;// DialogCoordinator.Instance);
            DataContext = _viewModel;
            Closing += (s, e) =>
            {
                if (!e.Cancel)
                {
                    _viewModel.Dispose();
                }
            };
            Exec();
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

        private async void ShowLimitedMessageDialog(object sender, RoutedEventArgs e)
        {
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Hi",
                NegativeButtonText = "Go away!",
                FirstAuxiliaryButtonText = "Cancel",
                MaximumBodyHeight = 100,
                ColorScheme = MetroDialogOptions.ColorScheme
            };

            MessageDialogResult result = await this.ShowMessageAsync("Hello!", "Welcome to the world of metro!" + string.Join(Environment.NewLine, "abc", "def", "ghi", "jkl", "mno", "pqr", "stu", "vwx", "yz"),
                MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary, mySettings);

            if (result != MessageDialogResult.FirstAuxiliary)
                await this.ShowMessageAsync("Result", "You said: " + (result == MessageDialogResult.Affirmative ? mySettings.AffirmativeButtonText : mySettings.NegativeButtonText +
                    Environment.NewLine + Environment.NewLine + "This dialog will follow the Use Accent setting."));
        }

        private async void ShowCustomDialog(object sender, RoutedEventArgs e)
        {
            var dialog = (BaseMetroDialog)this.Resources["CustomDialogTest"];
            await this.ShowMetroDialogAsync(dialog);
            var textBlock = dialog.FindChild<TextBlock>("MessageTextBlock");
            textBlock.Text = "A message box will appear in 3 seconds.";
            await TaskEx.Delay(3000);
            await this.ShowMessageAsync("Secondary dialog", "This message is shown on top of another.");

            textBlock.Text = "The dialog will close in 2 seconds.";
            await TaskEx.Delay(2000);

            await this.HideMetroDialogAsync(dialog);
        }

        public void Exec()
        {
            foreach (var item in PluginHandle.Instance.PluginList)
            {
                //加载所有项及子项
                item.Value.MdiMainWindow = _viewModel;
                foreach (var sub in item.Value.SubModuleList)
                {
                    sub.IModule = item.Value;
                    sub.MdiMainWindow = _viewModel;
                }
                _viewModel.Modules.Add(item.Value);
            }
        }

        public void ShowProgress(string msg)
        {
            throw new NotImplementedException();
        }

        public MetroDialogSettings MetroDialogPotions
        {
            get { return (MetroDialogSettings)GetValue(MetroDialogPotionsProperty); }
            set { SetValue(MetroDialogPotionsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MetroDialogPotions.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MetroDialogPotionsProperty =
            DependencyProperty.Register("MetroDialogPotions", typeof(MetroDialogSettings), typeof(MainWindow), new PropertyMetadata(null));

    }
}
