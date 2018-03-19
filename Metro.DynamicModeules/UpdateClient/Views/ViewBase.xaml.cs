using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace UpdateClient.Views
{
    /// <summary>
    /// ViewBase.xaml 的交互逻辑
    /// </summary>
    public partial class ViewBase : Window
    {
        public ViewBase()
        {
            InitializeComponent();
        }

        private void ViewBase_Closed(object sender, EventArgs e)
        {
           // MainProcessOpreate.Instatnce.OpreateMainForm(false);
           // Environment.Exit(0);
        }

        private Dictionary<string, Page> uiElementLst;

        /// <summary>
        /// 添加元素
        /// </summary>
        /// <param name="element"></param>
        private void AddControl(Page element)
        {
            _homeframe.Content = element;
        }

        public static Action<string> ExecuteStepAction { get; private set; }

        /// <summary>
        /// 添加Page集合
        /// </summary>
        public static Action<string, Page> AddDictInfoAction { get; private set; }

        private void windowBase_Loaded(object sender, RoutedEventArgs e)
        {
           // MainProcessOpreate.Instatnce.OpreateMainForm(true);
            ExecuteStepAction = new Action<string>((number) =>
            {
                AddControl(uiElementLst[number]);
            });
            AddDictInfoAction = new Action<string, Page>(
                (number, page) =>
                {
                    AddDictInfo(number, page);
                });
            uiElementLst = new Dictionary<string, Page>();
            AddDictInfo("1", new MainPage());
            AddDictInfo("2", new DownloadPage());
            AddControl(uiElementLst["1"]);
        }
        private void AddDictInfo(string number, Page page)
        {
            if (uiElementLst.ContainsKey(number))
            {
                return;
            }
            uiElementLst.Add(number, page);
        }

        private void windowBase_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
