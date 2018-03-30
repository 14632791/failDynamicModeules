﻿using GalaSoft.MvvmLight.Command;
using Metro.DynamicModeules.BaseControls.ControlEx;
using Metro.DynamicModeules.BLL;
using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Common.ExpressionSerialization;
using Metro.DynamicModeules.Interface.Sys;
using Metro.DynamicModeules.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Metro.DynamicModeules.BaseControls.ViewModel
{
    /// <summary>
    /// 带数据处理的子窗体viewModel
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class DataChildBaseViewModel<T> : ChildBaseViewModel, ISummaryView<T>//, IPrintableForm
           where T : class, new()
    {

        protected BllBase<T> _bll;
        /// <summary>
        /// 初始化业务逻辑层的对象
        /// </summary>
        /// <returns></returns>
        protected abstract BllBase<T> InitBll();

        public override void Initialize()
        {
            base.Initialize();
            _bll = InitBll();
            //RefreshDataSource();
        }

        protected override void SetViewMode()
        {
            base.SetViewMode();
        }
        /// <summary>
        /// 是否数据发生改变
        /// </summary>
        public override bool DataHasChanged()
        {
            return IsAddOrEditMode || !FocusedRow.CompareModel(OriginalData);
        }


        /// <summary>
        /// 是否新增/修改模式
        /// </summary>
        public bool IsAddOrEditMode
        {
            get
            {
                return UpdateType == DataRowState.Added ||
                  UpdateType == DataRowState.Deleted ||
                  UpdateType == DataRowState.Modified;
            }
        }

        /// <summary>
        /// 对应的文本控件是否可编辑
        /// </summary>
        public bool HasEnabled
        {
            get
            {
                return _hasEnabled;
            }
            set
            {
                _hasEnabled = value;
                RaisePropertyChanged(() => HasEnabled);
            }
        }
        bool _hasEnabled = true;
        /// <summary>
        /// 原始数据
        /// </summary>
        public T OriginalData { get; set; }





        #region IDataOperatable接口的方法


        /// <summary>
        /// 查看选中记录的数据
        /// </summary>
        /// <param name="sender"></param>
        public override void DoViewContent()
        {
            base.DoViewContent();
            this.ButtonStateChanged(UpdateType);
        }



        #endregion

        #region Set Editors Accessable




        /// <summary>
        /// 设置Grid自定义按钮(Add,Insert,Delete)状态
        /// </summary>
        protected void SetGridCustomButtonAccessable(DataGrid gridControl, bool value)
        {
            //NavigatorCustomButtons custom = gridControl.EmbeddedNavigator.Buttons.CustomButtons;
            //if (custom != null && custom.Count == 3)
            //{
            //    custom[DetailButtons.Add].Enabled = value; //add
            //    custom[DetailButtons.Insert].Enabled = value;//insert
            //    custom[DetailButtons.Delete].Enabled = value;//del
            //}
        }

        ICommand _gridDoubleClickCommand;
        public ICommand GridDoubleClickCommand
        {
            get
            {
                return _gridDoubleClickCommand ?? (_gridDoubleClickCommand = new RelayCommand(OnGridViewDoubleClick));
            }
        }


        /// <summary>
        /// 双击表格方法
        /// </summary>
        protected virtual void OnGridViewDoubleClick()
        {
            try
            {
                _flipPanel.IsFlipped = !_flipPanel.IsFlipped;
                //Buttons
                //if (SystemConfig.CurrentConfig == null) return;
                //if (!this.HasData()) return;
                //PackIconButton btn = _buttons.GetButtonByName("btnEdit");
                //双击表格进入修改状态
                //if (SystemConfig.CurrentConfig.DoubleClickIntoEditMode)
                //{
                //    if (this.ButtonAuthorized(ButtonAuthority.EDIT)) //当前用户有修改权限
                //    {
                //        this.DoEdit(btn); //调用修改方法
                //        return;
                //    }
                //}
                //else //只能查看
                //{
                //this.DoViewContent(btn);
                //  SetDetailEditorsAccessable(_DetailGroupControl, false); //2015.6.15 注释 陈刚 2015.6.15
                //}
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.StackTrace);
            }
        }

        #endregion


        ObservableCollection<T> _dataSource;
        public ObservableCollection<T> DataSource
        {
            get
            {

                return _dataSource;
            }
            set
            {
                _dataSource = value;
                RaisePropertyChanged(() => DataSource);
                if (null != value)
                {
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        View = CollectionViewSource.GetDefaultView(DataSource) as ListCollectionView;
                        View.CurrentChanged += View_CurrentChanged;
                        View.Refresh();
                    }));
                }
            }
        }

        ListCollectionView _view = null;
        public ListCollectionView View
        {
            get
            {
                return _view;
            }
            set
            {
                _view = value;
                RaisePropertyChanged(() => View);
            }
        }

        T _focusedRow;
        /// <summary>
        /// 选中的当前行
        /// </summary>
        public T FocusedRow
        {
            get
            {

                return _focusedRow;
            }
            set
            {
                _focusedRow = value;
                RaisePropertyChanged(() => FocusedRow);
                View.MoveCurrentTo(value);
            }
        }





        /// <summary>
        /// 清空容器内输入框.
        /// </summary>
        public virtual void ClearContainerEditorText()
        {
            //for (int i = 0; i < container.child.Count; i++)
            //{
            //    if (container.Controls[i] is TextEdit)
            //        ((TextEdit)container.Controls[i]).EditValue = null;
            //    else if (container.Controls[i] is TextBoxBase)
            //        ((TextBoxBase)container.Controls[i]).Clear();
            //}
        }



        /// <summary>
        /// 替换记录对应字段的数据。
        /// </summary>
        /// <param name="sourceRow">数据源</param>
        /// <param name="destRow">需要替换的记录</param>
        protected void ReplaceDataRowChanges(T sourceRow, T destRow)
        {
            destRow = sourceRow.CloneModel();
        }

        /// <summary>
        /// 更新当前操作的缓存记录
        /// 保存数据后更新Summary当前记录.
        /// 如果是修改后保存,将最新数据替换当前记录的数据.
        /// 如果是新增后保存,在表格内插入一条记录.
        /// </summary>
        protected virtual void UpdateSummaryRow(T summary)
        {
            if (DataSource == null) return;
            if (summary == null) return;
            bool isSave = false;
            try
            {
                //如果是新增后保存,在表格内插入一条记录.
                if (UpdateType == DataRowState.Added)
                {
                    T newrow = new T();//表格的数据源增加一条记录
                    this.ReplaceDataRowChanges(summary, newrow);//替换数据
                    DataSource.Add(newrow);
                    //RefreshDataSource();
                }

                //如果是修改后保存,将最新数据替换当前记录的数据.
                if (UpdateType == DataRowState.Modified || UpdateType == DataRowState.Unchanged)
                {
                    this.ReplaceDataRowChanges(summary, FocusedRow);//替换数据
                    //dr.Table.AcceptChanges();
                    //RefreshRow(FocusedRowHandle);//修改或新增要刷新Grid数据          
                }
                isSave = true;
            }
            catch (Exception ex)
            {
                //Msg.ShowException(ex);
                isSave = false;
            }
            finally
            {
                if (isSave)
                {
                    UpdateType = DataRowState.Unchanged;
                }
            }
        }

        #region 数据操作（修改、删除、增加）
        public override void DoAdd()
        {
            base.DoAdd();
            UpdateType = DataRowState.Added;
        }
        public override void DoEdit()
        {
            UpdateType = DataRowState.Modified;
            base.DoEdit();
            OriginalData = FocusedRow.CloneModel();
        }

        public override void DoDelete()
        {
            base.DoDelete();
            UpdateType = DataRowState.Deleted;
        }
        #endregion


        #region Summary数据导航功能

        int _total;
        /// <summary>
        /// 总条数 View.Count
        /// </summary>
        public int Total
        {
            get
            {
                return _total;//null == View ? 0 : View.Count;
            }
            set
            {
                _total = value;
                RaisePropertyChanged(() => Total);
            }
        }

        int _currentPosition;
        /// <summary>
        /// 当前位置
        /// </summary>
        public int CurrentPosition
        {
            get
            {
                return _currentPosition;// null == View ? 0 : View.CurrentPosition + 1;
            }
            set
            {
                _currentPosition = value;
                RaisePropertyChanged(() => CurrentPosition);
            }
        }


        ICommand _navigateCommand;
        /// <summary>
        /// 数据行导航command
        /// </summary>
        public ICommand NavigateCommand
        {
            get
            {
                return _navigateCommand ?? (_navigateCommand = new RelayCommand<NavigateType>(MoveViewPosition,
                    (navType) =>
                {
                    return null != View && (navType == NavigateType.First && View?.CurrentPosition > 0 ||
                       navType == NavigateType.Previous && View?.CurrentPosition > 0 ||
                       navType == NavigateType.Next && View?.CurrentPosition < View?.Count - 1 ||
                        navType == NavigateType.Last && View?.CurrentPosition < View?.Count - 1);
                }));
            }
        }

        /// <summary>
        /// 移动viewdata的当前位置
        /// </summary>
        /// <param name="navType"></param>
        protected virtual void MoveViewPosition(NavigateType navType)
        {
            switch (navType)
            {
                case NavigateType.First:
                    View?.MoveCurrentToFirst();
                    break;
                case NavigateType.Last:
                    View?.MoveCurrentToLast();
                    break;
                case NavigateType.Next:
                    View?.MoveCurrentToNext();
                    break;
                case NavigateType.Previous:
                    View?.MoveCurrentToPrevious();
                    break;
                default:
                    break;
            }
        }



        int _currentPage = 0;
        /// <summary>
        /// 当前页数
        /// </summary>
        public int CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                RaisePropertyChanged("CurrentPage");
            }
        }

        int _totalPages;
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages
        {
            get { return _totalPages; }
            set
            {
                _totalPages = value;
                RaisePropertyChanged("TotalPages");
            }
        }
        ICommand _getDataByPageCmd;
        /// <summary>
        /// 数据页导航command
        /// </summary>
        public ICommand GetDataByPageCmd
        {
            get
            {
                return _getDataByPageCmd ?? (_getDataByPageCmd = new RelayCommand<NavigateType>(GetDataByPage,
                    (navType) =>
                    {
                        return null != View && TotalPages > 1 &&
                        (navType == NavigateType.First && CurrentPage > 1 ||
                           navType == NavigateType.Previous && CurrentPage > 1 ||
                           navType == NavigateType.Next && CurrentPage < TotalPages ||
                            navType == NavigateType.Last && CurrentPage < TotalPages);
                    }));
            }
        }
        /// <summary>
        /// 获取指定页面的数据
        /// </summary>
        /// <param name="navType"></param>
        protected async virtual void GetDataByPage(NavigateType navType)
        {
            await GetListCount();
            if (TotalPages <= 0)//没有任何数据就直接返回了
            {
                return;
            }
            switch (navType)
            {
                case NavigateType.First:
                    CurrentPage = 1;
                    break;
                case NavigateType.Last:
                    CurrentPage = TotalPages;
                    break;
                case NavigateType.Next:
                    CurrentPage++;
                    break;
                case NavigateType.Previous:
                    CurrentPage--;
                    break;
                default:
                    break;
            }
            //如果只有一页就不需要刷新了
            if (CurrentPage == TotalPages && CurrentPage == 1)
            {
                return;
            }
            await RefreshDataSource(CurrentPage);
        }

        /// <summary>
        /// 搜索条件
        /// </summary>
        /// <returns></returns>
        protected abstract Expression<Func<T, bool>> GetSearchExpression();

        /// <summary>
        /// 刷新数据源
        /// </summary>
        public async virtual Task RefreshDataSource(int page = 0)
        {
            var expression = GetSearchExpression();
            await GetListCount();
            DataSource = await _bll.GetSearchListByPage(expression, Globals.PageSize, page);
        }
        protected async virtual Task GetListCount()
        {
            long total = await _bll.GetListCount(GetSearchExpression());//获取总数量

            if (total <= 0)
            {
                CurrentPage = 0;
                TotalPages = 0;
            }
            else
            {
                int total2 = (int)total;
                TotalPages = total2 / Globals.PageSize;
                if (total2 % Globals.PageSize > 0)
                {
                    TotalPages++;
                }
                if (TotalPages > 0)
                {
                    CurrentPage = 1;
                }
            }
        }
        /// <summary>
        /// view改变后触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void View_CurrentChanged(object sender, EventArgs e)
        {
            if (FocusedRow != (T)View.CurrentItem)
            {
                FocusedRow = (T)View.CurrentItem;
            }
            Total = View.Count;
            CurrentPosition = View.CurrentPosition + 1;
        }


        string _search;

        /// <summary>
        /// 搜索字符串
        /// </summary>
        public string SearchText
        {
            get { return _search; }
            set
            {
                _search = value;
                RaisePropertyChanged("SearchText");
            }
        }
        /// <summary>
        /// 该功能是search按钮专用，与数据刷新有区别
        /// </summary>
        public async override void DoSearch()
        {
            base.DoSearch();
            await RefreshDataSource();
        }

        #endregion

    }
    /// <summary>
    /// 导航类型
    /// </summary>
    public enum NavigateType
    {
        /// <summary>
        /// 第一页
        /// </summary>
        First,

        /// <summary>
        /// 上一页
        /// </summary>
        Previous,


        /// <summary>
        /// 下一页
        /// </summary>
        Next,

        /// <summary>
        /// 最后一页
        /// </summary>
        Last
    }
}
