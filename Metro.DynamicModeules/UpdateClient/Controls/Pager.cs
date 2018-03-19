using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace XHClient.UpdateClient.Controls
{
    public class Pager : UserControl
    {

        public static readonly DependencyProperty PageInfoProperty = DependencyProperty.Register("PageInfo", typeof(string), typeof(Pager));
        public static readonly DependencyProperty PageDataInfoProperty = DependencyProperty.Register("PageDataInfo", typeof(string), typeof(Pager));
        public static readonly DependencyProperty PageSizeProperty = DependencyProperty.Register("PageSize", typeof(int), typeof(Pager), new PropertyMetadata(0, DataPropertyChanged));
        public static readonly DependencyProperty PageSizeInitProperty = DependencyProperty.Register("PageSizeInit", typeof(int), typeof(Pager));
        public static readonly DependencyProperty PageIndexProperty = DependencyProperty.Register("PageIndex", typeof(int), typeof(Pager), new PropertyMetadata(0, DataPropertyChanged));
        public static readonly DependencyProperty PageDataCountProperty = DependencyProperty.Register("PageDataCount", typeof(int), typeof(Pager), new PropertyMetadata(0, DataPropertyChanged));
        public static readonly DependencyProperty IsLastPageProperty = DependencyProperty.Register("IsLastPage", typeof(bool), typeof(Pager), new PropertyMetadata(true));
        public static readonly DependencyProperty PageIndexCommandProperty = DependencyProperty.Register("PageIndexCommand", typeof(ICommand), typeof(Pager), new PropertyMetadata(null, DataPropertyChanged));

        public string PageDataInfo
        {
            get { return (string)GetValue(PageDataInfoProperty); }
            set { SetValue(PageDataInfoProperty, value); }
        }
        public string PageInfo
        {
            get { return (string)GetValue(PageInfoProperty); }
            set { SetValue(PageInfoProperty, value); }
        }
        public int PageSize
        {
            get { return (int)GetValue(PageSizeProperty); }
            set { SetValue(PageSizeProperty, value); }
        }
        public int PageSizeInit
        {
            get { return (int)GetValue(PageSizeInitProperty); }
            set { SetValue(PageSizeInitProperty, value); }
        }
        public int PageIndex
        {
            get { return (int)GetValue(PageIndexProperty); }
            set { SetValue(PageIndexProperty, value); }
        }
        public int PageDataCount
        {
            get { return (int)GetValue(PageDataCountProperty); }
            set { SetValue(PageDataCountProperty, value); }
        }
        public bool IsLastPage
        {
            get { return (bool)GetValue(IsLastPageProperty); }
            set { SetValue(IsLastPageProperty, value); }
        }
        public ICommand PageIndexCommand
        {
            get { return (ICommand)GetValue(PageIndexCommandProperty); }
            set { SetValue(PageIndexCommandProperty, value); }
        }
        public int PageCount { get; set; }
        private Button _btnPre;
        private Button _btnNxt;
        public override void OnApplyTemplate()
        {

            _btnPre = GetElement<Button>("btPre");// as Button;
            _btnNxt = GetElement<Button>("btNxt");// as Button;
            InitialContainer();
            SetValue(PageSizeProperty, PageSizeInit);//给pagesize赋值，更新viewModel的数据
            //PageSize = PageSizeInit;//
            base.OnApplyTemplate();
        }

        private T GetElement<T>(string name) where
            T : FrameworkElement, new()
        {
            return (GetTemplateChild(name) as T) ?? new T();
        }

        private void InitialContainer()
        {
            _btnPre.Click -= btPre_Click;
            _btnNxt.Click -= btNxt_Click;

            _btnPre.Click += btPre_Click;
            _btnNxt.Click += btNxt_Click;
        }

        private static void DataPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue == e.NewValue)
                return;
            Pager pctrl = (Pager)d;
            pctrl.DealWithPropertyChanged(pctrl, e);
        }

        private void DealWithPropertyChanged(Pager pctrl, DependencyPropertyChangedEventArgs obj)
        {
            if (PageSize == 0)
                return;
            PageCount = PageDataCount % PageSize > 0 ? (PageDataCount / PageSize + 1) : PageDataCount / PageSize;
            IsLastPage = false;
            if (PageIndex + 1 >= PageCount || PageCount == 0)
                IsLastPage = true;
            if (PageIndex + 1 > PageCount && PageCount > 0)
            {
                PageIndex = PageIndex - 1;
                DealWithPager(PageIndex);
            }
            if (PageDataCount == 0)
                PageDataInfo = string.Format("{0}/{1}", PageIndex, PageCount);
            else if (PageSize > 0 && PageDataCount > 0)
                PageDataInfo = string.Format("{0}/{1}", PageIndex + 1, PageCount);
            //只有在加载的时候，才运用导航首次加载数据
            if (!(obj.Property.Name == "PageIndexCommand" || obj.Property.Name == "PageSize"))
                return;
            if (PageSize > 0 && PageSize != PageSizeInit)
                return;
            if (PageIndexCommand != null && PageSize != 0 && PageSizeInit > 0)//数据发生改变的时候，不调用分页功能
                DealWithPager(PageIndex);
        }

        private void btPre_Click(object sender, RoutedEventArgs e)
        {
            if (PageIndex <= 0)
                return;
            PageIndex--;
            DealWithPager(PageIndex);
        }

        private void btNxt_Click(object sender, RoutedEventArgs e)
        {
            if (PageIndex + 1 == PageCount)
                return;
            PageIndex++;
            DealWithPager(PageIndex);
        }

        private void DealWithPager(int pageindex)
        {
            IsLastPage = (PageIndex + 1) == PageCount || PageCount == 0;
            if (PageIndexCommand != null) ExecutePageing();
            //this.tbInfo2.Text = IsLastPage.ToString();
        }

        private void ExecutePageing()
        {

            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("PageSize", PageSize);
            dic.Add("PageIndex", PageIndex);
            dic.Add("PageDataCount", PageDataCount);
            PageIndexCommand.Execute(dic);
        }
        //public virtual event PropertyChangedEventHandler PropertyChanged;



        //public event PropertyChangedEventHandler PropertyChanged;
    }
}
