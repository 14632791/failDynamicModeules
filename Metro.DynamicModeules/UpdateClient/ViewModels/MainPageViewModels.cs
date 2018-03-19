using System;
using UpdateClient.BLL;
using UpdateClient.Common;
using UpdateClient.Views;
using System.Windows;
using System.Threading;

namespace UpdateClient.ViewModels
{
    public class MainPageViewModels : ModelBase
    {
        public MainPageViewModels()
        {

        }
        #region 属性
        private bool _isEnabledBtn = true;
        public bool IsEnabledBtn
        {
            get
            {
                return _isEnabledBtn;
            }
            set
            {
                _isEnabledBtn = value;
                OnPropertyChanged("IsEnabledBtn");
            }
        }
        public double RangeValue
        {
            get; set;
        } = 0;

        /// <summary>
        /// 正在更新的内容
        /// </summary>
        public string UpdateContent { get; set; }
        #endregion 属性

        #region command
        private RelayCommand _startUpdateCommand;
        public RelayCommand StartUpdateCommand
        {
            get
            {
                return _startUpdateCommand ?? (_startUpdateCommand = new RelayCommand(() =>
                {
                    ThreadPool.QueueUserWorkItem(callBack =>
                    {
                        try
                        {
                            IsEnabledBtn = false;
                            VersionCompare.Instance.GetUpdateList();
                            if (MainProcessOpreate.Instatnce.HasMainForm())
                            {
                                if (MessageBox.Show("检测到您的程序正在运行，是否强行关闭？", "提示", MessageBoxButton.YesNo) == MessageBoxResult.No)
                                {
                                    MainProcessOpreate.Instatnce.OpreateMainForm(true);
                                }
                                else
                                {
                                    return;
                                }
                            }
                         Application.Current.Dispatcher.Invoke(new Action<string>(ViewBase.ExecuteStepAction), new object[] { "2" });
                    }
                        catch (Exception ex)
                        {
                            LogHelper.Error("StartUpdateCommand", ex);
                        }
                        finally
                        {
                            IsEnabledBtn = true;
                        }
                    });
                }));
            }
        }

        private RelayCommand _cancelCommand;
        public RelayCommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new RelayCommand(() =>
                {
                    ResultPage _resultPage = new ResultPage();
                    _resultPage.Result = 2;
                    ViewBase.AddDictInfoAction("3", _resultPage);
                    ViewBase.ExecuteStepAction("3");
                }));
            }
        }

        #endregion command
    }
}
