using Metro.DynamicModeules.Interface.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Data;
using Metro.DynamicModeules.Interface;
using System.Windows.Controls;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Common;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Metro.DynamicModeules.BLL.Base;
using System.Collections;

namespace Metro.DynamicModeules.BaseControls.ViewModel
{
    /// <summary>
    /// 带数据处理的子窗体viewModel
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class DataChildBaseViewModel<T> : ChildBaseViewModel, ISummaryView<T>//, IPrintableForm
           where T : class, new()
    {

        public DataChildBaseViewModel()
        {
            InitializeForm();
            _bll = InitBll();
        }
        protected BllBase<T> _bll;
        /// <summary>
        /// 初始化业务逻辑层的对象
        /// </summary>
        /// <returns></returns>
        protected abstract BllBase<T> InitBll();



        /// <summary>
        /// 自定义初始化窗体操作, 窗体的Load事件必须调用此方法
        /// </summary>
        protected virtual void InitializeForm()
        {
            this.InitButtons();//初始化本窗体的按钮
            this.SetViewMode();//预设为数据查看模式
            //无操作状态下不可输入数据
            //SetDetailEditorsAccessable(_DetailGroupControl, false);
        }



        /// <summary>
        /// 是否数据发生改变
        /// </summary>
        public override bool DataChanged
        {
            get { return this.IsAddOrEditMode; }
        }



        /// <summary>
        /// 是否新增/修改模式
        /// </summary>
        public bool IsAddOrEditMode
        {
            get { return (UpdateType == UpdateType.Add) || (UpdateType == UpdateType.Modify); }
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
        bool _hasEnabled;
        /// <summary>
        /// 原始数据
        /// </summary>
        public T OriginalData { get; set; }
        /// <summary>
        /// 初始化数据窗体的按钮
        /// </summary>
        public override void InitButtons()
        {
            base.InitButtons();
            List<ButtonInfoViewModel> dataButton = (List<ButtonInfoViewModel>)this.GetDataOperatableButtons();
            //List<ButtonInfoViewModel> printButton = this.GetPrintableButtons();
            foreach (var item in dataButton)
            {
                this.Buttons.Add(item);
            }
            //foreach (var item in printButton)
            //{
            //    this.Buttons.Add(item);
            //}
        }

        /// <summary>        
        ///设置为编辑模式
        ///数据操作两种状态.1：数据修改状态 2：查看数据状态 
        /// </summary>
        protected virtual void SetEditMode()
        {
            foreach (ButtonInfoViewModel button in Buttons)
            {

            }
            //_buttons.FirstOrDefault(b=>b.Name=="btnView").IsEnabled = false;
        }



        /// <summary>
        /// 检查按钮的权限
        /// </summary>
        /// <param name="authorityValue">权限值</param>
        /// <returns></returns>
        public override bool ButtonAuthorized(int authorityValue)
        {
            //超级用户拥有所有权限
            //窗体可用权限=2^n= 1+2+4=7
            //比如新增功能点是2,那么检查新增按钮的方法是：  2 & 7 = 2，表示有权限。
            //
            bool isAuth = true;// Loginer.CurrentUser.IsAdmin() || (authorityValue & this.FormAuthorities) == authorityValue;
            return isAuth;
        }

        /// <summary>
        /// 按钮状态发生变化
        /// </summary>        
        protected virtual void ButtonStateChanged(UpdateType currentState)
        {
            //PackIconMaterial FileFind;  // PackIconControl<PackIconMaterialKind>
            //PackIconMaterialLight Kind; //PackIconControl<PackIconMaterialLightKind>
            //PackIconFontAwesome EyeSlas; //PackIconControl<PackIconFontAwesomeKind>
            //PackIconOcticons Alert;  //PackIconControl<PackIconOcticonsKind>
            //PackIconModern _3dCollada;  //PackIconControl<PackIconModernKind>
            //PackIconEntypo AircraftLand;  //PackIconControl<PackIconEntypoKind>
            //PackIconSimpleIcons Amazon;  // PackIconControl<PackIconSimpleIconsKind>

        }



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

        /// <summary>
        /// 设置某个编辑控件状态.ReadOnly or Enable . (递归)循环控制
        /// </summary>


        /// <summary>
        /// 双击表格事件
        /// </summary>
        protected virtual void OnGridViewDoubleClick(object sender, EventArgs e)
        {
            try
            {
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



        public int RowCount
        {
            get
            {
                return DataSource == null ? 0 : DataSource.Count;
            }
        }

        public int FocusedRowHandle { get; set; }
        public ObservableCollection<T> DataSource { get; set; }

        public ListCollectionView View
        {
            get
            {
                if (null == DataSource)
                {
                    return null;
                }
                else
                {
                    return CollectionViewSource.GetDefaultView(DataSource) as ListCollectionView;
                }
            }
        }

        T _focusedRow;
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
                //OriginalData = value.CloneModel();
            }
        }


        /// <summary>
        ///获取指定的资料行
        /// </summary>
        public T GetDataRow(int rowIndex)
        {
            if (rowIndex < 0) return default(T);
            if (View != null)
            {
                return View.GetItemAt(rowIndex) as T;
            }
            return null;
        }

        /// <summary>
        /// 显示明细页
        /// </summary>
        protected virtual void ShowDetailPage(bool disableSummaryPage)
        {
            try
            {
                //this.tpDetail.PageEnabled = true; //2015.6.15 陈刚 不再对Page作禁用
                //tcBusiness.SelectedTabPage = this.tpDetail;
                //tpSummary.PageEnabled = !disableSummaryPage;//2015.6.15 陈刚 不再对Page作禁用
                //FocusEditor(); //第一个编辑框获得焦点.
                //this.ResumeLayout();
            }
            catch (Exception ex)
            {
                //Msg.ShowException(ex);
            }
        }

        /// <summary>
        /// 显示主表页
        /// </summary>
        protected void ShowSummaryPage(bool disableDetailPage)
        {
            //try
            //{
            //    this.tpSummary.PageEnabled = true;//2015.6.15 陈刚 不再对Page作禁用
            //    tcBusiness.SelectedTabPage = this.tpSummary;
            //    // tpDetail.PageEnabled = !disableDetailPage;//2015.6.15 陈刚 不再对Page作禁用
            //    if (View != null) SetFocus();
            //}
            //catch (Exception ex)
            //{ Msg.ShowException(ex); }
        }

        /// <summary>
        /// 显示当前操作消息
        /// </summary>
        protected void ShowTip(string tip)
        {
            //lblPrompt.Text = tip;
            //lblPrompt.Update();
        }

        /// <summary>
        ///获取当前光标所在的资料行. 
        /// </summary>
        protected T GetFocusedRow()
        {
            if (FocusedRowHandle < 0)
            {
                return default(T);
            }
            else
            {
                return GetDataRow(FocusedRowHandle);
            }
        }

        /// <summary>
        /// 关窗体中...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void FrmBaseDataForm_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (this.DataChanged)
        //        e.Cancel = !Msg.AskQuestion("您修改了数据没有保存，确定要退出吗?");
        //}

        /// <summary>
        /// 清空容器内输入框.
        /// </summary>
        public void ClearContainerEditorText(Control container)
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
        /// 绑定Summary的导航按钮.
        /// </summary>        
        //protected void BindingSummaryNavigator(ControlNavigator navigator, DataGrid gc)
        //{
        //    navigator.NavigatableControl = gc;
        //    navigator.ButtonClick += new NavigatorButtonClickEventHandler(OnSummaryNavigatorButtonClick);
        //}

        /// <summary>
        /// 主表格导航按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void OnSummaryNavigatorButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    try
        //    {
        //        CCursor.ShowWaitCursor();
        //        NavigatorButton btn = (NavigatorButton)e.Button;
        //        ControlNavigatorButtons buttons = ((ControlNavigator)sender).Buttons;
        //        if (e.Button == buttons.First) DoMoveFirst();
        //        if (e.Button == buttons.Prev) DoMovePrior();
        //        if (e.Button == buttons.Next) DoMoveNext();
        //        if (e.Button == buttons.Last) DoMoveLast();
        //    }
        //    finally
        //    {
        //        e.Handled = true;
        //        CCursor.ShowDefaultCursor();
        //    }
        //}




        /// <summary>
        /// 删除表格内指定行号的记录
        /// </summary>
        /// <param name="rowHandle"></param>
        protected virtual void DeleteSummaryRow(int rowHandle)
        {
            if (rowHandle >= 0)
            {
                View.RemoveAt(rowHandle);
            }
        }

        /// <summary>
        /// 在保存时有此情况发生: 不会更新最后一个编辑框里的数据!
        /// 当移除焦点后会更新输入框的数据. 2015.7.15 陈刚 确保最后录入的数据能绑定到对应的数据源中
        /// </summary>
        protected void UpdateLastControl()
        {
            try
            {
                //if (ActiveControl == null) return;
                //Control ctl = ActiveControl;
                //txtFocusForSave.Focus();
                //ActiveControl = ctl;
            }
            catch (Exception ex)
            {
                // Msg.ShowException(ex);
            }
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
                if (UpdateType == UpdateType.Add)
                {
                    T newrow = new T();//表格的数据源增加一条记录
                    this.ReplaceDataRowChanges(summary, newrow);//替换数据
                    DataSource.Add(newrow);
                    RefreshDataSource();
                }

                //如果是修改后保存,将最新数据替换当前记录的数据.
                if (UpdateType == UpdateType.Modify || UpdateType == UpdateType.None)
                {
                    var dr = GetDataRow(FocusedRowHandle);
                    this.ReplaceDataRowChanges(summary, dr);//替换数据
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
                    UpdateType = UpdateType.None;
                }
            }
        }


        /// <summary>
        /// 刷新数据源
        /// </summary>
        public virtual void RefreshDataSource()
        {
            throw new NotImplementedException();
        }

        #region Summary数据导航功能


        ICommand _moveCommand;
        /// <summary>
        /// 导航command
        /// </summary>
        public ICommand NavigateCommand
        {
            get
            {
                return _moveCommand ?? (_moveCommand = new RelayCommand<NavigateType>((navType) =>
                {
                    switch (navType)
                    {
                        case NavigateType.First:
                            MoveFirst();
                            break;
                        case NavigateType.Last:
                            MoveLast();
                            break;
                        case NavigateType.Next:
                            MoveNext();
                            break;
                        case NavigateType.Previous:
                            MovePrior();
                            break;
                    }
                }));
            }
        }
        public virtual void MoveFirst()
        {
            View.MoveCurrentToFirst();
        }

        public virtual void MovePrior()
        {
            View.MoveCurrentToPrevious();
        }

        public virtual void MoveNext()
        {
            View.MoveCurrentToNext();
        }

        public virtual void MoveLast()
        {
            View.MoveCurrentToLast();
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
