﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Metro.DynamicModeules.BaseControls.Commands;
using Metro.DynamicModeules.BaseControls.ViewModel;
using Metro.DynamicModeules.BLL;
using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.Interface.Sys;
using NHotkey;
using NHotkey.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Metro.DynamicModeules.Main.ViewModel
{
    public class MainWindowViewModel : ViewModelBase, IMdiMainViewModel,IDataErrorInfo, IDisposable
    {
        private readonly IDialogCoordinator _dialogCoordinator;
        int? _integerGreater10Property;
        private bool _animateOnPositionChange = true;
        static MainWindowViewModel _instance;
        public static MainWindowViewModel Instance
        {
            get
            {
                if (null == _instance)
                {
                    _instance = new MainWindowViewModel();
                }
                return _instance;
            }
        }

        MainWindowViewModel()
        {
            #region 初始化属性成员

            //Buttons = new ObservableCollection<tb_MyAuthorityItem>();
            Modules = new ObservableCollection<IModuleBase>();
            TabPages = new ObservableCollection<IMdiChildViewModel>();
           
            #endregion
            this.Title = "Flyout Binding Test";
            _dialogCoordinator = MahApps.Metro.Controls.Dialogs.DialogCoordinator.Instance;
            // SampleData.Seed();

            // create accent color menu items for the demo
            this.AccentColors = ThemeManager.Accents
                                            .Select(a => new AccentColorMenuData() { Name = a.Name, ColorBrush = a.Resources["AccentColorBrush"] as Brush })
                                            .ToList();

            // create metro theme color menu items for the demo
            this.AppThemes = ThemeManager.AppThemes
                                           .Select(a => new AppThemeMenuData() { Name = a.Name, BorderColorBrush = a.Resources["BlackColorBrush"] as Brush, ColorBrush = a.Resources["WhiteColorBrush"] as Brush })
                                           .ToList();


            //Albums = SampleData.Albums;
            //Artists = SampleData.Artists;

            FlipViewImages = new Uri[]
                             {
                                 new Uri("http://www.public-domain-photos.com/free-stock-photos-4/landscapes/mountains/painted-desert.jpg", UriKind.Absolute),
                                 new Uri("http://www.public-domain-photos.com/free-stock-photos-3/landscapes/forest/breaking-the-clouds-on-winter-day.jpg", UriKind.Absolute),
                                 new Uri("http://www.public-domain-photos.com/free-stock-photos-4/travel/bodie/bodie-streets.jpg", UriKind.Absolute)
                             };

            BrushResources = FindBrushResources();
            CultureInfos = CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures).ToList();

            try
            {
                HotkeyManager.Current.AddOrReplace("demo", HotKey.Key, HotKey.ModifierKeys, async (sender, e) => await OnHotKey(sender, e));
            }
            catch (HotkeyAlreadyRegisteredException exception)
            {
                System.Diagnostics.Trace.TraceWarning("Uups, the hotkey {0} is already registered!", exception.Name);
            }
        }

        public void Dispose()
        {
            HotkeyManager.Current.Remove("demo");
        }

        public string Title { get; set; }
        public int SelectedIndex { get; set; }
        public List<AccentColorMenuData> AccentColors { get; set; }
        public List<AppThemeMenuData> AppThemes { get; set; }
        public List<CultureInfo> CultureInfos { get; set; }

        public int? IntegerGreater10Property
        {
            get { return this._integerGreater10Property; }
            set
            {
                if (Equals(value, _integerGreater10Property))
                {
                    return;
                }

                _integerGreater10Property = value;
                RaisePropertyChanged("IntegerGreater10Property");
            }
        }

        DateTime? _datePickerDate;

        [Display(Prompt = "Auto resolved Watermark")]
        public DateTime? DatePickerDate
        {
            get { return this._datePickerDate; }
            set
            {
                if (Equals(value, _datePickerDate))
                {
                    return;
                }

                _datePickerDate = value;
                RaisePropertyChanged("DatePickerDate");
            }
        }

        bool _magicToggleButtonIsChecked = true;
        public bool MagicToggleButtonIsChecked
        {
            get { return this._magicToggleButtonIsChecked; }
            set
            {
                if (Equals(value, _magicToggleButtonIsChecked))
                {
                    return;
                }

                _magicToggleButtonIsChecked = value;
                RaisePropertyChanged("MagicToggleButtonIsChecked");
            }
        }

        private bool _quitConfirmationEnabled;
        public bool QuitConfirmationEnabled
        {
            get { return _quitConfirmationEnabled; }
            set
            {
                if (value.Equals(_quitConfirmationEnabled)) return;
                _quitConfirmationEnabled = value;
                RaisePropertyChanged("QuitConfirmationEnabled");
            }
        }

        private bool showMyTitleBar = true;
        public bool ShowMyTitleBar
        {
            get { return showMyTitleBar; }
            set
            {
                if (value.Equals(showMyTitleBar)) return;
                showMyTitleBar = value;
                RaisePropertyChanged("ShowMyTitleBar");
            }
        }

        private bool canCloseFlyout = true;

        public bool CanCloseFlyout
        {
            get { return this.canCloseFlyout; }
            set
            {
                if (Equals(value, this.canCloseFlyout))
                {
                    return;
                }
                this.canCloseFlyout = value;
                this.RaisePropertyChanged("CanCloseFlyout");
            }
        }

        private ICommand closeCmd;

        public ICommand CloseCmd
        {
            get
            {
                return this.closeCmd ?? (this.closeCmd = new SimpleCommand
                {
                    CanExecuteDelegate = x => this.CanCloseFlyout,
                    ExecuteDelegate = x => ((Flyout)x).IsOpen = false
                });
            }
        }

        private bool canShowHamburgerAboutCommand = true;

        public bool CanShowHamburgerAboutCommand
        {
            get { return this.canShowHamburgerAboutCommand; }
            set
            {
                if (Equals(value, this.canShowHamburgerAboutCommand))
                {
                    return;
                }
                this.canShowHamburgerAboutCommand = value;
                this.RaisePropertyChanged("CanShowHamburgerAboutCommand");
            }
        }

        private bool isHamburgerMenuPaneOpen;

        public bool IsHamburgerMenuPaneOpen
        {
            get { return this.isHamburgerMenuPaneOpen; }
            set
            {
                if (Equals(value, this.isHamburgerMenuPaneOpen))
                {
                    return;
                }
                this.isHamburgerMenuPaneOpen = value;
                this.RaisePropertyChanged("IsHamburgerMenuPaneOpen");
            }
        }




        public string this[string columnName]
        {
            get
            {
                if (columnName == "IntegerGreater10Property" && this.IntegerGreater10Property < 10)
                {
                    return "Number is not greater than 10!";
                }

                if (columnName == "DatePickerDate" && this.DatePickerDate == null)
                {
                    return "No date given!";
                }

                if (columnName == "HotKey" && this.HotKey != null && this.HotKey.Key == Key.D && this.HotKey.ModifierKeys == ModifierKeys.Shift)
                {
                    return "SHIFT-D is not allowed";
                }

                return null;
            }
        }

        [Description("Test-Property")]
        public string Error { get { return string.Empty; } }


        private static void PerformDialogCoordinatorAction(Action action, bool runInMainThread)
        {
            if (!runInMainThread)
            {
                Task.Factory.StartNew(action);
            }
            else
            {
                action();
            }
        }


        private ICommand _refreshCommand;
        /// <summary>
        /// 刷新缓存command
        /// </summary>
        public ICommand RefreshCommand
        {
            get
            {
                return this._refreshCommand ?? (this._refreshCommand = new RelayCommand(DataDictCache.Instance.DownloadBaseCacheData));
            }
        }



        public IEnumerable<string> BrushResources { get; private set; }

        public bool AnimateOnPositionChange
        {
            get
            {
                return _animateOnPositionChange;
            }
            set
            {
                if (Equals(_animateOnPositionChange, value)) return;
                _animateOnPositionChange = value;
                RaisePropertyChanged("AnimateOnPositionChange");
            }
        }

        private IEnumerable<string> FindBrushResources()
        {
            var rd = new ResourceDictionary
            {
                Source = new Uri(@"/MahApps.Metro;component/Styles/Colors.xaml", UriKind.RelativeOrAbsolute)
            };

            var resources = rd.Keys.Cast<object>()
                    .Where(key => rd[key] is Brush)
                    .Select(key => key.ToString())
                    .OrderBy(s => s)
                    .ToList();

            return resources;
        }

        public Uri[] FlipViewImages
        {
            get;
            set;
        }


        public class RandomDataTemplateSelector : DataTemplateSelector
        {
            public DataTemplate TemplateOne { get; set; }

            public override DataTemplate SelectTemplate(object item, DependencyObject container)
            {
                return TemplateOne;
            }
        }

        private HotKey _hotKey = new HotKey(Key.Home, ModifierKeys.Control | ModifierKeys.Shift);

        public HotKey HotKey
        {
            get { return _hotKey; }
            set
            {
                if (_hotKey != value)
                {
                    _hotKey = value;
                    if (_hotKey != null && _hotKey.Key != Key.None)
                    {
                        HotkeyManager.Current.AddOrReplace("demo", HotKey.Key, HotKey.ModifierKeys, async (sender, e) => await OnHotKey(sender, e));
                    }
                    else
                    {
                        HotkeyManager.Current.Remove("demo");
                    }
                    RaisePropertyChanged("HotKey");
                }
            }
        }

        private async Task OnHotKey(object sender, HotkeyEventArgs e)
        {
            await ((MetroWindow)Application.Current.MainWindow).ShowMessageAsync(
                "Hotkey pressed",
                "You pressed the hotkey '" + HotKey + "' registered with the name '" + e.Name + "'");
        }

        private ICommand toggleIconScalingCommand;

        public ICommand ToggleIconScalingCommand
        {
            get
            {
                return toggleIconScalingCommand ?? (toggleIconScalingCommand = new SimpleCommand
                {
                    ExecuteDelegate = ToggleIconScaling
                });
            }
        }

        private void ToggleIconScaling(object obj)
        {
            var multiFrameImageMode = (MultiFrameImageMode)obj;
            ((MetroWindow)Application.Current.MainWindow).IconScalingMode = multiFrameImageMode;
            RaisePropertyChanged("IsScaleDownLargerFrame");
            RaisePropertyChanged("IsNoScaleSmallerFrame");
        }

        public bool IsScaleDownLargerFrame {
            get {
                return ((MetroWindow)Application.Current.MainWindow).IconScalingMode == MultiFrameImageMode.ScaleDownLargerFrame; } }

        public bool IsNoScaleSmallerFrame {
            get {
                return ((MetroWindow)Application.Current.MainWindow).IconScalingMode == MultiFrameImageMode.NoScaleSmallerFrame; } }

        #region Expand 2018.3.13
       


        #region 左则的模块列表

        ObservableCollection<IModuleBase> _modules;
        /// <summary>
        /// 左则的模块列表 ModuleBaseViewModel=> IModuleBase
        /// </summary>
        public ObservableCollection<IModuleBase> Modules
        {
            get
            {
                return _modules;
            }
            set
            {
                _modules = value;
                RaisePropertyChanged(() => Modules);
            }
        }

        #endregion

        #region 右下方的tabItems列表
        ObservableCollection<IMdiChildViewModel> _tabPages;
        public ObservableCollection<IMdiChildViewModel> TabPages
        {
            get
            {
                return _tabPages;
            }
            set
            {
                _tabPages = value;
                RaisePropertyChanged(() => TabPages);
            }
        }
        #endregion
        /// <summary>
        /// 当前选中的page
        /// </summary>
        IMdiChildViewModel _activatePage;
        public IMdiChildViewModel FocusedPage
        {
            get
            {
                return _activatePage;
            }
            set
            {
                _activatePage = value;
                RaisePropertyChanged(() => FocusedPage);
            }
        }
    }

    #endregion

    #region 其它类定义

    public class AccentColorMenuData
    {
        public string Name { get; set; }
        public Brush BorderColorBrush { get; set; }
        public Brush ColorBrush { get; set; }

        private ICommand changeAccentCommand;

        public ICommand ChangeAccentCommand
        {
            get { return this.changeAccentCommand ?? (changeAccentCommand = new SimpleCommand { CanExecuteDelegate = x => true, ExecuteDelegate = x => this.DoChangeTheme(x) }); }
        }

        protected virtual void DoChangeTheme(object sender)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            var accent = ThemeManager.GetAccent(this.Name);
            ThemeManager.ChangeAppStyle(Application.Current, accent, theme.Item1);
        }
    }


    public class AppThemeMenuData : AccentColorMenuData
    {
        protected override void DoChangeTheme(object sender)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            var appTheme = ThemeManager.GetAppTheme(this.Name);
            ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, appTheme);
        }
    }

    #endregion
}
